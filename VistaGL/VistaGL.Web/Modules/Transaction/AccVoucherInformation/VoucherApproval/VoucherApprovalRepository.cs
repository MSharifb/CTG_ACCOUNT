using VistaGL.Transaction.Entities;

namespace VistaGL.Transaction.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.AccVoucherInformationRow;

    public class VoucherApprovalRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler().Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }

        public ListResponse<eNextApprover> GetNextApprover(IDbConnection connection, eNextApproverListRequest request)
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            bool isComfiguration = connection.Query<bool>("select APV_ApprovalFlowConfiguration.IsConfigurableApprovalFlow from APV_ApprovalFlowConfiguration INNER JOIN APV_ApprovalProcess ON APV_ApprovalProcess.Id = APV_ApprovalFlowConfiguration.ApprovalProcesssId where APV_ApprovalProcess.ProcessNameEnum='AccVou'", commandType: CommandType.Text).FirstOrDefault();
            if (isComfiguration)
            {
                var list = connection.Query<eNextApprover>("SELECT * FROM fn_Apv_GetNextApprover ((select id from APV_ApprovalProcess where ProcessNameEnum='AccVou')," + request.Id + ")", commandType: CommandType.Text).ToList();

                var response = new ListResponse<eNextApprover>();
                response.Entities = list;
                return response;
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ZoneId", user.ZoneID);
                param.Add("@ApprovalProcess", "AccVou");
                param.Add("@EmployeeId", user.EmpId);

                var list = connection.Query<eNextApprover>("ACC_getApproverListByZoneId", param, commandType: CommandType.StoredProcedure).ToList();
                var response = new ListResponse<eNextApprover>();
                response.Entities = list;
                return response;
            }
        }

        public CheckIsApproverResponse IsVoucherApprover(IDbConnection connection, ListRequest request)
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;
            var zoneInfoId = user.ZoneID;
            var approverId = user.EmpId;

            var strQuery = @"SELECT ai.ApproverId
                            FROM
                                APV_ApproverInfo ai
                                INNER JOIN APV_ApprovalFlowDetail afd ON ai.ApprovalFlowDetailId = afd.Id
                                INNER JOIN APV_ApprovalFlowMaster afm ON afd.ApprovalFlowMasterId = afm.Id
                                INNER JOIN APV_ApprovalProcess afp ON afm.ApprovalProcesssId = afp.Id
                            WHERE
                                ai.MaxAmount > 0.0
                                AND afp.ProcessNameEnum = 'AccVou'
                                AND afm.ZoneId = " + zoneInfoId + " AND ai.ApproverId = " + approverId;

            var resultApproverId = connection.Query<int?>(strQuery);

            var response = new CheckIsApproverResponse();

            response.IsApprover = false;
            if (resultApproverId != null && resultApproverId.Any())
                response.IsApprover = true;

            return response;
        }

        public ListResponse<eNextApprover> GetAmountByApprover(IDbConnection connection, ListRequest request)
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;
            var response = new ListResponse<eNextApprover>();

            var accAmountinfo = connection.Query<eNextApprover>("SELECT APV_ApproverInfo.MinAmount, APV_ApproverInfo.MaxAmount,APV_ApprovalStep.StepName as StepTypeName FROM APV_ApproverInfo INNER JOIN APV_ApprovalFlowDetail ON APV_ApproverInfo.ApprovalFlowDetailId = APV_ApprovalFlowDetail.Id INNER JOIN APV_ApprovalStep ON APV_ApprovalStep.Id = APV_ApprovalFlowDetail.ApprovalStepTypeId where ApproverId =" + user.EmpId, commandType: CommandType.Text).ToList();
            response.Entities = accAmountinfo;
            return response;
        }

        public ListResponse<eNextApprover> GetPostingSendTo(IDbConnection connection, eNextApproverListRequest request)
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            DynamicParameters param = new DynamicParameters();
            param.Add("@ZoneId", user.ZoneID);
            param.Add("@ApprovalProcess", "AccPost");
            param.Add("@EmployeeId", user.EmpId);

            var list = connection.Query<eNextApprover>("ACC_getApproverListByZoneId", param, commandType: CommandType.StoredProcedure).ToList();
            var response = new ListResponse<eNextApprover>();
            response.Entities = list;
            return response;
        }

        public ListResponse<eNextApprover> GetRegretList(IDbConnection connection, eNextApproverListRequest request)
        {
            return GetRegretList(connection, request, fld.Id);
        }

        public ListResponse<eNextApprover> GetRegretList(IDbConnection connection, eNextApproverListRequest request, Field field)
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            DynamicParameters param = new DynamicParameters();
            param.Add("@ZoneId", user.ZoneID);
            param.Add("@ApprovalProcess", "AccVou");
            param.Add("@EmployeeId", user.EmpId);
            param.Add("@ApplicationId", request.Id);

            var list = connection.Query<eNextApprover>("ACC_getRegretListByZoneId", param, commandType: CommandType.StoredProcedure).ToList();
            var response = new ListResponse<eNextApprover>();
            response.Entities = list;
            return response;
        }

        //public GetNextNumberResponse GetNextNumber(IDbConnection connection, GetNextVoucherNumberRequest request, Field field)
        //{
        //    var prefix = request.Prefix ?? "";
        //    SqlQuery q = new SqlQuery()
        //        .From(field.Fields)
        //        .Select(Sql.Max(field.Expression))
        //        .Where(
        //            fld.TransactionTypeEntityId == request.TransactionTypeId);

        //    var max = connection.Query<string>(q)
        //        .FirstOrDefault();

        //    var response = new GetNextNumberResponse();

        //    long l;

        //    response.Number = max == null ||
        //        !long.TryParse(max.Substring(prefix.Length), out l) ? request.StartingNumber : l + 1;

        //    response.Serial = prefix + response.Number.ToString()
        //        .PadLeft(request.Length - prefix.Length, '0');

        //    return response;
        //}

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            protected override void ExecuteSave()
            {
                base.ExecuteSave();

                #region Auto Approve

                #region New improved vertion for approval

                DynamicParameters paramImproved = new DynamicParameters();
                paramImproved.Add("@VoucherId", Row.Id);
                paramImproved.Add("@ApproverId", Row.ApproverId == null ? 0 : Row.ApproverId);
                paramImproved.Add("@ActionName", ((ApprovalStatus)Convert.ToInt32(Row.ApprovalAction)).ToString());
                paramImproved.Add("@Comments", String.IsNullOrEmpty(Row.ApprovalComments) ? "-" : Row.ApprovalComments);
                paramImproved.Add("@LoginUser", user.Username);
                paramImproved.Add("@SignatureByEmployeeId", user.EmpId);

                if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Approved).ToString())
                {
                    paramImproved.Add("@HasSignature", 1);
                    paramImproved.Add("@SignatureTypeId", Convert.ToInt32(SignatureType.ApprovedBy));
                }
                else if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Recommend).ToString())
                {
                    Row.EmpId = Row.ApproverId; // as last person of this voucher

                    paramImproved.Add("@HasSignature", 1);
                    paramImproved.Add("@SignatureTypeId", Convert.ToInt32(SignatureType.CheckedBy));
                }
                else if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Cancel).ToString())
                {
                    Row.EmpId = Row.ApproverId; // as last person of this voucher

                    paramImproved.Add("@HasSignature", 0);
                    paramImproved.Add("@SignatureTypeId", null);
                }
                else if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Regret).ToString())
                {
                    Row.EmpId = Row.RegretSendTo; // as last person of this voucher

                    Row.ApproverId = Row.RegretSendTo;
                    paramImproved.Add("@ApproverId", Row.ApproverId);
                    paramImproved.Add("@HasSignature", 0);
                    paramImproved.Add("@SignatureTypeId", null);
                }

                var spResult = Connection
                    .Query<String>("APV_ACCApprovalHistory", paramImproved, commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();

                var vouInfoRow = new Entities.AccVoucherInformationRow();
                vouInfoRow.EmpId = Row.ApproverId;

                if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                {
                    if (Row.LinkedWithAutoJV != null && Convert.ToBoolean(Row.LinkedWithAutoJV))
                    {
                        var journalVOucherEntityId = Convert.ToInt32(Row.LinkedVoucherIdForAutoJV);

                        paramImproved.Add("@VoucherId", journalVOucherEntityId);

                        spResult = Connection
                            .Query<String>("APV_ACCApprovalHistory", paramImproved, commandType: CommandType.StoredProcedure)
                            .FirstOrDefault();

                        vouInfoRow.Id = journalVOucherEntityId;
                        vouInfoRow.approveStatus = Row.approveStatus;
                        if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Approved).ToString())
                        {
                            vouInfoRow.EmpId = Row.EmpId;

                            if (Row.PostToLedger != null && Convert.ToInt32(Row.PostToLedger) == 1)
                            {
                                vouInfoRow.PostToLedger = Row.PostToLedger;
                                vouInfoRow.postingSendTo = Row.postingSendTo;
                            }
                        }
                        Connection.UpdateById<Entities.AccVoucherInformationRow>(vouInfoRow);
                    }
                }
                else if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Journal_Voucher))
                {
                    var v = AccVoucherInformationRow.Fields.As("v");
                    var vQuery = new SqlQuery()
                        .Select(v.Id)
                        .From(v)
                        .Where(v.LinkedVoucherIdForAutoJV == Row.Id.Value);

                    var paymentVoucherEntityId = Connection.Query<AccVoucherInformationRow>(vQuery)?.FirstOrDefault()?.Id;

                    //var paymentVoucherEntityId =
                    //    Connection
                    //    .List<Entities.AccVoucherInformationRow>()
                    //    .FirstOrDefault(x => x.LinkedVoucherIdForAutoJV == Row.Id)?.Id;

                    if (paymentVoucherEntityId > 0 && paymentVoucherEntityId != null)
                    {
                        paramImproved.Add("@VoucherId", paymentVoucherEntityId);

                        spResult = Connection
                            .Query<String>("APV_ACCApprovalHistory", paramImproved, commandType: CommandType.StoredProcedure)
                            .FirstOrDefault();

                        vouInfoRow.Id = paymentVoucherEntityId;
                        vouInfoRow.approveStatus = Row.approveStatus;
                        if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Approved).ToString())
                        {
                            vouInfoRow.EmpId = Row.EmpId;
                            if (Row.PostToLedger != null && Convert.ToInt32(Row.PostToLedger) == 1)
                            {
                                vouInfoRow.PostToLedger = Row.PostToLedger;
                                vouInfoRow.postingSendTo = Row.postingSendTo;
                            }
                        }
                        Connection.UpdateById<Entities.AccVoucherInformationRow>(vouInfoRow);
                    }
                }

                #endregion


                #region Old code for approval
                //var lastpplicationInformation = Connection.List<ApvApplicationInformationRow>(ApvApplicationInformationRow.Fields.ApplicationId == Row.Id.Value).OrderByDescending(p => p.Id).ToList();

                //DynamicParameters param1 = new DynamicParameters();
                //param1.Add("@ApplicationId", lastpplicationInformation[0].Id);

                //if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Approved).ToString())
                //    param1.Add("@ActionName", "Approved");

                //else if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Recommend).ToString())
                //    param1.Add("@ActionName", "Recommend");

                //else if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Cancel).ToString())
                //    param1.Add("@ActionName", "Reject");

                //else if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Regret).ToString())
                //{
                //    param1.Add("@ActionName", "Regret");
                //    Row.ApproverId = Row.RegretSendTo;
                //}

                //param1.Add("@Comments", Row.ApprovalComments);
                //param1.Add("@NextApproverId", Row.ApproverId == null ? 0 : Row.ApproverId);
                //param1.Add("@LoggedOnUser", user.Username);

                //string _result = Connection.Query<string>("APV_ProceedToNextStep", param1, commandType: CommandType.StoredProcedure).FirstOrDefault();


                //Entities.AccVoucherInformationRow vouInfoRow = new Entities.AccVoucherInformationRow();

                //if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                //{
                //    if (Row.LinkedWithAutoJV != null && Convert.ToBoolean(Row.LinkedWithAutoJV))
                //    {
                //        var journalVOucherEntityId = Convert.ToInt32(Row.LinkedVoucherIdForAutoJV);
                //        var lastApp1 = Connection.List<ApvApplicationInformationRow>(ApvApplicationInformationRow.Fields.ApplicationId == journalVOucherEntityId).OrderByDescending(p => p.Id).ToList();

                //        param1.Add("@ApplicationId", lastApp1[0].Id);

                //        var list2 = Connection
                //       .Query<String>("APV_ProceedToNextStep", param1, commandType: CommandType.StoredProcedure)
                //                    .FirstOrDefault();

                //        vouInfoRow.Id = journalVOucherEntityId;
                //        vouInfoRow.approveStatus = Row.approveStatus;
                //        if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Approved).ToString())
                //        {
                //            vouInfoRow.PostToLedger = Row.PostToLedger;
                //            vouInfoRow.postingSendTo = Row.postingSendTo;
                //        }
                //        Connection.UpdateById<Entities.AccVoucherInformationRow>(vouInfoRow);
                //    }
                //}
                //else if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Journal_Voucher))
                //{
                //    var paymentVoucherEntityId = Connection.List<Entities.AccVoucherInformationRow>().Where(x => x.LinkedVoucherIdForAutoJV == Row.Id).FirstOrDefault()?.Id;
                //    if (paymentVoucherEntityId > 0 && paymentVoucherEntityId != null)
                //    {
                //        var lastApp2 = Connection.List<ApvApplicationInformationRow>(ApvApplicationInformationRow.Fields.ApplicationId == paymentVoucherEntityId.Value).OrderByDescending(p => p.Id).ToList();

                //        param1.Add("@ApplicationId", lastApp2[0].Id);

                //        var list2 = Connection
                //       .Query<String>("APV_ProceedToNextStep", param1, commandType: CommandType.StoredProcedure)
                //                    .FirstOrDefault();

                //        vouInfoRow.Id = paymentVoucherEntityId;
                //        vouInfoRow.approveStatus = Row.approveStatus;

                //        if (Row.ApprovalAction == Convert.ToInt32(ApprovalStatus.Approved).ToString())
                //        {
                //            vouInfoRow.PostToLedger = Row.PostToLedger;
                //            vouInfoRow.postingSendTo = Row.postingSendTo;
                //        }

                //        Connection.UpdateById<Entities.AccVoucherInformationRow>(vouInfoRow);
                //    }
                //}
                #endregion
                #endregion
            }
        }

        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }

        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow>
        {
            protected override void OnReturn()
            {
                base.OnReturn();
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;

                int processNameEnumId = Connection.Query<int>("select id from APV_ApprovalProcess where ProcessNameEnum='AccVou'", commandType: CommandType.Text).FirstOrDefault();


                var list = Connection.Query<eNextApprover>("SELECT * FROM fn_Apv_GetNextApprover (" + processNameEnumId + "," + Row.Id + ") gn where gn.CurrentRecommenderApproverId=" + user.EmpId, commandType: CommandType.Text).FirstOrDefault();
                Row.ApprovalAction = list?.RequiredActionId.ToString() ?? string.Empty;
                var lastpplicationInformation = new ApvApplicationInformationRepository()
                    .List(Connection, new ListRequest { Criteria = new Criteria("ApplicationId") == Row.Id.Value && new Criteria("ApprovalProcessId") == processNameEnumId }).Entities
                    .OrderByDescending(p => p.Id);

                //   var lastpplicationInformation = Connection.List<Entities.ApvApplicationInformationRow>(Entities.ApvApplicationInformationRow.Fields.ApplicationId == Row.Id.Value).OrderByDescending(p => p.Id).ToList();
                var modifiedList = new List<ApvApplicationInformationRow>();

                var model = new ApvApplicationInformationRow();
                foreach (var item in lastpplicationInformation)
                {
                    model = new ApvApplicationInformationRow();

                    model.IDate = item.IDate;
                    model.IUser = item.IUser;
                    model.ForwordBy = Connection.Query<string>("select FullName from PRM_EmploymentInfo where EmpId=" + "'" + item.IUser + "'", commandType: CommandType.Text).FirstOrDefault();
                    model.Status = Connection.Query<string>("SELECT StatusName FROM APV_ApprovalStatus where Id=" + "'" + item.ApprovalStatusId + "'", commandType: CommandType.Text).FirstOrDefault();
                    model.ApproverComments = item.ApproverComments;
                    model.EmploymentInfoFullName = item.EmploymentInfoFullName;
                    model.ApproverCode = item.ApproverCode;

                    modifiedList.Add(model);
                }

                Row.ApplicationInformationHistory = modifiedList.OrderBy(x => x.IDate).ToList();
            }
        }

        private class MyListHandler : ListRequestHandler<MyRow>
        {
            protected override void PrepareQuery(SqlQuery query)
            {
                base.PrepareQuery(query);
                var user = (UserDefinition)Authorization.UserDefinition;

                bool isConfigurable = Connection.Query<bool>(@"
                    select APV_ApprovalFlowConfiguration.IsConfigurableApprovalFlow
                    from APV_ApprovalFlowConfiguration INNER JOIN
                        APV_ApprovalProcess ON APV_ApprovalProcess.Id = APV_ApprovalFlowConfiguration.ApprovalProcesssId
                    where APV_ApprovalProcess.ProcessNameEnum='AccVou'", commandType: CommandType.Text).FirstOrDefault();


                if (user.ZoneID != 0 && user.FundControlInformationId != 0)
                {
                    query.Where(fld.approveStatus != (Int32)ApprovalStatus.Approved
                        && fld.FundControlInformationId == user.FundControlInformationId
                        && fld.ZoneId == user.ZoneID);

                    query.Where(isConfigurable
                        ? Criteria.Exists(
                            "SELECT gn.ApplicationId FROM fn_Apv_GetNextApprover ((select id from APV_ApprovalProcess where ProcessNameEnum='AccVou'),t0.id) gn where gn.CurrentRecommenderApproverId=" +
                            user.EmpId).ToString()
                        : Criteria.Exists(
                            "SELECT gn.ApplicationId FROM APV_ApplicationInformation gn where gn.ApproverId=" +
                            user.EmpId + " AND gn.ApplicationId = t0.id and t0.EmpId ="+ user.EmpId).ToString());
                }
                else
                {
                    throw new Exception("select fund control");
                }
            }

            protected override void OnReturn()
            {
                base.OnReturn();
                if (Row.Id.HasValue)
                {
                    UserDefinition user = (UserDefinition)Authorization.UserDefinition;

                    int processNameEnumId = Connection.Query<int>("select id from APV_ApprovalProcess where ProcessNameEnum='AccVou'", commandType: CommandType.Text).FirstOrDefault();

                    var eligibleAmountForCurrentUser = Connection.Query<eNextApprover>("select MinAmount, MaxAmount from APV_ApproverInfo where ApproverId=" + user.EmpId, commandType: CommandType.Text).FirstOrDefault();
                    var nextApproverForCurrentUser = Connection.Query<eNextApprover>("SELECT * FROM fn_Apv_GetNextApprover (" + processNameEnumId + "," + Row.Id + ") gn where gn.CurrentRecommenderApproverId=" + user.EmpId, commandType: CommandType.Text).FirstOrDefault();

                    foreach (var row in Response.Entities)
                    {
                        row.MinAmount = eligibleAmountForCurrentUser?.MinAmount ?? 0;
                        row.MaxAmount = eligibleAmountForCurrentUser?.MaxAmount ?? 0;

                        row.ApprovalAction = nextApproverForCurrentUser?.RequiredActionId.ToString() ?? string.Empty;
                    }

                }
            }
        }
    }


    public class eNextApprover
    {
        public int Id { get; set; }
        public String FullName { get; set; }
        public String ApproverTypeName { get; set; }
        public int NextStepId { get; set; }
        public int StepTypeId { get; set; }
        public String StepTypeName { get; set; }
        public int RequiredActionId { get; set; }
        public int ApplicationId { get; set; }
        public int ApplicantId { get; set; }
        public int CurrentRecommenderApproverId { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
    }

    public class eNextApproverListRequest : ListRequest
    {
        public int? Id { get; set; }
    }


    public class AVP_InitialStep
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int InitialStepId { get; set; }
        public String StepName { get; set; }
        public String ApproverTypeName { get; set; }
        public Decimal? MinAmount { get; set; }
        public Decimal? MaxAmount { get; set; }
    }

    public class ApproverRecSignature
    {
        public string EmployeeName { get; set; }
        public byte[] Signature { get; set; }
    }
}


using VistaGL.Transaction.Entities;

namespace VistaGL.Transaction.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Linq;

    using MyRow = Entities.AccVoucherInformationRow;

    public class VoucherPostingRepository
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

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            protected override void BeforeSave()
            {
                base.BeforeSave();
                var vg = Row.VoucherDetails;
            }

            protected override void ExecuteSave()
            {
                base.ExecuteSave();

                #region Auto Posting
                var user = (UserDefinition)Authorization.UserDefinition;

                DynamicParameters paramImproved = new DynamicParameters();
                paramImproved.Add("@VoucherId", Row.Id);
                paramImproved.Add("@ApproverId", Row.ApproverId);
                paramImproved.Add("@ActionName", "PostToLedger");
                paramImproved.Add("@Comments", "-");
                paramImproved.Add("@LoginUser", user.Username);
                paramImproved.Add("@HasSignature", 1);
                paramImproved.Add("@SignatureTypeId", Convert.ToInt32(SignatureType.PostedBy));
                paramImproved.Add("@SignatureByEmployeeId", user.EmpId);

                var spResult = Connection
                    .Query<String>("APV_ACCApprovalHistory", paramImproved, commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();

                var vouInfoRow = new Entities.AccVoucherInformationRow();

                if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                {
                    if (Convert.ToBoolean(Row.LinkedWithAutoJV))
                    {
                        var journalVOucherEntityId = Convert.ToInt32(Row.LinkedVoucherIdForAutoJV);

                        vouInfoRow.Id = journalVOucherEntityId;
                        vouInfoRow.PostToLedger = 1;
                        vouInfoRow.PostedBy = Row.PostedBy;
                        vouInfoRow.PostingDate = Row.PostingDate;
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

                    //var paymentVoucherEntityId = Connection.List<Entities.AccVoucherInformationRow>().Where(x => x.LinkedVoucherIdForAutoJV == Row.Id).FirstOrDefault()?.Id;

                    if (paymentVoucherEntityId > 0 && paymentVoucherEntityId != null)
                    {

                        var a = ApvApplicationInformationRow.Fields.As("a");
                        var appQuery = new SqlQuery()
                            .Select(a.Id)
                            .From(a)
                            .Where(a.ApplicationId == paymentVoucherEntityId.Value)
                            .OrderBy(a.Id, true);

                        var lastApp2 = Connection.Query<ApvApplicationInformationRow>(appQuery).ToList();

                        //var lastApp2 = Connection
                        //    .List<ApvApplicationInformationRow>(ApvApplicationInformationRow.Fields.ApplicationId == paymentVoucherEntityId.Value)
                        //    .OrderByDescending(p => p.Id).ToList();

                        vouInfoRow.Id = paymentVoucherEntityId;
                        vouInfoRow.PostToLedger = 1;
                        vouInfoRow.PostedBy = Row.PostedBy;
                        vouInfoRow.PostingDate = Row.PostingDate;
                        Connection.UpdateById<Entities.AccVoucherInformationRow>(vouInfoRow);
                    }
                }
                #endregion

            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow>
        {
            protected override void PrepareQuery(SqlQuery query)
            {
                base.PrepareQuery(query);
                //if (Authorization.Username != "admin")
                //{
                var user = (UserDefinition)Authorization.UserDefinition;

                if (user.FundControlInformationId != 0 && user.ZoneID != 0)
                {
                    query.Where(fld.FundControlInformationId == user.FundControlInformationId /*&& fld.ZoneId == user.ZoneID*/ && fld.postingSendTo == user.EmpId && fld.approveStatus == 6);
                }
                else
                {
                    throw new Exception("Select entity please!");
                }
                //}
            }
        }
    }
}
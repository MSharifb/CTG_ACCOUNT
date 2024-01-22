
using System.Collections.Generic;
using VistaGL.Configurations.Entities;

namespace VistaGL.Transaction.Repositories
{
    using Entities;
    using Modules.Common;
    using PublicEndpoints;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.AccVoucherInformationRow;

    public class AccVoucherInformationRepository
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

        public GetNewVoucherNoResponse GetNewVoucherNo(IDbConnection connection, GetNewVoucherNoRequest request)
        {
            var vUtil = new VoucherUtility(connection, Convert.ToInt32(request.ZoneId), Convert.ToInt32(request.FundControlInformationId));
            var newVoucherNo = vUtil.GetNewVoucherNo(Convert.ToInt32(request.TransactionTypeId), Convert.ToInt32(request.FinancialYearId), Convert.ToDateTime(request.VoucherDate), request.BankAccId);

            var response = new GetNewVoucherNoResponse();
            response.VoucherNo = newVoucherNo.VoucherNo;
            response.VoucherNumber = newVoucherNo.VoucherNumber;

            return response;
        }

        public ListResponse<AVP_InitialStep> GetApproverInfoByApplicant(IDbConnection connection, GetApproverInfoByApplicantRequest request)
        {
            bool isComfiguration = connection.Query<bool>("select APV_ApprovalFlowConfiguration.IsConfigurableApprovalFlow from APV_ApprovalFlowConfiguration INNER JOIN APV_ApprovalProcess ON APV_ApprovalProcess.Id = APV_ApprovalFlowConfiguration.ApprovalProcesssId where APV_ApprovalProcess.ProcessNameEnum='AccVou'", commandType: CommandType.Text).FirstOrDefault();

            UserDefinition user = (UserDefinition)Authorization.UserDefinition;
            if (isComfiguration)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ApplicantId", user.Username);
                param.Add("@ApprovalProcess", "AccVou");

                var list = connection.Query<AVP_InitialStep>("APV_GetApproverInfoByApplicant", param, commandType: CommandType.StoredProcedure).ToList();

                var response = new ListResponse<AVP_InitialStep>();
                response.Entities = list;
                return response;
            }
            else
            {
                var approvalStepTypeId = request.ApprovalStepTypeId ?? Convert.ToInt32(ApprovalStepType.Both);

                //DynamicParameters param = new DynamicParameters();
                //param.Add("@ZoneId", user.ZoneID);
                //param.Add("@ApprovalProcess", "AccVou");
                //param.Add("@EmployeeId", user.EmpId);
                //param.Add("@ApprovalStepTypeId", approvalStepTypeId);
                //var list = connection.Query<AVP_InitialStep>("ACC_getApproverListByZoneId", param, commandType: CommandType.StoredProcedure).ToList();

                var list = my.GetApproverList(user.ZoneID, "AccVou", user.EmpId, (ApprovalStepType)approvalStepTypeId);

                var response = new ListResponse<AVP_InitialStep>();
                response.Entities = list;
                return response;
            }

        }

        #region For Import Voucher Service

        public Boolean CreateVoucher(IDbConnection connection, BillingAPIVoucherInfo serviceInfo)
        {
            try
            {
                var query = String.Empty;
                var isSuccess = false;

                query = String.Format("SELECT Id FROM PRM_ZoneInfo WHERE ZoneCodeForBillingSystem = '{0}'", serviceInfo.zoneId.FirstOrDefault());
                var zoneId = connection.Query<int>(query).FirstOrDefault();

                var coaId = serviceInfo.voucherDetails.FirstOrDefault().BILL_TYPE_ID;
                var fundControlIdbyCOA = connection.Query<int>(@"SELECT fundControlId FROM acc_ChartofAccounts WHERE Id = " + coaId).FirstOrDefault();

                query = String.Format(@"SELECT COAId FROM acc_BankAccountInformation
                                                WHERE
                                                    accountNumber = '{0}'
                                                    AND entityId = {1}
                                                    AND ZoneInfoId = {2}", serviceInfo.bankCoaId?.FirstOrDefault(), fundControlIdbyCOA, zoneId);
                var bankCOAId = connection.Query<int>(query).FirstOrDefault();

                query = String.Format("SELECT Id FROM acc_Cost_Centre_or_Institute_Information WHERE userCode = '{0}'", serviceInfo.receiveFrom.FirstOrDefault());
                var subLedgerId = connection.Query<int>(query).FirstOrDefault();

                query = String.Format("SELECT name FROM acc_Cost_Centre_or_Institute_Information WHERE userCode = '{0}'", serviceInfo.receiveFrom.FirstOrDefault());
                var subLedgerName = connection.Query<String>(query).FirstOrDefault();

                // PARSING VOUCHER DATE
                var voucherDate = DateTime.ParseExact(serviceInfo.voucherDate.FirstOrDefault(),
                                                        "dd-MMM-yyyy",
                                                        System.Globalization.CultureInfo.InvariantCulture);

                query = String.Format("SELECT dbo.FN_AmounttoWords({0})", serviceInfo.voucherAmount.FirstOrDefault());
                var amountInWord = connection.Query<String>(query).FirstOrDefault();


                //
                var voucherInfo = new Entities.AccVoucherInformationRow();

                if (serviceInfo.voucherTypeId.FirstOrDefault() == Convert.ToInt32(ServiceVoucherType.JournalVoucher))
                {
                    voucherInfo.VoucherTypeId = Convert.ToInt32(VoucherType.Journal_Voucher);
                    voucherInfo.TransactionMode = "Other";
                    voucherInfo.TransactionType = "JOURNAL";
                    voucherInfo.TransactionTypeEntityId = 3;
                    voucherInfo.VoucherType = "-";
                }
                else
                {
                    voucherInfo.VoucherTypeId = Convert.ToInt32(VoucherType.Receipt_Voucher);
                    voucherInfo.TransactionMode = "BANK";
                    voucherInfo.TransactionType = "RECEIPT";
                    voucherInfo.TransactionTypeEntityId = 11;
                    voucherInfo.AccountHeadBankCash = bankCOAId;
                    voucherInfo.VoucherType = "Credit";
                }

                voucherInfo.EmpId = 11; // user admin
                voucherInfo.approveStatus = serviceInfo.ApproveStatus;
                if (serviceInfo.ApproveStatus == ApprovalStatus.Approved)
                {
                    voucherInfo.PostToLedger = 1;
                    voucherInfo.PostingDate = voucherDate;
                    voucherInfo.IsApproved = 1;
                }
                else
                {
                    voucherInfo.PostToLedger = 0;
                    voucherInfo.IsApproved = 0;
                }

                voucherInfo.SubModule = "FROM BILLING SYSTEM";

                voucherInfo.VoucherDate = voucherDate;
                voucherInfo.VoucherNo = serviceInfo.voucherNo.FirstOrDefault();
                voucherInfo.VoucherNumber = "0";
                voucherInfo.Amount = serviceInfo.voucherAmount.FirstOrDefault();
                voucherInfo.AmountInWords = amountInWord;
                voucherInfo.Description = serviceInfo.narration.FirstOrDefault() ?? "N/A";
                voucherInfo.IsAuto = 1;
                voucherInfo.IsSubmitted = 0;
                voucherInfo.PaytoOrReciveFrom = subLedgerName;
                voucherInfo.ChequeRemarks = "-";
                voucherInfo.LinkedWithAutoJV = false;

                var bankAccountId = 0;
                if (serviceInfo.voucherTypeId.FirstOrDefault() == Convert.ToInt32(ServiceVoucherType.CreditVoucher))
                {
                    query = String.Format("SELECT Id FROM acc_BankAccountInformation WHERE COAId = {0}", bankCOAId);
                    bankAccountId = connection.Query<int>(query).FirstOrDefault();
                    voucherInfo.BankAccountInformationId = bankAccountId;

                    voucherInfo.IsBankReconcile = 1;
                }

                query = String.Format("SELECT id FROM acc_Accounting_Period_Information WHERE '" + Convert.ToDateTime(voucherDate).ToString("yyyy-MM-dd") + "' between periodStartDate and periodEndDate");
                var financialYearId = connection.Query<int>(query).FirstOrDefault();
                voucherInfo.PostingFinancialYearId = financialYearId;

                voucherInfo.FundControlInformationId = fundControlIdbyCOA;
                voucherInfo.ZoneId = zoneId;
                voucherInfo.createdUserDate = DateTime.Now;
                voucherInfo.createdUserId = "11"; // userid of 'Administrator'

                // Save Voucher Information
                using (var uow = new UnitOfWork(connection))
                {
                    //var newVoucherId = connection.InsertAndGetID(voucherInfo);
                    var newVoucherId = uow.Connection.InsertAndGetID(voucherInfo);
                    Decimal totalCreditAmount = 0.0M;

                    foreach (var v in serviceInfo.voucherDetails.OrderByDescending(a=> Convert.ToDecimal(a.CR_AMOUNT)))
                    {
                        var voucherDetailRow = new AccVoucherDetailsRow()
                        {
                            VoucherInformationId = newVoucherId,
                            ChartofAccountsId = v.BILL_TYPE_ID,
                            DebitAmount = v.DR_AMOUNT,
                            CreditAmount = v.CR_AMOUNT,
                            Description = v.DESCRIPTION,
                            ConversionAmount = v.DR_AMOUNT > 0 ? v.DR_AMOUNT : v.CR_AMOUNT,
                            ConversionRate = 1,
                            EffectiveValue = v.DR_AMOUNT > 0 ? v.DR_AMOUNT : v.CR_AMOUNT,
                            CCreditAmount = v.CR_AMOUNT,
                            CDebitAmount = v.DR_AMOUNT,
                            CalculationAmount = v.DR_AMOUNT > 0 ? v.DR_AMOUNT : v.CR_AMOUNT,
                            CalculationRate = 1,
                            createdUserDate = DateTime.Now,
                            createdUserId = "11"
                        };
                        //var newDetailId = connection.InsertAndGetID(voucherDetailRow);
                        var newDetailId = uow.Connection.InsertAndGetID(voucherDetailRow);

                        var voucherDtlAlocation = new AccVoucherDtlAllocationRow()
                        {
                            VoucherDetailId = newDetailId,
                            CostCenterId = subLedgerId,
                            Amount = v.DR_AMOUNT > 0 ? v.DR_AMOUNT : v.CR_AMOUNT,
                            DebitAmount = v.DR_AMOUNT,
                            CreditAmount = v.CR_AMOUNT,
                            createdUserDate = DateTime.Now,
                            createdUserId = "11"
                        };
                        totalCreditAmount += v.CR_AMOUNT;
                        //connection.Insert(voucherDtlAlocation);
                        uow.Connection.Insert(voucherDtlAlocation);
                    }

                    if (serviceInfo.voucherTypeId.FirstOrDefault() == Convert.ToInt32(ServiceVoucherType.CreditVoucher))
                    {
                        var _bankDetails = new AccVoucherDetailsRow()
                        {
                            VoucherInformationId = newVoucherId,
                            ConversionAmount = serviceInfo.voucherAmount.FirstOrDefault(),
                            ConversionRate = 1,
                            ChartofAccountsId = bankCOAId,
                            CreditAmount = 0,
                            DebitAmount = totalCreditAmount, //serviceInfo.voucherAmount.FirstOrDefault(),
                            Description = null,
                            EffectiveValue = totalCreditAmount, //serviceInfo.voucherAmount.FirstOrDefault(),
                            CCreditAmount = 0,
                            CDebitAmount = totalCreditAmount, //serviceInfo.voucherAmount.FirstOrDefault(),
                            BankAccountInformationId = bankAccountId,
                            IsAccountHeadBankCash = true,
                            createdUserDate = DateTime.Now,
                            createdUserId = "11"
                        };
                        if (serviceInfo.ApproveStatus == ApprovalStatus.Approved)
                        {
                            _bankDetails.ClearDate = voucherDate;
                            _bankDetails.IsClearDate = 1;
                        }

                        //connection.Insert(_bankDetails);
                        uow.Connection.Insert(_bankDetails);
                    }


                    uow.OnCommit += () =>
                    {
                        isSuccess = true;
                    };

                    uow.Commit();
                } // -- end unit-of-work

                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured in " + ex.TargetSite.Name + "\r\n" + ex.Message, ex.InnerException);
            }

        }
        #endregion

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            protected override void BeforeSave()
            {
                base.BeforeSave();

                //try
                //{
                var query = String.Format("select * from acc_Accounting_Period_Information Where '" + Convert.ToDateTime(Row.VoucherDate).ToString("yyyy-MM-dd") + "' between periodStartDate and periodEndDate");
                var accPeriod = Connection.Query<AccAccountingPeriodInformationRow>(query).FirstOrDefault();
                if (accPeriod != null)
                {
                    if (accPeriod.IsClosed == true)
                    {
                        throw new ValidationError("This accounting period - " + accPeriod.YearName + " is closed! You cannot create/modify voucher.");
                    }
                }
                else
                {
                    throw new ValidationError("Sorry, Accounting period not found!");
                }

                #region Check login entity and bank account entity
                if (Row.AccountHeadBankCash != null && Row.AccountHeadBankCash > 0)
                {
                    var bankHeadEntityId = Connection.Query<int>("SELECT fundControlId FROM acc_ChartofAccounts where id = " + Row.AccountHeadBankCash, commandType: CommandType.Text).FirstOrDefault();
                    if (bankHeadEntityId > 0)
                    {
                        if (bankHeadEntityId != user.FundControlInformationId)
                        {
                            var currentEntity = Connection.Query<string>("SELECT fundControlName FROM acc_FundControlInformation where id = " + bankHeadEntityId, commandType: CommandType.Text).FirstOrDefault();
                            throw new ValidationError("Current Voucher entity is " + currentEntity + ". But your logged in entity is " + user.FundControlName + ". Please login with " + currentEntity + " entity in different tab and try to save voucher again.");
                        }
                    }
                }
                #endregion

                #region Check approver before edit a voucher
                if (!IsCreate && Row.createdUserId != "11") // Voucher from billing system - 11-Administrator
                {
                    // STEP 1: Check if the voucher is approved or not
                    string strQueryIsApproved = @"SELECT CASE WHEN (SELECT distinct 1
                                                                    FROM APV_ApplicationInformation
                                                                    WHERE applicationid = " + Row.Id + @"
                                                                        and ApprovalStatusId = 6) = 1 THEN 1 ELSE 0
                                                         END as 'IsApproved'";
                    var isApproved = Connection.Query<int>(strQueryIsApproved, commandType: CommandType.Text).FirstOrDefault();
                    if (isApproved == 1)
                    {
                        // STEP 2: Get approved by user of voucher
                        string strQueryApproverUserId = @"SELECT UserId
                                                        FROM TblUsers
                                                        WHERE LoginId IN (SELECT top 1 IUser
					                                                        FROM APV_ApplicationInformation
					                                                        WHERE applicationid = " + Row.Id + @"
                                                                                and ApprovalStatusId = 6 ORDER BY IDate)";
                        var approverUserId = Connection.Query<int>(strQueryApproverUserId, commandType: CommandType.Text).FirstOrDefault();
                        // STEP 3: If approved by user and current logged in user are not same then goto next step.
                        if (approverUserId != user.UserId)
                        {
                            // STEP 4: Get current approvers of user.zone
                            var list = my.GetApproverList(user.ZoneID, "AccVou", 0, ApprovalStepType.Approval);
                            // STEP 5: If user is one of current approver(s) of user.zone then everything is ok. otherwise throw error.
                            if ((list as List<AVP_InitialStep>).Any(f => f.Id == user.EmpId))
                            {
                                //-- everything is ok.
                            }
                            else
                            {
                                throw new ValidationError("Sorry, Only approver have permission to edit this voucher!");
                            }
                        }
                    }
                }
                #endregion


                if (IsCreate)
                {
                    Row.ZoneId = user.ZoneID;
                    Row.FundControlInformationId = user.FundControlInformationId;

                    Row.EmpId = Row.ApproverId; // as last person of this voucher

                    if (Row.ChequeBookId != null || Convert.ToInt32(Row.ChequeBookId) > 0)
                    {
                        var fldCheque = AccChequeRegisterRow.Fields.As("fldCheque");
                        var queryCheque = new SqlQuery()
                            .Select(fldCheque.Id)
                            .From(fldCheque)
                            .Where(fldCheque.ChequeBookId == Row.ChequeBookId.Value
                                    & fldCheque.ChequeNo == Row.ChequeNo);

                        var accChequeRegister = Connection.Query<AccChequeRegisterRow>(queryCheque)?.FirstOrDefault();

                        //if (Connection.List<AccChequeRegisterRow>().Any(c =>
                        //    c.ChequeBookId == Row.ChequeBookId && c.ChequeNo == Row.ChequeNo))
                        if (accChequeRegister != null)
                        {
                            throw new ValidationError("This cheque number is already used. Please select another one!");
                        }
                    }

                    #region Getting New Voucher No.
                    //
                    var vUtil = new VoucherUtility(Connection, Convert.ToInt32(Row.ZoneId), Convert.ToInt32(Row.FundControlInformationId));
                    var newVoucherNo = vUtil.GetNewVoucherNo(
                                                    Convert.ToInt32(Row.TransactionTypeEntityId)
                                                    , Convert.ToInt32(Row.PostingFinancialYearId)
                                                    , Convert.ToDateTime(Row.VoucherDate)
                                                    , Row.BankAccountInformationId);

                    Row.VoucherNo = newVoucherNo.VoucherNo;
                    Row.VoucherNumber = newVoucherNo.VoucherNumber;

                    if (Convert.ToBoolean(Row.LinkedWithAutoJV))
                    {
                        var transactionTypeEntityIdForJV = 0;
                        var transactionType = Connection.List<AccTransactionTypeRow>();
                        var tt = transactionType.FirstOrDefault(x => x.VoucherTypeId == Convert.ToInt32(VoucherType.Journal_Voucher) && x.IsbyDefault == true);
                        transactionTypeEntityIdForJV = Convert.ToInt32(tt.Id);

                        var voucherNojv = newVoucherNo.VoucherNo.Replace(newVoucherNo.VoucherNo.Substring(0, 2), "JV(DV)");
                        var voucherNumberjv = "0";
                        //GetNewVoucherNo(transactionTypeEntityIdForJV, out voucherNojv, out voucherNumberjv);
                        Row.AutoJVVoucherNo = voucherNojv;
                        Row.AutoJVVoucherNumber = voucherNumberjv;
                    }
                    #endregion

                }

                if (Row.ApproverId != null && Row.approveStatus == ApprovalStatus.Submit)
                {
                    Row.EmpId = Row.ApproverId; // as last person of this voucher
                }

                //}
                //catch (Exception ex)
                //{
                //    throw new Exception("Error Occured in " + ex.TargetSite.Name + "\r\n" + ex.Message, ex.InnerException);
                //}
            }

            protected override void ExecuteSave()
            {
                try
                {
                    var user = (UserDefinition)Authorization.UserDefinition;


                    #region BANK DETAILS
                    if (Row.IsBankWisePaymentVoucher == true || Row.IsBankWiseReceiptVoucher == true)
                    {
                        var _bankDetails = new AccVoucherDetailsRow()
                        {
                            ConversionAmount = Row.AccountBankCashAmount,
                            ConversionRate = 1,
                            ChartofAccountsId = Row.AccountHeadBankCash,
                            CreditAmount = Row.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher) ? Row.AccountBankCashAmount : 0,
                            DebitAmount = Row.VoucherTypeId == Convert.ToInt32(VoucherType.Receipt_Voucher) ? Row.AccountBankCashAmount : 0,
                            Description = Row.Description,
                            EffectiveValue = Row.AccountBankCashAmount,
                            CCreditAmount = Row.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher) ? Row.AccountBankCashAmount : 0,
                            CDebitAmount = Row.VoucherTypeId == Convert.ToInt32(VoucherType.Receipt_Voucher) ? Row.AccountBankCashAmount : 0,
                            BankAccountInformationId = Row.BankAccountInformationId,
                            IsAccountHeadBankCash = true,
                            ClearDate = Row.ClearDate,
                            IsClearDate = Row.IsClearDate
                        };
                        Row.VoucherDetails.Add(_bankDetails);
                    }
                    #endregion

                    if (Row.IsBankWisePaymentVoucher == true)
                    {
                        SaveBankWisePaymentVoucher();
                    }

                    //if (Row.TemplateStatus == 1)
                    //{
                    //    #region 1
                    //    if (Row.TemplateId == null)
                    //    {
                    //        var empAdvance = new Entities.AccEmpAdvanceRow();
                    //        empAdvance.Amount = Row.Amount;
                    //        empAdvance.TransactionMode = Row.TransactionMode;
                    //        empAdvance.Amount = Row.Amount;
                    //        empAdvance.RemainAmount = Row.Amount;
                    //        //   string[] COAMaping = { "BANK", "CASH" };
                    //        //   var _bankOrCash = Row.VoucherDetails.Where(p => COAMaping.Contains(p.ChartofAccountsCoaMapping)).FirstOrDefault();
                    //        empAdvance.CoAId = Row.TemplateCOAId;
                    //        if (Row.TemplateChequeRegisterId != 0)
                    //            empAdvance.ChequeRegisterId = Row.TemplateChequeRegisterId;
                    //        empAdvance.EmpId = Row.EmpId;
                    //        empAdvance.ZoneId = user.ZoneID;
                    //        empAdvance.Status = 1;
                    //        empAdvance.Narration = Row.Description;
                    //        empAdvance.CoAId2 = Row.TemplateCOAId2;
                    //        Int64? _empAdvId = Connection.InsertAndGetID(empAdvance);
                    //        Row.TemplateId = (int)_empAdvId;
                    //    }
                    //    else
                    //    {
                    //        var empAdvance = new Entities.AccEmpAdvanceRow()
                    //        {
                    //            Status = 1,
                    //            Id = Row.TemplateId
                    //        };
                    //        Connection.UpdateById(empAdvance);
                    //    }
                    //    #endregion
                    //}
                    //else if (Row.TemplateStatus == 2)
                    //{
                    //    var empAdvance = new Entities.AccEmpAdvanceRow()
                    //    {
                    //        RemainAmount = Row.RemainAmount - Row.Amount,
                    //        Id = Row.TemplateId
                    //    };
                    //    Connection.UpdateById(empAdvance);
                    //}
                    //else if (Row.TemplateStatus == 3)
                    //{
                    //    #region 3
                    //    if (Row.TemplateId == null)
                    //    {
                    //        var partyAdvance = new Entities.AccPartyPaymentRow();
                    //        partyAdvance.Amount = Row.Amount;
                    //        partyAdvance.TransactionMode = Row.TransactionMode;
                    //        partyAdvance.Amount = Row.Amount;
                    //        partyAdvance.RemainAmount = Row.Amount;
                    //        //   string[] COAMaping = { "BANK", "CASH" };
                    //        //   var _bankOrCash = Row.VoucherDetails.Where(p => COAMaping.Contains(p.ChartofAccountsCoaMapping)).FirstOrDefault();
                    //        partyAdvance.CoAId = Row.TemplateCOAId;
                    //        if (Row.TemplateChequeRegisterId != 0)
                    //            partyAdvance.ChequeRegisterId = Row.TemplateChequeRegisterId;
                    //        partyAdvance.PartyId = Row.EmpId;
                    //        partyAdvance.ZoneId = user.ZoneID;
                    //        partyAdvance.Status = 1;
                    //        partyAdvance.Narration = Row.Description;
                    //        partyAdvance.CoAId2 = Row.TemplateCOAId2;
                    //        Int64? _empAdvId = Connection.InsertAndGetID(partyAdvance);
                    //        Row.TemplateId = (int)_empAdvId;
                    //        Row.EmpId = null;
                    //    }
                    //    else
                    //    {
                    //        var partyAdvance = new Entities.AccPartyPaymentRow()
                    //        {
                    //            Status = 1,
                    //            Id = Row.TemplateId
                    //        };
                    //        Connection.UpdateById(partyAdvance);
                    //    }
                    //    #endregion
                    //}
                    //else if (Row.TemplateStatus == 4)
                    //{
                    //    var partyAdvance = new Entities.AccPartyPaymentRow()
                    //    {
                    //        RemainAmount = Row.RemainAmount - Row.Amount,
                    //        Id = Row.TemplateId
                    //    };
                    //    Connection.UpdateById(partyAdvance);
                    //}

                    base.ExecuteSave();

                    if (Row.ApproverId != null && Row.approveStatus == ApprovalStatus.Submit)
                    {
                        #region Submit Voucher

                        #region Improved Version (WRITTEN ONLY FOR ACC MODULE)
                        //
                        DynamicParameters paramImproved = new DynamicParameters();
                        paramImproved.Add("@VoucherId", Row.Id);
                        paramImproved.Add("@ApproverId", Row.ApproverId);
                        paramImproved.Add("@ActionName", ApprovalStatus.Submit.GetName());
                        paramImproved.Add("@Comments", "-");
                        paramImproved.Add("@LoginUser", user.Username);
                        paramImproved.Add("@HasSignature", 1);
                        paramImproved.Add("@SignatureTypeId", Convert.ToInt32(SignatureType.PreparedBy));
                        paramImproved.Add("@SignatureByEmployeeId", user.EmpId);


                        var spResult = Connection
                            .Query<String>("APV_ACCApprovalHistory", paramImproved, commandType: CommandType.StoredProcedure)
                            .FirstOrDefault();

                        var vouInfoRow = new Entities.AccVoucherInformationRow();
                        if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                        {
                            if (Row.LinkedWithAutoJV != null && Convert.ToBoolean(Row.LinkedWithAutoJV) == true)
                            {
                                var journalVOucherEntityId = Convert.ToInt32(Row.LinkedVoucherIdForAutoJV);
                                paramImproved.Add("@VoucherId", journalVOucherEntityId);

                                spResult = Connection
                                    .Query<String>("APV_ACCApprovalHistory", paramImproved, commandType: CommandType.StoredProcedure)
                                    .FirstOrDefault();

                                vouInfoRow.Id = journalVOucherEntityId;
                                vouInfoRow.approveStatus = Row.approveStatus;
                                Connection.UpdateById<AccVoucherInformationRow>(vouInfoRow);
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
                            //    .List<AccVoucherInformationRow>()
                            //    .FirstOrDefault(x => x.LinkedVoucherIdForAutoJV == Row.Id)?.Id;

                            if (paymentVoucherEntityId > 0 && paymentVoucherEntityId != null)
                            {
                                paramImproved.Add("@VoucherId", paymentVoucherEntityId);

                                spResult = Connection
                                    .Query<String>("APV_ACCApprovalHistory", paramImproved, commandType: CommandType.StoredProcedure)
                                    .FirstOrDefault();

                                vouInfoRow.Id = paymentVoucherEntityId;
                                vouInfoRow.approveStatus = Row.approveStatus;
                                Connection.UpdateById<AccVoucherInformationRow>(vouInfoRow);
                            }
                        }
                        //
                        #endregion

                        #region Old Code For Submit
                        //DynamicParameters param = new DynamicParameters();
                        //param.Add("@ApplicantId", user.Username);
                        //param.Add("@ApprovalProcess", "AccVou");

                        ////var list = Connection
                        ////    .Query<AVP_InitialStep>("APV_GetApproverInfoByApplicant", param, commandType: CommandType.StoredProcedure)
                        ////    .Where(p => p.Id == Row.ApproverId.Value)
                        ////    .FirstOrDefault();

                        //// @ApprovalProcessEnum	Varchar(20)
                        ////,@ApplicantId			Varchar(50) -- EmpId
                        ////,@ApplicationId		Int
                        ////,@IsOnlineApplication	Int
                        ////,@ApproverId			Int
                        ////,@IUser				Varchar(50)

                        //DynamicParameters param1 = new DynamicParameters();
                        //param1.Add("@ApprovalProcessEnum", "AccVou");
                        //param1.Add("@ApplicantId", user.Username);
                        //param1.Add("@ApplicationId", Row.Id);
                        //param1.Add("@IsOnlineApplication", 0);
                        //param1.Add("@ApproverId", Row.ApproverId.Value);
                        //param1.Add("@IUser", user.Username);

                        //var list1 = Connection
                        //    .Query<String>("Apv_sp_InitializeApprovalProcess", param1, commandType: CommandType.StoredProcedure)
                        //    .FirstOrDefault();


                        ////Entities.ApvApplicationInformationRow ApvApplication = new Entities.ApvApplicationInformationRow();
                        ////ApvApplication.ApplicationId = Row.Id;
                        ////ApvApplication.ApprovalProcessId = 17;
                        ////ApvApplication.ApprovalStepId = list.InitialStepId;
                        ////ApvApplication.ApprovalStatusId = (int)ApprovalStatus.Submit;
                        ////ApvApplication.ApproverId = list.Id;
                        ////ApvApplication.IUser = user.Username;
                        ////ApvApplication.IDate = DateTime.Now;
                        ////Connection.Insert(ApvApplication);
                        //DynamicParameters param2 = new DynamicParameters();
                        //param2.Add("@ApprovalProcessEnum", "AccVou");
                        //param2.Add("@ApplicantId", user.Username);
                        //param2.Add("@IsOnlineApplication", 0);
                        //param2.Add("@ApproverId", Row.ApproverId.Value);
                        //param2.Add("@IUser", user.Username);

                        //Entities.AccVoucherInformationRow vouInfoRow = new Entities.AccVoucherInformationRow();

                        //if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                        //{
                        //    if (Row.LinkedWithAutoJV != null && Convert.ToBoolean(Row.LinkedWithAutoJV) == true)
                        //    {
                        //        var journalVOucherEntityId = Convert.ToInt32(Row.LinkedVoucherIdForAutoJV);
                        //        param2.Add("@ApplicationId", journalVOucherEntityId);

                        //        var list2 = Connection
                        //       .Query<String>("Apv_sp_InitializeApprovalProcess", param2, commandType: CommandType.StoredProcedure)
                        //                    .FirstOrDefault();

                        //        vouInfoRow.Id = journalVOucherEntityId;
                        //        vouInfoRow.approveStatus = Row.approveStatus;
                        //        Connection.UpdateById<AccVoucherInformationRow>(vouInfoRow);
                        //    }
                        //}
                        //else if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Journal_Voucher))
                        //{
                        //    var paymentVoucherEntityId = Connection.List<AccVoucherInformationRow>().Where(x => x.LinkedVoucherIdForAutoJV == Row.Id).FirstOrDefault()?.Id;
                        //    if (paymentVoucherEntityId > 0 && paymentVoucherEntityId != null)
                        //    {
                        //        param2.Add("@ApplicationId", paymentVoucherEntityId);

                        //        var list2 = Connection
                        //       .Query<String>("Apv_sp_InitializeApprovalProcess", param2, commandType: CommandType.StoredProcedure)
                        //                    .FirstOrDefault();

                        //        vouInfoRow.Id = paymentVoucherEntityId;
                        //        vouInfoRow.approveStatus = Row.approveStatus;
                        //        Connection.UpdateById<AccVoucherInformationRow>(vouInfoRow);
                        //    }
                        //}
                        #endregion
                        #endregion Submit Voucher
                    }

                    #region Updating Cheque Register.
                    if (Row.ChequeRegisterId != null)
                    {
                        if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                        {
                            Boolean isAutoBankAdvice = false;

                            if (!IsUpdate)
                            {
                                var bankAdviceSetup = Connection.List<AccSetupForBankAdviceLetterRow>()
                                    .FirstOrDefault(l => l.CoaId == Row.AccountHeadBankCash);
                                if (bankAdviceSetup != null)
                                {
                                    isAutoBankAdvice = Convert.ToBoolean(bankAdviceSetup.IsAutoBankAdvice);
                                }
                            }

                            new AccChequeRegisterRepository()
                                .Update(UnitOfWork, new SaveRequest<Entities.AccChequeRegisterRow>
                                {
                                    EntityId = Row.ChequeRegisterId,
                                    Entity = new Entities.AccChequeRegisterRow()
                                    {
                                        IsUsed = true,
                                        VoucherNo = Row.VoucherNo,
                                        BankAccountInformationId = Row.BankAccountInformationId,
                                        VoucherInformationId = Row.Id,
                                        Amount = Row.Amount,
                                        AmountInWords = Row.AmountInWords,
                                        IsBankAdvice = isAutoBankAdvice,
                                        BankAdviceDate = isAutoBankAdvice ? Row.VoucherDate : null
                                    }
                                });
                        }
                        else if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Receipt_Voucher))
                        {
                            new AccChequeReceiveRegisterRepository()
                                .Update(UnitOfWork, new SaveRequest<Entities.AccChequeReceiveRegisterRow>
                                {
                                    EntityId = Row.ChequeRegisterId,
                                    Entity = new Entities.AccChequeReceiveRegisterRow()
                                    {
                                        IsUsed = true,
                                        Amount = Row.Amount,
                                        AmountInWords = Row.AmountInWords
                                    }
                                });
                        }
                    }

                    #endregion

                    #region Updating Cheque Reg. FOR JV only
                    if(Row.VoucherTypeId == Convert.ToInt32(VoucherType.Journal_Voucher))
                    {
                        var AdjustedCRList = Row.VoucherDetails.Where(x => x.AdjustedChequeRegisterId != null && x.AdjustedChequeRegisterId > 0).ToList();
                        foreach(var item in AdjustedCRList)
                        {
                            new AccChequeRegisterRepository()
                                .Update(UnitOfWork, new SaveRequest<Entities.AccChequeRegisterRow>
                                {
                                    EntityId = item.AdjustedChequeRegisterId,
                                    Entity = new Entities.AccChequeRegisterRow()
                                    {
                                        isAdjusted = true
                                    }
                                });
                        }
                    }
                    #endregion

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Occured in " + ex.TargetSite.Name + "\r\n" + ex.Message, ex.InnerException);
                }
            }

            private void SaveBankWisePaymentVoucher()
            {
                Int64? chequeId = null;
                Row.IsBankReconcile = 1;

                if (String.IsNullOrEmpty(Row.ChequeRemarks)) Row.ChequeRemarks = "--";

                var isChequeRegisterIdExists = false;
                if (IsUpdate)
                {
                    //isChequeRegisterIdExists =
                    //    Connection.List<AccVoucherInformationRow>().Any(v => v.Id == Row.Id && v.ChequeRegisterId != null);

                    var fldv = AccVoucherInformationRow.Fields.As("fldv");
                    var queryV = new SqlQuery()
                        .Select(fldv.Id)
                        .From(fldv)
                        .Where(fldv.Id == Row.Id.Value & fldv.ChequeRegisterId != 0);

                    isChequeRegisterIdExists = Connection.Query<AccVoucherInformationRow>(queryV).Any();
                }

                if (Row.ChequeBookId != null || Convert.ToInt32(Row.ChequeBookId) > 0)
                {
                    if (IsCreate || !isChequeRegisterIdExists)
                    {
                        #region New Cheque Issue from bank wise payment voucher page.

                        var newChequeRegister = new AccChequeRegisterRow()
                        {
                            Amount = Row.BankAmount,
                            ChequeDate = Row.ChequeDate,
                            ChequeIssueDate = Row.ChequeDate,
                            ChequeNo = Row.ChequeNo,
                            ChequeNumhdn = Row.ChequeNumhdn,
                            ChequeType = Row.ChequeType,
                            IsUsed = true,
                            PayTo = Row.PaytoForBankAdvice,
                            BankAccountInformationId = Row.BankAccountInformationId,
                            ChequeBookId = Row.ChequeBookId,
                            IsBankAdvice = false,
                            Remarks = Row.ChequeRemarks,
                            ZoneInfoId = user.ZoneID,
                            EntityId = user.FundControlInformationId,
                            IsCancelled = false
                        };

                        var newIssuedChequeId = Connection.InsertAndGetID(newChequeRegister);

                        Row.ChequeRegisterId = newIssuedChequeId;
                        chequeId = newIssuedChequeId;

                        if (Convert.ToBoolean(Row.IsChequeFinished))
                        {
                            var item = new AccChequeBookRow()
                            {
                                HasFinished = true,
                                Id = Row.ChequeBookId
                            };

                            new AccChequeBookRepository().Update(UnitOfWork,
                                new SaveRequest<AccChequeBookRow> { EntityId = item.Id, Entity = item });
                        }

                        #endregion
                    }
                    else if (IsUpdate)
                    {
                        #region Update existing cheque register
                        var item = new AccChequeRegisterRow()
                        {
                            Id = Row.ChequeRegisterId,
                            Amount = Row.BankAmount,
                            ChequeDate = Row.ChequeDate,
                            ChequeIssueDate = Row.ChequeDate,
                            ChequeNo = Row.ChequeNo,
                            ChequeNumhdn = Row.ChequeNumhdn,
                            ChequeType = Row.ChequeType,
                            IsUsed = true,
                            PayTo = Row.PaytoForBankAdvice,
                            BankAccountInformationId = Row.BankAccountInformationId,
                            ChequeBookId = Row.ChequeBookId,
                            IsBankAdvice = false,
                            Remarks = Row.ChequeRemarks
                        };
                        new AccChequeRegisterRepository().Update(UnitOfWork,
                            new SaveRequest<AccChequeRegisterRow> { EntityId = item.Id, Entity = item });
                        #endregion
                    }
                }

                if (IsCreate && Convert.ToBoolean(Row.LinkedWithAutoJV))
                {
                    #region Auto Journal Voucher

                    var autoPVAccHead = Row.AutoPV_AccountHead;
                    var autoPVCostCenter = Row.AutoPV_CostCentreId;
                    var bankCreditAmount = Row.AccountBankCashAmount;

                    var journalVoucher = new Entities.AccVoucherInformationRow();
                    journalVoucher = Row.Clone();

                    journalVoucher.VoucherNumber = journalVoucher.AutoJVVoucherNumber;
                    journalVoucher.VoucherNo = journalVoucher.AutoJVVoucherNo;
                    journalVoucher.VoucherTypeId = Convert.ToInt32(VoucherType.Journal_Voucher);
                    journalVoucher.TransactionMode = "Other";
                    journalVoucher.TransactionType = "JOURNAL";
                    journalVoucher.VoucherType = "-";

                    journalVoucher.TransactionTypeEntityId = 3;

                    journalVoucher.LinkedWithAutoJV = false;
                    journalVoucher.Amount = Row.JVAmount;
                    journalVoucher.AmountInWords = Row.JVAmountInWords;

                    var newJvId = Connection.InsertAndGetID(journalVoucher);

                    #region Saving Journal Voucher Details

                    var tmpVucherDetails = new List<AccVoucherDetailsRow>();
                    tmpVucherDetails.AddRange(Row.VoucherDetails);

                    foreach (var v in tmpVucherDetails)
                    {
                        var isCOA_BANK = v.IsAccountHeadBankCash.Value;

                        if (!isCOA_BANK)
                        {
                            Row.VoucherDetails.Remove(v);

                            Entities.AccVoucherDetailsRow jvDetailRow = new AccVoucherDetailsRow()
                            {
                                VoucherInformationId = newJvId,
                                ChartofAccountsId = v.ChartofAccountsId,
                                DebitAmount = v.DebitAmount,
                                CreditAmount = v.CreditAmount,
                                Description = v.Description,
                                ConversionAmount = v.ConversionAmount,
                                ConversionRate = v.ConversionRate,
                                EffectiveValue = v.EffectiveValue,
                                CCreditAmount = v.CreditAmount,
                                CDebitAmount = v.DebitAmount,
                                CalculationAmount = v.CalculationAmount,
                                CalculationRate = v.CalculationRate
                            };
                            var newJvDtlId = Connection.InsertAndGetID(jvDetailRow);

                            if (v.VoucherDtlAllocation != null)
                            {
                                foreach (var vddtl in v.VoucherDtlAllocation)
                                {
                                    Entities.AccVoucherDtlAllocationRow jvDtlAlocation =
                                        new AccVoucherDtlAllocationRow()
                                        {
                                            VoucherDetailId = newJvDtlId,
                                            CostCenterId = vddtl.CostCenterId,
                                            Amount = vddtl.Amount,
                                            DebitAmount = vddtl.DebitAmount,
                                            CreditAmount = vddtl.CreditAmount
                                        };
                                    Connection.Insert(jvDtlAlocation);
                                }
                            }
                        }
                    } //-- End of voucher details iteration

                    var autoJournalVDetail = new AccVoucherDetailsRow()
                    {
                        VoucherInformationId = newJvId,
                        ChartofAccountsId = autoPVAccHead,
                        DebitAmount = 0,
                        CreditAmount = bankCreditAmount,
                        Description = "",
                        EffectiveValue = bankCreditAmount,
                        CCreditAmount = bankCreditAmount,
                        CDebitAmount = 0
                    };
                    var autoJvDtlId = Connection.InsertAndGetID(autoJournalVDetail);

                    var autoJournalVDetailAllocation = new AccVoucherDtlAllocationRow()
                    {
                        VoucherDetailId = autoJvDtlId,
                        CostCenterId = autoPVCostCenter,
                        Amount = bankCreditAmount,
                        CreditAmount = bankCreditAmount,
                        DebitAmount = 0
                    };
                    Connection.Insert(autoJournalVDetailAllocation);

                    #endregion

                    #region Auto Payment Voucher Details

                    var autoPaymentVDetails = new AccVoucherDetailsRow()
                    {
                        ChartofAccountsId = autoPVAccHead,
                        DebitAmount = bankCreditAmount,
                        CreditAmount = 0,
                        Description = "",
                        EffectiveValue = bankCreditAmount,
                        CCreditAmount = 0,
                        CDebitAmount = bankCreditAmount,
                        BankAccountInformationId = Row.BankAccountInformationId,
                        ChequeRegisterId = chequeId,
                        LinkedJVDetailId = autoJvDtlId
                    };

                    autoPaymentVDetails.VoucherDtlAllocation = new List<AccVoucherDtlAllocationRow>();

                    autoPaymentVDetails.VoucherDtlAllocation.Add(new AccVoucherDtlAllocationRow()
                    {
                        CostCenterId = autoPVCostCenter,
                        Amount = bankCreditAmount,
                        CreditAmount = 0,
                        DebitAmount = bankCreditAmount
                    });

                    Row.VoucherDetails.Add(autoPaymentVDetails);

                    #endregion

                    Row.LinkedVoucherIdForAutoJV = newJvId;

                    #endregion Auto Journal Voucher
                }

                #region Update Bank Information and newly issued cheque
                // Following code will also execute if bank wise payment voucher created without JV
                foreach (var bankDetail in Row.VoucherDetails)
                {
                    if (bankDetail.ChartofAccountsId != 0)
                    {
                        bankDetail.BankAccountInformationId = Row.BankAccountInformationId;
                        bankDetail.ChequeRegisterId = chequeId;
                    }
                }
                #endregion
            }
        }

        private class MyDeleteHandler : DeleteRequestHandler<MyRow>
        {
            public Int64? chequeRegisterId { get; set; }

            protected override void OnBeforeDelete()
            {
                var v = AccVoucherInformationRow.Fields.As("v");
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;

                #region VALIDATE ACCOUNTING PERIOD

                var query = String.Format("select * from acc_Accounting_Period_Information Where '" + Convert.ToDateTime(Row.VoucherDate).ToString("yyyy-MM-dd") + "' between periodStartDate and periodEndDate");
                var accPeriod = Connection.Query<AccAccountingPeriodInformationRow>(query).FirstOrDefault();
                if (accPeriod != null)
                {
                    if (accPeriod.IsClosed == true)
                    {
                        throw new ValidationError("This accounting period - " + accPeriod.YearName + " is closed! You cannot delete voucher.");
                    }
                }
                else
                {
                    throw new ValidationError("Sorry, Accounting period not found!");
                }
                #endregion

                #region VALIDATING DELETE

                if (Row.createdUserId != "11") // Voucher from billing system - 11-Administrator
                {

                    string strQueryIsApproved = @"SELECT CASE WHEN (SELECT distinct 1
                                                                    FROM APV_ApplicationInformation
                                                                    WHERE applicationid = " + Row.Id + @"
                                                                        and ApprovalStatusId = 6) = 1 THEN 1 ELSE 0
                                                         END as 'IsApproved'";
                    var isApproved = Connection.Query<int>(strQueryIsApproved, commandType: CommandType.Text).FirstOrDefault();
                    if (isApproved == 1)
                    {
                        string strQueryApproverUserId = @"SELECT UserId
                                                        FROM TblUsers
                                                        WHERE LoginId IN (SELECT top 1 IUser
					                                                        FROM APV_ApplicationInformation
					                                                        WHERE applicationid = " + Row.Id + @"
                                                                                and ApprovalStatusId = 6 ORDER BY IDate)";

                        var approverUserId = Connection.Query<int>(strQueryApproverUserId, commandType: CommandType.Text).FirstOrDefault();

                        if (approverUserId != user.UserId)
                        {
                            throw new ValidationError("Sorry, Only approver have permission to delete this voucher!");
                        }
                    }
                    else if (Row.createdUserId != user.UserId.ToString())
                    {
                        throw new ValidationError("Sorry, Only {prepared by} personnel can delete this voucher!");
                    }
                }
                #endregion

                #region DELETE LINKED VOUCHER. (if PAYMENT VOUCHER THEN JV WILL DELETE. AGAIN IF JOURNAL VOUCHER THEN PV WILL DELETE).

                var voucherInformationId = Row.Id.Value;

                if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Journal_Voucher))
                {
                    var vQuery = new SqlQuery()
                        .Select(v.Id)
                        .From(v)
                        .Where(v.LinkedVoucherIdForAutoJV == Convert.ToInt64(voucherInformationId));

                    var paymentVoucherEntityId = Connection.Query<AccVoucherInformationRow>(vQuery)?.FirstOrDefault()?.Id;

                    //var paymentVoucherEntityId =
                    //    Connection.List<AccVoucherInformationRow>()
                    //    .Where(x => x.LinkedVoucherIdForAutoJV == voucherInformationId).FirstOrDefault()?.Id;

                    if (paymentVoucherEntityId != null && paymentVoucherEntityId > 0)
                    {
                        throw new ValidationError("Please delete linked debit voucher. This linked journal voucher will be deleted automatically.");
                    }
                }

                if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                {
                    if (Convert.ToBoolean(Row.LinkedWithAutoJV))
                    {
                        var journalVOucherEntityId = Convert.ToInt32(Row.LinkedVoucherIdForAutoJV);

                        var vQuery = new SqlQuery()
                            .Select(v.Id)
                            .From(v)
                            .Where(v.LinkedVoucherIdForAutoJV == Convert.ToInt64(journalVOucherEntityId));

                        var isJVExists = Connection.Query<AccVoucherInformationRow>(vQuery).Any();

                        //if (Connection.List<AccVoucherInformationRow>().FirstOrDefault(x => x.Id == journalVOucherEntityId) != null)
                        if (isJVExists)
                        {
                            Connection.DeleteById<AccVoucherInformationRow>(journalVOucherEntityId);
                        }
                    }
                }
                #endregion

                base.OnBeforeDelete();
            }

            protected override void ExecuteDelete()
            {
                try
                {
                    if (Row.VoucherTypeId == Convert.ToInt32(VoucherType.Receipt_Voucher))
                    {
                        var strSql = "UPDATE acc_MoneyReceipt SET IsUsed = 0, VoucherId = NULL WHERE VoucherId = " + Row.Id;
                        Connection.Execute(strSql);
                    }

                    base.ExecuteDelete();
                }
                catch (Exception e)
                {
                    SqlExceptionHelper.HandleDeleteForeignKeyException(e);
                    throw;
                }
            }
        }

        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow>
        {
            protected override void OnReturn()
            {
                base.OnReturn();

                int processNameEnumId = Connection.Query<int>("select id from APV_ApprovalProcess where ProcessNameEnum='AccVou'", commandType: CommandType.Text).FirstOrDefault();

                var lastpplicationInformation = new ApvApplicationInformationRepository()
                    .List(Connection, new ListRequest { Criteria = new Criteria("ApplicationId") == Row.Id.Value && new Criteria("ApprovalProcessId") == processNameEnumId }).Entities
                    .OrderByDescending(p => p.Id);

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

                if (user.FundControlInformationId != 0 && user.ZoneID != 0)
                {
                    query.Where(fld.FundControlInformationId == user.FundControlInformationId
                        && fld.ZoneId == user.ZoneID);
                }
                else
                {
                    throw new Exception("Please Select Entity");
                }
            }
        }
    }


    [LookupScript("Transaction.AccVoucherInformation_Lookup", Permission = "?", Expiration = -1)]
    public class AccVoucherInformationRowLookup : RowLookupScript<AccVoucherInformationRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            //if (Authorization.Username != "admin")
            //{
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = MyRow.Fields;
            if (user.FundControlInformationId != 0)
            {
                query.Where(fld.ZoneId > user.ZoneID
                    && fld.FundControlInformationId == user.FundControlInformationId);
            }
            else
            {
                throw new Exception("Please select fund control!");
            }
            //}
        }
    }



    public class ClsLinkedAutoJvId
    {
        public Int64 LinkedVoucherIdForAutoJV { get; set; }
    }

    public class NewVoucherNumberOutput
    {
        public String VoucherNo { get; set; }
        public String VoucherNumber { get; set; }
    }

    public class VoucherUtility
    {
        IDbConnection _connection;
        int _zoneId;
        int _fundControlId;

        public VoucherUtility(IDbConnection connection, int zoneId, int fundControlId)
        {
            _connection = connection;
            _zoneId = zoneId;
            _fundControlId = fundControlId;
        }

        public NewVoucherNumberOutput GetNewVoucherNo(int transactionTypeId, int financialYearId, DateTime voucherDate, int? bankAccId = 0)
        {
            try
            {
                if (bankAccId == null) bankAccId = 0;

                var strSql = String.Format("SELECT * FROM [dbo].[fn_AMS_GetNextVoucherNumber] ({0}, '{1}', {2}, '{3}', {4}, {5}, {6})", this._zoneId, String.Empty, financialYearId, voucherDate.ToString("yyyy-MM-dd"), this._fundControlId, transactionTypeId, bankAccId);
                var newVoucherNo = _connection.Query<NewVoucherNumberOutput>(strSql, commandType: CommandType.Text).FirstOrDefault();

                return newVoucherNo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured in " + ex.TargetSite.Name + "\r\n" + ex.Message, ex.InnerException);
            }
        }

        public string Currency_to_Words(decimal s)
        {
            var data = s - Math.Floor(s);
            var inWords = "";

            if (data > 0)
            {
                inWords = this.convert_number(s) + " TAKA " + this.convert_number(data * 100) + " POISA";
            }
            else
            {
                inWords = this.convert_number(s) + " TAKA";
            }

            return inWords + " ONLY";
        }

        public string convert_number(decimal num)
        {
            if ((num < 0) || (num > 99999999999999))
            {
                return "NUMBER OUT OF RANGE!";
            }
            var Gn = Math.Floor(num / 10000000);  /* Crore */
            num -= Gn * 10000000;
            var kn = Math.Floor(num / 100000);     /* lakhs */
            num -= kn * 100000;
            var Hn = Math.Floor(num / 1000);      /* thousand */
            num -= Hn * 1000;
            var Dn = Math.Floor(num / 100);       /* Tens (deca) */
            num = num % 100;               /* Ones */
            var tn = Math.Floor(num / 10);
            var one = Math.Floor(num % 10);
            var res = "";

            if (Gn > 0)
            {
                res += (this.convert_number(Gn) + " CRORE");
            }
            if (kn > 0)
            {
                res += (((res == "") ? "" : " ") +
                    this.convert_number(kn) + " LAKH");
            }
            if (Hn > 0)
            {
                res += (((res == "") ? "" : " ") +
                    this.convert_number(Hn) + " THOUSAND");
            }

            if (Dn > 0)
            {
                res += (((res == "") ? "" : " ") +
                    this.convert_number(Dn) + " HUNDRED");
            }

            string[] ones = new string[] { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            string[] tens = new string[] { "", "", "TWENTY", "THIRTY", "FOURTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };


            if (tn > 0 || one > 0)
            {
                if (!(res == ""))
                {
                    res += " AND ";
                }
                if (tn < 2)
                {
                    res += ones[Convert.ToInt32(tn * 10 + one)];
                }
                else
                {

                    res += tens[Convert.ToInt32(tn)];
                    if (one > 0)
                    {
                        res += ("-" + ones[Convert.ToInt32(one)]);
                    }
                }
            }

            if (res == "")
            {
                res = "ZERO";
            }
            return res;
        }
    }


}
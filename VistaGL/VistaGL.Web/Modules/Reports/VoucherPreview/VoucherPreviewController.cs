using Serenity.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Configurations.Repositories;
using VistaGL.Transaction.Entities;
using VistaGL.Transaction.Repositories;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/VoucherPreview"), Route("{action=index}")]
    public class VoucherPreviewController : Controller
    {
        public SqlConnection con;
        public VoucherPreviewController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: LedgerInfo
        public ActionResult Index(int? id)
        {
            using (var connection = SqlConnections.NewFor<AccVoucherInformationRow>())
            {
                var d = new AccVoucherInformationRepository()
                    .Retrieve(connection, new Serenity.Services.RetrieveRequest { EntityId = id }).Entity;

                var model = new ReportSearchViewModel();
                model.pEntityName = d.FundControlInformationFundControlName;
                var voucherDetails = d.VoucherDetails;

                if (!String.IsNullOrEmpty(d.PowerofAttorney))
                {
                    d.PaytoOrReciveFrom = d.PaytoOrReciveFrom + "\n" + d.PowerofAttorney;
                }

                //foreach (var vd in voucherDetails.Where(i => i.ChequeRegisterId != null))
                if (d.ChequeRegisterId != null)
                {
                    if (d.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                    {
                        #region Payment
                        //int bankAccInfoId = 0;

                        var accChequeRegister = new AccChequeRegisterRow();
                        //accChequeRegister = connection.List<AccChequeRegisterRow>().FirstOrDefault(p => p.Id == d.ChequeRegisterId);

                        var fldCheque = AccChequeRegisterRow.Fields.As("fldCheque");
                        var queryCheque = new SqlQuery()
                            .Select(fldCheque.Id)
                            .Select(fldCheque.ChequeNo)
                            .Select(fldCheque.ChequeDate)
                            .From(fldCheque)
                            .Where(fldCheque.Id == d.ChequeRegisterId.Value);

                        accChequeRegister = connection.Query<AccChequeRegisterRow>(queryCheque)?.FirstOrDefault();

                        if (accChequeRegister != null)
                        {
                            model.Operator = accChequeRegister.ChequeNo;
                            model.FromDate = accChequeRegister.ChequeDate;
                            //bankAccInfoId = accChequeRegister.BankAccountInformationId ?? 0;
                        }
                        else
                        {
                            model.Operator = d.ChequeRemarks;
                        }

                        //if (bankAccInfoId != 0)
                        //{
                        //    var accBankAccount = new AccBankAccountInformationRepository()
                        //                        .Retrieve(connection, new Serenity.Services.RetrieveRequest { EntityId = bankAccInfoId })
                        //                        .Entity;

                        //    if (accBankAccount != null)
                        //    {
                        //        model.pBankAccountNo = accBankAccount.AccountNumber;
                        //    }
                        //}
                        #endregion
                    }
                    else if (d.VoucherTypeId == Convert.ToInt32(VoucherType.Receipt_Voucher))
                    {
                        #region Receive
                        var accChequeReceiveRegister = new AccChequeReceiveRegisterRow();
                        //accChequeReceiveRegister = connection.List<AccChequeReceiveRegisterRow>().FirstOrDefault(p => p.Id == d.ChequeRegisterId);

                        var fldChequeReceive = AccChequeReceiveRegisterRow.Fields.As("fldChequeReceive");
                        var queryChequeReceive = new SqlQuery()
                            .Select(fldChequeReceive.Id)
                            .Select(fldChequeReceive.ChequeNo)
                            .Select(fldChequeReceive.ChequeDate)
                            .From(fldChequeReceive)
                            .Where(fldChequeReceive.Id == Convert.ToInt64(d.ChequeRegisterId));

                        accChequeReceiveRegister = connection.Query<AccChequeReceiveRegisterRow>(queryChequeReceive)?.FirstOrDefault();
                        if (accChequeReceiveRegister != null)
                        {
                            model.Operator = accChequeReceiveRegister.ChequeNo;
                            model.FromDate = accChequeReceiveRegister.ChequeDate;
                        }
                        else
                        {
                            model.Operator = d.ChequeRemarks;
                        }
                        #endregion
                    }
                }
                else
                {
                    model.Operator = d.ChequeRemarks;
                }


                if (d.BankAccountInformationId != null)
                {
                    var accBankAccountInfo =
                        new AccBankAccountInformationRepository()
                        .Retrieve(connection, new Serenity.Services.RetrieveRequest { EntityId = d.BankAccountInformationId })
                        .Entity;

                    if (accBankAccountInfo != null)
                    {
                        model.pBankAccountNo = accBankAccountInfo.AccountNumber;

                        var bankInfo = new AccBankInformationRepository()
                        .Retrieve(connection, new Serenity.Services.RetrieveRequest { EntityId = accBankAccountInfo.BankId })
                        .Entity;

                        if (bankInfo != null)
                        {
                            model.pBankName = bankInfo.BankName;
                        }
                    }
                }


                var _detailsData = voucherDetails;
                Session["rpath"] = "~/Modules/Reports/Rdlc/VoucherPreview.rdlc";

                string[] COA = { "BANK", "CASH" };
                if (d.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                {
                    #region Payment Voucher
                    _detailsData = voucherDetails.Where(p => !COA.Contains(p.ChartofAccountsCoaMapping)).OrderBy(o => o.Id).ToList();
                    var t = new List<AccVoucherDetailsRow>();

                    foreach (var head in _detailsData)
                    {
                        #region Voucher Details
                        if (head.VoucherDtlAllocation.Count > 0)
                        {
                            foreach (var costcenter in head.VoucherDtlAllocation)
                            {
                                //if (head.EffectiveValue > 0)
                                //{
                                if (Convert.ToDouble(head.CreditAmount.Value) > 0)
                                    t.Add(new AccVoucherDetailsRow()
                                    {
                                        ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                                        createdUserId = costcenter.CostCenterName,
                                        EffectiveValue = (-costcenter.Amount),
                                        updatedUserId = costcenter.CostCenterUserCode,
                                        Description = head.ChartofAccountsUserCode,
                                        Mid = 1
                                    });
                                else
                                    t.Add(new AccVoucherDetailsRow()
                                    {
                                        ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                                        createdUserId = costcenter.CostCenterName,
                                        EffectiveValue = costcenter.Amount,
                                        updatedUserId = costcenter.CostCenterUserCode,
                                        Description = head.ChartofAccountsUserCode,
                                        Mid = 1

                                    });

                                //}
                                //else
                                //{
                                //    t.Add(new AccVoucherDetailsRow()
                                //    {
                                //        ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                                //        createdUserId = costcenter.CostCenterName,
                                //        EffectiveValue = (-costcenter.Amount),
                                //        updatedUserId = costcenter.CostCenterUserCode,
                                //        Description = head.ChartofAccountsUserCode,
                                //        Mid = 1
                                //    });
                                //}

                            }

                        }
                        else
                        {
                            t.Add(new AccVoucherDetailsRow()
                            {
                                ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                                Description = head.ChartofAccountsUserCode,
                                EffectiveValue = head.EffectiveValue,
                                Mid = 0
                            });
                        }
                        #endregion
                    }

                    if (t.Count > 0)
                    {
                        _detailsData = t;
                    }
                    Session["rpath"] = "~/Modules/Reports/Rdlc/PaymentVoucher.rdlc";
                    #endregion
                }
                else if (d.VoucherTypeId == Convert.ToInt32(VoucherType.Receipt_Voucher))
                {
                    #region Receipt Voucher
                    _detailsData = voucherDetails.Where(p => !COA.Contains(p.ChartofAccountsCoaMapping)).OrderBy(o => o.Id).ToList();
                    var t = new List<AccVoucherDetailsRow>();

                    foreach (var head in _detailsData)
                    {
                        #region Voucher Details
                        if (head.VoucherDtlAllocation.Count > 0)
                        {
                            foreach (var costcenter in head.VoucherDtlAllocation)
                            {
                                t.Add(new AccVoucherDetailsRow()
                                {
                                    ChartofAccountsAccountName = head.ChartofAccountsAccountName + " (" + costcenter.CostCenterName + ")",
                                    //EffectiveValue = (-costcenter.Amount),
                                    DebitAmount = costcenter.DebitAmount,
                                    CreditAmount = costcenter.CreditAmount,
                                    Description = head.Description
                                });

                            }
                        }
                        else
                        {
                            t.Add(new AccVoucherDetailsRow()
                            {
                                ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                                //EffectiveValue = head.EffectiveValue,
                                DebitAmount = head.DebitAmount,
                                CreditAmount = head.CreditAmount,
                                Description = head.Description
                            });
                        }
                        #endregion
                    }

                    if (t.Count > 0)
                    {
                        _detailsData = t;
                    }
                    Session["rpath"] = "~/Modules/Reports/Rdlc/ReceiptVoucher.rdlc";

                    #endregion
                }
                else if (d.VoucherTypeId == Convert.ToInt32(VoucherType.Journal_Voucher))
                {
                    #region Journal Voucher

                    var fldLinkedDV = AccVoucherInformationRow.Fields.As("fldLinkedDV");
                    var queryLinkedDV = new SqlQuery()
                        .Select(fldLinkedDV.Id)
                        .Select(fldLinkedDV.VoucherNo)
                        .From(fldLinkedDV)
                        .Where(fldLinkedDV.LinkedVoucherIdForAutoJV == d.Id.Value);

                    d.LinkedDebitVoucherNo = connection.Query<AccVoucherInformationRow>(queryLinkedDV).FirstOrDefault()?.VoucherNo ?? "";

                    var t = new List<AccVoucherDetailsRow>();
                    foreach (var jvDetail in _detailsData)
                    {
                        #region Voucher Details
                        if (jvDetail.VoucherDtlAllocation.Count > 0)
                        {
                            foreach (var costcenter in jvDetail.VoucherDtlAllocation)
                            {
                                t.Add(new AccVoucherDetailsRow()
                                {
                                    //ChartofAccountsAccountName = head.ChartofAccountsAccountName + " (" + costcenter.CostCenterName + ")",
                                    //EffectiveValue = (-costcenter.Amount)
                                    ChartofAccountsAccountName = jvDetail.ChartofAccountsAccountName,
                                    createdUserId = costcenter.CostCenterName,
                                    DebitAmount = costcenter.DebitAmount,
                                    CreditAmount = costcenter.CreditAmount,
                                    updatedUserId = jvDetail.ChartofAccountsUserCode, // costcenter.CostCenterUserCode
                                    Description = jvDetail.Description,
                                    Mid = 1

                                });

                            }
                        }
                        else
                        {
                            t.Add(new AccVoucherDetailsRow()
                            {
                                ChartofAccountsAccountName = jvDetail.ChartofAccountsAccountName,
                                //EffectiveValue = head.EffectiveValue
                                DebitAmount = jvDetail.DebitAmount,
                                CreditAmount = jvDetail.CreditAmount,
                                Description = jvDetail.Description,
                                Mid = 0
                            });
                        }
                        #endregion
                    }

                    if (t.Count > 0)
                    {
                        _detailsData = t;
                    }
                    Session["rpath"] = "~/Modules/Reports/Rdlc/JournalVoucher.rdlc";

                    #endregion
                }

                #region Signature

                var sqlQueryPreparedBy =
                    @"SELECT
                        PRM_EmploymentInfo.FullName + ', ' + ISNULL(PRM_Designation.ShortName, '') as EmployeeName,
                        PhotoSignature as Signature
                    FROM
                        PRM_EmploymentInfo  LEFT JOIN
                        PRM_EmpPhoto ON PRM_EmploymentInfo.Id = PRM_EmpPhoto.EmployeeId AND IsPhoto = 0 INNER JOIN
                        TblUsers ON TblUsers.EmpId =PRM_EmploymentInfo.EmpID INNER JOIN
                        PRM_Designation ON PRM_EmploymentInfo.DesignationId =PRM_Designation.Id
                    WHERE
                        TblUsers.UserId = " + d.createdUserId;

                var prepared = connection.Query<ApproverRecSignature>(sqlQueryPreparedBy, commandType: CommandType.Text).FirstOrDefault();
                if (prepared != null)
                {
                    d.PreparedSing = prepared.Signature ?? (byte[])(null); // == null ? (byte[])(null) : prepared.Signature;
                    d.PreparedEmployee = prepared.EmployeeName;
                }

                DynamicParameters param = new DynamicParameters();
                int postedEmpId = connection.Query<int>("SELECT Id from  PRM_EmploymentInfo WHERE  Id=" + "'" + d.PostedBy + "'", commandType: CommandType.Text).FirstOrDefault();
                param.Add("@EmployeeId", postedEmpId);
                var posting = connection.Query<ApproverRecSignature>("ACC_GetApproverRecommenderSignature", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (posting != null)
                {
                    d.PostingSing = posting.Signature;
                    d.PostedEmployee = posting.EmployeeName;
                }

                String sqlQueryApv = @"
                        SELECT TOP 1 E.Id
                        FROM
	                        APV_ApplicationInformation A INNER JOIN
	                        PRM_EmploymentInfo E ON A.IUser = E.EmpID
                        WHERE
	                        ApprovalStatusId = 6 AND ApplicationId = " + d.Id + @"
                        ORDER BY A.IDate DESC";

                var approverId = connection.Query<int>(sqlQueryApv, commandType: CommandType.Text).FirstOrDefault();
                param.Add("@EmployeeId", approverId);
                var approver = connection.Query<ApproverRecSignature>("ACC_GetApproverRecommenderSignature", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (approver != null)
                {
                    d.ApprovedSing = approver.Signature ?? (byte[])(null); // == null ? (byte[])(null) : approver.Signature;
                    d.ApprovedEmployee = approver.EmployeeName;
                }

                String sqlQueryRec = @"
                        SELECT TOP 1 E.Id
                        FROM
	                        APV_ApplicationInformation A INNER JOIN
	                        PRM_EmploymentInfo E ON A.IUser = E.EmpID
                        WHERE
	                        ApprovalStatusId = 5 AND ApplicationId = " + d.Id + @"
                        ORDER BY A.IDate DESC";

                var recommenderId = connection.Query<int>(sqlQueryRec, commandType: CommandType.Text).FirstOrDefault();
                param.Add("@EmployeeId", recommenderId);
                var recommender = connection.Query<ApproverRecSignature>("ACC_GetApproverRecommenderSignature", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (recommender != null)
                {
                    d.CheckedSing = recommender.Signature ?? (byte[])(null); // == null ? (byte[])(null) : recommender.Signature;
                    d.CheckedEmployee = recommender.EmployeeName;
                }
                #endregion

                var dList = new List<AccVoucherInformationRow>();
                dList.Add(d);
                Session["dt"] = dList;
                Session["dt1"] = _detailsData;
                //TempData["model"] = model;
                Session["model"] = model;
            }


            return View("~/Modules/Reports/VoucherPreview/VoucherPreviewIndex.cshtml");
        }

        // GET: LedgerInfo
        public ActionResult IndexCombineVoucher(int? id, bool? isCombineVoucher)
        {
            using (var connection = SqlConnections.NewFor<AccVoucherInformationRow>())
            {
                var dv = new AccVoucherInformationRepository()
                    .Retrieve(connection, new Serenity.Services.RetrieveRequest { EntityId = id })
                    .Entity;

                var model = new ReportSearchViewModel();
                model.pEntityName = dv.FundControlInformationFundControlName;
                var voucherDetails = dv.VoucherDetails;

                if (!String.IsNullOrEmpty(dv.PowerofAttorney))
                {
                    dv.PaytoOrReciveFrom = dv.PaytoOrReciveFrom + "\n" + dv.PowerofAttorney;
                }

                if (dv.ChequeRegisterId != null)
                {
                    #region Cheque Register
                    //int bankAccInfoId = 0;

                    var accChequeRegister = new AccChequeRegisterRow();
                    //accChequeRegister = connection.List<AccChequeRegisterRow>().FirstOrDefault(p => p.Id == dv.ChequeRegisterId);

                    var fldCheque = AccChequeRegisterRow.Fields.As("fldCheque");
                    var queryCheque = new SqlQuery()
                        .Select(fldCheque.Id)
                        .Select(fldCheque.ChequeNo)
                        .Select(fldCheque.ChequeDate)
                        .From(fldCheque)
                        .Where(fldCheque.Id == dv.ChequeRegisterId.Value);

                    accChequeRegister = connection.Query<AccChequeRegisterRow>(queryCheque)?.FirstOrDefault();
                    if (accChequeRegister != null)
                    {
                        model.Operator = accChequeRegister.ChequeNo;
                        model.FromDate = accChequeRegister.ChequeDate;
                        //bankAccInfoId = accChequeRegister.BankAccountInformationId == null
                        //    ? 0
                        //    : Convert.ToInt32(accChequeRegister.BankAccountInformationId);
                    }
                    else
                    {
                        model.Operator = dv.ChequeRemarks;
                    }

                    //var accBankAccount = new Configurations.Entities.AccBankAccountInformationRow();
                    ////accBankAccount = connection
                    ////    .List<Configurations.Entities.AccBankAccountInformationRow>()
                    ////    .FirstOrDefault(p => p.Id == bankAccInfoId);
                    //accBankAccount = new AccBankAccountInformationRepository()
                    //    .Retrieve(connection, new Serenity.Services.RetrieveRequest { EntityId = bankAccInfoId }).Entity;
                    //if (accBankAccount != null)
                    //{
                    //    model.pBankAccountNo = accBankAccount.AccountNumber;
                    //}
                    #endregion
                }
                else
                {
                    model.Operator = dv.ChequeRemarks;
                }

                if (dv.BankAccountInformationId != null)
                {
                    var accBankAccountInfo = new AccBankAccountInformationRepository()
                        .Retrieve(connection, new Serenity.Services.RetrieveRequest { EntityId = dv.BankAccountInformationId }).Entity;

                    if (accBankAccountInfo != null)
                    {
                        model.pBankAccountNo = accBankAccountInfo.AccountNumber;

                        var bankInfo = new AccBankInformationRepository()
                            .Retrieve(connection, new Serenity.Services.RetrieveRequest { EntityId = accBankAccountInfo.BankId }).Entity;

                        if (bankInfo != null)
                        {
                            model.pBankName = bankInfo.BankName;
                        }
                    }
                }

                var jv = new AccVoucherInformationRepository()
                    .Retrieve(connection, new Serenity.Services.RetrieveRequest { EntityId = dv.LinkedVoucherIdForAutoJV })
                    .Entity;

                IEnumerable<AccVoucherDetailsRow> jvVoucherDetails = new List<AccVoucherDetailsRow>();

                if (jv != null)
                {
                    dv.LinkedJournalVoucherNo = jv.VoucherNo;

                    jvVoucherDetails = jv.VoucherDetails
                        .Where(s => !voucherDetails.Any(x => x.ChartofAccountsId == s.ChartofAccountsId
                                                             && (x.VoucherDtlAllocation.Count != 0
                                                                 ? x.VoucherDtlAllocation[0].CostCenterId
                                                                 : 0) == (s.VoucherDtlAllocation.Count != 0
                                                                 ? s.VoucherDtlAllocation[0].CostCenterId
                                                                 : 0)
                                                             && x.DebitAmount == s.CreditAmount)).OrderBy(o => o.Id);
                }

                var _jvdetailsData = jvVoucherDetails;
                //Session["rpath"] = "~/Modules/Reports/Rdlc/VoucherPreview.rdlc";

                #region Payment Voucher
                string[] COA = { "BANK", "CASH" };
                _jvdetailsData = _jvdetailsData.Where(p => !COA.Contains(p.ChartofAccountsCoaMapping)).ToList();
                var t = new List<AccVoucherDetailsRow>();

                foreach (var head in _jvdetailsData)
                {
                    #region Journal Voucher Details
                    if (head.VoucherDtlAllocation.Count > 0)
                    {
                        foreach (var costcenter in head.VoucherDtlAllocation)
                        {
                            //if (head.EffectiveValue > 0)
                            //{
                            if (Convert.ToDecimal(head.CreditAmount.Value) > 0)
                                t.Add(new AccVoucherDetailsRow()
                                {
                                    ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                                    createdUserId = costcenter.CostCenterName,
                                    EffectiveValue = (-costcenter.Amount),
                                    updatedUserId = costcenter.CostCenterUserCode,
                                    Description = head.ChartofAccountsUserCode,
                                    Mid = 1
                                });
                            else
                                t.Add(new AccVoucherDetailsRow()
                                {
                                    ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                                    createdUserId = costcenter.CostCenterName,
                                    EffectiveValue = costcenter.Amount,
                                    updatedUserId = costcenter.CostCenterUserCode,
                                    Description = head.ChartofAccountsUserCode,
                                    Mid = 1

                                });

                            //}
                            //else
                            //{
                            //    t.Add(new AccVoucherDetailsRow()
                            //    {
                            //        ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                            //        createdUserId = costcenter.CostCenterName,
                            //        EffectiveValue = (-costcenter.Amount),
                            //        updatedUserId = costcenter.CostCenterUserCode,
                            //        Description = head.ChartofAccountsUserCode,
                            //        Mid = 1
                            //    });
                            //}

                        }

                    }
                    else
                    {
                        if (Convert.ToDecimal(head.CreditAmount.Value) > 0)
                            t.Add(new AccVoucherDetailsRow()
                            {
                                ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                                Description = head.ChartofAccountsUserCode,
                                EffectiveValue = (-Convert.ToDecimal(head.CreditAmount.Value)),
                                Mid = 0
                            });
                        else
                            t.Add(new AccVoucherDetailsRow()
                            {
                                ChartofAccountsAccountName = head.ChartofAccountsAccountName,
                                Description = head.ChartofAccountsUserCode,
                                EffectiveValue = Convert.ToDecimal(head.DebitAmount.Value),
                                Mid = 0
                            });

                    }
                    #endregion
                }

                if (t.Count > 0)
                {
                    _jvdetailsData = t;
                }
                Session["rpath"] = "~/Modules/Reports/Rdlc/PaymentVoucher.rdlc";
                #endregion

                #region Signature
                var prepared = connection.Query<ApproverRecSignature>("SELECT PRM_EmploymentInfo.FullName+', '+PRM_Designation.ShortName as EmployeeName, PhotoSignature as Signature FROM PRM_EmploymentInfo  LEFT JOIN PRM_EmpPhoto ON PRM_EmploymentInfo.Id = PRM_EmpPhoto.EmployeeId AND IsPhoto = 0 INNER JOIN TblUsers ON TblUsers.EmpId =PRM_EmploymentInfo.EmpID INNER JOIN PRM_Designation ON PRM_EmploymentInfo.DesignationId =PRM_Designation.Id   WHERE  TblUsers.UserId =" + dv.createdUserId, commandType: CommandType.Text).FirstOrDefault();
                if (prepared != null)
                {
                    dv.PreparedSing = prepared.Signature ?? (byte[])(null); //== null ?  : prepared.Signature;
                    dv.PreparedEmployee = prepared.EmployeeName;
                }

                DynamicParameters param = new DynamicParameters();
                int postedEmployeeId = Convert.ToInt32(dv.PostedBy);
                param.Add("@EmployeeId", postedEmployeeId);
                var posting = connection.Query<ApproverRecSignature>("ACC_GetApproverRecommenderSignature", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (posting != null)
                {
                    dv.PostingSing = posting.Signature;
                    dv.PostedEmployee = posting.EmployeeName;
                }

                String sqlQueryApv = @"
                        SELECT TOP 1 E.Id
                        FROM
	                        APV_ApplicationInformation A INNER JOIN
	                        PRM_EmploymentInfo E ON A.IUser = E.EmpID
                        WHERE
	                        ApprovalStatusId = 6 AND ApplicationId = " + dv.Id + @"
                        ORDER BY A.IDate DESC";

                var approverId = connection.Query<int>(sqlQueryApv, commandType: CommandType.Text).FirstOrDefault();
                param.Add("@EmployeeId", approverId);
                var approver = connection.Query<ApproverRecSignature>("ACC_GetApproverRecommenderSignature", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (approver != null)
                {
                    dv.ApprovedSing = approver.Signature ?? (byte[])(null); //== null ? (byte[])(null) : approver.Signature;
                    dv.ApprovedEmployee = approver.EmployeeName;
                }


                String sqlQueryRec = @"
                        SELECT TOP 1 E.Id
                        FROM
	                        APV_ApplicationInformation A INNER JOIN
	                        PRM_EmploymentInfo E ON A.IUser = E.EmpID
                        WHERE
	                        ApprovalStatusId = 5 AND ApplicationId = " + dv.Id + @"
                        ORDER BY A.IDate DESC";

                var recommenderId = connection.Query<int>(sqlQueryRec, commandType: CommandType.Text).FirstOrDefault();
                param.Add("@EmployeeId", recommenderId);
                var recommender = connection.Query<ApproverRecSignature>("ACC_GetApproverRecommenderSignature", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (recommender != null)
                {
                    dv.CheckedSing = recommender.Signature ?? (byte[])(null); // == null ? (byte[])(null) : recommender.Signature;
                    dv.CheckedEmployee = recommender.EmployeeName;
                }
                #endregion

                var dList = new List<AccVoucherInformationRow>();
                dList.Add(dv);
                Session["dt"] = dList;
                Session["dt1"] = _jvdetailsData;
                //TempData["model"] = model;
                Session["model"] = model;
            }


            return View("~/Modules/Reports/VoucherPreview/VoucherPreviewIndex.cshtml");
        }


    }
}
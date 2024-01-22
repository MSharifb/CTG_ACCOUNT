using Dapper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Modules.Common;

namespace VistaGL.Modules.Reports.AllVoucherInfo
{
    [RoutePrefix("Reports/AllVoucherInfo"), Route("{action=index}")]
    public class AllVoucherInfoController : Controller
    {
        public SqlConnection con;
        UserDefinition user = (UserDefinition)Serenity.Authorization.UserDefinition;

        public AllVoucherInfoController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: AllVoucherInfo
        public ActionResult Index(ReportSearchViewModel model)
        {
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsOpenReportInNewTab = true;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/AllVoucherInfo/AllVoucherInfoIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/AllVoucherInfo/AllVoucherInfoIndex.cshtml", model);
            }

            Session["dt"] = null;
            Session["rpath"] = null;

            if (model.TransactionType == "S") // Subledgers without parent
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@paramZoneList", model.ZoneInfoList);
                param.Add("@param_fundcontrolId", model.FundcontrolId);
                param.Add("@fromDate", model.FromDate);
                param.Add("@toDate", model.ToDate);

                con.Open();
                var list = con.Query<SubledgersWithUnallocatedParentRptModel>("acc_rptSubledgersWithUnallocatedParent", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
                con.Close();

                Session["rpath"] = "~/Modules/Reports/Rdlc/RptSubledgersWithUnallocatedParent.rdlc";
                Session["dt"] = list;
            }
            else if (model.TransactionType == "I") // Voucher Inconsistancy
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@paramZoneList", model.ZoneInfoList);
                param.Add("@param_fundcontrolId", model.FundcontrolId);
                param.Add("@fromDate", model.FromDate);
                param.Add("@toDate", model.ToDate);

                con.Open();
                var list = con.Query<VoucherInconsistancyRptModel>("usp_Acc_Dashboard_VoucherInconsistancy", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
                con.Close();

                Session["rpath"] = "~/Modules/Reports/Rdlc/RptVoucherInconsistancy.rdlc";
                Session["dt"] = list;
            }
            else if (model.TransactionType == "A") // Zone Approver List
            {
                var list = my.GetApproverList(user.ZoneID, "AccVou", 0, ApprovalStepType.Both);

                Session["rpath"] = "~/Modules/Reports/Rdlc/RptZoneApproverList.rdlc";
                Session["dt"] = list;
            }
            else if (model.TransactionType == "V") // All VOuchers
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@paramZoneList", model.ZoneInfoList);
                param.Add("@param_fundcontrolId", model.FundcontrolId);
                param.Add("@param_coaId", model.COAId);
                param.Add("@voucherType", model.VoucherTypeId);
                param.Add("@fromDate", model.FromDate);
                param.Add("@toDate", model.ToDate);

                con.Open();
                var list = con.Query<AllVoucherInfoRptModel>("Rpt_SP_ACC_AllVoucher", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
                con.Close();

                if (model.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher))
                {
                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptAllVoucherInfo.rdlc";
                }
                else if (model.VoucherTypeId == Convert.ToInt32(VoucherType.Receipt_Voucher))
                {
                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptAllVoucherInfoCV.rdlc";
                }
                else if (model.VoucherTypeId == Convert.ToInt32(VoucherType.Journal_Voucher))
                {
                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptAllVoucherInfoJV.rdlc";
                }
                else
                {
                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptAllVoucherInfo.rdlc";
                }

                Session["dt"] = list;
            }

            Session["model"] = model;
            return View("~/Modules/Reports/AllVoucherInfo/AllVoucherInfoIndex.cshtml", model);
        }

    }
}
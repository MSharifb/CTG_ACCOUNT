using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.AccHeadTypeMappingWiseReport
{
    [RoutePrefix("Reports/AccHeadTypeMappingWiseReport"), Route("{action=index}")]
    public class AccHeadTypeMappingWiseReportController : Controller
    {
        public SqlConnection con;
        public AccHeadTypeMappingWiseReportController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: AccHeadTypeMappingWiseReport
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsOpenReportInNewTab = true;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/AccHeadTypeMappingWiseReport/AccHeadTypeMappingWiseReportIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/AccHeadTypeMappingWiseReport/AccHeadTypeMappingWiseReportIndex.cshtml", model);
            }

            var param = new DynamicParameters();

            param.Add("@accHeadTypeList", model.accHeadTypeMappingList);
            param.Add("@voucherDateFrom", model.FromDate);
            param.Add("@VoucherDateTo", model.ToDate);
            param.Add("@zoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            //param.Add("@param_IgnoreToDateForDebitVoucher", model.IgnoreToDateForDebitVoucher);

            Session["dt"] = null;
            Session["rpath"] = null;

            con.Open();
            var list = con.Query<AccHeadTypeMappingWiseReportModel>("Rpt_SP_ACC_AccHeadTypeMappingWise", param, commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();
            con.Close();

            // Default report
            if (model.accHeadTypeMappingList.Count() == 1)
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptAccHeadTypeMapping_WithCOA.rdlc";
            else
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptAccHeadTypeMapping.rdlc";


            if (model.IsWithChequeNo)
            {
                if (model.accHeadTypeMappingList.Count() == 1)
                {
                    if (model.ShowWithVoucherNo)
                        Session["rpath"] = "~/Modules/Reports/Rdlc/RptAccHeadTypeMapping_WithVoucherAndChequeInfo.rdlc";
                    else
                        Session["rpath"] = "~/Modules/Reports/Rdlc/RptAccHeadTypeMapping_WithChequeInfo.rdlc";
                }
            }
            else if (model.ShowWithVoucherNo)
            {
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptAccHeadTypeMapping_WithVoucherNo.rdlc";
            }
            else
            {
                if (model.ShowSubledgerWiseTotal)
                {
                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptAccHeadTypeMapping_SubledgerWiseTotal.rdlc";
                }
            }

            Session["dt"] = list;

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/AccHeadTypeMappingWiseReport/AccHeadTypeMappingWiseReportIndex.cshtml", model);

        }

    }
}
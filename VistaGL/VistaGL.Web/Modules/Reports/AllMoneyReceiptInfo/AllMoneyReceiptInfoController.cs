using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.AllMoneyReceiptInfo
{
    [RoutePrefix("Reports/AllMoneyReceiptInfo"), Route("{action=index}")]
    public class AllMoneyReceiptInfoController : Controller
    {
        public SqlConnection con;
        UserDefinition user = (UserDefinition)Serenity.Authorization.UserDefinition;

        public AllMoneyReceiptInfoController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: AllMoneyReceiptInfo
        public ActionResult Index(ReportSearchViewModel model)
        {
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsOpenReportInNewTab = true;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/AllMoneyReceiptInfo/AllMoneyReceiptInfoIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/AllMoneyReceiptInfo/AllMoneyReceiptInfoIndex.cshtml", model);
            }

            Session["dt"] = null;
            Session["rpath"] = null;

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@fromDate", model.FromDate);
            param.Add("@toDate", model.ToDate);

            con.Open();
            var list = con.Query<AllMoneyReceiptInfoModel>("proc_acc_AllMoneyReceipt", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptAllMoneyReceipt.rdlc";
            Session["dt"] = list;

            Session["model"] = model;
            return View("~/Modules/Reports/AllMoneyReceiptInfo/AllMoneyReceiptInfoIndex.cshtml", model);
        }

    }
}
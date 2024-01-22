using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.MoneyReceiptRegister
{
    [RoutePrefix("Reports/MoneyReceiptRegister"), Route("{action=index}")]
    public class MoneyReceiptRegisterController : Controller
    {
        public SqlConnection con;
        UserDefinition user = (UserDefinition)Serenity.Authorization.UserDefinition;

        public MoneyReceiptRegisterController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }
        public ActionResult Index(ReportSearchViewModel model)
        {
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsOpenReportInNewTab = true;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/MoneyReceiptRegister/MoneyReceiptRegisterIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/MoneyReceiptRegister/MoneyReceiptRegisterIndex.cshtml", model);
            }

            Session["dt"] = null;
            Session["rpath"] = null;

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@paramEntityId", model.FundcontrolId);
            param.Add("@paramFromDate", model.FromDate);
            param.Add("@paramToDate", model.ToDate);

            con.Open();
            var list = con.Query<MoneyReceiptRegisterModel>("Rpt_SP_ACC_MoneyReceiptRegister", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/MoneyReceiptRegister.rdlc";
            Session["dt"] = list;

            Session["model"] = model;
            return View("~/Modules/Reports/MoneyReceiptRegister/MoneyReceiptRegisterIndex.cshtml", model);
        }
    }
}
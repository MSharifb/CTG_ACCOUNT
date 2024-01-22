using Dapper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.ChequeRegister
{
    [RoutePrefix("Reports/ChequeRegister"), Route("{action=index}")]
    public class RptChequeRegisterController : Controller
    {
        public SqlConnection con;
        public RptChequeRegisterController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);

        }

        // GET: ChequeRegister
        public ActionResult Index(ReportSearchViewModel model)
        {

            string gotoDashboard = Request.QueryString["gotoDashboard"] ?? String.Empty;
            if (!String.IsNullOrEmpty(gotoDashboard))
            {
                model.ShowDashboardButton = gotoDashboard == "1";
            }


            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsOnlyPostedVoucher = true;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/ChequeRegister/ChequeRegisterIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? BankAccountId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/ChequeRegister/ChequeRegisterIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@paramBankAccountId", model.BankAccountId);
            param.Add("@paramEntityId", model.FundcontrolId);
            param.Add("@paramFromDate", model.FromDate);
            param.Add("@paramToDate", model.ToDate);
            param.Add("@paramOnlyPostedVoucher", model.IsOnlyPostedVoucher);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<ChequeRegisterRptModel>("Rpt_SP_ACC_ChequeRegister", param, commandTimeout: 0,
                commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptChequeRegister.rdlc";
            Session["dt"] = list;
            if (list != null && list.Count > 0)
            {
                model.pBankAccountNo = list?.FirstOrDefault().BankName + " -(" + list?.FirstOrDefault().AccountNumber + ")";
            }
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/ChequeRegister/ChequeRegisterIndex.cshtml", model);


        }
    }
}
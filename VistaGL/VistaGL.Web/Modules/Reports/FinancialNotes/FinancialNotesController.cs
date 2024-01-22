using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.FinancialNotes
{
    [RoutePrefix("Reports/FinancialNotes"), Route("{action=index}")]
    public class FinancialNotesController : Controller
    {
        public SqlConnection con;
        public FinancialNotesController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: FinancialNotes
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/FinancialNotes/FinancialNotesIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/FinancialNotes/FinancialNotesIndex.cshtml", model);
            }
            DynamicParameters param = new DynamicParameters();
            param.Add("@param_ZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);


            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<FinancialNotesModel>("Rpt_SP_ACC_Note14_01", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note14_01.rdlc";

            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/FinancialNotes/FinancialNotesIndex.cshtml", model);
        }
    }
}
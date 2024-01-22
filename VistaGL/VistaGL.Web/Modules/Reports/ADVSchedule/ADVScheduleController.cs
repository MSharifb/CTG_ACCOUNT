using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.ADVSchedule
{
    [RoutePrefix("Reports/ADVSchedule"), Route("{action=index}")]
    public class ADVScheduleController : Controller
    {
        public SqlConnection con;
        public ADVScheduleController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: ADVSchedule
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.FundcontrolId = user.FundControlInformationId;
            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/ADVSchedule/ADVScheduleIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/ADVSchedule/ADVScheduleIndex.cshtml", model);
            }
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.FundcontrolId = user.FundControlInformationId;

            DynamicParameters param = new DynamicParameters();
            param.Add("@StartDate", model.FromDate);
            param.Add("@EndDate", model.ToDate);
            param.Add("@FundControlId", model.FundcontrolId);
            param.Add("@AccountHeadId", model.ParentCOAId);


            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<ADVScheduleViewModel>("Rpt_SP_ACC_Note10_01", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            if (model.TransactionType == "SUM")
            {
                Session["rpath"] = "~/Modules/Reports/Rdlc/ADVSummary.rdlc";
            }
            else
            {
                Session["rpath"] = "~/Modules/Reports/Rdlc/ADVSchedule.rdlc";
            }

            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/ADVSchedule/ADVScheduleIndex.cshtml", model);
        }
    }
}
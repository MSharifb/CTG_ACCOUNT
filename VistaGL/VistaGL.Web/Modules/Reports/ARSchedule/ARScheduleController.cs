using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.ARSchedule
{
    [RoutePrefix("Reports/ARSchedule"), Route("{action=index}")]
    public class ARScheduleController : Controller
    {
        public SqlConnection con;
        public ARScheduleController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: ARSchedule
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.FundcontrolId = user.FundControlInformationId;
            model.ZoneInfoList = user.ZoneID.ToString();

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/ARSchedule/ARScheduleIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/ARSchedule/ARScheduleIndex.cshtml", model);
            }
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.FundcontrolId = user.FundControlInformationId;

            DynamicParameters param = new DynamicParameters();
            param.Add("@StartDate", model.FromDate);
            param.Add("@EndDate", model.ToDate);
            param.Add("@FundControlId", model.FundcontrolId);

            if (model.TransactionType == "AR")
            {
                Session["dt"] = null;
                Session["rpath"] = null;
                con.Open();
                var list = con.Query<ARScheduleViewModel>("Rpt_SP_ACC_Note09_01", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                Session["rpath"] = "~/Modules/Reports/Rdlc/ARSchedule.rdlc";
                Session["dt"] = list;
            }
            else if(model.TransactionType == "SDS")
            {
                Session["dt"] = null;
                Session["rpath"] = null;
                con.Open();
                var list = con.Query<ARScheduleViewModel>("Rpt_SP_ACC_Note13_01", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                Session["rpath"] = "~/Modules/Reports/Rdlc/SDSummary.rdlc";
                Session["dt"] = list;
            }
            else if(model.TransactionType == "SDD")
            {
                param.Add("@ZoneList", model.ZoneInfoList);

                Session["dt"] = null;
                Session["rpath"] = null;
                con.Open();
                var list = con.Query<ARScheduleViewModel>("Rpt_SP_ACC_Note13_02", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                Session["rpath"] = "~/Modules/Reports/Rdlc/SDSchedule.rdlc";
                Session["dt"] = list;
            }
            else if (model.TransactionType == "SDE")
            {
                param.Add("@ZoneList", model.ZoneInfoList);

                Session["dt"] = null;
                Session["rpath"] = null;
                con.Open();
                var list = con.Query<ARScheduleViewModel>("Rpt_SP_ACC_Note13_03", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                Session["rpath"] = "~/Modules/Reports/Rdlc/SDEnlishment.rdlc";
                Session["dt"] = list;
            }
            Session["model"] = model;
            return View("~/Modules/Reports/ARSchedule/ARScheduleIndex.cshtml", model);
        }
    }
}
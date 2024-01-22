using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.CostCenterSchedule
{
    [RoutePrefix("Reports/CostCenterSchedule"), Route("{action=index}")]
    public class CostCenterScheduleController : Controller
    {
        public SqlConnection con;

        public CostCenterScheduleController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: CostCenterSchedule
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/CostCenterSchedule/CostCenterScheduleIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/CostCenterSchedule/CostCenterScheduleIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_coaId", model.COAId);
            param.Add("@param_costCenterId", model.CostCenterId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<CostCenterRptModel>("Rpt_SP_ACC_NotesProcessCostCenterWise", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/CostCenterSchedule.rdlc";
            Session["dt"] = list;
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/CostCenterSchedule/CostCenterScheduleIndex.cshtml", model);
        }
    }
}
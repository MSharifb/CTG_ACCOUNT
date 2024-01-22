using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/Notes"), Route("{action=index}")]
    public class NotesController : Controller
    {
        public SqlConnection con;
        public NotesController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: LedgerInfo
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/Notes/NotesIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/Notes/NotesIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_coaId", model.COAId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);
            param.Add("@param_BalanceType", model.TransactionType);


            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<NotesRptModel>("Rpt_SP_ACC_NotesProcess", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptNotes.rdlc";
            Session["dt"] = list;
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/Notes/NotesIndex.cshtml", model);
        }

    }
}
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Transaction.Entities;
using VistaGL.Transaction.Repositories;

namespace VistaGL.Modules.Reports.NOAInfoReport
{
    [Authorize]
    [RoutePrefix("Reports/NOAInfo"), Route("{action=index}")]
    public class NOAInfoController : Controller
    {
        public SqlConnection con;
        public NOAInfoController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: BankReconciliation
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            //model.ToDate = DateTime.Now;
            model.OperatorLIst = ddlOPeratorList();
            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/NOAInfoReport/NOAInfoIndex.cshtml", model);
        }

        private static IList<SelectListItem> ddlOPeratorList()
        {
            IList<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "All", Value = "All", });
            list.Add(new SelectListItem() { Text = "=", Value = "=", });
            list.Add(new SelectListItem() { Text = ">", Value = ">", });
            list.Add(new SelectListItem() { Text = ">=", Value = ">=", });
            list.Add(new SelectListItem() { Text = "<", Value = "<", });
            list.Add(new SelectListItem() { Text = "<=", Value = "<=", });
            return list;
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/NOAInfoReport/NOAInfoIndex.cshtml", model);
            }

            var user = (UserDefinition)Serenity.Authorization.UserDefinition;

            DynamicParameters param = new DynamicParameters();
            param.Add("@FundcontrolId", model.FundcontrolId);
            param.Add("@param_ZoneList", model.ZoneInfoList);
            param.Add("@NoaId", model.NoaId);
            param.Add("@FromDate", model.FromDate);
            param.Add("@ToDate", model.ToDate);
            param.Add("@SubledgerId", model.CostCenterId);

            Session["dt"] = null;
            Session["rpath"] = null;
            Session["DataSet"] = null;
            con.Open();
            var list = con.Query<NOAInfoRptModel>("ACC_rptNoaReport",
                 param,
                 commandTimeout: 0,
                 commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptContractorBillRegister2.rdlc";
            Session["dt"] = list;
            Session["DataSet"] = "DSNoaReport";

            model.OperatorLIst = ddlOPeratorList();
            TempData["model"] = model;
            return View("~/Modules/Reports/NOAInfoReport/NOAInfoIndex.cshtml", model);
        }

        public JsonResult GetNOAInfo(int costCenterId)
        {
            List < AccNoaRow > items = new List<AccNoaRow>();
            using (var connection = Serenity.Data.SqlConnections.NewFor<AccNoaRow>())
            {
                AccNoaRepository c = new AccNoaRepository();
                items = c.List(connection, new Serenity.Services.ListRequest() { }).Entities.ToList();
            }

            var list = new SelectList(items.Where(x=>x.CostCenterId == costCenterId), "Id", "NoaNumber");
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
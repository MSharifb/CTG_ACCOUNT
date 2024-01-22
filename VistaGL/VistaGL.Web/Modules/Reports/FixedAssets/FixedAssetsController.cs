using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.FixedAssets
{
    [RoutePrefix("Reports/FixedAssets"), Route("{action=index}")]
    public class FixedAssetsController : Controller
    {
        public SqlConnection con;
        public FixedAssetsController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: FixedAssets
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/FixedAssets/FixedAssetsIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;

            bool? assetType = null;

            if (model.TransactionType == "A")
            {
                assetType = null;
            }
            else if(model.TransactionType == "D")
            {
                assetType = true;
            }
            else
            {
                assetType = false;
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@AssetType", assetType);
            param.Add("@ParentLedgerId", model.financialPeriodId);
            param.Add("@ZoneInfoId", model.ZoneInfoId);
            param.Add("@IsWithOpening", model.IsWithOpening);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<FixedAssetsModel>("ACC_RptFixedAssets", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            TempData["model"] = model;
            Session["model"] = model;
            if (!model.IsWithOpening)
            {
            Session["rpath"] = "~/Modules/Reports/Rdlc/FixedAssets.rdlc";
            }
            else
            {
                Session["rpath"] = "~/Modules/Reports/Rdlc/FixedAssetsOpeningBalance.rdlc"; 
            }

            Session["dt"] = list;
            return View("~/Modules/Reports/FixedAssets/FixedAssetsIndex.cshtml", model);
        }
    }
}
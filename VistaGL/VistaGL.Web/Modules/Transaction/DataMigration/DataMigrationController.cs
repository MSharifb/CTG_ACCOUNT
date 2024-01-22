using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Transaction
{
    [RoutePrefix("Transaction/DataMigration"), Route("{action=index}")]
    public class DataMigrationController : Controller
    {
        public SqlConnection con;
        public DataMigrationController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: LedgerSubLedgerInfo
        public ActionResult Index(DataMigrationModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoId = user.ZoneID;
            model.ShowMappdReport = false;

            return View("~/Modules/Transaction/DataMigration/DataMigrationIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(DataMigrationModel model, int? zoneId)
        {
            // -- MAP Chart of Accounts of Old Acc. System and ERP
            //if (model.demoCOA_OldSystem != null && model.demoCOA_ERPSystem != null && model.demoCostCenter_ERPSystemId != null)
            //{
            //    if (model.demoCOA_OldSystem != string.Empty && model.demoCOA_ERPSystem > 0 && model.demoCostCenter_ERPSystemId > 0)
            //    {
            //        var param = new DynamicParameters();
            //        param.Add("@ZoneId", model.ZoneInfoId);
            //        param.Add("@COA_OldSystem", model.demoCOA_OldSystem);
            //        param.Add("@COA_ERPSystem", model.demoCOA_ERPSystem);
            //        param.Add("@CostCenter_ERPSystem", model.demoCostCenter_ERPSystemId);

            //        con.Open();
            //        model.ErrMsg = con.Query<string>("ACC_sp_MapChartofAccounts", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).FirstOrDefault();
            //        con.Close();
            //        model.errClass = model.ErrMsg == "success" ? "success" : "failed";
            //    }
            //}
            // --

            if (model.ShowMappdReport)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@param_ZoneId", model.ZoneInfoId);

                Session["dt"] = null;
                Session["rpath"] = null;

                con.Open();
                List<MappedReportModel> aList =
                    con.Query<MappedReportModel>("acc_rpt_DataMigraionMappedCostCenters", param,
                        commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();
                con.Close();

                Session["rpath"] = "~/Modules/Reports/Rdlc/rptDataMigrationMappedCostCenters.rdlc";
                Session["dt"] = aList;
                Session["model"] = model;
            }
            else
            {
                // -- MAP Sub-Ledgers of Old Acc. System and ERP
                if (model.demoCostCenter_OldSystemId != null && model.demoCostCenter_ERPSystemId != null)
                {
                    if (model.demoCostCenter_OldSystemId != string.Empty && model.demoCostCenter_ERPSystemId > 0)
                    {
                        var param = new DynamicParameters();
                        param.Add("@ZoneId", model.ZoneInfoId);
                        param.Add("@CostCenter_OldSystem", model.demoCostCenter_OldSystemId);
                        param.Add("@CostCenter_ERPSystem", model.demoCostCenter_ERPSystemId);

                        con.Open();
                        model.ErrMsg = con.Query<String>("ACC_sp_MapCostCenters", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).SingleOrDefault();
                        con.Close();

                        model.errClass = model.ErrMsg == "Success" ? "success" : "failed";
                    }
                }
                // --
            }

            return View("~/Modules/Transaction/DataMigration/DataMigrationIndex.cshtml", model);
        }
    }
}
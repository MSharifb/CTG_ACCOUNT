//using Dapper;
using Serenity;
using Serenity.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Configurations.Entities;

namespace VistaGL.Modules.Reports.BankAdviceLetterTemplateInfo
{
    [RoutePrefix("Reports/BankAdviceLetterTemplateInfo"), Route("{action=index}")]
    public class BankAdviceLetterTemplateInfoController : Controller
    {
        public SqlConnection con;
        public BankAdviceLetterTemplateInfoController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: BankAdviceLetterTemplateInfo
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            using (var connection = SqlConnections.NewFor<AccSetupForBankAdviceLetterRow>())
            {
                if (connection.List<AccSetupForBankAdviceLetterRow>().Any())
                {
                    model.MemorandumNo = connection.List<AccSetupForBankAdviceLetterRow>()[0].MemorandumNo;
                    model.Duplication = connection.List<AccSetupForBankAdviceLetterRow>()[0].Duplication;
                }
            }

            Session["dt"] = null;
            Session["dt1"] = null;

            Session["rpath"] = null;
            return View("~/Modules/Reports/BankAdviceLetterTemplateInfo/BankAdviceLetterTemplateInfoIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/BankAdviceLetterTemplateInfo/BankAdviceLetterTemplateInfoIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@asonDate", model.FromDate);
            param.Add("@accountId", model.BankAccountId);

            Session["dt"] = null;
            Session["dt1"] = null;

            Session["rpath"] = null;
            con.Open();
            var list = con.Query<BankAdviceLetterTemplateInfoRptModel>("Rpt_ACC_BankAdviceLetter", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            DynamicParameters param1 = new DynamicParameters();
            param1.Add("@ZoneId", ((UserDefinition)Authorization.UserDefinition).ZoneID);
            con.Open();
            var list1 = con.Query<BankAdviceLetterTemplateInfoRptModel>("SP_PRM_GetReportHeaderByZoneID", param1, commandType: CommandType.StoredProcedure).ToList();
            con.Close();


            Session["rpath"] = "~/Modules/Reports/Rdlc/RptBankAdviceLetter.rdlc";
            Session["dt"] = list;
            Session["dt1"] = list1;

            TempData["model"] = model;
            return View("~/Modules/Reports/BankAdviceLetterTemplateInfo/BankAdviceLetterTemplateInfoIndex.cshtml", model);
        }

        public ActionResult LoadBranch(int bankId)
        {
            List<AccBankBranchInformationRow> items = new List<AccBankBranchInformationRow>();
            using (var connection = SqlConnections.NewFor<AccBankBranchInformationRow>())
            {
                items = connection.List<AccBankBranchInformationRow>();
            }
            var list = new SelectList(items.Where(x => x.BankId == bankId), "id", "branchName");

            return Json(list, JsonRequestBehavior.AllowGet
            );
        }

        public ActionResult LoadBankAccount(int bankId, int branchId)
        {
            List<AccBankAccountInformationRow> items = new List<AccBankAccountInformationRow>();
            using (var connection = SqlConnections.NewFor<AccBankAccountInformationRow>())
            {
                items = connection.List<AccBankAccountInformationRow>();
            }
            var list = new SelectList(items.Where(x => x.BankId == bankId && x.BankBranchId == branchId), "id", "accountNumber");

            return Json(list, JsonRequestBehavior.AllowGet
            );
        }

        public ActionResult LoadDuplication(int bankAccountId)
        {
            ReportSearchViewModel model = new ReportSearchViewModel();
            using (var connection = SqlConnections.NewFor<AccSetupForBankAdviceLetterRow>())
            {
                model.MemorandumNo = connection.List<AccSetupForBankAdviceLetterRow>().Where(x => x.CoaId == bankAccountId).Select(s => s.MemorandumNo).FirstOrDefault();
                model.Duplication = connection.List<AccSetupForBankAdviceLetterRow>().Where(x => x.CoaId == bankAccountId).Select(s => s.Duplication).FirstOrDefault();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GenerateReport(string id, int COAId)
        {
            ReportSearchViewModel model = new ReportSearchViewModel();
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.FromDate = DateTime.Now;

            using (var connection = SqlConnections.NewFor<AccSetupForBankAdviceLetterRow>())
            {
                if (connection.List<AccSetupForBankAdviceLetterRow>().Any())
                {
                    model.MemorandumNo = connection.List<AccSetupForBankAdviceLetterRow>().Where(x=>x.CoaId == COAId).FirstOrDefault().MemorandumNo;
                    model.Duplication = connection.List<AccSetupForBankAdviceLetterRow>().Where(x => x.CoaId == COAId).FirstOrDefault().Duplication;
                }
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneId", user.ZoneID.ToString());
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@paramCRIdList", id);

            Session["dt"] = null;
            Session["dt1"] = null;

            Session["rpath"] = null;
            con.Open();
            var list = con.Query<BankAdviceLetterTemplateInfoRptModel>("Rpt_ACC_BankAdviceLetter", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            DynamicParameters param1 = new DynamicParameters();
            param1.Add("@ZoneId", ((UserDefinition)Authorization.UserDefinition).ZoneID);
            con.Open();
            var list1 = con.Query<BankAdviceLetterTemplateInfoRptModel>("SP_PRM_GetReportHeaderByZoneID", param1, commandType: CommandType.StoredProcedure).ToList();
            con.Close();


            Session["rpath"] = "~/Modules/Reports/Rdlc/RptBankAdviceLetter.rdlc";
            Session["dt"] = list;
            Session["dt1"] = list1;

            Session["model"] = model;
            return View("~/Modules/Reports/BankAdviceLetterTemplateInfo/BankAdviceLetterTemplateInfoIndex.cshtml", model);

        }

    }
}
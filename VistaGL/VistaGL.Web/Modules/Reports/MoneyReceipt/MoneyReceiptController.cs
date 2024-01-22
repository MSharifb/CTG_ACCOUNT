using Dapper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/MoneyReceipt"), Route("{action=index}")]
    public class MoneyReceiptController : Controller
    {
        public SqlConnection con;

        public MoneyReceiptController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: LedgerInfo
        public ActionResult Index(int? id, String source)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@MoneyReceiptId", id);

            Session["dt"] = null;
            Session["rpath"] = null;

            if (source == MoneyReceiptReportSource.FromReceiptVoucher.ToString())
            {
                con.Open();
                var list = con.Query<MoneyReceiptRptModel>("proc_acc_MoneyReceipt", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
                con.Close();

                Session["dt"] = list;
            }
            else
            {
                con.Open();
                var list = con.Query<MoneyReceiptRptModel>("proc_acc_MoneyReceipt_FromMoneyReceipt", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
                con.Close();

                Session["dt"] = list;
            }


            Session["rpath"] = "~/Modules/Reports/Rdlc/MoneyReceipt.rdlc";
            Session["model"] = new ReportSearchViewModel();

            return View("~/Modules/Reports/MoneyReceipt/MoneyReceiptIndex.cshtml");
        }

    }
}
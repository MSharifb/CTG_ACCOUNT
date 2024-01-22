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

namespace VistaGL.Modules.Reports.VatTaxVoucher
{
    [RoutePrefix("Reports/VatTaxVoucher"), Route("{action=index}")]
    public class VatTaxVoucherController : Controller
    {
        public SqlConnection con;
        public VatTaxVoucherController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: VatTaxVoucher
        public ActionResult Index(VatTaxVoucherModel model)
        {
            PopulateDDL(model);
            return View("~/Modules/Reports/VatTaxVoucher/VatTaxVoucherIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(VatTaxVoucherModel model, int? id)
        {
            try
            {
                if (model.FromDate > model.ToDate)
                {
                    model.IsError = true;
                    model.Message = @"From date cannot be greater than to date. Try again.";
                    return View("~/Modules/Reports/VatTaxVoucher/VatTaxVoucherIndex.cshtml", model);
                }

                UserDefinition user = (UserDefinition)Authorization.UserDefinition;

                var param = new DynamicParameters();
                param.Add("@ZoneInfoId", user.ZoneID);
                param.Add("@param_fromDate", model.FromDate);
                param.Add("@param_toDate", model.ToDate);
                param.Add("@UserId", user.UserId);
                param.Add("@FundControlId", user.FundControlInformationId);
                param.Add("@SVoucherDate", Convert.ToDateTime(model.VoucherDate).ToString("dd-MM-yyyy"));
                param.Add("@CostCenterId", model.CostCenterId);
                param.Add("@Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                if (model.IsVat == "V")
                {
                    param.Add("@IsVat", 1);
                }
                else
                {
                    param.Add("@IsVat", 0);
                }
                var aList = con.Query<string>("ACC_AutoPVforVatTaxoucher", param, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                model.Message = param.Get<string>("@Message");
                model.IsSuccess = 1;
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
                model.IsSuccess = 0;
            }
            PopulateDDL(model);
            return View("~/Modules/Reports/VatTaxVoucher/VatTaxVoucherIndex.cshtml", model);
        }

        public void PopulateDDL(VatTaxVoucherModel model)
        {
            var user = (UserDefinition)Authorization.UserDefinition;

            var items = new List<AccChartofAccountsRow>();

            using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
            {
                //items = connection.List<AccChartofAccountsRow>().Where(x=>x.CoaMapping=="BANK" && x.FundControlId == user.FundControlInformationId).ToList();
                var fldCOA = AccChartofAccountsRow.Fields.As("fldCOA");
                var coaQuery = new SqlQuery()
                    .Select(fldCOA.Id)
                    .Select(fldCOA.AccountName)
                    .From(fldCOA)
                    .Where(fldCOA.CoaMapping == "BANK" & fldCOA.FundControlId == user.FundControlInformationId);
                items = connection.Query<AccChartofAccountsRow>(coaQuery).ToList();
            }

            var resultList = new List<SelectListItem>();
            foreach (var item in items)
            {
                resultList.Add(new SelectListItem()
                {
                    Text = item.AccountName,
                    Value = item.Id.ToString()
                });
            }
            model.AccountBankCashList = resultList;

        }



    }
}
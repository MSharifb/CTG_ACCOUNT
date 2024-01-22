using Serenity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VistaGL.Transaction.Entities;

namespace VistaGL.Modules.Reports.VatTaxVoucher
{
    public class VatTaxVoucherModel
    {
        public VatTaxVoucherModel()
        {
            this.AccountBankCashList = new List<SelectListItem>();
            this.ChequeBookList = new List<SelectListItem>();
            this.ChequeNoList = new List<SelectListItem>();
        }
        public int AccountBankCashId { get; set; }
        public IList<SelectListItem> AccountBankCashList { get; set; }

        public int ChequeBookId { get; set; }
        public IList<SelectListItem> ChequeBookList { get; set; }

        public string ChequeNo { get; set; }
        public IList<SelectListItem> ChequeNoList { get; set; }

        //public int Year { get; set; }
        //public IList<SelectListItem> YearList { get; set; }
        //public int Month { get; set; }
        //public IList<SelectListItem> MonthList { get; set; }

        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }

        //[Displa]
        public DateTime? VoucherDate { get; set; }

        public string IsVat { get; set; }
        public string Message { get; set; }
        public Boolean IsError { get; set; }
        public String ErrMsgClass { get; set; }

        public int IsSuccess { get; set; }

        public int CostCenterId { get; set; }

        public SelectList CostCenterList
        {
            get
            {
                var items = new List<AccCostCentreOrInstituteInformationRow>();
                using (var connection = SqlConnections.NewFor<AccCostCentreOrInstituteInformationRow>())
                {
                    //var c = new AccCostCentreOrInstituteInformationRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { })
                    //    .Entities
                    //    .Where(q => q.IsInstitute == false)
                    //    .ToList();

                    var costAlias = AccCostCentreOrInstituteInformationRow.Fields.As("costAlias");
                    var costQuery = new SqlQuery()
                        .Select(costAlias.Id)
                        .Select(costAlias.UserCode)
                        .Select(costAlias.Name)
                        .From(costAlias)
                        .Where(costAlias.IsInstitute == 0)
                        .OrderBy(costAlias.Name);
                    items = connection.Query<AccCostCentreOrInstituteInformationRow>(costQuery).ToList();
                }

                var r = (from cost in items
                         select new
                         {
                             id = cost.Id,
                             name = cost.UserCode + " - " + cost.Name
                         }).ToList();

                return new SelectList(r, "id", "name");
            }
        }
    }
}
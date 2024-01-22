
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Serenity;
using Serenity.Data;
using VistaGL.Configurations.Entities;
using System.Text;

namespace VistaGL.Common
{
    public class DashboardPageModel
    {
        public DashboardPageModel()
        {
            myCommaSeparatedZoneIds = new StringBuilder();
            var user = (UserDefinition)Authorization.UserDefinition;
            using (var connection = SqlConnections.NewFor<PrmZoneInfoRow>())
            {
                var userZoneList = connection.Query<DashboardPageModel.clsZoneIds>("SELECT ZoneId FROM TblUserZone WHERE EmpId = '" + user.Username + "'").ToList();
                foreach (var item in userZoneList)
                {

                    if (!String.IsNullOrEmpty(myCommaSeparatedZoneIds.ToString()))
                        myCommaSeparatedZoneIds.Append(",");

                    myCommaSeparatedZoneIds.Append(item.ZoneId.ToString());
                }
            }

            dashboardCollectionFromBillingSystem = new List<DashboardCollectionFromBillingSystemModel>();
            dashboardBankTransactions = new List<DashboardBankTransactionModel>();
        }

        class clsZoneIds
        {
            public int? ZoneId { get; set; }
        }

        private IList<SelectListItem> _Zone;

        public StringBuilder myCommaSeparatedZoneIds { get; set; }

        public IList<SelectListItem> Zone
        {
            get
            {
                var user = (UserDefinition)Authorization.UserDefinition;

                var sortZoneList = new List<PrmZoneInfoRow>();
                var userZoneList = new List<DashboardPageModel.clsZoneIds>();
                using (var connection = SqlConnections.NewFor<PrmZoneInfoRow>())
                {
                    userZoneList = connection.Query<DashboardPageModel.clsZoneIds>("SELECT ZoneId FROM TblUserZone WHERE EmpId = '" + user.Username + "'").ToList();
                    sortZoneList = connection.List<PrmZoneInfoRow>().Where(x => userZoneList.Select(s => s.ZoneId).Contains(x.Id)).OrderBy(s => s.SortOrder).ToList();
                }

                var resultList = new List<SelectListItem>();
                foreach (var item in sortZoneList)
                {
                    if (sortZoneList.Count == 1)
                    {
                        resultList.Add(new SelectListItem()
                        {
                            Text = item.ZoneName,
                            Value = item.Id.ToString(),
                            Selected = true
                        });
                    }
                    else
                    {
                        resultList.Add(new SelectListItem()
                        {
                            Text = item.ZoneName,
                            Value = item.Id.ToString()
                        });
                    }
                }

                this._Zone = resultList;
                return _Zone;
            }
            set { _Zone = value; }
        }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int CurrentZone { get; set; }

        public int IssuedCheque { get; set; }
        public int PreparedVoucher { get; set; }
        public int SubmittedVoucher { get; set; }
        public int ApprovedVoucher { get; set; }
        public int PostedVoucher { get; set; }
        public int TotalVoucher { get; set; }
        public int ApprovedChequeVoucher { get; set; }
        public int ApprovedOtherVoucher { get; set; }
        public int ApprovedOtherPV;
        public int ApprovedOtherRV;
        public int ApprovedOtherJV;
        public int NumberofChequeVoucher { get; set; }
        public int NumberofChequePrepared { get; set; }


        public decimal TodayOpeningBalance { get; set; }
        public decimal TodayReceiptAmount { get; set; }
        public decimal TodayPaymentAmount { get; set; }
        public decimal TodayClosingBalance { get; set; }

        public IList<DashboardCollectionFromBillingSystemModel> dashboardCollectionFromBillingSystem { get; set; }
        public IList<DashboardBankTransactionModel> dashboardBankTransactions { get; set; }

    }


    public class DashboardBankTransactionModel
    {
        public String ZoneCode { get; set; }
        public Int32 SortOrder { get; set; }
        public String bankName { get; set; }
        public String accountNumber { get; set; }
        public Decimal DebitAmount { get; set; }
        public Decimal CreditAmount { get; set; }
    }

    public class DashboardCollectionFromBillingSystemModel
    {

        public String zoneName { get; set; }
        public int SortOrder { get; set; }
        public decimal today { get; set; }
        public decimal sameDayLastWeek { get; set; }
        public decimal PDiffBtwTodaySDLW { get; set; }
        public decimal sameDayLastMonth { get; set; }
        public decimal PDiffBtwTodaySDLM { get; set; }
        public decimal yesterday { get; set; }
        public decimal PDiffBtwTY { get; set; }
        public decimal last7Days { get; set; }
        public decimal last1Month { get; set; }

    }

}
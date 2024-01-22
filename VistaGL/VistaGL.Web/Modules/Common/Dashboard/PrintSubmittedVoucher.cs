using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serenity.Data;
using Serenity.Reporting;

namespace VistaGL.Modules.Common.Dashboard
{
    [Report("Dashboard.PrintSubmittedVoucher")]
    [ReportDesign(MVC.Views.Common.Dashboard.PrintSubmittedVoucher)]
    public class PrintSubmittedVoucher : IReport, ICustomizeHtmlToPdf
    {
        public int ZoneId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public object GetData()
        {
            var model = new DashboardPrintModel();
            model.Title = "Submitted Voucher";
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;

            using (var connection = SqlConnections.NewFor<DashboardPrintModel>())
            {
                DateTime fromDate = Convert.ToDateTime(FromDate);
                DateTime toDate = Convert.ToDateTime(ToDate);

                var param8 = new DynamicParameters();
                param8.Add("@FromDate", fromDate);
                param8.Add("@ToDate", toDate);
                param8.Add("@ZoneInfoId", ZoneId);
                param8.Add("@FundControlId", user.FundControlInformationId);

                var submitdetailModel = connection
                    .Query<DashboardPrintModel.SubmitDetailModel>(
                                        "Rpt_SP_ACC_DashboardSubmittedVoucher",
                                        commandTimeout: 0,
                                        commandType: System.Data.CommandType.StoredProcedure,
                                        param: param8)
                    .ToList();

                model.SubmitDetail = submitdetailModel;
            }

            return model;
        }

        public void Customize(IHtmlToPdfOptions options)
        {

        }
    }

}
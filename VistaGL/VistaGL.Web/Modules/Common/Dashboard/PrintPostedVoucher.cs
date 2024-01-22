using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serenity.Data;
using Serenity.Reporting;

namespace VistaGL.Modules.Common.Dashboard
{
    [Report("Dashboard.PrintPostedVoucher")]
    [ReportDesign(MVC.Views.Common.Dashboard.PrintPostedVoucher)]
    public class PrintPostedVoucher : IReport, ICustomizeHtmlToPdf
    {
        public int ZoneId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public object GetData()
        {
            var model = new DashboardPrintModel();
            model.Title = "Posted Voucher";
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;

            using (var connection = SqlConnections.NewFor<DashboardPrintModel>())
            {
                DateTime fromDate = Convert.ToDateTime(FromDate);
                DateTime toDate = Convert.ToDateTime(ToDate);

                DynamicParameters param8 = new DynamicParameters();
                param8.Add("@FromDate", fromDate);
                param8.Add("@ToDate", toDate);
                param8.Add("@IsPostedOnly", 1);
                param8.Add("@ApproveType", Convert.ToInt32(ApprovalStatus.Approved));
                param8.Add("@ZoneInfoId", ZoneId);
                param8.Add("@FundControlId", user.FundControlInformationId);

                var detailModel = connection.Query<DashboardPrintModel.DetailModel>(
                    "Rpt_SP_ACC_DashboardVoucher",
                    commandTimeout: 0,
                    commandType: System.Data.CommandType.StoredProcedure, 
                    param: param8).ToList();

                model.Detail = detailModel;
            }

            return model;
        }

        public void Customize(IHtmlToPdfOptions options)
        {

        }
    }

}
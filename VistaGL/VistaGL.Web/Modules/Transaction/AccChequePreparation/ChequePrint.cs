using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using VistaGL.Transaction.Entities;

namespace VistaGL.Modules.Transaction.AccChequePreparation
{

    [Report("Transaction.AccChequePreparation.ChequePrint")]
    [ReportDesign(MVC.Views.Transaction.AccChequePreparation.ChequePrint)]
    //[RequiredPermission(??)]
    public class ChequePrint : IReport, ICustomizeHtmlToPdf
    {
        public Int64 VoucherId { get; set; }

        public object GetData()
        {
            var data = new ChequePrintData();
            using (var connection = SqlConnections.NewFor<AccVoucherInformationRow>())
            {
                var fld = AccVoucherInformationRow.Fields;

                var voucher = connection.TryFirst<AccVoucherInformationRow>(fld.Id == VoucherId);
                if (voucher != null && voucher.ChequeRegisterId != null)
                {
                    data.Payto = voucher.PaytoOrReciveFrom ?? String.Empty;
                    data.ChequeAmount = (voucher.Amount ?? 0).ToString("n0", CultureInfo.CreateSpecificCulture("bn-BD"));
                    data.AmountInWords = voucher.AmountInWords ?? String.Empty;

                    var ch = AccChequeRegisterRow.Fields.As("ch");
                    var chQuery = new SqlQuery()
                        .Select(ch.Id)
                        .Select(ch.ChequeDate)
                        .From(ch)
                        .Where(ch.Id == voucher.ChequeRegisterId.Value);
                    var cheque = connection.Query<AccChequeRegisterRow>(chQuery)?.FirstOrDefault();
                    //var cheque = connection.TryFirst<AccChequeRegisterRow>(cld.Id == voucher.ChequeRegisterId.Value);
                    if (cheque != null)
                    {
                        data.ChequeDate = Convert.ToDateTime(cheque.ChequeDate).ToString("ddMMyyyy");
                    }
                }
            }

            return data;
        }

        public void Customize(IHtmlToPdfOptions options)
        {
            options.Landscape = false;

            options.PageWidth = "190mm";
            options.PageHeight = "90mm";

            options.MarginsAll = "0mm";
            options.MarginTop = "16mm";
            options.MarginLeft = "10mm";
        }
    }

    public class ChequePrintData
    {
        public string Payto { get; set; }
        public string ChequeAmount { get; set; }
        public string AmountInWords { get; set; }
        public string ChequeDate { get; set; }
    }
}
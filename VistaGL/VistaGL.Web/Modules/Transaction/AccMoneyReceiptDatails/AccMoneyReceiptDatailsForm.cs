
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccMoneyReceiptDatails")]
    [BasedOnRow(typeof(Entities.AccMoneyReceiptDatailsRow))]
    public class AccMoneyReceiptDatailsForm
    {
        [Hidden]
        public Int64 MoneyReceiptId { get; set; }
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32 CoaId { get; set; }
        public Int32 CostCenterId { get; set; }
        public Decimal Amount { get; set; }
        public String Description { get; set; }
    }
}
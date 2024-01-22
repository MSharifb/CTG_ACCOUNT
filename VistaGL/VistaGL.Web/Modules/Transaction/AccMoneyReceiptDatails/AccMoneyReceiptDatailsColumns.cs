
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccMoneyReceiptDatails")]
    [BasedOnRow(typeof(Entities.AccMoneyReceiptDatailsRow))]
    public class AccMoneyReceiptDatailsColumns
    {
        [EditLink]
        public String CoaAccountName { get; set; }
        public String CostCenterName { get; set; }
        public Decimal Amount { get; set; }
    }
}
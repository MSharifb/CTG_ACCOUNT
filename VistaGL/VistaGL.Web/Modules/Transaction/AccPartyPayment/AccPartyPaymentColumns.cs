
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccPartyPayment")]
    [BasedOnRow(typeof(Entities.AccPartyPaymentRow))]
    public class AccPartyPaymentColumns
    {
        public String PartyId { get; set; }
        public String PartyName { get; set; }
        [EditLink]
        public String TransactionMode { get; set; }
        public String CoAAccountName { get; set; }
        public String CoA2AccountName { get; set; }
        public Int32 ChequeRegisterId { get; set; }
        //   [QuickFilter]
        public decimal Amount { get; set; }
        public decimal RemainAmount { get; set; }

    }
}
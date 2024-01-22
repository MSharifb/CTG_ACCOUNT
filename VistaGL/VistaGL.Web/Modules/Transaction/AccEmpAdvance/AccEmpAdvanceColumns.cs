
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccEmpAdvance")]
    [BasedOnRow(typeof(Entities.AccEmpAdvanceRow))]
    public class AccEmpAdvanceColumns
    {
        // [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //      public Int32 Id { get; set; }
        public String EmpEmpId { get; set; }
        public String EmpFullName { get; set; }
        [EditLink]
        public String TransactionMode { get; set; }
        public String CoAAccountName { get; set; }
        public String CoA2AccountName { get; set; }
        public Int32 ChequeRegisterId { get; set; }
        //   [QuickFilter]
        public decimal Amount { get; set; }
        public decimal RemainAmount { get; set; }
        //public Int32 Status { get; set; }
        //public Int32 ZoneId { get; set; }
    }
}

namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccEmpAdvance")]
    [BasedOnRow(typeof(Entities.AccEmpAdvanceRow))]
    public class AccEmpAdvanceForm
    {
        public Int32 EmpId { get; set; }
        [COAMappingEditor]
        public String TransactionMode { get; set; }
        public Int32 CoAId { get; set; }
        public Int32 ChequeRegisterId { get; set; }
        public Int32 CoAId2 { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainAmount { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Narration { get; set; }
        //public Int32 Status { get; set; }
        //public Int32 ZoneId { get; set; }
    }
}
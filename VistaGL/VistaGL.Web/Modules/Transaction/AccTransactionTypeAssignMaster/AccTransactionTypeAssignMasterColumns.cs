
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccTransactionTypeAssignMaster")]
    [BasedOnRow(typeof(Entities.AccTransactionTypeAssignMasterRow))]
    public class AccTransactionTypeAssignMasterColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Hidden]
        public Int32 Id { get; set; }
        [EditLink]
        public String TransactionType { get; set; }
      
        public String Remarks { get; set; }
    }
}
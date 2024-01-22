
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccTransactionTypeAssign")]
    [BasedOnRow(typeof(Entities.AccTransactionTypeAssignRow))]
    public class AccTransactionTypeAssignColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String TrType { get; set; }
        public Int32 ParentId { get; set; }
        public Int32 CoaId { get; set; }
    }
}

namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccTransactionType")]
    [BasedOnRow(typeof(Entities.AccTransactionTypeRow))]
    public class AccTransactionTypeColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink]
        public String TransactionType { get; set; }
        public String VoucherTypeName { get; set; }
        public String TransactionMode { get; set; }

        [AlignCenter]
        public Int32 SortOrder { get; set; }

        //public String Remarks { get; set; }



    }
}
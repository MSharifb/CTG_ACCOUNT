
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccTransactionType")]
    [BasedOnRow(typeof(Entities.AccTransactionTypeRow))]
    public class AccTransactionTypeForm
    {
        public Int32 VoucherTypeId { get; set; }

        public String TransactionType { get; set; }

        [COAMappingEditor]
        public String TransactionMode { get; set; }

        public Int32 SortOrder { get; set; }

        public Boolean IsbyDefault { get; set; }

        [TextAreaEditor(Rows = 5)]
        public String Remarks { get; set; }



    }
}
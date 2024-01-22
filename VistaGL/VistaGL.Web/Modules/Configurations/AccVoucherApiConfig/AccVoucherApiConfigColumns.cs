
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccVoucherApiConfig")]
    [BasedOnRow(typeof(Entities.AccVoucherApiConfigRow))]
    public class AccVoucherApiConfigColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String ConfigName { get; set; }
        public String ModuleId { get; set; }
        public String FormName { get; set; }
        public String VouchrTypeName { get; set; }
        public String TransactionTransactionType { get; set; }
        public String TransactionMode { get; set; }
        public String Narration { get; set; }
        public String FundControlFundControlName { get; set; }
    }
}
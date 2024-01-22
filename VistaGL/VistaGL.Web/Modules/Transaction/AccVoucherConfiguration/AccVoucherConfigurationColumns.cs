
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccVoucherConfiguration")]
    [BasedOnRow(typeof(Entities.AccVoucherConfigurationRow))]
    public class AccVoucherConfigurationColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"),Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink,AlignCenter]
        public String AccountingPeriodYearName { get; set; }

        public String VoucherTypeName { get; set; }

        public String TransactionType { get; set; }

        public Int32 NumberLength { get; set; }

        public Boolean IsAutoPost { get; set; }

        [QuickFilter,FilterOnly]
        public Int32 AccountingPeriodId { get; set; }

        [QuickFilter, FilterOnly]
        public Int32 VoucherTypeId { get; set; }

        [QuickFilter, FilterOnly]
        public Int32 TransactionTypeId { get; set; }

    }
}
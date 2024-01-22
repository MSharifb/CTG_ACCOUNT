
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccFixedAssetDepreciation")]
    [BasedOnRow(typeof(Entities.AccFixedAssetDepreciationRow), CheckNames = true)]
    public class AccFixedAssetDepreciationColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight,Hidden]
        public Int32 Id { get; set; }
        [DisplayName("Financial Year"), EditLink]
        public String FinancialYearYearName { get; set; }
    }
}
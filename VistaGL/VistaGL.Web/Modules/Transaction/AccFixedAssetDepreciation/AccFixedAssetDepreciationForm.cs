
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccFixedAssetDepreciation")]
    [BasedOnRow(typeof(Entities.AccFixedAssetDepreciationRow), CheckNames = true)]
    public class AccFixedAssetDepreciationForm
    {
        public Int32 FinancialYearId { get; set; }
        [Hidden]
        public String ProcessType { get; set; }
    }
}
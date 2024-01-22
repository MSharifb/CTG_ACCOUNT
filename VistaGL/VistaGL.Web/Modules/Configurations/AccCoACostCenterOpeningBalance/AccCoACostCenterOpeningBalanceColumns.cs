
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccCoACostCenterOpeningBalance")]
    [BasedOnRow(typeof(Entities.AccCoACostCenterOpeningBalanceRow))]
    public class AccCoACostCenterOpeningBalanceColumns
    {
        [EditLink, QuickFilter, FilterOnly]
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32? CoAid { get; set; }

        [EditLink, QuickFilter, FilterOnly]
        public Int32? CostCenterId { get; set; }

        public String CoAidAccountName { get; set; }

        public String CostCenterName { get; set; }

        public Decimal OBDebit { get; set; }

        public Decimal OBCredit { get; set; }
    }
}
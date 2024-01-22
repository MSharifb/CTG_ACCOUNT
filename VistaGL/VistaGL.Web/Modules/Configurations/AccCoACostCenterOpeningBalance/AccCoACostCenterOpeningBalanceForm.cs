
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccCoACostCenterOpeningBalance")]
    [BasedOnRow(typeof(Entities.AccCoACostCenterOpeningBalanceRow))]
    public class AccCoACostCenterOpeningBalanceForm
    {
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32 CoAid { get; set; }

        public Int32 CostCenterId { get; set; }

        public Decimal OBDebit { get; set; }

        public Decimal OBCredit { get; set; }
    }
}
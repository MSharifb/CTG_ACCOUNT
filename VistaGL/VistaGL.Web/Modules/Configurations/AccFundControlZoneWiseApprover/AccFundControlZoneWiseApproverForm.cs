
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccFundControlZoneWiseApprover")]
    [BasedOnRow(typeof(Entities.AccFundControlZoneWiseApproverRow), CheckNames = true)]
    public class AccFundControlZoneWiseApproverForm
    {
        public Int32 FundControlId { get; set; }
        public Int32 ZoneInfoId { get; set; }
        public Int32 ApproverId { get; set; }
        public Int32 PostingById { get; set; }
    }
}
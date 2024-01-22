
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccFundControlZoneWiseApprover")]
    [BasedOnRow(typeof(Entities.AccFundControlZoneWiseApproverRow), CheckNames = true)]
    public class AccFundControlZoneWiseApproverColumns
    {
        [Width(150, Min = 150), EditLink]
        public String ApproverEmpId { get; set; }
        [Width(200, Min = 200), EditLink]
        public String ApproverFullName { get; set; }
        [Width(150, Min = 150)]
        public String PostingByEmpId { get; set; }
        [Width(200, Min = 200)]
        public String PostingByFullName { get; set; }
    }
}
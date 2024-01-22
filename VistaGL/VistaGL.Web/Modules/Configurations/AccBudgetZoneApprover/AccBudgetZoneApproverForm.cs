
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccBudgetZoneApprover")]
    [BasedOnRow(typeof(Entities.AccBudgetZoneApproverRow), CheckNames = true)]
    public class AccBudgetZoneApproverForm
    {
        public Int32 ZoneId { get; set; }
        public Int32 EmployeeId { get; set; }
        [Hidden]
        public Int32 EntityId { get; set; }
    }
}

namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccBudgetZoneApprover")]
    [BasedOnRow(typeof(Entities.AccBudgetZoneApproverRow), CheckNames = true)]
    public class AccBudgetZoneApproverColumns
    {
        public String EmployeeFullName { get; set; }
        public String ZoneZoneName { get; set; }
    }
}
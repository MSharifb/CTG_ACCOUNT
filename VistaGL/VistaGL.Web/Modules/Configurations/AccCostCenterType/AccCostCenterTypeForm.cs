
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccCostCenterType")]
    [BasedOnRow(typeof(Entities.AccCostCenterTypeRow))]
    public class AccCostCenterTypeForm
    {        
        public String CostCenterType { get; set; }
        public Int32 SortOrder { get; set; }
    }
}
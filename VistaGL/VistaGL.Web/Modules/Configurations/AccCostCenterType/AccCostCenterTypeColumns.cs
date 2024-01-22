
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccCostCenterType")]
    [BasedOnRow(typeof(Entities.AccCostCenterTypeRow))]
    public class AccCostCenterTypeColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"),Hidden, AlignRight]
        public Int32 Id { get; set; }
        [EditLink]       
        public String CostCenterType { get; set; }
        public Int32 SortOrder { get; set; }
    }
}
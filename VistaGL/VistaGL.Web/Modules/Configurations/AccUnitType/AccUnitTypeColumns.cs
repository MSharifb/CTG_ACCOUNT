
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccUnitType")]
    [BasedOnRow(typeof(Entities.AccUnitTypeRow))]
    public class AccUnitTypeColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"),Hidden, AlignRight]
        public Int32 Id { get; set; }
              
        [EditLink]
        public String UnitName { get; set; }
        public String Remarks { get; set; }
    }
}
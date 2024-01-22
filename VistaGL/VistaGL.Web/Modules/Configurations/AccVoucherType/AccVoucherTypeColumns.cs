
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccVoucherType")]
    [BasedOnRow(typeof(Entities.AccVoucherTypeRow))]
    public class AccVoucherTypeColumns
    {
        [DisplayName("Db.Shared.RecordId"), Hidden(), AlignRight]
        public Int32 Id { get; set; }

        //[EditLink]
        [Width(300)]
        public String Name { get; set; }

        [AlignCenter, Width(100)]
        public Int32 SortOrder { get; set; }
    }
}
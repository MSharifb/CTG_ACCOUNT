
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccCommonDescription")]
    [BasedOnRow(typeof(Entities.AccCommonDescriptionRow))]
    public class AccCommonDescriptionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"),Hidden, AlignRight]
        public Int32 Id { get; set; }
        [EditLink]        
        public String VoucherTypeName { get; set; }
        public String TransactionType { get; set; }
        public String Description { get; set; }
        
    }
}
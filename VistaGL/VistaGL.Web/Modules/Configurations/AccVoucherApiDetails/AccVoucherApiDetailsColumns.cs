
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccVoucherApiDetails")]
    [BasedOnRow(typeof(Entities.AccVoucherApiDetailsRow))]
    public class AccVoucherApiDetailsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public Int32 ConfigId { get; set; }
        public Int32 AccountHeadId { get; set; }
        [EditLink]
        public String DrCr { get; set; }
        public String Description { get; set; }
        public Double Amount { get; set; }
        public Int32 EmpId { get; set; }
    }
}
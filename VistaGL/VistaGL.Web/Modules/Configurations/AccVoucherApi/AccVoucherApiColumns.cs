
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccVoucherApi")]
    [BasedOnRow(typeof(Entities.AccVoucherApiRow))]
    public class AccVoucherApiColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public Int32 ConfigId { get; set; }
        public Int32 VouchrTypeId { get; set; }
        public Int32 TransactionId { get; set; }
        [EditLink]
        public String Narration { get; set; }
        public String TransactionMode { get; set; }
        public Int32 EmpId { get; set; }
    }
}
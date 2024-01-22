
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccVoucherDtlBillRef")]
    [BasedOnRow(typeof(Entities.AccVoucherDtlBillRefRow))]
    public class AccVoucherDtlBillRefColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 Id { get; set; }
        [EditLink]
        public DateTime BillDate { get; set; }
        public String BillType { get; set; }
        public String BillRefNo { get; set; }
        [AlignRight]
        public Double Amount { get; set; }



    //    public String Description { get; set; }
    }
}
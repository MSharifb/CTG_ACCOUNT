
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccChequeBook")]
    [BasedOnRow(typeof(Entities.AccChequeBookRow))]
    public class AccChequeBookColumns
    {
        [DisplayName("Db.Shared.RecordId"), Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink, Width(150)]
        public String CheckBookName { get; set; }
        [Width(150)]
        public String BankAccountInformationAccountNumber { get; set; }

        [AlignRight, QuickFilter]
        public DateTime CBDate { get; set; }

        public Int32 StartingNo { get; set; }
        public Int32 EndingNo { get; set; }
        public Int32 PageNo { get; set; }
        public String Prefix { get; set; }

        [AlignCenter, QuickFilter]
        public bool HasFinished { get; set; }

        [QuickFilter, FilterOnly]
        public Int32 BankAccountInformationId { get; set; }
    }
}

namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccChequeReceiveRegister")]
    [BasedOnRow(typeof(Entities.AccChequeReceiveRegisterRow))]
    public class AccChequeReceiveRegisterColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"),Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink]
        public String ChequeNo { get; set; }

        [AlignCenter, QuickFilter]
        public DateTime ChequeDate { get; set; }

        [AlignCenter, QuickFilter]
        public DateTime ChequeReceiveDate { get; set; }
        public String RecieveFrom { get; set; }
        public String AccountNo { get; set; }

        [AlignRight]
        public Decimal Amount { get; set; }  
               
        //public String BankName { get; set; }

        //public String ChequeType { get; set; }

        //public String AccountName { get; set; }     

        //  public String BranchName { get; set; }
       
    }
}
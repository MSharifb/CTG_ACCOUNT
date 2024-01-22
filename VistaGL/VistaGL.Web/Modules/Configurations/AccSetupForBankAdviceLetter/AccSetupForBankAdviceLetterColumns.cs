
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccSetupForBankAdviceLetter")]
    [BasedOnRow(typeof(Entities.AccSetupForBankAdviceLetterRow))]
    public class AccSetupForBankAdviceLetterColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight,Hidden]
        public Int32 Id { get; set; }

        [EditLink]
        public String CoaAccountName { get; set; }

        public String MemorandumNo { get; set; }

        public Boolean IsAutoBankAdvice { get; set; }

        //public Int32 ZoneInfoId { get; set; }
        //public Int32 FundControlId { get; set; }
    }
}
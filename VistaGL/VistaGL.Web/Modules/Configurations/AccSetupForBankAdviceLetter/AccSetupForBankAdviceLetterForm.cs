
namespace VistaGL.Configurations.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("Configurations.AccSetupForBankAdviceLetter")]
    [BasedOnRow(typeof(Entities.AccSetupForBankAdviceLetterRow))]
    public class AccSetupForBankAdviceLetterForm
    {
        [CssClass("width6"), DisplayName("Account Bank")]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup")]
        public Int32 CoaId { get; set; }

        public String MemorandumNo { get; set; }

        [TextAreaEditor(Rows = 3)]
        public String Duplication { get; set; }

        public Boolean IsAutoBankAdvice { get; set; }

        [Hidden]
        public Int32 ZoneInfoId { get; set; }
        [Hidden]
        public Int32 FundControlId { get; set; }
    }
}

namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccBankAdviceLetterTemplate")]
    [BasedOnRow(typeof(Entities.AccBankAdviceLetterTemplateRow))]
    public class AccBankAdviceLetterTemplateForm
    {
        public String Subject { get; set; }

        [TextAreaEditor(Rows = 2)]
        public String Body1 { get; set; }
        [TextAreaEditor(Rows = 2)]
        public String Body2 { get; set; }
    }
}
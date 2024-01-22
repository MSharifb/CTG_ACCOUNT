
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccBankAdviceLetterTemplate")]
    [BasedOnRow(typeof(Entities.AccBankAdviceLetterTemplateRow))]
    public class AccBankAdviceLetterTemplateColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String Subject { get; set; }
        public String Body1 { get; set; }
        public String Body2 { get; set; }
    }
}
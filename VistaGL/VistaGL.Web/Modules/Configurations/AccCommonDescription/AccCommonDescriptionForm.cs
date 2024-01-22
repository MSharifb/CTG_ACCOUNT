
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccCommonDescription")]
    [BasedOnRow(typeof(Entities.AccCommonDescriptionRow))]
    public class AccCommonDescriptionForm
    {
        [Required]
        public Int32 VoucherTypeId { get; set; }

        [Required]
        public Int32 TransactionTypeId { get; set; }

        [TextAreaEditor(Rows = 5)]
        public String Description { get; set; }

    }
}
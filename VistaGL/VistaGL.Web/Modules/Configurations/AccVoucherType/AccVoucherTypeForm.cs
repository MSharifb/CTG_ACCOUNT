
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccVoucherType")]
    [BasedOnRow(typeof(Entities.AccVoucherTypeRow))]
    public class AccVoucherTypeForm
    {
        public String Name { get; set; }
        public Int32 SortOrder { get; set; }
    }
}

namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccVoucherApiDetails")]
    [BasedOnRow(typeof(Entities.AccVoucherApiDetailsRow))]
    public class AccVoucherApiDetailsForm
    {
        public Int32 ConfigId { get; set; }
        public Int32 AccountHeadId { get; set; }
        public String DrCr { get; set; }
        public String Description { get; set; }
        public Double Amount { get; set; }
        public Int32 EmpId { get; set; }
    }
}
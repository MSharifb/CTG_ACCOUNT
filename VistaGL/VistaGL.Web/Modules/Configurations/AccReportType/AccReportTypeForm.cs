
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccReportType")]
    [BasedOnRow(typeof(Entities.AccReportTypeRow), CheckNames = true)]
    public class AccReportTypeForm
    {
        public String ReportType { get; set; }
    }
}

namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccUnitType")]
    [BasedOnRow(typeof(Entities.AccUnitTypeRow))]
    public class AccUnitTypeForm
    {

        public String UnitName { get; set; }

        [TextAreaEditor(Rows = 5)]
        public String Remarks { get; set; }
    }
}
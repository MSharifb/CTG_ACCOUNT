
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccFundControlInformation")]
    [BasedOnRow(typeof(Entities.AccFundControlInformationRow))]
    public class AccFundControlInformationForm
    {
        public String FundControlName { get; set; }
        public String Code { get; set; }
        //public DateTime BookingDate { get; set; }
        public Int32 CurrencyId { get; set; }
        //public String Address { get; set; }
        //public String Phone { get; set; }
        //public String Mobile { get; set; }
        //public String Fax { get; set; }
        //public String Email { get; set; }
        //public String WebUrl { get; set; }

        //[TextAreaEditor(Rows =5)]
        //public String Remarks { get; set; }

        //[Hidden]
        //public int ZoneInfoId { get; set; }
    }
}
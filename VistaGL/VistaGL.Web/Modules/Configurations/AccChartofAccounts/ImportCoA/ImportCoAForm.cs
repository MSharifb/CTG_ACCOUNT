﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serenity.ComponentModel;
using System.ComponentModel;

namespace VistaGL.Configurations.Forms
{
    [FormScript("Configurations.ImportCoAForm")]

    public class ImportCoAForm
    {
        //[DisplayName("Fund Control")]
        //[LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
        //public Int32 FundControlInformationId { get; set; }

        [CoAEditor, DisplayName("")]
        public List<Transaction.Entities.AccTransactionTypeAssignRow> CoADebit { get; set; }
    }
}
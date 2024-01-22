﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.FinancialNotes
{
    public class FinancialNotesModel
    {
        public String ParentAccountName { get; set; }
        public String AccountName { get; set; }
        public String coa_name { get; set; }
        public String account_code { get; set; }   
        public String ZoneCode { get; set; }

        public Decimal periodBalance { get; set; }

        public Decimal totalDebit { get; set; }
        public Decimal totalCredit { get; set; }
        public Decimal debitBalance { get; set; }
        public Decimal creditBalance { get; set; }

        public int SortOrder { get; set; }
    }
}
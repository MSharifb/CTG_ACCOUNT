using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports
{
    public class ChartofAccountRptModel
    {
        //     '' AS coa_id,
        //         coa_name,
        //'' AS account_code,
        //         fundControl_id,
        //         accountGroup,
        //         SUM(openingBalance)AS openingBalance,
        //         SUM(periodBalance) AS periodBalance,
        //         SUM(closingBalance) AS closingBalance,
        //         SUM(periodDebit) AS periodDebit,
        //         SUM(periodCredit) AS periodCredit

        public String coa_id { get; set; }
        public String coa_name { get; set; }
        public String account_code { get; set; }
        public int fundControl_id { get; set; }
        public String accountGroup { get; set; }
        public Decimal openingBalance { get; set; }
        public Decimal periodBalance { get; set; }
        public Decimal closingBalance { get; set; }
        public Decimal periodDebit { get; set; }
        public Decimal periodCredit { get; set; }
        public int SortOrder { get; set; }

    }
}
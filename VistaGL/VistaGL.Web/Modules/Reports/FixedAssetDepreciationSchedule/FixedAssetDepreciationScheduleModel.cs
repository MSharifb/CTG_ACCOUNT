using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.FixedAssetDepreciationSchedule
{
    public class FixedAssetDepreciationScheduleModel
    {
        public String ZoneName { get; set; }
        public String WorkType { get; set; }
        public String ParentGroup { get; set; }
        public String Subledger { get; set; }
        public Decimal CostOpeningBalance { get; set; }
        public Decimal CostAddition { get; set; }
        public Decimal CostAdjustment { get; set; }
        public Decimal CostClosingBalance { get; set; }
        public Decimal RateOfDenreciation { get; set; }
        public Decimal DepOpeningBalance { get; set; }
        public Decimal DepCharge { get; set; }
        public Decimal DepAdjustment { get; set; }
        public Decimal DepClosingBalance { get; set; }
        public Decimal BookValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
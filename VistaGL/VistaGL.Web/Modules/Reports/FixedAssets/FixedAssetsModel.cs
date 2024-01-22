using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.FixedAssets
{
    public class FixedAssetsModel
    {
        public string AssetType { get; set; }
        public string ParentSubLedger { get; set; }
        public string SubLedger { get; set; }
        public decimal OpeningBalanceCost { get; set; }
        public decimal OpeningBalanceDepreciation { get; set; }
    }
}
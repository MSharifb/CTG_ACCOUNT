
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccReportTypeGroupSetup")]
    [BasedOnRow(typeof(Entities.AccReportTypeGroupSetupRow), CheckNames = true)]
    public class AccReportTypeGroupSetupForm
    {
        public Int32 ReportTypeId { get; set; }
        public Int32 ParentId { get; set; }
        public String GroupName { get; set; }
        [HalfWidth]
        public Int32 SortingOrder { get; set; }
        [HalfWidth]
        public Boolean ShowAutoSum { get; set; }
        [HalfWidth]
        public Decimal NoteNo { get; set; }
        [HalfWidth]
        public Boolean AddBlankSpaceBefore { get; set; }
        [HalfWidth]
        public Boolean AddBlankSpaceAfter { get; set; }
        [HalfWidth]
        public Boolean ShowBottomBorder { get; set; }
        [HalfWidth]
        public Boolean ShowUpperBorder { get; set; }
        [HalfWidth]
        public Boolean ShowLeftBorder { get; set; }
        [HalfWidth]
        public Boolean ShowRightBorder { get; set; }
        [HalfWidth]
        public String Symbol { get; set; }
        [HalfWidth]
        public String FontWeight { get; set; }
        [Hidden]
        public Int32 FundControlId { get; set; }
    }
}
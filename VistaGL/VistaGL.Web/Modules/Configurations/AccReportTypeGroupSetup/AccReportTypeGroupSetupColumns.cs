
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccReportTypeGroupSetup")]
    [BasedOnRow(typeof(Entities.AccReportTypeGroupSetupRow), CheckNames = true)]
    public class AccReportTypeGroupSetupColumns
    {
        [EditLink]
        public String GroupName { get; set; }
        [QuickFilter]
        public String ReportType { get; set; }
        public Boolean ShowAutoSum { get; set; }
        public String ParentGroupName { get; set; }
        public Int32 NoteNo { get; set; }
        public Boolean AddBlankSpaceBefore { get; set; }
        public Boolean AddBlankSpaceAfter { get; set; }
        public Boolean ShowBottomBorder { get; set; }
        public Boolean ShowUpperBorder { get; set; }
        public Boolean ShowLeftBorder { get; set; }
        public Boolean ShowRightBorder { get; set; }
    }
}

namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[acc_ReportTypeGroupSetup]")][DisplayName("Report Type Group Setup"), InstanceName("Report Type Group Setup")]
    [ReadPermission("Configurations:AccReportTypeGroupSetup:Read")]
    [InsertPermission("Configurations:AccReportTypeGroupSetup:Insert")]
    [UpdatePermission("Configurations:AccReportTypeGroupSetup:Update")]
    [DeletePermission("Configurations:AccReportTypeGroupSetup:Delete")]
    [LookupScript("Configurations.AccReportTypeGroupSetup", Permission = "?")]
    public sealed class AccReportTypeGroupSetupRow : NRow, IIdRow, INameRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Parent Group"),ForeignKey("[dbo].[acc_ReportTypeGroupSetup]", "Id"), LeftJoin("jParentGroup")]
        [LookupEditor(typeof(AccReportTypeGroupSetupRow)), LookupInclude]
        public Int32? ParentId
        {
            get { return Fields.ParentId[this]; }
            set { Fields.ParentId[this] = value; }
        }

        [DisplayName("Report Type"), ForeignKey("[dbo].[acc_ReportType]", "Id"), LeftJoin("jReportType"), TextualField("ReportType")]
        [LookupEditor(typeof(AccReportTypeRow)),LookupInclude, NotNull]
        public Int32? ReportTypeId
        {
            get { return Fields.ReportTypeId[this]; }
            set { Fields.ReportTypeId[this] = value; }
        }

        [DisplayName("Group Name"), Size(255), QuickSearch, NotNull]
        public String GroupName
        {
            get { return Fields.GroupName[this]; }
            set { Fields.GroupName[this] = value; }
        }

        [DisplayName("Sorting Order")]
        public Int32? SortingOrder
        {
            get { return Fields.SortingOrder[this]; }
            set { Fields.SortingOrder[this] = value; }
        }

        [DisplayName("Auto Sum")]
        public Boolean? ShowAutoSum
        {
            get { return Fields.ShowAutoSum[this]; }
            set { Fields.ShowAutoSum[this] = value; }
        }

        [DisplayName("Note No")]
        public Decimal? NoteNo
        {
            get { return Fields.NoteNo[this]; }
            set { Fields.NoteNo[this] = value; }
        }

        [DisplayName("Add Blank Space Before")]
        public Boolean? AddBlankSpaceBefore
        {
            get { return Fields.AddBlankSpaceBefore[this]; }
            set { Fields.AddBlankSpaceBefore[this] = value; }
        }

        [DisplayName("Add Blank Space After")]
        public Boolean? AddBlankSpaceAfter
        {
            get { return Fields.AddBlankSpaceAfter[this]; }
            set { Fields.AddBlankSpaceAfter[this] = value; }
        }

        [DisplayName("Bottom Border")]
        public Boolean? ShowBottomBorder
        {
            get { return Fields.ShowBottomBorder[this]; }
            set { Fields.ShowBottomBorder[this] = value; }
        }

        [DisplayName("Upper Border")]
        public Boolean? ShowUpperBorder
        {
            get { return Fields.ShowUpperBorder[this]; }
            set { Fields.ShowUpperBorder[this] = value; }
        }

        [DisplayName("Left Border")]
        public Boolean? ShowLeftBorder
        {
            get { return Fields.ShowLeftBorder[this]; }
            set { Fields.ShowLeftBorder[this] = value; }
        }

        [DisplayName("Right Border")]
        public Boolean? ShowRightBorder
        {
            get { return Fields.ShowRightBorder[this]; }
            set { Fields.ShowRightBorder[this] = value; }
        }

        [DisplayName("Symbol")]
        public String Symbol
        {
            get { return Fields.Symbol[this]; }
            set { Fields.Symbol[this] = value; }
        }
        
        [DisplayName("Font Weight")]
        public String FontWeight
        {
            get { return Fields.FontWeight[this]; }
            set { Fields.FontWeight[this] = value; }
        }

        [DisplayName("Fund Control"), ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControl"), TextualField("FundControlCode")]
        public Int32? FundControlId
        {
            get { return Fields.FundControlId[this]; }
            set { Fields.FundControlId[this] = value; }
        }

        [DisplayName("Parent Group Name"), Expression("jParentGroup.[GroupName]")]
        public String ParentGroupName
        {
            get { return Fields.ParentGroupName[this]; }
            set { Fields.ParentGroupName[this] = value; }
        }


        [DisplayName("Report Type"), Expression("jReportType.[ReportType]")]
        public String ReportType
        {
            get { return Fields.ReportType[this]; }
            set { Fields.ReportType[this] = value; }
        }

  
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.GroupName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccReportTypeGroupSetupRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {

            public Int32Field Id;

            public Int32Field ParentId;

            public Int32Field ReportTypeId;

            public StringField GroupName;

            public Int32Field SortingOrder;

            public BooleanField ShowAutoSum;

            public DecimalField NoteNo;

            public BooleanField AddBlankSpaceBefore;

            public BooleanField AddBlankSpaceAfter;

            public BooleanField ShowBottomBorder;

            public BooleanField ShowUpperBorder;

            public BooleanField ShowLeftBorder;

            public BooleanField ShowRightBorder;

            public Int32Field FundControlId;

            public StringField ReportType;

            public StringField ParentGroupName;

            public StringField Symbol;

            public StringField FontWeight;
        }
    }
}


namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[acc_ReportTypeCostCenterMapping]")]
    [DisplayName("Report Type Sub-Ledger Mapping"), InstanceName("Report Type Sub-Ledger Mapping")]
    [ReadPermission("Configurations:AccReportTypeCostCenterMapping:Read")]
    [InsertPermission("Configurations:AccReportTypeCostCenterMapping:Insert")]
    [UpdatePermission("Configurations:AccReportTypeCostCenterMapping:Update")]
    [DeletePermission("Configurations:AccReportTypeCostCenterMapping:Delete")]
    [LookupScript("Configurations.AccReportTypeCostCenterMapping", Permission = "?")]
    public sealed class AccReportTypeCostCenterMappingRow : Row, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Group"), NotNull, ForeignKey("[dbo].[acc_ReportTypeGroupSetup]", "Id"), LeftJoin("jGroup"), TextualField("GroupGroupName")]
        [LookupEditor(typeof(AccReportTypeGroupSetupRow), CascadeFrom = "ReportTypeId")]
        public Int32? GroupId
        {
            get { return Fields.GroupId[this]; }
            set { Fields.GroupId[this] = value; }
        }

        [DisplayName("Sub-Ledger"), NotNull, ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jCostCenter"), TextualField("CostCenterCode")]
        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow), InplaceAdd = true, FilterField = nameof(Transaction.Entities.AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        public Int32? CostCenterId
        {
            get { return Fields.CostCenterId[this]; }
            set { Fields.CostCenterId[this] = value; }
        }

        [DisplayName("Opening Balance"), Column("OpeningBalance")]
        public Decimal? OpeningBalance
        {
            get { return Fields.OpeningBalance[this]; }
            set { Fields.OpeningBalance[this] = value; }
        }

        [DisplayName("Group Parent Id"), Expression("jGroup.[ParentId]")]
        public Int32? GroupParentId
        {
            get { return Fields.GroupParentId[this]; }
            set { Fields.GroupParentId[this] = value; }
        }

        [DisplayName("Group Report Type Id"), Expression("jGroup.[ReportTypeId]")]
        public Int32? GroupReportTypeId
        {
            get { return Fields.GroupReportTypeId[this]; }
            set { Fields.GroupReportTypeId[this] = value; }
        }

        [DisplayName("Group Name"), Expression("jGroup.[GroupName]")]
        public String GroupGroupName
        {
            get { return Fields.GroupGroupName[this]; }
            set { Fields.GroupGroupName[this] = value; }
        }

        [DisplayName("Group Sorting Order"), Expression("jGroup.[SortingOrder]")]
        public Int32? GroupSortingOrder
        {
            get { return Fields.GroupSortingOrder[this]; }
            set { Fields.GroupSortingOrder[this] = value; }
        }

        [DisplayName("Group Show Auto Sum"), Expression("jGroup.[ShowAutoSum]")]
        public Boolean? GroupShowAutoSum
        {
            get { return Fields.GroupShowAutoSum[this]; }
            set { Fields.GroupShowAutoSum[this] = value; }
        }

        [DisplayName("Group Note No"), Expression("jGroup.[NoteNo]")]
        public Int32? GroupNoteNo
        {
            get { return Fields.GroupNoteNo[this]; }
            set { Fields.GroupNoteNo[this] = value; }
        }

        [DisplayName("Group Add Blank Space Before"), Expression("jGroup.[AddBlankSpaceBefore]")]
        public Boolean? GroupAddBlankSpaceBefore
        {
            get { return Fields.GroupAddBlankSpaceBefore[this]; }
            set { Fields.GroupAddBlankSpaceBefore[this] = value; }
        }

        [DisplayName("Group Add Blank Space After"), Expression("jGroup.[AddBlankSpaceAfter]")]
        public Boolean? GroupAddBlankSpaceAfter
        {
            get { return Fields.GroupAddBlankSpaceAfter[this]; }
            set { Fields.GroupAddBlankSpaceAfter[this] = value; }
        }

        [DisplayName("Group Show Bottom Border"), Expression("jGroup.[ShowBottomBorder]")]
        public Boolean? GroupShowBottomBorder
        {
            get { return Fields.GroupShowBottomBorder[this]; }
            set { Fields.GroupShowBottomBorder[this] = value; }
        }

        [DisplayName("Group Show Upper Border"), Expression("jGroup.[ShowUpperBorder]")]
        public Boolean? GroupShowUpperBorder
        {
            get { return Fields.GroupShowUpperBorder[this]; }
            set { Fields.GroupShowUpperBorder[this] = value; }
        }

        [DisplayName("Group Show Left Border"), Expression("jGroup.[ShowLeftBorder]")]
        public Boolean? GroupShowLeftBorder
        {
            get { return Fields.GroupShowLeftBorder[this]; }
            set { Fields.GroupShowLeftBorder[this] = value; }
        }

        [DisplayName("Group Show Right Border"), Expression("jGroup.[ShowRightBorder]")]
        public Boolean? GroupShowRightBorder
        {
            get { return Fields.GroupShowRightBorder[this]; }
            set { Fields.GroupShowRightBorder[this] = value; }
        }

        [DisplayName("Group Fund Control Id"), Expression("jGroup.[FundControlId]")]
        public Int32? GroupFundControlId
        {
            get { return Fields.GroupFundControlId[this]; }
            set { Fields.GroupFundControlId[this] = value; }
        }

        [DisplayName("Report Type"), Expression("jGroup.[ReportTypeId]")]
        [LookupEditor(typeof(AccReportTypeRow))]
        public Int32? ReportTypeId
        {
            get { return Fields.ReportTypeId[this]; }
            set { Fields.ReportTypeId[this] = value; }
        }

        [DisplayName("Cost Center Code"), Expression("jCostCenter.[code]")]
        public String CostCenterCode
        {
            get { return Fields.CostCenterCode[this]; }
            set { Fields.CostCenterCode[this] = value; }
        }

        [DisplayName("Cost Center Code Count"), Expression("jCostCenter.[codeCount]")]
        public Int32? CostCenterCodeCount
        {
            get { return Fields.CostCenterCodeCount[this]; }
            set { Fields.CostCenterCodeCount[this] = value; }
        }

        [DisplayName("Cost Center User Code"), Expression("jCostCenter.[userCode]")]
        public String CostCenterUserCode
        {
            get { return Fields.CostCenterUserCode[this]; }
            set { Fields.CostCenterUserCode[this] = value; }
        }

        [DisplayName("Cost Center Is Institute"), Expression("jCostCenter.[isInstitute]")]
        public Boolean? CostCenterIsInstitute
        {
            get { return Fields.CostCenterIsInstitute[this]; }
            set { Fields.CostCenterIsInstitute[this] = value; }
        }

        [DisplayName("Sub-ledger"), Expression("jCostCenter.[name]")]
        public String CostCenterName
        {
            get { return Fields.CostCenterName[this]; }
            set { Fields.CostCenterName[this] = value; }
        }

        [DisplayName("Cost Center Name For Bank Advice Letter"), Expression("jCostCenter.[NameForBankAdviceLetter]")]
        public String CostCenterNameForBankAdviceLetter
        {
            get { return Fields.CostCenterNameForBankAdviceLetter[this]; }
            set { Fields.CostCenterNameForBankAdviceLetter[this] = value; }
        }

        [DisplayName("Cost Center Pa Ammount"), Expression("jCostCenter.[paAmmount]")]
        public Decimal? CostCenterPaAmmount
        {
            get { return Fields.CostCenterPaAmmount[this]; }
            set { Fields.CostCenterPaAmmount[this] = value; }
        }

        [DisplayName("Cost Center Remarks"), Expression("jCostCenter.[remarks]")]
        public String CostCenterRemarks
        {
            get { return Fields.CostCenterRemarks[this]; }
            set { Fields.CostCenterRemarks[this] = value; }
        }

        [DisplayName("Cost Center Parent Id"), Expression("jCostCenter.[parentId]")]
        public Int32? CostCenterParentId
        {
            get { return Fields.CostCenterParentId[this]; }
            set { Fields.CostCenterParentId[this] = value; }
        }

        [DisplayName("Cost Center Cost Center Type Id"), Expression("jCostCenter.[CostCenterTypeId]")]
        public Int32? CostCenterCostCenterTypeId
        {
            get { return Fields.CostCenterCostCenterTypeId[this]; }
            set { Fields.CostCenterCostCenterTypeId[this] = value; }
        }

        [DisplayName("Cost Center Emp Id"), Expression("jCostCenter.[empId]")]
        public Int32? CostCenterEmpId
        {
            get { return Fields.CostCenterEmpId[this]; }
            set { Fields.CostCenterEmpId[this] = value; }
        }

        [DisplayName("Cost Center Is Active"), Expression("jCostCenter.[IsActive]")]
        public Boolean? CostCenterIsActive
        {
            get { return Fields.CostCenterIsActive[this]; }
            set { Fields.CostCenterIsActive[this] = value; }
        }

        [DisplayName("Cost Center Entity Id"), Expression("jCostCenter.[entityId]")]
        public Int32? CostCenterEntityId
        {
            get { return Fields.CostCenterEntityId[this]; }
            set { Fields.CostCenterEntityId[this] = value; }
        }

        [DisplayName("Cost Center Zone Info Id"), Expression("jCostCenter.[ZoneInfoId]")]
        public Int32? CostCenterZoneInfoId
        {
            get { return Fields.CostCenterZoneInfoId[this]; }
            set { Fields.CostCenterZoneInfoId[this] = value; }
        }

        [DisplayName("Cost Center Is Budget Head"), Expression("jCostCenter.[isBudgetHead]")]
        public Boolean? CostCenterIsBudgetHead
        {
            get { return Fields.CostCenterIsBudgetHead[this]; }
            set { Fields.CostCenterIsBudgetHead[this] = value; }
        }

        [DisplayName("Cost Center Budget Group Id"), Expression("jCostCenter.[BudgetGroupId]")]
        public Int32? CostCenterBudgetGroupId
        {
            get { return Fields.CostCenterBudgetGroupId[this]; }
            set { Fields.CostCenterBudgetGroupId[this] = value; }
        }

        [DisplayName("Cost Center Is Fixed Asset Head"), Expression("jCostCenter.[IsFixedAssetHead]")]
        public Boolean? CostCenterIsFixedAssetHead
        {
            get { return Fields.CostCenterIsFixedAssetHead[this]; }
            set { Fields.CostCenterIsFixedAssetHead[this] = value; }
        }

        [DisplayName("Cost Center Is Fixed Asset Dev Work"), Expression("jCostCenter.[IsFixedAssetDevWork]")]
        public Boolean? CostCenterIsFixedAssetDevWork
        {
            get { return Fields.CostCenterIsFixedAssetDevWork[this]; }
            set { Fields.CostCenterIsFixedAssetDevWork[this] = value; }
        }

        [DisplayName("Cost Center Is Fixed Asset Non Dev Work"), Expression("jCostCenter.[IsFixedAssetNonDevWork]")]
        public Boolean? CostCenterIsFixedAssetNonDevWork
        {
            get { return Fields.CostCenterIsFixedAssetNonDevWork[this]; }
            set { Fields.CostCenterIsFixedAssetNonDevWork[this] = value; }
        }

        [DisplayName("Cost Center Depreciation Rate"), Expression("jCostCenter.[DepreciationRate]")]
        public Decimal? CostCenterDepreciationRate
        {
            get { return Fields.CostCenterDepreciationRate[this]; }
            set { Fields.CostCenterDepreciationRate[this] = value; }
        }

        [DisplayName("Cost Center Budget Code"), Expression("jCostCenter.[BudgetCode]")]
        public String CostCenterBudgetCode
        {
            get { return Fields.CostCenterBudgetCode[this]; }
            set { Fields.CostCenterBudgetCode[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccReportTypeCostCenterMappingRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field Id;

            public Int32Field GroupId;

            public Int32Field CostCenterId;



            public Int32Field GroupParentId;

            public Int32Field GroupReportTypeId;

            public StringField GroupGroupName;

            public Int32Field GroupSortingOrder;

            public BooleanField GroupShowAutoSum;

            public Int32Field GroupNoteNo;

            public BooleanField GroupAddBlankSpaceBefore;

            public BooleanField GroupAddBlankSpaceAfter;

            public BooleanField GroupShowBottomBorder;

            public BooleanField GroupShowUpperBorder;

            public BooleanField GroupShowLeftBorder;

            public BooleanField GroupShowRightBorder;

            public Int32Field GroupFundControlId;



            public StringField CostCenterCode;

            public Int32Field CostCenterCodeCount;

            public StringField CostCenterUserCode;

            public BooleanField CostCenterIsInstitute;

            public StringField CostCenterName;

            public StringField CostCenterNameForBankAdviceLetter;

            public DecimalField CostCenterPaAmmount;

            public StringField CostCenterRemarks;

            public Int32Field CostCenterParentId;

            public Int32Field CostCenterCostCenterTypeId;

            public Int32Field CostCenterEmpId;

            public BooleanField CostCenterIsActive;

            public Int32Field CostCenterEntityId;

            public Int32Field CostCenterZoneInfoId;

            public BooleanField CostCenterIsBudgetHead;

            public Int32Field CostCenterBudgetGroupId;

            public BooleanField CostCenterIsFixedAssetHead;

            public BooleanField CostCenterIsFixedAssetDevWork;

            public BooleanField CostCenterIsFixedAssetNonDevWork;

            public DecimalField CostCenterDepreciationRate;

            public StringField CostCenterBudgetCode;

            public DecimalField OpeningBalance;

            public Int32Field ReportTypeId;
        }
    }
}

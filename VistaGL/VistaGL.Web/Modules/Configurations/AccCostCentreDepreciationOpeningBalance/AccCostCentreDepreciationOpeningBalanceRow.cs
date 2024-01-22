
namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), TableName("[dbo].[acc_Cost_Centre_DepreciationOpeningBalance]"), DisplayName("Depreciation Opening Balance"), InstanceName("Depreciation Opening Balance"), TwoLevelCached]
    [ReadPermission("Configurations:AccCostCentreDepreciationOpeningBalance:Read")]
    [InsertPermission("Configurations:AccCostCentreDepreciationOpeningBalance:Insert")]
    [UpdatePermission("Configurations:AccCostCentreDepreciationOpeningBalance:Update")]
    [DeletePermission("Configurations:AccCostCentreDepreciationOpeningBalance:Delete")]
    [LookupScript("Configurations.AccCostCentreDepreciationOpeningBalance", Permission = "?")]
    public sealed class AccCostCentreDepreciationOpeningBalanceRow : NRow, IIdRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Sub Ledger"), ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jCostCenter"), TextualField("CostCenterCode")]
        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow),FilterField = nameof(Transaction.Entities.AccCostCentreOrInstituteInformationRow.IsFixedAssetHead), FilterValue = true)]
        public Int32? CostCenterId
        {
            get { return Fields.CostCenterId[this]; }
            set { Fields.CostCenterId[this] = value; }
        }

        [DisplayName("Opening Balance(Depreciation)"), Size(18), Scale(2)]
        public Decimal? OpeningBalanceDepreciation
        {
            get { return Fields.OpeningBalanceDepreciation[this]; }
            set { Fields.OpeningBalanceDepreciation[this] = value; }
        }
        [DisplayName("Opening Balance(Cost)"), Size(18), Scale(2)]
        public Decimal? OpeningBalanceCost
        {
            get { return Fields.OpeningBalanceCost[this]; }
            set { Fields.OpeningBalanceCost[this] = value; }
        }
        
        [DisplayName("Zone Info Id")]
        public Int32? ZoneInfoId
        {
            get { return Fields.ZoneInfoId[this]; }
            set { Fields.ZoneInfoId[this] = value; }
        }

        [DisplayName("Fund Control Id")]
        public Int32? FundControlId
        {
            get { return Fields.FundControlId[this]; }
            set { Fields.FundControlId[this] = value; }
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

        [DisplayName("Sub-ledger Code"), Expression("jCostCenter.[userCode]")]
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

        [DisplayName("Sub-Ledger"), Expression("jCostCenter.[name]")]
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

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccCostCentreDepreciationOpeningBalanceRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {
            public Int32Field Id;
            public Int32Field CostCenterId;
            public DecimalField OpeningBalanceDepreciation;
            public DecimalField OpeningBalanceCost;
            public Int32Field ZoneInfoId;
            public Int32Field FundControlId;

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

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Configurations.AccCostCentreDepreciationOpeningBalance";
            }
        }
    }
}

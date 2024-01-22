
namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Transaction"), TableName("[dbo].[acc_FixedAssetsManualInput]")]
    [DisplayName("Fixed Assets Input"), InstanceName("Fixed Assets Input")]
    [ReadPermission("Transaction:AccFixedAssetsManualInput:Read")]
    [InsertPermission("Transaction:AccFixedAssetsManualInput:Insert")]
    [UpdatePermission("Transaction:AccFixedAssetsManualInput:Update")]
    [DeletePermission("Transaction:AccFixedAssetsManualInput:Delete")]
    [LookupScript("Transaction.AccFixedAssetsManualInput", Permission = "?", Expiration = -1)]
    public sealed class AccFixedAssetsManualInputRow : NRow, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Sub Ledger"), NotNull, ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jCostCenter"), TextualField("CostCenterCode")]
        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow), FilterField = nameof(Transaction.Entities.AccCostCentreOrInstituteInformationRow.IsFixedAssetHead), FilterValue = true)]
        public Int32? CostCenterId
        {
            get { return Fields.CostCenterId[this]; }
            set { Fields.CostCenterId[this] = value; }
        }

        [DisplayName("Financial Year"), NotNull, ForeignKey("[dbo].[acc_Accounting_Period_Information]", "id"), LeftJoin("jFinancialYear"), TextualField("FinancialYearYearName")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow))]
        public Int32? FinancialYearId
        {
            get { return Fields.FinancialYearId[this]; }
            set { Fields.FinancialYearId[this] = value; }
        }

        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        public Int32? ZoneInfoId
        {
            get { return Fields.ZoneInfoId[this]; }
            set { Fields.ZoneInfoId[this] = value; }
        }

        [DisplayName("Addition Amount"), Size(18), Scale(2)]
        public Decimal? AdditionAmount
        {
            get { return Fields.AdditionAmount[this]; }
            set { Fields.AdditionAmount[this] = value; }
        }

        [DisplayName("Adjustment Amount"), Size(18), Scale(2)]
        public Decimal? AdjustmentAmount
        {
            get { return Fields.AdjustmentAmount[this]; }
            set { Fields.AdjustmentAmount[this] = value; }
        }
        [DisplayName("Dep. Charge"), Size(18), Scale(2)]
        public Decimal? DepCharge
        {
            get { return Fields.DepCharge[this]; }
            set { Fields.DepCharge[this] = value; }
        }
        [DisplayName("Dep. Adjustment Amount"), Size(18), Scale(2)]
        public Decimal? DepAdjustment
        {
            get { return Fields.DepAdjustment[this]; }
            set { Fields.DepAdjustment[this] = value; }
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

        [DisplayName("Sub ledger"), Expression("jCostCenter.[name]")]
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



        [DisplayName("Financial Year Is Active"), Expression("jFinancialYear.[isActive]")]
        public Boolean? FinancialYearIsActive
        {
            get { return Fields.FinancialYearIsActive[this]; }
            set { Fields.FinancialYearIsActive[this] = value; }
        }

        [DisplayName("Financial Year Is Closed"), Expression("jFinancialYear.[isClosed]")]
        public Boolean? FinancialYearIsClosed
        {
            get { return Fields.FinancialYearIsClosed[this]; }
            set { Fields.FinancialYearIsClosed[this] = value; }
        }

        [DisplayName("Financial Year Period End Date"), Expression("jFinancialYear.[periodEndDate]")]
        public DateTime? FinancialYearPeriodEndDate
        {
            get { return Fields.FinancialYearPeriodEndDate[this]; }
            set { Fields.FinancialYearPeriodEndDate[this] = value; }
        }

        [DisplayName("Financial Year Period Start Date"), Expression("jFinancialYear.[periodStartDate]")]
        public DateTime? FinancialYearPeriodStartDate
        {
            get { return Fields.FinancialYearPeriodStartDate[this]; }
            set { Fields.FinancialYearPeriodStartDate[this] = value; }
        }

        [DisplayName("Financial Year"), Expression("jFinancialYear.[yearName]")]
        public String FinancialYearYearName
        {
            get { return Fields.FinancialYearYearName[this]; }
            set { Fields.FinancialYearYearName[this] = value; }
        }

        [DisplayName("Financial Year Fund Control Information Id"), Expression("jFinancialYear.[fundControlInformation_id]")]
        public Int32? FinancialYearFundControlInformationId
        {
            get { return Fields.FinancialYearFundControlInformationId[this]; }
            set { Fields.FinancialYearFundControlInformationId[this] = value; }
        }



        [DisplayName("Zone Info Zone Name"), Expression("jZoneInfo.[ZoneName]")]
        public String ZoneInfoZoneName
        {
            get { return Fields.ZoneInfoZoneName[this]; }
            set { Fields.ZoneInfoZoneName[this] = value; }
        }

        [DisplayName("Zone Info Zone Name In Bengali"), Expression("jZoneInfo.[ZoneNameInBengali]")]
        public String ZoneInfoZoneNameInBengali
        {
            get { return Fields.ZoneInfoZoneNameInBengali[this]; }
            set { Fields.ZoneInfoZoneNameInBengali[this] = value; }
        }

        [DisplayName("Zone Info Zone Code"), Expression("jZoneInfo.[ZoneCode]")]
        public String ZoneInfoZoneCode
        {
            get { return Fields.ZoneInfoZoneCode[this]; }
            set { Fields.ZoneInfoZoneCode[this] = value; }
        }

        [DisplayName("Zone Info Sort Order"), Expression("jZoneInfo.[SortOrder]")]
        public Int32? ZoneInfoSortOrder
        {
            get { return Fields.ZoneInfoSortOrder[this]; }
            set { Fields.ZoneInfoSortOrder[this] = value; }
        }

        [DisplayName("Zone Info Organogram Category Type Id"), Expression("jZoneInfo.[OrganogramCategoryTypeId]")]
        public Int32? ZoneInfoOrganogramCategoryTypeId
        {
            get { return Fields.ZoneInfoOrganogramCategoryTypeId[this]; }
            set { Fields.ZoneInfoOrganogramCategoryTypeId[this] = value; }
        }

        [DisplayName("Zone Info Zone Address"), Expression("jZoneInfo.[ZoneAddress]")]
        public String ZoneInfoZoneAddress
        {
            get { return Fields.ZoneInfoZoneAddress[this]; }
            set { Fields.ZoneInfoZoneAddress[this] = value; }
        }

        [DisplayName("Zone Info Zone Address In Bengali"), Expression("jZoneInfo.[ZoneAddressInBengali]")]
        public String ZoneInfoZoneAddressInBengali
        {
            get { return Fields.ZoneInfoZoneAddressInBengali[this]; }
            set { Fields.ZoneInfoZoneAddressInBengali[this] = value; }
        }

        [DisplayName("Zone Info Prefix"), Expression("jZoneInfo.[Prefix]")]
        public String ZoneInfoPrefix
        {
            get { return Fields.ZoneInfoPrefix[this]; }
            set { Fields.ZoneInfoPrefix[this] = value; }
        }

        [DisplayName("Zone Info Is Head Office"), Expression("jZoneInfo.[IsHeadOffice]")]
        public Boolean? ZoneInfoIsHeadOffice
        {
            get { return Fields.ZoneInfoIsHeadOffice[this]; }
            set { Fields.ZoneInfoIsHeadOffice[this] = value; }
        }

        [DisplayName("Zone Info Zone Code For Billing System"), Expression("jZoneInfo.[ZoneCodeForBillingSystem]")]
        public String ZoneInfoZoneCodeForBillingSystem
        {
            get { return Fields.ZoneInfoZoneCodeForBillingSystem[this]; }
            set { Fields.ZoneInfoZoneCodeForBillingSystem[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccFixedAssetsManualInputRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {

            public Int32Field Id;

            public Int32Field CostCenterId;

            public Int32Field FinancialYearId;

            public Int32Field ZoneInfoId;

            public DecimalField AdditionAmount;

            public DecimalField AdjustmentAmount;

            public DecimalField DepCharge;
            public DecimalField DepAdjustment;

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

            public StringField CostCenterBudgetCode;



            public BooleanField FinancialYearIsActive;

            public BooleanField FinancialYearIsClosed;

            public DateTimeField FinancialYearPeriodEndDate;

            public DateTimeField FinancialYearPeriodStartDate;

            public StringField FinancialYearYearName;

            public Int32Field FinancialYearFundControlInformationId;



            public StringField ZoneInfoZoneName;

            public StringField ZoneInfoZoneNameInBengali;

            public StringField ZoneInfoZoneCode;

            public Int32Field ZoneInfoSortOrder;

            public Int32Field ZoneInfoOrganogramCategoryTypeId;

            public StringField ZoneInfoZoneAddress;

            public StringField ZoneInfoZoneAddressInBengali;

            public StringField ZoneInfoPrefix;

            public BooleanField ZoneInfoIsHeadOffice;

            public StringField ZoneInfoZoneCodeForBillingSystem;


		}
    }
}

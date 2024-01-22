
namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[acc_FinancialReportsDetails]")]
    [DisplayName("Financial Reports Details"), InstanceName("Financial Reports Details")]
    [ReadPermission("Configurations:AccFinancialReportsDetails:Read")]
    [InsertPermission("Configurations:AccFinancialReportsDetails:Insert")]
    [UpdatePermission("Configurations:AccFinancialReportsDetails:Update")]
    [DeletePermission("Configurations:AccFinancialReportsDetails:Delete")]
    [LookupScript("Configurations.AccFinancialReportsDetails", Permission = "?", Expiration = -1)]
    public sealed class AccFinancialReportsDetailsRow : Row, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Report Type"), NotNull]
        public String ReportType
        {
            get { return Fields.ReportType[this]; }
            set { Fields.ReportType[this] = value; }
        }

        [DisplayName("Zone"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        [LookupEditor(typeof(PrmZoneInfoRow))]
        public Int32? ZoneInfoId
        {
            get { return Fields.ZoneInfoId[this]; }
            set { Fields.ZoneInfoId[this] = value; }
        }

        [DisplayName("Entity Id"), NotNull]
        public Int32? EntityId
        {
            get { return Fields.EntityId[this]; }
            set { Fields.EntityId[this] = value; }
        }

        [DisplayName("Account Head"), QuickFilter, Column("COAId"), ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoa"), TextualField("CoaAccountGroup")]
        public Int32? CoaId
        {
            get { return Fields.CoaId[this]; }
            set { Fields.CoaId[this] = value; }
        }

        [DisplayName("Sub-ledger"), QuickFilter, ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jSubledger"), TextualField("SubledgerCode")]
        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow), FilterField = nameof(Transaction.Entities.AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        public Int32? SubledgerId
        {
            get { return Fields.SubledgerId[this]; }
            set { Fields.SubledgerId[this] = value; }
        }

        [DisplayName("Opening"), QuickFilter, Size(18), Scale(2)]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public Decimal? Opening
        {
            get { return Fields.Opening[this]; }
            set { Fields.Opening[this] = value; }
        }



        [DisplayName("Zone Name"), Expression("jZoneInfo.[ZoneName]")]
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



        [DisplayName("Coa Parent Account Id"), Expression("jCoa.[parentAccountId]")]
        public Int32? CoaParentAccountId
        {
            get { return Fields.CoaParentAccountId[this]; }
            set { Fields.CoaParentAccountId[this] = value; }
        }

        [DisplayName("Coa Level"), Expression("jCoa.[level]")]
        public Int32? CoaLevel
        {
            get { return Fields.CoaLevel[this]; }
            set { Fields.CoaLevel[this] = value; }
        }

        [DisplayName("Account Group"), Expression("jCoa.[accountGroup]")]
        public String CoaAccountGroup
        {
            get { return Fields.CoaAccountGroup[this]; }
            set { Fields.CoaAccountGroup[this] = value; }
        }

        [DisplayName("Coa Account Code"), Expression("jCoa.[accountCode]")]
        public String CoaAccountCode
        {
            get { return Fields.CoaAccountCode[this]; }
            set { Fields.CoaAccountCode[this] = value; }
        }

        [DisplayName("Coa Account Code Count"), Expression("jCoa.[accountCodeCount]")]
        public Int32? CoaAccountCodeCount
        {
            get { return Fields.CoaAccountCodeCount[this]; }
            set { Fields.CoaAccountCodeCount[this] = value; }
        }

        [DisplayName("Coa User Code"), Expression("jCoa.[UserCode]")]
        public String CoaUserCode
        {
            get { return Fields.CoaUserCode[this]; }
            set { Fields.CoaUserCode[this] = value; }
        }

        [DisplayName("Account Name"), Expression("jCoa.[accountName]")]
        public String CoaAccountName
        {
            get { return Fields.CoaAccountName[this]; }
            set { Fields.CoaAccountName[this] = value; }
        }

        [DisplayName("Coa Coa Mapping"), Expression("jCoa.[coaMapping]")]
        public String CoaCoaMapping
        {
            get { return Fields.CoaCoaMapping[this]; }
            set { Fields.CoaCoaMapping[this] = value; }
        }

        [DisplayName("Coa Is Controlhead"), Expression("jCoa.[isControlhead]")]
        public Int16? CoaIsControlhead
        {
            get { return Fields.CoaIsControlhead[this]; }
            set { Fields.CoaIsControlhead[this] = value; }
        }

        [DisplayName("Coa Is Cost Center Allocate"), Expression("jCoa.[isCostCenterAllocate]")]
        public Int16? CoaIsCostCenterAllocate
        {
            get { return Fields.CoaIsCostCenterAllocate[this]; }
            set { Fields.CoaIsCostCenterAllocate[this] = value; }
        }

        [DisplayName("Coa Opening Balance"), Expression("jCoa.[openingBalance]")]
        public Decimal? CoaOpeningBalance
        {
            get { return Fields.CoaOpeningBalance[this]; }
            set { Fields.CoaOpeningBalance[this] = value; }
        }

        [DisplayName("Coa Account Name Bangla"), Expression("jCoa.[accountNameBangla]")]
        public String CoaAccountNameBangla
        {
            get { return Fields.CoaAccountNameBangla[this]; }
            set { Fields.CoaAccountNameBangla[this] = value; }
        }

        [DisplayName("Coa Is Bill Ref"), Expression("jCoa.[isBillRef]")]
        public Int16? CoaIsBillRef
        {
            get { return Fields.CoaIsBillRef[this]; }
            set { Fields.CoaIsBillRef[this] = value; }
        }

        [DisplayName("Coa Mailing Address"), Expression("jCoa.[mailingAddress]")]
        public String CoaMailingAddress
        {
            get { return Fields.CoaMailingAddress[this]; }
            set { Fields.CoaMailingAddress[this] = value; }
        }

        [DisplayName("Coa Mailing Name"), Expression("jCoa.[mailingName]")]
        public String CoaMailingName
        {
            get { return Fields.CoaMailingName[this]; }
            set { Fields.CoaMailingName[this] = value; }
        }

        [DisplayName("Coa Remarks"), Expression("jCoa.[remarks]")]
        public String CoaRemarks
        {
            get { return Fields.CoaRemarks[this]; }
            set { Fields.CoaRemarks[this] = value; }
        }

        [DisplayName("Coa Tax Id"), Expression("jCoa.[taxID]")]
        public String CoaTaxId
        {
            get { return Fields.CoaTaxId[this]; }
            set { Fields.CoaTaxId[this] = value; }
        }

        [DisplayName("Coa Ugc Code"), Expression("jCoa.[ugcCode]")]
        public String CoaUgcCode
        {
            get { return Fields.CoaUgcCode[this]; }
            set { Fields.CoaUgcCode[this] = value; }
        }

        [DisplayName("Coa Multi Currency Id"), Expression("jCoa.[MultiCurrencyID]")]
        public Int32? CoaMultiCurrencyId
        {
            get { return Fields.CoaMultiCurrencyId[this]; }
            set { Fields.CoaMultiCurrencyId[this] = value; }
        }

        [DisplayName("Coa Effect Cash Flow"), Expression("jCoa.[EffectCashFlow]")]
        public Int32? CoaEffectCashFlow
        {
            get { return Fields.CoaEffectCashFlow[this]; }
            set { Fields.CoaEffectCashFlow[this] = value; }
        }

        [DisplayName("Coa Noa Acc Type Id"), Expression("jCoa.[NoaAccTypeId]")]
        public Int32? CoaNoaAccTypeId
        {
            get { return Fields.CoaNoaAccTypeId[this]; }
            set { Fields.CoaNoaAccTypeId[this] = value; }
        }

        [DisplayName("Coa Fund Control Id"), Expression("jCoa.[fundControlId]")]
        public Int32? CoaFundControlId
        {
            get { return Fields.CoaFundControlId[this]; }
            set { Fields.CoaFundControlId[this] = value; }
        }

        [DisplayName("Coa Sort Order"), Expression("jCoa.[SortOrder]")]
        public Int32? CoaSortOrder
        {
            get { return Fields.CoaSortOrder[this]; }
            set { Fields.CoaSortOrder[this] = value; }
        }

        [DisplayName("Coa Show Sum In Receipt Payment Report"), Expression("jCoa.[ShowSumInReceiptPaymentReport]")]
        public Boolean? CoaShowSumInReceiptPaymentReport
        {
            get { return Fields.CoaShowSumInReceiptPaymentReport[this]; }
            set { Fields.CoaShowSumInReceiptPaymentReport[this] = value; }
        }

        [DisplayName("Coa Is Budget Head"), Expression("jCoa.[isBudgetHead]")]
        public Boolean? CoaIsBudgetHead
        {
            get { return Fields.CoaIsBudgetHead[this]; }
            set { Fields.CoaIsBudgetHead[this] = value; }
        }

        [DisplayName("Coa Budget Group Id"), Expression("jCoa.[BudgetGroupId]")]
        public Int32? CoaBudgetGroupId
        {
            get { return Fields.CoaBudgetGroupId[this]; }
            set { Fields.CoaBudgetGroupId[this] = value; }
        }

        [DisplayName("Coa Is Balance Sheet"), Expression("jCoa.[isBalanceSheet]")]
        public Boolean? CoaIsBalanceSheet
        {
            get { return Fields.CoaIsBalanceSheet[this]; }
            set { Fields.CoaIsBalanceSheet[this] = value; }
        }

        [DisplayName("Coa Balance Sheet Notes"), Expression("jCoa.[BalanceSheetNotes]")]
        public Int32? CoaBalanceSheetNotes
        {
            get { return Fields.CoaBalanceSheetNotes[this]; }
            set { Fields.CoaBalanceSheetNotes[this] = value; }
        }

        [DisplayName("Coa Is Income Expenditure"), Expression("jCoa.[isIncomeExpenditure]")]
        public Boolean? CoaIsIncomeExpenditure
        {
            get { return Fields.CoaIsIncomeExpenditure[this]; }
            set { Fields.CoaIsIncomeExpenditure[this] = value; }
        }

        [DisplayName("Coa Income Expenditure Notes"), Expression("jCoa.[IncomeExpenditureNotes]")]
        public Int32? CoaIncomeExpenditureNotes
        {
            get { return Fields.CoaIncomeExpenditureNotes[this]; }
            set { Fields.CoaIncomeExpenditureNotes[this] = value; }
        }

        [DisplayName("Coa Budget Code"), Expression("jCoa.[BudgetCode]")]
        public String CoaBudgetCode
        {
            get { return Fields.CoaBudgetCode[this]; }
            set { Fields.CoaBudgetCode[this] = value; }
        }

        [DisplayName("Coa Is Hide Children From This Level"), Expression("jCoa.[IsHideChildrenFromThisLevel]")]
        public Boolean? CoaIsHideChildrenFromThisLevel
        {
            get { return Fields.CoaIsHideChildrenFromThisLevel[this]; }
            set { Fields.CoaIsHideChildrenFromThisLevel[this] = value; }
        }



        [DisplayName("Subledger Code"), Expression("jSubledger.[code]")]
        public String SubledgerCode
        {
            get { return Fields.SubledgerCode[this]; }
            set { Fields.SubledgerCode[this] = value; }
        }

        [DisplayName("Subledger Code Count"), Expression("jSubledger.[codeCount]")]
        public Int32? SubledgerCodeCount
        {
            get { return Fields.SubledgerCodeCount[this]; }
            set { Fields.SubledgerCodeCount[this] = value; }
        }

        [DisplayName("Subledger User Code"), Expression("jSubledger.[userCode]")]
        public String SubledgerUserCode
        {
            get { return Fields.SubledgerUserCode[this]; }
            set { Fields.SubledgerUserCode[this] = value; }
        }

        [DisplayName("Subledger Is Institute"), Expression("jSubledger.[isInstitute]")]
        public Boolean? SubledgerIsInstitute
        {
            get { return Fields.SubledgerIsInstitute[this]; }
            set { Fields.SubledgerIsInstitute[this] = value; }
        }

        [DisplayName("Sub-ledger"), Expression("jSubledger.[name]")]
        public String SubledgerName
        {
            get { return Fields.SubledgerName[this]; }
            set { Fields.SubledgerName[this] = value; }
        }

        [DisplayName("Subledger Name For Bank Advice Letter"), Expression("jSubledger.[NameForBankAdviceLetter]")]
        public String SubledgerNameForBankAdviceLetter
        {
            get { return Fields.SubledgerNameForBankAdviceLetter[this]; }
            set { Fields.SubledgerNameForBankAdviceLetter[this] = value; }
        }

        [DisplayName("Subledger Pa Ammount"), Expression("jSubledger.[paAmmount]")]
        public Decimal? SubledgerPaAmmount
        {
            get { return Fields.SubledgerPaAmmount[this]; }
            set { Fields.SubledgerPaAmmount[this] = value; }
        }

        [DisplayName("Subledger Remarks"), Expression("jSubledger.[remarks]")]
        public String SubledgerRemarks
        {
            get { return Fields.SubledgerRemarks[this]; }
            set { Fields.SubledgerRemarks[this] = value; }
        }

        [DisplayName("Subledger Parent Id"), Expression("jSubledger.[parentId]")]
        public Int32? SubledgerParentId
        {
            get { return Fields.SubledgerParentId[this]; }
            set { Fields.SubledgerParentId[this] = value; }
        }

        [DisplayName("Subledger Cost Center Type Id"), Expression("jSubledger.[CostCenterTypeId]")]
        public Int32? SubledgerCostCenterTypeId
        {
            get { return Fields.SubledgerCostCenterTypeId[this]; }
            set { Fields.SubledgerCostCenterTypeId[this] = value; }
        }

        [DisplayName("Subledger Emp Id"), Expression("jSubledger.[empId]")]
        public Int32? SubledgerEmpId
        {
            get { return Fields.SubledgerEmpId[this]; }
            set { Fields.SubledgerEmpId[this] = value; }
        }

        [DisplayName("Subledger Is Active"), Expression("jSubledger.[IsActive]")]
        public Boolean? SubledgerIsActive
        {
            get { return Fields.SubledgerIsActive[this]; }
            set { Fields.SubledgerIsActive[this] = value; }
        }

        [DisplayName("Subledger Entity Id"), Expression("jSubledger.[entityId]")]
        public Int32? SubledgerEntityId
        {
            get { return Fields.SubledgerEntityId[this]; }
            set { Fields.SubledgerEntityId[this] = value; }
        }

        [DisplayName("Subledger Zone Info Id"), Expression("jSubledger.[ZoneInfoId]")]
        public Int32? SubledgerZoneInfoId
        {
            get { return Fields.SubledgerZoneInfoId[this]; }
            set { Fields.SubledgerZoneInfoId[this] = value; }
        }

        [DisplayName("Subledger Is Budget Head"), Expression("jSubledger.[isBudgetHead]")]
        public Boolean? SubledgerIsBudgetHead
        {
            get { return Fields.SubledgerIsBudgetHead[this]; }
            set { Fields.SubledgerIsBudgetHead[this] = value; }
        }

        [DisplayName("Subledger Budget Group Id"), Expression("jSubledger.[BudgetGroupId]")]
        public Int32? SubledgerBudgetGroupId
        {
            get { return Fields.SubledgerBudgetGroupId[this]; }
            set { Fields.SubledgerBudgetGroupId[this] = value; }
        }

        [DisplayName("Subledger Is Fixed Asset Head"), Expression("jSubledger.[IsFixedAssetHead]")]
        public Boolean? SubledgerIsFixedAssetHead
        {
            get { return Fields.SubledgerIsFixedAssetHead[this]; }
            set { Fields.SubledgerIsFixedAssetHead[this] = value; }
        }

        [DisplayName("Subledger Is Fixed Asset Dev Work"), Expression("jSubledger.[IsFixedAssetDevWork]")]
        public Boolean? SubledgerIsFixedAssetDevWork
        {
            get { return Fields.SubledgerIsFixedAssetDevWork[this]; }
            set { Fields.SubledgerIsFixedAssetDevWork[this] = value; }
        }

        [DisplayName("Subledger Is Fixed Asset Non Dev Work"), Expression("jSubledger.[IsFixedAssetNonDevWork]")]
        public Boolean? SubledgerIsFixedAssetNonDevWork
        {
            get { return Fields.SubledgerIsFixedAssetNonDevWork[this]; }
            set { Fields.SubledgerIsFixedAssetNonDevWork[this] = value; }
        }

        [DisplayName("Subledger Depreciation Rate"), Expression("jSubledger.[DepreciationRate]")]
        public Decimal? SubledgerDepreciationRate
        {
            get { return Fields.SubledgerDepreciationRate[this]; }
            set { Fields.SubledgerDepreciationRate[this] = value; }
        }

        [DisplayName("Subledger Budget Code"), Expression("jSubledger.[BudgetCode]")]
        public String SubledgerBudgetCode
        {
            get { return Fields.SubledgerBudgetCode[this]; }
            set { Fields.SubledgerBudgetCode[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccFinancialReportsDetailsRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field Id;

            public StringField ReportType;

            public Int32Field ZoneInfoId;

            public Int32Field EntityId;

            public Int32Field CoaId;

            public Int32Field SubledgerId;

            public DecimalField Opening;



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



            public Int32Field CoaParentAccountId;

            public Int32Field CoaLevel;

            public StringField CoaAccountGroup;

            public StringField CoaAccountCode;

            public Int32Field CoaAccountCodeCount;

            public StringField CoaUserCode;

            public StringField CoaAccountName;

            public StringField CoaCoaMapping;

            public Int16Field CoaIsControlhead;

            public Int16Field CoaIsCostCenterAllocate;

            public DecimalField CoaOpeningBalance;

            public StringField CoaAccountNameBangla;

            public Int16Field CoaIsBillRef;

            public StringField CoaMailingAddress;

            public StringField CoaMailingName;

            public StringField CoaRemarks;

            public StringField CoaTaxId;

            public StringField CoaUgcCode;

            public Int32Field CoaMultiCurrencyId;

            public Int32Field CoaEffectCashFlow;

            public Int32Field CoaNoaAccTypeId;

            public Int32Field CoaFundControlId;

            public Int32Field CoaSortOrder;

            public BooleanField CoaShowSumInReceiptPaymentReport;

            public BooleanField CoaIsBudgetHead;

            public Int32Field CoaBudgetGroupId;

            public BooleanField CoaIsBalanceSheet;

            public Int32Field CoaBalanceSheetNotes;

            public BooleanField CoaIsIncomeExpenditure;

            public Int32Field CoaIncomeExpenditureNotes;

            public StringField CoaBudgetCode;

            public BooleanField CoaIsHideChildrenFromThisLevel;



            public StringField SubledgerCode;

            public Int32Field SubledgerCodeCount;

            public StringField SubledgerUserCode;

            public BooleanField SubledgerIsInstitute;

            public StringField SubledgerName;

            public StringField SubledgerNameForBankAdviceLetter;

            public DecimalField SubledgerPaAmmount;

            public StringField SubledgerRemarks;

            public Int32Field SubledgerParentId;

            public Int32Field SubledgerCostCenterTypeId;

            public Int32Field SubledgerEmpId;

            public BooleanField SubledgerIsActive;

            public Int32Field SubledgerEntityId;

            public Int32Field SubledgerZoneInfoId;

            public BooleanField SubledgerIsBudgetHead;

            public Int32Field SubledgerBudgetGroupId;

            public BooleanField SubledgerIsFixedAssetHead;

            public BooleanField SubledgerIsFixedAssetDevWork;

            public BooleanField SubledgerIsFixedAssetNonDevWork;

            public DecimalField SubledgerDepreciationRate;

            public StringField SubledgerBudgetCode;


		}
    }
}

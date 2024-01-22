
namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Transaction"), TableName("[dbo].[acc_FixedAsset_Refurbishment]")]
    [DisplayName("Fixed Asset Refurbishment"), InstanceName("Fixed Asset Refurbishment")]
    [ReadPermission("Transaction:AccFixedAssetRefurbishment:Read")]
    [InsertPermission("Transaction:AccFixedAssetRefurbishment:Insert")]
    [UpdatePermission("Transaction:AccFixedAssetRefurbishment:Update")]
    [DeletePermission("Transaction:AccFixedAssetRefurbishment:Delete")]
    [LookupScript("Transaction.AccFixedAssetRefurbishment", Permission = "?", Expiration = -1)]
    public sealed class AccFixedAssetRefurbishmentRow : Row, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Coa"), Column("COAId"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoa"), TextualField("CoaAccountGroup")]
        public Int32? CoaId
        {
            get { return Fields.CoaId[this]; }
            set { Fields.CoaId[this] = value; }
        }

        [DisplayName("Financial Year"), NotNull, ForeignKey("[dbo].[acc_Accounting_Period_Information]", "id"), LeftJoin("jFinancialYear"), TextualField("FinancialYearYearName")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow))]
        public Int32? FinancialYearId
        {
            get { return Fields.FinancialYearId[this]; }
            set { Fields.FinancialYearId[this] = value; }
        }

        [DisplayName("Cost Opening"), Size(18), Scale(2)]
        public Decimal? CostOpening
        {
            get { return Fields.CostOpening[this]; }
            set { Fields.CostOpening[this] = value; }
        }

        [DisplayName("Cost Addition"), Size(18), Scale(2)]
        public Decimal? CostAddition
        {
            get { return Fields.CostAddition[this]; }
            set { Fields.CostAddition[this] = value; }
        }

        [DisplayName("Cost Adjustment"), Size(18), Scale(2)]
        public Decimal? CostAdjustment
        {
            get { return Fields.CostAdjustment[this]; }
            set { Fields.CostAdjustment[this] = value; }
        }

        [DisplayName("Cost Closing"), Size(18), Scale(2)]
        public Decimal? CostClosing
        {
            get { return Fields.CostClosing[this]; }
            set { Fields.CostClosing[this] = value; }
        }

        [DisplayName("Dep Opening"), Size(18), Scale(2)]
        public Decimal? DepOpening
        {
            get { return Fields.DepOpening[this]; }
            set { Fields.DepOpening[this] = value; }
        }

        [DisplayName("Dep Charge"), Size(18), Scale(2)]
        public Decimal? DepCharge
        {
            get { return Fields.DepCharge[this]; }
            set { Fields.DepCharge[this] = value; }
        }

        [DisplayName("Dep Adjustment"), Size(18), Scale(2)]
        public Decimal? DepAdjustment
        {
            get { return Fields.DepAdjustment[this]; }
            set { Fields.DepAdjustment[this] = value; }
        }

        [DisplayName("Dep Closing"), Size(18), Scale(2)]
        public Decimal? DepClosing
        {
            get { return Fields.DepClosing[this]; }
            set { Fields.DepClosing[this] = value; }
        }

        [DisplayName("Book Value"), Size(18), Scale(2)]
        public Decimal? BookValue
        {
            get { return Fields.BookValue[this]; }
            set { Fields.BookValue[this] = value; }
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

        [DisplayName("Coa Account Group"), Expression("jCoa.[accountGroup]")]
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



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccFixedAssetRefurbishmentRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field Id;

            public Int32Field CoaId;

            public Int32Field FinancialYearId;

            public DecimalField CostOpening;

            public DecimalField CostAddition;

            public DecimalField CostAdjustment;

            public DecimalField CostClosing;

            public DecimalField DepOpening;

            public DecimalField DepCharge;

            public DecimalField DepAdjustment;

            public DecimalField DepClosing;

            public DecimalField BookValue;



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



            public BooleanField FinancialYearIsActive;

            public BooleanField FinancialYearIsClosed;

            public DateTimeField FinancialYearPeriodEndDate;

            public DateTimeField FinancialYearPeriodStartDate;

            public StringField FinancialYearYearName;

            public Int32Field FinancialYearFundControlInformationId;


		}
    }
}

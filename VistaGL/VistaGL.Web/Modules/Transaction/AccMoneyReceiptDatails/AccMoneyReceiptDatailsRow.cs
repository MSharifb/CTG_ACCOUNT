
namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), TableName("[dbo].[acc_MoneyReceiptDatails]"), DisplayName("Money Receipt Datails"), InstanceName("Money Receipt Datails"), TwoLevelCached]
    [ReadPermission("Transaction:AccMoneyReceipt:Read")]
    [InsertPermission("Transaction:AccMoneyReceipt:Insert")]
    [UpdatePermission("Transaction:AccMoneyReceipt:Update")]
    [DeletePermission("Transaction:AccMoneyReceipt:Delete")]
    [LookupScript("Transaction.AccMoneyReceiptDatails", Permission = "?")]
    public sealed class AccMoneyReceiptDatailsRow : NRow, IIdRow
    {
        [DisplayName("Id"), Identity]
        public Int64? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Money Receipt"), NotNull, ForeignKey("[dbo].[acc_MoneyReceipt]", "Id"), LeftJoin("jMoneyReceipt"), TextualField("MoneyReceiptSerialNo")]
        public Int64? MoneyReceiptId
        {
            get { return Fields.MoneyReceiptId[this]; }
            set { Fields.MoneyReceiptId[this] = value; }
        }

        [DisplayName("Account Head"), Column("COAId"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoa"), TextualField("CoaAccountGroup")]
        public Int32? CoaId
        {
            get { return Fields.CoaId[this]; }
            set { Fields.CoaId[this] = value; }
        }

        [DisplayName("Sub-ledger"), ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jCostCenter"), TextualField("CostCenterCode")]
        [LookupEditor(typeof(AccCostCentreOrInstituteInformationRow), InplaceAdd = true, FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        public Int32? CostCenterId
        {
            get { return Fields.CostCenterId[this]; }
            set { Fields.CostCenterId[this] = value; }
        }

        [DisplayName("Amount"), Size(18), Scale(2),LookupInclude]
        public Decimal? Amount
        {
            get { return Fields.Amount[this]; }
            set { Fields.Amount[this] = value; }
        }
        [DisplayName("Description")]
        public String Description
        {
            get { return Fields.Description[this]; }
            set { Fields.Description[this] = value; }
        }

        [DisplayName("Money Receipt Serial No"), Expression("jMoneyReceipt.[SerialNo]")]
        public String MoneyReceiptSerialNo
        {
            get { return Fields.MoneyReceiptSerialNo[this]; }
            set { Fields.MoneyReceiptSerialNo[this] = value; }
        }

        [DisplayName("Money Receipt Monry Receipt Date"), Expression("jMoneyReceipt.[MonryReceiptDate]")]
        public DateTime? MoneyReceiptMonryReceiptDate
        {
            get { return Fields.MoneyReceiptMonryReceiptDate[this]; }
            set { Fields.MoneyReceiptMonryReceiptDate[this] = value; }
        }

        [DisplayName("Money Receipt Amount"), Expression("jMoneyReceipt.[Amount]")]
        public Decimal? MoneyReceiptAmount
        {
            get { return Fields.MoneyReceiptAmount[this]; }
            set { Fields.MoneyReceiptAmount[this] = value; }
        }

        [DisplayName("Money Receipt Amount In Word"), Expression("jMoneyReceipt.[AmountInWord]")]
        public String MoneyReceiptAmountInWord
        {
            get { return Fields.MoneyReceiptAmountInWord[this]; }
            set { Fields.MoneyReceiptAmountInWord[this] = value; }
        }

        [DisplayName("Money Receipt Narration"), Expression("jMoneyReceipt.[Narration]")]
        public String MoneyReceiptNarration
        {
            get { return Fields.MoneyReceiptNarration[this]; }
            set { Fields.MoneyReceiptNarration[this] = value; }
        }

        [DisplayName("Money Receipt Cheque Receive Register Id"), Expression("jMoneyReceipt.[ChequeReceiveRegisterId]")]
        public Int64? MoneyReceiptChequeReceiveRegisterId
        {
            get { return Fields.MoneyReceiptChequeReceiveRegisterId[this]; }
            set { Fields.MoneyReceiptChequeReceiveRegisterId[this] = value; }
        }

        [DisplayName("Money Receipt Acc Head Bank Id"), Expression("jMoneyReceipt.[AccHeadBankId]")]
        public Int32? MoneyReceiptAccHeadBankId
        {
            get { return Fields.MoneyReceiptAccHeadBankId[this]; }
            set { Fields.MoneyReceiptAccHeadBankId[this] = value; }
        }

        [DisplayName("Money Receipt Is Cancelled"), Expression("jMoneyReceipt.[IsCancelled]")]
        public Boolean? MoneyReceiptIsCancelled
        {
            get { return Fields.MoneyReceiptIsCancelled[this]; }
            set { Fields.MoneyReceiptIsCancelled[this] = value; }
        }

        [DisplayName("Money Receipt Is Used"), Expression("jMoneyReceipt.[IsUsed]")]
        public Boolean? MoneyReceiptIsUsed
        {
            get { return Fields.MoneyReceiptIsUsed[this]; }
            set { Fields.MoneyReceiptIsUsed[this] = value; }
        }

        [DisplayName("Money Receipt Voucher Id"), Expression("jMoneyReceipt.[VoucherId]")]
        public Int64? MoneyReceiptVoucherId
        {
            get { return Fields.MoneyReceiptVoucherId[this]; }
            set { Fields.MoneyReceiptVoucherId[this] = value; }
        }

        [DisplayName("Money Receipt Entity Id"), Expression("jMoneyReceipt.[EntityId]")]
        public Int32? MoneyReceiptEntityId
        {
            get { return Fields.MoneyReceiptEntityId[this]; }
            set { Fields.MoneyReceiptEntityId[this] = value; }
        }

        [DisplayName("Money Receipt Zone Info Id"), Expression("jMoneyReceipt.[ZoneInfoId]")]
        public Int32? MoneyReceiptZoneInfoId
        {
            get { return Fields.MoneyReceiptZoneInfoId[this]; }
            set { Fields.MoneyReceiptZoneInfoId[this] = value; }
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

        [DisplayName("Account Head"), Expression("jCoa.[accountName]"), MinSelectLevel(SelectLevel.List)]
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

        [DisplayName("Subledger Name"), Expression("jCostCenter.[name]"), MinSelectLevel(SelectLevel.List)]
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

        public AccMoneyReceiptDatailsRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {
            public Int64Field Id;
            public Int64Field MoneyReceiptId;
            public Int32Field CoaId;
            public Int32Field CostCenterId;
            public DecimalField Amount;

            public StringField MoneyReceiptSerialNo;
            public DateTimeField MoneyReceiptMonryReceiptDate;
            public DecimalField MoneyReceiptAmount;
            public StringField MoneyReceiptAmountInWord;
            public StringField MoneyReceiptNarration;
            public Int64Field MoneyReceiptChequeReceiveRegisterId;
            public Int32Field MoneyReceiptAccHeadBankId;
            public BooleanField MoneyReceiptIsCancelled;
            public BooleanField MoneyReceiptIsUsed;
            public Int64Field MoneyReceiptVoucherId;
            public Int32Field MoneyReceiptEntityId;
            public Int32Field MoneyReceiptZoneInfoId;

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
            public StringField Description;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Transaction.AccMoneyReceiptDatails";
            }
        }
    }
}

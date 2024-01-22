
namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[acc_ReportTypeCOAMapping]")]
    [DisplayName("Report Type Coa Mapping"), InstanceName("Report Type Coa Mapping")]
    [ReadPermission("Configurations:AccReportTypeCoaMapping:Read")]
    [InsertPermission("Configurations:AccReportTypeCoaMapping:Insert")]
    [UpdatePermission("Configurations:AccReportTypeCoaMapping:Update")]
    [DeletePermission("Configurations:AccReportTypeCoaMapping:Delete")]
    [LookupScript("Configurations.AccReportTypeCoaMapping",Permission = "?")]
    public sealed class AccReportTypeCoaMappingRow : Row, IIdRow
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

        [DisplayName("Coa"), Column("COAId"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoa"), TextualField("CoaAccountGroup")]
        public Int32? CoaId
        {
            get { return Fields.CoaId[this]; }
            set { Fields.CoaId[this] = value; }
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

        [DisplayName("Report Type"), Expression("jGroup.[ReportTypeId]")]
        [LookupEditor(typeof(AccReportTypeRow))]
        public Int32? ReportTypeId
        {
            get { return Fields.ReportTypeId[this]; }
            set { Fields.ReportTypeId[this] = value; }
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

        [DisplayName("Account Head"), Expression("jCoa.[accountName]")]
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



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccReportTypeCoaMappingRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field Id;

            public Int32Field GroupId;

            public Int32Field CoaId;



            public Int32Field GroupParentId;

            public Int32Field ReportTypeId;

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

            public DecimalField OpeningBalance;

        }
    }
}

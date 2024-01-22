using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{

    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("ACCDB"), DisplayName("Chart of Accounts"), InstanceName("Chart of Accounts"), TwoLevelCached]
    [ReadPermission("Configurations:AccChartofAccounts:Read|Configurations:AccChartofAccounts:Group:Read")]
    [InsertPermission("Configurations:AccChartofAccounts:Insert|Configurations:AccChartofAccounts:Group:Insert")]
    [UpdatePermission("Configurations:AccChartofAccounts:Update|Configurations:AccChartofAccounts:Group:Update")]
    [DeletePermission("Configurations:AccChartofAccounts:Delete|Configurations:AccChartofAccounts:Group:Delete")]
    [LookupScript("Configurations.AccChartofAccounts", Permission = "?")]
    public sealed class AccChartofAccountsRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Account Code
        [DisplayName("System Code"), Column("accountCode"), Size(30), LookupInclude]
        public String AccountCode { get { return Fields.AccountCode[this]; } set { Fields.AccountCode[this] = value; } }
        public partial class RowFields { public StringField AccountCode; }
        #endregion AccountCode

        #region User Code
        [DisplayName("Account Code"), Column("UserCode"), NotNull, Size(100), Unique, QuickSearch]
        public String UserCode { get { return Fields.UserCode[this]; } set { Fields.UserCode[this] = value; } }
        public partial class RowFields { public StringField UserCode; }
        #endregion UserCode

        #region Account Code Count
        [DisplayName("Account Code Count"), Column("accountCodeCount"), LookupInclude]
        public Int32? AccountCodeCount { get { return Fields.AccountCodeCount[this]; } set { Fields.AccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field AccountCodeCount; }
        #endregion AccountCodeCount

        #region Account Group
        [DisplayName("Account Group"), Column("accountGroup"), Size(20), NotNull, LookupInclude, QuickSearch(SearchType.Contains)]
        public String AccountGroup { get { return Fields.AccountGroup[this]; } set { Fields.AccountGroup[this] = value; } }
        public partial class RowFields { public StringField AccountGroup; }
        #endregion AccountGroup

        #region Account Name
        [DisplayName("Account Head"), Column("accountName"), Size(100), NotNull, QuickSearch(SearchType.Contains)]
        public String AccountName { get { return Fields.AccountName[this]; } set { Fields.AccountName[this] = value; } }
        public partial class RowFields { public StringField AccountName; }
        #endregion AccountName

        #region Account Name Bangla
        [DisplayName("Account Name Bangla"), Column("accountNameBangla"), Size(200)]
        public String AccountNameBangla { get { return Fields.AccountNameBangla[this]; } set { Fields.AccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField AccountNameBangla; }
        #endregion AccountNameBangla

        #region Coa Mapping
        [DisplayName("COA Mapping"), Column("coaMapping"), Size(255), LookupInclude]
        public String CoaMapping { get { return Fields.CoaMapping[this]; } set { Fields.CoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoaMapping; }
        #endregion CoaMapping

        #region Is Bill Ref
        [DisplayName("Bill Ref.?"), Column("isBillRef"), LookupInclude]
        public Int16? IsBillRef { get { return Fields.IsBillRef[this]; } set { Fields.IsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field IsBillRef; }
        #endregion IsBillRef

        #region Is Budget Head
        [DisplayName("Is Budget Head?"), Column("isBudgetHead"), LookupInclude]
        public Int16? IsBudgetHead { get { return Fields.IsBudgetHead[this]; } set { Fields.IsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field IsBudgetHead; }
        #endregion IsBudgetHead

        #region Is Controlhead
        [DisplayName("Is Control Head?"), Column("isControlhead"), NotNull, LookupInclude]
        public Int16? IsControlhead { get { return Fields.IsControlhead[this]; } set { Fields.IsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field IsControlhead; }
        #endregion IsControlhead

        #region Is Sub Ledger Allocate
        [DisplayName("Sub Ledger Allocation"), Column("isCostCenterAllocate"), LookupInclude]
        public Int16? IsCostCenterAllocate { get { return Fields.IsCostCenterAllocate[this]; } set { Fields.IsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field IsCostCenterAllocate; }
        #endregion IsCostCenterAllocate

        #region Level
        [DisplayName("Level"), Column("level"), NotNull, DefaultValue(0), LookupInclude]
        public Int32? Level { get { return Fields.Level[this]; } set { Fields.Level[this] = value; } }
        public partial class RowFields { public Int32Field Level; }
        #endregion Level

        #region Mailing Address
        [DisplayName("Mailing Address"), Column("mailingAddress"), Size(255)]
        public String MailingAddress { get { return Fields.MailingAddress[this]; } set { Fields.MailingAddress[this] = value; } }
        public partial class RowFields { public StringField MailingAddress; }
        #endregion MailingAddress

        #region Mailing Name
        [DisplayName("Mailing Name"), Column("mailingName"), Size(255)]
        public String MailingName { get { return Fields.MailingName[this]; } set { Fields.MailingName[this] = value; } }
        public partial class RowFields { public StringField MailingName; }
        #endregion MailingName

        #region Remarks
        [DisplayName("Remarks"), Column("remarks"), Size(100)]
        public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
        public partial class RowFields { public StringField Remarks; }
        #endregion Remarks

        #region Tax Id
        [DisplayName("Tax Info./ TIN"), Column("taxID"), Size(255)]
        public String TaxId { get { return Fields.TaxId[this]; } set { Fields.TaxId[this] = value; } }
        public partial class RowFields { public StringField TaxId; }
        #endregion TaxId

        #region Ugc Code
        [DisplayName("Ugc Code"), Column("ugcCode"), Size(5)]
        public String UgcCode { get { return Fields.UgcCode[this]; } set { Fields.UgcCode[this] = value; } }
        public partial class RowFields { public StringField UgcCode; }
        #endregion UgcCode

        #region Fund Control
        [DisplayName("Entity Name"), Column("fundControlId"), ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControl"), TextualField("FundControlCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
        public Int32? FundControlId { get { return Fields.FundControlId[this]; } set { Fields.FundControlId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlId; }
        #endregion FundControlId

        #region Parent Account
        [DisplayName("Parent Head"), Column("parentAccountId"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jParentAccount"), TextualField("ParentAccountAccountCode")]
        //  [LookupEditor(typeof(Configurations.Entities.AccChartofAccountsRow)), LookupInclude]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(AccChartofAccountsRow.IsControlhead), FilterValue = 1), LookupInclude]

        public Int32? ParentAccountId { get { return Fields.ParentAccountId[this]; } set { Fields.ParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field ParentAccountId; }
        #endregion ParentAccountId

        #region Multi Currency
        [DisplayName("Multi Currency"), Column("MultiCurrencyID"), ForeignKey("[dbo].[acc_currency_conversion]", "id"), LeftJoin("jMultiCurrency"), TextualField("MultiCurrencyCurrency")]
        [LookupEditor(typeof(Configurations.Entities.AccCurrencyConversionRow)), LookupInclude]
        public Int32? MultiCurrencyId { get { return Fields.MultiCurrencyId[this]; } set { Fields.MultiCurrencyId[this] = value; } }
        public partial class RowFields { public Int32Field MultiCurrencyId; }

        [DisplayName("MultiCurrencyCurrency"), Expression("jMultiCurrency.Currency")]
        public String MultiCurrencyCurrency { get { return Fields.MultiCurrencyCurrency[this]; } set { Fields.MultiCurrencyCurrency[this] = value; } }
        public partial class RowFields { public StringField MultiCurrencyCurrency; }

        #endregion MultiCurrencyId

        #region Effect Cash Flow
        [DisplayName("Effect Cash Flow")]
        public Int32? EffectCashFlow { get { return Fields.EffectCashFlow[this]; } set { Fields.EffectCashFlow[this] = value; } }
        public partial class RowFields { public Int32Field EffectCashFlow; }
        #endregion EffectCashFlow

        #region NoaAccTypeId
        [DisplayName("COA Mapping2")]
        public Int32? NoaAccTypeId { get { return Fields.NoaAccTypeId[this]; } set { Fields.NoaAccTypeId[this] = value; } }
        public partial class RowFields { public Int32Field NoaAccTypeId; }
        #endregion NoaAccTypeId

        #region Sort Order for Receipt Payment Report
        [DisplayName("Sort Order"), Column("SortOrder"), LookupInclude, DefaultValue(1)]
        public Int32? SortOrder { get { return Fields.SortOrder[this]; } set { Fields.SortOrder[this] = value; } }
        public partial class RowFields { public Int32Field SortOrder; }
        #endregion SortOrder

        #region Show Sum In Receipt-Payment-Report?
        [DisplayName("Show Sum In Receipt-Payment-Report?"), Column("ShowSumInReceiptPaymentReport"), LookupInclude, DefaultValue(false)]
        public Boolean? ShowSumInReceiptPaymentReport { get { return Fields.ShowSumInReceiptPaymentReport[this]; } set { Fields.ShowSumInReceiptPaymentReport[this] = value; } }
        public partial class RowFields { public BooleanField ShowSumInReceiptPaymentReport; }
        #endregion ShowSumInReceiptPaymentReport


        #region Hide Children From This Level?
        [DisplayName("Hide Children From This Level?"), Column("IsHideChildrenFromThisLevel"), LookupInclude, DefaultValue(false)]
        public Boolean? IsHideChildrenFromThisLevel { get { return Fields.IsHideChildrenFromThisLevel[this]; } set { Fields.IsHideChildrenFromThisLevel[this] = value; } }
        public partial class RowFields { public BooleanField IsHideChildrenFromThisLevel; }
        #endregion IsHideChildrenFromThisLevel


        #region Budget Code
        [DisplayName("Budget Code"), Column("BudgetCode"), Size(50)]
        public String BudgetCode { get { return Fields.BudgetCode[this]; } set { Fields.BudgetCode[this] = value; } }
        public partial class RowFields { public StringField BudgetCode; }
        #endregion BudgetCode



        #region Is Balance Sheet Head
        [DisplayName("Is Balance Sheet Head?"), Column("isBalanceSheet"), LookupInclude, DefaultValue(false)]
        public Boolean? IsBalanceSheet { get { return Fields.isBalanceSheet[this]; } set { Fields.isBalanceSheet[this] = value; } }
        public partial class RowFields { public BooleanField isBalanceSheet; }
        #endregion Is Balance Sheet Head

        #region Is Income Expenditure Head
        [DisplayName("Is Income Expenditure?"), Column("isIncomeExpenditure"), LookupInclude, DefaultValue(false)]
        public Boolean? IsIncomeExpenditure { get { return Fields.IsIncomeExpenditure[this]; } set { Fields.IsIncomeExpenditure[this] = value; } }
        public partial class RowFields { public BooleanField IsIncomeExpenditure; }
        #endregion Is Income Expenditure Head

        #region Balance Sheet Notes
        [DisplayName("Notes"), Column("BalanceSheetNotes"), LookupInclude]
        public Int32? BalanceSheetNotes { get { return Fields.BalanceSheetNotes[this]; } set { Fields.BalanceSheetNotes[this] = value; } }
        public partial class RowFields { public Int32Field BalanceSheetNotes; }
        #endregion Balance Sheet Notes

        #region Income Expenditure Notes
        [DisplayName("Notes"), Column("IncomeExpenditureNotes"), LookupInclude]
        public Int32? IncomeExpenditureNotes { get { return Fields.IncomeExpenditureNotes[this]; } set { Fields.IncomeExpenditureNotes[this] = value; } }
        public partial class RowFields { public Int32Field IncomeExpenditureNotes; }
        #endregion Income Expenditure Notes

        #region Sort Order
        [DisplayName("Budget Group")]
        [LookupEditor("Configurations.AccBudgetGroup"), LookupInclude]
        public Int32? BudgetGroupId { get { return Fields.BudgetGroupId[this]; } set { Fields.BudgetGroupId[this] = value; } }
        public partial class RowFields { public Int32Field BudgetGroupId; }
        #endregion SortOrder

        #region Foreign Fields

        [DisplayName("Fund Control Code"), Expression("jFundControl.[code]")]
        public String FundControlCode { get { return Fields.FundControlCode[this]; } set { Fields.FundControlCode[this] = value; } }
        public partial class RowFields { public StringField FundControlCode; }

        [DisplayName("Fund Control Fund Control Name"), Expression("jFundControl.[fundControlName]")]
        public String FundControlFundControlName { get { return Fields.FundControlFundControlName[this]; } set { Fields.FundControlFundControlName[this] = value; } }
        public partial class RowFields { public StringField FundControlFundControlName; }

        [DisplayName("Fund Control Remarks"), Expression("jFundControl.[remarks]")]
        public String FundControlRemarks { get { return Fields.FundControlRemarks[this]; } set { Fields.FundControlRemarks[this] = value; } }
        public partial class RowFields { public StringField FundControlRemarks; }


        [DisplayName("Parent Account Account Code"), Expression("jParentAccount.[accountCode]")]
        [MinSelectLevel(SelectLevel.List)]
        public String ParentAccountAccountCode { get { return Fields.ParentAccountAccountCode[this]; } set { Fields.ParentAccountAccountCode[this] = value; } }
        public partial class RowFields { public StringField ParentAccountAccountCode; }


        [DisplayName("Parent Account Account Code Count"), Expression("jParentAccount.[accountCodeCount]")]
        public Int32? ParentAccountAccountCodeCount { get { return Fields.ParentAccountAccountCodeCount[this]; } set { Fields.ParentAccountAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field ParentAccountAccountCodeCount; }


        [DisplayName("Parent Account Account Group"), Expression("jParentAccount.[accountGroup]")]
        public String ParentAccountAccountGroup { get { return Fields.ParentAccountAccountGroup[this]; } set { Fields.ParentAccountAccountGroup[this] = value; } }
        public partial class RowFields { public StringField ParentAccountAccountGroup; }


        [DisplayName("Parent Head"), Expression("jParentAccount.[accountName]"), QuickSearch()]
        [MinSelectLevel(SelectLevel.List)]
        public String ParentAccountAccountName { get { return Fields.ParentAccountAccountName[this]; } set { Fields.ParentAccountAccountName[this] = value; } }
        public partial class RowFields { public StringField ParentAccountAccountName; }


        [DisplayName("Parent Account Account Name Bangla"), Expression("jParentAccount.[accountNameBangla]")]
        public String ParentAccountAccountNameBangla { get { return Fields.ParentAccountAccountNameBangla[this]; } set { Fields.ParentAccountAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField ParentAccountAccountNameBangla; }


        [DisplayName("Parent Account Coa Mapping"), Expression("jParentAccount.[coaMapping]")]
        public String ParentAccountCoaMapping { get { return Fields.ParentAccountCoaMapping[this]; } set { Fields.ParentAccountCoaMapping[this] = value; } }
        public partial class RowFields { public StringField ParentAccountCoaMapping; }


        [DisplayName("Parent Account Is Budget Head"), Expression("jParentAccount.[isBudgetHead]")]
        public Int16? ParentAccountIsBudgetHead { get { return Fields.ParentAccountIsBudgetHead[this]; } set { Fields.ParentAccountIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field ParentAccountIsBudgetHead; }


        [DisplayName("Parent Account Is Controlhead"), Expression("jParentAccount.[isControlhead]")]
        public Int16? ParentAccountIsControlhead { get { return Fields.ParentAccountIsControlhead[this]; } set { Fields.ParentAccountIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field ParentAccountIsControlhead; }


        [DisplayName("Parent Account Is Sub Ledger Allocate"), Expression("jParentAccount.[isCostCenterAllocate]")]
        public Int16? ParentAccountIsCostCenterAllocate { get { return Fields.ParentAccountIsCostCenterAllocate[this]; } set { Fields.ParentAccountIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field ParentAccountIsCostCenterAllocate; }


        [DisplayName("Parent Account Level"), Expression("jParentAccount.[level]")]
        public Int32? ParentAccountLevel { get { return Fields.ParentAccountLevel[this]; } set { Fields.ParentAccountLevel[this] = value; } }
        public partial class RowFields { public Int32Field ParentAccountLevel; }


        [DisplayName("Parent Account Opening Balance"), Expression("jParentAccount.[openingBalance]")]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public Decimal? ParentAccountOpeningBalance { get { return Fields.ParentAccountOpeningBalance[this]; } set { Fields.ParentAccountOpeningBalance[this] = value; } }
        public partial class RowFields { public DecimalField ParentAccountOpeningBalance; }


        [DisplayName("Parent Account Remarks"), Expression("jParentAccount.[remarks]")]
        public String ParentAccountRemarks { get { return Fields.ParentAccountRemarks[this]; } set { Fields.ParentAccountRemarks[this] = value; } }
        public partial class RowFields { public StringField ParentAccountRemarks; }


        [DisplayName("Parent Account Fund Control Id"), Expression("jParentAccount.[fundControlId]")]
        public Int32? ParentAccountFundControlId { get { return Fields.ParentAccountFundControlId[this]; } set { Fields.ParentAccountFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field ParentAccountFundControlId; }


        [DisplayName("Parent Account Parent Account Id"), Expression("jParentAccount.[parentAccountId]")]
        public Int32? ParentAccountParentAccountId { get { return Fields.ParentAccountParentAccountId[this]; } set { Fields.ParentAccountParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field ParentAccountParentAccountId; }

        [DisplayName("AccOpeningBalance Id"), NotMapped]
        public Int32? AccOpeningBalanceId { get { return Fields.AccOpeningBalanceId[this]; } set { Fields.AccOpeningBalanceId[this] = value; } }
        public partial class RowFields { public Int32Field AccOpeningBalanceId; }

        #region Opening Balance
        [DisplayName("Opening Balance"), Column("openingBalance")]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public Decimal? OpeningBalance { get { return Fields.OpeningBalance[this]; } set { Fields.OpeningBalance[this] = value; } }
        public partial class RowFields { public DecimalField OpeningBalance; }
        #endregion OpeningBalance

        [DisplayName("Opening Balance"), NotMapped]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public Decimal? AccOpeningBalance { get { return Fields.AccOpeningBalance[this]; } set { Fields.AccOpeningBalance[this] = value; } }
        public partial class RowFields { public DecimalField AccOpeningBalance; }

        [DisplayName("iSCoA Used"), NotMapped]
        public Int32? iSCoAUsed { get { return Fields.iSCoAUsed[this]; } set { Fields.iSCoAUsed[this] = value; } }
        public partial class RowFields { public Int32Field iSCoAUsed; }

        [NotMapped]
        public Int32? NoaAccTypeId2 { get { return Fields.NoaAccTypeId2[this]; } set { Fields.NoaAccTypeId2[this] = value; } }
        public partial class RowFields { public Int32Field NoaAccTypeId2; }

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.AccountName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccChartofAccountsRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_ChartofAccounts]")
            {
                LocalTextPrefix = "Configurations.AccChartofAccounts";
            }
        }
        #endregion RowFields
    }

}


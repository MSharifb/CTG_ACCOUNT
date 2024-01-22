
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;
    using Transaction.Entities;

    [FormScript("Configurations.AccChartofAccounts")]
    [BasedOnRow(typeof(Entities.AccChartofAccountsRow))]
    public class AccChartofAccountsForm
    {
        [Tab("Main")]
        [Category("Properties")]

        [ReadOnly(true)]
        public Int32 FundControlId { get; set; }

        //   public Int32 AccountCodeCount { get; set; }

        public String AccountName { get; set; }

        public String UserCode { get; set; }

        public Int32 ParentAccountId { get; set; }

        [CssClass("width6"), ReadOnly(true)]
        public String AccountCode { get; set; }

        [CssClass("width6"), ReadOnly(true)]
        public Int32 Level { get; set; }

        [Hidden()]
        public Int32 AccountCodeCount { get; set; }

        //  public Double OpeningBalance { get; set; }

        [CssClass("width6"), ReadOnly(true)]
        public String AccountGroup { get; set; }

        [CssClass("width6")]
        public Decimal? AccOpeningBalance { get; set; }

        [Hidden()]
        public Int32 AccOpeningBalanceId { get; set; }

        [CssClass("width6")]
        public Int32 MultiCurrencyId { get; set; }
        [CssClass("width6")]
        public EffectinCashFlow EffectCashFlow { get; set; }

        //  public String AccountNameBangla { get; set; }

        [CssClass("width6"), COAMappingEditor]
        public String CoaMapping { get; set; }

        [CssClass("width6")]
        public String TaxId { get; set; }

        //public String MailingName { get; set; }

        //[TextAreaEditor(Rows = 2)]
        //public String MailingAddress { get; set; }

        [CssClass("width6"), DefaultValue(true)]
        public Boolean IsCostCenterAllocate { get; set; }

        [CssClass("width6")]
        public Boolean IsBillRef { get; set; }

        [CssClass("width6")]
        public Boolean IsControlhead { get; set; }

        [CssClass("width6")]
        [AccHeadTypeMappingEditor]
        public Int32? NoaAccTypeId { get; set; }

        public String Remarks { get; set; }

        [CssClass("width6"), Visible(false)]
        public Int32? NoaAccTypeId2 { get; set; }

        //public Int32 Level { get; set; }

        [Tab("Budget Sett.")]
        [Category("Settings for Budget")]

        [CssClass("width6")]
        public Boolean IsBudgetHead { get; set; }
        [CssClass("width6")]
        public String BudgetCode { get; set; }

        public Int32 BudgetGroupId { get; set; }


        // --
        [Tab("Receipt/Payment Report Sett.")]
        [Category("Settings for Receipt/Payment Report")]

        [CssClass("width12")]
        public Int32? SortOrder { get; set; }

        [CssClass("width12")]
        public Boolean ShowSumInReceiptPaymentReport { get; set; }

        [CssClass("width12")]
        public Boolean IsHideChildrenFromThisLevel { get; set; }

        // --
        [Tab("Balance Sheet Sett.")]
        [Category("Setting for Balance Sheet")]

        [CssClass("width6")]
        public Boolean IsBalanceSheet { get; set; }

        [CssClass("width6")]
        public Int32 BalanceSheetNotes { get; set; }

        //
        [Tab("Income Expenditure Sett.")]
        [Category("Setting for Income Expenditure")]

        [CssClass("width6")]
        public Boolean IsIncomeExpenditure { get; set; }
        [CssClass("width6")]
        public Int32 IncomeExpenditureNotes { get; set; }


        //
        //[Tab("Migration")]

        //[Category("Migrate From:-")]
        //[LookupEditor(typeof(Repositories.DemoACINFLookup))]
        //[DisplayName("Acc. Head of Old System")]
        //public String demoCOA_OldSystem { get; set; }

        //[Category("Migrate To:-")]
        //[LookupEditor(typeof(Repositories.AccChartofAccountWithUserCodeLookup))]
        //[DisplayName("Acc. Head of ERP System")]
        //public Int32? demoCOA_ERPSystem { get; set; }

        //[LookupEditor(typeof(AccCostCentreOrInstituteInformationRow), FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        //[DisplayName("")]
        //public Int32? demoCostCenter_ERPSystem { get; set; }

        //[Category("")]
        //[LookupEditor(typeof(Transaction.Repositories.DemoSTPINFLookup))]
        //[DisplayName("Sub-Ledger of Old System")]
        //public String demoCostCenter_OLDSystem { get; set; }

    }
}
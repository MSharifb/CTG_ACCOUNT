using VistaGL.Modules.Common;

namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Voucher Details"), InstanceName("Voucher Details"), TwoLevelCached]
    //[ReadPermission("Transaction:acc_voucher_details:Read")]
    //[InsertPermission("Transaction:acc_voucher_details:Insert")]
    //[UpdatePermission("Transaction:acc_voucher_details:Update")]
    //[DeletePermission("Transaction:acc_voucher_details:Delete")]
    [LookupScript("Transaction.AccVoucherDetails", Permission = "?")]
    public sealed class AccVoucherDetailsRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int64? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int64Field Id; }
        #endregion Id

        #region Credit Amount
        [DisplayName("Credit Amount"), Column("creditAmount"), DefaultValue(0)]
        public Decimal? CreditAmount { get { return Fields.CreditAmount[this]; } set { Fields.CreditAmount[this] = value; } }
        public partial class RowFields { public DecimalField CreditAmount; }
        #endregion CreditAmount

        #region Debit Amount
        [DisplayName("Debit Amount"), Column("debitAmount"), DefaultValue(0)]
        public Decimal? DebitAmount { get { return Fields.DebitAmount[this]; } set { Fields.DebitAmount[this] = value; } }
        public partial class RowFields { public DecimalField DebitAmount; }
        #endregion DebitAmount

        #region Description
        [DisplayName("Description"), Column("description"), Size(100), QuickSearch]
        public String Description { get { return Fields.Description[this]; } set { Fields.Description[this] = value; } }
        public partial class RowFields { public StringField Description; }
        #endregion Description

        #region Is Payor Receive Head
        [DisplayName("Is Payor Receive Head"), Column("isPayorReceiveHead")]
        public Int16? IsPayorReceiveHead { get { return Fields.IsPayorReceiveHead[this]; } set { Fields.IsPayorReceiveHead[this] = value; } }
        public partial class RowFields { public Int16Field IsPayorReceiveHead; }
        #endregion IsPayorReceiveHead

        [DisplayName("Payment Voucher Head"), NotMapped, DefaultValue(false)]
        public Boolean? PaymentVoucherHead { get { return Fields.PaymentVoucherHead[this]; } set { Fields.PaymentVoucherHead[this] = value; } }
        public partial class RowFields { public BooleanField PaymentVoucherHead; }

        #region Mid
        [DisplayName("Mid"), Column("mid")]
        public Int32? Mid { get { return Fields.Mid[this]; } set { Fields.Mid[this] = value; } }
        public partial class RowFields { public Int32Field Mid; }
        #endregion Mid

        #region Chartof Accounts
        [DisplayName("Chart of Accounts"), Column("chartofAccountsId"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), InnerJoin("jChartofAccounts"), TextualField("ChartofAccountsAccountCode")]
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32? ChartofAccountsId { get { return Fields.ChartofAccountsId[this]; } set { Fields.ChartofAccountsId[this] = value; } }
        public partial class RowFields { public Int32Field ChartofAccountsId; }
        #endregion ChartofAccountsId

        #region Voucher Information
        [DisplayName("Voucher Information"), Column("voucherInformationId"), NotNull, ForeignKey("[dbo].[acc_voucher_information]", "id"), InnerJoin("jVoucherInformation"), TextualField("VoucherInformationAmountInWords")]
        [LookupEditor(typeof(Transaction.Repositories.AccVoucherInformationRowLookup))]
        public Int64? VoucherInformationId { get { return Fields.VoucherInformationId[this]; } set { Fields.VoucherInformationId[this] = value; } }
        public partial class RowFields { public Int64Field VoucherInformationId; }
        #endregion VoucherInformationId

        #region Sub Ledger Allocation
        [DisplayName("Sub Ledger Allocation"),
            MasterDetailRelation(foreignKey: "VoucherDetailId"), NotMapped,
            MinSelectLevel(SelectLevel.Auto)]
        public List<AccVoucherDtlAllocationRow> VoucherDtlAllocation
        {
            get { return Fields.VoucherDtlAllocation[this]; }
            set { Fields.VoucherDtlAllocation[this] = value; }
        }
        public partial class RowFields { public RowListField<AccVoucherDtlAllocationRow> VoucherDtlAllocation; }
        #endregion

        #region Bill Ref. Information
        [DisplayName("Bill Ref. Information"),
            MasterDetailRelation(foreignKey: "VoucherDetailId"), NotMapped,
            MinSelectLevel(SelectLevel.Auto)]
        public List<AccVoucherDtlBillRefRow> VoucherDtlBillRef
        {
            get { return Fields.VoucherDtlBillRef[this]; }
            set { Fields.VoucherDtlBillRef[this] = value; }
        }
        public partial class RowFields { public RowListField<AccVoucherDtlBillRefRow> VoucherDtlBillRef; }
        #endregion

        #region Conversion Rate
        [DisplayName("Conversion Rate"), Column("ConversionRate")]
        public Decimal? ConversionRate { get { return Fields.ConversionRate[this]; } set { Fields.ConversionRate[this] = value; } }
        public partial class RowFields { public DecimalField ConversionRate; }
        #endregion ConversionRate

        #region Conversion Amount
        [DisplayName("Conversion Amount"), Column("ConversionAmount"), QuickSearch]
        public Decimal? ConversionAmount { get { return Fields.ConversionAmount[this]; } set { Fields.ConversionAmount[this] = value; } }
        public partial class RowFields { public DecimalField ConversionAmount; }
        #endregion ConversionRate

        #region Effective Value
        [DisplayName("Effective Value"), Column("EffectiveValue")]
        public Decimal? EffectiveValue { get { return Fields.EffectiveValue[this]; } set { Fields.EffectiveValue[this] = value; } }
        public partial class RowFields { public DecimalField EffectiveValue; }
        #endregion ConversionRate

        #region Credit Amount
        [DisplayName("Credit Amount"), Column("ccreditAmount"), DefaultValue(0)]
        public Decimal? CCreditAmount { get { return Fields.CCreditAmount[this]; } set { Fields.CCreditAmount[this] = value; } }
        public partial class RowFields { public DecimalField CCreditAmount; }
        #endregion CreditAmount

        #region Debit Amount
        [DisplayName("Debit Amount"), Column("cdebitAmount"), DefaultValue(0)]
        public Decimal? CDebitAmount { get { return Fields.CDebitAmount[this]; } set { Fields.CDebitAmount[this] = value; } }
        public partial class RowFields { public DecimalField CDebitAmount; }
        #endregion DebitAmount

        #region Bank Account Information
        [DisplayName("Bank Account"), Column("bankAccountInformationId"), ForeignKey("[dbo].[acc_BankAccountInformation]", "id"), InnerJoin("jBankAccountInformation"), TextualField("BankAccountInformationAccountDescription")]
        [LookupEditor(typeof(Configurations.Entities.AccBankAccountInformationRow))]
        public Int32? BankAccountInformationId { get { return Fields.BankAccountInformationId[this]; } set { Fields.BankAccountInformationId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationId; }
        #endregion BankAccountInformationId

        #region Cheque Register
        [DisplayName("Cheque Register"), Column("chequeRegisterId")]//, ForeignKey("[dbo].[acc_ChequeRegister]", "id"), LeftJoin("jChequeRegister"), TextualField("ChequeRegisterAmountInWords")]
        [LookupEditor("Transaction.AccChequeRegister_Lookup"), LookupInclude, MinSelectLevel(SelectLevel.List)]
        public Int64? ChequeRegisterId { get { return Fields.ChequeRegisterId[this]; } set { Fields.ChequeRegisterId[this] = value; } }
        public partial class RowFields { public Int64Field ChequeRegisterId; }
        #endregion ChequeRegisterId

        #region ClearDate
        [DisplayName("Clear Date"), Column("clearDate")]
        public DateTime? ClearDate { get { return Fields.ClearDate[this]; } set { Fields.ClearDate[this] = value; } }
        public partial class RowFields { public DateTimeField ClearDate; }
        #endregion ClearDate

        #region IsClearDate
        [DisplayName("Reconciliation Status"), Column("IsclearDate")]
        [Expression("( ISNULL(IsClearDate,0) )")]
        public Int32? IsClearDate { get { return Fields.IsClearDate[this]; } set { Fields.IsClearDate[this] = value; } }
        public partial class RowFields { public Int32Field IsClearDate; }
        #endregion IsClearDate

        #region Calculation Amount
        [DisplayName("Calculation Amount"), Column("calculationAmount")]
        public Decimal? CalculationAmount { get { return Fields.CalculationAmount[this]; } set { Fields.CalculationAmount[this] = value; } }
        public partial class RowFields { public DecimalField CalculationAmount; }
        #endregion Calculation Amount

        #region Calculation Rate

        [DisplayName("Calculation Rate"), Column("calculationRate")]
        public Decimal? CalculationRate { get { return Fields.CalculationRate[this]; } set { Fields.CalculationRate[this] = value; } }
        public partial class RowFields { public DecimalField CalculationRate; }

        #endregion Calculation Rate

        #region Is Bank Account Head
        [Column("IsAccountHeadBankCash"), DefaultValue(false)]
        public Boolean? IsAccountHeadBankCash { get { return Fields.IsAccountHeadBankCash[this]; } set { Fields.IsAccountHeadBankCash[this] = value; } }
        public partial class RowFields { public BooleanField IsAccountHeadBankCash; }
        #endregion IsAccountHeadBankCash

        #region Linked Journal Voucher Detail
        [Column("LinkedJVDetailId"), ForeignKey("[dbo].[acc_voucher_details]", "id"), InnerJoin("jVoucherDetail"), TextualField("LinkedJournalVoucherDetail"), LookupInclude]
        public Int64? LinkedJVDetailId { get { return Fields.LinkedJVDetailId[this]; } set { Fields.LinkedJVDetailId[this] = value; } }
        public partial class RowFields { public Int64Field LinkedJVDetailId; }
        #endregion LinkedPVDetailId

        #region Adjusted Voucher Id
        [Column("AdjustedChequeRegisterId"), ForeignKey("[dbo].[acc_ChequeRegister]", "id"), InnerJoin("jAdjustedVoucher"), TextualField("AdjustedVoucher"), LookupInclude]
        [DisplayName("Adjusted with")]
        public Int64? AdjustedChequeRegisterId { get { return Fields.AdjustedChequeRegisterId[this]; } set { Fields.AdjustedChequeRegisterId[this] = value; } }
        public partial class RowFields { public Int64Field AdjustedChequeRegisterId; }
        #endregion Adjusted Voucher Id


        #region Foreign Fields

        #region jChartofAccount

        //[DisplayName("Chartof Accounts Account Code"), Expression("jChartofAccounts.[accountCode]")]
        //public String ChartofAccountsAccountCode { get { return Fields.ChartofAccountsAccountCode[this]; } set { Fields.ChartofAccountsAccountCode[this] = value; } }
        //public partial class RowFields { public StringField ChartofAccountsAccountCode; }

        [DisplayName("User Code"), Expression("jChartofAccounts.[UserCode]")]
        [MinSelectLevel(SelectLevel.List)]
        public String ChartofAccountsUserCode { get { return Fields.ChartofAccountsUserCode[this]; } set { Fields.ChartofAccountsUserCode[this] = value; } }
        public partial class RowFields { public StringField ChartofAccountsUserCode; }

        //[DisplayName("Chartof Accounts Account Code Count"), Expression("jChartofAccounts.[accountCodeCount]")]
        //public Int32? ChartofAccountsAccountCodeCount { get { return Fields.ChartofAccountsAccountCodeCount[this]; } set { Fields.ChartofAccountsAccountCodeCount[this] = value; } }
        //public partial class RowFields { public Int32Field ChartofAccountsAccountCodeCount; }


        //[DisplayName("Chartof Accounts Account Group"), Expression("jChartofAccounts.[accountGroup]")]
        //public String ChartofAccountsAccountGroup { get { return Fields.ChartofAccountsAccountGroup[this]; } set { Fields.ChartofAccountsAccountGroup[this] = value; } }
        //public partial class RowFields { public StringField ChartofAccountsAccountGroup; }


        [DisplayName("Chart of Accounts"), Expression("jChartofAccounts.[accountName]")]
        [MinSelectLevel(SelectLevel.List)]
        public String ChartofAccountsAccountName { get { return Fields.ChartofAccountsAccountName[this]; } set { Fields.ChartofAccountsAccountName[this] = value; } }
        public partial class RowFields { public StringField ChartofAccountsAccountName; }


        //[DisplayName("Chartof Accounts Account Name Bangla"), Expression("jChartofAccounts.[accountNameBangla]")]
        //public String ChartofAccountsAccountNameBangla { get { return Fields.ChartofAccountsAccountNameBangla[this]; } set { Fields.ChartofAccountsAccountNameBangla[this] = value; } }
        //public partial class RowFields { public StringField ChartofAccountsAccountNameBangla; }


        [DisplayName("Chartof Accounts Coa Mapping"), Expression("jChartofAccounts.[coaMapping]")]
        [MinSelectLevel(SelectLevel.List)]
        public String ChartofAccountsCoaMapping { get { return Fields.ChartofAccountsCoaMapping[this]; } set { Fields.ChartofAccountsCoaMapping[this] = value; } }
        public partial class RowFields { public StringField ChartofAccountsCoaMapping; }


        //[DisplayName("Chartof Accounts Is Bill Ref"), Expression("jChartofAccounts.[isBillRef]")]
        //public Int16? ChartofAccountsIsBillRef { get { return Fields.ChartofAccountsIsBillRef[this]; } set { Fields.ChartofAccountsIsBillRef[this] = value; } }
        //public partial class RowFields { public Int16Field ChartofAccountsIsBillRef; }


        //[DisplayName("Chartof Accounts Is Budget Head"), Expression("jChartofAccounts.[isBudgetHead]")]
        //public Int16? ChartofAccountsIsBudgetHead { get { return Fields.ChartofAccountsIsBudgetHead[this]; } set { Fields.ChartofAccountsIsBudgetHead[this] = value; } }
        //public partial class RowFields { public Int16Field ChartofAccountsIsBudgetHead; }


        //[DisplayName("Chartof Accounts Is Controlhead"), Expression("jChartofAccounts.[isControlhead]")]
        //public Int16? ChartofAccountsIsControlhead { get { return Fields.ChartofAccountsIsControlhead[this]; } set { Fields.ChartofAccountsIsControlhead[this] = value; } }
        //public partial class RowFields { public Int16Field ChartofAccountsIsControlhead; }


        //[DisplayName("Chartof Accounts Is Sub Ledger Allocate"), Expression("jChartofAccounts.[isCostCenterAllocate]")]
        //public Int16? ChartofAccountsIsCostCenterAllocate { get { return Fields.ChartofAccountsIsCostCenterAllocate[this]; } set { Fields.ChartofAccountsIsCostCenterAllocate[this] = value; } }
        //public partial class RowFields { public Int16Field ChartofAccountsIsCostCenterAllocate; }


        //[DisplayName("Chartof Accounts Level"), Expression("jChartofAccounts.[level]")]
        //public Int32? ChartofAccountsLevel { get { return Fields.ChartofAccountsLevel[this]; } set { Fields.ChartofAccountsLevel[this] = value; } }
        //public partial class RowFields { public Int32Field ChartofAccountsLevel; }


        //[DisplayName("Chartof Accounts Mailing Address"), Expression("jChartofAccounts.[mailingAddress]")]
        //public String ChartofAccountsMailingAddress { get { return Fields.ChartofAccountsMailingAddress[this]; } set { Fields.ChartofAccountsMailingAddress[this] = value; } }
        //public partial class RowFields { public StringField ChartofAccountsMailingAddress; }


        //[DisplayName("Chartof Accounts Mailing Name"), Expression("jChartofAccounts.[mailingName]")]
        //public String ChartofAccountsMailingName { get { return Fields.ChartofAccountsMailingName[this]; } set { Fields.ChartofAccountsMailingName[this] = value; } }
        //public partial class RowFields { public StringField ChartofAccountsMailingName; }


        //[DisplayName("Chartof Accounts Opening Balance"), Expression("jChartofAccounts.[openingBalance]")]
        //public Decimal? ChartofAccountsOpeningBalance { get { return Fields.ChartofAccountsOpeningBalance[this]; } set { Fields.ChartofAccountsOpeningBalance[this] = value; } }
        //public partial class RowFields { public DecimalField ChartofAccountsOpeningBalance; }


        //[DisplayName("Chartof Accounts Remarks"), Expression("jChartofAccounts.[remarks]")]
        //public String ChartofAccountsRemarks { get { return Fields.ChartofAccountsRemarks[this]; } set { Fields.ChartofAccountsRemarks[this] = value; } }
        //public partial class RowFields { public StringField ChartofAccountsRemarks; }


        //[DisplayName("Chartof Accounts Tax Id"), Expression("jChartofAccounts.[taxID]")]
        //public String ChartofAccountsTaxId { get { return Fields.ChartofAccountsTaxId[this]; } set { Fields.ChartofAccountsTaxId[this] = value; } }
        //public partial class RowFields { public StringField ChartofAccountsTaxId; }


        //[DisplayName("Chartof Accounts Ugc Code"), Expression("jChartofAccounts.[ugcCode]")]
        //public String ChartofAccountsUgcCode { get { return Fields.ChartofAccountsUgcCode[this]; } set { Fields.ChartofAccountsUgcCode[this] = value; } }
        //public partial class RowFields { public StringField ChartofAccountsUgcCode; }


        [DisplayName("Chartof Accounts Fund Control Id"), Expression("jChartofAccounts.[fundControlId]")]
        public Int32? ChartofAccountsFundControlId { get { return Fields.ChartofAccountsFundControlId[this]; } set { Fields.ChartofAccountsFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field ChartofAccountsFundControlId; }


        //[DisplayName("Chartof Accounts Parent Account Id"), Expression("jChartofAccounts.[parentAccountId]")]
        //public Int32? ChartofAccountsParentAccountId { get { return Fields.ChartofAccountsParentAccountId[this]; } set { Fields.ChartofAccountsParentAccountId[this] = value; } }
        //public partial class RowFields { public Int32Field ChartofAccountsParentAccountId; }

        #endregion

        #region jVoucherInformation

        [DisplayName("Voucher Information Amount"), Expression("jVoucherInformation.[amount]")]
        public Decimal? VoucherInformationAmount { get { return Fields.VoucherInformationAmount[this]; } set { Fields.VoucherInformationAmount[this] = value; } }
        public partial class RowFields { public DecimalField VoucherInformationAmount; }


        [DisplayName("Voucher Information Amount In Words"), Expression("jVoucherInformation.[amountInWords]")]
        public String VoucherInformationAmountInWords { get { return Fields.VoucherInformationAmountInWords[this]; } set { Fields.VoucherInformationAmountInWords[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationAmountInWords; }


        [DisplayName("Voucher Information Clear Date"), Expression("jVoucherInformation.[clearDate]")]
        public DateTime? VoucherInformationClearDate { get { return Fields.VoucherInformationClearDate[this]; } set { Fields.VoucherInformationClearDate[this] = value; } }
        public partial class RowFields { public DateTimeField VoucherInformationClearDate; }


        [DisplayName("Voucher Information Description"), Expression("jVoucherInformation.[description]")]
        public String VoucherInformationDescription { get { return Fields.VoucherInformationDescription[this]; } set { Fields.VoucherInformationDescription[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationDescription; }



        [DisplayName("Voucher Information Head Description"), Expression("jVoucherInformation.[headDescription]")]
        public String VoucherInformationHeadDescription { get { return Fields.VoucherInformationHeadDescription[this]; } set { Fields.VoucherInformationHeadDescription[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationHeadDescription; }


        [DisplayName("Voucher Information Is Approved"), Expression("jVoucherInformation.[isApproved]")]
        public Int16? VoucherInformationIsApproved { get { return Fields.VoucherInformationIsApproved[this]; } set { Fields.VoucherInformationIsApproved[this] = value; } }
        public partial class RowFields { public Int16Field VoucherInformationIsApproved; }


        [DisplayName("Voucher Information Is Auto"), Expression("jVoucherInformation.[isAuto]")]
        public Int16? VoucherInformationIsAuto { get { return Fields.VoucherInformationIsAuto[this]; } set { Fields.VoucherInformationIsAuto[this] = value; } }
        public partial class RowFields { public Int16Field VoucherInformationIsAuto; }


        [DisplayName("Voucher Information Is Bank Reconcile"), Expression("jVoucherInformation.[isBankReconcile]")]
        public Int16? VoucherInformationIsBankReconcile { get { return Fields.VoucherInformationIsBankReconcile[this]; } set { Fields.VoucherInformationIsBankReconcile[this] = value; } }
        public partial class RowFields { public Int16Field VoucherInformationIsBankReconcile; }



        [DisplayName("Voucher Information Is Submitted"), Expression("jVoucherInformation.[isSubmitted]")]
        public Int16? VoucherInformationIsSubmitted { get { return Fields.VoucherInformationIsSubmitted[this]; } set { Fields.VoucherInformationIsSubmitted[this] = value; } }
        public partial class RowFields { public Int16Field VoucherInformationIsSubmitted; }



        [DisplayName("Voucher Information Payment Amount"), Expression("jVoucherInformation.[paymentAmount]")]
        public Decimal? VoucherInformationPaymentAmount { get { return Fields.VoucherInformationPaymentAmount[this]; } set { Fields.VoucherInformationPaymentAmount[this] = value; } }
        public partial class RowFields { public DecimalField VoucherInformationPaymentAmount; }


        [DisplayName("Voucher Information Payto Or Recive From"), Expression("jVoucherInformation.[paytoOrReciveFrom]")]
        public String VoucherInformationPaytoOrReciveFrom { get { return Fields.VoucherInformationPaytoOrReciveFrom[this]; } set { Fields.VoucherInformationPaytoOrReciveFrom[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationPaytoOrReciveFrom; }


        [DisplayName("Voucher Information Post To Ledger"), Expression("jVoucherInformation.[postToLedger]")]
        public Int16? VoucherInformationPostToLedger { get { return Fields.VoucherInformationPostToLedger[this]; } set { Fields.VoucherInformationPostToLedger[this] = value; } }
        public partial class RowFields { public Int16Field VoucherInformationPostToLedger; }


        [DisplayName("Voucher Information Posted By"), Expression("jVoucherInformation.[postedBy]")]
        public String VoucherInformationPostedBy { get { return Fields.VoucherInformationPostedBy[this]; } set { Fields.VoucherInformationPostedBy[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationPostedBy; }


        [DisplayName("Voucher Information Posting Date"), Expression("jVoucherInformation.[postingDate]")]
        public DateTime? VoucherInformationPostingDate { get { return Fields.VoucherInformationPostingDate[this]; } set { Fields.VoucherInformationPostingDate[this] = value; } }
        public partial class RowFields { public DateTimeField VoucherInformationPostingDate; }


        [DisplayName("Voucher Information Posting Number"), Expression("jVoucherInformation.[postingNumber]")]
        public String VoucherInformationPostingNumber { get { return Fields.VoucherInformationPostingNumber[this]; } set { Fields.VoucherInformationPostingNumber[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationPostingNumber; }


        [DisplayName("Voucher Information Prepared By"), Expression("jVoucherInformation.[preparedBy]")]
        public String VoucherInformationPreparedBy { get { return Fields.VoucherInformationPreparedBy[this]; } set { Fields.VoucherInformationPreparedBy[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationPreparedBy; }

        [DisplayName("Voucher Information Transaction Mode"), Expression("jVoucherInformation.[transactionMode]")]
        public String VoucherInformationTransactionMode { get { return Fields.VoucherInformationTransactionMode[this]; } set { Fields.VoucherInformationTransactionMode[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationTransactionMode; }


        [DisplayName("Voucher Information Transaction Type"), Expression("jVoucherInformation.[transactionType]")]
        public String VoucherInformationTransactionType { get { return Fields.VoucherInformationTransactionType[this]; } set { Fields.VoucherInformationTransactionType[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationTransactionType; }


        [DisplayName("Voucher Date"), Expression("jVoucherInformation.[voucherDate]"), QuickSearch]
        public DateTime? VoucherInformationVoucherDate { get { return Fields.VoucherInformationVoucherDate[this]; } set { Fields.VoucherInformationVoucherDate[this] = value; } }
        public partial class RowFields { public DateTimeField VoucherInformationVoucherDate; }


        [DisplayName("Voucher No"), Expression("jVoucherInformation.[voucherNo]"), QuickSearch(SearchType.Contains)]
        public String VoucherInformationVoucherNo { get { return Fields.VoucherInformationVoucherNo[this]; } set { Fields.VoucherInformationVoucherNo[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationVoucherNo; }


        [DisplayName("Voucher Information Voucher Number"), Expression("jVoucherInformation.[voucherNumber]")]
        public String VoucherInformationVoucherNumber { get { return Fields.VoucherInformationVoucherNumber[this]; } set { Fields.VoucherInformationVoucherNumber[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationVoucherNumber; }

        [DisplayName("Voucher Information Voucher Type"), Expression("jVoucherInformation.[voucherType]")]
        public String VoucherInformationVoucherType { get { return Fields.VoucherInformationVoucherType[this]; } set { Fields.VoucherInformationVoucherType[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationVoucherType; }

        [DisplayName("Voucher Type"), Expression("jVoucherInformation.[VoucherTypeId]"), ForeignKey("acc_voucher_type", "Id"), InnerJoin("jvoucher_type"), TextualField("VoucherTypeName")]
        public Int32? VoucherInformationVoucherTypeId { get { return Fields.VoucherInformationVoucherTypeId[this]; } set { Fields.VoucherInformationVoucherTypeId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherInformationVoucherTypeId; }


        [DisplayName("Voucher Information Cost Centre Id"), Expression("jVoucherInformation.[costCentreId]")]
        public Int32? VoucherInformationCostCentreId { get { return Fields.VoucherInformationCostCentreId[this]; } set { Fields.VoucherInformationCostCentreId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherInformationCostCentreId; }


        [DisplayName("Voucher Information Cheque Register Id"), Expression("jVoucherInformation.[chequeRegisterId]")]
        [ForeignKey("dbo.acc_ChequeRegister", "Id"), InnerJoin("viChequeRegister"), TextualField("VoucherInformationChequeRegisterNo")]
        public Int32? VoucherInformationChequeRegisterId { get { return Fields.VoucherInformationChequeRegisterId[this]; } set { Fields.VoucherInformationChequeRegisterId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherInformationChequeRegisterId; }

        [DisplayName("Cheque No."), Expression("viChequeRegister.ChequeNo"), QuickSearch(SearchType.Contains)]
        public string VoucherInformationChequeRegisterNo { get { return Fields.VoucherInformationChequeRegisterNo[this]; } set { Fields.VoucherInformationChequeRegisterNo[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationChequeRegisterNo; }

        [DisplayName("Voucher Information Transaction Type Entity Id"), Expression("jVoucherInformation.[transactionTypeEntityId]")]
        public Int32? VoucherInformationTransactionTypeEntityId { get { return Fields.VoucherInformationTransactionTypeEntityId[this]; } set { Fields.VoucherInformationTransactionTypeEntityId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherInformationTransactionTypeEntityId; }


        [DisplayName("Voucher Information Bank Account Information Id"), Expression("jVoucherInformation.[bankAccountInformationId]")]
        public Int32? VoucherInformationBankAccountInformationId { get { return Fields.VoucherInformationBankAccountInformationId[this]; } set { Fields.VoucherInformationBankAccountInformationId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherInformationBankAccountInformationId; }



        [DisplayName("Voucher Information Fund Control Information Id"), Expression("jVoucherInformation.[fundControlInformationId]")]
        public Int32? VoucherInformationFundControlInformationId { get { return Fields.VoucherInformationFundControlInformationId[this]; } set { Fields.VoucherInformationFundControlInformationId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherInformationFundControlInformationId; }

        [DisplayName("VoucherInformationZoneID"), Expression("jVoucherInformation.[ZoneID]")]
        public Int32? VoucherInformationZoneID { get { return Fields.VoucherInformationZoneID[this]; } set { Fields.VoucherInformationZoneID[this] = value; } }
        public partial class RowFields { public Int32Field VoucherInformationZoneID; }

        #endregion

        [DisplayName("Voucher Type"), Expression("jvoucher_type.[Name]"), QuickSearch]
        //[MinSelectLevel(SelectLevel.List)]
        public String VoucherTypeName { get { return Fields.VoucherTypeName[this]; } set { Fields.VoucherTypeName[this] = value; } }
        public partial class RowFields { public StringField VoucherTypeName; }

        #region Payto Or Recive From
        [DisplayName("Payto/Recive From"), Expression("jVoucherInformation.[paytoOrReciveFrom]")]
        [MinSelectLevel(SelectLevel.List), QuickSearch(SearchType.Contains)]
        public String PaytoOrReciveFrom { get { return Fields.PaytoOrReciveFrom[this]; } set { Fields.PaytoOrReciveFrom[this] = value; } }
        public partial class RowFields { public StringField PaytoOrReciveFrom; }
        #endregion PaytoOrReciveFrom

        #region jChequeRegister

        //[DisplayName("Cheque Register Amount"), Expression("jChequeRegister.[amount]")]
        //public Decimal? ChequeRegisterAmount { get { return Fields.ChequeRegisterAmount[this]; } set { Fields.ChequeRegisterAmount[this] = value; } }
        //public partial class RowFields { public DecimalField ChequeRegisterAmount; }


        //[DisplayName("Cheque Register Amount In Words"), Expression("jChequeRegister.[amountInWords]")]
        //public String ChequeRegisterAmountInWords { get { return Fields.ChequeRegisterAmountInWords[this]; } set { Fields.ChequeRegisterAmountInWords[this] = value; } }
        //public partial class RowFields { public StringField ChequeRegisterAmountInWords; }


        //[DisplayName("Cheque Date"), Expression("jChequeRegister.[chequeDate]"), QuickSearch]
        //public DateTime? ChequeRegisterChequeDate { get { return Fields.ChequeRegisterChequeDate[this]; } set { Fields.ChequeRegisterChequeDate[this] = value; } }
        //public partial class RowFields { public DateTimeField ChequeRegisterChequeDate; }


        //[DisplayName("Cheque Register Cheque Issue Date"), Expression("jChequeRegister.[chequeIssueDate]")]
        //public DateTime? ChequeRegisterChequeIssueDate { get { return Fields.ChequeRegisterChequeIssueDate[this]; } set { Fields.ChequeRegisterChequeIssueDate[this] = value; } }
        //public partial class RowFields { public DateTimeField ChequeRegisterChequeIssueDate; }


        //[DisplayName("Cheque No"), Expression("jChequeRegister.[chequeNo]"), QuickSearch]
        //public String ChequeRegisterChequeNo { get { return Fields.ChequeRegisterChequeNo[this]; } set { Fields.ChequeRegisterChequeNo[this] = value; } }
        //public partial class RowFields { public StringField ChequeRegisterChequeNo; }


        //[DisplayName("Cheque Register Cheque Type"), Expression("jChequeRegister.[chequeType]")]
        //public String ChequeRegisterChequeType { get { return Fields.ChequeRegisterChequeType[this]; } set { Fields.ChequeRegisterChequeType[this] = value; } }
        //public partial class RowFields { public StringField ChequeRegisterChequeType; }


        //[DisplayName("Cheque Register Is Cancelled"), Expression("jChequeRegister.[isCancelled]")]
        //public Int16? ChequeRegisterIsCancelled { get { return Fields.ChequeRegisterIsCancelled[this]; } set { Fields.ChequeRegisterIsCancelled[this] = value; } }
        //public partial class RowFields { public Int16Field ChequeRegisterIsCancelled; }


        //[DisplayName("Cheque Register Is Payment"), Expression("jChequeRegister.[isPayment]")]
        //public Int16? ChequeRegisterIsPayment { get { return Fields.ChequeRegisterIsPayment[this]; } set { Fields.ChequeRegisterIsPayment[this] = value; } }
        //public partial class RowFields { public Int16Field ChequeRegisterIsPayment; }


        //[DisplayName("Cheque Register Is Used"), Expression("jChequeRegister.[isUsed]")]
        //public Int16? ChequeRegisterIsUsed { get { return Fields.ChequeRegisterIsUsed[this]; } set { Fields.ChequeRegisterIsUsed[this] = value; } }
        //public partial class RowFields { public Int16Field ChequeRegisterIsUsed; }


        //[DisplayName("Cheque Register Pay To"), Expression("jChequeRegister.[payTo]")]
        //public String ChequeRegisterPayTo { get { return Fields.ChequeRegisterPayTo[this]; } set { Fields.ChequeRegisterPayTo[this] = value; } }
        //public partial class RowFields { public StringField ChequeRegisterPayTo; }


        //[DisplayName("Cheque Register Payee Bank Name"), Expression("jChequeRegister.[payeeBankName]")]
        //public String ChequeRegisterPayeeBankName { get { return Fields.ChequeRegisterPayeeBankName[this]; } set { Fields.ChequeRegisterPayeeBankName[this] = value; } }
        //public partial class RowFields { public StringField ChequeRegisterPayeeBankName; }


        //[DisplayName("Cheque Register Remarks"), Expression("jChequeRegister.[remarks]")]
        //public String ChequeRegisterRemarks { get { return Fields.ChequeRegisterRemarks[this]; } set { Fields.ChequeRegisterRemarks[this] = value; } }
        //public partial class RowFields { public StringField ChequeRegisterRemarks; }


        //[DisplayName("Cheque Register Voucher No"), Expression("jChequeRegister.[voucherNo]")]
        //public String ChequeRegisterVoucherNo { get { return Fields.ChequeRegisterVoucherNo[this]; } set { Fields.ChequeRegisterVoucherNo[this] = value; } }
        //public partial class RowFields { public StringField ChequeRegisterVoucherNo; }


        //[DisplayName("Cheque Register Bank Account Information Id"), Expression("jChequeRegister.[bankAccountInformation_id]")]
        //public Int32? ChequeRegisterBankAccountInformationId { get { return Fields.ChequeRegisterBankAccountInformationId[this]; } set { Fields.ChequeRegisterBankAccountInformationId[this] = value; } }
        //public partial class RowFields { public Int32Field ChequeRegisterBankAccountInformationId; }


        //[DisplayName("Cheque Register Voucher Information Id"), Expression("jChequeRegister.[voucherInformation_id]")]
        //public Int32? ChequeRegisterVoucherInformationId { get { return Fields.ChequeRegisterVoucherInformationId[this]; } set { Fields.ChequeRegisterVoucherInformationId[this] = value; } }
        //public partial class RowFields { public Int32Field ChequeRegisterVoucherInformationId; }


        //[DisplayName("Cheque Register Entity Id"), Expression("jChequeRegister.[entityId]")]
        //public Int32? ChequeRegisterEntityId { get { return Fields.ChequeRegisterEntityId[this]; } set { Fields.ChequeRegisterEntityId[this] = value; } }
        //public partial class RowFields { public Int32Field ChequeRegisterEntityId; }


        //[DisplayName("Cheque Register Cheque Book Id"), Expression("jChequeRegister.[chequeBook_id]")]
        //public Int32? ChequeRegisterChequeBookId { get { return Fields.ChequeRegisterChequeBookId[this]; } set { Fields.ChequeRegisterChequeBookId[this] = value; } }
        //public partial class RowFields { public Int32Field ChequeRegisterChequeBookId; }

        #endregion

        #region jBankAccountInformation

        //[DisplayName("Bank Account Information Account Description"), Expression("jBankAccountInformation.[accountDescription]")]
        //public String BankAccountInformationAccountDescription { get { return Fields.BankAccountInformationAccountDescription[this]; } set { Fields.BankAccountInformationAccountDescription[this] = value; } }
        //public partial class RowFields { public StringField BankAccountInformationAccountDescription; }


        //[DisplayName("Bank Account Information Account Name"), Expression("jBankAccountInformation.[accountName]")]
        //public String BankAccountInformationAccountName { get { return Fields.BankAccountInformationAccountName[this]; } set { Fields.BankAccountInformationAccountName[this] = value; } }
        //public partial class RowFields { public StringField BankAccountInformationAccountName; }


        //[DisplayName("Bank Account Information Account Number"), Expression("jBankAccountInformation.[accountNumber]")]
        //public String BankAccountInformationAccountNumber { get { return Fields.BankAccountInformationAccountNumber[this]; } set { Fields.BankAccountInformationAccountNumber[this] = value; } }
        //public partial class RowFields { public StringField BankAccountInformationAccountNumber; }


        //[DisplayName("Bank Account Information Code"), Expression("jBankAccountInformation.[code]")]
        //public String BankAccountInformationCode { get { return Fields.BankAccountInformationCode[this]; } set { Fields.BankAccountInformationCode[this] = value; } }
        //public partial class RowFields { public StringField BankAccountInformationCode; }


        //[DisplayName("Bank Account Information Coa Id"), Expression("jBankAccountInformation.[COAId]")]
        //public Int32? BankAccountInformationCoaId { get { return Fields.BankAccountInformationCoaId[this]; } set { Fields.BankAccountInformationCoaId[this] = value; } }
        //public partial class RowFields { public Int32Field BankAccountInformationCoaId; }


        //[DisplayName("Bank Account Information Bank Id"), Expression("jBankAccountInformation.[bankId]")]
        //public Int32? BankAccountInformationBankId { get { return Fields.BankAccountInformationBankId[this]; } set { Fields.BankAccountInformationBankId[this] = value; } }
        //public partial class RowFields { public Int32Field BankAccountInformationBankId; }


        //[DisplayName("Bank Account Information Bank Branch Id"), Expression("jBankAccountInformation.[bankBranchId]")]
        //public Int32? BankAccountInformationBankBranchId { get { return Fields.BankAccountInformationBankBranchId[this]; } set { Fields.BankAccountInformationBankBranchId[this] = value; } }
        //public partial class RowFields { public Int32Field BankAccountInformationBankBranchId; }


        //[DisplayName("Bank Account Information Entity Id"), Expression("jBankAccountInformation.[entityId]")]
        //public Int32? BankAccountInformationEntityId { get { return Fields.BankAccountInformationEntityId[this]; } set { Fields.BankAccountInformationEntityId[this] = value; } }
        //public partial class RowFields { public Int32Field BankAccountInformationEntityId; }

        #endregion


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Description; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccVoucherDetailsRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_voucher_details]")
            {
                LocalTextPrefix = "Transaction.AccVoucherDetails";
            }
        }
        #endregion RowFields
    }

    [LookupScript("VoucherLookUp", Permission = "?", Expiration = -1)]
    public class VoucherLookUp : RowLookupScript<Entities.AccVoucherDetailsRow>
    {

        public VoucherLookUp()
        {
            IdField = AccVoucherDetailsRow.Fields.VoucherInformationVoucherTypeId.PropertyName;
            TextField = AccVoucherDetailsRow.Fields.VoucherTypeName.PropertyName;

        }

        protected override void PrepareQuery(SqlQuery query)
        {
            var fld = Entities.AccVoucherDetailsRow.Fields;
            query.Distinct(true)
                .Select(fld.VoucherInformationVoucherTypeId)
                .Select(fld.VoucherTypeName)
                .Where(fld.VoucherInformationVoucherTypeId < 3);
        }

        protected override void ApplyOrder(SqlQuery query)
        {
        }
    }
}

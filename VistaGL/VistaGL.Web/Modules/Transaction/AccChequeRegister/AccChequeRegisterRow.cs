using VistaGL.Modules.Common;

namespace VistaGL.Transaction.Entities
{
    using _Ext;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("ACCDB"), DisplayName("Cheque Issue Information"), InstanceName("Cheque Issue Information"), TwoLevelCached]
    [ReadPermission("Transaction:AccChequeRegister:Read")]
    [InsertPermission("Transaction:AccChequeRegister:Insert")]
    [UpdatePermission("Transaction:AccChequeRegister:Update")]
    [DeletePermission("Transaction:AccChequeRegister:Delete")]
    [LookupScript("Transaction.AccChequeRegister", Permission = "?", Expiration =-1)]
    public sealed class AccChequeRegisterRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int64? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int64Field Id; }
        #endregion Id

        #region Cheque Date
        [DisplayName("Cheque Date"), Column("chequeDate"), NotNull]
        public DateTime? ChequeDate { get { return Fields.ChequeDate[this]; } set { Fields.ChequeDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeDate; }
        #endregion ChequeDate

        #region Cheque Issue Date
        [DisplayName("Cheque Issue Date"), Column("chequeIssueDate"), NotNull]
        public DateTime? ChequeIssueDate { get { return Fields.ChequeIssueDate[this]; } set { Fields.ChequeIssueDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeIssueDate; }
        #endregion ChequeIssueDate

        #region Bank Advice Date
        [DisplayName("Bank Advice Date"), Column("BankAdviceDate"),LookupInclude]
        public DateTime? BankAdviceDate { get { return Fields.BankAdviceDate[this]; } set { Fields.BankAdviceDate[this] = value; } }
        public partial class RowFields { public DateTimeField BankAdviceDate; }
        #endregion Bank Advice Date


        #region Cheque No
        [DisplayName("Cheque No"), Column("chequeNo"), Size(255), NotNull, QuickSearch]
        public String ChequeNo { get { return Fields.ChequeNo[this]; } set { Fields.ChequeNo[this] = value; } }
        public partial class RowFields { public StringField ChequeNo; }
        #endregion ChequeNo

        #region Cheque Type
        [DisplayName("Cheque Type"), Column("chequeType"), Size(20), NotNull, QuickSearch]
        public String ChequeType { get { return Fields.ChequeType[this]; } set { Fields.ChequeType[this] = value; } }
        public partial class RowFields { public StringField ChequeType; }
        #endregion ChequeType

        #region Amount
        [DisplayName("Amount"), Column("amount"), NotNull, LookupInclude]
        public Decimal? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DecimalField Amount; }
        #endregion Amount

        #region Pay To
        [DisplayName("Pay To"), Column("payTo"), NotNull, LookupInclude, QuickSearch]
        [AutoCompleteEditor(LookupKey = "Transaction.AccCostCentreOrInstituteInformation_LookupForAutoComplete")]
        public String PayTo { get { return Fields.PayTo[this]; } set { Fields.PayTo[this] = value; } }
        public partial class RowFields { public StringField PayTo; }
        #endregion PayTo

        #region Cheque Nunhdn
        [DisplayName("Cheque Nunhdn"), Column("chequeNumhdn"), Size(18), NotNull]
        public Decimal? ChequeNumhdn { get { return Fields.ChequeNumhdn[this]; } set { Fields.ChequeNumhdn[this] = value; } }
        public partial class RowFields { public DecimalField ChequeNumhdn; }
        #endregion ChequeNumhdn

        #region Cheque Temp
        [DisplayName("Cheque Temp"), Column("ChequeNoTemp"), Size(18), NotMapped]
        public string ChequeNoTemp { get { return Fields.ChequeNoTemp[this]; } set { Fields.ChequeNoTemp[this] = value; } }
        public partial class RowFields { public StringField ChequeNoTemp; }
        #endregion ChequeNumhdn

        #region Amount In Words
        [DisplayName("Amount In Words"), Column("amountInWords")]
        public String AmountInWords { get { return Fields.AmountInWords[this]; } set { Fields.AmountInWords[this] = value; } }
        public partial class RowFields { public StringField AmountInWords; }
        #endregion AmountInWords

        #region Is Cancelled
        [DisplayName("Is Cancelled"), Column("isCancelled"), DefaultValue(false)]
        public Boolean? IsCancelled { get { return Fields.IsCancelled[this]; } set { Fields.IsCancelled[this] = value; } }
        public partial class RowFields { public BooleanField IsCancelled; }
        #endregion IsCancelled

        #region Is Payment
        [DisplayName("Is Payment"), Column("isPayment")]
        public Boolean? IsPayment { get { return Fields.IsPayment[this]; } set { Fields.IsPayment[this] = value; } }
        public partial class RowFields { public BooleanField IsPayment; }
        #endregion IsPayment

        #region Is Used
        [DisplayName("Is Used"), Column("isUsed"), LookupInclude]
        public Boolean? IsUsed { get { return Fields.IsUsed[this]; } set { Fields.IsUsed[this] = value; } }
        public partial class RowFields { public BooleanField IsUsed; }
        #endregion IsUsed

        #region Is Used
        [DisplayName("Is Used"), Column("isAdjusted"), LookupInclude,DefaultValue(false)]
        public Boolean? isAdjusted { get { return Fields.isAdjusted[this]; } set { Fields.isAdjusted[this] = value; } }
        public partial class RowFields { public BooleanField isAdjusted; }
        #endregion IsUsed


        #region Payee Bank Name
        [DisplayName("Payee Bank Name"), Column("payeeBankName"), Size(255)]
        public String PayeeBankName { get { return Fields.PayeeBankName[this]; } set { Fields.PayeeBankName[this] = value; } }
        public partial class RowFields { public StringField PayeeBankName; }
        #endregion PayeeBankName

        #region Remarks
        [DisplayName("Remarks"), Column("remarks"), Size(255), LookupInclude]
        public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
        public partial class RowFields { public StringField Remarks; }
        #endregion Remarks

        #region Voucher No
        [DisplayName("Voucher No"), Column("voucherNo"), Size(255)]
        public String VoucherNo { get { return Fields.VoucherNo[this]; } set { Fields.VoucherNo[this] = value; } }
        public partial class RowFields { public StringField VoucherNo; }
        #endregion VoucherNo

        #region Bank Account Information
        [DisplayName("Account No."), Column("bankAccountInformation_id"), NotNull, ForeignKey("[dbo].[acc_BankAccountInformation]", "id"), LeftJoin("jBankAccountInformation"), TextualField("BankAccountInformationAccountDescription")]
        [LookupEditor("Configurations.AccBankAccountInformation_Lookup"), LookupInclude]
        public Int32? BankAccountInformationId { get { return Fields.BankAccountInformationId[this]; } set { Fields.BankAccountInformationId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationId; }
        #endregion BankAccountInformationId

        #region Voucher Information
        [DisplayName("Voucher Information"), Column("voucherInformation_id"), ForeignKey("[dbo].[acc_voucher_information]", "id"), LeftJoin("jVoucherInformation"), TextualField("VoucherInformationAmountInWords")]
        [LookupEditor(typeof(Transaction.Repositories.AccVoucherInformationRowLookup))]
        public Int64? VoucherInformationId { get { return Fields.VoucherInformationId[this]; } set { Fields.VoucherInformationId[this] = value; } }
        public partial class RowFields { public Int64Field VoucherInformationId; }
        #endregion VoucherInformationId

        #region Entity
        [DisplayName("Entity"), Column("entityId"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jEntity"), TextualField("EntityCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow), InplaceAdd = true)]
        public Int32? EntityId { get { return Fields.EntityId[this]; } set { Fields.EntityId[this] = value; } }
        public partial class RowFields { public Int32Field EntityId; }
        #endregion EntityId

        #region Cheque Book
        [DisplayName("Cheque Book"), Column("chequeBook_id"), NotNull, ForeignKey("[dbo].[acc_ChequeBook]", "id"), LeftJoin("jChequeBook"), TextualField("ChequeBookCheckBookName")]
        [LookupEditor(typeof(Repositories.AccChequeBookRow_NotFinishedYet_Lookup), CascadeFrom = "BankAccountInformationId"), LookupInclude]
        public Int32? ChequeBookId { get { return Fields.ChequeBookId[this]; } set { Fields.ChequeBookId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeBookId; }
        #endregion ChequeBookId

        #region Is Bank Advice
        [DisplayName("Is Bank Advice"), Column("isBankAdvice")]
        [Expression(" (ISNULL(IsBankAdvice, 0)) ")]
        public Boolean? IsBankAdvice { get { return Fields.IsBankAdvice[this]; } set { Fields.IsBankAdvice[this] = value; } }
        public partial class RowFields { public BooleanField IsBankAdvice; }
        #endregion IsBankAdvice

        #region optional field used for update cheque book
        [DisplayName("Is Finished"), NotMapped]
        public Boolean? IsFinished { get { return Fields.IsFinished[this]; } set { Fields.IsFinished[this] = value; } }
        public partial class RowFields { public BooleanField IsFinished; }
        #endregion IsFinished

        #region Zone Info
        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        //[LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region Foreign Fields

        //[DisplayName("Bank Account Information Account Description"), Expression("jBankAccountInformation.[accountDescription]")]
        //public String BankAccountInformationAccountDescription { get { return Fields.BankAccountInformationAccountDescription[this]; } set { Fields.BankAccountInformationAccountDescription[this] = value; } }
        //public partial class RowFields { public StringField BankAccountInformationAccountDescription; }


        //[DisplayName("Bank Account Information Account Name"), Expression("jBankAccountInformation.[accountName]")]
        //public String BankAccountInformationAccountName { get { return Fields.BankAccountInformationAccountName[this]; } set { Fields.BankAccountInformationAccountName[this] = value; } }
        //public partial class RowFields { public StringField BankAccountInformationAccountName; }


        [DisplayName("Account No."), Expression("jBankAccountInformation.[accountNumber]")]
        public String BankAccountInformationAccountNumber { get { return Fields.BankAccountInformationAccountNumber[this]; } set { Fields.BankAccountInformationAccountNumber[this] = value; } }
        public partial class RowFields { public StringField BankAccountInformationAccountNumber; }


        //[DisplayName("Bank Account Information Code"), Expression("jBankAccountInformation.[code]")]
        //public String BankAccountInformationCode { get { return Fields.BankAccountInformationCode[this]; } set { Fields.BankAccountInformationCode[this] = value; } }
        //public partial class RowFields { public StringField BankAccountInformationCode; }


        [DisplayName("Bank Account Information Coa Id"), Expression("jBankAccountInformation.[COAId]")]
        [MinSelectLevel(SelectLevel.Always), LookupInclude]
        public Int32? BankAccountInformationCoaId { get { return Fields.BankAccountInformationCoaId[this]; } set { Fields.BankAccountInformationCoaId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationCoaId; }


        //[DisplayName("Bank Account Information Bank Id"), Expression("jBankAccountInformation.[bankId]")]
        //public Int32? BankAccountInformationBankId { get { return Fields.BankAccountInformationBankId[this]; } set { Fields.BankAccountInformationBankId[this] = value; } }
        //public partial class RowFields { public Int32Field BankAccountInformationBankId; }


        //[DisplayName("Bank Account Information Bank Branch Id"), Expression("jBankAccountInformation.[bankBranchId]")]
        //public Int32? BankAccountInformationBankBranchId { get { return Fields.BankAccountInformationBankBranchId[this]; } set { Fields.BankAccountInformationBankBranchId[this] = value; } }
        //public partial class RowFields { public Int32Field BankAccountInformationBankBranchId; }


        //[DisplayName("Bank Account Information Entity Id"), Expression("jBankAccountInformation.[entityId]")]
        //public Int32? BankAccountInformationEntityId { get { return Fields.BankAccountInformationEntityId[this]; } set { Fields.BankAccountInformationEntityId[this] = value; } }
        //public partial class RowFields { public Int32Field BankAccountInformationEntityId; }


        //[DisplayName("Voucher Information Amount"), Expression("jVoucherInformation.[amount]")]
        //public Decimal? VoucherInformationAmount { get { return Fields.VoucherInformationAmount[this]; } set { Fields.VoucherInformationAmount[this] = value; } }
        //public partial class RowFields { public DecimalField VoucherInformationAmount; }


        //[DisplayName("Voucher Information Amount In Words"), Expression("jVoucherInformation.[amountInWords]")]
        //public String VoucherInformationAmountInWords { get { return Fields.VoucherInformationAmountInWords[this]; } set { Fields.VoucherInformationAmountInWords[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationAmountInWords; }


        //[DisplayName("Voucher Information Clear Date"), Expression("jVoucherInformation.[clearDate]")]
        //public DateTime? VoucherInformationClearDate { get { return Fields.VoucherInformationClearDate[this]; } set { Fields.VoucherInformationClearDate[this] = value; } }
        //public partial class RowFields { public DateTimeField VoucherInformationClearDate; }


        //[DisplayName("Voucher Information Description"), Expression("jVoucherInformation.[description]")]
        //public String VoucherInformationDescription { get { return Fields.VoucherInformationDescription[this]; } set { Fields.VoucherInformationDescription[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationDescription; }


        //[DisplayName("Voucher Information File No"), Expression("jVoucherInformation.[fileNo]")]
        //public String VoucherInformationFileNo { get { return Fields.VoucherInformationFileNo[this]; } set { Fields.VoucherInformationFileNo[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationFileNo; }


        //[DisplayName("Voucher Information Head Description"), Expression("jVoucherInformation.[headDescription]")]
        //public String VoucherInformationHeadDescription { get { return Fields.VoucherInformationHeadDescription[this]; } set { Fields.VoucherInformationHeadDescription[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationHeadDescription; }


        //[DisplayName("Voucher Information Is Approved"), Expression("jVoucherInformation.[isApproved]")]
        //public Int16? VoucherInformationIsApproved { get { return Fields.VoucherInformationIsApproved[this]; } set { Fields.VoucherInformationIsApproved[this] = value; } }
        //public partial class RowFields { public Int16Field VoucherInformationIsApproved; }


        //[DisplayName("Voucher Information Is Auto"), Expression("jVoucherInformation.[isAuto]")]
        //public Int16? VoucherInformationIsAuto { get { return Fields.VoucherInformationIsAuto[this]; } set { Fields.VoucherInformationIsAuto[this] = value; } }
        //public partial class RowFields { public Int16Field VoucherInformationIsAuto; }


        //[DisplayName("Voucher Information Is Bank Reconcile"), Expression("jVoucherInformation.[isBankReconcile]")]
        //public Int16? VoucherInformationIsBankReconcile { get { return Fields.VoucherInformationIsBankReconcile[this]; } set { Fields.VoucherInformationIsBankReconcile[this] = value; } }
        //public partial class RowFields { public Int16Field VoucherInformationIsBankReconcile; }


        //[DisplayName("Voucher Information Is Cash"), Expression("jVoucherInformation.[isCash]")]
        //public Int16? VoucherInformationIsCash { get { return Fields.VoucherInformationIsCash[this]; } set { Fields.VoucherInformationIsCash[this] = value; } }
        //public partial class RowFields { public Int16Field VoucherInformationIsCash; }


        //[DisplayName("Voucher Information Is Submitted"), Expression("jVoucherInformation.[isSubmitted]")]
        //public Int16? VoucherInformationIsSubmitted { get { return Fields.VoucherInformationIsSubmitted[this]; } set { Fields.VoucherInformationIsSubmitted[this] = value; } }
        //public partial class RowFields { public Int16Field VoucherInformationIsSubmitted; }


        //[DisplayName("Voucher Information Menu Name"), Expression("jVoucherInformation.[menuName]")]
        //public String VoucherInformationMenuName { get { return Fields.VoucherInformationMenuName[this]; } set { Fields.VoucherInformationMenuName[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationMenuName; }


        //[DisplayName("Voucher Information Mid"), Expression("jVoucherInformation.[mid]")]
        //public Int32? VoucherInformationMid { get { return Fields.VoucherInformationMid[this]; } set { Fields.VoucherInformationMid[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherInformationMid; }


        //[DisplayName("Voucher Information Note Type"), Expression("jVoucherInformation.[noteType]")]
        //public String VoucherInformationNoteType { get { return Fields.VoucherInformationNoteType[this]; } set { Fields.VoucherInformationNoteType[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationNoteType; }


        //[DisplayName("Voucher Information Page No"), Expression("jVoucherInformation.[pageNo]")]
        //public String VoucherInformationPageNo { get { return Fields.VoucherInformationPageNo[this]; } set { Fields.VoucherInformationPageNo[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationPageNo; }


        //[DisplayName("Voucher Information Payment Amount"), Expression("jVoucherInformation.[paymentAmount]")]
        //public Decimal? VoucherInformationPaymentAmount { get { return Fields.VoucherInformationPaymentAmount[this]; } set { Fields.VoucherInformationPaymentAmount[this] = value; } }
        //public partial class RowFields { public DecimalField VoucherInformationPaymentAmount; }


        //[DisplayName("Voucher Information Paymentamount In Words"), Expression("jVoucherInformation.[paymentamountInWords]")]
        //public String VoucherInformationPaymentamountInWords { get { return Fields.VoucherInformationPaymentamountInWords[this]; } set { Fields.VoucherInformationPaymentamountInWords[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationPaymentamountInWords; }


        //[DisplayName("Voucher Information Payto Or Recive From"), Expression("jVoucherInformation.[paytoOrReciveFrom]")]
        //public String VoucherInformationPaytoOrReciveFrom { get { return Fields.VoucherInformationPaytoOrReciveFrom[this]; } set { Fields.VoucherInformationPaytoOrReciveFrom[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationPaytoOrReciveFrom; }


        //[DisplayName("Voucher Information Post To Ledger"), Expression("jVoucherInformation.[postToLedger]")]
        //public Int16? VoucherInformationPostToLedger { get { return Fields.VoucherInformationPostToLedger[this]; } set { Fields.VoucherInformationPostToLedger[this] = value; } }
        //public partial class RowFields { public Int16Field VoucherInformationPostToLedger; }


        //[DisplayName("Voucher Information Posted By"), Expression("jVoucherInformation.[postedBy]")]
        //public String VoucherInformationPostedBy { get { return Fields.VoucherInformationPostedBy[this]; } set { Fields.VoucherInformationPostedBy[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationPostedBy; }


        //[DisplayName("Voucher Information Posting Date"), Expression("jVoucherInformation.[postingDate]")]
        //public DateTime? VoucherInformationPostingDate { get { return Fields.VoucherInformationPostingDate[this]; } set { Fields.VoucherInformationPostingDate[this] = value; } }
        //public partial class RowFields { public DateTimeField VoucherInformationPostingDate; }


        //[DisplayName("Voucher Information Posting Number"), Expression("jVoucherInformation.[postingNumber]")]
        //public String VoucherInformationPostingNumber { get { return Fields.VoucherInformationPostingNumber[this]; } set { Fields.VoucherInformationPostingNumber[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationPostingNumber; }


        //[DisplayName("Voucher Information Prepared By"), Expression("jVoucherInformation.[preparedBy]")]
        //public String VoucherInformationPreparedBy { get { return Fields.VoucherInformationPreparedBy[this]; } set { Fields.VoucherInformationPreparedBy[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationPreparedBy; }


        //[DisplayName("Voucher Information Sub Module"), Expression("jVoucherInformation.[subModule]")]
        //public String VoucherInformationSubModule { get { return Fields.VoucherInformationSubModule[this]; } set { Fields.VoucherInformationSubModule[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationSubModule; }


        //[DisplayName("Voucher Information Transaction Mode"), Expression("jVoucherInformation.[transactionMode]")]
        //public String VoucherInformationTransactionMode { get { return Fields.VoucherInformationTransactionMode[this]; } set { Fields.VoucherInformationTransactionMode[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationTransactionMode; }


        //[DisplayName("Voucher Information Transaction Type"), Expression("jVoucherInformation.[transactionType]")]
        //public String VoucherInformationTransactionType { get { return Fields.VoucherInformationTransactionType[this]; } set { Fields.VoucherInformationTransactionType[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationTransactionType; }


        //[DisplayName("Voucher Information Transfer Type"), Expression("jVoucherInformation.[transferType]")]
        //public String VoucherInformationTransferType { get { return Fields.VoucherInformationTransferType[this]; } set { Fields.VoucherInformationTransferType[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationTransferType; }


        [DisplayName("Voucher Information Voucher Date"), Expression("jVoucherInformation.[voucherDate]")]
        public DateTime? VoucherInformationVoucherDate { get { return Fields.VoucherInformationVoucherDate[this]; } set { Fields.VoucherInformationVoucherDate[this] = value; } }
        public partial class RowFields { public DateTimeField VoucherInformationVoucherDate; }


        [DisplayName("Voucher Information Voucher No"), Expression("jVoucherInformation.[voucherNo]")]
        public String VoucherInformationVoucherNo { get { return Fields.VoucherInformationVoucherNo[this]; } set { Fields.VoucherInformationVoucherNo[this] = value; } }
        public partial class RowFields { public StringField VoucherInformationVoucherNo; }


        //[DisplayName("Voucher Information Voucher Number"), Expression("jVoucherInformation.[voucherNumber]")]
        //public String VoucherInformationVoucherNumber { get { return Fields.VoucherInformationVoucherNumber[this]; } set { Fields.VoucherInformationVoucherNumber[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationVoucherNumber; }


        //[DisplayName("Voucher Information Voucher Tag"), Expression("jVoucherInformation.[voucherTag]")]
        //public Int32? VoucherInformationVoucherTag { get { return Fields.VoucherInformationVoucherTag[this]; } set { Fields.VoucherInformationVoucherTag[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherInformationVoucherTag; }


        //[DisplayName("Voucher Information Voucher Type"), Expression("jVoucherInformation.[voucherType]")]
        //public String VoucherInformationVoucherType { get { return Fields.VoucherInformationVoucherType[this]; } set { Fields.VoucherInformationVoucherType[this] = value; } }
        //public partial class RowFields { public StringField VoucherInformationVoucherType; }


        //[DisplayName("Voucher Information Cost Centre Id"), Expression("jVoucherInformation.[costCentreId]")]
        //public Int32? VoucherInformationCostCentreId { get { return Fields.VoucherInformationCostCentreId[this]; } set { Fields.VoucherInformationCostCentreId[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherInformationCostCentreId; }


        //[DisplayName("Voucher Information Cheque Register Id"), Expression("jVoucherInformation.[chequeRegisterId]")]
        //public Int32? VoucherInformationChequeRegisterId { get { return Fields.VoucherInformationChequeRegisterId[this]; } set { Fields.VoucherInformationChequeRegisterId[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherInformationChequeRegisterId; }


        //[DisplayName("Voucher Information Transaction Type Entity Id"), Expression("jVoucherInformation.[transactionTypeEntityId]")]
        //public Int32? VoucherInformationTransactionTypeEntityId { get { return Fields.VoucherInformationTransactionTypeEntityId[this]; } set { Fields.VoucherInformationTransactionTypeEntityId[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherInformationTransactionTypeEntityId; }


        //[DisplayName("Voucher Information Bank Account Information Id"), Expression("jVoucherInformation.[bankAccountInformationId]")]
        //public Int32? VoucherInformationBankAccountInformationId { get { return Fields.VoucherInformationBankAccountInformationId[this]; } set { Fields.VoucherInformationBankAccountInformationId[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherInformationBankAccountInformationId; }


        //[DisplayName("Voucher Information Posting Financial Year Id"), Expression("jVoucherInformation.[postingFinancialYearId]")]
        //public Int32? VoucherInformationPostingFinancialYearId { get { return Fields.VoucherInformationPostingFinancialYearId[this]; } set { Fields.VoucherInformationPostingFinancialYearId[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherInformationPostingFinancialYearId; }


        //[DisplayName("Voucher Information Fund Control Information Id"), Expression("jVoucherInformation.[fundControlInformationId]")]
        //public Int32? VoucherInformationFundControlInformationId { get { return Fields.VoucherInformationFundControlInformationId[this]; } set { Fields.VoucherInformationFundControlInformationId[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherInformationFundControlInformationId; }


        //[DisplayName("Entity Code"), Expression("jEntity.[code]")]
        //public String EntityCode { get { return Fields.EntityCode[this]; } set { Fields.EntityCode[this] = value; } }
        //public partial class RowFields { public StringField EntityCode; }

        //[DisplayName("Entity Fund Control Name"), Expression("jEntity.[fundControlName]")]
        //public String EntityFundControlName { get { return Fields.EntityFundControlName[this]; } set { Fields.EntityFundControlName[this] = value; } }
        //public partial class RowFields { public StringField EntityFundControlName; }


        //[DisplayName("Entity Remarks"), Expression("jEntity.[remarks]")]
        //public String EntityRemarks { get { return Fields.EntityRemarks[this]; } set { Fields.EntityRemarks[this] = value; } }
        //public partial class RowFields { public StringField EntityRemarks; }


        //[DisplayName("Cheque Book Cheque Issue Date"), Expression("jChequeBook.[CBDate]")]
        //public DateTime? ChequeBookCBDate { get { return Fields.ChequeBookCBDate[this]; } set { Fields.ChequeBookCBDate[this] = value; } }
        //public partial class RowFields { public DateTimeField ChequeBookCBDate; }


        //[DisplayName("Cheque Book Check Book Name"), Expression("jChequeBook.[checkBookName]")]
        //public String ChequeBookCheckBookName { get { return Fields.ChequeBookCheckBookName[this]; } set { Fields.ChequeBookCheckBookName[this] = value; } }
        //public partial class RowFields { public StringField ChequeBookCheckBookName; }


        //[DisplayName("Cheque Book Ending No"), Expression("jChequeBook.[endingNo]")]
        //public Decimal? ChequeBookEndingNo { get { return Fields.ChequeBookEndingNo[this]; } set { Fields.ChequeBookEndingNo[this] = value; } }
        //public partial class RowFields { public DecimalField ChequeBookEndingNo; }


        //[DisplayName("Cheque Book Has Finished"), Expression("jChequeBook.[hasFinished]")]
        //public Int16? ChequeBookHasFinished { get { return Fields.ChequeBookHasFinished[this]; } set { Fields.ChequeBookHasFinished[this] = value; } }
        //public partial class RowFields { public Int16Field ChequeBookHasFinished; }


        //[DisplayName("Cheque Book Starting No"), Expression("jChequeBook.[startingNo]")]
        //public Decimal? ChequeBookStartingNo { get { return Fields.ChequeBookStartingNo[this]; } set { Fields.ChequeBookStartingNo[this] = value; } }
        //public partial class RowFields { public DecimalField ChequeBookStartingNo; }


        //[DisplayName("Cheque Book Entity Id"), Expression("jChequeBook.[entityId]")]
        //public Int32? ChequeBookEntityId { get { return Fields.ChequeBookEntityId[this]; } set { Fields.ChequeBookEntityId[this] = value; } }
        //public partial class RowFields { public Int32Field ChequeBookEntityId; }


        //[DisplayName("Cheque Book Bank Account Information Id"), Expression("jChequeBook.[bankAccountInformation_id]")]
        //public Int32? ChequeBookBankAccountInformationId { get { return Fields.ChequeBookBankAccountInformationId[this]; } set { Fields.ChequeBookBankAccountInformationId[this] = value; } }
        //public partial class RowFields { public Int32Field ChequeBookBankAccountInformationId; }


        //[DisplayName("Cheque Book Page No"), Expression("jChequeBook.[pageNo]")]
        //public Decimal? ChequeBookPageNo { get { return Fields.ChequeBookPageNo[this]; } set { Fields.ChequeBookPageNo[this] = value; } }
        //public partial class RowFields { public DecimalField ChequeBookPageNo; }


        //[DisplayName("Cheque Book Prefix"), Expression("jChequeBook.[prefix]")]
        //public String ChequeBookPrefix { get { return Fields.ChequeBookPrefix[this]; } set { Fields.ChequeBookPrefix[this] = value; } }
        //public partial class RowFields { public StringField ChequeBookPrefix; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.ChequeNo; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccChequeRegisterRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_ChequeRegister]")
            {
                LocalTextPrefix = "Transaction.AccChequeRegister";
            }
        }
        #endregion RowFields
    }
}


using VistaGL.Modules.Common;

namespace VistaGL.Transaction.Entities
{

    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;


    [ConnectionKey("ACCDB"), DisplayName("Voucher Information"), InstanceName("Voucher Information"), TwoLevelCached]

    [ReadPermission("Transaction:AccVoucherInformation|Transaction:AccVoucherInformation:Approval")]
    [InsertPermission("Transaction:AccVoucherInformation:Insert|Transaction:AccVoucherInformation:Approval:Insert")]
    [UpdatePermission("Transaction:AccVoucherInformation:Update|Transaction:AccVoucherInformation:Approval:Update")]
    [DeletePermission("Transaction:AccVoucherInformation:Delete|Transaction:AccVoucherInformation:Approval:Delete")]
    [LookupScript("Transaction.AccVoucherInformation", Permission = "?")]
    [UniqueConstraint(new string[] { "VoucherNo", "ZoneId", "FundControlInformationId", "transactionTypeEntityId" }, CheckBeforeSave = true, ErrorMessage = "Duplicate Voucher No!")]
    [LeftJoin("jvJv", "acc_voucher_information", "jvJv.LinkedVoucherIdForAutoJV=t0.Id")]
    public sealed class AccVoucherInformationRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int64? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int64Field Id; }
        #endregion Id

        #region Amount
        [DisplayName("Amount"), Column("amount"), NotNull, DefaultValue(0), QuickSearch(), LookupInclude]
        public Decimal? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DecimalField Amount; }
        #endregion Amount

        #region Amount In Words
        [DisplayName("Amount In Words"), Column("amountInWords"), DefaultValue("ZERO")]
        public String AmountInWords { get { return Fields.AmountInWords[this]; } set { Fields.AmountInWords[this] = value; } }
        public partial class RowFields { public StringField AmountInWords; }
        #endregion AmountInWords

        #region Clear Date
        [DisplayName("Clear Date"), Column("clearDate")]
        public DateTime? ClearDate { get { return Fields.ClearDate[this]; } set { Fields.ClearDate[this] = value; } }
        public partial class RowFields { public DateTimeField ClearDate; }

        [NotMapped]
        public Int32? IsClearDate { get { return Fields.IsClearDate[this]; } set { Fields.IsClearDate[this] = value; } }
        public partial class RowFields { public Int32Field IsClearDate; }
        #endregion ClearDate

        #region Description
        [DisplayName("Narration"), Column("description"), NotNull, QuickSearch]
        public String Description { get { return Fields.Description[this]; } set { Fields.Description[this] = value; } }
        public partial class RowFields { public StringField Description; }
        #endregion Description

        #region File No
        [DisplayName("File No"), Column("fileNo")]
        public String FileNo { get { return Fields.FileNo[this]; } set { Fields.FileNo[this] = value; } }
        public partial class RowFields { public StringField FileNo; }
        #endregion FileNo

        #region Head Description
        [DisplayName("Head Description"), Column("headDescription")]
        public String HeadDescription { get { return Fields.HeadDescription[this]; } set { Fields.HeadDescription[this] = value; } }
        public partial class RowFields { public StringField HeadDescription; }
        #endregion HeadDescription

        #region Is Approved
        [DisplayName("Is Approved"), Column("isApproved")]
        public Int16? IsApproved { get { return Fields.IsApproved[this]; } set { Fields.IsApproved[this] = value; } }
        public partial class RowFields { public Int16Field IsApproved; }
        #endregion IsApproved

        #region Is Auto
        [DisplayName("Is Auto"), Column("isAuto")]
        public Int16? IsAuto { get { return Fields.IsAuto[this]; } set { Fields.IsAuto[this] = value; } }
        public partial class RowFields { public Int16Field IsAuto; }
        #endregion IsAuto

        #region Is Bank Reconcile
        [DisplayName("Is Bank Reconcile"), Column("isBankReconcile")]
        public Int16? IsBankReconcile { get { return Fields.IsBankReconcile[this]; } set { Fields.IsBankReconcile[this] = value; } }
        public partial class RowFields { public Int16Field IsBankReconcile; }
        #endregion IsBankReconcile

        #region Is Cash
        [DisplayName("Is Cash"), Column("isCash")]
        public Int16? IsCash { get { return Fields.IsCash[this]; } set { Fields.IsCash[this] = value; } }
        public partial class RowFields { public Int16Field IsCash; }
        #endregion IsCash

        #region Is Submitted
        [DisplayName("Is Submitted"), Column("isSubmitted")]
        public Int16? IsSubmitted { get { return Fields.IsSubmitted[this]; } set { Fields.IsSubmitted[this] = value; } }
        public partial class RowFields { public Int16Field IsSubmitted; }
        #endregion IsSubmitted

        #region Menu Name
        [DisplayName("Menu Name"), Column("menuName")]
        public String MenuName { get { return Fields.MenuName[this]; } set { Fields.MenuName[this] = value; } }
        public partial class RowFields { public StringField MenuName; }
        #endregion MenuName

        #region Mid
        [DisplayName("Mid"), Column("mid")]
        public Int32? Mid { get { return Fields.Mid[this]; } set { Fields.Mid[this] = value; } }
        public partial class RowFields { public Int32Field Mid; }
        #endregion Mid

        #region Note Type
        [DisplayName("Note Type"), Column("noteType")]
        public String NoteType { get { return Fields.NoteType[this]; } set { Fields.NoteType[this] = value; } }
        public partial class RowFields { public StringField NoteType; }
        #endregion NoteType

        #region Page No
        [DisplayName("Page No"), Column("pageNo")]
        public String PageNo { get { return Fields.PageNo[this]; } set { Fields.PageNo[this] = value; } }
        public partial class RowFields { public StringField PageNo; }
        #endregion PageNo

        #region Payment Amount
        [DisplayName("Payment Amount"), Column("paymentAmount")]
        public Decimal? PaymentAmount { get { return Fields.PaymentAmount[this]; } set { Fields.PaymentAmount[this] = value; } }
        public partial class RowFields { public DecimalField PaymentAmount; }
        #endregion PaymentAmount

        #region Paymentamount In Words
        [DisplayName("Paymentamount In Words"), Column("paymentamountInWords")]
        public String PaymentamountInWords { get { return Fields.PaymentamountInWords[this]; } set { Fields.PaymentamountInWords[this] = value; } }
        public partial class RowFields { public StringField PaymentamountInWords; }
        #endregion PaymentamountInWords

        #region Post To Ledger
        [DisplayName("Post To Ledger"), Column("postToLedger")]
        public Int16? PostToLedger { get { return Fields.PostToLedger[this]; } set { Fields.PostToLedger[this] = value; } }
        public partial class RowFields { public Int16Field PostToLedger; }
        #endregion PostToLedger

        #region Post to Ledger (as boolean)
        [DisplayName("Post to Ledger")]
        [Expression("(CASE WHEN ISNULL(t0.PostToLedger, 0) = 0 THEN 0 ELSE 1 END)")]
        public Boolean? PostToLedgerBoolean { get { return Fields.PostToLedgerBoolean[this]; } set { Fields.PostToLedgerBoolean[this] = value; } }
        public partial class RowFields { public BooleanField PostToLedgerBoolean; }
        #endregion PosttoLedgerAsBoolean

        #region Posted By
        [DisplayName("Posted By"), Column("postedBy"), ForeignKey("dbo.prm_EmploymentInfo", "Id"), LeftJoin("empPostedBy"), TextualField("PostedByName")]
        public String PostedBy { get { return Fields.PostedBy[this]; } set { Fields.PostedBy[this] = value; } }
        public partial class RowFields { public StringField PostedBy; }
        #endregion PostedBy

        #region Posted By Name
        [DisplayName("Posted By")]
        [Expression("empPostedBy.FullName")]
        public String PostedByName { get { return Fields.PostedByName[this]; } set { Fields.PostedByName[this] = value; } }
        public partial class RowFields { public StringField PostedByName; }
        #endregion PostedByName

        #region Posting Date
        [DisplayName("Posting Date"), Column("postingDate")]
        public DateTime? PostingDate { get { return Fields.PostingDate[this]; } set { Fields.PostingDate[this] = value; } }
        public partial class RowFields { public DateTimeField PostingDate; }
        #endregion PostingDate

        #region Posting Number
        [DisplayName("Posting Number"), Column("postingNumber")]
        public String PostingNumber { get { return Fields.PostingNumber[this]; } set { Fields.PostingNumber[this] = value; } }
        public partial class RowFields { public StringField PostingNumber; }
        #endregion PostingNumber

        #region Prepared By
        [DisplayName("Prepared By"), Column("preparedBy")]
        public String PreparedBy { get { return Fields.PreparedBy[this]; } set { Fields.PreparedBy[this] = value; } }
        public partial class RowFields { public StringField PreparedBy; }
        #endregion PreparedBy

        #region Sub Module
        [DisplayName("Sub Module"), Column("subModule")]
        public String SubModule { get { return Fields.SubModule[this]; } set { Fields.SubModule[this] = value; } }
        public partial class RowFields { public StringField SubModule; }
        #endregion SubModule

        #region Transaction Mode
        [DisplayName("Transaction Mode"), Column("transactionMode"), NotNull]
        public String TransactionMode { get { return Fields.TransactionMode[this]; } set { Fields.TransactionMode[this] = value; } }
        public partial class RowFields { public StringField TransactionMode; }
        #endregion TransactionMode

        #region Transaction Type
        [DisplayName("Transaction Type"), Column("transactionType"), NotNull]
        public String TransactionType { get { return Fields.TransactionType[this]; } set { Fields.TransactionType[this] = value; } }
        public partial class RowFields { public StringField TransactionType; }
        #endregion TransactionType

        #region Transfer Type
        [DisplayName("Transfer Type"), Column("transferType")]
        public String TransferType { get { return Fields.TransferType[this]; } set { Fields.TransferType[this] = value; } }
        public partial class RowFields { public StringField TransferType; }
        #endregion TransferType

        #region Voucher Date
        [DisplayName("Voucher Date"), Column("voucherDate"), NotNull, DefaultValue("now")]
        public DateTime? VoucherDate { get { return Fields.VoucherDate[this]; } set { Fields.VoucherDate[this] = value; } }
        public partial class RowFields { public DateTimeField VoucherDate; }
        #endregion VoucherDate

        #region Voucher No
        [DisplayName("Voucher No"), Column("voucherNo"), NotNull, QuickSearch]
        public String VoucherNo { get { return Fields.VoucherNo[this]; } set { Fields.VoucherNo[this] = value; } }
        public partial class RowFields { public StringField VoucherNo; }
        #endregion VoucherNo

        #region Voucher Number
        [DisplayName("Voucher Number"), Column("voucherNumber")]
        public String VoucherNumber { get { return Fields.VoucherNumber[this]; } set { Fields.VoucherNumber[this] = value; } }
        public partial class RowFields { public StringField VoucherNumber; }
        #endregion VoucherNumber

        #region Voucher Tag
        [DisplayName("Voucher Tag"), Column("voucherTag")]
        public Int32? VoucherTag { get { return Fields.VoucherTag[this]; } set { Fields.VoucherTag[this] = value; } }
        public partial class RowFields { public Int32Field VoucherTag; }
        #endregion VoucherTag

        #region Voucher Type
        [DisplayName("Voucher Type"), Column("voucherType"), NotNull]
        public String VoucherType { get { return Fields.VoucherType[this]; } set { Fields.VoucherType[this] = value; } }
        public partial class RowFields { public StringField VoucherType; }
        #endregion VoucherType

        #region Type
        [DisplayName("Type"), NotMapped]
        public String Type { get { return Fields.Type[this]; } set { Fields.Type[this] = value; } }
        public partial class RowFields { public StringField Type; }
        #endregion VoucherType

        #region Cost Centre

        [DisplayName("Sub Ledger Type")]
        [LookupEditor(typeof(Configurations.Entities.AccCostCenterTypeRow)), NotMapped]
        public Int16? CostCenterTypeId { get { return Fields.CostCenterTypeId[this]; } set { Fields.CostCenterTypeId[this] = value; } }
        public partial class RowFields { public Int16Field CostCenterTypeId; }


        [DisplayName("Sub Ledger Group"), NotMapped]
        //[LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow), FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = true)]
        [LookupEditor("Transaction.AccCostCentreOrInstituteInformation_Lookup",
            FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = true, CascadeFrom = "CostCenterTypeId")]
        public Int32? ParentId { get { return Fields.ParentId[this]; } set { Fields.ParentId[this] = value; } }
        public partial class RowFields { public Int32Field ParentId; }


        [DisplayName("Sub Ledger"), Column("costCentreId"), ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jCostCentre"), TextualField("CostCentreCode")]
        [LookupEditor(typeof(AccCostCentreOrInstituteInformationRow), InplaceAdd = true, FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        //[LookupEditor("Transaction.AccCostCentreOrInstituteInformation_Lookup", InplaceAdd = true,
        //    FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false, CascadeFrom = "ParentId")]
        public Int32? CostCentreId { get { return Fields.CostCentreId[this]; } set { Fields.CostCentreId[this] = value; } }
        public partial class RowFields { public Int32Field CostCentreId; }
        #endregion CostCentreId

        #region VoucherType
        [DisplayName("Voucher Type"), Column("VoucherTypeId"), NotNull, ForeignKey("[dbo].[acc_voucher_type]", "Id"), LeftJoin("jVoucherType"), TextualField("VoucherTypeName")]
        [LookupEditor(typeof(Configurations.Entities.AccVoucherTypeRow))]
        public Int32? VoucherTypeId { get { return Fields.VoucherTypeId[this]; } set { Fields.VoucherTypeId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherTypeId; }
        #endregion VoucherTypeID

        #region File attachment
        [MultipleFileUploadEditor()]
        [DisplayName("File Name"), Column("fileName")]
        public string FileName { get { return Fields.FileName[this]; } set { Fields.FileName[this] = value; } }
        public partial class RowFields { public StringField FileName; }
        #endregion

        #region Transaction Type Entity
        [DisplayName("Transaction Type"), Column("transactionTypeEntityId"), NotNull, ForeignKey("[dbo].[acc_transaction_type]", "id"), LeftJoin("jTransactionTypeEntity"), TextualField("TransactionTypeEntityRemarks")]
        [LookupEditor(typeof(Configurations.Entities.AccTransactionTypeRow), CascadeFrom = "VoucherTypeId")]
        //   [LookupEditor(typeof(Configurations.Entities.AccTransactionTypeRow))]

        public Int32? TransactionTypeEntityId { get { return Fields.TransactionTypeEntityId[this]; } set { Fields.TransactionTypeEntityId[this] = value; } }
        public partial class RowFields { public Int32Field TransactionTypeEntityId; }
        #endregion TransactionTypeEntityId

        #region Posting Financial Year
        [DisplayName("Financial Year"), Column("postingFinancialYearId"), ForeignKey("[dbo].[acc_Accounting_Period_Information]", "id"), LeftJoin("jPostingFinancialYear"), TextualField("PostingFinancialYearYearName")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow))]
        public Int32? PostingFinancialYearId { get { return Fields.PostingFinancialYearId[this]; } set { Fields.PostingFinancialYearId[this] = value; } }
        public partial class RowFields { public Int32Field PostingFinancialYearId; }
        #endregion PostingFinancialYearId

        #region Fund Control Information
        [DisplayName("Entity Name"), Column("fundControlInformationId"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControlInformation"), TextualField("FundControlInformationCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
        public Int32? FundControlInformationId { get { return Fields.FundControlInformationId[this]; } set { Fields.FundControlInformationId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlInformationId; }
        #endregion FundControlInformationId

        #region Voucher Details
        [DisplayName("Voucher Details"),
            MasterDetailRelation(foreignKey: "VoucherInformationId",
            CheckChangesOnUpdate = true), MinSelectLevel(SelectLevel.Auto)]
        public List<AccVoucherDetailsRow> VoucherDetails
        {
            get { return Fields.VoucherDetails[this]; }
            set { Fields.VoucherDetails[this] = value; }
        }
        public partial class RowFields { public RowListField<AccVoucherDetailsRow> VoucherDetails; }
        #endregion

        #region Zone
        [DisplayName("Zone"), Column("ZoneID"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZone"), TextualField("ZoneZoneName")]
        [LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneId { get { return Fields.ZoneId[this]; } set { Fields.ZoneId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneId; }
        #endregion ZoneId

        #region approveStatus
        [DisplayName("Approve Status"), Column("approveStatus")]
        public ApprovalStatus? approveStatus { get { return (ApprovalStatus?)Fields.approveStatus[this]; } set { Fields.approveStatus[this] = (Int32)value; } }
        public partial class RowFields { public Int32Field approveStatus; }
        #endregion approveStatus

        #region EmpId
        [DisplayName("EmpId"), Column("EmpId")]
        public Int32? EmpId { get { return Fields.EmpId[this]; } set { Fields.EmpId[this] = value; } }
        public partial class RowFields { public Int32Field EmpId; }
        #endregion EmpId

        #region ProjectID
        [DisplayName("Project"), Column("ProjectID")]
        [LookupEditor("Transaction.AccViewProjectList_Lookup")]
        public Int32? ProjectID { get { return Fields.ProjectID[this]; } set { Fields.ProjectID[this] = value; } }
        public partial class RowFields { public Int32Field ProjectID; }
        #endregion ProjectID

        #region TemplateId
        [DisplayName("TemplateId"), Column("TemplateId")]
        public Int32? TemplateId { get { return Fields.TemplateId[this]; } set { Fields.TemplateId[this] = value; } }
        public partial class RowFields { public Int32Field TemplateId; }
        #endregion TemplateId

        #region postingSendTo
        [DisplayName("Send To"), Column("postingSendTo")]
        public Int32? postingSendTo { get { return Fields.postingSendTo[this]; } set { Fields.postingSendTo[this] = value; } }
        public partial class RowFields { public Int32Field postingSendTo; }
        #endregion postingSendTo

        #region Temp Account Bank/Cash
        [NotMapped]
        public string AccountBankCash { get { return Fields.AccountBankCash[this]; } set { Fields.AccountBankCash[this] = value; } }
        public partial class RowFields { public StringField AccountBankCash; }
        #endregion

        #region Temp Account Bank/Cash Amount
        [NotMapped]
        public Decimal? AccountBankCashAmount { get { return Fields.AccountBankCashAmount[this]; } set { Fields.AccountBankCashAmount[this] = value; } }
        public partial class RowFields { public DecimalField AccountBankCashAmount; }
        #endregion


        #region Power of Attorney
        [DisplayName("Power of Attorney"), Column("PowerofAttorney")]
        public String PowerofAttorney { get { return Fields.PowerofAttorney[this]; } set { Fields.PowerofAttorney[this] = value; } }
        public partial class RowFields { public StringField PowerofAttorney; }
        #endregion PowerofAttorney

        #region Linked With Auto JV
        [DisplayName("Has Auto JV?"), Column("LinkedWithAutoJV"), DefaultValue(false), LookupInclude]
        public Boolean? LinkedWithAutoJV { get { return Fields.LinkedWithAutoJV[this]; } set { Fields.LinkedWithAutoJV[this] = value; } }
        public partial class RowFields { public BooleanField LinkedWithAutoJV; }
        #endregion LinkedWithAutoJV

        #region Linked VoucherId For AutoJV
        [Column("LinkedVoucherIdForAutoJV"), LookupInclude]
        public Int64? LinkedVoucherIdForAutoJV { get { return Fields.LinkedVoucherIdForAutoJV[this]; } set { Fields.LinkedVoucherIdForAutoJV[this] = value; } }
        public partial class RowFields { public Int64Field LinkedVoucherIdForAutoJV; }
        #endregion LinkedVoucherIdForAutoJV

        #region LinkedJournalVoucherNo
        [DisplayName("Linked Journal Voucher No."), NotMapped]
        public String LinkedJournalVoucherNo { get { return Fields.LinkedJournalVoucherNo[this]; } set { Fields.LinkedJournalVoucherNo[this] = value; } }
        public partial class RowFields { public StringField LinkedJournalVoucherNo; }
        #endregion LinkedJournalVoucherNo

        #region LinkedDebitVoucherNo
        [DisplayName("Linked Debit Voucher No."), NotMapped]
        public String LinkedDebitVoucherNo { get { return Fields.LinkedDebitVoucherNo[this]; } set { Fields.LinkedDebitVoucherNo[this] = value; } }
        public partial class RowFields { public StringField LinkedDebitVoucherNo; }
        #endregion LinkedDebitVoucherNo

        [DisplayName("Is Linked with Debit Voucher")]
        [Expression("(CASE WHEN ISNULL(jvJv.Id, 0) = 0 THEN 0 ELSE 1 END)")]
        public Boolean? LinkedWithDebitVoucher { get { return Fields.LinkedWithDebitVoucher[this]; } set { Fields.LinkedWithDebitVoucher[this] = value; } }
        public partial class RowFields { public BooleanField LinkedWithDebitVoucher; }


        #region JV Amount
        [DisplayName("JV Amount"), NotMapped]
        public Decimal? JVAmount { get { return Fields.JVAmount[this]; } set { Fields.JVAmount[this] = value; } }
        public partial class RowFields { public DecimalField JVAmount; }
        #endregion JVAmount

        #region JV Amount In Words
        [DisplayName("JV Amount In Words"), NotMapped]
        public String JVAmountInWords { get { return Fields.JVAmountInWords[this]; } set { Fields.JVAmountInWords[this] = value; } }
        public partial class RowFields { public StringField JVAmountInWords; }
        #endregion JVAmountInWords

        #region NOA
        [DisplayName("NOA"), ForeignKey("[dbo].[acc_NOA]", "id"), LeftJoin("jNoa"), TextualField("NoaNumber")]
        [LookupEditor(typeof(AccNoaRow), FilterField = nameof(AccNoaRow.ZoneInfoId), InplaceAdd = true)]
        public Int32? NOAId { get { return Fields.NOAId[this]; } set { Fields.NOAId[this] = value; } }
        public partial class RowFields { public Int32Field NOAId; }

        [DisplayName("Noa Number"), Expression("jNoa.NOANumber"), LookupInclude]
        public String NoaNumber { get { return Fields.NoaNumber[this]; } set { Fields.NoaNumber[this] = value; } }
        public partial class RowFields { public StringField NoaNumber; }

        #endregion NOA

        #region Bank

        #region Is Bank Wise Payment Voucher?
        [NotMapped, DefaultValue(false), NotNull]
        public Boolean? IsBankWisePaymentVoucher { get { return Fields.IsBankWisePaymentVoucher[this]; } set { Fields.IsBankWisePaymentVoucher[this] = value; } }
        public partial class RowFields { public BooleanField IsBankWisePaymentVoucher; }
        #endregion IsBankWisePaymentVoucher

        #region Is Bank Wise Receipt Voucher?
        [NotMapped, DefaultValue(false), NotNull]
        public Boolean? IsBankWiseReceiptVoucher { get { return Fields.IsBankWiseReceiptVoucher[this]; } set { Fields.IsBankWiseReceiptVoucher[this] = value; } }
        public partial class RowFields { public BooleanField IsBankWiseReceiptVoucher; }
        #endregion IsBankWiseReceiptVoucher

        #region Bank Account Information
        [DisplayName("Bank Account"), Column("bankAccountInformationId"),
            ForeignKey("[dbo].[acc_BankAccountInformation]", "id"), LeftJoin("jBankAccountInformation"), TextualField("BankAccountInformationAccountDescription")]
        [LookupEditor("Configurations.AccBankAccountInformation_Lookup")]
        public Int32? BankAccountInformationId { get { return Fields.BankAccountInformationId[this]; } set { Fields.BankAccountInformationId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationId; }
        #endregion BankAccountInformationId

        #region Payto Or Recive From
        [DisplayName("Payto Or Recive From"), Column("paytoOrReciveFrom"), QuickSearch]
        public String PaytoOrReciveFrom { get { return Fields.PaytoOrReciveFrom[this]; } set { Fields.PaytoOrReciveFrom[this] = value; } }
        public partial class RowFields { public StringField PaytoOrReciveFrom; }
        #endregion PaytoOrReciveFrom

        #region Pay to For Bank Advice
        [NotMapped]
        public String PaytoForBankAdvice { get { return Fields.PaytoForBankAdvice[this]; } set { Fields.PaytoForBankAdvice[this] = value; } }
        public partial class RowFields { public StringField PaytoForBankAdvice; }
        #endregion PaytoForBankAdvice

        #region Cheque Register
        [DisplayName("Cheque Register"), Column("chequeRegisterId"),
            ForeignKey("[dbo].[acc_ChequeRegister]", "id"), LeftJoin("jChequeRegister"), TextualField("ChequeRegisterAmountInWords")]
        [LookupEditor("Transaction.AccChequeRegister_Lookup", InplaceAdd = true), LookupInclude, MinSelectLevel(SelectLevel.List)]
        public Int64? ChequeRegisterId { get { return Fields.ChequeRegisterId[this]; } set { Fields.ChequeRegisterId[this] = value; } }
        public partial class RowFields { public Int64Field ChequeRegisterId; }
        #endregion ChequeRegisterId

        #endregion

        #region Is Cheque Prepared
        [DisplayName("Is Cheque Prepared?"), Column("IsChequePrepared"), DefaultValue(false)]
        public Boolean? IsChequePrepared { get { return Fields.IsChequePrepared[this]; } set { Fields.IsChequePrepared[this] = value; } }
        public partial class RowFields { public BooleanField IsChequePrepared; }
        #endregion IsChequePrepared

        #region Cheque Prepared By
        [DisplayName("Cheque Prepared By"), Column("ChequePreparedBy")]
        public String ChequePreparedBy { get { return Fields.ChequePreparedBy[this]; } set { Fields.ChequePreparedBy[this] = value; } }
        public partial class RowFields { public StringField ChequePreparedBy; }
        #endregion ChequePreparedBy

        #region Posting Date
        [DisplayName("CHeque Prepared Date"), Column("ChequePrepareDate")]
        public DateTime? ChequePrepareDate { get { return Fields.ChequePrepareDate[this]; } set { Fields.ChequePrepareDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequePrepareDate; }
        #endregion PostingDate


        #region Foreign Fields

        [DisplayName("Sub Ledger"), Expression("jCostCentre.[code]")]
        public String CostCentreCode { get { return Fields.CostCentreCode[this]; } set { Fields.CostCentreCode[this] = value; } }
        public partial class RowFields { public StringField CostCentreCode; }


        [DisplayName("Sub Ledger Is Institute"), Expression("jCostCentre.[isInstitute]")]
        public Int16? CostCentreIsInstitute { get { return Fields.CostCentreIsInstitute[this]; } set { Fields.CostCentreIsInstitute[this] = value; } }
        public partial class RowFields { public Int16Field CostCentreIsInstitute; }


        [DisplayName("Sub Ledger"), Expression("jCostCentre.[name]")]
        public String CostCentreName { get { return Fields.CostCentreName[this]; } set { Fields.CostCentreName[this] = value; } }
        public partial class RowFields { public StringField CostCentreName; }


        [DisplayName("Sub Ledger Pa Ammount"), Expression("jCostCentre.[paAmmount]")]
        public Decimal? CostCentrePaAmmount { get { return Fields.CostCentrePaAmmount[this]; } set { Fields.CostCentrePaAmmount[this] = value; } }
        public partial class RowFields { public DecimalField CostCentrePaAmmount; }


        //[DisplayName("Sub Ledger Remarks"), Expression("jCostCentre.[remarks]")]
        //public String CostCentreRemarks { get { return Fields.CostCentreRemarks[this]; } set { Fields.CostCentreRemarks[this] = value; } }
        //public partial class RowFields { public StringField CostCentreRemarks; }


        [DisplayName("Sub Ledger Parent Id"), Expression("jCostCentre.[parentId]")]
        public Int32? CostCentreParentId { get { return Fields.CostCentreParentId[this]; } set { Fields.CostCentreParentId[this] = value; } }
        public partial class RowFields { public Int32Field CostCentreParentId; }


        [DisplayName("Sub Ledger Entity Id"), Expression("jCostCentre.[entityId]")]
        public Int32? CostCentreEntityId { get { return Fields.CostCentreEntityId[this]; } set { Fields.CostCentreEntityId[this] = value; } }
        public partial class RowFields { public Int32Field CostCentreEntityId; }


        [DisplayName("Cheque Register Amount"), Expression("jChequeRegister.[amount]")]
        public Decimal? ChequeRegisterAmount { get { return Fields.ChequeRegisterAmount[this]; } set { Fields.ChequeRegisterAmount[this] = value; } }
        public partial class RowFields { public DecimalField ChequeRegisterAmount; }


        [DisplayName("Cheque Register Amount In Words"), Expression("jChequeRegister.[amountInWords]")]
        public String ChequeRegisterAmountInWords { get { return Fields.ChequeRegisterAmountInWords[this]; } set { Fields.ChequeRegisterAmountInWords[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterAmountInWords; }


        [DisplayName("Cheque Register Cheque Date"), Expression("jChequeRegister.[chequeDate]")]
        public DateTime? ChequeRegisterChequeDate { get { return Fields.ChequeRegisterChequeDate[this]; } set { Fields.ChequeRegisterChequeDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeRegisterChequeDate; }


        [DisplayName("Cheque Register Cheque Issue Date"), Expression("jChequeRegister.[chequeIssueDate]")]
        public DateTime? ChequeRegisterChequeIssueDate { get { return Fields.ChequeRegisterChequeIssueDate[this]; } set { Fields.ChequeRegisterChequeIssueDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeRegisterChequeIssueDate; }


        [DisplayName("Cheque Register Cheque No"), Expression("jChequeRegister.[chequeNo]"), QuickSearch]
        public String ChequeRegisterChequeNo { get { return Fields.ChequeRegisterChequeNo[this]; } set { Fields.ChequeRegisterChequeNo[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterChequeNo; }


        [DisplayName("Cheque Register Cheque Type"), Expression("jChequeRegister.[chequeType]")]
        public String ChequeRegisterChequeType { get { return Fields.ChequeRegisterChequeType[this]; } set { Fields.ChequeRegisterChequeType[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterChequeType; }


        [DisplayName("Cheque Register Is Cancelled"), Expression("jChequeRegister.[isCancelled]")]
        public Int16? ChequeRegisterIsCancelled { get { return Fields.ChequeRegisterIsCancelled[this]; } set { Fields.ChequeRegisterIsCancelled[this] = value; } }
        public partial class RowFields { public Int16Field ChequeRegisterIsCancelled; }


        [DisplayName("Cheque Register Is Payment"), Expression("jChequeRegister.[isPayment]")]
        public Int16? ChequeRegisterIsPayment { get { return Fields.ChequeRegisterIsPayment[this]; } set { Fields.ChequeRegisterIsPayment[this] = value; } }
        public partial class RowFields { public Int16Field ChequeRegisterIsPayment; }


        [DisplayName("Cheque Register Is Used"), Expression("jChequeRegister.[isUsed]")]
        public Int16? ChequeRegisterIsUsed { get { return Fields.ChequeRegisterIsUsed[this]; } set { Fields.ChequeRegisterIsUsed[this] = value; } }
        public partial class RowFields { public Int16Field ChequeRegisterIsUsed; }


        [DisplayName("Cheque Register Pay To"), Expression("jChequeRegister.[payTo]")]
        public String ChequeRegisterPayTo { get { return Fields.ChequeRegisterPayTo[this]; } set { Fields.ChequeRegisterPayTo[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterPayTo; }


        [DisplayName("Cheque Register Payee Bank Name"), Expression("jChequeRegister.[payeeBankName]")]
        public String ChequeRegisterPayeeBankName { get { return Fields.ChequeRegisterPayeeBankName[this]; } set { Fields.ChequeRegisterPayeeBankName[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterPayeeBankName; }


        [DisplayName("Cheque Register Remarks"), Expression("jChequeRegister.[remarks]")]
        public String ChequeRegisterRemarks { get { return Fields.ChequeRegisterRemarks[this]; } set { Fields.ChequeRegisterRemarks[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterRemarks; }


        [DisplayName("Cheque Register Voucher No"), Expression("jChequeRegister.[voucherNo]")]
        public String ChequeRegisterVoucherNo { get { return Fields.ChequeRegisterVoucherNo[this]; } set { Fields.ChequeRegisterVoucherNo[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterVoucherNo; }


        [DisplayName("Cheque Register Bank Account Information Id"), Expression("jChequeRegister.[bankAccountInformation_id]")]
        public Int32? ChequeRegisterBankAccountInformationId { get { return Fields.ChequeRegisterBankAccountInformationId[this]; } set { Fields.ChequeRegisterBankAccountInformationId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeRegisterBankAccountInformationId; }


        [DisplayName("Cheque Register Voucher Information Id"), Expression("jChequeRegister.[voucherInformation_id]")]
        public Int32? ChequeRegisterVoucherInformationId { get { return Fields.ChequeRegisterVoucherInformationId[this]; } set { Fields.ChequeRegisterVoucherInformationId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeRegisterVoucherInformationId; }


        [DisplayName("Cheque Register Entity Id"), Expression("jChequeRegister.[entityId]")]
        public Int32? ChequeRegisterEntityId { get { return Fields.ChequeRegisterEntityId[this]; } set { Fields.ChequeRegisterEntityId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeRegisterEntityId; }


        [DisplayName("Cheque Register Cheque Book Id"), Expression("jChequeRegister.[chequeBook_id]")]
        public Int32? ChequeRegisterChequeBookId { get { return Fields.ChequeRegisterChequeBookId[this]; } set { Fields.ChequeRegisterChequeBookId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeRegisterChequeBookId; }


        //[DisplayName("Transaction Type Entity Remarks"), Expression("jTransactionTypeEntity.[remarks]")]
        //public String TransactionTypeEntityRemarks { get { return Fields.TransactionTypeEntityRemarks[this]; } set { Fields.TransactionTypeEntityRemarks[this] = value; } }
        //public partial class RowFields { public StringField TransactionTypeEntityRemarks; }


        //[DisplayName("Transaction Type Entity Sort Order"), Expression("jTransactionTypeEntity.[sortOrder]")]
        //public Int32? TransactionTypeEntitySortOrder { get { return Fields.TransactionTypeEntitySortOrder[this]; } set { Fields.TransactionTypeEntitySortOrder[this] = value; } }
        //public partial class RowFields { public Int32Field TransactionTypeEntitySortOrder; }


        [DisplayName("Transaction Type"), Expression("jTransactionTypeEntity.[transactionType]")]
        public String TransactionTypeEntityTransactionType { get { return Fields.TransactionTypeEntityTransactionType[this]; } set { Fields.TransactionTypeEntityTransactionType[this] = value; } }
        public partial class RowFields { public StringField TransactionTypeEntityTransactionType; }


        [DisplayName("Transaction Type Entity Fund Control Id"), Expression("jTransactionTypeEntity.[fundControlId]")]
        public Int32? TransactionTypeEntityFundControlId { get { return Fields.TransactionTypeEntityFundControlId[this]; } set { Fields.TransactionTypeEntityFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field TransactionTypeEntityFundControlId; }


        [DisplayName("Transaction Type Entity Voucher Type Id"), Expression("jTransactionTypeEntity.[voucherTypeId]")]
        public Int32? TransactionTypeEntityVoucherTypeId { get { return Fields.TransactionTypeEntityVoucherTypeId[this]; } set { Fields.TransactionTypeEntityVoucherTypeId[this] = value; } }
        public partial class RowFields { public Int32Field TransactionTypeEntityVoucherTypeId; }


        //[DisplayName("Bank Account Information Account Description"), Expression("jBankAccountInformation.[accountDescription]")]
        //public String BankAccountInformationAccountDescription { get { return Fields.BankAccountInformationAccountDescription[this]; } set { Fields.BankAccountInformationAccountDescription[this] = value; } }
        //public partial class RowFields { public StringField BankAccountInformationAccountDescription; }


        [DisplayName("Bank Account Information Account Name"), Expression("jBankAccountInformation.[accountName]")]
        public String BankAccountInformationAccountName { get { return Fields.BankAccountInformationAccountName[this]; } set { Fields.BankAccountInformationAccountName[this] = value; } }
        public partial class RowFields { public StringField BankAccountInformationAccountName; }


        [DisplayName("Bank Account Information Account Number"), Expression("jBankAccountInformation.[accountNumber]")]
        public String BankAccountInformationAccountNumber { get { return Fields.BankAccountInformationAccountNumber[this]; } set { Fields.BankAccountInformationAccountNumber[this] = value; } }
        public partial class RowFields { public StringField BankAccountInformationAccountNumber; }


        [DisplayName("Bank Account Information Code"), Expression("jBankAccountInformation.[code]")]
        public String BankAccountInformationCode { get { return Fields.BankAccountInformationCode[this]; } set { Fields.BankAccountInformationCode[this] = value; } }
        public partial class RowFields { public StringField BankAccountInformationCode; }


        [DisplayName("Bank Account Information Coa Id"), Expression("jBankAccountInformation.[COAId]")]
        public Int32? BankAccountInformationCoaId { get { return Fields.BankAccountInformationCoaId[this]; } set { Fields.BankAccountInformationCoaId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationCoaId; }


        [DisplayName("Bank Account Information Bank Id"), Expression("jBankAccountInformation.[bankId]")]
        [LookupEditor(typeof(Configurations.Entities.AccBankInformationRow))]
        public Int32? BankAccountInformationBankId { get { return Fields.BankAccountInformationBankId[this]; } set { Fields.BankAccountInformationBankId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationBankId; }


        [DisplayName("Bank Account Information Bank Branch Id"), Expression("jBankAccountInformation.[bankBranchId]")]
        public Int32? BankAccountInformationBankBranchId { get { return Fields.BankAccountInformationBankBranchId[this]; } set { Fields.BankAccountInformationBankBranchId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationBankBranchId; }


        [DisplayName("Bank Account Information Entity Id"), Expression("jBankAccountInformation.[entityId]")]
        public Int32? BankAccountInformationEntityId { get { return Fields.BankAccountInformationEntityId[this]; } set { Fields.BankAccountInformationEntityId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationEntityId; }


        [DisplayName("Posting Financial Year Is Active"), Expression("jPostingFinancialYear.[isActive]")]
        public Int16? PostingFinancialYearIsActive { get { return Fields.PostingFinancialYearIsActive[this]; } set { Fields.PostingFinancialYearIsActive[this] = value; } }
        public partial class RowFields { public Int16Field PostingFinancialYearIsActive; }


        [DisplayName("Posting Financial Year Is Closed"), Expression("jPostingFinancialYear.[isClosed]")]
        public Int16? PostingFinancialYearIsClosed { get { return Fields.PostingFinancialYearIsClosed[this]; } set { Fields.PostingFinancialYearIsClosed[this] = value; } }
        public partial class RowFields { public Int16Field PostingFinancialYearIsClosed; }


        [DisplayName("Posting Financial Year Period End Date"), Expression("jPostingFinancialYear.[periodEndDate]")]
        public DateTime? PostingFinancialYearPeriodEndDate { get { return Fields.PostingFinancialYearPeriodEndDate[this]; } set { Fields.PostingFinancialYearPeriodEndDate[this] = value; } }
        public partial class RowFields { public DateTimeField PostingFinancialYearPeriodEndDate; }


        [DisplayName("Posting Financial Year Period Start Date"), Expression("jPostingFinancialYear.[periodStartDate]")]
        public DateTime? PostingFinancialYearPeriodStartDate { get { return Fields.PostingFinancialYearPeriodStartDate[this]; } set { Fields.PostingFinancialYearPeriodStartDate[this] = value; } }
        public partial class RowFields { public DateTimeField PostingFinancialYearPeriodStartDate; }


        [DisplayName("Financial Year"), Expression("jPostingFinancialYear.[yearName]")]
        public String PostingFinancialYearYearName { get { return Fields.PostingFinancialYearYearName[this]; } set { Fields.PostingFinancialYearYearName[this] = value; } }
        public partial class RowFields { public StringField PostingFinancialYearYearName; }


        [DisplayName("Posting Financial Year Fund Control Information Id"), Expression("jPostingFinancialYear.[fundControlInformation_id]")]
        public Int32? PostingFinancialYearFundControlInformationId { get { return Fields.PostingFinancialYearFundControlInformationId[this]; } set { Fields.PostingFinancialYearFundControlInformationId[this] = value; } }
        public partial class RowFields { public Int32Field PostingFinancialYearFundControlInformationId; }


        [DisplayName("Fund Control Information Code"), Expression("jFundControlInformation.[code]")]
        public String FundControlInformationCode { get { return Fields.FundControlInformationCode[this]; } set { Fields.FundControlInformationCode[this] = value; } }
        public partial class RowFields { public StringField FundControlInformationCode; }

        //[DisplayName("Fund Control Information Employees"), Expression("jFundControlInformation.[employees]")]
        //public String FundControlInformationEmployees { get { return Fields.FundControlInformationEmployees[this]; } set { Fields.FundControlInformationEmployees[this] = value; } }
        //public partial class RowFields { public StringField FundControlInformationEmployees; }

        [DisplayName("Fund Control"), Expression("jFundControlInformation.[fundControlName]")]
        public String FundControlInformationFundControlName { get { return Fields.FundControlInformationFundControlName[this]; } set { Fields.FundControlInformationFundControlName[this] = value; } }
        public partial class RowFields { public StringField FundControlInformationFundControlName; }

        //[DisplayName("Fund Control Information Is Coa Mapped"), Expression("jFundControlInformation.[isCOAMapped]")]
        //public Int16? FundControlInformationIsCoaMapped { get { return Fields.FundControlInformationIsCoaMapped[this]; } set { Fields.FundControlInformationIsCoaMapped[this] = value; } }
        //public partial class RowFields { public Int16Field FundControlInformationIsCoaMapped; }


        //[DisplayName("Fund Control Information Sub Ledger"), Expression("jFundControlInformation.[costCenter]")]
        //public Int16? FundControlInformationCostCenter { get { return Fields.FundControlInformationCostCenter[this]; } set { Fields.FundControlInformationCostCenter[this] = value; } }
        //public partial class RowFields { public Int16Field FundControlInformationCostCenter; }


        //[DisplayName("Fund Control Information Project"), Expression("jFundControlInformation.[project]")]
        //public Int16? FundControlInformationProject { get { return Fields.FundControlInformationProject[this]; } set { Fields.FundControlInformationProject[this] = value; } }
        //public partial class RowFields { public Int16Field FundControlInformationProject; }

        [DisplayName("Fund Control Information Remarks"), Expression("jFundControlInformation.[remarks]")]
        public String FundControlInformationRemarks { get { return Fields.FundControlInformationRemarks[this]; } set { Fields.FundControlInformationRemarks[this] = value; } }
        public partial class RowFields { public StringField FundControlInformationRemarks; }


        [DisplayName("Zone Zone Name"), Expression("jZone.[ZoneName]")]
        public String ZoneZoneName { get { return Fields.ZoneZoneName[this]; } set { Fields.ZoneZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneZoneName; }


        //[DisplayName("Zone Zone Name In Bengali"), Expression("jZone.[ZoneNameInBengali]")]
        //public String ZoneZoneNameInBengali { get { return Fields.ZoneZoneNameInBengali[this]; } set { Fields.ZoneZoneNameInBengali[this] = value; } }
        //public partial class RowFields { public StringField ZoneZoneNameInBengali; }


        [DisplayName("Zone Zone Code"), Expression("jZone.[ZoneCode]")]
        public String ZoneZoneCode { get { return Fields.ZoneZoneCode[this]; } set { Fields.ZoneZoneCode[this] = value; } }
        public partial class RowFields { public StringField ZoneZoneCode; }

        [DisplayName("Voucher Type"), Expression("jVoucherType.[Name]")]
        public String VoucherTypeName { get { return Fields.VoucherTypeName[this]; } set { Fields.VoucherTypeName[this] = value; } }
        public partial class RowFields { public StringField VoucherTypeName; }

        [DisplayName("Action"), NotMapped]
        public String ApprovalAction { get { return Fields.ApprovalAction[this]; } set { Fields.ApprovalAction[this] = value; } }
        public partial class RowFields { public StringField ApprovalAction; }

        [DisplayName("Comments"), NotMapped]
        public String ApprovalComments { get { return Fields.ApprovalComments[this]; } set { Fields.ApprovalComments[this] = value; } }
        public partial class RowFields { public StringField ApprovalComments; }

        [DisplayName("Comments History"), NotMapped]
        public List<ApvApplicationInformationRow> ApplicationInformationHistory
        {
            get { return Fields.ApplicationInformationHistory[this]; }
            set { Fields.ApplicationInformationHistory[this] = value; }
        }
        public partial class RowFields { public RowListField<ApvApplicationInformationRow> ApplicationInformationHistory; }

        [DisplayName("Approver"), NotMapped]
        public Int32? ApproverId { get { return Fields.ApproverId[this]; } set { Fields.ApproverId[this] = value; } }
        public partial class RowFields { public Int32Field ApproverId; }

        //[DisplayName("TemplateId"), NotMapped]
        //public Int32? TemplateId { get { return Fields.TemplateId[this]; } set { Fields.TemplateId[this] = value; } }
        //public partial class RowFields { public Int32Field TemplateId; }
        [DisplayName("TemplateStatus"), NotMapped]
        public Int32? TemplateStatus { get { return Fields.TemplateStatus[this]; } set { Fields.TemplateStatus[this] = value; } }
        public partial class RowFields { public Int32Field TemplateStatus; }
        [DisplayName("TemplateCOAId"), NotMapped]
        public Int32? TemplateCOAId { get { return Fields.TemplateCOAId[this]; } set { Fields.TemplateCOAId[this] = value; } }
        public partial class RowFields { public Int32Field TemplateCOAId; }
        [DisplayName("TemplateChequeRegisterId"), NotMapped]
        public Int32? TemplateChequeRegisterId { get { return Fields.TemplateChequeRegisterId[this]; } set { Fields.TemplateChequeRegisterId[this] = value; } }
        public partial class RowFields { public Int32Field TemplateChequeRegisterId; }


        [DisplayName("Remain Amount"), NotMapped]
        public Decimal? RemainAmount { get { return Fields.RemainAmount[this]; } set { Fields.RemainAmount[this] = value; } }
        public partial class RowFields { public DecimalField RemainAmount; }

        [DisplayName("TemplateCOAId2"), NotMapped]
        public Int32? TemplateCOAId2 { get { return Fields.TemplateCOAId2[this]; } set { Fields.TemplateCOAId2[this] = value; } }
        public partial class RowFields { public Int32Field TemplateCOAId2; }

        #region Bank Information



        #endregion

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.AmountInWords; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccVoucherInformationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_voucher_information]")
            {
                LocalTextPrefix = "Transaction.AccVoucherInformation";
            }
        }
        #endregion RowFields

        #region NotMapped Properties
        [NotMapped]
        public string AutoJVVoucherNo { get { return Fields.AutoJVVoucherNo[this]; } set { Fields.AutoJVVoucherNo[this] = value; } }
        public partial class RowFields { public StringField AutoJVVoucherNo; }

        [NotMapped]
        public string AutoJVVoucherNumber { get { return Fields.AutoJVVoucherNumber[this]; } set { Fields.AutoJVVoucherNumber[this] = value; } }
        public partial class RowFields { public StringField AutoJVVoucherNumber; }

        [NotMapped]
        public Int32? TransactionTypeEntityIdForAutoJV { get { return Fields.TransactionTypeEntityIdForAutoJV[this]; } set { Fields.TransactionTypeEntityIdForAutoJV[this] = value; } }
        public partial class RowFields { public Int32Field TransactionTypeEntityIdForAutoJV; }

        [NotMapped]
        public Int32? AutoPV_AccountHead { get { return Fields.AutoPV_AccountHead[this]; } set { Fields.AutoPV_AccountHead[this] = value; } }
        public partial class RowFields { public Int32Field AutoPV_AccountHead; }

        [NotMapped]
        public Int32? AutoPV_CostCentreId { get { return Fields.AutoPV_CostCentreId[this]; } set { Fields.AutoPV_CostCentreId[this] = value; } }
        public partial class RowFields { public Int32Field AutoPV_CostCentreId; }

        [DisplayName("Min Amount"), NotMapped]
        public decimal? MinAmount { get { return Fields.MinAmount[this]; } set { Fields.MinAmount[this] = value; } }
        public partial class RowFields { public DecimalField MinAmount; }

        [DisplayName("Max Amount"), NotMapped]
        public decimal? MaxAmount { get { return Fields.MaxAmount[this]; } set { Fields.MaxAmount[this] = value; } }
        public partial class RowFields { public DecimalField MaxAmount; }

        [NotMapped]
        public byte[] PostingSing { get { return Fields.PostingSing[this]; } set { Fields.PostingSing[this] = value; } }
        public partial class RowFields { public ByteArrayField PostingSing; }

        [NotMapped]
        public byte[] PreparedSing { get { return Fields.PreparedSing[this]; } set { Fields.PreparedSing[this] = value; } }
        public partial class RowFields { public ByteArrayField PreparedSing; }

        [NotMapped]
        public byte[] CheckedSing { get { return Fields.CheckedSing[this]; } set { Fields.CheckedSing[this] = value; } }
        public partial class RowFields { public ByteArrayField CheckedSing; }

        [NotMapped]
        public byte[] ApprovedSing { get { return Fields.ApprovedSing[this]; } set { Fields.ApprovedSing[this] = value; } }
        public partial class RowFields { public ByteArrayField ApprovedSing; }

        [NotMapped]
        public string PostedEmployee { get { return Fields.PostedEmployee[this]; } set { Fields.PostedEmployee[this] = value; } }
        public partial class RowFields { public StringField PostedEmployee; }

        [NotMapped]
        public string PreparedEmployee { get { return Fields.PreparedEmployee[this]; } set { Fields.PreparedEmployee[this] = value; } }
        public partial class RowFields { public StringField PreparedEmployee; }

        [NotMapped]
        public string CheckedEmployee { get { return Fields.CheckedEmployee[this]; } set { Fields.CheckedEmployee[this] = value; } }
        public partial class RowFields { public StringField CheckedEmployee; }

        [NotMapped]
        public string ApprovedEmployee { get { return Fields.ApprovedEmployee[this]; } set { Fields.ApprovedEmployee[this] = value; } }
        public partial class RowFields { public StringField ApprovedEmployee; }

        [DisplayName("Regret To"), NotMapped]
        public Int32? RegretSendTo { get { return Fields.RegretSendTo[this]; } set { Fields.RegretSendTo[this] = value; } }
        public partial class RowFields { public Int32Field RegretSendTo; }

        #region Cheque Issue Information
        //

        #region Bank Account Information
        [DisplayName("Bank Account"), Column("AccountHeadBankCash")]
        public Int32? AccountHeadBankCash { get { return Fields.AccountHeadBankCash[this]; } set { Fields.AccountHeadBankCash[this] = value; } }
        public partial class RowFields { public Int32Field AccountHeadBankCash; }
        #endregion AccountHeadBankCash

        #region Cheque Book
        [DisplayName("Cheque Book {A/C No.}"), NotMapped]
        [LookupEditor(typeof(Transaction.Entities.AccChequeBookRow),
            FilterField = nameof(AccChequeBookRow.HasFinished), FilterValue = false,
            CascadeFrom = "BankAccountInformationId")
            ]
        //[LookupEditor(typeof(Repositories.DemoLookup))]
        public Int32? ChequeBookId { get { return Fields.ChequeBookId[this]; } set { Fields.ChequeBookId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeBookId; }
        #endregion ChequeBookId

        #region Cheque Number - Hidden
        [DisplayName("Cheque No"), NotMapped]
        public Int32? ChequeNumhdn { get { return Fields.ChequeNumhdn[this]; } set { Fields.ChequeNumhdn[this] = value; } }
        public partial class RowFields { public Int32Field ChequeNumhdn; }
        #endregion ChequeNumhdn

        #region Cheque No
        [NotMapped]
        public String ChequeNo { get { return Fields.ChequeNo[this]; } set { Fields.ChequeNo[this] = value; } }
        public partial class RowFields { public StringField ChequeNo; }
        #endregion ChequeNo

        #region optional field used for update cheque book
        [NotMapped]
        public Boolean? IsChequeFinished { get { return Fields.IsChequeFinished[this]; } set { Fields.IsChequeFinished[this] = value; } }
        public partial class RowFields { public BooleanField IsChequeFinished; }
        #endregion IsChequeFinished

        #region Cheque Type
        [DisplayName("Cheque Type"), NotMapped]
        public String ChequeType { get { return Fields.ChequeType[this]; } set { Fields.ChequeType[this] = value; } }
        public partial class RowFields { public StringField ChequeType; }
        #endregion ChequeType

        #region Cheque Date
        [DisplayName("Cheque Date"), NotMapped, DefaultValue("now")]
        public DateTime? ChequeDate { get { return Fields.ChequeDate[this]; } set { Fields.ChequeDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeDate; }
        #endregion ChequeDate

        #region Cheque Remarks
        [DisplayName("Remarks"), Column("ChequeRemarks"), DefaultValue("--")]
        public String ChequeRemarks { get { return Fields.ChequeRemarks[this]; } set { Fields.ChequeRemarks[this] = value; } }
        public partial class RowFields { public StringField ChequeRemarks; }
        #endregion ChequeRemarks

        #region Bank Amount
        [DisplayName("Bank Amount"), NotMapped]
        public Decimal? BankAmount { get { return Fields.BankAmount[this]; } set { Fields.BankAmount[this] = value; } }
        public partial class RowFields { public DecimalField BankAmount; }
        #endregion BankAmount

        //
        #endregion



        #endregion


    }
}

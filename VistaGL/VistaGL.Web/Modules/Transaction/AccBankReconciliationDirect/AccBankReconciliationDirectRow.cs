using VistaGL.Modules.Common;

namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Bank Reconciliation"), InstanceName("Bank Reconciliation"), TwoLevelCached]
    [ReadPermission("Transaction:AccBankReconciliationDirect:Read")]
    [InsertPermission("Transaction:AccBankReconciliationDirect:Insert")]
    [UpdatePermission("Transaction:AccBankReconciliationDirect:Update")]
    [DeletePermission("Transaction:AccBankReconciliationDirect:Delete")]
    [LookupScript("Transaction.AccBankReconciliationDirect", Permission = "?")]
    public sealed class AccBankReconciliationDirectRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Amount
        [DisplayName("Amount"), Column("amount"), NotNull, QuickSearch]
        public Decimal? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DecimalField Amount; }
        #endregion Amount

        #region Cheque Date
        [DisplayName("Cheque Date"), Column("chequeDate"), QuickSearch]
        public DateTime? ChequeDate { get { return Fields.ChequeDate[this]; } set { Fields.ChequeDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeDate; }
        #endregion ChequeDate

        #region Cheque No
        [DisplayName("Cheque No"), Column("chequeNo"), Size(50), QuickSearch]
        public String ChequeNo { get { return Fields.ChequeNo[this]; } set { Fields.ChequeNo[this] = value; } }
        public partial class RowFields { public StringField ChequeNo; }
        #endregion ChequeNo

        #region Clear Date
        [DisplayName("Clear Date"), Column("clearDate")]
        public DateTime? ClearDate { get { return Fields.ClearDate[this]; } set { Fields.ClearDate[this] = value; } }
        public partial class RowFields { public DateTimeField ClearDate; }
        #endregion ClearDate

        #region Description
        [DisplayName("Description"), Column("description"), Size(300), QuickSearch]
        public String Description { get { return Fields.Description[this]; } set { Fields.Description[this] = value; } }
        public partial class RowFields { public StringField Description; }
        #endregion Description

        #region Is Bank Reconcile
        [DisplayName("Is Bank Reconcile"), Column("isBankReconcile"), Expression("( CASE WHEN t0.ClearDate IS NOT NULL THEN 1 ELSE 0 END )")]
        public Boolean? IsBankReconcile { get { return Fields.IsBankReconcile[this]; } set { Fields.IsBankReconcile[this] = value; } }
        public partial class RowFields { public BooleanField IsBankReconcile; }
        #endregion IsBankReconcile

        #region Is Cash
        [DisplayName("Is Cash"), Column("isCash")]
        public Boolean? IsCash { get { return Fields.IsCash[this]; } set { Fields.IsCash[this] = value; } }
        public partial class RowFields { public BooleanField IsCash; }
        #endregion IsCash

        #region Payto Or Recive From
        [DisplayName("Payto Or Recive From"), Column("paytoOrReciveFrom"), Size(250)]
        public String PaytoOrReciveFrom { get { return Fields.PaytoOrReciveFrom[this]; } set { Fields.PaytoOrReciveFrom[this] = value; } }
        public partial class RowFields { public StringField PaytoOrReciveFrom; }
        #endregion PaytoOrReciveFrom

        #region Transaction Mode
        [DisplayName("Transaction Mode"), Column("transactionMode"), Size(20)]
        public String TransactionMode { get { return Fields.TransactionMode[this]; } set { Fields.TransactionMode[this] = value; } }
        public partial class RowFields { public StringField TransactionMode; }
        #endregion TransactionMode

        #region Transaction Type
        [DisplayName("Transaction Type"), Column("transactionType"), Size(20), NotNull, QuickSearch]
        public String TransactionType { get { return Fields.TransactionType[this]; } set { Fields.TransactionType[this] = value; } }
        public partial class RowFields { public StringField TransactionType; }
        #endregion TransactionType

        #region Voucher Date
        [DisplayName("Voucher Date"), Column("voucherDate"), QuickSearch]
        public DateTime? VoucherDate { get { return Fields.VoucherDate[this]; } set { Fields.VoucherDate[this] = value; } }
        public partial class RowFields { public DateTimeField VoucherDate; }
        #endregion VoucherDate

        #region Voucher Number
        [DisplayName("Voucher Number"), Column("voucherNumber"), Size(150), QuickSearch]
        public String VoucherNumber { get { return Fields.VoucherNumber[this]; } set { Fields.VoucherNumber[this] = value; } }
        public partial class RowFields { public StringField VoucherNumber; }
        #endregion VoucherNumber

        #region Fund Control Information
        [DisplayName("Fund Control Information"), Column("fundControlInformationId"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControlInformation"), TextualField("FundControlInformationCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
        public Int32? FundControlInformationId { get { return Fields.FundControlInformationId[this]; } set { Fields.FundControlInformationId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlInformationId; }
        #endregion FundControlInformationId

        #region Bank Account Information
        [DisplayName("Bank Account Information"), Column("bankAccountInformationId"),NotNull, ForeignKey("[dbo].[acc_BankAccountInformation]", "id"), LeftJoin("jBankAccountInformation"), TextualField("BankAccountInformationAccountDescription")]
        [LookupEditor(typeof(Configurations.Entities.AccBankAccountInformationRow))]
        public Int32? BankAccountInformationId { get { return Fields.BankAccountInformationId[this]; } set { Fields.BankAccountInformationId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationId; }
        #endregion BankAccountInformationId

        #region Zone Info
        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        //[LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region Voucher Detail
        // [DisplayName("Voucher Detail"), NotNull, ForeignKey("[dbo].[acc_voucher_details]", "id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        //[LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int64? VoucherDetailId { get { return Fields.VoucherDetailId[this]; } set { Fields.VoucherDetailId[this] = value; } }
        public partial class RowFields { public Int64Field VoucherDetailId; }
        #endregion VoucherDetailId


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
        public AccBankReconciliationDirectRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_bank_reconciliation_direct]")
            {
                LocalTextPrefix = "Transaction.AccBankReconciliationDirect";
            }
        }
        #endregion RowFields
    }
}

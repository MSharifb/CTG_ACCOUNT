
using VistaGL.Modules.Common;

namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Money Receipt"), InstanceName("Money Receipt"), TwoLevelCached]
    [ReadPermission("Transaction:AccMoneyReceipt:Read")]
    [InsertPermission("Transaction:AccMoneyReceipt:Insert")]
    [UpdatePermission("Transaction:AccMoneyReceipt:Update")]
    [DeletePermission("Transaction:AccMoneyReceipt:Delete")]
    [LookupScript("Transaction.AccMoneyReceipt", Permission = "?")]
    public sealed class AccMoneyReceiptRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int64? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int64Field Id; }
        #endregion Id

        #region Monry Receipt Date
        [DisplayName("Date"), NotNull]
        public DateTime? MonryReceiptDate { get { return Fields.MonryReceiptDate[this]; } set { Fields.MonryReceiptDate[this] = value; } }
        public partial class RowFields { public DateTimeField MonryReceiptDate; }
        #endregion MonryReceiptDate

        #region Amount
        [DisplayName("Amount"), Size(18), Scale(2), NotNull, QuickSearch()]
        public Decimal? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DecimalField Amount; }
        #endregion Amount

        #region Amount In Word
        [DisplayName("Amount In Word"), Size(-1), NotNull]
        public String AmountInWord { get { return Fields.AmountInWord[this]; } set { Fields.AmountInWord[this] = value; } }
        public partial class RowFields { public StringField AmountInWord; }
        #endregion AmountInWord

        #region Narration
        [DisplayName("Narration/Purpose"), Size(-1), NotNull, QuickSearch()]
        public String Narration { get { return Fields.Narration[this]; } set { Fields.Narration[this] = value; } }
        public partial class RowFields { public StringField Narration; }
        #endregion Narration

        [DisplayName("Cheque Receive Register"), ForeignKey("[dbo].[acc_cheque_receive_register]", "id"), LeftJoin("jChequeReceiveRegister"), TextualField("ChequeReceiveRegisterAccountName")]
        public Int64? ChequeReceiveRegisterId { get { return Fields.ChequeReceiveRegisterId[this]; } set { Fields.ChequeReceiveRegisterId[this] = value; } }
        public partial class RowFields { public Int64Field ChequeReceiveRegisterId; }


        [DisplayName("Chq./DD/PO Type"), Expression("jChequeReceiveRegister.[receiveType]"), NotNull]
        [RecChequeTypeMappingEditor]
        public String ChequeType { get { return Fields.ChequeType[this]; } set { Fields.ChequeType[this] = value; } }

        [DisplayName("Chq./DD/PO Date"), Expression("jChequeReceiveRegister.[chequeDate]"), NotNull]
        public DateTime? ChequeDate { get { return Fields.ChequeDate[this]; } set { Fields.ChequeDate[this] = value; } }

        [DisplayName("Cheque No"), Expression("jChequeReceiveRegister.[chequeNo]"), NotNull]
        public String ChequeNo { get { return Fields.ChequeNo[this]; } set { Fields.ChequeNo[this] = value; } }

        [DisplayName("Sl. No."),MaxLength(50), QuickSearch()]
        public String SerialNo { get { return Fields.SerialNo[this]; } set { Fields.SerialNo[this] = value; } }
        public partial class RowFields { public StringField SerialNo; }
        
        [DisplayName("Receive From")]
        public String ReceiveFrom { get { return Fields.ReceiveFrom[this]; } set { Fields.ReceiveFrom[this] = value; } }
        public partial class RowFields { public StringField ReceiveFrom; }

        #region Acc Head Bank Id
        [DisplayName("Account Head Bank"), NotNull, LookupInclude]
        [ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoaBank"), TextualField("AccHeadBankName")]
        public Int32? AccHeadBankId { get { return Fields.AccHeadBankId[this]; } set { Fields.AccHeadBankId[this] = value; } }
        public partial class RowFields { public Int32Field AccHeadBankId; }
        #endregion AccHeadBankId

        [Expression("jCoaBank.[accountName]"), DisplayName("Account Head Bank")]
        public String AccHeadBankName { get { return Fields.AccHeadBankName[this]; } set { Fields.AccHeadBankName[this] = value; } }
        public partial class RowFields { public StringField AccHeadBankName; }


        #region Is Cancelled
        [DisplayName("Is Cancelled"), NotNull]
        public Boolean? IsCancelled { get { return Fields.IsCancelled[this]; } set { Fields.IsCancelled[this] = value; } }
        public partial class RowFields { public BooleanField IsCancelled; }
        #endregion IsCancelled

        #region Is Used
        [DisplayName("Is Used"), NotNull]
        public Boolean? IsUsed { get { return Fields.IsUsed[this]; } set { Fields.IsUsed[this] = value; } }
        public partial class RowFields { public BooleanField IsUsed; }
        #endregion IsUsed

        #region Voucher Id
        [DisplayName("Voucher Id"), ForeignKey("dbo.acc_Voucher_Information", "Id"), LeftJoin("jVoucher"), TextualField("VoucherNo")]
        public Int64? VoucherId { get { return Fields.VoucherId[this]; } set { Fields.VoucherId[this] = value; } }
        public partial class RowFields { public Int64Field VoucherId; }


        [DisplayName("Voucher No"), Expression("jVoucher.VoucherNo")]
        public String VoucherNo { get { return Fields.VoucherNo[this]; } set { Fields.VoucherNo[this] = value; } }
        public partial class RowFields { public StringField VoucherNo; }
        #endregion VoucherId

        #region Entity Id
        [DisplayName("Entity Id"), NotNull]
        public Int32? EntityId { get { return Fields.EntityId[this]; } set { Fields.EntityId[this] = value; } }
        public partial class RowFields { public Int32Field EntityId; }
        #endregion EntityId

        #region Zone Info Id
        [DisplayName("Zone Info Id"), NotNull]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region Money Receipt Number
        [DisplayName("Money Receipt No"), Column("MoneyReceiptNo")]
        public String MoneyReceiptNo { get { return Fields.MoneyReceiptNo[this]; } set { Fields.MoneyReceiptNo[this] = value; } }
        public partial class RowFields { public StringField MoneyReceiptNo; }
        #endregion  Money Receipt Number

        [DisplayName("Dollar($)")]
        public Decimal? Dollar { get { return Fields.Dollar[this]; } set { Fields.Dollar[this] = value; } }
        public partial class RowFields { public DecimalField Dollar; }

        [DisplayName("Is Confirmed"), NotNull, DefaultValue(false)]
        public Boolean? IsConfirmed { get { return Fields.IsConfirmed[this]; } set { Fields.IsConfirmed[this] = value; } }
        public partial class RowFields { public BooleanField IsConfirmed; }

        [DisplayName("Voucher Date"), NotMapped]
        public DateTime? CreditVoucherDate { get { return Fields.CreditVoucherDate[this]; } set { Fields.CreditVoucherDate[this] = value; } }
        public partial class RowFields { public DateTimeField CreditVoucherDate; }

        [DisplayName("Voucher Narration"), NotMapped]
        public String CreditVoucherNarration { get { return Fields.CreditVoucherNarration[this]; } set { Fields.CreditVoucherNarration[this] = value; } }
        public partial class RowFields { public StringField CreditVoucherNarration; }

        #region Money Receipt Details
        [DisplayName("Money Receipt Details"), MasterDetailRelation(foreignKey: "MoneyReceiptId"), MinSelectLevel(SelectLevel.Auto), NotMapped]
        public List<AccMoneyReceiptDatailsRow> AccMoneyReceiptDatailsList
        {
            get { return Fields.AccMoneyReceiptDatailsList[this]; }
            set { Fields.AccMoneyReceiptDatailsList[this] = value; }
        }
        public partial class RowFields { public RowListField<AccMoneyReceiptDatailsRow> AccMoneyReceiptDatailsList; }
        #endregion



        #region Foreign Fields

        [DisplayName("Voucher No."), Expression("jVoucher.[voucherNo]")]
        public String VouchervoucherNo { get { return Fields.VouchervoucherNo[this]; } set { Fields.VouchervoucherNo[this] = value; } }

        [DisplayName("Cheque Receive Register Account Name"), Expression("jChequeReceiveRegister.[accountName]")]
        public String ChequeReceiveRegisterAccountName { get { return Fields.ChequeReceiveRegisterAccountName[this]; } set { Fields.ChequeReceiveRegisterAccountName[this] = value; } }

        [DisplayName("Cheque Receive Register Account No"), Expression("jChequeReceiveRegister.[accountNo]")]
        public String ChequeReceiveRegisterAccountNo { get { return Fields.ChequeReceiveRegisterAccountNo[this]; } set { Fields.ChequeReceiveRegisterAccountNo[this] = value; } }

        [DisplayName("Cheque Receive Register Amount"), Expression("jChequeReceiveRegister.[amount]")]
        public Decimal? ChequeReceiveRegisterAmount { get { return Fields.ChequeReceiveRegisterAmount[this]; } set { Fields.ChequeReceiveRegisterAmount[this] = value; } }

        [DisplayName("Cheque Receive Register Amount In Words"), Expression("jChequeReceiveRegister.[amountInWords]")]
        public String ChequeReceiveRegisterAmountInWords { get { return Fields.ChequeReceiveRegisterAmountInWords[this]; } set { Fields.ChequeReceiveRegisterAmountInWords[this] = value; } }

        [DisplayName("Cheque Receive Register Bank Name"), Expression("jChequeReceiveRegister.[bankName]")]
        public String ChequeReceiveRegisterBankName { get { return Fields.ChequeReceiveRegisterBankName[this]; } set { Fields.ChequeReceiveRegisterBankName[this] = value; } }

        [DisplayName("Cheque Receive Register Branch Name"), Expression("jChequeReceiveRegister.[branchName]")]
        public String ChequeReceiveRegisterBranchName
        { get { return Fields.ChequeReceiveRegisterBranchName[this]; } set { Fields.ChequeReceiveRegisterBranchName[this] = value; } }

        [DisplayName("Cheque Receive Register Cheque Receive Date"), Expression("jChequeReceiveRegister.[chequeReceiveDate]")]
        public DateTime? ChequeReceiveRegisterChequeReceiveDate
        { get { return Fields.ChequeReceiveRegisterChequeReceiveDate[this]; } set { Fields.ChequeReceiveRegisterChequeReceiveDate[this] = value; } }


        [DisplayName("Cheque Receive Register Is Cancelled"), Expression("jChequeReceiveRegister.[isCancelled]")]
        public Boolean? ChequeReceiveRegisterIsCancelled { get { return Fields.ChequeReceiveRegisterIsCancelled[this]; } set { Fields.ChequeReceiveRegisterIsCancelled[this] = value; } }

        [DisplayName("Cheque Receive Register Is Used"), Expression("jChequeReceiveRegister.[isUsed]")]
        public Boolean? ChequeReceiveRegisterIsUsed { get { return Fields.ChequeReceiveRegisterIsUsed[this]; } set { Fields.ChequeReceiveRegisterIsUsed[this] = value; } }

        [DisplayName("Cheque Receive Register Receive Type"), Expression("jChequeReceiveRegister.[receiveType]")]
        public String ChequeReceiveRegisterReceiveType { get { return Fields.ChequeReceiveRegisterReceiveType[this]; } set { Fields.ChequeReceiveRegisterReceiveType[this] = value; } }

        [DisplayName("Cheque Receive Register Remarks"), Expression("jChequeReceiveRegister.[remarks]")]
        public String ChequeReceiveRegisterRemarks { get { return Fields.ChequeReceiveRegisterRemarks[this]; } set { Fields.ChequeReceiveRegisterRemarks[this] = value; } }

        [DisplayName("Cheque Receive Register Recieve From"), Expression("jChequeReceiveRegister.[recieveFrom]")]
        public String ChequeReceiveRegisterRecieveFrom { get { return Fields.ChequeReceiveRegisterRecieveFrom[this]; } set { Fields.ChequeReceiveRegisterRecieveFrom[this] = value; } }

        [DisplayName("Cheque Receive Register Entity Id"), Expression("jChequeReceiveRegister.[entityId]")]
        public Int32? ChequeReceiveRegisterEntityId { get { return Fields.ChequeReceiveRegisterEntityId[this]; } set { Fields.ChequeReceiveRegisterEntityId[this] = value; } }

        [DisplayName("Cheque Receive Register Zone Info Id"), Expression("jChequeReceiveRegister.[ZoneInfoId]")]
        public Int32? ChequeReceiveRegisterZoneInfoId { get { return Fields.ChequeReceiveRegisterZoneInfoId[this]; } set { Fields.ChequeReceiveRegisterZoneInfoId[this] = value; } }

        public partial class RowFields { public StringField ChequeReceiveRegisterAccountName; }
        public partial class RowFields { public StringField ChequeReceiveRegisterAccountNo; }
        public partial class RowFields { public DecimalField ChequeReceiveRegisterAmount; }
        public partial class RowFields { public StringField ChequeReceiveRegisterAmountInWords; }
        public partial class RowFields { public StringField ChequeReceiveRegisterBankName; }
        public partial class RowFields { public StringField ChequeReceiveRegisterBranchName; }
        public partial class RowFields { public DateTimeField ChequeDate; }
        public partial class RowFields { public StringField ChequeNo; }
        public partial class RowFields { public DateTimeField ChequeReceiveRegisterChequeReceiveDate; }
        public partial class RowFields { public StringField ChequeType; }
        public partial class RowFields { public BooleanField ChequeReceiveRegisterIsCancelled; }
        public partial class RowFields { public BooleanField ChequeReceiveRegisterIsUsed; }
        public partial class RowFields { public StringField ChequeReceiveRegisterReceiveType; }
        public partial class RowFields { public StringField ChequeReceiveRegisterRemarks; }
        public partial class RowFields { public StringField ChequeReceiveRegisterRecieveFrom; }
        public partial class RowFields { public Int32Field ChequeReceiveRegisterEntityId; }
        public partial class RowFields { public Int32Field ChequeReceiveRegisterZoneInfoId; }
        public partial class RowFields { public StringField VouchervoucherNo; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.AmountInWord; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccMoneyReceiptRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public const string TableName = "[dbo].[acc_MoneyReceipt]";

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_MoneyReceipt]")
            {
                LocalTextPrefix = "Transaction.AccMoneyReceipt";
            }
        }
        #endregion RowFields
    }
}

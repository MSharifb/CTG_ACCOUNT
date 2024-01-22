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

    [ConnectionKey("ACCDB"), DisplayName("Bill Ref. Information"), InstanceName("Bill Ref. Information"), TwoLevelCached]
    //[ReadPermission("Transaction:acc_voucher_dtl_bill_ref:Read")]
    //[InsertPermission("Transaction:acc_voucher_dtl_bill_ref:Insert")]
    //[UpdatePermission("Transaction:acc_voucher_dtl_bill_ref:Update")]
    //[DeletePermission("Transaction:acc_voucher_dtl_bill_ref:Delete")]
    [LookupScript("Transaction.AccVoucherDtlBillRefRow", Permission = "?")]
    public sealed class AccVoucherDtlBillRefRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Amount
        [DisplayName("Amount"), Column("amount")]
        public Double? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DoubleField Amount; }
        #endregion Amount

        #region Bill Date
        [DisplayName("Bill Date"), Column("billDate"), DefaultValue("now")]
        public DateTime? BillDate { get { return Fields.BillDate[this]; } set { Fields.BillDate[this] = value; } }
        public partial class RowFields { public DateTimeField BillDate; }
        #endregion BillDate

        #region Bill Ref No
        [DisplayName("Bill Ref No"), Column("billRefNo"), Size(50), QuickSearch]
        public String BillRefNo { get { return Fields.BillRefNo[this]; } set { Fields.BillRefNo[this] = value; } }
        public partial class RowFields { public StringField BillRefNo; }
        #endregion BillRefNo

        #region Bill Type
        [DisplayName("Bill Type"), Column("billType"), Size(10)]
        public String BillType { get { return Fields.BillType[this]; } set { Fields.BillType[this] = value; } }
        public partial class RowFields { public StringField BillType; }
        #endregion BillType

        #region Description
        [DisplayName("Description"), Column("description"), Size(255)]
        public String Description { get { return Fields.Description[this]; } set { Fields.Description[this] = value; } }
        public partial class RowFields { public StringField Description; }
        #endregion Description

        #region Is Payment Complete
        [DisplayName("Is Payment Complete"), Column("isPaymentComplete")]
        public Int16? IsPaymentComplete { get { return Fields.IsPaymentComplete[this]; } set { Fields.IsPaymentComplete[this] = value; } }
        public partial class RowFields { public Int16Field IsPaymentComplete; }
        #endregion IsPaymentComplete

        #region Voucher Detail
        [DisplayName("Voucher Detail"), Column("voucherDetailId"), NotNull, ForeignKey("[dbo].[acc_voucher_details]", "id"), LeftJoin("jVoucherDetail"), TextualField("VoucherDetailDescription")]
        [LookupEditor(typeof(Transaction.Entities.AccVoucherDetailsRow), InplaceAdd = true)]
        public Int64? VoucherDetailId { get { return Fields.VoucherDetailId[this]; } set { Fields.VoucherDetailId[this] = value; } }
        public partial class RowFields { public Int64Field VoucherDetailId; }
        #endregion VoucherDetailId


        #region Foreign Fields

        [DisplayName("Voucher Detail Credit Amount"), Expression("jVoucherDetail.[creditAmount]")]
        public Double? VoucherDetailCreditAmount { get { return Fields.VoucherDetailCreditAmount[this]; } set { Fields.VoucherDetailCreditAmount[this] = value; } }
        public partial class RowFields { public DoubleField VoucherDetailCreditAmount; }


        [DisplayName("Voucher Detail Debit Amount"), Expression("jVoucherDetail.[debitAmount]")]
        public Double? VoucherDetailDebitAmount { get { return Fields.VoucherDetailDebitAmount[this]; } set { Fields.VoucherDetailDebitAmount[this] = value; } }
        public partial class RowFields { public DoubleField VoucherDetailDebitAmount; }


        [DisplayName("Voucher Detail Description"), Expression("jVoucherDetail.[description]")]
        public String VoucherDetailDescription { get { return Fields.VoucherDetailDescription[this]; } set { Fields.VoucherDetailDescription[this] = value; } }
        public partial class RowFields { public StringField VoucherDetailDescription; }


        [DisplayName("Voucher Detail Is Payor Receive Head"), Expression("jVoucherDetail.[isPayorReceiveHead]")]
        public Int16? VoucherDetailIsPayorReceiveHead { get { return Fields.VoucherDetailIsPayorReceiveHead[this]; } set { Fields.VoucherDetailIsPayorReceiveHead[this] = value; } }
        public partial class RowFields { public Int16Field VoucherDetailIsPayorReceiveHead; }


        [DisplayName("Voucher Detail Chartof Accounts Id"), Expression("jVoucherDetail.[chartofAccountsId]")]
        public Int32? VoucherDetailChartofAccountsId { get { return Fields.VoucherDetailChartofAccountsId[this]; } set { Fields.VoucherDetailChartofAccountsId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherDetailChartofAccountsId; }


        [DisplayName("Voucher Detail Voucher Information Id"), Expression("jVoucherDetail.[voucherInformationId]")]
        public Int32? VoucherDetailVoucherInformationId { get { return Fields.VoucherDetailVoucherInformationId[this]; } set { Fields.VoucherDetailVoucherInformationId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherDetailVoucherInformationId; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.BillRefNo; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccVoucherDtlBillRefRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_voucher_dtl_bill_ref]")
            {
                LocalTextPrefix = "Transaction.AccVoucherDtlBillRef";
            }
        }
        #endregion RowFields
    }
}

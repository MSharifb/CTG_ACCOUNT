using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Transaction Type"), InstanceName("Transaction Type"), TwoLevelCached]
    [ReadPermission("Configurations:AccTransactionType:Read")]
    [InsertPermission("Configurations:AccTransactionType:Insert")]
    [UpdatePermission("Configurations:AccTransactionType:Update")]
    [DeletePermission("Configurations:AccTransactionType:Delete")]
    [LookupScript("Configurations.AccTransactionType", Permission = "?")]
    public sealed class AccTransactionTypeRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Remarks
        [DisplayName("Remarks"), Column("remarks"), Size(255), QuickSearch]
        public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
        public partial class RowFields { public StringField Remarks; }
        #endregion Remarks

        #region Sort Order
        [DisplayName("Sort Order"), Column("sortOrder"), SortOrder(1)]
        public Int32? SortOrder { get { return Fields.SortOrder[this]; } set { Fields.SortOrder[this] = value; } }
        public partial class RowFields { public Int32Field SortOrder; }
        #endregion SortOrder

        #region Transaction Type
        [DisplayName("Transaction Type"), Column("transactionType"), Size(100), NotNull]
        public String TransactionType { get { return Fields.TransactionType[this]; } set { Fields.TransactionType[this] = value; } }
        public partial class RowFields { public StringField TransactionType; }
        #endregion TransactionType

        #region Fund Control
        [DisplayName("Fund Control"), Column("fundControlId"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControl"), TextualField("FundControlCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
        public Int32? FundControlId { get { return Fields.FundControlId[this]; } set { Fields.FundControlId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlId; }
        #endregion FundControlId

        #region Voucher Type
        [DisplayName("Voucher Type"), Column("voucherTypeId"), NotNull, ForeignKey("[dbo].[acc_voucher_type]", "id"), LeftJoin("jVoucherType"), TextualField("VoucherTypeName")]
        [LookupEditor(typeof(Configurations.Entities.AccVoucherTypeRow)), LookupInclude]
        public Int32? VoucherTypeId { get { return Fields.VoucherTypeId[this]; } set { Fields.VoucherTypeId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherTypeId; }
        #endregion VoucherTypeId

        #region Transaction Mode
        [DisplayName("Transaction Mode"), Column("transactionMode"), Size(50), NotNull]
        public String TransactionMode { get { return Fields.TransactionMode[this]; } set { Fields.TransactionMode[this] = value; } }
        public partial class RowFields { public StringField TransactionMode; }
        #endregion TransactionMode

        #region Is Default
        [DisplayName("Is Default"), Column("isbyDefault"), LookupInclude]
        public Boolean? IsbyDefault { get { return Fields.IsbyDefault[this]; } set { Fields.IsbyDefault[this] = value; } }
        public partial class RowFields { public BooleanField IsbyDefault; }
        #endregion

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


        [DisplayName("Voucher Type"), Expression("jVoucherType.[name]")]
        public String VoucherTypeName { get { return Fields.VoucherTypeName[this]; } set { Fields.VoucherTypeName[this] = value; } }
        public partial class RowFields { public StringField VoucherTypeName; }


        [DisplayName("Voucher Type Sort Order"), Expression("jVoucherType.[sortOrder]")]
        public Int32? VoucherTypeSortOrder { get { return Fields.VoucherTypeSortOrder[this]; } set { Fields.VoucherTypeSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field VoucherTypeSortOrder; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TransactionType; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccTransactionTypeRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_transaction_type]")
            {
                LocalTextPrefix = "Configurations.AccTransactionType";
            }
        }
        #endregion RowFields
    }
}

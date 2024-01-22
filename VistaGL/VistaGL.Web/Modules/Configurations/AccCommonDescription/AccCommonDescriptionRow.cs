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

    [ConnectionKey("ACCDB"), DisplayName("Common Description"), InstanceName("Common Description"), TwoLevelCached]
    [ReadPermission("Configurations:AccCommonDescription:Read")]
    [InsertPermission("Configurations:AccCommonDescription:Insert")]
    [UpdatePermission("Configurations:AccCommonDescription:Update")]
    [DeletePermission("Configurations:AccCommonDescription:Delete")]
    [LookupScript("Configurations.AccCommonDescription",Permission ="?")]
    public sealed class AccCommonDescriptionRow : NRow, IIdRow, INameRow, IAuditLog
    {
            #region Id
            [DisplayName("Id"), Column("id"), Identity]
            public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
            public partial class RowFields { public Int32Field Id; }
            #endregion Id

            #region Description
            [DisplayName("Description"), Column("description"), Size(1000), QuickSearch]
            public String Description { get { return Fields.Description[this]; } set { Fields.Description[this] = value; } }
            public partial class RowFields { public StringField Description; }
            #endregion Description

            #region Transaction Type
            [DisplayName("Transaction Type"), Column("transactionTypeId"), ForeignKey("[dbo].[acc_transaction_type]", "id"), LeftJoin("jTransactionType"), TextualField("TransactionTypeRemarks")]
            [LookupEditor(typeof(Configurations.Entities.AccTransactionTypeRow), CascadeFrom = "VoucherTypeId")]
            public Int32? TransactionTypeId { get { return Fields.TransactionTypeId[this]; } set { Fields.TransactionTypeId[this] = value; } }
            public partial class RowFields { public Int32Field TransactionTypeId; }
            #endregion TransactionTypeId

            #region Voucher Type
            [DisplayName("Voucher Type"), Column("voucherTypeId"), ForeignKey("[dbo].[acc_voucher_type]", "id"), LeftJoin("jVoucherType"), TextualField("VoucherTypeName")]
            [LookupEditor(typeof(Configurations.Entities.AccVoucherTypeRow)),LookupInclude]
            public Int32? VoucherTypeId { get { return Fields.VoucherTypeId[this]; } set { Fields.VoucherTypeId[this] = value; } }
            public partial class RowFields { public Int32Field VoucherTypeId; }
            #endregion VoucherTypeId


    #region Foreign Fields

                [DisplayName("Transaction Type Remarks"), Expression("jTransactionType.[remarks]")]
                public String TransactionTypeRemarks { get { return Fields.TransactionTypeRemarks[this]; } set { Fields.TransactionTypeRemarks[this] = value; } }
                public partial class RowFields { public StringField TransactionTypeRemarks; }


                [DisplayName("Transaction Type Sort Order"), Expression("jTransactionType.[sortOrder]")]
                public Int32? TransactionTypeSortOrder { get { return Fields.TransactionTypeSortOrder[this]; } set { Fields.TransactionTypeSortOrder[this] = value; } }
                public partial class RowFields { public Int32Field TransactionTypeSortOrder; }


                [DisplayName("Transaction Type"), Expression("jTransactionType.[transactionType]")]
                public String TransactionType { get { return Fields.TransactionType[this]; } set { Fields.TransactionType[this] = value; } }
                public partial class RowFields { public StringField TransactionType; }


                [DisplayName("Transaction Type Fund Control Id"), Expression("jTransactionType.[fundControlId]")]
                public Int32? TransactionTypeFundControlId { get { return Fields.TransactionTypeFundControlId[this]; } set { Fields.TransactionTypeFundControlId[this] = value; } }
                public partial class RowFields { public Int32Field TransactionTypeFundControlId; }


                [DisplayName("Transaction Type Voucher Type Id"), Expression("jTransactionType.[voucherTypeId]")]
                public Int32? TransactionTypeVoucherTypeId { get { return Fields.TransactionTypeVoucherTypeId[this]; } set { Fields.TransactionTypeVoucherTypeId[this] = value; } }
                public partial class RowFields { public Int32Field TransactionTypeVoucherTypeId; }


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
            get { return Fields.Description; }
            }
            #endregion Id and Name fields

    #region Constructor
    public AccCommonDescriptionRow()
    : base(Fields)
    {
    }
    #endregion Constructor

    #region RowFields
    public static readonly RowFields Fields = new RowFields().Init();

    public partial class RowFields : NRowFields
    {
    public RowFields()
    : base("[dbo].[acc_common_description]")
    {
    LocalTextPrefix = "Configurations.AccCommonDescription";
    }
    }
    #endregion RowFields
    }
    }

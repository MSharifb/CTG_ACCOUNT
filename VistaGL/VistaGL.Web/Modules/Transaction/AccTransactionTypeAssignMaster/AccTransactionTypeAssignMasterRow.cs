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

    [ConnectionKey("ACCDB"), DisplayName("Transaction Type Assign"), InstanceName("Transaction Type Assign"), TwoLevelCached]
    [ReadPermission("Transaction:AccTransactionTypeAssignMaster:Read")]
    [InsertPermission("Transaction:AccTransactionTypeAssignMaster:Insert")]
    [UpdatePermission("Transaction:AccTransactionTypeAssignMaster:Update")]
    [DeletePermission("Transaction:AccTransactionTypeAssignMaster:Delete")]
    [LookupScript("Transaction.AccTransactionTypeAssignMaster",Permission ="?")]
    public sealed class AccTransactionTypeAssignMasterRow : Row, IIdRow, INameRow, IAuditLog
    {
            #region Id
            [DisplayName("Id"), Column("id"), Identity]
            public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
            public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Transaction Type
        [DisplayName("Voucher Type"), Expression("jTransactionType.[voucherTypeId]")]
        [LookupEditor(typeof(Configurations.Entities.AccVoucherTypeRow)), LookupInclude]
        public Int32? VoucherTypeId { get { return Fields.VoucherTypeId[this]; } set { Fields.VoucherTypeId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherTypeId; }

        [DisplayName("Transaction Type"), ForeignKey("[dbo].[acc_transaction_type]", "id"), LeftJoin("jTransactionType"), TextualField("TransactionTypeRemarks")]
            [LookupEditor(typeof(Configurations.Entities.AccTransactionTypeRow), CascadeFrom = "VoucherTypeId")]
            public Int32? TransactionTypeId { get { return Fields.TransactionTypeId[this]; } set { Fields.TransactionTypeId[this] = value; } }
            public partial class RowFields { public Int32Field TransactionTypeId; }
            #endregion TransactionTypeId

            #region Remarks
            [DisplayName("Remarks"), Size(500), QuickSearch]
            public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
            public partial class RowFields { public StringField Remarks; }
        #endregion Remarks

        #region Debit
        [DisplayName("Debit"), MasterDetailRelation(foreignKey: "MasterID", CheckChangesOnUpdate = false), NotMapped]
        public List<AccTransactionTypeAssignRow> CoADebit
        {
            get { return Fields.CoADebit[this]; }
            set { Fields.CoADebit[this] = value; }
        }
        public partial class RowFields { public RowListField<AccTransactionTypeAssignRow> CoADebit; }
        #endregion

        //#region Credit
        //[DisplayName("Credit"), /*MasterDetailRelation(foreignKey: "MasterID"),*/ NotMapped]
        //public List<AccTransactionTypeAssignRow> CoACredit
        //{
        //    get { return Fields.CoACredit[this]; }
        //    set { Fields.CoACredit[this] = value; }
        //}
        //public partial class RowFields { public RowListField<AccTransactionTypeAssignRow> CoACredit; }
        //#endregion

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





    #endregion Foreign Fields

    #region Id and Name fields
    IIdField IIdRow.IdField
    {
    get { return Fields.Id; }
    }

            StringField INameRow.NameField
            {
            get { return Fields.Remarks; }
            }
            #endregion Id and Name fields

    #region Constructor
    public AccTransactionTypeAssignMasterRow()
    : base(Fields)
    {
    }
    #endregion Constructor

    #region RowFields
    public static readonly RowFields Fields = new RowFields().Init();

    public partial class RowFields : RowFieldsBase
    {
    public RowFields()
    : base("[dbo].[acc_Transaction_type_Assign_Master]")
    {
    LocalTextPrefix = "Transaction.AccTransactionTypeAssignMaster";
    }
    }
    #endregion RowFields
    }
    }

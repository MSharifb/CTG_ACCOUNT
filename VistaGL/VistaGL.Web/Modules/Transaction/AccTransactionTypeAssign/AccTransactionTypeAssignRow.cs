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

    [ConnectionKey("ACCDB"), DisplayName("Assign Chart of Account"), InstanceName("Assign Chart of Account"), TwoLevelCached]
    [ReadPermission("Transaction:AccTransactionTypeAssignMaster:Read")]
    [InsertPermission("Transaction:AccTransactionTypeAssignMaster:Insert")]
    [UpdatePermission("Transaction:AccTransactionTypeAssignMaster:Update")]
    [DeletePermission("Transaction:AccTransactionTypeAssignMaster:Delete")]
    [LookupScript("Transaction.AccTransactionTypeAssign", Permission = "?")]
    public sealed class AccTransactionTypeAssignRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Tr Type
        [DisplayName("Tr Type"), Column("trType"), Size(255), QuickSearch, LookupInclude]
        public String TrType { get { return Fields.TrType[this]; } set { Fields.TrType[this] = value; } }
        public partial class RowFields { public StringField TrType; }
        #endregion TrType

        #region Parent
        [DisplayName("Parent"), Column("parentId"), ForeignKey("[dbo].[acc_transaction_type]", "id"), LeftJoin("jParent"), TextualField("ParentRemarks")]
        [LookupEditor(typeof(Configurations.Entities.AccTransactionTypeRow)), LookupInclude]
        public Int32? ParentId { get { return Fields.ParentId[this]; } set { Fields.ParentId[this] = value; } }
        public partial class RowFields { public Int32Field ParentId; }
        #endregion ParentId

        #region Coa
        [DisplayName("Coa"), Column("coaId"), ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoa"), TextualField("CoaAccountCode")]
        [LookupEditor(typeof(Configurations.Entities.AccChartofAccountsRow)), LookupInclude]
        public Int32? CoaId { get { return Fields.CoaId[this]; } set { Fields.CoaId[this] = value; } }
        public partial class RowFields { public Int32Field CoaId; }
        #endregion CoaId
        #region MasterID
        [DisplayName("MasterID"), Column("MasterID")]
        public Int32? MasterID { get { return Fields.MasterID[this]; } set { Fields.MasterID[this] = value; } }
        public partial class RowFields { public Int32Field MasterID; }
        #endregion MasterID

        #region Foreign Fields

        [DisplayName("Parent Remarks"), Expression("jParent.[remarks]")]
        public String ParentRemarks { get { return Fields.ParentRemarks[this]; } set { Fields.ParentRemarks[this] = value; } }
        public partial class RowFields { public StringField ParentRemarks; }


        [DisplayName("Parent Sort Order"), Expression("jParent.[sortOrder]")]
        public Int32? ParentSortOrder { get { return Fields.ParentSortOrder[this]; } set { Fields.ParentSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field ParentSortOrder; }


        [DisplayName("Parent Transaction Type"), Expression("jParent.[transactionType]")]
        public String ParentTransactionType { get { return Fields.ParentTransactionType[this]; } set { Fields.ParentTransactionType[this] = value; } }
        public partial class RowFields { public StringField ParentTransactionType; }


        [DisplayName("Parent Fund Control Id"), Expression("jParent.[fundControlId]")]
        public Int32? ParentFundControlId { get { return Fields.ParentFundControlId[this]; } set { Fields.ParentFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field ParentFundControlId; }


        [DisplayName("Parent Voucher Type Id"), Expression("jParent.[voucherTypeId]")]
        public Int32? ParentVoucherTypeId { get { return Fields.ParentVoucherTypeId[this]; } set { Fields.ParentVoucherTypeId[this] = value; } }
        public partial class RowFields { public Int32Field ParentVoucherTypeId; }


        [DisplayName("Coa Account Code"), Expression("jCoa.[accountCode]")]
        public String CoaAccountCode { get { return Fields.CoaAccountCode[this]; } set { Fields.CoaAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoaAccountCode; }


        [DisplayName("Coa Account Code Count"), Expression("jCoa.[accountCodeCount]")]
        public Int32? CoaAccountCodeCount { get { return Fields.CoaAccountCodeCount[this]; } set { Fields.CoaAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoaAccountCodeCount; }


        [DisplayName("Coa Account Group"), Expression("jCoa.[accountGroup]")]
        public String CoaAccountGroup { get { return Fields.CoaAccountGroup[this]; } set { Fields.CoaAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoaAccountGroup; }


        [DisplayName("Coa Account Name"), Expression("jCoa.[accountName]")]
        public String CoaAccountName { get { return Fields.CoaAccountName[this]; } set { Fields.CoaAccountName[this] = value; } }
        public partial class RowFields { public StringField CoaAccountName; }


        [DisplayName("Coa Account Name Bangla"), Expression("jCoa.[accountNameBangla]")]
        public String CoaAccountNameBangla { get { return Fields.CoaAccountNameBangla[this]; } set { Fields.CoaAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField CoaAccountNameBangla; }


        [DisplayName("Coa Coa Mapping"), Expression("jCoa.[coaMapping]")]
        public String CoaCoaMapping { get { return Fields.CoaCoaMapping[this]; } set { Fields.CoaCoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoaCoaMapping; }


        [DisplayName("Coa Is Bill Ref"), Expression("jCoa.[isBillRef]")]
        public Int16? CoaIsBillRef { get { return Fields.CoaIsBillRef[this]; } set { Fields.CoaIsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field CoaIsBillRef; }


        [DisplayName("Coa Is Budget Head"), Expression("jCoa.[isBudgetHead]")]
        public Int16? CoaIsBudgetHead { get { return Fields.CoaIsBudgetHead[this]; } set { Fields.CoaIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field CoaIsBudgetHead; }


        [DisplayName("Coa Is Controlhead"), Expression("jCoa.[isControlhead]")]
        public Int16? CoaIsControlhead { get { return Fields.CoaIsControlhead[this]; } set { Fields.CoaIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field CoaIsControlhead; }


        [DisplayName("Coa Is Sub Ledger Allocate"), Expression("jCoa.[isCostCenterAllocate]")]
        public Int16? CoaIsCostCenterAllocate { get { return Fields.CoaIsCostCenterAllocate[this]; } set { Fields.CoaIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field CoaIsCostCenterAllocate; }


        [DisplayName("Coa Level"), Expression("jCoa.[level]")]
        public Int32? CoaLevel { get { return Fields.CoaLevel[this]; } set { Fields.CoaLevel[this] = value; } }
        public partial class RowFields { public Int32Field CoaLevel; }


        [DisplayName("Coa Mailing Address"), Expression("jCoa.[mailingAddress]")]
        public String CoaMailingAddress { get { return Fields.CoaMailingAddress[this]; } set { Fields.CoaMailingAddress[this] = value; } }
        public partial class RowFields { public StringField CoaMailingAddress; }


        [DisplayName("Coa Mailing Name"), Expression("jCoa.[mailingName]")]
        public String CoaMailingName { get { return Fields.CoaMailingName[this]; } set { Fields.CoaMailingName[this] = value; } }
        public partial class RowFields { public StringField CoaMailingName; }


        [DisplayName("Coa Opening Balance"), Expression("jCoa.[openingBalance]")]
        public Double? CoaOpeningBalance { get { return Fields.CoaOpeningBalance[this]; } set { Fields.CoaOpeningBalance[this] = value; } }
        public partial class RowFields { public DoubleField CoaOpeningBalance; }


        [DisplayName("Coa Remarks"), Expression("jCoa.[remarks]")]
        public String CoaRemarks { get { return Fields.CoaRemarks[this]; } set { Fields.CoaRemarks[this] = value; } }
        public partial class RowFields { public StringField CoaRemarks; }


        [DisplayName("Coa Tax Id"), Expression("jCoa.[taxID]")]
        public String CoaTaxId { get { return Fields.CoaTaxId[this]; } set { Fields.CoaTaxId[this] = value; } }
        public partial class RowFields { public StringField CoaTaxId; }


        [DisplayName("Coa Ugc Code"), Expression("jCoa.[ugcCode]")]
        public String CoaUgcCode { get { return Fields.CoaUgcCode[this]; } set { Fields.CoaUgcCode[this] = value; } }
        public partial class RowFields { public StringField CoaUgcCode; }


        [DisplayName("Coa Fund Control Id"), Expression("jCoa.[fundControlId]")]
        public Int32? CoaFundControlId { get { return Fields.CoaFundControlId[this]; } set { Fields.CoaFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoaFundControlId; }


        [DisplayName("Coa Parent Account Id"), Expression("jCoa.[parentAccountId]")]
        public Int32? CoaParentAccountId { get { return Fields.CoaParentAccountId[this]; } set { Fields.CoaParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoaParentAccountId; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.CoaAccountName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccTransactionTypeAssignRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_transaction_type_assign]")
            {
                LocalTextPrefix = "Transaction.AccTransactionTypeAssign";
            }
        }
        #endregion RowFields
    }
}

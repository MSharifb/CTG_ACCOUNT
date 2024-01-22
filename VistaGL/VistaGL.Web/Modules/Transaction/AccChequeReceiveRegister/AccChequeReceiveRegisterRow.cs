using VistaGL.Modules.Common;

namespace VistaGL.Transaction.Entities
{
    using Configurations.Entities;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Cheque/DD/PO Receive Information"), InstanceName("Cheque/DD/PO Receive Information"), TwoLevelCached]
    [ReadPermission("Transaction:AccChequeReceiveRegister:Read")]
    [InsertPermission("Transaction:AccChequeReceiveRegister:Insert")]
    [UpdatePermission("Transaction:AccChequeReceiveRegister:Update")]
    [DeletePermission("Transaction:AccChequeReceiveRegister:Delete")]
    [LookupScript("Transaction.AccChequeReceiveRegister", Permission = "?")]
    public sealed class AccChequeReceiveRegisterRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int64? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int64Field Id; }
        #endregion Id

        #region Account Name
        [DisplayName("Account Name"), Column("accountName"), Size(255), QuickSearch]
        public String AccountName { get { return Fields.AccountName[this]; } set { Fields.AccountName[this] = value; } }
        public partial class RowFields { public StringField AccountName; }
        #endregion AccountName

        #region Account No
        [DisplayName("Account No"), Column("accountNo"), Size(100), DefaultValue(""), QuickSearch]
        public String AccountNo { get { return Fields.AccountNo[this]; } set { Fields.AccountNo[this] = value; } }
        public partial class RowFields { public StringField AccountNo; }
        #endregion AccountNo

        #region Amount
        [DisplayName("Amount"), Column("amount"), Size(16), Scale(2), NotNull, QuickSearch, LookupInclude]
        public Decimal? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DecimalField Amount; }
        #endregion Amount

        #region Amount In Words
        [DisplayName("Amount In Words"), Column("amountInWords"), Size(500)]
        public String AmountInWords { get { return Fields.AmountInWords[this]; } set { Fields.AmountInWords[this] = value; } }
        public partial class RowFields { public StringField AmountInWords; }
        #endregion AmountInWords

        #region Bank Name
        [DisplayName("Bank Name"), Column("bankName"), Size(100), DefaultValue(""), QuickSearch]
        public String BankName { get { return Fields.BankName[this]; } set { Fields.BankName[this] = value; } }
        public partial class RowFields { public StringField BankName; }
        #endregion BankName

        #region Branch Name
        [DisplayName("Branch Name"), Column("branchName"), Size(100), DefaultValue(""), QuickSearch]
        public String BranchName { get { return Fields.BranchName[this]; } set { Fields.BranchName[this] = value; } }
        public partial class RowFields { public StringField BranchName; }
        #endregion BranchName

        #region Cheque Date
        [DisplayName("Cheque Date"), Column("chequeDate"), NotNull, QuickSearch]
        public DateTime? ChequeDate { get { return Fields.ChequeDate[this]; } set { Fields.ChequeDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeDate; }
        #endregion ChequeDate

        #region Chq./DD/PO Number
        [DisplayName("Chq./DD/PO No"), Column("chequeNo"), Size(255), NotNull, QuickSearch, LookupInclude]
        public String ChequeNo { get { return Fields.ChequeNo[this]; } set { Fields.ChequeNo[this] = value; } }
        public partial class RowFields { public StringField ChequeNo; }
        #endregion ChequeNo

        #region Cheque Receive Date
        [DisplayName("Chq./DD/PO Receive Date"), Column("chequeReceiveDate"), NotNull, QuickSearch]
        public DateTime? ChequeReceiveDate { get { return Fields.ChequeReceiveDate[this]; } set { Fields.ChequeReceiveDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeReceiveDate; }
        #endregion ChequeReceiveDate

        #region Cheque Type
        [DisplayName("Cheque Type"), Column("chequeType"), Size(20), QuickSearch]
        public String ChequeType { get { return Fields.ChequeType[this]; } set { Fields.ChequeType[this] = value; } }
        public partial class RowFields { public StringField ChequeType; }
        #endregion ChequeType

        #region Is Cancelled
        [DisplayName("Is Cancelled"), Column("isCancelled"), DefaultValue(false)]
        public Boolean? IsCancelled { get { return Fields.IsCancelled[this]; } set { Fields.IsCancelled[this] = value; } }
        public partial class RowFields { public BooleanField IsCancelled; }
        #endregion IsCancelled

        #region Is Used
        [DisplayName("Is Used"), Column("isUsed")]
        public Boolean? IsUsed { get { return Fields.IsUsed[this]; } set { Fields.IsUsed[this] = value; } }
        public partial class RowFields { public BooleanField IsUsed; }
        #endregion IsUsed

        #region Receive Type
        [DisplayName("Receive Type"), Column("receiveType"), Size(20), QuickSearch]
        public String ReceiveType { get { return Fields.ReceiveType[this]; } set { Fields.ReceiveType[this] = value; } }
        public partial class RowFields { public StringField ReceiveType; }
        #endregion ReceiveType

        #region Recieve From
        [DisplayName("Recieve From"), Column("recieveFrom"), Size(250), NotNull, QuickSearch, LookupInclude]
        public String RecieveFrom { get { return Fields.RecieveFrom[this]; } set { Fields.RecieveFrom[this] = value; } }
        public partial class RowFields { public StringField RecieveFrom; }
        #endregion RecieveFromId

        #region Entity
        [DisplayName("Entity"), Column("entityId"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jEntity"), TextualField("EntityCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow), InplaceAdd = true)]
        public Int32? EntityId { get { return Fields.EntityId[this]; } set { Fields.EntityId[this] = value; } }
        public partial class RowFields { public Int32Field EntityId; }
        #endregion EntityId

        #region Narration/Purpose
        [DisplayName("Narration/Purpose "), Column("remarks"), Size(500), LookupInclude]
        public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
        public partial class RowFields { public StringField Remarks; }
        #endregion Remarks

        #region Zone Info
        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        //[LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region Foreign Fields

        [DisplayName("Entity Code"), Expression("jEntity.[code]")]
        public String EntityCode { get { return Fields.EntityCode[this]; } set { Fields.EntityCode[this] = value; } }
        public partial class RowFields { public StringField EntityCode; }

        [DisplayName("Entity Fund Control Name"), Expression("jEntity.[fundControlName]")]
        public String EntityFundControlName { get { return Fields.EntityFundControlName[this]; } set { Fields.EntityFundControlName[this] = value; } }
        public partial class RowFields { public StringField EntityFundControlName; }

        [DisplayName("Entity Remarks"), Expression("jEntity.[remarks]")]
        public String EntityRemarks { get { return Fields.EntityRemarks[this]; } set { Fields.EntityRemarks[this] = value; } }
        public partial class RowFields { public StringField EntityRemarks; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.AccountName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccChequeReceiveRegisterRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_cheque_receive_register]")
            {
                LocalTextPrefix = "Transaction.AccChequeReceiveRegister";
            }
        }
        #endregion RowFields
    }
}

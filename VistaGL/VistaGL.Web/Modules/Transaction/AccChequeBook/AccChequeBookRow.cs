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

    [ConnectionKey("ACCDB"), DisplayName("Cheque Book"), InstanceName("Cheque Book"), TwoLevelCached]
    [ReadPermission("Transaction:AccChequeBook:Read")]
    [InsertPermission("Transaction:AccChequeBook:Insert")]
    [UpdatePermission("Transaction:AccChequeBook:Update")]
    [DeletePermission("Transaction:AccChequeBook:Delete")]
    [LookupScript("Transaction.AccChequeBook", Permission = "?")]
    public sealed class AccChequeBookRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Check Book No
        [DisplayName("Cheque Book No."), Column("checkBookName"), Size(255), NotNull, QuickSearch]
        public String CheckBookName { get { return Fields.CheckBookName[this]; } set { Fields.CheckBookName[this] = value; } }
        public partial class RowFields { public StringField CheckBookName; }
        #endregion CheckBookName

        #region Ending No
        [DisplayName("Ending No."), Column("endingNo"), Size(19), NotNull, LookupInclude]
        public Int32? EndingNo { get { return Fields.EndingNo[this]; } set { Fields.EndingNo[this] = value; } }
        public partial class RowFields { public Int32Field EndingNo; }
        #endregion EndingNo

        #region Has Finished
        [DisplayName("Has Finished"), Column("hasFinished"), LookupInclude]
        public Boolean? HasFinished { get { return Fields.HasFinished[this]; } set { Fields.HasFinished[this] = value; } }
        public partial class RowFields { public BooleanField HasFinished; }
        #endregion HasFinished

        #region Starting No
        [DisplayName("Starting No."), Column("startingNo"), Size(19), NotNull, LookupInclude]
        public String StartingNo { get { return Fields.StartingNo[this]; } set { Fields.StartingNo[this] = value; } }
        public partial class RowFields { public StringField StartingNo; }
        #endregion StartingNo

        #region Entity
        [DisplayName("Entity"), Column("entityId"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jEntity"), TextualField("EntityCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow), InplaceAdd = true)]
        public Int32? EntityId { get { return Fields.EntityId[this]; } set { Fields.EntityId[this] = value; } }
        public partial class RowFields { public Int32Field EntityId; }
        #endregion EntityId

        #region Bank Account No.
        [DisplayName("Account No."), Column("bankAccountInformation_id"), NotNull, ForeignKey("[dbo].[acc_BankAccountInformation]", "id"), LeftJoin("jBankAccountInformation"), TextualField("BankAccountInformationAccountDescription")]
        [LookupEditor("Configurations.AccBankAccountInformation_Lookup"), LookupInclude]
        public Int32? BankAccountInformationId { get { return Fields.BankAccountInformationId[this]; } set { Fields.BankAccountInformationId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationId; }
        #endregion BankAccountInformationId

        #region No. of Pages
        [DisplayName("No. of Pages"), Column("pageNo"), Size(18), NotNull]
        public Int32? PageNo { get { return Fields.PageNo[this]; } set { Fields.PageNo[this] = value; } }
        public partial class RowFields { public Int32Field PageNo; }
        #endregion PageNo

        #region Prefix
        [DisplayName("Prefix"), Column("prefix"), Size(10), LookupInclude]
        public String Prefix { get { return Fields.Prefix[this]; } set { Fields.Prefix[this] = value; } }
        public partial class RowFields { public StringField Prefix; }
        #endregion Prefix

        #region Zone Info
        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        //[LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region CB Date
        [DisplayName("C.B. Collection Date"), Column("CBDate"), NotNull,QuickSearch]
        public DateTime? CBDate { get { return Fields.CBDate[this]; } set { Fields.CBDate[this] = value; } }
        public partial class RowFields { public DateTimeField CBDate; }
        #endregion CBDate

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


        [DisplayName("Bank Account Information Account Description"), Expression("jBankAccountInformation.[accountDescription]")]
        public String BankAccountInformationAccountDescription { get { return Fields.BankAccountInformationAccountDescription[this]; } set { Fields.BankAccountInformationAccountDescription[this] = value; } }
        public partial class RowFields { public StringField BankAccountInformationAccountDescription; }


        [DisplayName("Bank Account Information Account Name"), Expression("jBankAccountInformation.[accountName]")]
        public String BankAccountInformationAccountName { get { return Fields.BankAccountInformationAccountName[this]; } set { Fields.BankAccountInformationAccountName[this] = value; } }
        public partial class RowFields { public StringField BankAccountInformationAccountName; }


        [DisplayName("Account No."), Expression("jBankAccountInformation.[accountNumber]"),QuickSearch]
        public String BankAccountInformationAccountNumber { get { return Fields.BankAccountInformationAccountNumber[this]; } set { Fields.BankAccountInformationAccountNumber[this] = value; } }
        public partial class RowFields { public StringField BankAccountInformationAccountNumber; }


        [DisplayName("Bank Account Information Code"), Expression("jBankAccountInformation.[code]")]
        public String BankAccountInformationCode { get { return Fields.BankAccountInformationCode[this]; } set { Fields.BankAccountInformationCode[this] = value; } }
        public partial class RowFields { public StringField BankAccountInformationCode; }


        [DisplayName("Bank Account Information Coa Id"), Expression("jBankAccountInformation.[COAId]")]
        public Int32? BankAccountInformationCoaId { get { return Fields.BankAccountInformationCoaId[this]; } set { Fields.BankAccountInformationCoaId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationCoaId; }


        [DisplayName("Bank Account Information Bank Id"), Expression("jBankAccountInformation.[bankId]")]
        public Int32? BankAccountInformationBankId { get { return Fields.BankAccountInformationBankId[this]; } set { Fields.BankAccountInformationBankId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationBankId; }


        [DisplayName("Bank Account Information Bank Branch Id"), Expression("jBankAccountInformation.[bankBranchId]")]
        public Int32? BankAccountInformationBankBranchId { get { return Fields.BankAccountInformationBankBranchId[this]; } set { Fields.BankAccountInformationBankBranchId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationBankBranchId; }


        [DisplayName("Bank Account Information Entity Id"), Expression("jBankAccountInformation.[entityId]")]
        public Int32? BankAccountInformationEntityId { get { return Fields.BankAccountInformationEntityId[this]; } set { Fields.BankAccountInformationEntityId[this] = value; } }
        public partial class RowFields { public Int32Field BankAccountInformationEntityId; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.CheckBookName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccChequeBookRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_ChequeBook]")
            {
                LocalTextPrefix = "Transaction.AccChequeBook";
            }
        }
        #endregion RowFields
    }
}

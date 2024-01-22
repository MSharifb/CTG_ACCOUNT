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

    [ConnectionKey("ACCDB"), DisplayName("Bank Branch Information"), InstanceName("Bank Branch Information"), TwoLevelCached]
    [ReadPermission("Configurations:AccBankInformation:Read")]
    [InsertPermission("Configurations:AccBankInformation:Insert")]
    [UpdatePermission("Configurations:AccBankInformation:Update")]
    [DeletePermission("Configurations:AccBankInformation:Delete")]
    [LookupScript("Configurations.AccBankBranchInformation", Permission = "?")]
    public sealed class AccBankBranchInformationRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Branch Name
        [DisplayName("Branch Name"), Column("branchName"), Size(100), NotNull]
        public String BranchName { get { return Fields.BranchName[this]; } set { Fields.BranchName[this] = value; } }
        public partial class RowFields { public StringField BranchName; }
        #endregion BranchName

        #region Address
        [DisplayName("Address"), Column("address"), Size(200), QuickSearch]
        public String Address { get { return Fields.Address[this]; } set { Fields.Address[this] = value; } }
        public partial class RowFields { public StringField Address; }
        #endregion Address

        #region Contacts
        [DisplayName("Contacts"), Column("contacts"), Size(100)]
        public String Contacts { get { return Fields.Contacts[this]; } set { Fields.Contacts[this] = value; } }
        public partial class RowFields { public StringField Contacts; }
        #endregion Contacts

        #region Email
        [DisplayName("Email"), Column("email"), Size(50)]
        public String Email { get { return Fields.Email[this]; } set { Fields.Email[this] = value; } }
        public partial class RowFields { public StringField Email; }
        #endregion Email

        #region SWIFT Code
        [DisplayName("SWIFT Code"), Column("code"), Size(10), NotNull]
        public String Code { get { return Fields.Code[this]; } set { Fields.Code[this] = value; } }
        public partial class RowFields { public StringField Code; }
        #endregion Code

        #region Bank
        [DisplayName("Bank"), Column("bankId"), NotNull, ForeignKey("[dbo].[acc_BankInformation]", "id"), LeftJoin("jBank"), TextualField("BankBankName")]
        [LookupEditor(typeof(Configurations.Entities.AccBankInformationRow), InplaceAdd = true), LookupInclude]
        public Int32? BankId { get { return Fields.BankId[this]; } set { Fields.BankId[this] = value; } }
        public partial class RowFields { public Int32Field BankId; }
        #endregion BankId

        #region Foreign Fields

        [DisplayName("Bank Bank Name"), Expression("jBank.[bankName]")]
        public String BankBankName { get { return Fields.BankBankName[this]; } set { Fields.BankBankName[this] = value; } }
        public partial class RowFields { public StringField BankBankName; }


        [DisplayName("Bank Code"), Expression("jBank.[code]")]
        public String BankCode { get { return Fields.BankCode[this]; } set { Fields.BankCode[this] = value; } }
        public partial class RowFields { public StringField BankCode; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.BranchName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccBankBranchInformationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_BankBranchInformation]")
            {
                LocalTextPrefix = "Configurations.AccBankBranchInformation";
            }
        }
        #endregion RowFields
    }
}

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

    [ConnectionKey("ACCDB"), DisplayName("Bank Account Information"), InstanceName("Bank Account Information"), TwoLevelCached]
    [ReadPermission("Configurations:AccBankAccountInformation:Read")]
    [InsertPermission("Configurations:AccBankAccountInformation:Insert")]
    [UpdatePermission("Configurations:AccBankAccountInformation:Update")]
    [DeletePermission("Configurations:AccBankAccountInformation:Delete")]
    [LookupScript("Configurations.AccBankAccountInformation", Permission = "?", Expiration = -1)]
    public sealed class AccBankAccountInformationRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Opening Balance
        [DisplayName("Opening Balance"), Column("OpeningBalance")]
        public Decimal? OpeningBalance { get { return Fields.OpeningBalance[this]; } set { Fields.OpeningBalance[this] = value; } }
        public partial class RowFields { public DecimalField OpeningBalance; }
        #endregion OpeningBalance

        #region Opening Date
        [DisplayName("Voucher Date"), Column("OpeningDate")]
        public DateTime? OpeningDate { get { return Fields.OpeningDate[this]; } set { Fields.OpeningDate[this] = value; } }
        public partial class RowFields { public DateTimeField OpeningDate; }
        #endregion OpeningDate

        #region Account Description
        [DisplayName("Description"), Column("accountDescription"), Size(100), QuickSearch]
        public String AccountDescription { get { return Fields.AccountDescription[this]; } set { Fields.AccountDescription[this] = value; } }
        public partial class RowFields { public StringField AccountDescription; }
        #endregion AccountDescription

        #region Account Name
        [DisplayName("Account Name"), Column("accountName"), Size(100), NotNull, LookupInclude, QuickSearch]
        public String AccountName { get { return Fields.AccountName[this]; } set { Fields.AccountName[this] = value; } }
        public partial class RowFields { public StringField AccountName; }
        #endregion AccountName

        #region Account Number
        [DisplayName("Account Number"), Column("accountNumber"), Size(100), NotNull, QuickSearch]
        public String AccountNumber { get { return Fields.AccountNumber[this]; } set { Fields.AccountNumber[this] = value; } }
        public partial class RowFields { public StringField AccountNumber; }
        #endregion AccountNumber

        #region Code
        [DisplayName("Short Code for Voucher No."), Column("code"), Size(50), NotNull]
        public String Code { get { return Fields.Code[this]; } set { Fields.Code[this] = value; } }
        public partial class RowFields { public StringField Code; }
        #endregion Code

        #region Account Head
        [DisplayName("Account Head"), Column("COAId"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoa"), TextualField("CoaAccountCode")]
        //[LookupEditor(typeof(Configurations.Entities.AccChartofAccountsRow), FilterField = nameof(AccChartofAccountsRow.CoaMapping), FilterValue = "BANK")]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(AccChartofAccountsRow.CoaMapping), FilterValue = "BANK"), LookupInclude]
        public Int32? CoaId { get { return Fields.CoaId[this]; } set { Fields.CoaId[this] = value; } }
        public partial class RowFields { public Int32Field CoaId; }
        #endregion CoaId

        #region Bank
        [DisplayName("Bank"), Column("bankId"), NotNull, ForeignKey("[dbo].[acc_BankInformation]", "id"), LeftJoin("jBank"), TextualField("BankBankName")]
        [LookupEditor(typeof(Configurations.Entities.AccBankInformationRow))]
        public Int32? BankId { get { return Fields.BankId[this]; } set { Fields.BankId[this] = value; } }
        public partial class RowFields { public Int32Field BankId; }
        #endregion BankId

        #region Bank Branch
        [DisplayName("Bank Branch"), Column("bankBranchId"), NotNull, ForeignKey("[dbo].[acc_BankBranchInformation]", "id"), LeftJoin("jBankBranch"), TextualField("BankBranchAddress")]
        [LookupEditor(typeof(Configurations.Entities.AccBankBranchInformationRow), CascadeFrom = "BankId")]
        public Int32? BankBranchId { get { return Fields.BankBranchId[this]; } set { Fields.BankBranchId[this] = value; } }
        public partial class RowFields { public Int32Field BankBranchId; }
        #endregion BankBranchId

        #region Entity
        [DisplayName("Entity"), Column("entityId"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jEntity"), TextualField("EntityCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow), InplaceAdd = true)]
        public Int32? EntityId { get { return Fields.EntityId[this]; } set { Fields.EntityId[this] = value; } }
        public partial class RowFields { public Int32Field EntityId; }
        #endregion EntityId

        #region Zone Info
        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName"), LookupInclude]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region Foreign Fields

        [DisplayName("Coa Account Code"), Expression("jCoa.[accountCode]")]
        public String CoaAccountCode { get { return Fields.CoaAccountCode[this]; } set { Fields.CoaAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoaAccountCode; }


        [DisplayName("Coa Account Code Count"), Expression("jCoa.[accountCodeCount]")]
        public Int32? CoaAccountCodeCount { get { return Fields.CoaAccountCodeCount[this]; } set { Fields.CoaAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoaAccountCodeCount; }


        [DisplayName("Coa Account Group"), Expression("jCoa.[accountGroup]")]
        public String CoaAccountGroup { get { return Fields.CoaAccountGroup[this]; } set { Fields.CoaAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoaAccountGroup; }


        [DisplayName("Account Head"), Expression("jCoa.[accountName]"), QuickSearch]
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


        [DisplayName("Coa Is Sub-Ledger Allocate"), Expression("jCoa.[isCostCenterAllocate]")]
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
        public Decimal? CoaOpeningBalance { get { return Fields.CoaOpeningBalance[this]; } set { Fields.CoaOpeningBalance[this] = value; } }
        public partial class RowFields { public DecimalField CoaOpeningBalance; }


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


        [DisplayName("Bank Name"), Expression("jBank.[bankName]"), LookupInclude, QuickSearch]
        public String BankBankName { get { return Fields.BankBankName[this]; } set { Fields.BankBankName[this] = value; } }
        public partial class RowFields { public StringField BankBankName; }


        [DisplayName("Bank Code"), Expression("jBank.[code]")]
        public String BankCode { get { return Fields.BankCode[this]; } set { Fields.BankCode[this] = value; } }
        public partial class RowFields { public StringField BankCode; }


        [DisplayName("Bank Branch Address"), Expression("jBankBranch.[address]")]
        public String BankBranchAddress { get { return Fields.BankBranchAddress[this]; } set { Fields.BankBranchAddress[this] = value; } }
        public partial class RowFields { public StringField BankBranchAddress; }


        [DisplayName("Branch Name"), Expression("jBankBranch.[branchName]"), LookupInclude, QuickSearch]
        public String BankBranchBranchName { get { return Fields.BankBranchBranchName[this]; } set { Fields.BankBranchBranchName[this] = value; } }
        public partial class RowFields { public StringField BankBranchBranchName; }


        [DisplayName("Bank Branch Code"), Expression("jBankBranch.[code]")]
        public String BankBranchCode { get { return Fields.BankBranchCode[this]; } set { Fields.BankBranchCode[this] = value; } }
        public partial class RowFields { public StringField BankBranchCode; }


        [DisplayName("Bank Branch Contacts"), Expression("jBankBranch.[contacts]")]
        public String BankBranchContacts { get { return Fields.BankBranchContacts[this]; } set { Fields.BankBranchContacts[this] = value; } }
        public partial class RowFields { public StringField BankBranchContacts; }


        [DisplayName("Bank Branch Email"), Expression("jBankBranch.[email]")]
        public String BankBranchEmail { get { return Fields.BankBranchEmail[this]; } set { Fields.BankBranchEmail[this] = value; } }
        public partial class RowFields { public StringField BankBranchEmail; }


        [DisplayName("Bank Branch Bank Id"), Expression("jBankBranch.[bankId]")]
        public Int32? BankBranchBankId { get { return Fields.BankBranchBankId[this]; } set { Fields.BankBranchBankId[this] = value; } }
        public partial class RowFields { public Int32Field BankBranchBankId; }


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
            get { return Fields.AccountNumber; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccBankAccountInformationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_BankAccountInformation]")
            {
                LocalTextPrefix = "Configurations.AccBankAccountInformation";
            }
        }
        #endregion RowFields
    }
}

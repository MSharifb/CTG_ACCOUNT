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

    [ConnectionKey("ACCDB"), DisplayName("Voucher Configuration"), InstanceName("Voucher Configuration"), TwoLevelCached]
    [ReadPermission("Transaction:AccVoucherConfiguration:Read")]
    [InsertPermission("Transaction:AccVoucherConfiguration:Insert")]
    [UpdatePermission("Transaction:AccVoucherConfiguration:Update")]
    [DeletePermission("Transaction:AccVoucherConfiguration:Delete")]

    [LookupScript("Transaction.AccVoucherConfiguration", Permission = "?", Expiration = -1)]
    [UniqueConstraint("FundControlInformationId", "VoucherTypeId", "TransactionTypeId", "AccountingPeriodId", CheckBeforeSave = true, ErrorMessage = "Deuplicate Entry", Name = "")]
    public sealed class AccVoucherConfigurationRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Auto Numbering
        [DisplayName("Auto Numbering"), Column("autoNumbering"), LookupInclude]
        public Boolean? AutoNumbering { get { return Fields.AutoNumbering[this]; } set { Fields.AutoNumbering[this] = value; } }
        public partial class RowFields { public BooleanField AutoNumbering; }
        #endregion AutoNumbering

        #region Common Description
        [DisplayName("Common Description"), Column("commonDescription"), LookupInclude]
        public Boolean? CommonDescription { get { return Fields.CommonDescription[this]; } set { Fields.CommonDescription[this] = value; } }
        public partial class RowFields { public BooleanField CommonDescription; }
        #endregion CommonDescription

        #region Each Account Description
        [DisplayName("Each Account Description"), Column("eachAccounting"), LookupInclude]
        public Boolean? EachAccounting { get { return Fields.EachAccounting[this]; } set { Fields.EachAccounting[this] = value; } }
        public partial class RowFields { public BooleanField EachAccounting; }
        #endregion EachAccounting

        #region Is Active
        [DisplayName("Is Active"), Column("isActive")]
        public Boolean? IsActive { get { return Fields.IsActive[this]; } set { Fields.IsActive[this] = value; } }
        public partial class RowFields { public BooleanField IsActive; }
        #endregion IsActive

        #region  Financial Year Suffix
        [DisplayName("Financial Year Suffix"), Column("isUserFinancialAtTheEnd"), LookupInclude]
        public Boolean? IsUserFinancialAtTheEnd { get { return Fields.IsUserFinancialAtTheEnd[this]; } set { Fields.IsUserFinancialAtTheEnd[this] = value; } }
        public partial class RowFields { public BooleanField IsUserFinancialAtTheEnd; }
        #endregion IsUserFinancialAtTheEnd

        #region Max Month Serial Number
        [DisplayName("Max Month Serial Number"), Column("maxMonthSerialNumber"), Size(1000), LookupInclude]
        public String MaxMonthSerialNumber { get { return Fields.MaxMonthSerialNumber[this]; } set { Fields.MaxMonthSerialNumber[this] = value; } }
        public partial class RowFields { public StringField MaxMonthSerialNumber; }
        #endregion MaxMonthSerialNumber

        #region Max Serial Number
        [DisplayName("Max Serial Number"), Column("maxSerialNumber"), LookupInclude]
        public Int32? MaxSerialNumber { get { return Fields.MaxSerialNumber[this]; } set { Fields.MaxSerialNumber[this] = value; } }
        public partial class RowFields { public Int32Field MaxSerialNumber; }
        #endregion MaxSerialNumber

        #region New Number In Every Month
        [DisplayName("New Number In Every Month"), Column("newNumber"), LookupInclude]
        public Boolean? NewNumber { get { return Fields.NewNumber[this]; } set { Fields.NewNumber[this] = value; } }
        public partial class RowFields { public BooleanField NewNumber; }
        #endregion NewNumber

        #region Number Length
        [DisplayName("Number Length"), Column("numberLength"), NotNull, LookupInclude]
        public Int32? NumberLength { get { return Fields.NumberLength[this]; } set { Fields.NumberLength[this] = value; } }
        public partial class RowFields { public Int32Field NumberLength; }
        #endregion NumberLength

        #region Posting Number
        [DisplayName("Posting Number"), Column("postingNumber"), LookupInclude]
        public Int32? PostingNumber { get { return Fields.PostingNumber[this]; } set { Fields.PostingNumber[this] = value; } }
        public partial class RowFields { public Int32Field PostingNumber; }
        #endregion PostingNumber

        #region Prefix
        [DisplayName("Prefix"), Column("prefix"), Size(10),QuickSearch, LookupInclude]
        public String Prefix { get { return Fields.Prefix[this]; } set { Fields.Prefix[this] = value; } }
        public partial class RowFields { public StringField Prefix; }
        #endregion Prefix

        #region Prepared By Info
        [DisplayName("Prepared By Info"), Column("preparedByInfo")]
        public Boolean? PreparedByInfo { get { return Fields.PreparedByInfo[this]; } set { Fields.PreparedByInfo[this] = value; } }
        public partial class RowFields { public BooleanField PreparedByInfo; }
        #endregion PreparedByInfo

        #region Separators
        [DisplayName("Separators"), Column("separators"), Size(255), LookupInclude]
        public String Separators { get { return Fields.Separators[this]; } set { Fields.Separators[this] = value; } }
        public partial class RowFields { public StringField Separators; }
        #endregion Separators

        #region Starting Number
        [DisplayName("Starting Number"), Column("startingNumber"), NotNull, LookupInclude]
        public Int32? StartingNumber { get { return Fields.StartingNumber[this]; } set { Fields.StartingNumber[this] = value; } }
        public partial class RowFields { public Int32Field StartingNumber; }
        #endregion StartingNumber

        #region Suffix
        [DisplayName("Suffix"), Column("suffix"), Size(10), QuickSearch, LookupInclude]
        public String Suffix { get { return Fields.Suffix[this]; } set { Fields.Suffix[this] = value; } }
        public partial class RowFields { public StringField Suffix; }
        #endregion Suffix

        #region Transaction Type
        [DisplayName("Transaction Type"), Column("transactionTypeId"), NotNull, ForeignKey("[dbo].[acc_transaction_type]", "id"), LeftJoin("jTransactionType"), TextualField("TransactionTypeRemarks")]
        [LookupEditor(typeof(Configurations.Entities.AccTransactionTypeRow), CascadeFrom = "VoucherTypeId"), LookupInclude]
        public Int32? TransactionTypeId { get { return Fields.TransactionTypeId[this]; } set { Fields.TransactionTypeId[this] = value; } }
        public partial class RowFields { public Int32Field TransactionTypeId; }
        #endregion TransactionTypeId

        #region Voucher Type
        [DisplayName("Voucher Type"), Column("voucherTypeId"), NotNull, ForeignKey("[dbo].[acc_voucher_type]", "id"), LeftJoin("jVoucherType"), TextualField("VoucherTypeName")]
        [LookupEditor(typeof(Configurations.Entities.AccVoucherTypeRow)), LookupInclude]
        public Int32? VoucherTypeId { get { return Fields.VoucherTypeId[this]; } set { Fields.VoucherTypeId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherTypeId; }
        #endregion VoucherTypeId

        #region Fund Control Information
        [DisplayName("Fund Control Information"), Column("fundControlInformationId"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControlInformation"), TextualField("FundControlInformationCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow)), LookupInclude]
        public Int32? FundControlInformationId { get { return Fields.FundControlInformationId[this]; } set { Fields.FundControlInformationId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlInformationId; }
        #endregion FundControlInformationId

        #region Accounting Period
        [DisplayName("Accounting Period"), Column("accountingPeriodId"), NotNull, ForeignKey("[dbo].[acc_Accounting_Period_Information]", "id"), LeftJoin("jAccountingPeriod"), TextualField("AccountingPeriodYearName")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow)), LookupInclude]
        public Int32? AccountingPeriodId { get { return Fields.AccountingPeriodId[this]; } set { Fields.AccountingPeriodId[this] = value; } }
        public partial class RowFields { public Int32Field AccountingPeriodId; }
        #endregion AccountingPeriodId

        #region Date
        [DisplayName("Date"), Column("date"), NotNull]
        public DateTime? Date { get { return Fields.Date[this]; } set { Fields.Date[this] = value; } }
        public partial class RowFields { public DateTimeField Date; }
        #endregion ChequeIssueDate

        #region Zone Info
        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName"), LookupInclude]
        //[LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region Is AutoPost
        [DisplayName("Is Auto Posting"), Column("isAutoPost"), LookupInclude]
        public Boolean? IsAutoPost { get { return Fields.IsAutoPost[this]; } set { Fields.IsAutoPost[this] = value; } }
        public partial class RowFields { public BooleanField IsAutoPost; }
        #endregion ISAutoPost

        #region  Financial Year Prefix
        [DisplayName("Financial Year Prefix"), Column("isUserFinancialAtStart"), LookupInclude]
        public Boolean? IsUserFinancialAtStart { get { return Fields.IsUserFinancialAtStart[this]; } set { Fields.IsUserFinancialAtStart[this] = value; } }
        public partial class RowFields { public BooleanField IsUserFinancialAtStart; }
        #endregion IsUserFinancialAtTheEnd

        #region  Added Month
        [DisplayName("Add Month"), Column("isMonth"), LookupInclude]
        public Boolean? IsMonth { get { return Fields.IsMonth[this]; } set { Fields.IsMonth[this] = value; } }
        public partial class RowFields { public BooleanField IsMonth; }
        #endregion

        #region  Added Date
        [DisplayName("Add Day"), Column("isDate"), LookupInclude]
        public Boolean? IsDate { get { return Fields.IsDate[this]; } set { Fields.IsDate[this] = value; } }
        public partial class RowFields { public BooleanField IsDate; }
        #endregion

        #region New Number for Every Bank Account
        [DisplayName("New Number for Every Bank Account"), Column("NewNumberforEveryBankAccount"), LookupInclude]
        public Boolean? NewNumberforEveryBankAccount { get { return Fields.NewNumberforEveryBankAccount[this]; } set { Fields.NewNumberforEveryBankAccount[this] = value; } }
        public partial class RowFields { public BooleanField NewNumberforEveryBankAccount; }
        #endregion

        #region  Add Zone Short Code
        [DisplayName("Add Zone Short Code"), Column("AddZoneShortCode"), LookupInclude]
        public Boolean? AddZoneShortCode { get { return Fields.AddZoneShortCode[this]; } set { Fields.AddZoneShortCode[this] = value; } }
        public partial class RowFields { public BooleanField AddZoneShortCode; }
        #endregion

        #region  Add Bank A/C Short Code
        [DisplayName("Add Bank A/C Short Code"), Column("AddBankACShortCode"), LookupInclude]
        public Boolean? AddBankACShortCode { get { return Fields.AddBankACShortCode[this]; } set { Fields.AddBankACShortCode[this] = value; } }
        public partial class RowFields { public BooleanField AddBankACShortCode; }
        #endregion

        #region Foreign Fields

        [DisplayName("Transaction Type Remarks"), Expression("jTransactionType.[remarks]")]
        public String TransactionTypeRemarks { get { return Fields.TransactionTypeRemarks[this]; } set { Fields.TransactionTypeRemarks[this] = value; } }
        public partial class RowFields { public StringField TransactionTypeRemarks; }


        [DisplayName("Transaction Type Sort Order"), Expression("jTransactionType.[sortOrder]")]
        public Int32? TransactionTypeSortOrder { get { return Fields.TransactionTypeSortOrder[this]; } set { Fields.TransactionTypeSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field TransactionTypeSortOrder; }


        [DisplayName("Transaction Type"), Expression("jTransactionType.[transactionType]"), QuickSearch]
        public String TransactionType { get { return Fields.TransactionType[this]; } set { Fields.TransactionType[this] = value; } }
        public partial class RowFields { public StringField TransactionType; }


        [DisplayName("Transaction Type Fund Control Id"), Expression("jTransactionType.[fundControlId]")]
        public Int32? TransactionTypeFundControlId { get { return Fields.TransactionTypeFundControlId[this]; } set { Fields.TransactionTypeFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field TransactionTypeFundControlId; }


        [DisplayName("Transaction Type Voucher Type Id"), Expression("jTransactionType.[voucherTypeId]")]
        public Int32? TransactionTypeVoucherTypeId { get { return Fields.TransactionTypeVoucherTypeId[this]; } set { Fields.TransactionTypeVoucherTypeId[this] = value; } }
        public partial class RowFields { public Int32Field TransactionTypeVoucherTypeId; }


        [DisplayName("Voucher Type"), Expression("jVoucherType.[name]"), QuickSearch]
        public String VoucherTypeName { get { return Fields.VoucherTypeName[this]; } set { Fields.VoucherTypeName[this] = value; } }
        public partial class RowFields { public StringField VoucherTypeName; }


        [DisplayName("Voucher Type Sort Order"), Expression("jVoucherType.[sortOrder]")]
        public Int32? VoucherTypeSortOrder { get { return Fields.VoucherTypeSortOrder[this]; } set { Fields.VoucherTypeSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field VoucherTypeSortOrder; }


        [DisplayName("Fund Control Information Code"), Expression("jFundControlInformation.[code]")]
        public String FundControlInformationCode { get { return Fields.FundControlInformationCode[this]; } set { Fields.FundControlInformationCode[this] = value; } }
        public partial class RowFields { public StringField FundControlInformationCode; }


        [DisplayName("Fund Control Information Fund Control Name"), Expression("jFundControlInformation.[fundControlName]")]
        public String FundControlInformationFundControlName { get { return Fields.FundControlInformationFundControlName[this]; } set { Fields.FundControlInformationFundControlName[this] = value; } }
        public partial class RowFields { public StringField FundControlInformationFundControlName; }

        [DisplayName("Fund Control Information Remarks"), Expression("jFundControlInformation.[remarks]")]
        public String FundControlInformationRemarks { get { return Fields.FundControlInformationRemarks[this]; } set { Fields.FundControlInformationRemarks[this] = value; } }
        public partial class RowFields { public StringField FundControlInformationRemarks; }


        [DisplayName("Accounting Period Is Active"), Expression("jAccountingPeriod.[isActive]")]
        public Int16? AccountingPeriodIsActive { get { return Fields.AccountingPeriodIsActive[this]; } set { Fields.AccountingPeriodIsActive[this] = value; } }
        public partial class RowFields { public Int16Field AccountingPeriodIsActive; }


        [DisplayName("Accounting Period Is Closed"), Expression("jAccountingPeriod.[isClosed]")]
        public Int16? AccountingPeriodIsClosed { get { return Fields.AccountingPeriodIsClosed[this]; } set { Fields.AccountingPeriodIsClosed[this] = value; } }
        public partial class RowFields { public Int16Field AccountingPeriodIsClosed; }


        [DisplayName("Accounting Period Period End Date"), Expression("jAccountingPeriod.[periodEndDate]")]
        public DateTime? AccountingPeriodPeriodEndDate { get { return Fields.AccountingPeriodPeriodEndDate[this]; } set { Fields.AccountingPeriodPeriodEndDate[this] = value; } }
        public partial class RowFields { public DateTimeField AccountingPeriodPeriodEndDate; }


        [DisplayName("Accounting Period Period Start Date"), Expression("jAccountingPeriod.[periodStartDate]")]
        public DateTime? AccountingPeriodPeriodStartDate { get { return Fields.AccountingPeriodPeriodStartDate[this]; } set { Fields.AccountingPeriodPeriodStartDate[this] = value; } }
        public partial class RowFields { public DateTimeField AccountingPeriodPeriodStartDate; }


        [DisplayName("Accounting Period"), Expression("jAccountingPeriod.[yearName]"), QuickSearch]
        [LookupInclude]
        public String AccountingPeriodYearName { get { return Fields.AccountingPeriodYearName[this]; } set { Fields.AccountingPeriodYearName[this] = value; } }
        public partial class RowFields { public StringField AccountingPeriodYearName; }


        [DisplayName("Accounting Period Fund Control Information Id"), Expression("jAccountingPeriod.[fundControlInformation_id]")]
        public Int32? AccountingPeriodFundControlInformationId { get { return Fields.AccountingPeriodFundControlInformationId[this]; } set { Fields.AccountingPeriodFundControlInformationId[this] = value; } }
        public partial class RowFields { public Int32Field AccountingPeriodFundControlInformationId; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.AccountingPeriodYearName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccVoucherConfigurationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_Voucher_Configuration]")
            {
                LocalTextPrefix = "Transaction.AccVoucherConfiguration";
            }
        }
        #endregion RowFields
    }
}

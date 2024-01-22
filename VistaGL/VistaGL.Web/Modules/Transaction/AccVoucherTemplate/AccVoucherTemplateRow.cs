using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using VistaGL.Modules.Common;

namespace VistaGL.Transaction.Entities
{


    [ConnectionKey("ACCDB"), DisplayName("Voucher Template"), InstanceName("Voucher Template"), TwoLevelCached]
    [ReadPermission("Transaction:AccVoucherTemplate:Read")]
    [InsertPermission("Transaction:AccVoucherTemplate:Insert")]
    [UpdatePermission("Transaction:AccVoucherTemplate:Update")]
    [DeletePermission("Transaction:AccVoucherTemplate:Delete")]
    [LookupScript("Transaction.AccVoucherTemplateRow")]
    public sealed class AccVoucherTemplateRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Voucher Type
        [DisplayName("Voucher Type"), Column("voucherTypeId"), NotNull, ForeignKey("[dbo].[acc_voucher_type]", "id"), LeftJoin("jVoucherType"), TextualField("VoucherTypeName")]
        [LookupEditor(typeof(Configurations.Entities.AccVoucherTypeRow)), LookupInclude]
        public Int32? VoucherTypeId { get { return Fields.VoucherTypeId[this]; } set { Fields.VoucherTypeId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherTypeId; }
        #endregion VoucherTypeId

        #region Transaction Type
        [DisplayName("Transaction Type"), Column("transactionTypeId"), NotNull, ForeignKey("[dbo].[acc_transaction_type]", "id"), LeftJoin("jTransactionType"), TextualField("TransactionTypeRemarks")]
        [LookupEditor(typeof(Configurations.Entities.AccTransactionTypeRow), CascadeFrom = "VoucherTypeId"),LookupInclude]
        public Int32? TransactionTypeId { get { return Fields.TransactionTypeId[this]; } set { Fields.TransactionTypeId[this] = value; } }
        public partial class RowFields { public Int32Field TransactionTypeId; }
        #endregion TransactionTypeId

        #region Transaction Mode
        [DisplayName("Transaction Mode"), Column("transactionMode"), Size(20), NotNull]
        public String TransactionMode { get { return Fields.TransactionMode[this]; } set { Fields.TransactionMode[this] = value; } }
        public partial class RowFields { public StringField TransactionMode; }
        #endregion TransactionMode


        #region Template Name
        [DisplayName("Template Name"), Column("templateName"), Size(250), NotNull]
        public string TemplateName { get { return Fields.TemplateName[this]; } set { Fields.TemplateName[this] = value; } }
        public partial class RowFields { public StringField TemplateName; }
        #endregion TemplateName

        #region Account Head (Debit)
        [DisplayName("Account Head (Debit)"), Column("coaDebitHeadId"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoaDebitHead"), TextualField("CoaDebitHeadAccountCode")]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(Configurations.Entities.AccChartofAccountsRow.IsControlhead), FilterValue = 0)]
        public Int32? CoaDebitHeadId { get { return Fields.CoaDebitHeadId[this]; } set { Fields.CoaDebitHeadId[this] = value; } }
        public partial class RowFields { public Int32Field CoaDebitHeadId; }
        #endregion CoaDebitHeadId

        #region Use Cheque
        [DisplayName("Use Cheque"), Column("isDebitHeadCheque"), NotNull]
        public Boolean? IsDebitHeadCheque { get { return Fields.IsDebitHeadCheque[this]; } set { Fields.IsDebitHeadCheque[this] = value; } }
        public partial class RowFields { public BooleanField IsDebitHeadCheque; }
        #endregion isDebitHeadCheque

        #region Account Head (Credit)
        [DisplayName("Account Head (Credit)"), Column("coaCreditHeadId"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoaCreditHead"), TextualField("CoaCreditHeadAccountCode")]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(Configurations.Entities.AccChartofAccountsRow.IsControlhead), FilterValue = 0)]
        public Int32? CoaCreditHeadId { get { return Fields.CoaCreditHeadId[this]; } set { Fields.CoaCreditHeadId[this] = value; } }
        public partial class RowFields { public Int32Field CoaCreditHeadId; }
        #endregion CoaCreditHeadId

        #region Use Cheque
        [DisplayName("Use Cheque"), Column("isCreditHeadCheque"), NotNull]
        public Boolean? IsCreditHeadCheque { get { return Fields.IsCreditHeadCheque[this]; } set { Fields.IsCreditHeadCheque[this] = value; } }
        public partial class RowFields { public BooleanField IsCreditHeadCheque; }
        #endregion isDebitHeadCheque

        #region Use Bill Reference
        [DisplayName("Use Bill Reference"), Column("isBillReference"), NotNull]
        public Boolean? IsBillReference { get { return Fields.IsBillReference[this]; } set { Fields.IsBillReference[this] = value; } }
        public partial class RowFields { public BooleanField IsBillReference; }
        #endregion

        #region Use Sub Ledger
        [DisplayName("Use Sub Ledger"), Column("isCostCenter"), NotNull]
        public Boolean? IsCostCenter { get { return Fields.IsCostCenter[this]; } set { Fields.IsCostCenter[this] = value; } }
        public partial class RowFields { public BooleanField IsCostCenter; }
        #endregion

        #region Add S/D
        [DisplayName("Add S/D"), Column("isSD"), NotNull]
        public Boolean? IsSd { get { return Fields.IsSd[this]; } set { Fields.IsSd[this] = value; } }
        public partial class RowFields { public BooleanField IsSd; }
        #endregion IsSd

        #region Coa Sd
        [DisplayName("COA SD"), Column("coaSDId"), ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoaSd"), TextualField("CoaSdAccountCode")]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(Configurations.Entities.AccChartofAccountsRow.IsControlhead), FilterValue = 0)]
        public Int32? CoaSdId { get { return Fields.CoaSdId[this]; } set { Fields.CoaSdId[this] = value; } }
        public partial class RowFields { public Int32Field CoaSdId; }
        #endregion CoaSdId

        #region Type
        [DisplayName("Type"), Column("SDType"), Size(50), QuickSearch]
        public String SdType { get { return Fields.SdType[this]; } set { Fields.SdType[this] = value; } }
        public partial class RowFields { public StringField SdType; }
        #endregion SdType

        #region Rate
        [DisplayName("Rate"), Column("SDRate"), Size(5), Scale(2)]
        public Decimal? SdRate { get { return Fields.SdRate[this]; } set { Fields.SdRate[this] = value; } }
        public partial class RowFields { public DecimalField SdRate; }
        #endregion SdRate

        #region ADD VAT
        [DisplayName("ADD VAT"), Column("isVAT"), NotNull]
        public Boolean? IsVat { get { return Fields.IsVat[this]; } set { Fields.IsVat[this] = value; } }
        public partial class RowFields { public BooleanField IsVat; }
        #endregion IsVat

        #region Coa Vat
        [DisplayName("COA VAT"), Column("coaVATId"), ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoaVat"), TextualField("CoaVatAccountCode")]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(Configurations.Entities.AccChartofAccountsRow.IsControlhead), FilterValue = 0)]
        public Int32? CoaVatId { get { return Fields.CoaVatId[this]; } set { Fields.CoaVatId[this] = value; } }
        public partial class RowFields { public Int32Field CoaVatId; }
        #endregion CoaVatId

        #region Type
        [DisplayName("Type"), Column("VATType"), Size(50)]
        public String VatType { get { return Fields.VatType[this]; } set { Fields.VatType[this] = value; } }
        public partial class RowFields { public StringField VatType; }
        #endregion VatType

        #region Rate
        [DisplayName("Rate"), Column("VATRate"), Size(5), Scale(2)]
        public Decimal? VatRate { get { return Fields.VatRate[this]; } set { Fields.VatRate[this] = value; } }
        public partial class RowFields { public DecimalField VatRate; }
        #endregion VatRate

        #region ADD TAX
        [DisplayName("ADD TAX"), Column("isTAX"), NotNull]
        public Boolean? IsTax { get { return Fields.IsTax[this]; } set { Fields.IsTax[this] = value; } }
        public partial class RowFields { public BooleanField IsTax; }
        #endregion IsTax

        #region Coa Tax
        [DisplayName("Coa Tax"), Column("coaTAXId"), ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoaTax"), TextualField("CoaTaxAccountCode")]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(Configurations.Entities.AccChartofAccountsRow.IsControlhead), FilterValue = 0)]
        public Int32? CoaTaxId { get { return Fields.CoaTaxId[this]; } set { Fields.CoaTaxId[this] = value; } }
        public partial class RowFields { public Int32Field CoaTaxId; }
        #endregion CoaTaxId

        #region Type
        [DisplayName("Type"), Column("TAXType"), Size(50)]
        public String TaxType { get { return Fields.TaxType[this]; } set { Fields.TaxType[this] = value; } }
        public partial class RowFields { public StringField TaxType; }
        #endregion TaxType

        #region Rate
        [DisplayName("Rate"), Column("TAXRate"), Size(5), Scale(2)]
        public Decimal? TaxRate { get { return Fields.TaxRate[this]; } set { Fields.TaxRate[this] = value; } }
        public partial class RowFields { public DecimalField TaxRate; }
        #endregion TaxRate

        #region Narration
        [DisplayName("Narration"), Size(500)]
        public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
        public partial class RowFields { public StringField Remarks; }
        #endregion Remarks

        #region Foreign Fields

        [DisplayName("Voucher Type Name"), Expression("jVoucherType.[name]")]
        public String VoucherTypeName { get { return Fields.VoucherTypeName[this]; } set { Fields.VoucherTypeName[this] = value; } }
        public partial class RowFields { public StringField VoucherTypeName; }


        [DisplayName("Voucher Type Sort Order"), Expression("jVoucherType.[sortOrder]")]
        public Int32? VoucherTypeSortOrder { get { return Fields.VoucherTypeSortOrder[this]; } set { Fields.VoucherTypeSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field VoucherTypeSortOrder; }


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


        [DisplayName("Coa Debit Head Account Code"), Expression("jCoaDebitHead.[accountCode]")]
        public String CoaDebitHeadAccountCode { get { return Fields.CoaDebitHeadAccountCode[this]; } set { Fields.CoaDebitHeadAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadAccountCode; }


        [DisplayName("Coa Debit Head Account Code Count"), Expression("jCoaDebitHead.[accountCodeCount]")]
        public Int32? CoaDebitHeadAccountCodeCount { get { return Fields.CoaDebitHeadAccountCodeCount[this]; } set { Fields.CoaDebitHeadAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoaDebitHeadAccountCodeCount; }


        [DisplayName("Coa Debit Head Account Group"), Expression("jCoaDebitHead.[accountGroup]")]
        public String CoaDebitHeadAccountGroup { get { return Fields.CoaDebitHeadAccountGroup[this]; } set { Fields.CoaDebitHeadAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadAccountGroup; }


        [DisplayName("Account Head (Debit)"), Expression("jCoaDebitHead.[accountName]")]
        public String CoaDebitHeadAccountName { get { return Fields.CoaDebitHeadAccountName[this]; } set { Fields.CoaDebitHeadAccountName[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadAccountName; }


        [DisplayName("Coa Debit Head Account Name Bangla"), Expression("jCoaDebitHead.[accountNameBangla]")]
        public String CoaDebitHeadAccountNameBangla { get { return Fields.CoaDebitHeadAccountNameBangla[this]; } set { Fields.CoaDebitHeadAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadAccountNameBangla; }


        [DisplayName("Coa Debit Head Coa Mapping"), Expression("jCoaDebitHead.[coaMapping]")]
        public String CoaDebitHeadCoaMapping { get { return Fields.CoaDebitHeadCoaMapping[this]; } set { Fields.CoaDebitHeadCoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadCoaMapping; }


        [DisplayName("Coa Debit Head Is Bill Ref"), Expression("jCoaDebitHead.[isBillRef]")]
        public Int16? CoaDebitHeadIsBillRef { get { return Fields.CoaDebitHeadIsBillRef[this]; } set { Fields.CoaDebitHeadIsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field CoaDebitHeadIsBillRef; }


        [DisplayName("Coa Debit Head Is Budget Head"), Expression("jCoaDebitHead.[isBudgetHead]")]
        public Int16? CoaDebitHeadIsBudgetHead { get { return Fields.CoaDebitHeadIsBudgetHead[this]; } set { Fields.CoaDebitHeadIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field CoaDebitHeadIsBudgetHead; }


        [DisplayName("Coa Debit Head Is Controlhead"), Expression("jCoaDebitHead.[isControlhead]")]
        public Int16? CoaDebitHeadIsControlhead { get { return Fields.CoaDebitHeadIsControlhead[this]; } set { Fields.CoaDebitHeadIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field CoaDebitHeadIsControlhead; }


        [DisplayName("Coa Debit Head Is Sub Ledger Allocate"), Expression("jCoaDebitHead.[isCostCenterAllocate]")]
        public Int16? CoaDebitHeadIsCostCenterAllocate { get { return Fields.CoaDebitHeadIsCostCenterAllocate[this]; } set { Fields.CoaDebitHeadIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field CoaDebitHeadIsCostCenterAllocate; }


        [DisplayName("Coa Debit Head Level"), Expression("jCoaDebitHead.[level]")]
        public Int32? CoaDebitHeadLevel { get { return Fields.CoaDebitHeadLevel[this]; } set { Fields.CoaDebitHeadLevel[this] = value; } }
        public partial class RowFields { public Int32Field CoaDebitHeadLevel; }


        [DisplayName("Coa Debit Head Mailing Address"), Expression("jCoaDebitHead.[mailingAddress]")]
        public String CoaDebitHeadMailingAddress { get { return Fields.CoaDebitHeadMailingAddress[this]; } set { Fields.CoaDebitHeadMailingAddress[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadMailingAddress; }


        [DisplayName("Coa Debit Head Mailing Name"), Expression("jCoaDebitHead.[mailingName]")]
        public String CoaDebitHeadMailingName { get { return Fields.CoaDebitHeadMailingName[this]; } set { Fields.CoaDebitHeadMailingName[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadMailingName; }


        [DisplayName("Coa Debit Head Opening Balance"), Expression("jCoaDebitHead.[openingBalance]")]
        public Double? CoaDebitHeadOpeningBalance { get { return Fields.CoaDebitHeadOpeningBalance[this]; } set { Fields.CoaDebitHeadOpeningBalance[this] = value; } }
        public partial class RowFields { public DoubleField CoaDebitHeadOpeningBalance; }


        [DisplayName("Coa Debit Head Remarks"), Expression("jCoaDebitHead.[remarks]")]
        public String CoaDebitHeadRemarks { get { return Fields.CoaDebitHeadRemarks[this]; } set { Fields.CoaDebitHeadRemarks[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadRemarks; }


        [DisplayName("Coa Debit Head Tax Id"), Expression("jCoaDebitHead.[taxID]")]
        public String CoaDebitHeadTaxId { get { return Fields.CoaDebitHeadTaxId[this]; } set { Fields.CoaDebitHeadTaxId[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadTaxId; }


        [DisplayName("Coa Debit Head Ugc Code"), Expression("jCoaDebitHead.[ugcCode]")]
        public String CoaDebitHeadUgcCode { get { return Fields.CoaDebitHeadUgcCode[this]; } set { Fields.CoaDebitHeadUgcCode[this] = value; } }
        public partial class RowFields { public StringField CoaDebitHeadUgcCode; }


        [DisplayName("Coa Debit Head Fund Control Id"), Expression("jCoaDebitHead.[fundControlId]")]
        public Int32? CoaDebitHeadFundControlId { get { return Fields.CoaDebitHeadFundControlId[this]; } set { Fields.CoaDebitHeadFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoaDebitHeadFundControlId; }


        [DisplayName("Coa Debit Head Parent Account Id"), Expression("jCoaDebitHead.[parentAccountId]")]
        public Int32? CoaDebitHeadParentAccountId { get { return Fields.CoaDebitHeadParentAccountId[this]; } set { Fields.CoaDebitHeadParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoaDebitHeadParentAccountId; }


        [DisplayName("Coa Credit Head Account Code"), Expression("jCoaCreditHead.[accountCode]")]
        public String CoaCreditHeadAccountCode { get { return Fields.CoaCreditHeadAccountCode[this]; } set { Fields.CoaCreditHeadAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadAccountCode; }


        [DisplayName("Coa Credit Head Account Code Count"), Expression("jCoaCreditHead.[accountCodeCount]")]
        public Int32? CoaCreditHeadAccountCodeCount { get { return Fields.CoaCreditHeadAccountCodeCount[this]; } set { Fields.CoaCreditHeadAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoaCreditHeadAccountCodeCount; }


        [DisplayName("Coa Credit Head Account Group"), Expression("jCoaCreditHead.[accountGroup]")]
        public String CoaCreditHeadAccountGroup { get { return Fields.CoaCreditHeadAccountGroup[this]; } set { Fields.CoaCreditHeadAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadAccountGroup; }


        [DisplayName("Account Head (Credit)"), Expression("jCoaCreditHead.[accountName]")]
        public String CoaCreditHeadAccountName { get { return Fields.CoaCreditHeadAccountName[this]; } set { Fields.CoaCreditHeadAccountName[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadAccountName; }


        [DisplayName("Coa Credit Head Account Name Bangla"), Expression("jCoaCreditHead.[accountNameBangla]")]
        public String CoaCreditHeadAccountNameBangla { get { return Fields.CoaCreditHeadAccountNameBangla[this]; } set { Fields.CoaCreditHeadAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadAccountNameBangla; }


        [DisplayName("Coa Credit Head Coa Mapping"), Expression("jCoaCreditHead.[coaMapping]")]
        public String CoaCreditHeadCoaMapping { get { return Fields.CoaCreditHeadCoaMapping[this]; } set { Fields.CoaCreditHeadCoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadCoaMapping; }


        [DisplayName("Coa Credit Head Is Bill Ref"), Expression("jCoaCreditHead.[isBillRef]")]
        public Int16? CoaCreditHeadIsBillRef { get { return Fields.CoaCreditHeadIsBillRef[this]; } set { Fields.CoaCreditHeadIsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field CoaCreditHeadIsBillRef; }


        [DisplayName("Coa Credit Head Is Budget Head"), Expression("jCoaCreditHead.[isBudgetHead]")]
        public Int16? CoaCreditHeadIsBudgetHead { get { return Fields.CoaCreditHeadIsBudgetHead[this]; } set { Fields.CoaCreditHeadIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field CoaCreditHeadIsBudgetHead; }


        [DisplayName("Coa Credit Head Is Controlhead"), Expression("jCoaCreditHead.[isControlhead]")]
        public Int16? CoaCreditHeadIsControlhead { get { return Fields.CoaCreditHeadIsControlhead[this]; } set { Fields.CoaCreditHeadIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field CoaCreditHeadIsControlhead; }


        [DisplayName("Coa Credit Head Is Sub Ledger Allocate"), Expression("jCoaCreditHead.[isCostCenterAllocate]")]
        public Int16? CoaCreditHeadIsCostCenterAllocate { get { return Fields.CoaCreditHeadIsCostCenterAllocate[this]; } set { Fields.CoaCreditHeadIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field CoaCreditHeadIsCostCenterAllocate; }


        [DisplayName("Coa Credit Head Level"), Expression("jCoaCreditHead.[level]")]
        public Int32? CoaCreditHeadLevel { get { return Fields.CoaCreditHeadLevel[this]; } set { Fields.CoaCreditHeadLevel[this] = value; } }
        public partial class RowFields { public Int32Field CoaCreditHeadLevel; }


        [DisplayName("Coa Credit Head Mailing Address"), Expression("jCoaCreditHead.[mailingAddress]")]
        public String CoaCreditHeadMailingAddress { get { return Fields.CoaCreditHeadMailingAddress[this]; } set { Fields.CoaCreditHeadMailingAddress[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadMailingAddress; }


        [DisplayName("Coa Credit Head Mailing Name"), Expression("jCoaCreditHead.[mailingName]")]
        public String CoaCreditHeadMailingName { get { return Fields.CoaCreditHeadMailingName[this]; } set { Fields.CoaCreditHeadMailingName[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadMailingName; }


        [DisplayName("Coa Credit Head Opening Balance"), Expression("jCoaCreditHead.[openingBalance]")]
        public Double? CoaCreditHeadOpeningBalance { get { return Fields.CoaCreditHeadOpeningBalance[this]; } set { Fields.CoaCreditHeadOpeningBalance[this] = value; } }
        public partial class RowFields { public DoubleField CoaCreditHeadOpeningBalance; }


        [DisplayName("Coa Credit Head Remarks"), Expression("jCoaCreditHead.[remarks]")]
        public String CoaCreditHeadRemarks { get { return Fields.CoaCreditHeadRemarks[this]; } set { Fields.CoaCreditHeadRemarks[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadRemarks; }


        [DisplayName("Coa Credit Head Tax Id"), Expression("jCoaCreditHead.[taxID]")]
        public String CoaCreditHeadTaxId { get { return Fields.CoaCreditHeadTaxId[this]; } set { Fields.CoaCreditHeadTaxId[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadTaxId; }


        [DisplayName("Coa Credit Head Ugc Code"), Expression("jCoaCreditHead.[ugcCode]")]
        public String CoaCreditHeadUgcCode { get { return Fields.CoaCreditHeadUgcCode[this]; } set { Fields.CoaCreditHeadUgcCode[this] = value; } }
        public partial class RowFields { public StringField CoaCreditHeadUgcCode; }


        [DisplayName("Coa Credit Head Fund Control Id"), Expression("jCoaCreditHead.[fundControlId]")]
        public Int32? CoaCreditHeadFundControlId { get { return Fields.CoaCreditHeadFundControlId[this]; } set { Fields.CoaCreditHeadFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoaCreditHeadFundControlId; }


        [DisplayName("Coa Credit Head Parent Account Id"), Expression("jCoaCreditHead.[parentAccountId]")]
        public Int32? CoaCreditHeadParentAccountId { get { return Fields.CoaCreditHeadParentAccountId[this]; } set { Fields.CoaCreditHeadParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoaCreditHeadParentAccountId; }


        [DisplayName("Coa Sd Account Code"), Expression("jCoaSd.[accountCode]")]
        public String CoaSdAccountCode { get { return Fields.CoaSdAccountCode[this]; } set { Fields.CoaSdAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoaSdAccountCode; }


        [DisplayName("Coa Sd Account Code Count"), Expression("jCoaSd.[accountCodeCount]")]
        public Int32? CoaSdAccountCodeCount { get { return Fields.CoaSdAccountCodeCount[this]; } set { Fields.CoaSdAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoaSdAccountCodeCount; }


        [DisplayName("Coa Sd Account Group"), Expression("jCoaSd.[accountGroup]")]
        public String CoaSdAccountGroup { get { return Fields.CoaSdAccountGroup[this]; } set { Fields.CoaSdAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoaSdAccountGroup; }


        [DisplayName("Coa Sd Account Name"), Expression("jCoaSd.[accountName]")]
        public String CoaSdAccountName { get { return Fields.CoaSdAccountName[this]; } set { Fields.CoaSdAccountName[this] = value; } }
        public partial class RowFields { public StringField CoaSdAccountName; }


        [DisplayName("Coa Sd Account Name Bangla"), Expression("jCoaSd.[accountNameBangla]")]
        public String CoaSdAccountNameBangla { get { return Fields.CoaSdAccountNameBangla[this]; } set { Fields.CoaSdAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField CoaSdAccountNameBangla; }


        [DisplayName("Coa Sd Coa Mapping"), Expression("jCoaSd.[coaMapping]")]
        public String CoaSdCoaMapping { get { return Fields.CoaSdCoaMapping[this]; } set { Fields.CoaSdCoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoaSdCoaMapping; }


        [DisplayName("Coa Sd Is Bill Ref"), Expression("jCoaSd.[isBillRef]")]
        public Int16? CoaSdIsBillRef { get { return Fields.CoaSdIsBillRef[this]; } set { Fields.CoaSdIsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field CoaSdIsBillRef; }


        [DisplayName("Coa Sd Is Budget Head"), Expression("jCoaSd.[isBudgetHead]")]
        public Int16? CoaSdIsBudgetHead { get { return Fields.CoaSdIsBudgetHead[this]; } set { Fields.CoaSdIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field CoaSdIsBudgetHead; }


        [DisplayName("Coa Sd Is Controlhead"), Expression("jCoaSd.[isControlhead]")]
        public Int16? CoaSdIsControlhead { get { return Fields.CoaSdIsControlhead[this]; } set { Fields.CoaSdIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field CoaSdIsControlhead; }


        [DisplayName("Coa Sd Is Sub Ledger Allocate"), Expression("jCoaSd.[isCostCenterAllocate]")]
        public Int16? CoaSdIsCostCenterAllocate { get { return Fields.CoaSdIsCostCenterAllocate[this]; } set { Fields.CoaSdIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field CoaSdIsCostCenterAllocate; }


        [DisplayName("Coa Sd Level"), Expression("jCoaSd.[level]")]
        public Int32? CoaSdLevel { get { return Fields.CoaSdLevel[this]; } set { Fields.CoaSdLevel[this] = value; } }
        public partial class RowFields { public Int32Field CoaSdLevel; }


        [DisplayName("Coa Sd Mailing Address"), Expression("jCoaSd.[mailingAddress]")]
        public String CoaSdMailingAddress { get { return Fields.CoaSdMailingAddress[this]; } set { Fields.CoaSdMailingAddress[this] = value; } }
        public partial class RowFields { public StringField CoaSdMailingAddress; }


        [DisplayName("Coa Sd Mailing Name"), Expression("jCoaSd.[mailingName]")]
        public String CoaSdMailingName { get { return Fields.CoaSdMailingName[this]; } set { Fields.CoaSdMailingName[this] = value; } }
        public partial class RowFields { public StringField CoaSdMailingName; }


        [DisplayName("Coa Sd Opening Balance"), Expression("jCoaSd.[openingBalance]")]
        public Double? CoaSdOpeningBalance { get { return Fields.CoaSdOpeningBalance[this]; } set { Fields.CoaSdOpeningBalance[this] = value; } }
        public partial class RowFields { public DoubleField CoaSdOpeningBalance; }


        [DisplayName("Coa Sd Remarks"), Expression("jCoaSd.[remarks]")]
        public String CoaSdRemarks { get { return Fields.CoaSdRemarks[this]; } set { Fields.CoaSdRemarks[this] = value; } }
        public partial class RowFields { public StringField CoaSdRemarks; }


        [DisplayName("Coa Sd Tax Id"), Expression("jCoaSd.[taxID]")]
        public String CoaSdTaxId { get { return Fields.CoaSdTaxId[this]; } set { Fields.CoaSdTaxId[this] = value; } }
        public partial class RowFields { public StringField CoaSdTaxId; }


        [DisplayName("Coa Sd Ugc Code"), Expression("jCoaSd.[ugcCode]")]
        public String CoaSdUgcCode { get { return Fields.CoaSdUgcCode[this]; } set { Fields.CoaSdUgcCode[this] = value; } }
        public partial class RowFields { public StringField CoaSdUgcCode; }


        [DisplayName("Coa Sd Fund Control Id"), Expression("jCoaSd.[fundControlId]")]
        public Int32? CoaSdFundControlId { get { return Fields.CoaSdFundControlId[this]; } set { Fields.CoaSdFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoaSdFundControlId; }


        [DisplayName("Coa Sd Parent Account Id"), Expression("jCoaSd.[parentAccountId]")]
        public Int32? CoaSdParentAccountId { get { return Fields.CoaSdParentAccountId[this]; } set { Fields.CoaSdParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoaSdParentAccountId; }


        [DisplayName("Coa Vat Account Code"), Expression("jCoaVat.[accountCode]")]
        public String CoaVatAccountCode { get { return Fields.CoaVatAccountCode[this]; } set { Fields.CoaVatAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoaVatAccountCode; }


        [DisplayName("Coa Vat Account Code Count"), Expression("jCoaVat.[accountCodeCount]")]
        public Int32? CoaVatAccountCodeCount { get { return Fields.CoaVatAccountCodeCount[this]; } set { Fields.CoaVatAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoaVatAccountCodeCount; }


        [DisplayName("Coa Vat Account Group"), Expression("jCoaVat.[accountGroup]")]
        public String CoaVatAccountGroup { get { return Fields.CoaVatAccountGroup[this]; } set { Fields.CoaVatAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoaVatAccountGroup; }


        [DisplayName("Coa Vat Account Name"), Expression("jCoaVat.[accountName]")]
        public String CoaVatAccountName { get { return Fields.CoaVatAccountName[this]; } set { Fields.CoaVatAccountName[this] = value; } }
        public partial class RowFields { public StringField CoaVatAccountName; }


        [DisplayName("Coa Vat Account Name Bangla"), Expression("jCoaVat.[accountNameBangla]")]
        public String CoaVatAccountNameBangla { get { return Fields.CoaVatAccountNameBangla[this]; } set { Fields.CoaVatAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField CoaVatAccountNameBangla; }


        [DisplayName("Coa Vat Coa Mapping"), Expression("jCoaVat.[coaMapping]")]
        public String CoaVatCoaMapping { get { return Fields.CoaVatCoaMapping[this]; } set { Fields.CoaVatCoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoaVatCoaMapping; }


        [DisplayName("Coa Vat Is Bill Ref"), Expression("jCoaVat.[isBillRef]")]
        public Int16? CoaVatIsBillRef { get { return Fields.CoaVatIsBillRef[this]; } set { Fields.CoaVatIsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field CoaVatIsBillRef; }


        [DisplayName("Coa Vat Is Budget Head"), Expression("jCoaVat.[isBudgetHead]")]
        public Int16? CoaVatIsBudgetHead { get { return Fields.CoaVatIsBudgetHead[this]; } set { Fields.CoaVatIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field CoaVatIsBudgetHead; }


        [DisplayName("Coa Vat Is Controlhead"), Expression("jCoaVat.[isControlhead]")]
        public Int16? CoaVatIsControlhead { get { return Fields.CoaVatIsControlhead[this]; } set { Fields.CoaVatIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field CoaVatIsControlhead; }


        [DisplayName("Coa Vat Is Sub Ledger Allocate"), Expression("jCoaVat.[isCostCenterAllocate]")]
        public Int16? CoaVatIsCostCenterAllocate { get { return Fields.CoaVatIsCostCenterAllocate[this]; } set { Fields.CoaVatIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field CoaVatIsCostCenterAllocate; }


        [DisplayName("Coa Vat Level"), Expression("jCoaVat.[level]")]
        public Int32? CoaVatLevel { get { return Fields.CoaVatLevel[this]; } set { Fields.CoaVatLevel[this] = value; } }
        public partial class RowFields { public Int32Field CoaVatLevel; }


        [DisplayName("Coa Vat Mailing Address"), Expression("jCoaVat.[mailingAddress]")]
        public String CoaVatMailingAddress { get { return Fields.CoaVatMailingAddress[this]; } set { Fields.CoaVatMailingAddress[this] = value; } }
        public partial class RowFields { public StringField CoaVatMailingAddress; }


        [DisplayName("Coa Vat Mailing Name"), Expression("jCoaVat.[mailingName]")]
        public String CoaVatMailingName { get { return Fields.CoaVatMailingName[this]; } set { Fields.CoaVatMailingName[this] = value; } }
        public partial class RowFields { public StringField CoaVatMailingName; }


        [DisplayName("Coa Vat Opening Balance"), Expression("jCoaVat.[openingBalance]")]
        public Double? CoaVatOpeningBalance { get { return Fields.CoaVatOpeningBalance[this]; } set { Fields.CoaVatOpeningBalance[this] = value; } }
        public partial class RowFields { public DoubleField CoaVatOpeningBalance; }


        [DisplayName("Coa Vat Remarks"), Expression("jCoaVat.[remarks]")]
        public String CoaVatRemarks { get { return Fields.CoaVatRemarks[this]; } set { Fields.CoaVatRemarks[this] = value; } }
        public partial class RowFields { public StringField CoaVatRemarks; }


        [DisplayName("Coa Vat Tax Id"), Expression("jCoaVat.[taxID]")]
        public String CoaVatTaxId { get { return Fields.CoaVatTaxId[this]; } set { Fields.CoaVatTaxId[this] = value; } }
        public partial class RowFields { public StringField CoaVatTaxId; }


        [DisplayName("Coa Vat Ugc Code"), Expression("jCoaVat.[ugcCode]")]
        public String CoaVatUgcCode { get { return Fields.CoaVatUgcCode[this]; } set { Fields.CoaVatUgcCode[this] = value; } }
        public partial class RowFields { public StringField CoaVatUgcCode; }


        [DisplayName("Coa Vat Fund Control Id"), Expression("jCoaVat.[fundControlId]")]
        public Int32? CoaVatFundControlId { get { return Fields.CoaVatFundControlId[this]; } set { Fields.CoaVatFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoaVatFundControlId; }


        [DisplayName("Coa Vat Parent Account Id"), Expression("jCoaVat.[parentAccountId]")]
        public Int32? CoaVatParentAccountId { get { return Fields.CoaVatParentAccountId[this]; } set { Fields.CoaVatParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoaVatParentAccountId; }


        [DisplayName("Coa Tax Account Code"), Expression("jCoaTax.[accountCode]")]
        public String CoaTaxAccountCode { get { return Fields.CoaTaxAccountCode[this]; } set { Fields.CoaTaxAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoaTaxAccountCode; }


        [DisplayName("Coa Tax Account Code Count"), Expression("jCoaTax.[accountCodeCount]")]
        public Int32? CoaTaxAccountCodeCount { get { return Fields.CoaTaxAccountCodeCount[this]; } set { Fields.CoaTaxAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoaTaxAccountCodeCount; }


        [DisplayName("Coa Tax Account Group"), Expression("jCoaTax.[accountGroup]")]
        public String CoaTaxAccountGroup { get { return Fields.CoaTaxAccountGroup[this]; } set { Fields.CoaTaxAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoaTaxAccountGroup; }


        [DisplayName("Coa Tax Account Name"), Expression("jCoaTax.[accountName]")]
        public String CoaTaxAccountName { get { return Fields.CoaTaxAccountName[this]; } set { Fields.CoaTaxAccountName[this] = value; } }
        public partial class RowFields { public StringField CoaTaxAccountName; }


        [DisplayName("Coa Tax Account Name Bangla"), Expression("jCoaTax.[accountNameBangla]")]
        public String CoaTaxAccountNameBangla { get { return Fields.CoaTaxAccountNameBangla[this]; } set { Fields.CoaTaxAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField CoaTaxAccountNameBangla; }


        [DisplayName("Coa Tax Coa Mapping"), Expression("jCoaTax.[coaMapping]")]
        public String CoaTaxCoaMapping { get { return Fields.CoaTaxCoaMapping[this]; } set { Fields.CoaTaxCoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoaTaxCoaMapping; }


        [DisplayName("Coa Tax Is Bill Ref"), Expression("jCoaTax.[isBillRef]")]
        public Int16? CoaTaxIsBillRef { get { return Fields.CoaTaxIsBillRef[this]; } set { Fields.CoaTaxIsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field CoaTaxIsBillRef; }


        [DisplayName("Coa Tax Is Budget Head"), Expression("jCoaTax.[isBudgetHead]")]
        public Int16? CoaTaxIsBudgetHead { get { return Fields.CoaTaxIsBudgetHead[this]; } set { Fields.CoaTaxIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field CoaTaxIsBudgetHead; }


        [DisplayName("Coa Tax Is Controlhead"), Expression("jCoaTax.[isControlhead]")]
        public Int16? CoaTaxIsControlhead { get { return Fields.CoaTaxIsControlhead[this]; } set { Fields.CoaTaxIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field CoaTaxIsControlhead; }


        [DisplayName("Coa Tax Is Sub Ledger Allocate"), Expression("jCoaTax.[isCostCenterAllocate]")]
        public Int16? CoaTaxIsCostCenterAllocate { get { return Fields.CoaTaxIsCostCenterAllocate[this]; } set { Fields.CoaTaxIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field CoaTaxIsCostCenterAllocate; }


        [DisplayName("Coa Tax Level"), Expression("jCoaTax.[level]")]
        public Int32? CoaTaxLevel { get { return Fields.CoaTaxLevel[this]; } set { Fields.CoaTaxLevel[this] = value; } }
        public partial class RowFields { public Int32Field CoaTaxLevel; }


        [DisplayName("Coa Tax Mailing Address"), Expression("jCoaTax.[mailingAddress]")]
        public String CoaTaxMailingAddress { get { return Fields.CoaTaxMailingAddress[this]; } set { Fields.CoaTaxMailingAddress[this] = value; } }
        public partial class RowFields { public StringField CoaTaxMailingAddress; }


        [DisplayName("Coa Tax Mailing Name"), Expression("jCoaTax.[mailingName]")]
        public String CoaTaxMailingName { get { return Fields.CoaTaxMailingName[this]; } set { Fields.CoaTaxMailingName[this] = value; } }
        public partial class RowFields { public StringField CoaTaxMailingName; }


        [DisplayName("Coa Tax Opening Balance"), Expression("jCoaTax.[openingBalance]")]
        public Double? CoaTaxOpeningBalance { get { return Fields.CoaTaxOpeningBalance[this]; } set { Fields.CoaTaxOpeningBalance[this] = value; } }
        public partial class RowFields { public DoubleField CoaTaxOpeningBalance; }


        [DisplayName("Coa Tax Remarks"), Expression("jCoaTax.[remarks]")]
        public String CoaTaxRemarks { get { return Fields.CoaTaxRemarks[this]; } set { Fields.CoaTaxRemarks[this] = value; } }
        public partial class RowFields { public StringField CoaTaxRemarks; }


        [DisplayName("Coa Tax Tax Id"), Expression("jCoaTax.[taxID]")]
        public String CoaTaxTaxId { get { return Fields.CoaTaxTaxId[this]; } set { Fields.CoaTaxTaxId[this] = value; } }
        public partial class RowFields { public StringField CoaTaxTaxId; }


        [DisplayName("Coa Tax Ugc Code"), Expression("jCoaTax.[ugcCode]")]
        public String CoaTaxUgcCode { get { return Fields.CoaTaxUgcCode[this]; } set { Fields.CoaTaxUgcCode[this] = value; } }
        public partial class RowFields { public StringField CoaTaxUgcCode; }


        [DisplayName("Coa Tax Fund Control Id"), Expression("jCoaTax.[fundControlId]")]
        public Int32? CoaTaxFundControlId { get { return Fields.CoaTaxFundControlId[this]; } set { Fields.CoaTaxFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoaTaxFundControlId; }


        [DisplayName("Coa Tax Parent Account Id"), Expression("jCoaTax.[parentAccountId]")]
        public Int32? CoaTaxParentAccountId { get { return Fields.CoaTaxParentAccountId[this]; } set { Fields.CoaTaxParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoaTaxParentAccountId; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TemplateName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccVoucherTemplateRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_VoucherTemplate]")
            {
                LocalTextPrefix = "Transaction.AccVoucherTemplate";
            }
        }
        #endregion RowFields
    }
}

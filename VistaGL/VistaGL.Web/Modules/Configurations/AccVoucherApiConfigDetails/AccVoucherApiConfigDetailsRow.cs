using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("ACCDB"), DisplayName("Voucher API Config. Details"), InstanceName("Voucher API Config. Details"), TwoLevelCached]
    [ReadPermission("Configurations:AccVoucherApiConfig:Read")]
    [InsertPermission("Configurations:AccVoucherApiConfig:Insert")]
    [UpdatePermission("Configurations:AccVoucherApiConfig:Update")]
    [DeletePermission("Configurations:AccVoucherApiConfig:Delete")]
    [LookupScript("Configurations.AccVoucherApiConfigDetails")]
    public sealed class AccVoucherApiConfigDetailsRow : Row, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Config
        [DisplayName("Config"), ForeignKey("[dbo].[acc_VoucherAPIConfig]", "Id"), LeftJoin("jConfig"), TextualField("ConfigConfigName")]
        [LookupEditor(typeof(Configurations.Entities.AccVoucherApiConfigRow), InplaceAdd = true)]
        public Int32? ConfigId { get { return Fields.ConfigId[this]; } set { Fields.ConfigId[this] = value; } }
        public partial class RowFields { public Int32Field ConfigId; }
        #endregion ConfigId

        #region Account Head
        [DisplayName("Account Head"), ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jAccountHead"), TextualField("AccountHeadAccountCode")]
        public Int32? AccountHeadId { get { return Fields.AccountHeadId[this]; } set { Fields.AccountHeadId[this] = value; } }
        public partial class RowFields { public Int32Field AccountHeadId; }
        #endregion AccountHeadId

        #region Dr Cr
        [DisplayName("Dr Cr"), Size(50), QuickSearch]
        public String DrCr { get { return Fields.DrCr[this]; } set { Fields.DrCr[this] = value; } }
        public partial class RowFields { public StringField DrCr; }
        #endregion DrCr

        #region Description
        [DisplayName("Description"), Size(50)]
        public String Description { get { return Fields.Description[this]; } set { Fields.Description[this] = value; } }
        public partial class RowFields { public StringField Description; }
        #endregion Description

        #region Subledger
        [DisplayName("Sub Ledger"), ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jSubLedger"), TextualField("SubLedgerAccountCode")]
        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow), InplaceAdd = true,
            FilterField = nameof(Transaction.Entities.AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        public Int32? SubLedgerId { get { return Fields.SubLedgerId[this]; } set { Fields.SubLedgerId[this] = value; } }
        public partial class RowFields { public Int32Field SubLedgerId; }
        #endregion Subledger

        #region Foreign Fields

        [DisplayName("Config Config Name"), Expression("jConfig.[ConfigName]")]
        public String ConfigConfigName { get { return Fields.ConfigConfigName[this]; } set { Fields.ConfigConfigName[this] = value; } }
        public partial class RowFields { public StringField ConfigConfigName; }


        [DisplayName("Config Module Id"), Expression("jConfig.[ModuleId]")]
        [MinSelectLevel(SelectLevel.List)]
        public String ConfigModuleId { get { return Fields.ConfigModuleId[this]; } set { Fields.ConfigModuleId[this] = value; } }
        public partial class RowFields { public StringField ConfigModuleId; }


        [DisplayName("Config Form Name"), Expression("jConfig.[FormName]")]
        public String ConfigFormName { get { return Fields.ConfigFormName[this]; } set { Fields.ConfigFormName[this] = value; } }
        public partial class RowFields { public StringField ConfigFormName; }


        [DisplayName("Config Vouchr Type Id"), Expression("jConfig.[VouchrTypeId]")]
         [MinSelectLevel(SelectLevel.List)]
        public Int32? ConfigVouchrTypeId { get { return Fields.ConfigVouchrTypeId[this]; } set { Fields.ConfigVouchrTypeId[this] = value; } }
        public partial class RowFields { public Int32Field ConfigVouchrTypeId; }


        [DisplayName("Config Transaction Id"), Expression("jConfig.[TransactionId]")]
         [MinSelectLevel(SelectLevel.List)]
        public Int32? ConfigTransactionId { get { return Fields.ConfigTransactionId[this]; } set { Fields.ConfigTransactionId[this] = value; } }
        public partial class RowFields { public Int32Field ConfigTransactionId; }


        [DisplayName("Config Transaction Mode"), Expression("jConfig.[TransactionMode]")]
         [MinSelectLevel(SelectLevel.List)]
        public String ConfigTransactionMode { get { return Fields.ConfigTransactionMode[this]; } set { Fields.ConfigTransactionMode[this] = value; } }
        public partial class RowFields { public StringField ConfigTransactionMode; }


        [DisplayName("Config Narration"), Expression("jConfig.[Narration]")]
         [MinSelectLevel(SelectLevel.List)]
        public String ConfigNarration { get { return Fields.ConfigNarration[this]; } set { Fields.ConfigNarration[this] = value; } }
        public partial class RowFields { public StringField ConfigNarration; }


        [DisplayName("Config Fund Control Id"), Expression("jConfig.[FundControlId]")]
         [MinSelectLevel(SelectLevel.List)]
        public Int32? ConfigFundControlId { get { return Fields.ConfigFundControlId[this]; } set { Fields.ConfigFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field ConfigFundControlId; }


        [DisplayName("Account Head Account Code"), Expression("jAccountHead.[accountCode]")]
        public String AccountHeadAccountCode { get { return Fields.AccountHeadAccountCode[this]; } set { Fields.AccountHeadAccountCode[this] = value; } }
        public partial class RowFields { public StringField AccountHeadAccountCode; }


        [DisplayName("Account Head Account Code Count"), Expression("jAccountHead.[accountCodeCount]")]
        public Int32? AccountHeadAccountCodeCount { get { return Fields.AccountHeadAccountCodeCount[this]; } set { Fields.AccountHeadAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field AccountHeadAccountCodeCount; }


        [DisplayName("Account Head Account Group"), Expression("jAccountHead.[accountGroup]")]
        public String AccountHeadAccountGroup { get { return Fields.AccountHeadAccountGroup[this]; } set { Fields.AccountHeadAccountGroup[this] = value; } }
        public partial class RowFields { public StringField AccountHeadAccountGroup; }


        [DisplayName("Account Head"), Expression("CONCAT(jAccountHead.[accountName] ,' (', jSubLedger.[name], ')')")]
        [MinSelectLevel(SelectLevel.List)]
        public String AccountHeadAccountName { get { return Fields.AccountHeadAccountName[this]; } set { Fields.AccountHeadAccountName[this] = value; } }
        public partial class RowFields { public StringField AccountHeadAccountName; }


        [DisplayName("Account Head Account Name Bangla"), Expression("jAccountHead.[accountNameBangla]")]
        public String AccountHeadAccountNameBangla { get { return Fields.AccountHeadAccountNameBangla[this]; } set { Fields.AccountHeadAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField AccountHeadAccountNameBangla; }


        [DisplayName("Account Head Coa Mapping"), Expression("jAccountHead.[coaMapping]")]
        public String AccountHeadCoaMapping { get { return Fields.AccountHeadCoaMapping[this]; } set { Fields.AccountHeadCoaMapping[this] = value; } }
        public partial class RowFields { public StringField AccountHeadCoaMapping; }


        [DisplayName("Account Head Is Bill Ref"), Expression("jAccountHead.[isBillRef]")]
        public Int16? AccountHeadIsBillRef { get { return Fields.AccountHeadIsBillRef[this]; } set { Fields.AccountHeadIsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field AccountHeadIsBillRef; }


        [DisplayName("Account Head Is Budget Head"), Expression("jAccountHead.[isBudgetHead]")]
        public Int16? AccountHeadIsBudgetHead { get { return Fields.AccountHeadIsBudgetHead[this]; } set { Fields.AccountHeadIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field AccountHeadIsBudgetHead; }


        [DisplayName("Account Head Is Controlhead"), Expression("jAccountHead.[isControlhead]")]
        public Int16? AccountHeadIsControlhead { get { return Fields.AccountHeadIsControlhead[this]; } set { Fields.AccountHeadIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field AccountHeadIsControlhead; }


        [DisplayName("Account Head Is Sub Ledger Allocate"), Expression("jAccountHead.[isCostCenterAllocate]")]
        public Int16? AccountHeadIsCostCenterAllocate { get { return Fields.AccountHeadIsCostCenterAllocate[this]; } set { Fields.AccountHeadIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field AccountHeadIsCostCenterAllocate; }


        [DisplayName("Account Head Level"), Expression("jAccountHead.[level]")]
        public Int32? AccountHeadLevel { get { return Fields.AccountHeadLevel[this]; } set { Fields.AccountHeadLevel[this] = value; } }
        public partial class RowFields { public Int32Field AccountHeadLevel; }


        [DisplayName("Account Head Mailing Address"), Expression("jAccountHead.[mailingAddress]")]
        public String AccountHeadMailingAddress { get { return Fields.AccountHeadMailingAddress[this]; } set { Fields.AccountHeadMailingAddress[this] = value; } }
        public partial class RowFields { public StringField AccountHeadMailingAddress; }


        [DisplayName("Account Head Mailing Name"), Expression("jAccountHead.[mailingName]")]
        public String AccountHeadMailingName { get { return Fields.AccountHeadMailingName[this]; } set { Fields.AccountHeadMailingName[this] = value; } }
        public partial class RowFields { public StringField AccountHeadMailingName; }


        [DisplayName("Account Head Opening Balance"), Expression("jAccountHead.[openingBalance]")]
        public Double? AccountHeadOpeningBalance { get { return Fields.AccountHeadOpeningBalance[this]; } set { Fields.AccountHeadOpeningBalance[this] = value; } }
        public partial class RowFields { public DoubleField AccountHeadOpeningBalance; }


        [DisplayName("Account Head Remarks"), Expression("jAccountHead.[remarks]")]
        public String AccountHeadRemarks { get { return Fields.AccountHeadRemarks[this]; } set { Fields.AccountHeadRemarks[this] = value; } }
        public partial class RowFields { public StringField AccountHeadRemarks; }


        [DisplayName("Account Head Tax Id"), Expression("jAccountHead.[taxID]")]
        public String AccountHeadTaxId { get { return Fields.AccountHeadTaxId[this]; } set { Fields.AccountHeadTaxId[this] = value; } }
        public partial class RowFields { public StringField AccountHeadTaxId; }


        [DisplayName("Account Head Ugc Code"), Expression("jAccountHead.[ugcCode]")]
        public String AccountHeadUgcCode { get { return Fields.AccountHeadUgcCode[this]; } set { Fields.AccountHeadUgcCode[this] = value; } }
        public partial class RowFields { public StringField AccountHeadUgcCode; }


        [DisplayName("Account Head Fund Control Id"), Expression("jAccountHead.[fundControlId]")]
        public Int32? AccountHeadFundControlId { get { return Fields.AccountHeadFundControlId[this]; } set { Fields.AccountHeadFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field AccountHeadFundControlId; }


        [DisplayName("Account Head Parent Account Id"), Expression("jAccountHead.[parentAccountId]")]
        public Int32? AccountHeadParentAccountId { get { return Fields.AccountHeadParentAccountId[this]; } set { Fields.AccountHeadParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field AccountHeadParentAccountId; }


        [DisplayName("Account Head Multi Currency Id"), Expression("jAccountHead.[MultiCurrencyID]")]
        public Int32? AccountHeadMultiCurrencyId { get { return Fields.AccountHeadMultiCurrencyId[this]; } set { Fields.AccountHeadMultiCurrencyId[this] = value; } }
        public partial class RowFields { public Int32Field AccountHeadMultiCurrencyId; }


        [DisplayName("Account Head Effect Cash Flow"), Expression("jAccountHead.[EffectCashFlow]")]
        public Int32? AccountHeadEffectCashFlow { get { return Fields.AccountHeadEffectCashFlow[this]; } set { Fields.AccountHeadEffectCashFlow[this] = value; } }
        public partial class RowFields { public Int32Field AccountHeadEffectCashFlow; }


        [DisplayName("Account Head User Code"), Expression("jAccountHead.[UserCode]")]
        public String AccountHeadUserCode { get { return Fields.AccountHeadUserCode[this]; } set { Fields.AccountHeadUserCode[this] = value; } }
        public partial class RowFields { public StringField AccountHeadUserCode; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.DrCr; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccVoucherApiConfigDetailsRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[acc_VoucherAPIConfigDetails]")
            {
                LocalTextPrefix = "Configurations.AccVoucherApiConfigDetails";
            }
        }
        #endregion RowFields
    }
}

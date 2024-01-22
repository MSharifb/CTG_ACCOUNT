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

    [ConnectionKey("ACCDB"), DisplayName("acc_VoucherAPIDetails"), InstanceName("acc_VoucherAPIDetails"), TwoLevelCached]
    [ReadPermission("Transaction:AccVoucherInformation:Read")]
    [InsertPermission("Transaction:AccVoucherInformation:Insert")]
    [UpdatePermission("Transaction:AccVoucherInformation:Update")]
    [DeletePermission("Transaction:AccVoucherInformation:Delete")]
    [LookupScript("Configurations.AccVoucherApiDetails")]
    public sealed class AccVoucherApiDetailsRow : Row, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Voucher Api
        [DisplayName("Voucher Api"), Column("VoucherAPIId"), ForeignKey("[dbo].[acc_VoucherAPI]", "Id"), LeftJoin("jVoucherApi"), TextualField("VoucherApiNarration")]
        [LookupEditor(typeof(Configurations.Entities.AccVoucherApiRow), InplaceAdd = true)]
        public Int32? VoucherApiId { get { return Fields.VoucherApiId[this]; } set { Fields.VoucherApiId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherApiId; }
        #endregion VoucherApiId

        #region Account Head
        [DisplayName("Account Head"), ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jAccountHead"), TextualField("AccountHeadAccountCode")]
        [LookupEditor(typeof(Configurations.Entities.AccChartofAccountsRow), InplaceAdd = true)]
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

        #region Amount
        [DisplayName("Amount")]
        public Double? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DoubleField Amount; }
        #endregion Amount


        #region Foreign Fields

        [DisplayName("Voucher Api Config Id"), Expression("jVoucherApi.[ConfigId]")]
        public Int32? VoucherApiConfigId { get { return Fields.VoucherApiConfigId[this]; } set { Fields.VoucherApiConfigId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherApiConfigId; }


        [DisplayName("Voucher Api Vouchr Type Id"), Expression("jVoucherApi.[VouchrTypeId]")]
        [MinSelectLevel(SelectLevel.List)]
        public Int32? VoucherApiVouchrTypeId { get { return Fields.VoucherApiVouchrTypeId[this]; } set { Fields.VoucherApiVouchrTypeId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherApiVouchrTypeId; }


        [DisplayName("Voucher Api Transaction Id"), Expression("jVoucherApi.[TransactionId]")]
        [MinSelectLevel(SelectLevel.List)]
        public Int32? VoucherApiTransactionId { get { return Fields.VoucherApiTransactionId[this]; } set { Fields.VoucherApiTransactionId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherApiTransactionId; }


        [DisplayName("Voucher Api Narration"), Expression("jVoucherApi.[Narration]")]
        [MinSelectLevel(SelectLevel.List)]
        public String VoucherApiNarration { get { return Fields.VoucherApiNarration[this]; } set { Fields.VoucherApiNarration[this] = value; } }
        public partial class RowFields { public StringField VoucherApiNarration; }


        [DisplayName("Voucher Api Transaction Mode"), Expression("jVoucherApi.[TransactionMode]")]
        [MinSelectLevel(SelectLevel.List)]
        public String VoucherApiTransactionMode { get { return Fields.VoucherApiTransactionMode[this]; } set { Fields.VoucherApiTransactionMode[this] = value; } }
        public partial class RowFields { public StringField VoucherApiTransactionMode; }


        [DisplayName("Voucher Api Emp Id"), Expression("jVoucherApi.[EmpId]")]
        [MinSelectLevel(SelectLevel.List)]
        public Int32? VoucherApiEmpId { get { return Fields.VoucherApiEmpId[this]; } set { Fields.VoucherApiEmpId[this] = value; } }
        public partial class RowFields { public Int32Field VoucherApiEmpId; }


        [DisplayName("Account Head Account Code"), Expression("jAccountHead.[accountCode]")]
        public String AccountHeadAccountCode { get { return Fields.AccountHeadAccountCode[this]; } set { Fields.AccountHeadAccountCode[this] = value; } }
        public partial class RowFields { public StringField AccountHeadAccountCode; }


        [DisplayName("Account Head Account Code Count"), Expression("jAccountHead.[accountCodeCount]")]
        public Int32? AccountHeadAccountCodeCount { get { return Fields.AccountHeadAccountCodeCount[this]; } set { Fields.AccountHeadAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field AccountHeadAccountCodeCount; }


        [DisplayName("Account Head Account Group"), Expression("jAccountHead.[accountGroup]")]
        public String AccountHeadAccountGroup { get { return Fields.AccountHeadAccountGroup[this]; } set { Fields.AccountHeadAccountGroup[this] = value; } }
        public partial class RowFields { public StringField AccountHeadAccountGroup; }


        [DisplayName("Account Head Account Name"), Expression("jAccountHead.[accountName]")]
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
        public AccVoucherApiDetailsRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[acc_VoucherAPIDetails]")
            {
                LocalTextPrefix = "Configurations.AccVoucherApiDetails";
            }
        }
        #endregion RowFields
    }
}

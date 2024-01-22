
namespace VistaGL.Configurations.Entities
{
    using Modules.Common;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("ACCDB"), DisplayName("Bank Advice Letter Config"), InstanceName("Bank Advice Letter Config"), TwoLevelCached]
    [ReadPermission("Configurations:AccSetupForBankAdviceLetter:Read")]
    [InsertPermission("Configurations:AccSetupForBankAdviceLetter:Insert")]
    [UpdatePermission("Configurations:AccSetupForBankAdviceLetter:Update")]
    [DeletePermission("Configurations:AccSetupForBankAdviceLetter:Delete")]
    [LookupScript("Configurations.AccSetupForBankAdviceLetter", Permission = "?")]
    public sealed class AccSetupForBankAdviceLetterRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Coa
        [DisplayName("Coa"), Column("COAId"), NotNull, Unique, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoa"), TextualField("CoaAccountGroup")]
        [LookupEditor(typeof(Configurations.Entities.AccChartofAccountsRow))]
        public Int32? CoaId { get { return Fields.CoaId[this]; } set { Fields.CoaId[this] = value; } }
        public partial class RowFields { public Int32Field CoaId; }
        #endregion CoaId

        #region Memorandum No
        [DisplayName("Memorandum No"), Size(500), QuickSearch]
        public String MemorandumNo { get { return Fields.MemorandumNo[this]; } set { Fields.MemorandumNo[this] = value; } }
        public partial class RowFields { public StringField MemorandumNo; }
        #endregion MemorandumNo

        #region Duplication
        [DisplayName("Duplication"), Size(500)]
        public String Duplication { get { return Fields.Duplication[this]; } set { Fields.Duplication[this] = value; } }
        public partial class RowFields { public StringField Duplication; }
        #endregion Duplication


        #region Is Auto Bank Advice
        [DisplayName("Is Auto Bank Advice"), LookupInclude]
        public Boolean? IsAutoBankAdvice { get { return Fields.IsAutoBankAdvice[this]; } set { Fields.IsAutoBankAdvice[this] = value; } }
        public partial class RowFields { public BooleanField IsAutoBankAdvice; }
        #endregion IsAutoBankAdvice


        #region Zone Info Id
        [DisplayName("Zone Info Id"), NotNull]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region Fund Control Id
        [DisplayName("Fund Control Id"), NotNull]
        public Int32? FundControlId { get { return Fields.FundControlId[this]; } set { Fields.FundControlId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlId; }
        #endregion FundControlId


        #region Foreign Fields

        [DisplayName("Coa Parent Account Id"), Expression("jCoa.[parentAccountId]")]
        public Int32? CoaParentAccountId { get { return Fields.CoaParentAccountId[this]; } set { Fields.CoaParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoaParentAccountId; }


        [DisplayName("Coa Level"), Expression("jCoa.[level]")]
        public Int32? CoaLevel { get { return Fields.CoaLevel[this]; } set { Fields.CoaLevel[this] = value; } }
        public partial class RowFields { public Int32Field CoaLevel; }


        [DisplayName("Coa Account Group"), Expression("jCoa.[accountGroup]")]
        public String CoaAccountGroup { get { return Fields.CoaAccountGroup[this]; } set { Fields.CoaAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoaAccountGroup; }


        [DisplayName("Coa Account Code"), Expression("jCoa.[accountCode]")]
        public String CoaAccountCode { get { return Fields.CoaAccountCode[this]; } set { Fields.CoaAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoaAccountCode; }


        [DisplayName("Coa Account Code Count"), Expression("jCoa.[accountCodeCount]")]
        public Int32? CoaAccountCodeCount { get { return Fields.CoaAccountCodeCount[this]; } set { Fields.CoaAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoaAccountCodeCount; }


        [DisplayName("Coa User Code"), Expression("jCoa.[UserCode]")]
        public String CoaUserCode { get { return Fields.CoaUserCode[this]; } set { Fields.CoaUserCode[this] = value; } }
        public partial class RowFields { public StringField CoaUserCode; }


        [DisplayName("Coa Account Name"), Expression("jCoa.[accountName]")]
        public String CoaAccountName { get { return Fields.CoaAccountName[this]; } set { Fields.CoaAccountName[this] = value; } }
        public partial class RowFields { public StringField CoaAccountName; }


        [DisplayName("Coa Coa Mapping"), Expression("jCoa.[coaMapping]")]
        public String CoaCoaMapping { get { return Fields.CoaCoaMapping[this]; } set { Fields.CoaCoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoaCoaMapping; }


        [DisplayName("Coa Is Controlhead"), Expression("jCoa.[isControlhead]")]
        public Int16? CoaIsControlhead { get { return Fields.CoaIsControlhead[this]; } set { Fields.CoaIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field CoaIsControlhead; }


        [DisplayName("Coa Is Cost Center Allocate"), Expression("jCoa.[isCostCenterAllocate]")]
        public Int16? CoaIsCostCenterAllocate { get { return Fields.CoaIsCostCenterAllocate[this]; } set { Fields.CoaIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field CoaIsCostCenterAllocate; }


        [DisplayName("Coa Opening Balance"), Expression("jCoa.[openingBalance]")]
        public Decimal? CoaOpeningBalance { get { return Fields.CoaOpeningBalance[this]; } set { Fields.CoaOpeningBalance[this] = value; } }
        public partial class RowFields { public DecimalField CoaOpeningBalance; }


        [DisplayName("Coa Account Name Bangla"), Expression("jCoa.[accountNameBangla]")]
        public String CoaAccountNameBangla { get { return Fields.CoaAccountNameBangla[this]; } set { Fields.CoaAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField CoaAccountNameBangla; }


        [DisplayName("Coa Is Bill Ref"), Expression("jCoa.[isBillRef]")]
        public Int16? CoaIsBillRef { get { return Fields.CoaIsBillRef[this]; } set { Fields.CoaIsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field CoaIsBillRef; }


        [DisplayName("Coa Mailing Address"), Expression("jCoa.[mailingAddress]")]
        public String CoaMailingAddress { get { return Fields.CoaMailingAddress[this]; } set { Fields.CoaMailingAddress[this] = value; } }
        public partial class RowFields { public StringField CoaMailingAddress; }


        [DisplayName("Coa Mailing Name"), Expression("jCoa.[mailingName]")]
        public String CoaMailingName { get { return Fields.CoaMailingName[this]; } set { Fields.CoaMailingName[this] = value; } }
        public partial class RowFields { public StringField CoaMailingName; }


        [DisplayName("Coa Remarks"), Expression("jCoa.[remarks]")]
        public String CoaRemarks { get { return Fields.CoaRemarks[this]; } set { Fields.CoaRemarks[this] = value; } }
        public partial class RowFields { public StringField CoaRemarks; }


        [DisplayName("Coa Tax Id"), Expression("jCoa.[taxID]")]
        public String CoaTaxId { get { return Fields.CoaTaxId[this]; } set { Fields.CoaTaxId[this] = value; } }
        public partial class RowFields { public StringField CoaTaxId; }


        [DisplayName("Coa Ugc Code"), Expression("jCoa.[ugcCode]")]
        public String CoaUgcCode { get { return Fields.CoaUgcCode[this]; } set { Fields.CoaUgcCode[this] = value; } }
        public partial class RowFields { public StringField CoaUgcCode; }


        [DisplayName("Coa Multi Currency Id"), Expression("jCoa.[MultiCurrencyID]")]
        public Int32? CoaMultiCurrencyId { get { return Fields.CoaMultiCurrencyId[this]; } set { Fields.CoaMultiCurrencyId[this] = value; } }
        public partial class RowFields { public Int32Field CoaMultiCurrencyId; }


        [DisplayName("Coa Effect Cash Flow"), Expression("jCoa.[EffectCashFlow]")]
        public Int32? CoaEffectCashFlow { get { return Fields.CoaEffectCashFlow[this]; } set { Fields.CoaEffectCashFlow[this] = value; } }
        public partial class RowFields { public Int32Field CoaEffectCashFlow; }


        [DisplayName("Coa Noa Acc Type Id"), Expression("jCoa.[NoaAccTypeId]")]
        public Int32? CoaNoaAccTypeId { get { return Fields.CoaNoaAccTypeId[this]; } set { Fields.CoaNoaAccTypeId[this] = value; } }
        public partial class RowFields { public Int32Field CoaNoaAccTypeId; }


        [DisplayName("Coa Fund Control Id"), Expression("jCoa.[fundControlId]")]
        public Int32? CoaFundControlId { get { return Fields.CoaFundControlId[this]; } set { Fields.CoaFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoaFundControlId; }


        [DisplayName("Coa Sort Order"), Expression("jCoa.[SortOrder]")]
        public Int32? CoaSortOrder { get { return Fields.CoaSortOrder[this]; } set { Fields.CoaSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field CoaSortOrder; }


        [DisplayName("Coa Show Sum In Receipt Payment Report"), Expression("jCoa.[ShowSumInReceiptPaymentReport]")]
        public Boolean? CoaShowSumInReceiptPaymentReport { get { return Fields.CoaShowSumInReceiptPaymentReport[this]; } set { Fields.CoaShowSumInReceiptPaymentReport[this] = value; } }
        public partial class RowFields { public BooleanField CoaShowSumInReceiptPaymentReport; }


        [DisplayName("Coa Is Budget Head"), Expression("jCoa.[isBudgetHead]")]
        public Boolean? CoaIsBudgetHead { get { return Fields.CoaIsBudgetHead[this]; } set { Fields.CoaIsBudgetHead[this] = value; } }
        public partial class RowFields { public BooleanField CoaIsBudgetHead; }


        [DisplayName("Coa Budget Group Id"), Expression("jCoa.[BudgetGroupId]")]
        public Int32? CoaBudgetGroupId { get { return Fields.CoaBudgetGroupId[this]; } set { Fields.CoaBudgetGroupId[this] = value; } }
        public partial class RowFields { public Int32Field CoaBudgetGroupId; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.MemorandumNo; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccSetupForBankAdviceLetterRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public const string TableName = "[dbo].[acc_SetupForBankAdviceLetter]";

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_SetupForBankAdviceLetter]")
            {
                LocalTextPrefix = "Configurations.AccSetupForBankAdviceLetter";
            }
        }
        #endregion RowFields
    }
}

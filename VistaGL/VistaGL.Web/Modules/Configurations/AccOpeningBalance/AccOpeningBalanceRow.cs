using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("ACCDB"), DisplayName("Opening Balance"), InstanceName("Opening Balance"), TwoLevelCached]
    [ReadPermission("Configurations:AccChartofAccounts:Read")]
    [InsertPermission("Configurations:AccChartofAccounts:Insert")]
    [UpdatePermission("Configurations:AccChartofAccounts:Update")]
    [DeletePermission("Configurations:AccChartofAccounts:Delete")]
    [LookupScript("Configurations.AccOpeningBalance")]
    public sealed class AccOpeningBalanceRow : NRow, IIdRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Opening Balance
        [DisplayName("Opening Balance"), NotNull]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public Decimal? OpeningBalance { get { return Fields.OpeningBalance[this]; } set { Fields.OpeningBalance[this] = value; } }
        public partial class RowFields { public DecimalField OpeningBalance; }
        #endregion OpeningBalance

        #region Co Aid
        [DisplayName("Chart of Account"), Column("CoAID"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoAid"), TextualField("CoAidAccountCode")]
        [LookupEditor(typeof(Configurations.Entities.AccChartofAccountsRow))]
        public Int32? CoAid { get { return Fields.CoAid[this]; } set { Fields.CoAid[this] = value; } }
        public partial class RowFields { public Int32Field CoAid; }
        #endregion CoAid

        #region Zone
        [DisplayName("Zone"), Column("ZoneID"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZone"), TextualField("ZoneZoneName")]
        [LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneId { get { return Fields.ZoneId[this]; } set { Fields.ZoneId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneId; }
        #endregion ZoneId

        #region Fund Control
        [DisplayName("Fund Control"), Column("FundControlID"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControl"), TextualField("FundControlCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
        public Int32? FundControlId { get { return Fields.FundControlId[this]; } set { Fields.FundControlId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlId; }
        #endregion FundControlId

        #region Foreign Fields

        [DisplayName("Co Aid Account Code"), Expression("jCoAid.[accountCode]")]
        public String CoAidAccountCode { get { return Fields.CoAidAccountCode[this]; } set { Fields.CoAidAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoAidAccountCode; }


        [DisplayName("Co Aid Account Code Count"), Expression("jCoAid.[accountCodeCount]")]
        public Int32? CoAidAccountCodeCount { get { return Fields.CoAidAccountCodeCount[this]; } set { Fields.CoAidAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoAidAccountCodeCount; }


        [DisplayName("Co Aid Account Group"), Expression("jCoAid.[accountGroup]")]
        public String CoAidAccountGroup { get { return Fields.CoAidAccountGroup[this]; } set { Fields.CoAidAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoAidAccountGroup; }


        [DisplayName("Account Name"), Expression("jCoAid.[accountName]")]
        public String CoAidAccountName { get { return Fields.CoAidAccountName[this]; } set { Fields.CoAidAccountName[this] = value; } }
        public partial class RowFields { public StringField CoAidAccountName; }


        [DisplayName("Co Aid Account Name Bangla"), Expression("jCoAid.[accountNameBangla]")]
        public String CoAidAccountNameBangla { get { return Fields.CoAidAccountNameBangla[this]; } set { Fields.CoAidAccountNameBangla[this] = value; } }
        public partial class RowFields { public StringField CoAidAccountNameBangla; }


        [DisplayName("Co Aid Coa Mapping"), Expression("jCoAid.[coaMapping]")]
        public String CoAidCoaMapping { get { return Fields.CoAidCoaMapping[this]; } set { Fields.CoAidCoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoAidCoaMapping; }


        [DisplayName("Co Aid Is Bill Ref"), Expression("jCoAid.[isBillRef]")]
        public Int16? CoAidIsBillRef { get { return Fields.CoAidIsBillRef[this]; } set { Fields.CoAidIsBillRef[this] = value; } }
        public partial class RowFields { public Int16Field CoAidIsBillRef; }


        [DisplayName("Co Aid Is Budget Head"), Expression("jCoAid.[isBudgetHead]")]
        public Int16? CoAidIsBudgetHead { get { return Fields.CoAidIsBudgetHead[this]; } set { Fields.CoAidIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field CoAidIsBudgetHead; }


        [DisplayName("Co Aid Is Controlhead"), Expression("jCoAid.[isControlhead]")]
        public Int16? CoAidIsControlhead { get { return Fields.CoAidIsControlhead[this]; } set { Fields.CoAidIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field CoAidIsControlhead; }


        [DisplayName("Co Aid Is Sub Ledger Allocate"), Expression("jCoAid.[isCostCenterAllocate]")]
        public Int16? CoAidIsCostCenterAllocate { get { return Fields.CoAidIsCostCenterAllocate[this]; } set { Fields.CoAidIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field CoAidIsCostCenterAllocate; }


        [DisplayName("Co Aid Level"), Expression("jCoAid.[level]")]
        public Int32? CoAidLevel { get { return Fields.CoAidLevel[this]; } set { Fields.CoAidLevel[this] = value; } }
        public partial class RowFields { public Int32Field CoAidLevel; }


        [DisplayName("Co Aid Mailing Address"), Expression("jCoAid.[mailingAddress]")]
        public String CoAidMailingAddress { get { return Fields.CoAidMailingAddress[this]; } set { Fields.CoAidMailingAddress[this] = value; } }
        public partial class RowFields { public StringField CoAidMailingAddress; }


        [DisplayName("Co Aid Mailing Name"), Expression("jCoAid.[mailingName]")]
        public String CoAidMailingName { get { return Fields.CoAidMailingName[this]; } set { Fields.CoAidMailingName[this] = value; } }
        public partial class RowFields { public StringField CoAidMailingName; }


        [DisplayName("Co Aid Opening Balance"), Expression("jCoAid.[openingBalance]")]
        public Double? CoAidOpeningBalance { get { return Fields.CoAidOpeningBalance[this]; } set { Fields.CoAidOpeningBalance[this] = value; } }
        public partial class RowFields { public DoubleField CoAidOpeningBalance; }


        [DisplayName("Co Aid Remarks"), Expression("jCoAid.[remarks]")]
        public String CoAidRemarks { get { return Fields.CoAidRemarks[this]; } set { Fields.CoAidRemarks[this] = value; } }
        public partial class RowFields { public StringField CoAidRemarks; }


        [DisplayName("Co Aid Tax Id"), Expression("jCoAid.[taxID]")]
        public String CoAidTaxId { get { return Fields.CoAidTaxId[this]; } set { Fields.CoAidTaxId[this] = value; } }
        public partial class RowFields { public StringField CoAidTaxId; }


        [DisplayName("Co Aid Ugc Code"), Expression("jCoAid.[ugcCode]")]
        public String CoAidUgcCode { get { return Fields.CoAidUgcCode[this]; } set { Fields.CoAidUgcCode[this] = value; } }
        public partial class RowFields { public StringField CoAidUgcCode; }


        [DisplayName("Co Aid Fund Control Id"), Expression("jCoAid.[fundControlId]")]
        public Int32? CoAidFundControlId { get { return Fields.CoAidFundControlId[this]; } set { Fields.CoAidFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoAidFundControlId; }


        [DisplayName("Co Aid Parent Account Id"), Expression("jCoAid.[parentAccountId]")]
        public Int32? CoAidParentAccountId { get { return Fields.CoAidParentAccountId[this]; } set { Fields.CoAidParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoAidParentAccountId; }


        [DisplayName("Co Aid Multi Currency Id"), Expression("jCoAid.[MultiCurrencyID]")]
        public Int32? CoAidMultiCurrencyId { get { return Fields.CoAidMultiCurrencyId[this]; } set { Fields.CoAidMultiCurrencyId[this] = value; } }
        public partial class RowFields { public Int32Field CoAidMultiCurrencyId; }


        [DisplayName("Co Aid Effect Cash Flow"), Expression("jCoAid.[EffectCashFlow]")]
        public Int32? CoAidEffectCashFlow { get { return Fields.CoAidEffectCashFlow[this]; } set { Fields.CoAidEffectCashFlow[this] = value; } }
        public partial class RowFields { public Int32Field CoAidEffectCashFlow; }


        [DisplayName("Zone Zone Name"), Expression("jZone.[ZoneName]")]
        public String ZoneZoneName { get { return Fields.ZoneZoneName[this]; } set { Fields.ZoneZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneZoneName; }


        [DisplayName("Zone Zone Name In Bengali"), Expression("jZone.[ZoneNameInBengali]")]
        public String ZoneZoneNameInBengali { get { return Fields.ZoneZoneNameInBengali[this]; } set { Fields.ZoneZoneNameInBengali[this] = value; } }
        public partial class RowFields { public StringField ZoneZoneNameInBengali; }


        [DisplayName("Zone Zone Code"), Expression("jZone.[ZoneCode]")]
        public String ZoneZoneCode { get { return Fields.ZoneZoneCode[this]; } set { Fields.ZoneZoneCode[this] = value; } }
        public partial class RowFields { public StringField ZoneZoneCode; }


        [DisplayName("Zone Sort Order"), Expression("jZone.[SortOrder]")]
        public Int32? ZoneSortOrder { get { return Fields.ZoneSortOrder[this]; } set { Fields.ZoneSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field ZoneSortOrder; }


        [DisplayName("Zone Organogram Category Type Id"), Expression("jZone.[OrganogramCategoryTypeId]")]
        public Int32? ZoneOrganogramCategoryTypeId { get { return Fields.ZoneOrganogramCategoryTypeId[this]; } set { Fields.ZoneOrganogramCategoryTypeId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneOrganogramCategoryTypeId; }


        [DisplayName("Zone Zone Address"), Expression("jZone.[ZoneAddress]")]
        public String ZoneZoneAddress { get { return Fields.ZoneZoneAddress[this]; } set { Fields.ZoneZoneAddress[this] = value; } }
        public partial class RowFields { public StringField ZoneZoneAddress; }


        [DisplayName("Zone Zone Address In Bengali"), Expression("jZone.[ZoneAddressInBengali]")]
        public String ZoneZoneAddressInBengali { get { return Fields.ZoneZoneAddressInBengali[this]; } set { Fields.ZoneZoneAddressInBengali[this] = value; } }
        public partial class RowFields { public StringField ZoneZoneAddressInBengali; }


        [DisplayName("Zone Prefix"), Expression("jZone.[Prefix]")]
        public String ZonePrefix { get { return Fields.ZonePrefix[this]; } set { Fields.ZonePrefix[this] = value; } }
        public partial class RowFields { public StringField ZonePrefix; }


        [DisplayName("Zone Is Head Office"), Expression("jZone.[IsHeadOffice]")]
        public Boolean? ZoneIsHeadOffice { get { return Fields.ZoneIsHeadOffice[this]; } set { Fields.ZoneIsHeadOffice[this] = value; } }
        public partial class RowFields { public BooleanField ZoneIsHeadOffice; }


        [DisplayName("Fund Control Code"), Expression("jFundControl.[code]")]
        public String FundControlCode { get { return Fields.FundControlCode[this]; } set { Fields.FundControlCode[this] = value; } }
        public partial class RowFields { public StringField FundControlCode; }


        [DisplayName("Fund Control Fund Control Name"), Expression("jFundControl.[fundControlName]")]
        public String FundControlFundControlName { get { return Fields.FundControlFundControlName[this]; } set { Fields.FundControlFundControlName[this] = value; } }
        public partial class RowFields { public StringField FundControlFundControlName; }


        [DisplayName("Fund Control Booking Date"), Expression("jFundControl.[bookingDate]")]
        public DateTime? FundControlBookingDate { get { return Fields.FundControlBookingDate[this]; } set { Fields.FundControlBookingDate[this] = value; } }
        public partial class RowFields { public DateTimeField FundControlBookingDate; }


        //[DisplayName("Fund Control Base Currency"), Expression("jFundControl.[baseCurrency]")]
        //public String FundControlBaseCurrency { get { return Fields.FundControlBaseCurrency[this]; } set { Fields.FundControlBaseCurrency[this] = value; } }
        //public partial class RowFields { public StringField FundControlBaseCurrency; }


        //[DisplayName("Fund Control Currency Symbol"), Expression("jFundControl.[currencySymbol]")]
        //public String FundControlCurrencySymbol { get { return Fields.FundControlCurrencySymbol[this]; } set { Fields.FundControlCurrencySymbol[this] = value; } }
        //public partial class RowFields { public StringField FundControlCurrencySymbol; }


        [DisplayName("Fund Control Address"), Expression("jFundControl.[address]")]
        public String FundControlAddress { get { return Fields.FundControlAddress[this]; } set { Fields.FundControlAddress[this] = value; } }
        public partial class RowFields { public StringField FundControlAddress; }


        [DisplayName("Fund Control Phone"), Expression("jFundControl.[phone]")]
        public String FundControlPhone { get { return Fields.FundControlPhone[this]; } set { Fields.FundControlPhone[this] = value; } }
        public partial class RowFields { public StringField FundControlPhone; }


        [DisplayName("Fund Control Mobile"), Expression("jFundControl.[mobile]")]
        public String FundControlMobile { get { return Fields.FundControlMobile[this]; } set { Fields.FundControlMobile[this] = value; } }
        public partial class RowFields { public StringField FundControlMobile; }


        [DisplayName("Fund Control Fax"), Expression("jFundControl.[fax]")]
        public String FundControlFax { get { return Fields.FundControlFax[this]; } set { Fields.FundControlFax[this] = value; } }
        public partial class RowFields { public StringField FundControlFax; }


        [DisplayName("Fund Control Email"), Expression("jFundControl.[email]")]
        public String FundControlEmail { get { return Fields.FundControlEmail[this]; } set { Fields.FundControlEmail[this] = value; } }
        public partial class RowFields { public StringField FundControlEmail; }


        [DisplayName("Fund Control Web Url"), Expression("jFundControl.[webUrl]")]
        public String FundControlWebUrl { get { return Fields.FundControlWebUrl[this]; } set { Fields.FundControlWebUrl[this] = value; } }
        public partial class RowFields { public StringField FundControlWebUrl; }


        [DisplayName("Fund Control Remarks"), Expression("jFundControl.[remarks]")]
        public String FundControlRemarks { get { return Fields.FundControlRemarks[this]; } set { Fields.FundControlRemarks[this] = value; } }
        public partial class RowFields { public StringField FundControlRemarks; }


        [DisplayName("Fund Control Zone Info Id"), Expression("jFundControl.[ZoneInfoId]")]
        public Int32? FundControlZoneInfoId { get { return Fields.FundControlZoneInfoId[this]; } set { Fields.FundControlZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlZoneInfoId; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccOpeningBalanceRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_OpeningBalance]")
            {
                LocalTextPrefix = "Configurations.AccOpeningBalance";
            }
        }
        #endregion RowFields
    }
}

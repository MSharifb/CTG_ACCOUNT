
namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[acc_ReportTypeGroupOpeningBalance]")] [DisplayName("Report Type Group Opening Balance"), InstanceName("Report Type Group Opening Balance")]
    [ReadPermission("Configurations:AccReportTypeGroupOpeningBalance:Read")]
    [InsertPermission("Configurations:AccReportTypeGroupOpeningBalance:Insert")]
    [UpdatePermission("Configurations:AccReportTypeGroupOpeningBalance:Update")]
    [DeletePermission("Configurations:AccReportTypeGroupOpeningBalance:Delete")]
    [LookupScript("Configurations.AccReportTypeGroupOpeningBalance", Permission = "?")]
    public sealed class AccReportTypeGroupOpeningBalanceRow : NRow, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Group"), NotNull, ForeignKey("[dbo].[acc_ReportTypeGroupSetup]", "Id"), LeftJoin("jGroup"), TextualField("GroupGroupName")]
        [LookupEditor(typeof(AccReportTypeGroupSetupRow), CascadeFrom = "ReportTypeId")]
        public Int32? GroupId
        {
            get { return Fields.GroupId[this]; }
            set { Fields.GroupId[this] = value; }
        }

        [DisplayName("Zone"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZone"), TextualField("ZoneZoneName")]
        [LookupEditor(typeof(PrmZoneInfoRow))]
        public Int32? ZoneId
        {
            get { return Fields.ZoneId[this]; }
            set { Fields.ZoneId[this] = value; }
        }

        [DisplayName("Fund Control"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControl"), TextualField("FundControlCode")]
        public Int32? FundControlId
        {
            get { return Fields.FundControlId[this]; }
            set { Fields.FundControlId[this] = value; }
        }

        [DisplayName("Opening Balance"), Size(19), Scale(5)]
        public Decimal? OpeningBalance
        {
            get { return Fields.OpeningBalance[this]; }
            set { Fields.OpeningBalance[this] = value; }
        }



        [DisplayName("Group Parent Id"), Expression("jGroup.[ParentId]")]
        public Int32? GroupParentId
        {
            get { return Fields.GroupParentId[this]; }
            set { Fields.GroupParentId[this] = value; }
        }

        [DisplayName("Report Type"), Expression("jGroup.[ReportTypeId]")]
        [LookupEditor(typeof(AccReportTypeRow))]
        public Int32? ReportTypeId
        {
            get { return Fields.ReportTypeId[this]; }
            set { Fields.ReportTypeId[this] = value; }
        }

        [DisplayName("Group Name"), Expression("jGroup.[GroupName]")]
        public String GroupGroupName
        {
            get { return Fields.GroupGroupName[this]; }
            set { Fields.GroupGroupName[this] = value; }
        }

        [DisplayName("Group Sorting Order"), Expression("jGroup.[SortingOrder]")]
        public Int32? GroupSortingOrder
        {
            get { return Fields.GroupSortingOrder[this]; }
            set { Fields.GroupSortingOrder[this] = value; }
        }

        [DisplayName("Group Show Auto Sum"), Expression("jGroup.[ShowAutoSum]")]
        public Boolean? GroupShowAutoSum
        {
            get { return Fields.GroupShowAutoSum[this]; }
            set { Fields.GroupShowAutoSum[this] = value; }
        }

        [DisplayName("Group Note No"), Expression("jGroup.[NoteNo]")]
        public Int32? GroupNoteNo
        {
            get { return Fields.GroupNoteNo[this]; }
            set { Fields.GroupNoteNo[this] = value; }
        }

        [DisplayName("Group Add Blank Space Before"), Expression("jGroup.[AddBlankSpaceBefore]")]
        public Boolean? GroupAddBlankSpaceBefore
        {
            get { return Fields.GroupAddBlankSpaceBefore[this]; }
            set { Fields.GroupAddBlankSpaceBefore[this] = value; }
        }

        [DisplayName("Group Add Blank Space After"), Expression("jGroup.[AddBlankSpaceAfter]")]
        public Boolean? GroupAddBlankSpaceAfter
        {
            get { return Fields.GroupAddBlankSpaceAfter[this]; }
            set { Fields.GroupAddBlankSpaceAfter[this] = value; }
        }

        [DisplayName("Group Show Bottom Border"), Expression("jGroup.[ShowBottomBorder]")]
        public Boolean? GroupShowBottomBorder
        {
            get { return Fields.GroupShowBottomBorder[this]; }
            set { Fields.GroupShowBottomBorder[this] = value; }
        }

        [DisplayName("Group Show Upper Border"), Expression("jGroup.[ShowUpperBorder]")]
        public Boolean? GroupShowUpperBorder
        {
            get { return Fields.GroupShowUpperBorder[this]; }
            set { Fields.GroupShowUpperBorder[this] = value; }
        }

        [DisplayName("Group Show Left Border"), Expression("jGroup.[ShowLeftBorder]")]
        public Boolean? GroupShowLeftBorder
        {
            get { return Fields.GroupShowLeftBorder[this]; }
            set { Fields.GroupShowLeftBorder[this] = value; }
        }

        [DisplayName("Group Show Right Border"), Expression("jGroup.[ShowRightBorder]")]
        public Boolean? GroupShowRightBorder
        {
            get { return Fields.GroupShowRightBorder[this]; }
            set { Fields.GroupShowRightBorder[this] = value; }
        }

        [DisplayName("Group Fund Control Id"), Expression("jGroup.[FundControlId]")]
        public Int32? GroupFundControlId
        {
            get { return Fields.GroupFundControlId[this]; }
            set { Fields.GroupFundControlId[this] = value; }
        }



        [DisplayName("Zone Name"), Expression("jZone.[ZoneName]")]
        public String ZoneZoneName
        {
            get { return Fields.ZoneZoneName[this]; }
            set { Fields.ZoneZoneName[this] = value; }
        }

        [DisplayName("Zone Zone Name In Bengali"), Expression("jZone.[ZoneNameInBengali]")]
        public String ZoneZoneNameInBengali
        {
            get { return Fields.ZoneZoneNameInBengali[this]; }
            set { Fields.ZoneZoneNameInBengali[this] = value; }
        }

        [DisplayName("Zone Zone Code"), Expression("jZone.[ZoneCode]")]
        public String ZoneZoneCode
        {
            get { return Fields.ZoneZoneCode[this]; }
            set { Fields.ZoneZoneCode[this] = value; }
        }

        [DisplayName("Zone Sort Order"), Expression("jZone.[SortOrder]")]
        public Int32? ZoneSortOrder
        {
            get { return Fields.ZoneSortOrder[this]; }
            set { Fields.ZoneSortOrder[this] = value; }
        }

        [DisplayName("Zone Organogram Category Type Id"), Expression("jZone.[OrganogramCategoryTypeId]")]
        public Int32? ZoneOrganogramCategoryTypeId
        {
            get { return Fields.ZoneOrganogramCategoryTypeId[this]; }
            set { Fields.ZoneOrganogramCategoryTypeId[this] = value; }
        }

        [DisplayName("Zone Zone Address"), Expression("jZone.[ZoneAddress]")]
        public String ZoneZoneAddress
        {
            get { return Fields.ZoneZoneAddress[this]; }
            set { Fields.ZoneZoneAddress[this] = value; }
        }

        [DisplayName("Zone Zone Address In Bengali"), Expression("jZone.[ZoneAddressInBengali]")]
        public String ZoneZoneAddressInBengali
        {
            get { return Fields.ZoneZoneAddressInBengali[this]; }
            set { Fields.ZoneZoneAddressInBengali[this] = value; }
        }

        [DisplayName("Zone Prefix"), Expression("jZone.[Prefix]")]
        public String ZonePrefix
        {
            get { return Fields.ZonePrefix[this]; }
            set { Fields.ZonePrefix[this] = value; }
        }

        [DisplayName("Zone Is Head Office"), Expression("jZone.[IsHeadOffice]")]
        public Boolean? ZoneIsHeadOffice
        {
            get { return Fields.ZoneIsHeadOffice[this]; }
            set { Fields.ZoneIsHeadOffice[this] = value; }
        }

        [DisplayName("Zone Zone Code For Billing System"), Expression("jZone.[ZoneCodeForBillingSystem]")]
        public String ZoneZoneCodeForBillingSystem
        {
            get { return Fields.ZoneZoneCodeForBillingSystem[this]; }
            set { Fields.ZoneZoneCodeForBillingSystem[this] = value; }
        }



        [DisplayName("Fund Control Code"), Expression("jFundControl.[code]")]
        public String FundControlCode
        {
            get { return Fields.FundControlCode[this]; }
            set { Fields.FundControlCode[this] = value; }
        }

        [DisplayName("Fund Control Fund Control Name"), Expression("jFundControl.[fundControlName]")]
        public String FundControlFundControlName
        {
            get { return Fields.FundControlFundControlName[this]; }
            set { Fields.FundControlFundControlName[this] = value; }
        }

        [DisplayName("Fund Control Booking Date"), Expression("jFundControl.[bookingDate]")]
        public DateTime? FundControlBookingDate
        {
            get { return Fields.FundControlBookingDate[this]; }
            set { Fields.FundControlBookingDate[this] = value; }
        }

        [DisplayName("Fund Control Currency Id"), Expression("jFundControl.[currencyId]")]
        public Int32? FundControlCurrencyId
        {
            get { return Fields.FundControlCurrencyId[this]; }
            set { Fields.FundControlCurrencyId[this] = value; }
        }

        [DisplayName("Fund Control Address"), Expression("jFundControl.[address]")]
        public String FundControlAddress
        {
            get { return Fields.FundControlAddress[this]; }
            set { Fields.FundControlAddress[this] = value; }
        }

        [DisplayName("Fund Control Phone"), Expression("jFundControl.[phone]")]
        public String FundControlPhone
        {
            get { return Fields.FundControlPhone[this]; }
            set { Fields.FundControlPhone[this] = value; }
        }

        [DisplayName("Fund Control Mobile"), Expression("jFundControl.[mobile]")]
        public String FundControlMobile
        {
            get { return Fields.FundControlMobile[this]; }
            set { Fields.FundControlMobile[this] = value; }
        }

        [DisplayName("Fund Control Fax"), Expression("jFundControl.[fax]")]
        public String FundControlFax
        {
            get { return Fields.FundControlFax[this]; }
            set { Fields.FundControlFax[this] = value; }
        }

        [DisplayName("Fund Control Email"), Expression("jFundControl.[email]")]
        public String FundControlEmail
        {
            get { return Fields.FundControlEmail[this]; }
            set { Fields.FundControlEmail[this] = value; }
        }

        [DisplayName("Fund Control Web Url"), Expression("jFundControl.[webUrl]")]
        public String FundControlWebUrl
        {
            get { return Fields.FundControlWebUrl[this]; }
            set { Fields.FundControlWebUrl[this] = value; }
        }

        [DisplayName("Fund Control Remarks"), Expression("jFundControl.[remarks]")]
        public String FundControlRemarks
        {
            get { return Fields.FundControlRemarks[this]; }
            set { Fields.FundControlRemarks[this] = value; }
        }

        [DisplayName("Fund Control Zone Info Id"), Expression("jFundControl.[ZoneInfoId]")]
        public Int32? FundControlZoneInfoId
        {
            get { return Fields.FundControlZoneInfoId[this]; }
            set { Fields.FundControlZoneInfoId[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccReportTypeGroupOpeningBalanceRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {

            public Int32Field Id;

            public Int32Field GroupId;

            public Int32Field ZoneId;

            public Int32Field FundControlId;

            public DecimalField OpeningBalance;



            public Int32Field GroupParentId;

            public Int32Field ReportTypeId;

            public StringField GroupGroupName;

            public Int32Field GroupSortingOrder;

            public BooleanField GroupShowAutoSum;

            public Int32Field GroupNoteNo;

            public BooleanField GroupAddBlankSpaceBefore;

            public BooleanField GroupAddBlankSpaceAfter;

            public BooleanField GroupShowBottomBorder;

            public BooleanField GroupShowUpperBorder;

            public BooleanField GroupShowLeftBorder;

            public BooleanField GroupShowRightBorder;

            public Int32Field GroupFundControlId;



            public StringField ZoneZoneName;

            public StringField ZoneZoneNameInBengali;

            public StringField ZoneZoneCode;

            public Int32Field ZoneSortOrder;

            public Int32Field ZoneOrganogramCategoryTypeId;

            public StringField ZoneZoneAddress;

            public StringField ZoneZoneAddressInBengali;

            public StringField ZonePrefix;

            public BooleanField ZoneIsHeadOffice;

            public StringField ZoneZoneCodeForBillingSystem;



            public StringField FundControlCode;

            public StringField FundControlFundControlName;

            public DateTimeField FundControlBookingDate;

            public Int32Field FundControlCurrencyId;

            public StringField FundControlAddress;

            public StringField FundControlPhone;

            public StringField FundControlMobile;

            public StringField FundControlFax;

            public StringField FundControlEmail;

            public StringField FundControlWebUrl;

            public StringField FundControlRemarks;

            public Int32Field FundControlZoneInfoId;


		}
    }
}

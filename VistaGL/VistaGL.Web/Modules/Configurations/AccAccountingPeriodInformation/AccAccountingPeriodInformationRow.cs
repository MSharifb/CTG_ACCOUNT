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

    [ConnectionKey("ACCDB"), DisplayName("Accounting Period"), InstanceName("Accounting Period"), TwoLevelCached]
    [ReadPermission("Configurations:AccAccountingPeriodInformation:Read")]
    [InsertPermission("Configurations:AccAccountingPeriodInformation:Insert")]
    [UpdatePermission("Configurations:AccAccountingPeriodInformation:Update")]
    [DeletePermission("Configurations:AccAccountingPeriodInformation:Delete")]
    [LookupScript("Configurations.AccAccountingPeriodInformation", Permission ="?")]
    public sealed class AccAccountingPeriodInformationRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Is Active
        [DisplayName("Active"), Column("isActive")]
        public Boolean? IsActive { get { return Fields.IsActive[this]; } set { Fields.IsActive[this] = value; } }
        public partial class RowFields { public BooleanField IsActive; }
        #endregion IsActive

        #region Is Closed
        [DisplayName("Closed"), Column("isClosed"), LookupInclude]
        public Boolean? IsClosed { get { return Fields.IsClosed[this]; } set { Fields.IsClosed[this] = value; } }
        public partial class RowFields { public BooleanField IsClosed; }
        #endregion IsClosed

        #region Period End Date
        [DisplayName("Period End Date"), Column("periodEndDate"), NotNull, LookupInclude]
        public DateTime? PeriodEndDate { get { return Fields.PeriodEndDate[this]; } set { Fields.PeriodEndDate[this] = value; } }
        public partial class RowFields { public DateTimeField PeriodEndDate; }
        #endregion PeriodEndDate

        #region Period Start Date
        [DisplayName("Period Start Date"), Column("periodStartDate"), NotNull, LookupInclude]
        public DateTime? PeriodStartDate { get { return Fields.PeriodStartDate[this]; } set { Fields.PeriodStartDate[this] = value; } }
        public partial class RowFields { public DateTimeField PeriodStartDate; }
        #endregion PeriodStartDate

        #region Year Name
        [DisplayName("Year Name"), Column("yearName"), Size(10), NotNull, QuickSearch, LookupInclude]
        public String YearName { get { return Fields.YearName[this]; } set { Fields.YearName[this] = value; } }
        public partial class RowFields { public StringField YearName; }
        #endregion YearName

        #region Fund Control Information
        [DisplayName("Fund Control"), Column("fundControlInformation_id"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControlInformation"), TextualField("FundControlInformationCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
        public Int32? FundControlInformationId { get { return Fields.FundControlInformationId[this]; } set { Fields.FundControlInformationId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlInformationId; }
        #endregion FundControlInformationId


        #region Foreign Fields

        [DisplayName("Fund Control Information Code"), Expression("jFundControlInformation.[code]")]
        public String FundControlInformationCode { get { return Fields.FundControlInformationCode[this]; } set { Fields.FundControlInformationCode[this] = value; } }
        public partial class RowFields { public StringField FundControlInformationCode; }

        [DisplayName("Fund Control"), Expression("jFundControlInformation.[fundControlName]")]
        public String FundControlInformationFundControlName { get { return Fields.FundControlInformationFundControlName[this]; } set { Fields.FundControlInformationFundControlName[this] = value; } }
        public partial class RowFields { public StringField FundControlInformationFundControlName; }

        [DisplayName("Fund Control Information Remarks"), Expression("jFundControlInformation.[remarks]")]
        public String FundControlInformationRemarks { get { return Fields.FundControlInformationRemarks[this]; } set { Fields.FundControlInformationRemarks[this] = value; } }
        public partial class RowFields { public StringField FundControlInformationRemarks; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.YearName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccAccountingPeriodInformationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_Accounting_Period_Information]")
            {
                LocalTextPrefix = "Configurations.AccAccountingPeriodInformation";
            }
        }
        #endregion RowFields
    }
}

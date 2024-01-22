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

    [ConnectionKey("ACCDB"), DisplayName("NOA"), InstanceName("NOA"), TwoLevelCached]
    [ReadPermission("Transaction:AccNoa:Read")]
    [InsertPermission("Transaction:AccNoa:Insert")]
    [UpdatePermission("Transaction:AccNoa:Update")]
    [DeletePermission("Transaction:AccNoa:Delete")]
    [LookupScript("Transaction.AccNoa", Permission = "?")]
    public sealed class AccNoaRow : Row, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity, LookupInclude]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Noa Number
        [DisplayName("NOA Number"), Column("NOANumber"), Size(150), QuickSearch, NotNull, LookupInclude]
        public String NoaNumber { get { return Fields.NoaNumber[this]; } set { Fields.NoaNumber[this] = value; } }
        public partial class RowFields { public StringField NoaNumber; }
        #endregion NoaNumber

        #region Noa Date
        [DisplayName("Date"), Column("NOADate"), NotNull, LookupInclude]
        public DateTime? NoaDate { get { return Fields.NoaDate[this]; } set { Fields.NoaDate[this] = value; } }
        public partial class RowFields { public DateTimeField NoaDate; }
        #endregion NoaDate

        #region Sub Ledger
        [DisplayName("Party Name"), ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jCostCenter"), TextualField("CostCenterCode"), NotNull, LookupInclude]
        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow), InplaceAdd = true)]
        public Int32? CostCenterId { get { return Fields.CostCenterId[this]; } set { Fields.CostCenterId[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterId; }
        #endregion CostCenterId

        #region Contact Value
        [DisplayName("Estimated Value"), Size(18), Scale(2), LookupInclude]
        public Decimal? ContactValue { get { return Fields.ContactValue[this]; } set { Fields.ContactValue[this] = value; } }
        public partial class RowFields { public DecimalField ContactValue; }
        #endregion ContactValue

        #region Nameof Contract
        [DisplayName("Name of Work"), Size(500), LookupInclude]
        public String NameofContract { get { return Fields.NameofContract[this]; } set { Fields.NameofContract[this] = value; } }
        public partial class RowFields { public StringField NameofContract; }
        #endregion NameofContract

        #region Contract Date
        [DisplayName("Contract Date"), LookupInclude]
        public DateTime? ContractDate { get { return Fields.ContractDate[this]; } set { Fields.ContractDate[this] = value; } }
        public partial class RowFields { public DateTimeField ContractDate; }
        #endregion ContractDate

        #region AdministrativeDate
        [DisplayName("Administrative Date")]
        public DateTime? AdministrativeDate { get { return Fields.AdministrativeDate[this]; } set { Fields.AdministrativeDate[this] = value; } }
        public partial class RowFields { public DateTimeField AdministrativeDate; }
        #endregion AdministrativeDate

        #region TechnicalDate
        [DisplayName("Technical Date")]
        public DateTime? TechnicalDate { get { return Fields.TechnicalDate[this]; } set { Fields.TechnicalDate[this] = value; } }
        public partial class RowFields { public DateTimeField TechnicalDate; }
        #endregion TechnicalDate

        #region FinancialDate
        [DisplayName("Financial Date")]
        public DateTime? FinancialDate { get { return Fields.FinancialDate[this]; } set { Fields.FinancialDate[this] = value; } }
        public partial class RowFields { public DateTimeField FinancialDate; }
        #endregion FinancialDate
        #region Budget Provision
        [DisplayName("Budget Provision"), Size(18), Scale(2)]
        public Decimal? BudgetProvision { get { return Fields.BudgetProvision[this]; } set { Fields.BudgetProvision[this] = value; } }
        public partial class RowFields { public DecimalField BudgetProvision; }
        #endregion Budget Provision

        #region AdministrativeApproved
        [DisplayName("Administrative Approved"), Size(150), QuickSearch]
        public String AdministrativeApproved { get { return Fields.AdministrativeApproved[this]; } set { Fields.AdministrativeApproved[this] = value; } }
        public partial class RowFields { public StringField AdministrativeApproved; }
        #endregion AdministrativeApproved
        #region TechnicalApproved
        [DisplayName("Technical Approved"), Size(150), QuickSearch]
        public String TechnicalApproved { get { return Fields.TechnicalApproved[this]; } set { Fields.TechnicalApproved[this] = value; } }
        public partial class RowFields { public StringField TechnicalApproved; }
        #endregion TechnicalApproved
        #region TechnicalApproved
        [DisplayName("Financial Approved"), Size(150), QuickSearch]
        public String FinancialApproved { get { return Fields.FinancialApproved[this]; } set { Fields.FinancialApproved[this] = value; } }
        public partial class RowFields { public StringField FinancialApproved; }
        #endregion TechnicalApproved
        #region TenderNo
        [DisplayName("Tender No"), Size(150), QuickSearch]
        public String TenderNo { get { return Fields.TenderNo[this]; } set { Fields.TenderNo[this] = value; } }
        public partial class RowFields { public StringField TenderNo; }
        #endregion TenderNo
        #region NameofContractor
        [DisplayName("Name of Contractor"), Size(250), QuickSearch, LookupInclude]
        public String NameofContractor { get { return Fields.NameofContractor[this]; } set { Fields.NameofContractor[this] = value; } }
        public partial class RowFields { public StringField NameofContractor; }
        #endregion NameofContractor
        #region ContractorAddress
        [DisplayName("Contractor Address"), Size(250), QuickSearch, LookupInclude]
        public String ContractorAddress { get { return Fields.ContractorAddress[this]; } set { Fields.ContractorAddress[this] = value; } }
        public partial class RowFields { public StringField ContractorAddress; }
        #endregion ContractorAddress

        #region SecurityMoney
        [DisplayName("Security/Earnest Money"), Size(18), Scale(2)]
        public Decimal? SecurityMoney { get { return Fields.SecurityMoney[this]; } set { Fields.SecurityMoney[this] = value; } }
        public partial class RowFields { public DecimalField SecurityMoney; }
        #endregion SecurityMoney
        #region WorkStartOn
        [DisplayName("Work Start On")]
        public DateTime? WorkStartOn { get { return Fields.WorkStartOn[this]; } set { Fields.WorkStartOn[this] = value; } }
        public partial class RowFields { public DateTimeField WorkStartOn; }
        #endregion WorkStartOn
        #region CompilationDate
        [DisplayName("Compilation Date")]
        public DateTime? CompilationDate { get { return Fields.CompilationDate[this]; } set { Fields.CompilationDate[this] = value; } }
        public partial class RowFields { public DateTimeField CompilationDate; }
        #endregion CompilationDate
        #region MBNo
        [DisplayName("M.B. No"), Size(150), QuickSearch]
        public String MBNo { get { return Fields.MBNo[this]; } set { Fields.MBNo[this] = value; } }
        public partial class RowFields { public StringField MBNo; }
        #endregion MBNo


        #region Zone Info
        [Column("ZoneInfoId"), ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        [LookupInclude]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        [DisplayName("Zone Name"), Expression("jZoneInfo.[ZoneName]"), QuickSearch(SearchType.Contains)]
        public String ZoneInfoZoneName { get { return Fields.ZoneInfoZoneName[this]; } set { Fields.ZoneInfoZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneInfoZoneName; }


        #region Foreign Fields


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NoaNumber; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccNoaRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public const string TableName = "[dbo].[acc_NOA]";

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[acc_NOA]")
            {
                LocalTextPrefix = "Transaction.AccNoa";
            }
        }
        #endregion RowFields
    }
}

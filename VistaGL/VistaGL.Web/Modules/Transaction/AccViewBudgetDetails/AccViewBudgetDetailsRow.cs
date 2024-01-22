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

    [ConnectionKey("ACCDB"), DisplayName("acc_view_BudgetDetails"), InstanceName("acc_view_BudgetDetails"), TwoLevelCached]
    //[ReadPermission("Transaction:AccViewBudget:Read")]
    //[InsertPermission("Transaction:AccViewBudget:Insert")]
    //[UpdatePermission("Transaction:AccViewBudget:Update")]
    //[DeletePermission("Transaction:AccViewBudget:Delete")]
    //[LookupScript("Transaction.AccViewBudgetDetails")]
    public sealed class AccViewBudgetDetailsRow : Row, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), NotNull]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Account Name
        [DisplayName("Account Name"), Column("accountName"), Size(100), NotNull, QuickSearch]
        public String AccountName { get { return Fields.AccountName[this]; } set { Fields.AccountName[this] = value; } }
        public partial class RowFields { public StringField AccountName; }
        #endregion AccountName

        #region Quantity
        [DisplayName("Quantity"), Column("quantity"), Size(18), Scale(2)]
        public Decimal? Quantity { get { return Fields.Quantity[this]; } set { Fields.Quantity[this] = value; } }
        public partial class RowFields { public DecimalField Quantity; }
        #endregion Quantity

        #region Amount
        [DisplayName("Amount"), Column("amount"), Size(18), Scale(2), NotNull]
        public Decimal? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DecimalField Amount; }
        #endregion Amount

        #region ActualDuring
        [DisplayName("Actual During"), Column("ActualDuring"), Size(18), Scale(2), NotNull]
        public Decimal? ActualDuring { get { return Fields.ActualDuring[this]; } set { Fields.ActualDuring[this] = value; } }
        public partial class RowFields { public DecimalField ActualDuring; }
        #endregion ActualDuring

        #region Actual1stSixMonths
        [DisplayName("Actual 1st Six Months"), Column("Actual1stSixMonths"), Size(18), Scale(2), NotNull]
        public Decimal? Actual1stSixMonths { get { return Fields.Actual1stSixMonths[this]; } set { Fields.Actual1stSixMonths[this] = value; } }
        public partial class RowFields { public DecimalField Actual1stSixMonths; }
        #endregion Actual1stSixMonths

        #region BudgetApproved
        [DisplayName("Budget Approved"), Column("BudgetApproved"), Size(18), Scale(2), NotNull]
        public Decimal? BudgetApproved { get { return Fields.BudgetApproved[this]; } set { Fields.BudgetApproved[this] = value; } }
        public partial class RowFields { public DecimalField BudgetApproved; }
        #endregion BudgetApproved

        //#region BudgetApproved1Step
        //[DisplayName("Budget Approved 1Step"), Column("BudgetApproved1Step"), Size(18), Scale(2), NotNull]
        //public Decimal? BudgetApproved1Step { get { return Fields.BudgetApproved1Step[this]; } set { Fields.BudgetApproved1Step[this] = value; } }
        //public partial class RowFields { public DecimalField BudgetApproved1Step; }
        //#endregion BudgetApproved
        #region RevisedEstimate
        [DisplayName("Revised Estimate"), Column("RevisedEstimate"), Size(18), Scale(2), NotNull]
        public Decimal? RevisedEstimate { get { return Fields.RevisedEstimate[this]; } set { Fields.RevisedEstimate[this] = value; } }
        public partial class RowFields { public DecimalField RevisedEstimate; }
        #endregion RevisedEstimate
        //#region Budget Revision No
        //[DisplayName("Budget Revision No"), Column("budgetRevisionNo"), NotNull]
        //public Int32? BudgetRevisionNo { get { return Fields.BudgetRevisionNo[this]; } set { Fields.BudgetRevisionNo[this] = value; } }
        //public partial class RowFields { public Int32Field BudgetRevisionNo; }
        //#endregion BudgetRevisionNo

        //#region Budget Department Info Id
        //[DisplayName("Budget Department Info Id"), Column("budgetDepartmentInfoId"), NotNull]
        //public Int32? BudgetDepartmentInfoId { get { return Fields.BudgetDepartmentInfoId[this]; } set { Fields.BudgetDepartmentInfoId[this] = value; } }
        //public partial class RowFields { public Int32Field BudgetDepartmentInfoId; }
        //#endregion BudgetDepartmentInfoId

        #region Zone Info Id
        [DisplayName("Zone Info Id"), NotNull]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        //#region Entity Id
        //[DisplayName("Entity Id"), Column("entityId"), NotNull]
        //public Int32? EntityId { get { return Fields.EntityId[this]; } set { Fields.EntityId[this] = value; } }
        //public partial class RowFields { public Int32Field EntityId; }
        //#endregion EntityId

        #region Budget Year Id
        [DisplayName("Budget Year Id"), Column("budgetYear_id"), NotNull]
        public Int32? BudgetYearId { get { return Fields.BudgetYearId[this]; } set { Fields.BudgetYearId[this] = value; } }
        public partial class RowFields { public Int32Field BudgetYearId; }
        #endregion BudgetYearId

        #region Budget Status
        [DisplayName("Budget Status"), Column("budgetStatus"), NotNull]
        public Int32? BudgetStatus { get { return Fields.BudgetStatus[this]; } set { Fields.BudgetStatus[this] = value; } }
        public partial class RowFields { public Int32Field BudgetStatus; }
        #endregion BudgetStatus

        //#region Budget Dept
        //[DisplayName("Budget Dept"), Size(255), NotNull]
        //public String BudgetDept { get { return Fields.BudgetDept[this]; } set { Fields.BudgetDept[this] = value; } }
        //public partial class RowFields { public StringField BudgetDept; }
        //#endregion BudgetDept

        #region Year Name
        [DisplayName("Year Name"), Column("yearName"), Size(10), NotNull]
        public String YearName { get { return Fields.YearName[this]; } set { Fields.YearName[this] = value; } }
        public partial class RowFields { public StringField YearName; }
        #endregion YearName

        //#region Fund Control Name
        //[DisplayName("Fund Control Name"), Column("fundControlName"), Size(50), NotNull]
        //public String FundControlName { get { return Fields.FundControlName[this]; } set { Fields.FundControlName[this] = value; } }
        //public partial class RowFields { public StringField FundControlName; }
        //#endregion FundControlName
        #region ZoneName
        [DisplayName("Zone Name"), Column("ZoneName"), Size(50), NotNull]
        public String ZoneName { get { return Fields.ZoneName[this]; } set { Fields.ZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneName; }
        #endregion ZoneName
        #region ZoneCode
        [DisplayName("ZoneCode"), Column("ZoneCode"), Size(50), NotNull]
        public String ZoneCode { get { return Fields.ZoneCode[this]; } set { Fields.ZoneCode[this] = value; } }
        public partial class RowFields { public StringField ZoneCode; }
        #endregion ZoneCode

        #region Foreign Fields

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.AccountName; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.AccountName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccViewBudgetDetailsRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[acc_view_BudgetDetails]")
            {
                LocalTextPrefix = "Transaction.AccViewBudgetDetails";
            }
        }
        #endregion RowFields
    }
}

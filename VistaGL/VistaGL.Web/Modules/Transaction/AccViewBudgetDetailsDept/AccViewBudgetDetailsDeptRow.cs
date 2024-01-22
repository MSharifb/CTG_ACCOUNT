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

    [ConnectionKey("ACCDB"), DisplayName("acc_view_BudgetDetailsDept"), InstanceName("acc_view_BudgetDetailsDept"), TwoLevelCached]
    //[ReadPermission("Transaction:acc_view_BudgetDetailsDept:Read")]
    //[InsertPermission("Transaction:acc_view_BudgetDetailsDept:Insert")]
    //[UpdatePermission("Transaction:acc_view_BudgetDetailsDept:Update")]
    //[DeletePermission("Transaction:acc_view_BudgetDetailsDept:Delete")]
    [LookupScript("Transaction.AccViewBudgetDetailsDeptRow")]
    public sealed class AccViewBudgetDetailsDeptRow : Row, IIdRow, INameRow, IAuditLog
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
            [DisplayName("Quantity"), Column("quantity"), Size(38), Scale(2)]
            public Decimal? Quantity { get { return Fields.Quantity[this]; } set { Fields.Quantity[this] = value; } }
            public partial class RowFields { public DecimalField Quantity; }
            #endregion Quantity

            #region Amount
            [DisplayName("Amount"), Column("amount"), Size(38), Scale(2)]
            public Decimal? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
            public partial class RowFields { public DecimalField Amount; }
            #endregion Amount

            #region Zone Info Id
            [DisplayName("Zone Info Id"), NotNull]
            public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
            public partial class RowFields { public Int32Field ZoneInfoId; }
            #endregion ZoneInfoId

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

            #region Budget Department Info Id
            [DisplayName("Budget Department Info Id"), Column("budgetDepartmentInfoId"), NotNull]
            public Int32? BudgetDepartmentInfoId { get { return Fields.BudgetDepartmentInfoId[this]; } set { Fields.BudgetDepartmentInfoId[this] = value; } }
            public partial class RowFields { public Int32Field BudgetDepartmentInfoId; }
            #endregion BudgetDepartmentInfoId

            #region Budget Dept
            [DisplayName("Budget Dept"), Size(255), NotNull]
            public String BudgetDept { get { return Fields.BudgetDept[this]; } set { Fields.BudgetDept[this] = value; } }
            public partial class RowFields { public StringField BudgetDept; }
            #endregion BudgetDept

            #region Year Name
            [DisplayName("Year Name"), Column("yearName"), Size(10), NotNull]
            public String YearName { get { return Fields.YearName[this]; } set { Fields.YearName[this] = value; } }
            public partial class RowFields { public StringField YearName; }
            #endregion YearName

            #region Actual During
            [DisplayName("Actual During"), Size(16), Scale(2)]
            public Decimal? ActualDuring { get { return Fields.ActualDuring[this]; } set { Fields.ActualDuring[this] = value; } }
            public partial class RowFields { public DecimalField ActualDuring; }
            #endregion ActualDuring

            #region Actual1st Six Months
            [DisplayName("Actual1st Six Months"), Size(16), Scale(2)]
            public Decimal? Actual1stSixMonths { get { return Fields.Actual1stSixMonths[this]; } set { Fields.Actual1stSixMonths[this] = value; } }
            public partial class RowFields { public DecimalField Actual1stSixMonths; }
            #endregion Actual1stSixMonths

            #region Budget Approved
            [DisplayName("Budget Approved"), Size(16), Scale(2)]
            public Decimal? BudgetApproved { get { return Fields.BudgetApproved[this]; } set { Fields.BudgetApproved[this] = value; } }
            public partial class RowFields { public DecimalField BudgetApproved; }
            #endregion BudgetApproved

            #region Revised Estimate
            [DisplayName("Revised Estimate"), Size(16), Scale(2)]
            public Decimal? RevisedEstimate { get { return Fields.RevisedEstimate[this]; } set { Fields.RevisedEstimate[this] = value; } }
            public partial class RowFields { public DecimalField RevisedEstimate; }
            #endregion RevisedEstimate

            //#region Budget Approved1 Step
            //[DisplayName("Budget Approved1 Step"), Size(16), Scale(2)]
            //public Decimal? BudgetApproved1Step { get { return Fields.BudgetApproved1Step[this]; } set { Fields.BudgetApproved1Step[this] = value; } }
            //public partial class RowFields { public DecimalField BudgetApproved1Step; }
            //#endregion BudgetApproved1Step


    #region Foreign Fields

    #endregion Foreign Fields

    #region Id and Name fields
    IIdField IIdRow.IdField
    {
    get { return Fields.Id; }
    }

            StringField INameRow.NameField
            {
            get { return Fields.AccountName; }
            }
            #endregion Id and Name fields

    #region Constructor
    public AccViewBudgetDetailsDeptRow()
    : base(Fields)
    {
    }
    #endregion Constructor

    #region RowFields
    public static readonly RowFields Fields = new RowFields().Init();

    public partial class RowFields : RowFieldsBase
    {
    public RowFields()
    : base("[dbo].[acc_view_BudgetDetailsDept]")
    {
    LocalTextPrefix = "Transaction.AccViewBudgetDetailsDept";
    }
    }
    #endregion RowFields
    }
    }

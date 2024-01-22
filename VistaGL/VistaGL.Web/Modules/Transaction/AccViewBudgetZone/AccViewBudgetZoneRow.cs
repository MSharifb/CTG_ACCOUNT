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

    [ConnectionKey("ACCDB"), DisplayName("acc_view_budgetZone"), InstanceName("acc_view_budgetZone"), TwoLevelCached]
    //[ReadPermission("Transaction:acc_view_budgetZone:Read")]
    //[InsertPermission("Transaction:acc_view_budgetZone:Insert")]
    //[UpdatePermission("Transaction:acc_view_budgetZone:Update")]
    //[DeletePermission("Transaction:acc_view_budgetZone:Delete")]
    [LookupScript("Transaction.AccViewBudgetZoneRow")]
    public sealed class AccViewBudgetZoneRow : Row, IIdRow, INameRow, IAuditLog
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
    public AccViewBudgetZoneRow()
    : base(Fields)
    {
    }
    #endregion Constructor

    #region RowFields
    public static readonly RowFields Fields = new RowFields().Init();

    public partial class RowFields : RowFieldsBase
    {
    public RowFields()
    : base("[dbo].[acc_view_budgetZone]")
    {
    LocalTextPrefix = "Transaction.AccViewBudgetZone";
    }
    }
    #endregion RowFields
    }
    }

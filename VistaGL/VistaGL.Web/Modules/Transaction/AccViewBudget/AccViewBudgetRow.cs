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

    [ConnectionKey("ACCDB"), DisplayName("View Budget"), InstanceName("View Budget"), TwoLevelCached]
    //[ReadPermission("Transaction:AccViewBudget:Read")]
    //[InsertPermission("Transaction:AccViewBudget:Insert")]
    //[UpdatePermission("Transaction:AccViewBudget:Update")]
    //[DeletePermission("Transaction:AccViewBudget:Delete")]
    //[LookupScript("Transaction.AccViewBudget")]
    public sealed class AccViewBudgetRow : Row, IIdRow, INameRow, IAuditLog
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
        public AccViewBudgetRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[acc_view_Budget]")
            {
                LocalTextPrefix = "Transaction.AccViewBudget";
            }
        }
        #endregion RowFields
    }
}

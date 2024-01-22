
namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Transaction"), TableName("[dbo].[acc_BudgetDetails]")]
    [DisplayName("Budget Details"), InstanceName("Budget Details")]
    [ReadPermission("Transaction:AccBudget:Read")]
    [InsertPermission("Transaction:AccBudget:Insert")]
    [UpdatePermission("Transaction:AccBudget:Update")]
    [DeletePermission("Transaction:AccBudget:Delete")]
    [LookupScript("Transaction.AccBudgetDetails", Permission = "?")]
    public sealed class AccBudgetDetailsRow : NRow, IIdRow, INameRow
    {

        [DisplayName("Id"), Identity]
        public Int64? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Budget"), NotNull, ForeignKey("[dbo].[acc_Budget]", "Id"), LeftJoin("jBudget"), TextualField("BudgetAttachment")]
        public Int32? BudgetId
        {
            get { return Fields.BudgetId[this]; }
            set { Fields.BudgetId[this] = value; }
        }

        [DisplayName("Budget Group Id")]
        public Int32? BudgetGroupId
        {
            get { return Fields.BudgetGroupId[this]; }
            set { Fields.BudgetGroupId[this] = value; }
        }

        [DisplayName("Budget Head")]
        [LookupEditor("Transaction.AccBudgetHeads_Lookup"), LookupInclude]
        public Int32? BudgetHeadId
        {
            get { return Fields.BudgetHeadId[this]; }
            set { Fields.BudgetHeadId[this] = value; }
        }

        [DisplayName("Parent Id")]
        public Int32? ParentId
        {
            get { return Fields.ParentId[this]; }
            set { Fields.ParentId[this] = value; }
        }

        [DisplayName("Is Coa"), Column("IsCOA"), LookupInclude]
        public Boolean? IsCoa
        {
            get { return Fields.IsCoa[this]; }
            set { Fields.IsCoa[this] = value; }
        }

        [DisplayName("Is Budget Head")]
        public Boolean? IsBudgetHead
        {
            get { return Fields.IsBudgetHead[this]; }
            set { Fields.IsBudgetHead[this] = value; }
        }

        [DisplayName("Is Sub-ledger")]
        public Boolean? IsCostCenter
        {
            get { return Fields.IsCostCenter[this]; }
            set { Fields.IsCostCenter[this] = value; }
        }

        [DisplayName("Budget Amount"), Size(18), Scale(6), LookupInclude]
        public Decimal? BudgetAmount
        {
            get { return Fields.BudgetAmount[this]; }
            set { Fields.BudgetAmount[this] = value; }
        }

        [DisplayName("Budget Code"), Size(50), QuickSearch]
        public String BudgetCode
        {
            get { return Fields.BudgetCode[this]; }
            set { Fields.BudgetCode[this] = value; }
        }

        [DisplayName("Bg Sort Order"), Column("BGSortOrder")]
        public Int32? BgSortOrder
        {
            get { return Fields.BgSortOrder[this]; }
            set { Fields.BgSortOrder[this] = value; }
        }

        [DisplayName("Budget Head Name")]
        public String BudgetHeadName
        {
            get { return Fields.BudgetHeadName[this]; }
            set { Fields.BudgetHeadName[this] = value; }
        }

        #region Foreign Key
        [DisplayName("Financial Year"), Expression("jBudget.[FinancialYearId]"),LookupInclude]
        public Int32? FinancialYearId
        {
            get { return Fields.FinancialYearId[this]; }
            set { Fields.FinancialYearId[this] = value; }
        }
        [DisplayName("Financial Year"), Expression("jBudget.[ZoneInfoId]"), LookupInclude]
        public Int32? ZoneInfoId
        {
            get { return Fields.ZoneInfoId[this]; }
            set { Fields.ZoneInfoId[this] = value; }
        }
        [DisplayName("Financial Year"), Expression("jBudget.[EntityId]"), LookupInclude]
        public Int32? EntityId
        {
            get { return Fields.EntityId[this]; }
            set { Fields.EntityId[this] = value; }
        }


        #endregion

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.BudgetHeadName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccBudgetDetailsRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {

            public Int64Field Id;

            public Int32Field BudgetId;

            public Int32Field BudgetGroupId;

            public Int32Field BudgetHeadId;

            public Int32Field ParentId;

            public BooleanField IsCoa;

            public BooleanField IsBudgetHead;

            public BooleanField IsCostCenter;

            public DecimalField BudgetAmount;

            public StringField BudgetCode;

            public Int32Field BgSortOrder;

            public StringField BudgetHeadName;


            public Int32Field ZoneInfoId;

            public Int32Field FinancialYearId;

            public Int32Field EntityId;
        }
    }
}

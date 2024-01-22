
namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Transaction"), TableName("[dbo].[acc_Budget_ForDepartment_Detail]")]
    [DisplayName("Acc Budget For Department Detail"), InstanceName("Acc Budget For Department Detail")]
    [ReadPermission("*")]
    [InsertPermission("*")]
    [UpdatePermission("*")]
    [DeletePermission("*")]
    [LookupScript("Transaction.AccBudgetForDepartmentDetail", Permission = "?")]
    public sealed class AccBudgetForDepartmentDetailRow : NRow, IIdRow, INameRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Budget For Department"), NotNull, ForeignKey("[dbo].[acc_Budget_ForDepartment]", "Id"), LeftJoin("jBudgetForDepartment")]
        public Int32? BudgetForDepartmentId
        {
            get { return Fields.BudgetForDepartmentId[this]; }
            set { Fields.BudgetForDepartmentId[this] = value; }
        }

        [DisplayName("Budget Group"), NotNull, ForeignKey("[dbo].[acc_Budget_Group]", "Id"), LeftJoin("jBudgetGroup"), TextualField("BudgetGroupGroupName")]
        public Int32? BudgetGroupId
        {
            get { return Fields.BudgetGroupId[this]; }
            set { Fields.BudgetGroupId[this] = value; }
        }

        [DisplayName("Budget Parent Id")]
        public Int32? ParentId
        {
            get { return Fields.ParentId[this]; }
            set { Fields.ParentId[this] = value; }
        }

        [DisplayName("Budget Head Id")]
        public Int32? BudgetHeadId
        {
            get { return Fields.BudgetHeadId[this]; }
            set { Fields.BudgetHeadId[this] = value; }
        }

        [DisplayName("Is Coa"), Column("IsCOA")]
        public Boolean? IsCoa
        {
            get { return Fields.IsCoa[this]; }
            set { Fields.IsCoa[this] = value; }
        }

        [DisplayName("Is Budget Head"), Column("IsBudgetHead")]
        public Boolean? IsBudgetHead
        {
            get { return Fields.IsBudgetHead[this]; }
            set { Fields.IsBudgetHead[this] = value; }
        }

        [DisplayName("Is Cost Center"), Column("IsCostCenter")]
        public Boolean? IsCostCenter
        {
            get { return Fields.IsCostCenter[this]; }
            set { Fields.IsCostCenter[this] = value; }
        }

        [DisplayName("Revised Estimate"), Column("RevisedEstimateAmount")]
        public Decimal? RevisedEstimateAmount
        {
            get { return Fields.RevisedEstimateAmount[this]; }
            set { Fields.RevisedEstimateAmount[this] = value; }
        }

        [DisplayName("Proposed Budget"), Column("ProposedBudgetAmount")]
        public Decimal? ProposedBudgetAmount
        {
            get { return Fields.ProposedBudgetAmount[this]; }
            set { Fields.ProposedBudgetAmount[this] = value; }
        }

        [DisplayName("Proposed Budget Financial Year"), Column("ProposedBudgetFinancialYearId")]
        public Int32? ProposedBudgetFinancialYearId
        {
            get { return Fields.ProposedBudgetFinancialYearId[this]; }
            set { Fields.ProposedBudgetFinancialYearId[this] = value; }
        }

        [DisplayName("Actual 1st six months"), NotMapped]
        public Decimal? ActualFirstSixMonths
        {
            get { return Fields.ActualFirstSixMonths[this]; }
            set { Fields.ActualFirstSixMonths[this] = value; }
        }

        [DisplayName("Budget (Approved)"), NotMapped]
        public Decimal? BudgetApproved
        {
            get { return Fields.BudgetApproved[this]; }
            set { Fields.BudgetApproved[this] = value; }
        }

        [DisplayName("Actual During"), NotMapped]
        public Decimal? ActualDuring
        {
            get { return Fields.ActualDuring[this]; }
            set { Fields.ActualDuring[this] = value; }
        }

        [DisplayName("Budget For Department Budget Circular Id"), Expression("jBudgetForDepartment.[BudgetCircularId]"), ForeignKey("[dbo].[acc_BudgetCircular]", "Id"), LeftJoin("jBudgetCircular"), TextualField("BudgetCircular")]
        public Int32? BudgetForDepartmentBudgetCircularId
        {
            get { return Fields.BudgetForDepartmentBudgetCircularId[this]; }
            set { Fields.BudgetForDepartmentBudgetCircularId[this] = value; }
        }

        [DisplayName("Financial Year"), Expression("jBudgetCircular.[FinancialYearId]")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow))]
        public Int32? CircularFinancialYearId
        {
            get { return Fields.CircularFinancialYearId[this]; }
            set { Fields.CircularFinancialYearId[this] = value; }
        }

        [DisplayName("Budget For Department Zone Id"), Expression("jBudgetCircular.[FundControlId]")]
        public Int32? CircularFundControlId
        {
            get { return Fields.CircularFundControlId[this]; }
            set { Fields.CircularFundControlId[this] = value; }
        }

        [DisplayName("Is Active"), Expression("jBudgetCircular.[IsActive]")]
        [LookupInclude]
        public Boolean? CircularIsActive
        {
            get { return Fields.CircularIsActive[this]; }
            set { Fields.CircularIsActive[this] = value; }
        }

        [DisplayName("Zone"), Expression("jBudgetForDepartment.[ZoneId]")]
        [LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow)), LookupInclude]
        public Int32? BudgetForDepartmentZoneId
        {
            get { return Fields.BudgetForDepartmentZoneId[this]; }
            set { Fields.BudgetForDepartmentZoneId[this] = value; }
        }

        [DisplayName("Department"), Expression("jBudgetForDepartment.[DepartmentId]")]
        [LookupEditor("Configurations.DepartmentForBudget_Lookup"), LookupInclude]
        public Int32? BudgetForDepartmentDepartmentId
        {
            get { return Fields.BudgetForDepartmentDepartmentId[this]; }
            set { Fields.BudgetForDepartmentDepartmentId[this] = value; }
        }

        [DisplayName("Approval Status"), Expression("jBudgetForDepartment.[ApprovalStatusId]")]
        [LookupInclude]
        public Int32? BudgetForDepartmentApprovalStatusId
        {
            get { return Fields.BudgetForDepartmentApprovalStatusId[this]; }
            set { Fields.BudgetForDepartmentApprovalStatusId[this] = value; }
        }

        [DisplayName("Forward To Employee"), Expression("jBudgetForDepartment.[ForwardToEmployeeId]")]
        [LookupInclude]
        public Int32? BudgetForDepartmentForwardToEmployeeId
        {
            get { return Fields.BudgetForDepartmentForwardToEmployeeId[this]; }
            set { Fields.BudgetForDepartmentForwardToEmployeeId[this] = value; }
        }

        [DisplayName("Budget Group Parent Id"), Expression("jBudgetGroup.[ParentId]")]
        public Int32? BudgetGroupParentId
        {
            get { return Fields.BudgetGroupParentId[this]; }
            set { Fields.BudgetGroupParentId[this] = value; }
        }

        [DisplayName("Budget Group Name"), Expression("jBudgetGroup.[GroupName]")]
        public String BudgetGroupGroupName
        {
            get { return Fields.BudgetGroupGroupName[this]; }
            set { Fields.BudgetGroupGroupName[this] = value; }
        }

        [DisplayName("Budget Group Sorting Order"), Expression("jBudgetGroup.[SortingOrder]")]
        public Int32? BudgetGroupSortingOrder
        {
            get { return Fields.BudgetGroupSortingOrder[this]; }
            set { Fields.BudgetGroupSortingOrder[this] = value; }
        }

        [DisplayName("Budget Group Is Active"), Expression("jBudgetGroup.[IsActive]")]
        public Boolean? BudgetGroupIsActive
        {
            get { return Fields.BudgetGroupIsActive[this]; }
            set { Fields.BudgetGroupIsActive[this] = value; }
        }

        [DisplayName("Budget Head Name"), NotMapped, LookupInclude]
        public String BudgetHeadName
        {
            get { return Fields.BudgetHeadName[this]; }
            set { Fields.BudgetHeadName[this] = value; }
        }

        [DisplayName("BG Sort Order"), Column("BGSortOrder")]
        public Int32? BGSortOrder { get { return Fields.BGSortOrder[this]; } set { Fields.BGSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field BGSortOrder; }

        [DisplayName("Budget Code"), Column("BudgetCode")]
        public String BudgetCode { get { return Fields.BudgetCode[this]; } set { Fields.BudgetCode[this] = value; } }
        public partial class RowFields { public StringField BudgetCode; }


        #region _collapsed
        [NotMapped]
        public String _collapsed { get { return Fields._collapsed[this]; } set { Fields._collapsed[this] = value; } }
        public partial class RowFields { public StringField _collapsed; }
        #endregion _collapsed

        #region _indent
        [NotMapped]
        public String _indent { get { return Fields._indent[this]; } set { Fields._indent[this] = value; } }
        public partial class RowFields { public StringField _indent; }
        #endregion _indent


        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }
        StringField INameRow.NameField
        {
            get { return Fields.BudgetHeadName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccBudgetForDepartmentDetailRow()
            : base(Fields)
        {
        }

        public partial class RowFields : NRowFields
        {
            public Int32Field Id;
            public Int32Field BudgetForDepartmentId;
            public Int32Field BudgetGroupId;
            public Int32Field ParentId;
            public Int32Field BudgetHeadId;
            public BooleanField IsCoa;
            public BooleanField IsBudgetHead;
            public BooleanField IsCostCenter;
            public Int32Field BudgetForDepartmentBudgetCircularId;
            public Int32Field BudgetForDepartmentZoneId;
            public Int32Field BudgetForDepartmentDepartmentId;
            public Int32Field BudgetForDepartmentForwardToEmployeeId;
            public Int32Field BudgetForDepartmentApprovalStatusId;
            public Int32Field ProposedBudgetFinancialYearId;
            public Int32Field BudgetGroupParentId;
            public StringField BudgetGroupGroupName;
            public Int32Field BudgetGroupSortingOrder;
            public BooleanField BudgetGroupIsActive;
            public StringField BudgetHeadName;
            public DecimalField ProposedBudgetAmount;
            public DecimalField RevisedEstimateAmount;
            public DecimalField ActualFirstSixMonths;
            public DecimalField BudgetApproved;
            public DecimalField ActualDuring;
            public Int32Field CircularFundControlId;
            public Int32Field CircularFinancialYearId;
            public BooleanField CircularIsActive;
        }
    }
}

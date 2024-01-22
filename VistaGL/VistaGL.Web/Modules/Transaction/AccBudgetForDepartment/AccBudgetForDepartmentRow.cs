
namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Transaction"), TableName("[dbo].[acc_Budget_ForDepartment]")]
    [DisplayName("Department Wise Budget Head Setup"), InstanceName("Budget Head Setup")]
    [ReadPermission("Transaction:AccBudgetForDepartment:Read")]
    [InsertPermission("Transaction:AccBudgetForDepartment:Insert")]
    [UpdatePermission("Transaction:AccBudgetForDepartment:Update")]
    [DeletePermission("Transaction:AccBudgetForDepartment:Delete")]
    [LookupScript("Transaction.AccBudgetForDepartment", Permission = "?")]
    public sealed class AccBudgetForDepartmentRow : NRow, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Budget Year"), NotNull,ForeignKey("[dbo].[acc_BudgetCircular]", "Id"), LeftJoin("jBudgetCircular")]
        [LookupEditor(typeof(AccBudgetCircularRow)), LookupInclude]
        public Int32? BudgetCircularId
        {
            get { return Fields.BudgetCircularId[this]; }
            set { Fields.BudgetCircularId[this] = value; }
        }

        [DisplayName("Zone Id"), LookupInclude, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo")]
        public Int32? ZoneId
        {
            get { return Fields.ZoneId[this]; }
            set { Fields.ZoneId[this] = value; }
        }

        [DisplayName("Entity Id"), LookupInclude]
        public Int32? EntityId
        {
            get { return Fields.EntityId[this]; }
            set { Fields.EntityId[this] = value; }
        }


        [DisplayName("Department Id"), NotNull, ForeignKey("[dbo].[PRM_Division]", "Id"), LeftJoin("jDepartment")]
        [LookupEditor("Configurations.DepartmentForBudget_Lookup"), LookupInclude]
        public Int32? DepartmentId
        {
            get { return Fields.DepartmentId[this]; }
            set { Fields.DepartmentId[this] = value; }
        }

        [DisplayName("Status"), LookupInclude]
        public ApprovalStatus? ApprovalStatusId
        {
            get { return (ApprovalStatus?)Fields.ApprovalStatusId[this]; }
            set { Fields.ApprovalStatusId[this] = (Int32)value; }
        }

        [DisplayName("Forward To Employee"), LookupInclude]
        public Int32? ForwardToEmployeeId
        {
            get { return Fields.ForwardToEmployeeId[this]; }
            set { Fields.ForwardToEmployeeId[this] = value; }
        }

        [DisplayName("Budget Year"),
            Expression("jBudgetCircular.[FinancialYearId]"),
            ForeignKey("[dbo].[acc_Accounting_Period_Information]", "id"),
            LeftJoin("jFinancialYear")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow)), LookupInclude]
        public Int32? BudgetCircularFinancialYearId
        {
            get { return Fields.BudgetCircularFinancialYearId[this]; }
            set { Fields.BudgetCircularFinancialYearId[this] = value; }
        }

        [DisplayName("Budget Circular Fund Control Id"),
            Expression("jBudgetCircular.[FundControlId]")]
        public Int32? BudgetCircularFundControlId
        {
            get { return Fields.BudgetCircularFundControlId[this]; }
            set { Fields.BudgetCircularFundControlId[this] = value; }
        }

        [DisplayName("Budget Circular Is Active"), Expression("jBudgetCircular.[IsActive]")]
        public Boolean? BudgetCircularIsActive
        {
            get { return Fields.BudgetCircularIsActive[this]; }
            set { Fields.BudgetCircularIsActive[this] = value; }
        }

        [DisplayName("Department"), Expression("jDepartment.[Name]")]
        public String DepartmentName
        {
            get { return Fields.DepartmentName[this]; }
            set { Fields.DepartmentName[this] = value; }
        }

        [DisplayName("Budget Year"), Expression("jFinancialYear.[yearName]")]
        public String FinancialYearName
        {
            get { return Fields.FinancialYearName[this]; }
            set { Fields.FinancialYearName[this] = value; }
        }

        [DisplayName("Zone Name"), Expression("jZoneInfo.[ZoneName]")]
        public String ZoneName
        {
            get { return Fields.ZoneName[this]; }
            set { Fields.ZoneName[this] = value; }
        }

        [MasterDetailRelation(foreignKey: "BudgetForDepartmentId", CheckChangesOnUpdate = true), NotMapped]
        public List<AccBudgetForDepartmentDetailRow> AccBudgetForDepartmentDetailList
        {
            get { return Fields.AccBudgetForDepartmentDetailList[this]; }
            set { Fields.AccBudgetForDepartmentDetailList[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccBudgetForDepartmentRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {
            public Int32Field Id;
            public Int32Field BudgetCircularId;
            public Int32Field ZoneId;
            public Int32Field EntityId;
            public Int32Field DepartmentId;
            public Int32Field ForwardToEmployeeId;
            public Int32Field ApprovalStatusId;
            public Int32Field BudgetCircularFinancialYearId;
            public Int32Field BudgetCircularFundControlId;
            public BooleanField BudgetCircularIsActive;
            public StringField DepartmentName;
            public StringField FinancialYearName;
            public StringField ZoneName;
            public RowListField<AccBudgetForDepartmentDetailRow> AccBudgetForDepartmentDetailList;
        }
    }
}

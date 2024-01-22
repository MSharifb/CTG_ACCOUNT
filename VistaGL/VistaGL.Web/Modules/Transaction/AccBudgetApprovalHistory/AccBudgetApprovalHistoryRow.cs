
namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Transaction"), TableName("[dbo].[acc_BudgetApprovalHistory]")]
    [DisplayName("Budget Approval History"), InstanceName("Budget Approval History")]
    [ReadPermission("*")]
    [ModifyPermission("*")]
    public sealed class AccBudgetApprovalHistoryRow : NRow, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Budget"), NotNull, ForeignKey("[dbo].[acc_Budget_ForDepartment]", "Id"), LeftJoin("jBudget")]
        public Int32? BudgetForDepartmentId
        {
            get { return Fields.BudgetForDepartmentId[this]; }
            set { Fields.BudgetForDepartmentId[this] = value; }
        }

        [DisplayName("From Appover Id"), NotNull, ForeignKey("[dbo].[PRM_EmploymentInfo]", "Id"), LeftJoin("jFromEmployee")]
        public Int32? FromAppoverId
        {
            get { return Fields.FromAppoverId[this]; }
            set { Fields.FromAppoverId[this] = value; }
        }

        [DisplayName("Approval Status Id")]
        public ApprovalStatus? ApprovalStatusId
        {
            get { return (ApprovalStatus?)Fields.ApprovalStatusId[this]; }
            set { Fields.ApprovalStatusId[this] = (Int32)value; }
        }

        [DisplayName("To Approver Id"), ForeignKey("[dbo].[PRM_EmploymentInfo]", "Id"), LeftJoin("jToEmployee")]
        public Int32? ToApproverId
        {
            get { return Fields.ToApproverId[this]; }
            set { Fields.ToApproverId[this] = value; }
        }



        [DisplayName("Budget Budget Circular Id"), Expression("jBudget.[BudgetCircularId]")]
        public Int32? BudgetBudgetCircularId
        {
            get { return Fields.BudgetBudgetCircularId[this]; }
            set { Fields.BudgetBudgetCircularId[this] = value; }
        }

        [DisplayName("Budget Zone Id"), Expression("jBudget.[ZoneId]")]
        public Int32? BudgetZoneId
        {
            get { return Fields.BudgetZoneId[this]; }
            set { Fields.BudgetZoneId[this] = value; }
        }

        [DisplayName("Budget Department Id"), Expression("jBudget.[DepartmentId]")]
        public Int32? BudgetDepartmentId
        {
            get { return Fields.BudgetDepartmentId[this]; }
            set { Fields.BudgetDepartmentId[this] = value; }
        }

        [DisplayName("Budget Approval Status Id"), Expression("jBudget.[ApprovalStatusId]")]
        public Int32? BudgetApprovalStatusId
        {
            get { return Fields.BudgetApprovalStatusId[this]; }
            set { Fields.BudgetApprovalStatusId[this] = value; }
        }

        [DisplayName("Budget Forward To Employee Id"), Expression("jBudget.[ForwardToEmployeeId]")]
        public Int32? BudgetForwardToEmployeeId
        {
            get { return Fields.BudgetForwardToEmployeeId[this]; }
            set { Fields.BudgetForwardToEmployeeId[this] = value; }
        }

        [DisplayName("Emp Name"), Expression("jFromEmployee.[FullName]")]
        public String FromEmpFullName
        {
            get { return Fields.FromEmpFullName[this]; }
            set { Fields.FromEmpFullName[this] = value; }
        }

        [DisplayName("Emp Name"), Expression("jToEmployee.[FullName]")]
        public String ToEmpFullName
        {
            get { return Fields.ToEmpFullName[this]; }
            set { Fields.ToEmpFullName[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccBudgetApprovalHistoryRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {

            public Int32Field Id;

            public Int32Field BudgetForDepartmentId;

            public Int32Field FromAppoverId;

            public Int32Field ApprovalStatusId;

            public Int32Field ToApproverId;



            public Int32Field BudgetBudgetCircularId;

            public Int32Field BudgetZoneId;

            public Int32Field BudgetDepartmentId;

            public Int32Field BudgetApprovalStatusId;

            public Int32Field BudgetForwardToEmployeeId;

            public StringField FromEmpFullName;

            public StringField ToEmpFullName;
        }
    }
}

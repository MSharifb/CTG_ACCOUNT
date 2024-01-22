
namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[Acc_BudgetZoneApprover]")]
    [DisplayName("Budget Zone Approver"), InstanceName("Budget Zone Approver")]
    [ReadPermission("Configurations:AccBudgetZoneApprover:Read")]
    [InsertPermission("Configurations:AccBudgetZoneApprover:Insert")]
    [UpdatePermission("Configurations:AccBudgetZoneApprover:Update")]
    [DeletePermission("Configurations:AccBudgetZoneApprover:Delete")]
    [LookupScript("Configurations.AccBudgetZoneApprover", Permission = "?")]
    public sealed class AccBudgetZoneApproverRow : Row, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Employee"), NotNull, ForeignKey("[dbo].[PRM_EmploymentInfo]", "Id"), LeftJoin("jEmployee"), TextualField("EmployeeEmpId")]
        [LookupEditor(typeof(Configurations.Entities.PrmEmploymentInfoRow), CascadeFrom = nameof(ZoneId), CascadeField = "ZoneInfoId")]
        public Int32? EmployeeId
        {
            get { return Fields.EmployeeId[this]; }
            set { Fields.EmployeeId[this] = value; }
        }

        [DisplayName("Zone"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZone"), TextualField("ZoneZoneName")]
        [LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneId
        {
            get { return Fields.ZoneId[this]; }
            set { Fields.ZoneId[this] = value; }
        }

        [DisplayName("Entity"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jEntity"), TextualField("EntityCode")]
        public Int32? EntityId
        {
            get { return Fields.EntityId[this]; }
            set { Fields.EntityId[this] = value; }
        }


        [DisplayName("Employee Emp Id"), Expression("jEmployee.[EmpID]")]
        public String EmployeeEmpId
        {
            get { return Fields.EmployeeEmpId[this]; }
            set { Fields.EmployeeEmpId[this] = value; }
        }

        [DisplayName("Employee Employee Initial"), Expression("jEmployee.[EmployeeInitial]")]
        public String EmployeeEmployeeInitial
        {
            get { return Fields.EmployeeEmployeeInitial[this]; }
            set { Fields.EmployeeEmployeeInitial[this] = value; }
        }

        [DisplayName("Employee Title Id"), Expression("jEmployee.[TitleId]")]
        public Int32? EmployeeTitleId
        {
            get { return Fields.EmployeeTitleId[this]; }
            set { Fields.EmployeeTitleId[this] = value; }
        }

        [DisplayName("Employee First Name"), Expression("jEmployee.[FirstName]")]
        public String EmployeeFirstName
        {
            get { return Fields.EmployeeFirstName[this]; }
            set { Fields.EmployeeFirstName[this] = value; }
        }

        [DisplayName("Employee Middle Name"), Expression("jEmployee.[MiddleName]")]
        public String EmployeeMiddleName
        {
            get { return Fields.EmployeeMiddleName[this]; }
            set { Fields.EmployeeMiddleName[this] = value; }
        }

        [DisplayName("Employee Last Name"), Expression("jEmployee.[LastName]")]
        public String EmployeeLastName
        {
            get { return Fields.EmployeeLastName[this]; }
            set { Fields.EmployeeLastName[this] = value; }
        }

        [DisplayName("Employee Full Name"), Expression("jEmployee.[FullName]")]
        public String EmployeeFullName
        {
            get { return Fields.EmployeeFullName[this]; }
            set { Fields.EmployeeFullName[this] = value; }
        }

        [DisplayName("Employee Full Name Bangla"), Expression("jEmployee.[FullNameBangla]")]
        public String EmployeeFullNameBangla
        {
            get { return Fields.EmployeeFullNameBangla[this]; }
            set { Fields.EmployeeFullNameBangla[this] = value; }
        }

        [DisplayName("Employee Dateof Joining"), Expression("jEmployee.[DateofJoining]")]
        public DateTime? EmployeeDateofJoining
        {
            get { return Fields.EmployeeDateofJoining[this]; }
            set { Fields.EmployeeDateofJoining[this] = value; }
        }

        [DisplayName("Employee Provision Month"), Expression("jEmployee.[ProvisionMonth]")]
        public Int32? EmployeeProvisionMonth
        {
            get { return Fields.EmployeeProvisionMonth[this]; }
            set { Fields.EmployeeProvisionMonth[this] = value; }
        }

        [DisplayName("Employee Dateof Confirmation"), Expression("jEmployee.[DateofConfirmation]")]
        public DateTime? EmployeeDateofConfirmation
        {
            get { return Fields.EmployeeDateofConfirmation[this]; }
            set { Fields.EmployeeDateofConfirmation[this] = value; }
        }

        [DisplayName("Employee Dateof Position"), Expression("jEmployee.[DateofPosition]")]
        public DateTime? EmployeeDateofPosition
        {
            get { return Fields.EmployeeDateofPosition[this]; }
            set { Fields.EmployeeDateofPosition[this] = value; }
        }

        [DisplayName("Employee Designation Id"), Expression("jEmployee.[DesignationId]")]
        public Int32? EmployeeDesignationId
        {
            get { return Fields.EmployeeDesignationId[this]; }
            set { Fields.EmployeeDesignationId[this] = value; }
        }

        [DisplayName("Employee Status Designation Id"), Expression("jEmployee.[StatusDesignationId]")]
        public Int32? EmployeeStatusDesignationId
        {
            get { return Fields.EmployeeStatusDesignationId[this]; }
            set { Fields.EmployeeStatusDesignationId[this] = value; }
        }

        [DisplayName("Employee Discipline Id"), Expression("jEmployee.[DisciplineId]")]
        public Int32? EmployeeDisciplineId
        {
            get { return Fields.EmployeeDisciplineId[this]; }
            set { Fields.EmployeeDisciplineId[this] = value; }
        }

        [DisplayName("Employee Division Id"), Expression("jEmployee.[DivisionId]")]
        public Int32? EmployeeDivisionId
        {
            get { return Fields.EmployeeDivisionId[this]; }
            set { Fields.EmployeeDivisionId[this] = value; }
        }

        [DisplayName("Employee Section Id"), Expression("jEmployee.[SectionId]")]
        public Int32? EmployeeSectionId
        {
            get { return Fields.EmployeeSectionId[this]; }
            set { Fields.EmployeeSectionId[this] = value; }
        }

        [DisplayName("Employee Sub Section Id"), Expression("jEmployee.[SubSectionId]")]
        public Int32? EmployeeSubSectionId
        {
            get { return Fields.EmployeeSubSectionId[this]; }
            set { Fields.EmployeeSubSectionId[this] = value; }
        }

        [DisplayName("Employee Job Location Id"), Expression("jEmployee.[JobLocationId]")]
        public Int32? EmployeeJobLocationId
        {
            get { return Fields.EmployeeJobLocationId[this]; }
            set { Fields.EmployeeJobLocationId[this] = value; }
        }

        [DisplayName("Employee Resource Level Id"), Expression("jEmployee.[ResourceLevelId]")]
        public Int32? EmployeeResourceLevelId
        {
            get { return Fields.EmployeeResourceLevelId[this]; }
            set { Fields.EmployeeResourceLevelId[this] = value; }
        }

        [DisplayName("Employee Staff Category Id"), Expression("jEmployee.[StaffCategoryId]")]
        public Int32? EmployeeStaffCategoryId
        {
            get { return Fields.EmployeeStaffCategoryId[this]; }
            set { Fields.EmployeeStaffCategoryId[this] = value; }
        }





        [DisplayName("Zone Name"), Expression("jZone.[ZoneName]")]
        public String ZoneZoneName
        {
            get { return Fields.ZoneZoneName[this]; }
            set { Fields.ZoneZoneName[this] = value; }
        }



        [DisplayName("Entity Code"), Expression("jEntity.[code]")]
        public String EntityCode
        {
            get { return Fields.EntityCode[this]; }
            set { Fields.EntityCode[this] = value; }
        }

        [DisplayName("Entity Fund Control Name"), Expression("jEntity.[fundControlName]")]
        public String EntityFundControlName
        {
            get { return Fields.EntityFundControlName[this]; }
            set { Fields.EntityFundControlName[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccBudgetZoneApproverRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field Id;

            public Int32Field EmployeeId;

            public Int32Field ZoneId;

            public Int32Field EntityId;



            public StringField EmployeeEmpId;

            public StringField EmployeeEmployeeInitial;

            public Int32Field EmployeeTitleId;

            public StringField EmployeeFirstName;

            public StringField EmployeeMiddleName;

            public StringField EmployeeLastName;

            public StringField EmployeeFullName;

            public StringField EmployeeFullNameBangla;

            public DateTimeField EmployeeDateofJoining;

            public Int32Field EmployeeProvisionMonth;

            public DateTimeField EmployeeDateofConfirmation;

            public DateTimeField EmployeeDateofPosition;

            public Int32Field EmployeeDesignationId;

            public Int32Field EmployeeStatusDesignationId;

            public Int32Field EmployeeDisciplineId;

            public Int32Field EmployeeDivisionId;

            public Int32Field EmployeeSectionId;

            public Int32Field EmployeeSubSectionId;

            public Int32Field EmployeeJobLocationId;

            public Int32Field EmployeeResourceLevelId;

            public Int32Field EmployeeStaffCategoryId;

            public StringField ZoneZoneName;


            public StringField EntityCode;

            public StringField EntityFundControlName;


        }
    }
}

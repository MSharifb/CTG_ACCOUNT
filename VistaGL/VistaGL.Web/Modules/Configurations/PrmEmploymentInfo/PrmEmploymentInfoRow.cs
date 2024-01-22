using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("PRM_EmploymentInfo"), InstanceName("PRM_EmploymentInfo"), TwoLevelCached]
    [ReadPermission("Configurations:PRM_EmploymentInfo:Read")]
    [InsertPermission("Configurations:PRM_EmploymentInfo:Insert")]
    [UpdatePermission("Configurations:PRM_EmploymentInfo:Update")]
    [DeletePermission("Configurations:PRM_EmploymentInfo:Delete")]
    [LookupScript("Configurations.PrmEmploymentInfo", Permission = "?")]
    public sealed class PrmEmploymentInfoRow : Row, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Emp Id
        [DisplayName("Emp Id"), Column("EmpID"), Size(15), NotNull, QuickSearch, LookupInclude]
        public String EmpId { get { return Fields.EmpId[this]; } set { Fields.EmpId[this] = value; } }
        public partial class RowFields { public StringField EmpId; }
        #endregion EmpId

        #region Employee Initial
        [DisplayName("Employee Initial"), Size(15)]
        public String EmployeeInitial { get { return Fields.EmployeeInitial[this]; } set { Fields.EmployeeInitial[this] = value; } }
        public partial class RowFields { public StringField EmployeeInitial; }
        #endregion EmployeeInitial

        #region Title
        [DisplayName("Title"), ForeignKey("[dbo].[PRM_NameTitle]", "Id"), LeftJoin("jTitle"), TextualField("TitleName")]

        public Int32? TitleId { get { return Fields.TitleId[this]; } set { Fields.TitleId[this] = value; } }
        public partial class RowFields { public Int32Field TitleId; }
        #endregion TitleId

        #region First Name
        [DisplayName("First Name"), Size(50)]
        public String FirstName { get { return Fields.FirstName[this]; } set { Fields.FirstName[this] = value; } }
        public partial class RowFields { public StringField FirstName; }
        #endregion FirstName

        #region Middle Name
        [DisplayName("Middle Name"), Size(50)]
        public String MiddleName { get { return Fields.MiddleName[this]; } set { Fields.MiddleName[this] = value; } }
        public partial class RowFields { public StringField MiddleName; }
        #endregion MiddleName

        #region Last Name
        [DisplayName("Last Name"), Size(50)]
        public String LastName { get { return Fields.LastName[this]; } set { Fields.LastName[this] = value; } }
        public partial class RowFields { public StringField LastName; }
        #endregion LastName

        #region Full Name
        [DisplayName("Full Name"), Size(200), NotNull, LookupInclude]
        public String FullName { get { return Fields.FullName[this]; } set { Fields.FullName[this] = value; } }
        public partial class RowFields { public StringField FullName; }
        #endregion FullName

        #region Full Name Bangla
        [DisplayName("Full Name Bangla"), Size(200)]
        public String FullNameBangla { get { return Fields.FullNameBangla[this]; } set { Fields.FullNameBangla[this] = value; } }
        public partial class RowFields { public StringField FullNameBangla; }
        #endregion FullNameBangla

        #region Dateof Joining
        [DisplayName("Dateof Joining"), NotNull]
        public DateTime? DateofJoining { get { return Fields.DateofJoining[this]; } set { Fields.DateofJoining[this] = value; } }
        public partial class RowFields { public DateTimeField DateofJoining; }
        #endregion DateofJoining

        #region Provision Month
        [DisplayName("Provision Month"), NotNull]
        public Int32? ProvisionMonth { get { return Fields.ProvisionMonth[this]; } set { Fields.ProvisionMonth[this] = value; } }
        public partial class RowFields { public Int32Field ProvisionMonth; }
        #endregion ProvisionMonth

        #region Dateof Confirmation
        [DisplayName("Dateof Confirmation")]
        public DateTime? DateofConfirmation { get { return Fields.DateofConfirmation[this]; } set { Fields.DateofConfirmation[this] = value; } }
        public partial class RowFields { public DateTimeField DateofConfirmation; }
        #endregion DateofConfirmation

        #region Dateof Position
        [DisplayName("Dateof Position"), NotNull]
        public DateTime? DateofPosition { get { return Fields.DateofPosition[this]; } set { Fields.DateofPosition[this] = value; } }
        public partial class RowFields { public DateTimeField DateofPosition; }
        #endregion DateofPosition

        #region Designation
        [DisplayName("Designation"), NotNull, ForeignKey("[dbo].[PRM_Designation]", "Id"), LeftJoin("jDesignation"), TextualField("DesignationName")]

        public Int32? DesignationId { get { return Fields.DesignationId[this]; } set { Fields.DesignationId[this] = value; } }
        public partial class RowFields { public Int32Field DesignationId; }
        #endregion DesignationId

        #region Status Designation
        [DisplayName("Status Designation"), ForeignKey("[dbo].[PRM_Designation]", "Id"), LeftJoin("jStatusDesignation"), TextualField("StatusDesignationName")]

        public Int32? StatusDesignationId { get { return Fields.StatusDesignationId[this]; } set { Fields.StatusDesignationId[this] = value; } }
        public partial class RowFields { public Int32Field StatusDesignationId; }
        #endregion StatusDesignationId

        #region Discipline
        [DisplayName("Discipline"), ForeignKey("[dbo].[PRM_Discipline]", "Id"), LeftJoin("jDiscipline"), TextualField("DisciplineName")]

        public Int32? DisciplineId { get { return Fields.DisciplineId[this]; } set { Fields.DisciplineId[this] = value; } }
        public partial class RowFields { public Int32Field DisciplineId; }
        #endregion DisciplineId

        #region Division
        [DisplayName("Division"), ForeignKey("[dbo].[PRM_Division]", "Id"), LeftJoin("jDivision"), TextualField("DivisionName"),LookupInclude]

        public Int32? DivisionId { get { return Fields.DivisionId[this]; } set { Fields.DivisionId[this] = value; } }
        public partial class RowFields { public Int32Field DivisionId; }
        #endregion DivisionId

        #region Section
        [DisplayName("Staff Category Id"), ForeignKey("[dbo].[PRM_StaffCategory]", "Id"), LeftJoin("jStaffCategory"), TextualField("Name")]

        public Int32? StaffCategoryId { get { return Fields.StaffCategoryId[this]; } set { Fields.StaffCategoryId[this] = value; } }
        public partial class RowFields { public Int32Field StaffCategoryId; }
        #endregion SectionId


        #region Section
        [DisplayName("Section"), ForeignKey("[dbo].[PRM_Section]", "Id"), LeftJoin("jSection"), TextualField("SectionName")]

        public Int32? SectionId { get { return Fields.SectionId[this]; } set { Fields.SectionId[this] = value; } }
        public partial class RowFields { public Int32Field SectionId; }
        #endregion SectionId

        #region Bank
        [DisplayName("Bank"), ForeignKey("[dbo].[PRM_BankName]", "Id"), LeftJoin("jBank"), TextualField("BankName")]

        public Int32? BankId { get { return Fields.BankId[this]; } set { Fields.BankId[this] = value; } }
        public partial class RowFields { public Int32Field BankId; }
        #endregion BankId

        #region Bank Branch
        [DisplayName("Bank Branch"), ForeignKey("[dbo].[PRM_BankBranch]", "Id"), LeftJoin("jBankBranch"), TextualField("BankBranchName")]

        public Int32? BankBranchId { get { return Fields.BankBranchId[this]; } set { Fields.BankBranchId[this] = value; } }
        public partial class RowFields { public Int32Field BankBranchId; }
        #endregion BankBranchId

        #region Bank Account No
        [DisplayName("Bank Account No"), Size(50)]
        public String BankAccountNo { get { return Fields.BankAccountNo[this]; } set { Fields.BankAccountNo[this] = value; } }
        public partial class RowFields { public StringField BankAccountNo; }
        #endregion BankAccountNo

        #region Employment Status
        [DisplayName("Employment Status"), NotNull, ForeignKey("[dbo].[PRM_EmploymentStatus]", "Id"), LeftJoin("jEmploymentStatus"), TextualField("EmploymentStatusName")]

        public Int32? EmploymentStatusId { get { return Fields.EmploymentStatusId[this]; } set { Fields.EmploymentStatusId[this] = value; } }
        public partial class RowFields { public Int32Field EmploymentStatusId; }
        #endregion EmploymentStatusId

        #region Dateof Inactive
        [DisplayName("Dateof Inactive")]
        public DateTime? DateofInactive { get { return Fields.DateofInactive[this]; } set { Fields.DateofInactive[this] = value; } }
        public partial class RowFields { public DateTimeField DateofInactive; }
        #endregion DateofInactive

        #region Gender
        [DisplayName("Gender"), Size(20), NotNull]
        public String Gender { get { return Fields.Gender[this]; } set { Fields.Gender[this] = value; } }
        public partial class RowFields { public StringField Gender; }
        #endregion Gender

        #region Zone Info
        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        [LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId


        #region Foreign Fields
        [DisplayName("Title Name"), Expression("T0.EmpId + ' - ' + T0.FullName")]
        public String LookupText { get { return Fields.LookupText[this]; } set { Fields.LookupText[this] = value; } }
        public partial class RowFields { public StringField LookupText; }

        [DisplayName("Designation Name"), Expression("jDesignation.[Name]")]
        public String DesignationName { get { return Fields.DesignationName[this]; } set { Fields.DesignationName[this] = value; } }
        public partial class RowFields { public StringField DesignationName; }

        [DisplayName("Zone Name"), Expression("jZoneInfo.[ZoneName]"), QuickSearch(SearchType.Contains)]
        public String ZoneInfoZoneName { get { return Fields.ZoneInfoZoneName[this]; } set { Fields.ZoneInfoZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneInfoZoneName; }


        [DisplayName("Status Designation Name"), Expression("jStatusDesignation.[Name]")]
        public String StatusDesignationName { get { return Fields.StatusDesignationName[this]; } set { Fields.StatusDesignationName[this] = value; } }
        public partial class RowFields { public StringField StatusDesignationName; }


        [DisplayName("Division Name"), Expression("jDivision.[Name]")]
        public String DivisionName { get { return Fields.DivisionName[this]; } set { Fields.DivisionName[this] = value; } }
        public partial class RowFields { public StringField DivisionName; }

        [DisplayName("Staff Category Name"), Expression("jStaffCategory.[Name]")]
        public String StaffCategoryName { get { return Fields.StaffCategoryName[this]; } set { Fields.StaffCategoryName[this] = value; } }
        public partial class RowFields { public StringField StaffCategoryName; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.LookupText; }
        }
        #endregion Id and Name fields

        #region Constructor
        public PrmEmploymentInfoRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[PRM_EmploymentInfo]")
            {
                LocalTextPrefix = "Configurations.PrmEmploymentInfo";
            }
        }
        #endregion RowFields
    }
}

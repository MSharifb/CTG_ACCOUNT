using VistaGL.Modules.Common;

namespace VistaGL.HRM.Entities {
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("POMS_MPA"), DisplayName("PRM_EmploymentInfo"), InstanceName("PRM_EmploymentInfo"), TwoLevelCached]
    [ReadPermission("HRM:PRM_EmploymentInfo:Read")]
    [InsertPermission("HRM:PRM_EmploymentInfo:Insert")]
    [UpdatePermission("HRM:PRM_EmploymentInfo:Update")]
    [DeletePermission("HRM:PRM_EmploymentInfo:Delete")]
    [LookupScript("HRM.EmploymentInfo")]
    public sealed class EmploymentInfoRow : Row, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Emp Id
        [DisplayName("Emp Id"), Column("EmpID"), Size(15), NotNull, QuickSearch]
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
        //[LookupEditor(typeof(HRM.Entities.PrmNameTitleRow), InplaceAdd = true)]
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
        [DisplayName("Full Name"), Size(200), NotNull]
        public String FullName { get { return Fields.FullName[this]; } set { Fields.FullName[this] = value; } }
        public partial class RowFields { public StringField FullName; }
        #endregion FullName


        #region Designation
        [DisplayName("Designation"), ForeignKey("[dbo].[PRM_Designation]", "Id"), LeftJoin("jDesignation"), TextualField("DesignationName")]
        //[LookupEditor(typeof(HRM.Entities.PrmDesignationRow), InplaceAdd = true)]
        public Int32? DesignationId { get { return Fields.DesignationId[this]; } set { Fields.DesignationId[this] = value; } }
        public partial class RowFields { public Int32Field DesignationId; }
        #endregion DesignationId

        #region Discipline
        [DisplayName("Discipline"), ForeignKey("[dbo].[PRM_Discipline]", "Id"), LeftJoin("jDiscipline"), TextualField("DisciplineName")]
        //[LookupEditor(typeof(HRM.Entities.PrmDisciplineRow), InplaceAdd = true)]
        public Int32? DisciplineId { get { return Fields.DisciplineId[this]; } set { Fields.DisciplineId[this] = value; } }
        public partial class RowFields { public Int32Field DisciplineId; }
        #endregion DisciplineId

        #region Division
        [DisplayName("Division"), ForeignKey("[dbo].[PRM_Division]", "Id"), LeftJoin("jDivision"), TextualField("DivisionName")]
        //[LookupEditor(typeof(HRM.Entities.PrmDivisionRow), InplaceAdd = true)]
        public Int32? DivisionId { get { return Fields.DivisionId[this]; } set { Fields.DivisionId[this] = value; } }
        public partial class RowFields { public Int32Field DivisionId; }
        #endregion DivisionId


        #region Employment Status
        [DisplayName("Employment Status"), NotNull, ForeignKey("[dbo].[PRM_EmploymentStatus]", "Id"), LeftJoin("jEmploymentStatus"), TextualField("EmploymentStatusName")]
        //[LookupEditor(typeof(HRM.Entities.PrmEmploymentStatusRow), InplaceAdd = true)]
        public Int32? EmploymentStatusId { get { return Fields.EmploymentStatusId[this]; } set { Fields.EmploymentStatusId[this] = value; } }
        public partial class RowFields { public Int32Field EmploymentStatusId; }
        #endregion EmploymentStatusId

        #region Prl Date
        [DisplayName("Prl Date"), Column("PRLDate")]
        public DateTime? PrlDate { get { return Fields.PrlDate[this]; } set { Fields.PrlDate[this] = value; } }
        public partial class RowFields { public DateTimeField PrlDate; }
        #endregion PrlDate


        #region Region
        [DisplayName("Region"), NotNull, ForeignKey("[dbo].[PRM_Region]", "Id"), LeftJoin("jRegion"), TextualField("RegionName")]
        ////[LookupEditor(typeof(HRM.Entities.PrmRegionRow), InplaceAdd = true)]
        public Int32? RegionId { get { return Fields.RegionId[this]; } set { Fields.RegionId[this] = value; } }
        public partial class RowFields { public Int32Field RegionId; }
        #endregion RegionId


        #region Foreign Fields
        [DisplayName("Title Name"), Expression("jTitle.[Name]")]
        public String TitleName { get { return Fields.TitleName[this]; } set { Fields.TitleName[this] = value; } }
        public partial class RowFields { public StringField TitleName; }

        [DisplayName("Title Name"), Expression("T0.EmpId + ' - ' + T0.FullName")]
        public String LookupText { get { return Fields.LookupText[this]; } set { Fields.LookupText[this] = value; } }
        public partial class RowFields { public StringField LookupText; }


        [DisplayName("Designation Name"), Expression("jDesignation.[Name]")]
        public String DesignationName { get { return Fields.DesignationName[this]; } set { Fields.DesignationName[this] = value; } }
        public partial class RowFields { public StringField DesignationName; }


        [DisplayName("Discipline Name"), Expression("jDiscipline.[Name]")]
        public String DisciplineName { get { return Fields.DisciplineName[this]; } set { Fields.DisciplineName[this] = value; } }
        public partial class RowFields { public StringField DisciplineName; }


        [DisplayName("Division Name"), Expression("jDivision.[Name]")]
        public String DivisionName { get { return Fields.DivisionName[this]; } set { Fields.DivisionName[this] = value; } }
        public partial class RowFields { public StringField DivisionName; }


        [DisplayName("Employment Status Name"), Expression("jEmploymentStatus.[Name]")]
        public String EmploymentStatusName { get { return Fields.EmploymentStatusName[this]; } set { Fields.EmploymentStatusName[this] = value; } }
        public partial class RowFields { public StringField EmploymentStatusName; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField {
            get { return Fields.LookupText; }
        }
        #endregion Id and Name fields

        #region Constructor
        public EmploymentInfoRow()
        : base(Fields) {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();
        public const string TableName = "[dbo].[PRM_EmploymentInfo]";

        public partial class RowFields : RowFieldsBase {
            public RowFields()
            : base(EmploymentInfoRow.TableName) {
                LocalTextPrefix = "HRM.EmploymentInfo";
            }
        }
        #endregion RowFields
    }
}

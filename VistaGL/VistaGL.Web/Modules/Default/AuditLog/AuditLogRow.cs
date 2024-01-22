
namespace VistaGL.Default.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Audit Log"), InstanceName("Audit Log"), TwoLevelCached]
    [ReadPermission("Default:AuditLog:Read")]
    [InsertPermission("Default:AuditLog:Insert")]
    [UpdatePermission("Default:AuditLog:Update")]
    [DeletePermission("Default:AuditLog:Delete")]
    [LookupScript("Default.AuditLog", Permission = "?")]
    public sealed class AuditLogRow : Row, IIdRow, INameRow
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int64? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int64Field Id; }
        #endregion Id

        #region User Id
        [DisplayName("User Id"), NotNull]
        public Int32? UserId { get { return Fields.UserId[this]; } set { Fields.UserId[this] = value; } }
        public partial class RowFields { public Int32Field UserId; }
        #endregion UserId

        #region User Name
        [DisplayName("Employee Id"), Size(50), NotNull, ForeignKey("dbo.prm_EmploymentInfo", "empid"), LeftJoin("jEmployee"), TextualField("UserFullName")]
        public String UserName { get { return Fields.UserName[this]; } set { Fields.UserName[this] = value; } }
        public partial class RowFields { public StringField UserName; }
        #endregion UserName


        //[DisplayName("User Name"), NotMapped]
        //public String UserFullName { get { return Fields.UserFullName[this]; } set { Fields.UserFullName[this] = value; } }
        //public partial class RowFields { public StringField UserFullName; }

        //[DisplayName("Zone Name"), NotMapped]
        //public String ZoneName { get { return Fields.ZoneName[this]; } set { Fields.ZoneName[this] = value; } }
        //public partial class RowFields { public StringField ZoneName; }


        #region Action
        [DisplayName("Action"), Size(50), NotNull, QuickSearch]
        [LookupEditor("AuditLog.ActionName_Lookup")]
        public String Action { get { return Fields.Action[this]; } set { Fields.Action[this] = value; } }
        public partial class RowFields { public StringField Action; }
        #endregion Action

        #region Changed On
        [DisplayName("Changed On"), NotNull, DateTimeEditor, DateTimeFormatter(DisplayFormat = "dd-MM-yyyy HH:mm")]
        public DateTime? ChangedOn { get { return Fields.ChangedOn[this]; } set { Fields.ChangedOn[this] = value; } }
        public partial class RowFields { public DateTimeField ChangedOn; }
        #endregion ChangedOn

        #region Table Name
        [DisplayName("Table Name"), Size(50), NotNull, Column("TableName"), QuickSearch]
        [LookupEditor("AuditLog.TableName_Lookup")]
        public String DBTableName { get { return Fields.DBTableName[this]; } set { Fields.DBTableName[this] = value; } }
        public partial class RowFields { public StringField DBTableName; }
        #endregion DBTableName

        #region Row Id
        [DisplayName("Row Id"), NotNull]
        public Int32? RowId { get { return Fields.RowId[this]; } set { Fields.RowId[this] = value; } }
        public partial class RowFields { public Int32Field RowId; }
        #endregion RowId

        #region Module
        [DisplayName("Module"), Size(500)]
        public String Module { get { return Fields.Module[this]; } set { Fields.Module[this] = value; } }
        public partial class RowFields { public StringField Module; }
        #endregion Module

        #region Page
        [DisplayName("Page"), Size(500)]
        public String Page { get { return Fields.Page[this]; } set { Fields.Page[this] = value; } }
        public partial class RowFields { public StringField Page; }
        #endregion Page

        #region Changes
        [DisplayName("Changes"), Size(-1), QuickSearch]
        public String Changes { get { return Fields.Changes[this]; } set { Fields.Changes[this] = value; } }
        public partial class RowFields { public StringField Changes; }
        #endregion Changes


        #region Foreign Fields

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.UserName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AuditLogRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public const string TableName = "[dbo].[AuditLog]";

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[AuditLog]")
            {
                LocalTextPrefix = "Default.AuditLog";
            }
        }
        #endregion RowFields
    }
}

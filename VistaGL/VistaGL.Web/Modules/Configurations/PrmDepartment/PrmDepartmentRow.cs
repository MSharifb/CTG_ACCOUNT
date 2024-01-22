
namespace VistaGL.Configurations.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[PRM_Division]")]
    [DisplayName("Division/Department"), InstanceName("Division/Department")]
    [ReadPermission("Configurations:PRM_Division:(*)")]
    public sealed class PrmDepartmentRow : Row, IIdRow, INameRow
    {

        [DisplayName("Id"), PrimaryKey]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Name"), Size(100), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Sort Order"), NotNull]
        public Int32? SortOrder
        {
            get { return Fields.SortOrder[this]; }
            set { Fields.SortOrder[this] = value; }
        }

        [DisplayName("Remarks"), Size(100)]
        public String Remarks
        {
            get { return Fields.Remarks[this]; }
            set { Fields.Remarks[this] = value; }
        }

        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        public Int32? ZoneInfoId
        {
            get { return Fields.ZoneInfoId[this]; }
            set { Fields.ZoneInfoId[this] = value; }
        }



        [DisplayName("Zone Info Zone Name"), Expression("jZoneInfo.[ZoneName]")]
        public String ZoneInfoZoneName
        {
            get { return Fields.ZoneInfoZoneName[this]; }
            set { Fields.ZoneInfoZoneName[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public PrmDepartmentRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field Id;

            public StringField Name;

            public Int32Field SortOrder;

            public StringField Remarks;

            public Int32Field ZoneInfoId;

            public StringField ZoneInfoZoneName;


		}
    }
}

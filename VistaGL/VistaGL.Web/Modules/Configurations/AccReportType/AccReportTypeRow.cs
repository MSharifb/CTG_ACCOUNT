
namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[acc_ReportType]")][DisplayName("Acc Report Type"), InstanceName("Acc Report Type")]
    [ReadPermission("Configurations:AccReportTypeGroupSetup:(*)")]
    [InsertPermission("Configurations:AccReportTypeGroupSetup:(*)")]
    [UpdatePermission("Configurations:AccReportTypeGroupSetup:(*)")]
    [DeletePermission("Configurations:AccReportTypeGroupSetup:(*)")]
    [LookupScript("Configurations.AccReportType", Permission = "?")]
    public sealed class AccReportTypeRow : NRow, IIdRow, INameRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Report Type"), Size(500), NotNull, QuickSearch]
        public String ReportType
        {
            get { return Fields.ReportType[this]; }
            set { Fields.ReportType[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.ReportType; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccReportTypeRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {

            public Int32Field Id;

            public StringField ReportType;


		}
    }
}

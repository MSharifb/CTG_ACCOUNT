using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190701161010)]
    public class ACCDB_20190701_16010_ReportTypeGroupSetupAlter: Migration
    {
        public override void Up()
        {
            //throw new NotImplementedException();
            Alter.Table("acc_ReportTypeGroupSetup")
                 .AddColumn("Symbol").AsString().Nullable()
                 .AddColumn("FontWeight").AsString().Nullable();
        }
        public override void Down()
        {
            //throw new NotImplementedException();
        }
    }
}
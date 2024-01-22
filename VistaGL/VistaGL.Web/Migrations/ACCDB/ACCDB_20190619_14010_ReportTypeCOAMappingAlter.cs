using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190619140010)]
    public class ACCDB_20190619_14010_ReportTypeCOAMappingAlter: Migration
    {
        public override void Up()
        {
            //throw new NotImplementedException();
            Alter.Table("acc_ReportTypeCOAMapping")
                 .AddColumn("OpeningBalance").AsDecimal(18,5).Nullable();

            Alter.Table("acc_ReportTypeCostCenterMapping")
                 .AddColumn("OpeningBalance").AsDecimal(18,5).Nullable();
        }
        public override void Down()
        {
            //throw new NotImplementedException();
        }
    }
}
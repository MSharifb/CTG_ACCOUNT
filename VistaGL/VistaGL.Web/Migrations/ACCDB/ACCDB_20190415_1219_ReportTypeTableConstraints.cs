using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190415121900)]
    public class ACCDB_20190415_1219_ReportTypeTableConstraints : Migration
    {
        public override void Up()
        {
            Alter.Table("acc_ReportTypeGroupSetup")
                .AlterColumn("ReportTypeId").AsInt32().NotNullable().WithDefaultValue(1)
                .AlterColumn("GroupName").AsString(500).NotNullable().WithDefaultValue("<blank>");

            Alter.Table("acc_ReportTypeCOAMapping")
                .AddColumn("createdUserDate").AsDateTime().Nullable()
                .AddColumn("createdUserId").AsString(255).Nullable()
                .AddColumn("updatedUserDate").AsDateTime().Nullable()
                .AddColumn("updatedUserId").AsString(255).Nullable();

            Alter.Table("acc_ReportTypeCostCenterMapping")
                .AddColumn("createdUserDate").AsDateTime().Nullable()
                .AddColumn("createdUserId").AsString(255).Nullable()
                .AddColumn("updatedUserDate").AsDateTime().Nullable()
                .AddColumn("updatedUserId").AsString(255).Nullable();
        }

        public override void Down()
        {
            //
        }
    }
}
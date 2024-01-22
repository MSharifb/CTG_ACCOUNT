using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190411155200)]
    public class ACCDB_20190411_1552_GroupOpeningBalance: Migration
    {
        public override void Up()
        {
            Create.Table("acc_ReportTypeGroupOpeningBalance")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("GroupId").AsInt32().NotNullable()
                .WithColumn("ZoneId").AsInt32().NotNullable()
                .WithColumn("FundControlId").AsInt32().NotNullable()
                .WithColumn("OpeningBalance").AsDecimal().Nullable()
                .WithColumn("createdUserDate").AsDateTime().Nullable()
                .WithColumn("createdUserId").AsString().Nullable()
                .WithColumn("updatedUserDate").AsDateTime().Nullable()
                .WithColumn("updatedUserId").AsString().Nullable();

            Create.ForeignKey("acc_ReportTypeGroupOpeningBalance_acc_ReportTypeGroupSetup")
            .FromTable("acc_ReportTypeGroupOpeningBalance").ForeignColumn("GroupId")
            .ToTable("acc_ReportTypeGroupSetup").PrimaryColumn("Id");

            Create.ForeignKey("acc_ReportTypeGroupOpeningBalance_PRM_ZoneInfo")
            .FromTable("acc_ReportTypeGroupOpeningBalance").ForeignColumn("ZoneId")
            .ToTable("PRM_ZoneInfo").PrimaryColumn("Id");

            Create.ForeignKey("acc_ReportTypeGroupOpeningBalance_acc_FundControlInformation")
            .FromTable("acc_ReportTypeGroupOpeningBalance").ForeignColumn("FundControlId")
            .ToTable("acc_FundControlInformation").PrimaryColumn("Id");
        }
        public override void Down()
        {
            //throw new NotImplementedException();
        }
    }
}
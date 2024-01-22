using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190409134600)]
    public class ACCBD_20190409_1346_ReportTypeGroupSetup_Table : Migration
    {
        public override void Up()
        {
            Create.Table("acc_ReportTypeGroupSetup")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ParentId").AsInt32().Nullable()
                .WithColumn("ReportTypeId").AsInt32().Nullable()
                .WithColumn("GroupName").AsString().Nullable()
                .WithColumn("SortingOrder").AsInt32().Nullable()
                .WithColumn("ShowAutoSum").AsBoolean().Nullable()
                .WithColumn("NoteNo").AsInt32().Nullable()
                .WithColumn("AddBlankSpaceBefore").AsBoolean().Nullable()
                .WithColumn("AddBlankSpaceAfter").AsBoolean().Nullable()
                .WithColumn("ShowBottomBorder").AsBoolean().Nullable()
                .WithColumn("ShowUpperBorder").AsBoolean().Nullable()
                .WithColumn("ShowLeftBorder").AsBoolean().Nullable()
                .WithColumn("ShowRightBorder").AsBoolean().Nullable()
                .WithColumn("FundControlId").AsInt32().Nullable()
                .WithColumn("createdUserDate").AsDateTime().Nullable()
                .WithColumn("createdUserId").AsString().Nullable()
                .WithColumn("updatedUserDate").AsDateTime().Nullable()
                .WithColumn("updatedUserId").AsString().Nullable();


            Create.ForeignKey("acc_ReportTypeGroupSetup_acc_ReportType")
                .FromTable("acc_ReportTypeGroupSetup").ForeignColumn("ReportTypeId")
                .ToTable("acc_ReportType").PrimaryColumn("Id");

            Create.ForeignKey("acc_ReportTypeGroupSetup_acc_FundControlInformation")
                .FromTable("acc_ReportTypeGroupSetup").ForeignColumn("FundControlId")
                .ToTable("acc_FundControlInformation").PrimaryColumn("Id");

        }
        public override void Down()
        {
           // throw new NotImplementedException();
        }
    }
}
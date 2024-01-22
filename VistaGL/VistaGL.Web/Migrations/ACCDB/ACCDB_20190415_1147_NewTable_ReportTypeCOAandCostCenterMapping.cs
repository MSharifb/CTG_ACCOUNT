using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190415114700)]
    public class ACCDB_20190415_1147_NewTable_ReportTypeCOAandCostCenterMapping:Migration
    {
        public override void Up()
        {
            // Chart of Accounts
            Create.Table("acc_ReportTypeCOAMapping")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("GroupId").AsInt32().NotNullable()
                .WithColumn("COAId").AsInt32().NotNullable();
            
            Create.ForeignKey("FK_acc_ReportTypeCOAMapping_GroupId_acc_ReportTypeGroupSetup_Id")
                .FromTable("acc_ReportTypeCOAMapping").ForeignColumn("GroupId")
                .ToTable("acc_ReportTypeGroupSetup").PrimaryColumn("Id");
            
            Create.ForeignKey("FK_acc_ReportTypeCOAMapping_COAId_acc_ChartofAccounts_Id")
                .FromTable("acc_ReportTypeCOAMapping").ForeignColumn("COAId")
                .ToTable("acc_ChartofAccounts").PrimaryColumn("Id");



            // Cost Center
            Create.Table("acc_ReportTypeCostCenterMapping")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("GroupId").AsInt32().NotNullable()
                .WithColumn("CostCenterId").AsInt32().NotNullable();
            
            Create.ForeignKey("FK_acc_ReportTypeCostCenterMapping_GroupId_acc_ReportTypeGroupSetup_Id")
                .FromTable("acc_ReportTypeCostCenterMapping").ForeignColumn("GroupId")
                .ToTable("acc_ReportTypeGroupSetup").PrimaryColumn("Id");
            
            Create.ForeignKey("FK_acc_ReportTypeCostCenterMapping_CostCenterId_acc_Cost_Centre_or_Institute_Information_Id")
                .FromTable("acc_ReportTypeCostCenterMapping").ForeignColumn("CostCenterId")
                .ToTable("acc_Cost_Centre_or_Institute_Information").PrimaryColumn("Id");

        }

        public override void Down()
        {
            //...
        }
    }
}
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190331161300)]
    public class ACCDB_20190331_1613_BudgetForwardFromZoneSetup_Table : Migration
    {

        public override void Up()
        {
            Create.Table("Acc_BudgetZoneApprover")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("EmployeeId").AsInt32().NotNullable()
                .WithColumn("ZoneId").AsInt32().NotNullable()
                .WithColumn("EntityId").AsInt32().NotNullable();

            Create.ForeignKey("fk_Acc_BudgetZoneApprover_Zone")
                .FromTable("Acc_BudgetZoneApprover").ForeignColumn("ZoneId")
                .ToTable("PRM_ZoneInfo").PrimaryColumn("Id");


            Create.ForeignKey("fk_Acc_BudgetZoneApprover_Employee")
                .FromTable("Acc_BudgetZoneApprover").ForeignColumn("EmployeeId")
                .ToTable("PRM_EmploymentInfo").PrimaryColumn("Id");

            Create.ForeignKey("fk_Acc_BudgetZoneApprover_FundControlId")
                .FromTable("Acc_BudgetZoneApprover").ForeignColumn("EntityId")
                .ToTable("acc_FundControlInformation").PrimaryColumn("Id");
        }

        public override void Down()
        {
            //...
        }
    }
}
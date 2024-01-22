using FluentMigrator;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190407113000)]
    public class ACCDB_20190407_1130_Adding_FK_BudgetApproverHistory : Migration
    {
        public override void Up()
        {
            Alter.Column("FromAppoverId").OnTable("acc_BudgetApprovalHistory")
                .AsInt32()
                .ForeignKey("fk_acc_BudgetApprovalHistory_FromApproverId_prm_EmploymentInfo_Id", "dbo", "PRM_EmploymentInfo", "Id");

            Alter.Column("ToApproverId").OnTable("acc_BudgetApprovalHistory")
            .AsInt32()
            .ForeignKey("fk_acc_BudgetApprovalHistory_ToApproverId_prm_EmploymentInfo_Id", "dbo", "PRM_EmploymentInfo", "Id");
        }

        public override void Down()
        {
            //...
        }
    }
}
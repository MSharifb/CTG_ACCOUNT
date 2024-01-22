using FluentMigrator;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190338151200)]
    public class ACCDB_20190338_1512_BudgetDepartment_FK_FundControlId : Migration
    {
        public override void Up()
        {
            Create.ForeignKey("fk_acc_budget_ForDepartment_EntityId_acc_FundControlInformation_Id")
                .FromTable("acc_Budget_ForDepartment").ForeignColumn("EntityId")
                .ToTable("acc_FundControlInformation").PrimaryColumn("Id");
        }

        public override void Down()
        {
            //...
        }
    }
}
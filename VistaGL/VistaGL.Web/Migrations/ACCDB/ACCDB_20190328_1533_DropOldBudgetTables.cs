using FluentMigrator;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190328153300)]
    public class ACCDB_20190328_1533_DropOldBudgetTables: Migration
    {
        public override void Up()
        {
            Delete.Table("acc_Budget_Submission_Detail");
            Delete.Table("acc_Budget_Submission");
            Delete.Table("acc_BudgetZoneItemsDetails");
            Delete.Table("acc_BudgetZoneItems");
            Delete.Table("acc_BudgetZoneMaster");
            Delete.Table("acc_BudgetDepartmentInfo");

            Delete.Table("acc_BudgetHQItemsDetails");
            Delete.Table("acc_BudgetHQItems");
            Delete.Table("acc_BudgetHQMaster");

        }

        public override void Down()
        {
            //..
        }
    }
}
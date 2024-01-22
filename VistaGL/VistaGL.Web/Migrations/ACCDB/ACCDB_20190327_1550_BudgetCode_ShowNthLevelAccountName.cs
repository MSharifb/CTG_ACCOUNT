using FluentMigrator;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190327155000)]
    public class ACCDB_20190327_1550_BudgetCode_ShowNthLevelAccountName : Migration
    {
        public override void Up()
        {
            Alter.Table("acc_ChartofAccounts")
                .AddColumn("BudgetCode")
                    .AsString(50)
                    .Nullable()
                .AddColumn("IsHideChildrenFromThisLevel")
                    .AsBoolean()
                    .NotNullable()
                    .WithDefaultValue(false);

            Alter.Table("acc_Cost_Centre_or_Institute_Information")
                .AddColumn("BudgetCode")
                    .AsString(50)
                    .Nullable();

            Alter.Table("acc_Budget_Group")
                .AddColumn("BudgetCode")
                    .AsString(50)
                    .Nullable();

        }

        public override void Down()
        {
            //...
        }
    }
}
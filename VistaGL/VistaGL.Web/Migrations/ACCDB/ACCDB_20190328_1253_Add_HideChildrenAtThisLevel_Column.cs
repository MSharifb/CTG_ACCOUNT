using FluentMigrator;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190328125300)]
    public class ACCDB_20190328_1253_Add_HideChildrenAtThisLevel_Column : Migration
    {
        public override void Up()
        {
            Alter.Table("acc_Budget_Group")
                    .AddColumn("IsHideChildrenFromThisLevel")
                    .AsBoolean()
                    .NotNullable()
                    .WithDefaultValue(false);
        }

        public override void Down()
        {
            //
        }
    }
}
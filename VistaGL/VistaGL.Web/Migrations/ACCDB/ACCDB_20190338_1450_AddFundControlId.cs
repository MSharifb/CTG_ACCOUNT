using FluentMigrator;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190338145000)]
    public class ACCDB_20190338_1450_AddFundControlId : Migration
    {
        public override void Up()
        {
            Alter.Table("acc_Budget_ForDepartment")
                .AddColumn("EntityId")
                .AsInt32()
                .NotNullable()
                .WithDefaultValue(1);
        }

        public override void Down()
        {
            //...
        }
    }
}
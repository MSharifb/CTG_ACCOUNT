using FluentMigrator;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190127105200)]
    public class ACCDB_20190127_1052_AlterAcc_Bugdet_Group_AddColFundControlId : Migration
    {

        public override void Up()
        {
            Alter.Table("acc_budget_group")
                .AddColumn("FundControlId")
                .AsInt32()
                .WithDefaultValue(1)
                .NotNullable();

            Create.ForeignKey("fk_acc_budget_group_FundControlId_acc_FundControlInformation_Id")
                .FromTable("acc_budget_group").ForeignColumn("FundControlId")
                .ToTable("acc_FundControlInformation").PrimaryColumn("Id");

            Execute.Script(HttpContext.Current.Server.MapPath("Migrations/ACCDB/SqlScripts/Rpt_SP_Acc_BudgetGroup.sql"));
        }

        public override void Down()
        {
            //
        }

    }
}
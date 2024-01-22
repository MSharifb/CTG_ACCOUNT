using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190407112300)]
    public class ACCDB_20190407_1123_AlterColumn_BudgetApprovalHistory_BudgetId : Migration
    {
        public override void Up()
        {
            Execute.Sql("EXEC sp_RENAME 'acc_BudgetApprovalHistory.BudgetId', 'BudgetForDepartmentId', 'COLUMN'");
        }

        public override void Down()
        {
            //...
        }
    }
}
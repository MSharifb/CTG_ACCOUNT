using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190515100100)]
    public class ACCDB_20190515_10010_VoucherConfigurationAlter : Migration
    {
        public override void Up()
        {
            //throw new NotImplementedException();
            Alter.Table("acc_Voucher_Configuration")
                 .AddColumn("NewNumberforEveryBankAccount").AsBoolean().NotNullable().WithDefaultValue(false);
        }
        public override void Down()
        {
            //throw new NotImplementedException();
        }
    }
}
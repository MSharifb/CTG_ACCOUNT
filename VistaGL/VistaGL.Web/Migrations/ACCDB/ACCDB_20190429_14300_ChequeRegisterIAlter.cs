using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Migrations.ACCDB
{
    [Migration(20190429143000)]
    public class ACCDB_20190429_14300_ChequeRegisterIAlter: Migration
    {
        public override void Up()
        {
            //throw new NotImplementedException();
            Alter.Table("acc_voucher_details")
                 .AddColumn("AdjustedChequeRegisterId").AsInt64().Nullable().ForeignKey("acc_voucher_details_acc_ChequeRegister", "acc_ChequeRegister", "id");

        }
        public override void Down()
        {
            //throw new NotImplementedException();
        }
    }
}
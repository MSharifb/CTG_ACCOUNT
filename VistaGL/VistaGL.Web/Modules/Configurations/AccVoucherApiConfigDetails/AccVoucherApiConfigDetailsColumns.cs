
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccVoucherApiConfigDetails")]
    [BasedOnRow(typeof(Entities.AccVoucherApiConfigDetailsRow))]
    public class AccVoucherApiConfigDetailsColumns
    {
   
        public String AccountHeadAccountName { get; set; }
        [EditLink]
        public String DrCr { get; set; }
        public String Description { get; set; }
    }
}
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VistaGL
{
    public abstract class NRow : Row, ILoggingRow
    {
        [NotMapped]
        public int? __id { get { return Fields.__id[this]; } set { Fields.__id[this] = value; } }

        [DisplayName("Create Date")]
        public DateTime? createdUserDate { get { return Fields.createdUserDate[this]; } set { Fields.createdUserDate[this] = value; } }

        [DisplayName("Insert User Id")]
        [ForeignKey("dbo.TblUsers", "UserId"), LeftJoin("createdBy")]
        public string createdUserId { get { return Fields.createdUserId[this]; } set { Fields.createdUserId[this] = value; } }

        [Expression("createdBy.LastName"), DisplayName("Created By")]
        public string createdUserName { get { return Fields.createdUserId[this]; } set { Fields.createdUserId[this] = value; } }

        [DisplayName("Update Date")]
        public DateTime? updatedUserDate { get { return Fields.updatedUserDate[this]; } set { Fields.updatedUserDate[this] = value; } }

        [DisplayName("Update User Id")]
        public string updatedUserId { get { return Fields.updatedUserId[this]; } set { Fields.updatedUserId[this] = value; } }

        IIdField IInsertLogRow.InsertUserIdField
        {
            get { return Fields.createdUserId; }
        }

        IIdField IUpdateLogRow.UpdateUserIdField
        {
            get { return Fields.updatedUserId; }
        }

        DateTimeField IInsertLogRow.InsertDateField
        {
            get { return Fields.createdUserDate; }
        }

        DateTimeField IUpdateLogRow.UpdateDateField
        {
            get { return Fields.updatedUserDate; }
        }

        public NRow(NRowFields fields) : base(fields)
        {
            Fields = fields;
        }

        private NRowFields Fields;

        public abstract class NRowFields : RowFieldsBase
        {

            public Int32Field __id;
            public StringField createdUserId;
            public StringField updatedUserId;
            public DateTimeField createdUserDate;
            public DateTimeField updatedUserDate;

            public StringField createdUserName;

            public NRowFields(string tableName = null, string fieldPrefix = "") : base(tableName, fieldPrefix)
            {

            }
        }

    }
}
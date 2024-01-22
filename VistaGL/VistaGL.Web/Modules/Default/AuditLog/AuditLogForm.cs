
namespace VistaGL.Default.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Default.AuditLog")]
    [BasedOnRow(typeof(Entities.AuditLogRow))]
    public class AuditLogForm
    {
        [HalfWidth]
        public Int32 UserId { get; set; }
        [HalfWidth]
        public String UserName { get; set; }

        public String UserFullName { get; set; }

        public String ZoneName { get; set; }

        [HalfWidth]
        public String Action { get; set; }
        [HalfWidth]
        public DateTime ChangedOn { get; set; }

        public String Module { get; set; }

        public String Page { get; set; }

        public Int32 RowId { get; set; }

        public String DBTableName { get; set; }

        [TextAreaEditor(Rows = 12), Insertable(false), Updatable(false)]
        public String Changes { get; set; }
    }
}
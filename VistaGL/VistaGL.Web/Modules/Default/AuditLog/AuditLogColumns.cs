
namespace VistaGL.Default.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("Default.AuditLog")]
    [BasedOnRow(typeof(Entities.AuditLogRow))]
    public class AuditLogColumns
    {
        public Int32 UserId { get; set; }

        [EditLink, QuickFilter, Width(100)]
        public String UserName { get; set; }

        [QuickFilter, Width(100)]
        public String Action { get; set; }

        [QuickFilter, Width(180), AlignRight]
        public DateTime ChangedOn { get; set; }

        [QuickFilter, Width(300)]
        public String DBTableName { get; set; }

        [Width(300)]
        public String Changes { get; set; }

    }
}
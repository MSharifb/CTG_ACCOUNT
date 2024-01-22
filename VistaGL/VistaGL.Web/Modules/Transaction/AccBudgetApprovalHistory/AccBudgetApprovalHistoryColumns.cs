
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccBudgetApprovalHistory")]
    [BasedOnRow(typeof(Entities.AccBudgetApprovalHistoryRow), CheckNames = true)]
    public class AccBudgetApprovalHistoryColumns
    {
        [DisplayName("From")]
        public String FromEmpFullName { get; set; }

        [DisplayName("Status")]
        public ApprovalStatus? ApprovalStatusId { get; set; }

        [DisplayName("To")]
        public String ToEmpFullName { get; set; }

    }
}
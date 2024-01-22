
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccBudgetApprovalHistory")]
    [BasedOnRow(typeof(Entities.AccBudgetApprovalHistoryRow), CheckNames = true)]
    public class AccBudgetApprovalHistoryForm
    {
        public Int32 BudgetForDepartmentId { get; set; }
        public Int32 FromAppoverId { get; set; }
        public Int32 ApprovalStatusId { get; set; }
        public Int32 ToApproverId { get; set; }
    }
}

namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccNoa")]
    [BasedOnRow(typeof(Entities.AccNoaRow))]
    public class AccNoaForm
    {
        [CssClass("width6")]
        public String NoaNumber { get; set; }
        [CssClass("width6")]
        public DateTime NoaDate { get; set; }
        [CssClass("width6")]
        public Int32 CostCenterId { get; set; }
        [CssClass("width6")]
        public Decimal ContactValue { get; set; }
        [CssClass("width6")]
        public String NameofContract { get; set; }
        [CssClass("width6")]
        public DateTime ContractDate { get; set; }
        [CssClass("width6")]
        public Decimal? BudgetProvision { get; set; }
        [CssClass("width6")]
        public String TenderNo { get; set; }
        [CssClass("width6")]
        public String AdministrativeApproved { get; set; }
        [CssClass("width6")]
        public DateTime? AdministrativeDate { get; set; }
        [CssClass("width6")]
        public String TechnicalApproved { get; set; }
        [CssClass("width6")]
        public DateTime? TechnicalDate { get; set; }
        [CssClass("width6")]
        public String FinancialApproved { get; set; }
        [CssClass("width6")]
        public DateTime? FinancialDate { get; set; }
        [CssClass("width6")]
        public String NameofContractor { get; set; }
        [CssClass("width6")]
        public String ContractorAddress { get; set; }
        [CssClass("width6")]
        public Decimal? SecurityMoney { get; set; }
        [CssClass("width6")]
        public String MBNo { get; set; }
        [CssClass("width6")]
        public DateTime? WorkStartOn { get; set; }
        [CssClass("width6")]
        public DateTime? CompilationDate { get; set; }

        [Visible(false)]
        public Int32? ZoneInfoId { get; set; }
    }
}
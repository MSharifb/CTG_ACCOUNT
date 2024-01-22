
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;
    using Entities;

    [FormScript("Transaction.AccCostCentreOrInstituteInformation")]
    [BasedOnRow(typeof(Entities.AccCostCentreOrInstituteInformationRow))]
    public class AccCostCentreOrInstituteInformationForm
    {

        [Tab("General")]
        [Category("Subledger Properties")]

        public Boolean IsInstitute { get; set; }

        public Int32 CostCenterTypeId { get; set; }

        public Int32 EmpId { get; set; }

        public String UserCode { get; set; }

        [Hidden(), ReadOnly(true)]
        public String AccountCodeClient { get; set; }

        [Hidden(), ReadOnly(true)]
        public String Code { get; set; }

        [Hidden(), ReadOnly(true)]
        public Int32 CodeCount { get; set; }

        public String Name { get; set; }

        public String NameForBankAdviceLetter { get; set; }

        public Int32 ParentId { get; set; }

        //public Double PaAmmount { get; set; }

        [TextAreaEditor(Rows = 5)]
        public String Remarks { get; set; }

        //public Int32 EntityId { get; set; }

        public Boolean IsActive { get; set; }

        [Tab("Budget Sett.")]
        [Category("Settings for Budget")]

        [CssClass("width6")]
        public Boolean IsBudgetHead { get; set; }
        [CssClass("width6")]
        public String BudgetCode { get; set; }

        public Int32 BudgetGroupId { get; set; }

        [Tab("Merge Subledger")]
        [Category("Merge Subledger")]

        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow),
            FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        [DisplayName("Merge From")]
        public Int32? FromCostCenter { get; set; }

        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow),
            FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        [DisplayName("Merge To")]
        public Int32? ToCostCenter { get; set; }

        [ReadOnly(true)]
        public String ZoneName { get; set; }


        [Tab("Fixed Asset Sett.")]
        [Category("Fixed Asset Settings")]

        public Boolean IsFixedAssetHead { get; set; }

        [RadioButtonEditor]
        public FixedAssetDevWorkType FixedAssetDevWorkTypeSelector { get; set; }

        public Decimal DepreciationRate { get; set; }


    }
}
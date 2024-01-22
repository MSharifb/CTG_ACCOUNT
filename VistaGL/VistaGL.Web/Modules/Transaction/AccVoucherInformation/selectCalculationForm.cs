using Serenity.ComponentModel;
using System.ComponentModel;

namespace VistaGL.Transaction.Forms
{
    [FormScript("Transaction.selectCalculationForm")]
    public class selectCalculationForm
    {
        [VoucherTemplateDrCrMappingEditor]
        public string Type { get; set; }
        public decimal Amount { get; set; }
        [DisplayName("Rate (%)")]
        public decimal Rate { get; set; }
    }
}
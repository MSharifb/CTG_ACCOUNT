
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccCreditVoucherFromMoneyReceipt"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccMoneyReceiptRow))]
    public class AccCreditVoucherFromMoneyReceiptController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccCreditVoucherFromMoneyReceipt/AccCreditVoucherFromMoneyReceiptIndex.cshtml");
        }
    }
}
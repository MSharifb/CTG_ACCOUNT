

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccMoneyReceipt", typeof(VistaGL.Transaction.Pages.AccMoneyReceiptController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccMoneyReceipt"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccMoneyReceiptRow))]
    public class AccMoneyReceiptController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccMoneyReceipt/AccMoneyReceiptIndex.cshtml");
        }
    }
}
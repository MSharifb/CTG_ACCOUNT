

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccMoneyReceiptDatails", typeof(VistaGL.Transaction.Pages.AccMoneyReceiptDatailsController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccMoneyReceiptDatails"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccMoneyReceiptDatailsRow))]
    public class AccMoneyReceiptDatailsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccMoneyReceiptDatails/AccMoneyReceiptDatailsIndex.cshtml");
        }
    }
}
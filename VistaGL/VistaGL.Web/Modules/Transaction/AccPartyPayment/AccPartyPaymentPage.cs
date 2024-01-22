

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccPartyPayment", typeof(VistaGL.Transaction.Pages.AccPartyPaymentController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccPartyPayment"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccPartyPaymentRow))]
    public class AccPartyPaymentController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccPartyPayment/AccPartyPaymentIndex.cshtml");
        }
    }
}
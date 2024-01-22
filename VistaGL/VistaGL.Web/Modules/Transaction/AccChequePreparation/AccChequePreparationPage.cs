

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccChequePreparation", typeof(VistaGL.Transaction.Pages.AccChequePreparationController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccChequePreparation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherInformationRow))]
    public class AccChequePreparationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccChequePreparation/AccChequePreparationIndex.cshtml");
        }
    }
}
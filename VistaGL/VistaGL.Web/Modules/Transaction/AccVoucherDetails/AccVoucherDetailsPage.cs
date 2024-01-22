

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccVoucherDetails", typeof(VistaGL.Transaction.Pages.AccVoucherDetailsController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccVoucherDetails"), Route("{action=index}")]
   // [PageAuthorize(typeof(Entities.AccVoucherDetailsRow))]
    public class AccVoucherDetailsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccVoucherDetails/AccVoucherDetailsIndex.cshtml");
        }
    }
}
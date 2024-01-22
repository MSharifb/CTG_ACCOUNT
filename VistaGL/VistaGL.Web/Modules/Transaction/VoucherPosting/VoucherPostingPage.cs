


namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/VoucherPosting"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherInformationRow))]
    public class VoucherPostingController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/VoucherPosting/VoucherPostingIndex.cshtml");
        }
    }
}
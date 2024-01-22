


namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccVoucherConfiguration"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherConfigurationRow))]
    public class AccVoucherConfigurationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccVoucherConfiguration/AccVoucherConfigurationIndex.cshtml");
        }
    }
}
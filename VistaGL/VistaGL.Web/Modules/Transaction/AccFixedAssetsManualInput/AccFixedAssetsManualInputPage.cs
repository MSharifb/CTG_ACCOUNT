
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccFixedAssetsManualInput"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccFixedAssetsManualInputRow))]
    public class AccFixedAssetsManualInputController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccFixedAssetsManualInput/AccFixedAssetsManualInputIndex.cshtml");
        }
    }
}
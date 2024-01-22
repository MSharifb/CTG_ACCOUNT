
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccFixedAssetRefurbishment"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccFixedAssetRefurbishmentRow))]
    public class AccFixedAssetRefurbishmentController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccFixedAssetRefurbishment/AccFixedAssetRefurbishmentIndex.cshtml");
        }
    }
}
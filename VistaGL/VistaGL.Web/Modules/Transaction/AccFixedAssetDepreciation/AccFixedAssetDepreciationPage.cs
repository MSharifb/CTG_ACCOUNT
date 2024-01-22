
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccFixedAssetDepreciation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccFixedAssetDepreciationRow))]
    public class AccFixedAssetDepreciationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccFixedAssetDepreciation/AccFixedAssetDepreciationIndex.cshtml");
        }
    }
}



namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccCostCenterType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccCostCenterTypeRow))]
    public class AccCostCenterTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccCostCenterType/AccCostCenterTypeIndex.cshtml");
        }
    }
}
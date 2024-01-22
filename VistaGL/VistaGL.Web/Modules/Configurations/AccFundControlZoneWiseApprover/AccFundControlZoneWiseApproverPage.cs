
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccFundControlZoneWiseApprover"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccFundControlZoneWiseApproverRow))]
    public class AccFundControlZoneWiseApproverController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccFundControlZoneWiseApprover/AccFundControlZoneWiseApproverIndex.cshtml");
        }
    }
}
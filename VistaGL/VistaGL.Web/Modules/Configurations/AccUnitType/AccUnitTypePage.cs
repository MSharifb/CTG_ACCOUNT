


namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccUnitType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccUnitTypeRow))]
    public class AccUnitTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccUnitType/AccUnitTypeIndex.cshtml");
        }
    }
}
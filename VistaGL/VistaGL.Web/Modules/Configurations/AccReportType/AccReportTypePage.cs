
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccReportType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccReportTypeRow))]
    public class AccReportTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccReportType/AccReportTypeIndex.cshtml");
        }
    }
}
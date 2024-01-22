
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccReportTypeGroupSetup"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccReportTypeGroupSetupRow))]
    public class AccReportTypeGroupSetupController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccReportTypeGroupSetup/AccReportTypeGroupSetupIndex.cshtml");
        }
    }
}
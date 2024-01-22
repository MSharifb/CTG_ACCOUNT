
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccReportTypeCoaMapping"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccReportTypeCoaMappingRow))]
    public class AccReportTypeCoaMappingController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccReportTypeCoaMapping/AccReportTypeCoaMappingIndex.cshtml");
        }
    }
}
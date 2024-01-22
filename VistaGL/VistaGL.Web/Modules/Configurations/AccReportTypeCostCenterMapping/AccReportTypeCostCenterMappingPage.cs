
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccReportTypeCostCenterMapping"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccReportTypeCostCenterMappingRow))]
    public class AccReportTypeCostCenterMappingController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccReportTypeCostCenterMapping/AccReportTypeCostCenterMappingIndex.cshtml");
        }
    }
}
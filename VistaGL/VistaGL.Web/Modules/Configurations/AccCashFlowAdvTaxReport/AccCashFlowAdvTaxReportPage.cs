
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccCashFlowAdvTaxReport"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccCashFlowAdvTaxReportRow))]
    public class AccCashFlowAdvTaxReportController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccCashFlowAdvTaxReport/AccCashFlowAdvTaxReportIndex.cshtml");
        }
    }
}

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccReportTypeGroupOpeningBalance"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccReportTypeGroupOpeningBalanceRow))]
    public class AccReportTypeGroupOpeningBalanceController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccReportTypeGroupOpeningBalance/AccReportTypeGroupOpeningBalanceIndex.cshtml");
        }
    }
}
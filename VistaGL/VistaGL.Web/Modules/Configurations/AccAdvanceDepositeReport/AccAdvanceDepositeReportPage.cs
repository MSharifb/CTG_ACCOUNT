
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccAdvanceDepositeReport"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccAdvanceDepositeReportRow))]
    public class AccAdvanceDepositeReportController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccAdvanceDepositeReport/AccAdvanceDepositeReportIndex.cshtml");
        }
    }
}
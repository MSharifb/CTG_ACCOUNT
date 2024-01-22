
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccGovtLoanReport"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccGovtLoanReportRow))]
    public class AccGovtLoanReportController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccGovtLoanReport/AccGovtLoanReportIndex.cshtml");
        }
    }
}
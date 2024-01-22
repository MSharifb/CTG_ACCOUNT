
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccFinancialReportsDetails"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccFinancialReportsDetailsRow))]
    public class AccFinancialReportsDetailsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccFinancialReportsDetails/AccFinancialReportsDetailsIndex.cshtml");
        }
    }
}
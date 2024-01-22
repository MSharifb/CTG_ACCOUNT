
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccPriorYearAdjustment"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccPriorYearAdjustmentRow))]
    public class AccPriorYearAdjustmentController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccPriorYearAdjustment/AccPriorYearAdjustmentIndex.cshtml");
        }
    }
}
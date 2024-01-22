
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccBudgetZoneApprover"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBudgetZoneApproverRow))]
    public class AccBudgetZoneApproverController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccBudgetZoneApprover/AccBudgetZoneApproverIndex.cshtml");
        }
    }
}
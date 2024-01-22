
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccBudgetCircular"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBudgetCircularRow))]
    public class AccBudgetCircularController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccBudgetCircular/AccBudgetCircularIndex.cshtml");
        }
    }
}
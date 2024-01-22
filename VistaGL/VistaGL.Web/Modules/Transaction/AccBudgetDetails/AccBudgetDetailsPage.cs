
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccBudgetDetails"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBudgetDetailsRow))]
    public class AccBudgetDetailsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccBudgetDetails/AccBudgetDetailsIndex.cshtml");
        }
    }
}
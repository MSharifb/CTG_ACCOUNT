
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccBudget"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBudgetRow))]
    public class AccBudgetController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccBudget/AccBudgetIndex.cshtml");
        }
    }
}


[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccViewBudget", typeof(VistaGL.Transaction.Pages.AccViewBudgetController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccViewBudget"), Route("{action=index}")]
 //   [PageAuthorize(typeof(Entities.AccViewBudgetRow))]
    public class AccViewBudgetController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccViewBudget/AccViewBudgetIndex.cshtml");
        }
    }
}
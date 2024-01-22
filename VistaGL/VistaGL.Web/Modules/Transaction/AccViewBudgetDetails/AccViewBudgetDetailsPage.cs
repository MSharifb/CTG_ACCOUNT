

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccViewBudgetDetails", typeof(VistaGL.Transaction.Pages.AccViewBudgetDetailsController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccViewBudgetDetails"), Route("{action=index}")]
  //  [PageAuthorize(typeof(Entities.AccViewBudgetDetailsRow))]
    public class AccViewBudgetDetailsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccViewBudgetDetails/AccViewBudgetDetailsIndex.cshtml");
        }
    }
}
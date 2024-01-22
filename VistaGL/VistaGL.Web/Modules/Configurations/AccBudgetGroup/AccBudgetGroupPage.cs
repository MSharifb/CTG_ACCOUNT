

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/AccBudgetGroup", typeof(VistaGL.Configurations.Pages.AccBudgetGroupController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccBudgetGroup"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBudgetGroupRow))]
    public class AccBudgetGroupController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccBudgetGroup/AccBudgetGroupIndex.cshtml");
        }
    }
}
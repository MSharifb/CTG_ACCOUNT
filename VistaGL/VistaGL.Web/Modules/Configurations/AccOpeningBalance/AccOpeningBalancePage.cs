

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/AccOpeningBalance", typeof(VistaGL.Configurations.Pages.AccOpeningBalanceController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccOpeningBalance"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccOpeningBalanceRow))]
    public class AccOpeningBalanceController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccOpeningBalance/AccOpeningBalanceIndex.cshtml");
        }
    }
}
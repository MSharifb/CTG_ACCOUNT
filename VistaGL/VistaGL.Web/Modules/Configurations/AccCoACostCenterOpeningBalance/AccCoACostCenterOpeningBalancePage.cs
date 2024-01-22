

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/AccCoACostCenterOpeningBalance", typeof(VistaGL.Configurations.Pages.AccCoACostCenterOpeningBalanceController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccCoACostCenterOpeningBalance"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccCoACostCenterOpeningBalanceRow))]
    public class AccCoACostCenterOpeningBalanceController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccCoACostCenterOpeningBalance/AccCoACostCenterOpeningBalanceIndex.cshtml");
        }
    }
}
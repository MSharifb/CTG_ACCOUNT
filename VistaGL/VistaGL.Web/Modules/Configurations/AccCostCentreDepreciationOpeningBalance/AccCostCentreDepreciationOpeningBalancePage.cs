

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/AccCostCentreDepreciationOpeningBalance", typeof(VistaGL.Configurations.Pages.AccCostCentreDepreciationOpeningBalanceController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccCostCentreDepreciationOpeningBalance"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccCostCentreDepreciationOpeningBalanceRow))]
    public class AccCostCentreDepreciationOpeningBalanceController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccCostCentreDepreciationOpeningBalance/AccCostCentreDepreciationOpeningBalanceIndex.cshtml");
        }
    }
}
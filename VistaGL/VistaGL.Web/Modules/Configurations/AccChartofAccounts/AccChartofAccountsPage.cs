


namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccChartofAccounts"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccChartofAccountsRow))]
    public class AccChartofAccountsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccChartofAccounts/AccChartofAccountsIndex.cshtml");
        }
        public ActionResult Group()
        {
            return View("~/Modules/Configurations/AccChartofAccounts/Group/AccChartofAccountsGroupIndex.cshtml");
        }
        public ActionResult ImportCoA()
        {
            return View("~/Modules/Configurations/AccChartofAccounts/ImportCoA/ImportCoAIndex.cshtml");
        }
    }
}
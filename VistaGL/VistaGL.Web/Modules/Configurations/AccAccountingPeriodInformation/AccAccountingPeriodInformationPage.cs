



namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccAccountingPeriodInformation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccAccountingPeriodInformationRow))]
    public class AccAccountingPeriodInformationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccAccountingPeriodInformation/AccAccountingPeriodInformationIndex.cshtml");
        }
    }
}
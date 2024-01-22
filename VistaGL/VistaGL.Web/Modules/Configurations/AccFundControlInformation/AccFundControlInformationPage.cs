


namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccFundControlInformation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccFundControlInformationRow))]
    public class AccFundControlInformationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccFundControlInformation/AccFundControlInformationIndex.cshtml");
        }
    }
}
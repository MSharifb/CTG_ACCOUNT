



namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccBankInformation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBankInformationRow))]
    public class AccBankInformationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccBankInformation/AccBankInformationIndex.cshtml");
        }
    }
}
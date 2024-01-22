


namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccBankAccountInformation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBankAccountInformationRow))]
    public class AccBankAccountInformationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccBankAccountInformation/AccBankAccountInformationIndex.cshtml");
        }
    }
}
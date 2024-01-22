
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccSetupForBankAdviceLetter"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccSetupForBankAdviceLetterRow))]
    public class AccSetupForBankAdviceLetterController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccSetupForBankAdviceLetter/AccSetupForBankAdviceLetterIndex.cshtml");
        }
    }
}
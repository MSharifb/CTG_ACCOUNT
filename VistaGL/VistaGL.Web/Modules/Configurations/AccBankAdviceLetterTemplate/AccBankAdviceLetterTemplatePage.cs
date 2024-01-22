
namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccBankAdviceLetterTemplate"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBankAdviceLetterTemplateRow))]
    public class AccBankAdviceLetterTemplateController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccBankAdviceLetterTemplate/AccBankAdviceLetterTemplateIndex.cshtml");
        }
    }
}


[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccBankAdviceLetter", typeof(VistaGL.Transaction.Pages.AccBankAdviceLetterController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccBankAdviceLetter"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccChequeRegisterRow))]
    public class AccBankAdviceLetterController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccBankAdviceLetter/AccBankAdviceLetterIndex.cshtml");
        }
    }
}
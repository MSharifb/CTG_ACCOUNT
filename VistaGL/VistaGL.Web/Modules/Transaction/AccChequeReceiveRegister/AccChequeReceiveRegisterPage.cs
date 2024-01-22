


namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccChequeReceiveRegister"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccChequeReceiveRegisterRow))]
    public class AccChequeReceiveRegisterController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccChequeReceiveRegister/AccChequeReceiveRegisterIndex.cshtml");
        }
    }
}
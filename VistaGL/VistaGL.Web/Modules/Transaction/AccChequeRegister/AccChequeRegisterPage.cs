


namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccChequeRegister"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccChequeRegisterRow))]
    public class AccChequeRegisterController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccChequeRegister/AccChequeRegisterIndex.cshtml");
        }
    }
}



namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccBankReconciliationDirect"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBankReconciliationDirectRow))]
    public class AccBankReconciliationDirectController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccBankReconciliationDirect/AccBankReconciliationDirectIndex.cshtml");
        }
    }
}
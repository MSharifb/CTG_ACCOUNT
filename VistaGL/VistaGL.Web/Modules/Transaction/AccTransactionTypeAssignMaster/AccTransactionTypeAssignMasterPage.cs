


namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccTransactionTypeAssignMaster"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccTransactionTypeAssignMasterRow))]
    public class AccTransactionTypeAssignMasterController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccTransactionTypeAssignMaster/AccTransactionTypeAssignMasterIndex.cshtml");
        }
    }
}
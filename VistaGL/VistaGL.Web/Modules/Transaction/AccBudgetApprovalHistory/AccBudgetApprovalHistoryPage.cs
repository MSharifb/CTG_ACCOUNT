
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccBudgetApprovalHistory"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBudgetApprovalHistoryRow))]
    public class AccBudgetApprovalHistoryController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccBudgetApprovalHistory/AccBudgetApprovalHistoryIndex.cshtml");
        }
    }
}
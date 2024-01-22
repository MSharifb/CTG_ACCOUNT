
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccBudgetCreation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBudgetForDepartmentDetailRow))]
    public class AccBudgetCreationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccBudgetCreation/AccBudgetCreationIndex.cshtml");
        }
        public ActionResult Approval()
        {
            return View("~/Modules/Transaction/AccBudgetCreation/BudgetCreationApproval/BudgetCreationApprovalIndex.cshtml");
        }
    }
}
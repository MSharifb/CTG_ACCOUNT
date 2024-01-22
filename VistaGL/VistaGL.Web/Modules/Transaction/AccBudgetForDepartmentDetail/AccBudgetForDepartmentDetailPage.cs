
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccBudgetForDepartmentDetail"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBudgetForDepartmentDetailRow))]
    public class AccBudgetForDepartmentDetailController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccBudgetForDepartmentDetail/AccBudgetForDepartmentDetailIndex.cshtml");
        }
    }
}
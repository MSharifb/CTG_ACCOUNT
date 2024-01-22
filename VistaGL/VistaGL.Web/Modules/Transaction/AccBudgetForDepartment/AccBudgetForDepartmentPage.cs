
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccBudgetForDepartment"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBudgetForDepartmentRow))]
    public class AccBudgetForDepartmentController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccBudgetForDepartment/AccBudgetForDepartmentIndex.cshtml");
        }
    }
}
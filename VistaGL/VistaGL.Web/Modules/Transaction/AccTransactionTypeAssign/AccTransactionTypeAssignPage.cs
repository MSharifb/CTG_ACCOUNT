

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/Assign Chart of Account", typeof(VistaGL.Transaction.Pages.AccTransactionTypeAssignController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccTransactionTypeAssign"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccTransactionTypeAssignRow))]
    public class AccTransactionTypeAssignController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccTransactionTypeAssign/AccTransactionTypeAssignIndex.cshtml");
        }
    }
}
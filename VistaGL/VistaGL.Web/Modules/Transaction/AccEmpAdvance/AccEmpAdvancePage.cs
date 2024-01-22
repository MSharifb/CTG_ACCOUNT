

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccEmpAdvance", typeof(VistaGL.Transaction.Pages.AccEmpAdvanceController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccEmpAdvance"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccEmpAdvanceRow))]
    public class AccEmpAdvanceController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccEmpAdvance/AccEmpAdvanceIndex.cshtml");
        }
    }
}
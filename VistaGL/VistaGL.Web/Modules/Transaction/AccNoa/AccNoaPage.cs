

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccNoa", typeof(VistaGL.Transaction.Pages.AccNoaController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccNoa"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccNoaRow))]
    public class AccNoaController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccNoa/AccNoaIndex.cshtml");
        }
    }
}
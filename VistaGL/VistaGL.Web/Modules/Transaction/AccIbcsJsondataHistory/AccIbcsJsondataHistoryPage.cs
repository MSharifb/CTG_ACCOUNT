
namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccIbcsJsondataHistory"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccIbcsJsondataHistoryRow))]
    public class AccIbcsJsondataHistoryController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccIbcsJsondataHistory/AccIbcsJsondataHistoryIndex.cshtml");
        }
    }
}
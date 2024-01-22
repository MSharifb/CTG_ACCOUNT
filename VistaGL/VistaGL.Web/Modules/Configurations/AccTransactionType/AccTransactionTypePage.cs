


namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccTransactionType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccTransactionTypeRow))]
    public class AccTransactionTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccTransactionType/AccTransactionTypeIndex.cshtml");
        }
    }
}

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccArDoubtfulDebts"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccArDoubtfulDebtsRow))]
    public class AccArDoubtfulDebtsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccArDoubtfulDebts/AccArDoubtfulDebtsIndex.cshtml");
        }
    }
}
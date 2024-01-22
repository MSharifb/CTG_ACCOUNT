


namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccVoucherType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherTypeRow))]
    public class AccVoucherTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccVoucherType/AccVoucherTypeIndex.cshtml");
        }
    }
}
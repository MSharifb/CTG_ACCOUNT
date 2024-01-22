

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/AccVoucherApi", typeof(VistaGL.Configurations.Pages.AccVoucherApiController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccVoucherApi"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherApiRow))]
    public class AccVoucherApiController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccVoucherApi/AccVoucherApiIndex.cshtml");
        }
    }
}
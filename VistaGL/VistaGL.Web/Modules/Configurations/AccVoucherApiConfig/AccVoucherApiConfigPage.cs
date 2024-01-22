

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/AccVoucherApiConfig", typeof(VistaGL.Configurations.Pages.AccVoucherApiConfigController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccVoucherApiConfig"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherApiConfigRow))]
    public class AccVoucherApiConfigController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccVoucherApiConfig/AccVoucherApiConfigIndex.cshtml");
        }
    }
}


[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/AccVoucherApiDetails", typeof(VistaGL.Configurations.Pages.AccVoucherApiDetailsController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccVoucherApiDetails"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherApiDetailsRow))]
    public class AccVoucherApiDetailsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccVoucherApiDetails/AccVoucherApiDetailsIndex.cshtml");
        }
    }
}
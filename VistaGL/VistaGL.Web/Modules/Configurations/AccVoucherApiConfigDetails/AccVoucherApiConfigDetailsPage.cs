

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/AccVoucherApiConfigDetails", typeof(VistaGL.Configurations.Pages.AccVoucherApiConfigDetailsController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccVoucherApiConfigDetails"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherApiConfigDetailsRow))]
    public class AccVoucherApiConfigDetailsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccVoucherApiConfigDetails/AccVoucherApiConfigDetailsIndex.cshtml");
        }
    }
}


//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/AccCommonDescription", typeof(VistaGL.Configurations.Pages.AccCommonDescriptionController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccCommonDescription"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccCommonDescriptionRow))]
    public class AccCommonDescriptionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccCommonDescription/AccCommonDescriptionIndex.cshtml");
        }
    }
}
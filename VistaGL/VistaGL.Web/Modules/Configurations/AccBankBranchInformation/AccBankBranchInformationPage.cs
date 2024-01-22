

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Configurations/Bank Branch Information", typeof(VistaGL.Configurations.Pages.AccBankBranchInformationController))]

namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccBankBranchInformation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccBankBranchInformationRow))]
    public class AccBankBranchInformationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccBankBranchInformation/AccBankBranchInformationIndex.cshtml");
        }
    }
}
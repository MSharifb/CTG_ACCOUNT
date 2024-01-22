


namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccCostCentreOrInstituteInformation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccCostCentreOrInstituteInformationRow))]
    public class AccCostCentreOrInstituteInformationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccCostCentreOrInstituteInformation/AccCostCentreOrInstituteInformationIndex.cshtml");
        }
    }
}
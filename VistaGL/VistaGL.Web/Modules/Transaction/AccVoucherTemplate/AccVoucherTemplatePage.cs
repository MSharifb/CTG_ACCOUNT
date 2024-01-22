


namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccVoucherTemplate"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherTemplateRow))]
    public class AccVoucherTemplateController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccVoucherTemplate/AccVoucherTemplateIndex.cshtml");
        }
    }
}


//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccVoucherDtlAllocation", typeof(VistaGL.Transaction.Pages.AccVoucherDtlAllocationController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccVoucherDtlAllocation"), Route("{action=index}")]
 //   [PageAuthorize(typeof(Entities.AccVoucherDtlAllocationRow))]
    public class AccVoucherDtlAllocationController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccVoucherDtlAllocation/AccVoucherDtlAllocationIndex.cshtml");
        }
    }
}
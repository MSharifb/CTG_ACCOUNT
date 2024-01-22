

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Transaction/AccVoucherDtlBillRef", typeof(VistaGL.Transaction.Pages.AccVoucherDtlBillRefController))]

namespace VistaGL.Transaction.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccVoucherDtlBillRef"), Route("{action=index}")]
  //  [PageAuthorize(typeof(Entities.AccVoucherDtlBillRefRow))]
    public class AccVoucherDtlBillRefController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Transaction/AccVoucherDtlBillRef/AccVoucherDtlBillRefIndex.cshtml");
        }
    }
}
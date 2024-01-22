


namespace VistaGL.Transaction.Pages
{
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Transaction/AccVoucherInformation"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccVoucherInformationRow))]
    public class AccVoucherInformationController : Controller
    {
        public ActionResult Index()
        {
            // if (VType != null)
            // {
            //string g=   TwoLevelCache.GetLocalStoreOnly("Vtype", TimeSpan.Zero, "Vtype", () => {

            //         return VType.Value.ToString();
            //     });
            // }
            // Session["VType"] = VType;
            // string v= TwoLevelCache.get
            return View("~/Modules/Transaction/AccVoucherInformation/AccVoucherInformationIndex.cshtml");
        }

        public ActionResult PaymentVoucher()
        {

            return View("~/Modules/Transaction/AccVoucherInformation/PaymentVoucher/PaymentVoucherIndex.cshtml");
        }

        public ActionResult ReceiptVoucher()
        {

            return View("~/Modules/Transaction/AccVoucherInformation/ReceiptVoucher/ReceiptVoucherIndex.cshtml");
        }

        public ActionResult JournalVoucher()
        {

            return View("~/Modules/Transaction/AccVoucherInformation/JournalVoucher/JournalVoucherIndex.cshtml");
        }

        public ActionResult TransferVoucher()
        {

            return View("~/Modules/Transaction/AccVoucherInformation/TransferVoucher/TransferVoucherIndex.cshtml");
        }

        public ActionResult Approval()
        {

            return View("~/Modules/Transaction/AccVoucherInformation/VoucherApproval/VoucherApprovalIndex.cshtml");
        }

        public ActionResult VoucherAPI()
        {

            return View("~/Modules/Transaction/AccVoucherInformation/VoucherAPI/VoucherAPIIndex.cshtml");
        }

        public ActionResult Payment()
        {

            return View("~/Modules/Transaction/AccVoucherInformation/PaymentVoucher/PaymentIndex.cshtml");
        }

        public ActionResult Receipt()
        {

            return View("~/Modules/Transaction/AccVoucherInformation/ReceiptVoucher/ReceiptIndex.cshtml");
        }
    }
}
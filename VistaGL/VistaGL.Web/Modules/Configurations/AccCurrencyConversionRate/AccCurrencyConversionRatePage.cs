


namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccCurrencyConversionRate"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccCurrencyConversionRateRow))]
    public class AccCurrencyConversionRateController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccCurrencyConversionRate/AccCurrencyConversionRateIndex.cshtml");
        }
    }
}
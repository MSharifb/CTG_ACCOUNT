


namespace VistaGL.Configurations.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configurations/AccCurrencyConversion"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AccCurrencyConversionRow))]
    public class AccCurrencyConversionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Configurations/AccCurrencyConversion/AccCurrencyConversionIndex.cshtml");
        }
    }
}
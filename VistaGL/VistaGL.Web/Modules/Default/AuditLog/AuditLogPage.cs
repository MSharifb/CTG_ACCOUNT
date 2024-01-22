

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Default/AuditLog", typeof(VistaGL.Default.Pages.AuditLogController))]

namespace VistaGL.Default.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Default/AuditLog"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AuditLogRow))]
    public class AuditLogController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Default/AuditLog/AuditLogIndex.cshtml");
        }
    }
}
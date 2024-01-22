
namespace VistaGL.Transaction.Endpoints
{
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.VoucherApprovalRepository;
    using MyRow = Entities.AccVoucherInformationRow;

    [RoutePrefix("Services/Transaction/VoucherApproval"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class VoucherApprovalController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Update(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyRepository().Delete(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository().Retrieve(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyRepository().List(connection, request);
        }

        public CheckIsApproverResponse IsVoucherApprover(IDbConnection connection, ListRequest request)
        {
            return new MyRepository().IsVoucherApprover(connection, request);
        }

        public ListResponse<Repositories.eNextApprover> GetNextApprover(IDbConnection connection, Repositories.eNextApproverListRequest request)
        {
            return new MyRepository().GetNextApprover(connection, request);
        }
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new Serenity.Reporting.DynamicDataReport(data, request.IncludeColumns, typeof(Columns.AccVoucherInformationColumns));
            var bytes = new ReportRepository().Render(report);
            return Serenity.Web.ExcelContentResult.Create(bytes, "VoucherInformation" +
                System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }

        public ListResponse<Repositories.eNextApprover> GetAmountByApprover(IDbConnection connection, Repositories.eNextApproverListRequest request)
        {
            return new MyRepository().GetAmountByApprover(connection, request);
        }
        public ListResponse<Repositories.eNextApprover> GetPostingSendTo(IDbConnection connection, Repositories.eNextApproverListRequest request)
        {
            return new MyRepository().GetPostingSendTo(connection, request);
        }
        public ListResponse<Repositories.eNextApprover> GetRegretList(IDbConnection connection, Repositories.eNextApproverListRequest request)
        {
            return new MyRepository().GetRegretList(connection, request);
        }

    }
}

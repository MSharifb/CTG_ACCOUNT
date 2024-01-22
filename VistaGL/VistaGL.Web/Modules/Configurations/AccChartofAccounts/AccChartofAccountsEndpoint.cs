
namespace VistaGL.Configurations.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Mvc;

    using MyRepository = Repositories.AccChartofAccountsRepository;
    using MyRow = Entities.AccChartofAccountsRow;

    [RoutePrefix("Services/Configurations/AccChartofAccounts"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class AccChartofAccountsController : ServiceEndpoint
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

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new Serenity.Reporting.DynamicDataReport(data, request.IncludeColumns, typeof(Columns.AccChartofAccountsColumns));
            var bytes = new ReportRepository().Render(report);
            return Serenity.Web.ExcelContentResult.Create(bytes, "CoA" +
                System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }

        public SaveCoAListResponse SaveCoAList(IDbConnection connection, SaveCoAListRequest request)
        {
            return new MyRepository().SaveCoAList(connection, request);
        }
    }

    public class SaveCoAListRequest: ServiceRequest
    {
        public List<Transaction.Entities.AccTransactionTypeAssignRow> List { get; set; }
    }

    public class SaveCoAListResponse: ServiceResponse
    {

    }
}

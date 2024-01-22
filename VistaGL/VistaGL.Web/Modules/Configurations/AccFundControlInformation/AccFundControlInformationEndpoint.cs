
namespace VistaGL.Configurations.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using MyRepository = Repositories.AccFundControlInformationRepository;
    using MyRow = Entities.AccFundControlInformationRow;

    [RoutePrefix("Services/Configurations/AccFundControlInformation"), Route("{action}")]
    //  [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    [ConnectionKey(typeof(MyRow))]
    public class AccFundControlInformationController : ServiceEndpoint
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
            var report = new Serenity.Reporting.DynamicDataReport(data, request.IncludeColumns, typeof(Columns.AccFundControlInformationColumns));
            var bytes = new ReportRepository().Render(report);
            return Serenity.Web.ExcelContentResult.Create(bytes, "EntityInfo" +
                System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }

        public RetrieveResponse<MyRow> SetFundControl(IDbConnection connection, RetrieveRequest request)
        {
            var user = Authorization.UserDefinition as UserDefinition;
            user.FundControlInformationId = int.Parse(request.EntityId.ToString());

            //  var request1 = { Criteria: [[MyRow.Fields.Id,], '=', ""] }  as ListRequest;


            var data = new MyRepository().Retrieve(connection, new RetrieveRequest() { EntityId = user.FundControlInformationId }).Entity;

            // var data=connection.List<MyRow>(MyRow.Fields.Id==user.FundControlInformationId);
            user.BaseCurrency = data.CurrencyCurrency;
            user.BaseCurrencyId = data.CurrencyId.Value;
            user.FundControlName=data.FundControlName;

            return new RetrieveResponse<Entities.AccFundControlInformationRow>();

        }

    }
}

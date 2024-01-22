
namespace VistaGL.Transaction.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.AccVoucherDtlBillRefRepository;
    using MyRow = Entities.AccVoucherDtlBillRefRow;

    [RoutePrefix("Services/Transaction/AccVoucherDtlBillRef"), Route("{action}")]
    [ConnectionKey(typeof(MyRow))]
    public class AccVoucherDtlBillRefController : ServiceEndpoint
    {
        //  [HttpPost, AuthorizeCreate(typeof(MyRow))]
        [HttpPost]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Create(uow, request);
        }

        // [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        [HttpPost]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Update(uow, request);
        }

        //  [HttpPost, AuthorizeDelete(typeof(MyRow))]
        [HttpPost]
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
    }
}

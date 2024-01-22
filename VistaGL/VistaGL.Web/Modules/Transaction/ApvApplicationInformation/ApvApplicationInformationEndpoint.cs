
using System.Data;
using System.Web.Mvc;
using Serenity.Data;
using Serenity.Services;
using VistaGL.Transaction.Entities;
using VistaGL.Transaction.Repositories;

namespace VistaGL.Transaction.Endpoints
{
    using MyRepository = ApvApplicationInformationRepository;
    using MyRow = ApvApplicationInformationRow;

    [RoutePrefix("Services/Transaction/ApvApplicationInformation"), Route("{action}")]
    [ConnectionKey(typeof(MyRow))]
    public class ApvApplicationInformationController : ServiceEndpoint
    {
        [HttpPost]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Create(uow, request);
        }

        [HttpPost]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Update(uow, request);
        }

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

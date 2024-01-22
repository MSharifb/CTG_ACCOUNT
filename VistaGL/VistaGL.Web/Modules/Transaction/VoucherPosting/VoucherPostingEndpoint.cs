
namespace VistaGL.Transaction.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;
    using System.Web.Mvc;
    using MyRepository = Repositories.VoucherPostingRepository;
    using MyRow = Entities.AccVoucherInformationRow;

    [RoutePrefix("Services/Transaction/VoucherPosting"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class VoucherPostingController : ServiceEndpoint
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

        public ServiceResponse BulkAction(IUnitOfWork uow, BulkActionRequest request)
        {
            request.CheckNotNull();

            var random = new Random();

            // fail randomly with 3 percent chance
            if (random.Next(100) < 3)
                throw new ValidationError("Failed randomly!");

            var user = (UserDefinition)Authorization.UserDefinition;

            foreach (var x in request.IDs)
            {
                Entities.AccVoucherInformationRow _row = new MyRow();
                _row.Id = x;
                _row.PostedBy = user.EmpId.ToString();
                _row.PostingDate = DateTime.Now;
                _row.PostToLedger = 1;
                new MyRepository().Update(uow,new SaveRequest<MyRow> {EntityId=x, Entity=_row } );
            }

            return new ServiceResponse();
        }
    }

    public class BulkActionRequest : ServiceRequest
    {
        public List<int> IDs { get; set; }
    }
}

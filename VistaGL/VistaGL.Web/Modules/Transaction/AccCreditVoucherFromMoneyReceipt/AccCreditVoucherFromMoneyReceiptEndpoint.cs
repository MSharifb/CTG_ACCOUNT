
namespace VistaGL.Transaction.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.AccCreditVoucherFromMoneyReceiptRepository;
    using MyRow = Entities.AccMoneyReceiptRow;

    [RoutePrefix("Services/Transaction/AccCreditVoucherFromMoneyReceipt"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class AccCreditVoucherFromMoneyReceiptController : ServiceEndpoint
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

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository().Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyRepository().List(connection, request);
        }

        public StringMessageResponse CreateCreditVoucher(CreditVoucherParametersRequest request)
        {
            return new MyRepository().CreateCreditVoucher(request);
        }

        public ServiceResponse BulkAction(IUnitOfWork uow, BulkActionRequest request)
        {
            request.CheckNotNull();

            var random = new Random();

            // fail randomly with 3 percent chance
            if (random.Next(100) < 3)
                throw new ValidationError("Failed randomly!");

            var user = (UserDefinition)Authorization.UserDefinition;

            //Entities.AccMoneyReceiptRow _row;
            //foreach (var x in request.IDs)
            //{
            //    _row = new MyRow();
            //    _row.Id = x;
            //    _row.IsUsed = true;
            //    _row.updatedUserId = user.EmpId.ToString();
            //    _row.updatedUserDate = DateTime.Now;

            //    new MyRepository().Update(uow, new SaveRequest<MyRow>
            //    {
            //        EntityId = x,
            //        Entity = _row
            //    });
            //}

            //new MyRepository().CreateCreditVoucher(request);

            return new ServiceResponse();
        }
    }


    public class CreditVoucherParametersRequest : ServiceRequest
    {
        public List<int> MoneyReceiptIds { get; set; }
        public String Narration { get; set; }
        public DateTime VoucherDate { get; set; }
        public String ReceiveFrom { get; set; }
    }


}

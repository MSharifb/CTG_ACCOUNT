
using Serenity.Web;

namespace VistaGL.Transaction.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Reporting;
    using System.Data;
    using System;
    using System.Web.Mvc;
    using MyRepository = Repositories.BankReconciliationVoucherRepository;
    using MyRow = Entities.AccVoucherDetailsRow;

    [RoutePrefix("Services/Transaction/BankReconciliationVoucher"), Route("{action}")]
    //[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    [ConnectionKey(typeof(MyRow))]
    public class BankReconciliationVoucherController : ServiceEndpoint
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

        // [HttpPost, AuthorizeDelete(typeof(MyRow))]
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

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new DynamicDataReport(data, request.IncludeColumns, typeof(Columns.BankReconciliationVoucherColumns));
            var bytes = new ReportRepository().Render(report);
            var reportName = "BankReconciliationList_";
            return ExcelContentResult.Create(bytes, reportName + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }
    }
}

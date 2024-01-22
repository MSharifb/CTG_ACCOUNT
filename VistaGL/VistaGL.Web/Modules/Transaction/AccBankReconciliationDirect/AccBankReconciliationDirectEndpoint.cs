
using Serenity.Reporting;
using Serenity.Web;

namespace VistaGL.Transaction.Endpoints
{
    using Columns;
    using Entities;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.AccBankReconciliationDirectRepository;
    using MyRow = Entities.AccBankReconciliationDirectRow;

    [RoutePrefix("Services/Transaction/AccBankReconciliationDirect"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class AccBankReconciliationDirectController : ServiceEndpoint
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
            var report = new DynamicDataReport(data, request.IncludeColumns, typeof(Columns.AccBankReconciliationDirectColumns));
            var bytes = new ReportRepository().Render(report);
            var reportName = "BankReconciliation_Direct_List_";
            return ExcelContentResult.Create(bytes, reportName + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }

        //public ServiceResponse BankReconciliationBulkAction(IUnitOfWork uow, BankReconciliationBulkActionRequest request)
        //{
        //    request.CheckNotNull();

        //    var random = new Random();

        //    // fail randomly with 3 percent chance
        //    if (random.Next(100) < 3)
        //        throw new ValidationError("Failed randomly!");

        //    foreach (var x in request.TOBj)
        //    {
        //        AccBankReconciliationDirectRow _row = new AccBankReconciliationDirectRow();
        //        _row.Id =null;
        //        _row.VoucherDetailId = x.voucherDetailId;
        //        _row.VoucherNumber = x.VoucherInformationVoucherNo;
        //        _row.VoucherDate = x.VoucherInformationVoucherDate;
        //        _row.Amount = x.EffectiveValue;
        //        _row.Description = x.Description;
        //        _row.BankAccountInformationId = x.BankAccountInformationId;
        //        _row.ZoneInfoId = 1;
        //        new MyRepository().Create(uow, new SaveRequest<MyRow> { EntityId = x, Entity = _row });


        //    }
        //    return new ServiceResponse();
        //}
    }


}

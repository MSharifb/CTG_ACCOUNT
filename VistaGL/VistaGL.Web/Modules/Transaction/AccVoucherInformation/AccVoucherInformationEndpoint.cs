
namespace VistaGL.Transaction.Endpoints
{
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.AccVoucherInformationRepository;
    using MyRow = Entities.AccVoucherInformationRow;

    [RoutePrefix("Services/Transaction/AccVoucherInformation"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class AccVoucherInformationController : ServiceEndpoint
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


        public GetNewVoucherNoResponse GetNewVoucherNo(IDbConnection connection, GetNewVoucherNoRequest request)
        {
            return new MyRepository().GetNewVoucherNo(connection, request);
        }

        public ListResponse<Repositories.AVP_InitialStep> GetApproverInfoByApplicant(IDbConnection connection, GetApproverInfoByApplicantRequest request)
        {
            return new MyRepository().GetApproverInfoByApplicant(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new Serenity.Reporting.DynamicDataReport(data, request.IncludeColumns, typeof(Columns.AccVoucherInformationColumns));
            var bytes = new ReportRepository().Render(report);
            return Serenity.Web.ExcelContentResult.Create(bytes, "VoucherInformation" +
                System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }

    }

}

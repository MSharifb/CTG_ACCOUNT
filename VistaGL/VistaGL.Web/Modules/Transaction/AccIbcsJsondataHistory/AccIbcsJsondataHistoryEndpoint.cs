
namespace VistaGL.Transaction.Endpoints
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using System.Text;
    using System.Web.Mvc;
    using System.Linq;
    using MyRepository = Repositories.AccIbcsJsondataHistoryRepository;
    using MyRow = Entities.AccIbcsJsondataHistoryRow;
    using System;

    [RoutePrefix("Services/Transaction/AccIbcsJsondataHistory"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class AccIbcsJsondataHistoryController : ServiceEndpoint
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

        [HttpPost]
        public ActionResult ExportFile(IDbConnection connection, RetrieveRequest request)
        {
            RetrieveResponse<MyRow> Response = new MyRepository().Retrieve(connection, request);

            //var dObj = Newtonsoft.Json.JsonConvert.DeserializeObject(Response.Entity.JsonData);
            //var formatedJson = Newtonsoft.Json.JsonConvert.SerializeObject(dObj, Newtonsoft.Json.Formatting.Indented);

            var formatedJson = FormatJson(Response.Entity.JsonData);

            byte[] fileContent = Encoding.ASCII.GetBytes(formatedJson);
            var output = File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet, Response.Entity.Id + ".txt");
            return output;
        }

        private const string INDENT_STRING = "    ";

        static string FormatJson(string json)
        {

            int indentation = 0;
            int quoteCount = 0;
            var result =
                from ch in json
                let quotes = ch == '"' ? quoteCount++ : quoteCount
                let lineBreak = ch == ',' && quotes % 2 == 0 ? ch + Environment.NewLine + String.Concat(Enumerable.Repeat(INDENT_STRING, indentation)) : null
                let openChar = ch == '{' || ch == '[' ? ch + Environment.NewLine + String.Concat(Enumerable.Repeat(INDENT_STRING, ++indentation)) : ch.ToString()
                let closeChar = ch == '}' || ch == ']' ? Environment.NewLine + String.Concat(Enumerable.Repeat(INDENT_STRING, --indentation)) + ch : ch.ToString()
                select lineBreak == null
                            ? openChar.Length > 1
                                ? openChar
                                : closeChar
                            : lineBreak;

            return String.Concat(result);
        }
    }
}

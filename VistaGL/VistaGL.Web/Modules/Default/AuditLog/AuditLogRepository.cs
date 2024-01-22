

namespace VistaGL.Default.Repositories
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Data;
    using MyRow = Entities.AuditLogRow;
    using System.Collections.Generic;
    using Entities;

    public class AuditLogRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler().Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow> { }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }

    [LookupScript("AuditLog.TableName_Lookup", Permission = "?", Expiration = -1)]
    public class TableNameLookup : RowLookupScript<Entities.AuditLogRow>
    {
        public TableNameLookup()
        {
            IdField = TextField = Entities.AuditLogRow.Fields.DBTableName.PropertyName;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            var fld = Entities.AuditLogRow.Fields;
            query.Distinct(true).Select(fld.DBTableName);
        }

        protected override void ApplyOrder(SqlQuery query)
        {

        }
    }

    [LookupScript("AuditLog.ActionName_Lookup", Permission = "?", Expiration = -1)]
    public class ActionNameLookup : RowLookupScript<Entities.AuditLogRow>
    {
        public ActionNameLookup()
        {
            IdField = TextField = Entities.AuditLogRow.Fields.Action.PropertyName;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            var fld = Entities.AuditLogRow.Fields;
            query.Distinct(true).Select(fld.Action);
        }

        protected override void ApplyOrder(SqlQuery query)
        {

        }
    }

}
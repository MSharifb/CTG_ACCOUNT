

namespace VistaGL.Transaction.Repositories
{
    using Entities;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using MyRow = Entities.AccChequeBookRow;

    public class AccChequeBookRepository
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

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            protected override void BeforeSave()
            {
                base.BeforeSave();
                var user = (UserDefinition)Authorization.UserDefinition;
                Row.EntityId = user.FundControlInformationId;
                Row.ZoneInfoId = user.ZoneID;

            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }

        private class MyListHandler : ListRequestHandler<MyRow>
        {
            protected override void PrepareQuery(SqlQuery query)
            {
                base.PrepareQuery(query);
                var user = (UserDefinition)Authorization.UserDefinition;

                if (user.ZoneID != 0 && user.FundControlInformationId != 0)
                {
                    query.Where(fld.ZoneInfoId == user.ZoneID
                        && fld.EntityId == user.FundControlInformationId);
                }
                else
                {
                    throw new Exception("Please select fund control!");
                }
            }
        }
    }

    [LookupScript("Repositories.DemoLookup", Permission = "?")]
    public class DemoLookup: LookupScript
    {
        public DemoLookup()
        {
            this.IdField = "Id";
            this.TextField = "CheckBookName";
            this.getItems = this.GetItems;
        }

        protected virtual IEnumerable<dynamic> GetItems()
        {
            return null;
        }
    }


    [LookupScript("Transaction.AccChequeBook_Lookup", Permission = "?", Expiration = -1)]
    public class AccChequeBookRowRowLookup : RowLookupScript<AccChequeBookRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            //if (Authorization.Username != "admin")
            //{
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = AccChequeBookRow.Fields;
            if (user.FundControlInformationId != 0 && user.ZoneID != 0)
            {
                query.Where(fld.EntityId == user.FundControlInformationId
                    && fld.ZoneInfoId == user.ZoneID);
            }
            else
            {
                throw new Exception("Please select entity!");
            }
            //}
        }
    }

    [LookupScript("Transaction.AccChequeBook_NotFinishedYet_Lookup", Permission = "?", Expiration = -1)]
    public class AccChequeBookRow_NotFinishedYet_Lookup : RowLookupScript<AccChequeBookRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            //if (Authorization.Username != "admin")
            //{
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = AccChequeBookRow.Fields;
            if (user.FundControlInformationId != 0 && user.ZoneID != 0)
            {
                query.Where(fld.EntityId == user.FundControlInformationId
                    && fld.ZoneInfoId == user.ZoneID
                    && fld.HasFinished == 0);
            }
            else
            {
                throw new Exception("Please select entity!");
            }
            //}
        }
    }
}
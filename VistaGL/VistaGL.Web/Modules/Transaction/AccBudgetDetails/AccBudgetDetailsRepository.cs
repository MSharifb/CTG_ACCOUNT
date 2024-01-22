
namespace VistaGL.Transaction.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.AccBudgetDetailsRow;

    public class AccBudgetDetailsRepository
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

    [Serenity.ComponentModel.LookupScript("Transaction.AccBudgetDetails_Lookup", Permission = "?", Expiration = -1)]
    public class AccBudgetDetailsRowLookup : RowLookupScript<Entities.AccBudgetDetailsRow>
    {
        protected override List<Entities.AccBudgetDetailsRow> GetItems()
        {
            var _items = new List<Entities.AccBudgetDetailsRow>();
            var user = (UserDefinition)Authorization.UserDefinition;
            using (var connection = SqlConnections.NewFor<Entities.AccBudgetDetailsRow>())
            {
                var fldCheque = Entities.AccBudgetDetailsRow.Fields.As("fldCheque");
                var queryCheque = new SqlQuery()
                    .Select(fldCheque.BudgetHeadId)
                    .Select(fldCheque.BudgetAmount)
                    .Select(fldCheque.IsCoa)
                    .From(fldCheque)
                    .Where(fldCheque.ZoneInfoId == user.ZoneID
                    && fldCheque.EntityId == user.FundControlInformationId);

                _items = connection.Query<Entities.AccBudgetDetailsRow>(queryCheque).ToList();
            }
            return _items;
        }
    }

}

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
    using MyRow = Entities.AccBudgetRow;

    public class AccBudgetRepository
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

        private class MySaveHandler : SaveRequestHandler<MyRow> {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;
            protected override void ValidateRequest()
            {
                base.ValidateRequest();
                var f = MyRow.Fields;
                if (IsCreate)
                {
                    var d = Connection.TryFirst<MyRow>(f.FinancialYearId == Convert.ToInt32(Row.FinancialYearId) & f.EntityId == Convert.ToInt32(user.FundControlInformationId) & f.ZoneInfoId == Convert.ToInt32(user.ZoneID));
                    if (d != null)
                        throw new ValidationError("Duplicate Financial Year!");
                }
            }
            protected override void BeforeSave()
            {
                base.BeforeSave();
                Row.ZoneInfoId = user.ZoneID;
                Row.EntityId = user.FundControlInformationId;
            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> {
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
                    throw new Exception("select fund control");
                }
            }
        }
    }

    [Serenity.ComponentModel.LookupScript("Transaction.AccBudgetHeads_Lookup", Permission = "?", Expiration = -1)]
    public class AccBudgetHeadsRowLookup : RowLookupScript<Entities.AccBudgetDetailsRow>
    {
        protected override List<Entities.AccBudgetDetailsRow> GetItems()
        {
            var _items = new List<Entities.AccBudgetDetailsRow>(); // base.GetItems();
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = MyRow.Fields;
            using (var connection = SqlConnections.NewFor<Entities.AccBudgetDetailsRow>())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@param_fundcontrolId", user.FundControlInformationId);
                var list = connection.Query<Entities.AccBudgetDetailsRow>("Rpt_SP_ACC_BudgetGroup", param, commandType: CommandType.StoredProcedure).ToList();
                _items = list.Where(x=>x.IsBudgetHead == true).ToList();
            }
            return _items;
        }
    }

}

namespace VistaGL.Transaction.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using MyRow = Entities.AccBudgetCircularRow;

    public class AccBudgetCircularRepository
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
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            protected override void BeforeSave()
            {
                base.BeforeSave();
                Row.FundControlId = user.FundControlInformationId;
            }
            protected override void AfterSave()
            {
                base.AfterSave();
                if (Row.IsActive == true)
                {
                    var strSql = "UPDATE acc_BudgetCircular SET IsActive = 0 WHERE Id <> " + Row.Id + "AND FundControlId = " + Row.FundControlId;
                    Connection.Execute(strSql);
                }
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

                if (user.FundControlInformationId != 0)
                {
                    query.Where(fld.FundControlId == user.FundControlInformationId);
                }
                else
                {
                    throw new Exception("Please Select Entity");
                }
            }
        }
    }
}
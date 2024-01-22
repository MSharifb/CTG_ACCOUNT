
namespace VistaGL.Transaction.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using MyRow = Entities.AccFixedAssetDepreciationRow;

    public class AccFixedAssetDepreciationRepository
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

            protected override void ExecuteSave()
            {
                DynamicParameters param = new DynamicParameters();
                if (Row.ProcessType == "P")
                {
                    param.Add("@FinancialYearId", Row.FinancialYearId);
                    param.Add("@FundControlId", user.FundControlInformationId);
                    param.Add("@UserId", user.Id);
                    var result = Connection.Query<string>("procFixedAssetDepreciation", param, commandType: CommandType.StoredProcedure, commandTimeout: 0);
                    return;
                }
                else if(Row.ProcessType == "RB")
                {
                    param.Add("@FinancialYearId", Row.FinancialYearId);
                    var result = Connection.Query<string>("procFixedAssetDepreciationRollback", param, commandType: CommandType.StoredProcedure);
                    return;
                }
            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}
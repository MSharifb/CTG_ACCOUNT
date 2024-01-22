
namespace VistaGL.Transaction.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Linq;
    using System.Data;
    using MyRow = Entities.AccBudgetForDepartmentRow;

    public class AccBudgetForDepartmentRepository
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

        public ListResponse<Entities.AccBudgetForDepartmentDetailRow> BudgetHeadList(IDbConnection connection, ListRequest request)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            DynamicParameters param = new DynamicParameters();
            param.Add("@param_fundcontrolId", user.FundControlInformationId);
            var list = connection.Query<Entities.AccBudgetForDepartmentDetailRow>("Rpt_SP_ACC_BudgetGroup", param, commandType: CommandType.StoredProcedure).ToList();
            var response = new ListResponse<Entities.AccBudgetForDepartmentDetailRow>();
            response.Entities = list;
            return response;
        }

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            protected override void BeforeSave()
            {
                base.BeforeSave();
                Row.ZoneId = user.ZoneID;

                Row.BudgetCircularFinancialYearId = Connection.Query<Int32>("SELECT FinancialYearId FROM acc_BudgetCircular where Id = " + Row.BudgetCircularId, commandType: CommandType.Text).FirstOrDefault();

                var o = Configurations.Entities.AccAccountingPeriodInformationRow.Fields.As("o");
                var oQuery = new SqlQuery()
                    .Select(o.PeriodStartDate)
                    .Select(o.PeriodEndDate)
                    .From(o)
                    .Where(o.Id == Convert.ToInt32(Row.BudgetCircularFinancialYearId));

                var _finYear = Connection.Query<Configurations.Entities.AccAccountingPeriodInformationRow>(oQuery).FirstOrDefault();

                var iQuery = new SqlQuery()
                    .Select(o.Id)
                    .From(o)
                    .Where(o.PeriodStartDate == Convert.ToDateTime(_finYear.PeriodStartDate).AddYears(1) && o.PeriodEndDate == Convert.ToDateTime(_finYear.PeriodEndDate).AddYears(1));
                var _nextfinYear = Connection.Query<Configurations.Entities.AccAccountingPeriodInformationRow>(iQuery).FirstOrDefault();

                if(_nextfinYear.Id==0 || _nextfinYear.Id == null)
                {
                    throw new Exception("Proposed Budget not found.");
                }
                else if(Row.AccBudgetForDepartmentDetailList != null)
                {
                    Row.AccBudgetForDepartmentDetailList.ForEach(x => x.ProposedBudgetFinancialYearId = _nextfinYear.Id);
                }
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
                    query.Where(fld.ZoneId == user.ZoneID
                        && fld.EntityId == user.FundControlInformationId);
                }
                else
                {
                    throw new Exception("Please select zone and fund control!");
                }
            }
        }
    }
}
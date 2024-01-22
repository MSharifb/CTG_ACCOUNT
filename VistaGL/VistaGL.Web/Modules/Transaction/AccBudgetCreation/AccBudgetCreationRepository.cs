
namespace VistaGL.Transaction.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Linq;

    using MyRow = Entities.AccBudgetForDepartmentDetailRow;

    public class AccBudgetCreationRepository
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
        public ListResponse<FinancialYearNames> GetFinancialYearName(IDbConnection connection, FinancialYearNamesListRequest request)
        {
            var o =Configurations.Entities.AccAccountingPeriodInformationRow.Fields.As("o");
            var oQuery = new SqlQuery()
                .Select(o.YearName)
                .From(o)
                .Where(o.Id == Convert.ToInt32(request.Id));
            var _finYear = connection.Query<Configurations.Entities.AccAccountingPeriodInformationRow>(oQuery).FirstOrDefault();

            var list = connection.Query<FinancialYearNames>(@"SELECT [dbo].[acc_getNextPeriodYearName] (" + request.Id + ") as NextYearName, [dbo].acc_getPreviousPeriodYearName(" + request.Id + ")  as PreviousYearName, "+ "'" + _finYear.YearName +"'"+ " as  CurrentYearName", commandType: CommandType.Text).ToList();

            var response = new ListResponse<FinancialYearNames>();
            response.Entities = list;
            return response;
        }

        public ListResponse<BudgetApproverList> GetBudgetApproverList(IDbConnection connection, BudgetApproverListRequest request)
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            var o = Configurations.Entities.PrmEmploymentInfoRow.Fields.As("o");
            var oQuery = new SqlQuery()
                .Select(o.Id)
                .Select(o.EmpId)
                .Select(o.LookupText)
                .From(o)
                .Where(o.ZoneInfoId == Convert.ToInt32(user.ZoneID) && o.StaffCategoryId == 9 && o.Id != user.EmpId);

            var list = connection.Query<BudgetApproverList>(oQuery).ToList();

            var response = new ListResponse<BudgetApproverList>();

            response.Entities = list;
            return response;
        }

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            protected override void AfterSave()
            {
                base.AfterSave();
                if (Row.BudgetForDepartmentForwardToEmployeeId != null && Row.BudgetForDepartmentApprovalStatusId != null)
                {
                    new AccBudgetForDepartmentRepository()
                                                    .Update(UnitOfWork, new SaveRequest<Entities.AccBudgetForDepartmentRow>
                                                    {
                                                        EntityId = Row.BudgetForDepartmentId,
                                                        Entity = new Entities.AccBudgetForDepartmentRow()
                                                        {
                                                            ForwardToEmployeeId = Row.BudgetForDepartmentForwardToEmployeeId,
                                                            ApprovalStatusId = (ApprovalStatus)Row.BudgetForDepartmentApprovalStatusId
                                                        }
                                                    });
                }

                if(Row.BudgetForDepartmentApprovalStatusId != null && Row.BudgetForDepartmentApprovalStatusId == Convert.ToInt32(ApprovalStatus.Submit))
                {
                    new AccBudgetApprovalHistoryRepository().Create(UnitOfWork, new SaveRequest<Entities.AccBudgetApprovalHistoryRow>
                                                        {
                                                            Entity = new Entities.AccBudgetApprovalHistoryRow()
                                                            {
                                                                BudgetForDepartmentId = Row.BudgetForDepartmentId,
                                                                FromAppoverId = user.EmpId,
                                                                ApprovalStatusId = ApprovalStatus.Submit,
                                                                ToApproverId = Row.BudgetForDepartmentForwardToEmployeeId
                                                            }
                                                        });
                }
            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow>
        {
            UserDefinition user = (UserDefinition)Authorization.UserDefinition;

            protected override void PrepareQuery(SqlQuery query)
            {
                base.PrepareQuery(query);
                query.LeftJoin("[dbo].[acc_ChartofAccounts]", new Alias("JChartofAccounts"), fld.BudgetHeadId == new Criteria("JChartofAccounts", "[id]"));
                query.LeftJoin("[dbo].[acc_Cost_Centre_or_Institute_Information]", new Alias("JCost"), fld.BudgetHeadId == new Criteria("JCost", "[id]"));

                query.Select(@"CASE
                     WHEN  T0.[IsCOA] = 1 THEN JChartofAccounts.accountName
                     WHEN  T0.[IsCostCenter] = 1 THEN JCost.name
                     ELSE  jBudgetGroup.[GroupName]
                    END", "BudgetHeadName");

                query.Select(@"dbo.acc_getActual1stSixMonths("+ fld.BudgetForDepartmentZoneId +","+ fld.CircularFinancialYearId + "," + fld.CircularFundControlId + "," + fld.BudgetHeadId + "," + fld.IsCoa + "," + fld.IsCostCenter + ")", "ActualFirstSixMonths");
                query.Select(@"dbo.acc_getActualDuring(" + fld.BudgetForDepartmentZoneId + "," + fld.CircularFinancialYearId + "," + fld.CircularFundControlId + "," + fld.BudgetHeadId + "," + fld.IsCoa + "," + fld.IsCostCenter + ")", "ActualDuring");
                query.Select(@"jBudgetCircular.IsActive ", "CircularIsActive");
                query.Select(@"jBudgetForDepartment.ForwardToEmployeeId", "BudgetForDepartmentForwardToEmployeeId");

                //int departmentId = Connection.Query<int>("SELECT DivisionId FROM PRM_EmploymentInfo where Id = " + user.EmpId, commandType: CommandType.Text).FirstOrDefault();

                if (user.FundControlInformationId != 0 && user.ZoneID != 0)
                {
                    //query.Where(fld.BudgetForDepartmentDepartmentId == departmentId && fld.BudgetForDepartmentZoneId == user.ZoneID);
                }
                else
                {
                    throw new Exception("Please Select Entity!");
                }
            }
        }
    }
    public class FinancialYearNames
    {
        public string CurrentYearName { get; set; }
        public string PreviousYearName { get; set; }
        public string NextYearName { get; set; }
    }
    public class FinancialYearNamesListRequest : ListRequest
    {
        public int? Id { get; set; }
    }

    public class BudgetApproverList
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string LookupText { get; set; }
    }
    public class BudgetApproverListRequest : ListRequest
    {
        public int ZoneId { get; set; }
        public int DepartmentId { get; set; }
    }

}
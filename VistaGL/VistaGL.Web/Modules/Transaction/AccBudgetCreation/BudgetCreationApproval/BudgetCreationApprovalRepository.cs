
namespace VistaGL.Transaction.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.AccBudgetForDepartmentRow;

    public class BudgetCreationApprovalRepository
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
                new AccBudgetForDepartmentRepository()
                                                .Update(UnitOfWork, new SaveRequest<Entities.AccBudgetForDepartmentRow>
                                                {
                                                    EntityId = Row.Id,
                                                    Entity = new Entities.AccBudgetForDepartmentRow()
                                                    {
                                                        ForwardToEmployeeId = Row.ForwardToEmployeeId,
                                                        ApprovalStatusId = Row.ApprovalStatusId
                                                    }
                                                });

                if (Row.ApprovalStatusId != null)
                {
                    new AccBudgetApprovalHistoryRepository().Create(UnitOfWork, new SaveRequest<Entities.AccBudgetApprovalHistoryRow>
                    {
                        Entity = new Entities.AccBudgetApprovalHistoryRow()
                        {
                            BudgetForDepartmentId = Row.Id,
                            FromAppoverId = user.EmpId,
                            ApprovalStatusId = Row.ApprovalStatusId,
                            ToApproverId = Row.ForwardToEmployeeId
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
                if (user.FundControlInformationId != 0 && user.ZoneID != 0)
                {
                    query.Where(fld.ForwardToEmployeeId == user.EmpId);
                }
                else
                {
                    throw new Exception("Please Select Entity");
                }
            }
        }
    }
}
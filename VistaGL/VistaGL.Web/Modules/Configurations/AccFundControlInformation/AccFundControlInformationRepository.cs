

namespace VistaGL.Configurations.Repositories
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.AccFundControlInformationRow;

    public class AccFundControlInformationRepository
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
                Row.ZoneInfoId = user.ZoneID;
                //if (IsCreate)
                //{
                //    int _DulicateCheck = Connection.Count<MyRow>(fld.AccountName == Row.AccountName && fld.FundControlId == Row.FundControlId.Value && fld.ParentAccountId == Row.ParentAccountId.Value);
                //    if (_DulicateCheck == 0)
                //    {

                //    }
                //    else
                //    {

                //      //  throw new Exception("duplicate found.");
                //    }
                //}
            }
            protected override void ExecuteSave()
            {
                base.ExecuteSave();
                if (IsCreate)
                {

                    //#region INSERT To Chart of Account

                    //var obj = new AccChartofAccountsRow() { FundControlId = Row.Id, AccountName = Row.FundControlName, AccountCode = "0", AccountGroup = "Root", IsControlhead = 1, Level = 0, AccountCodeCount = 0 };
                    //SaveResponse sres = new AccChartofAccountsRepository().Create(UnitOfWork, new SaveRequest<AccChartofAccountsRow> { Entity = obj });

                    //int parentId = Convert.ToInt32(sres.EntityId);
                    //var listCOA = new List<AccChartofAccountsRow>();
                    //listCOA.Add(new AccChartofAccountsRow() { FundControlId = Row.Id, ParentAccountId = parentId, IsControlhead = 1, Level = 1, AccountCode = "1", AccountName = "Property & Assets", AccountGroup = "Assets", AccountCodeCount = 1 });
                    //listCOA.Add(new AccChartofAccountsRow() { FundControlId = Row.Id, ParentAccountId = parentId, IsControlhead = 1, Level = 1, AccountCode = "2", AccountName = "Equity & Liabilities", AccountGroup = "Liabilities", AccountCodeCount = 2 });
                    //listCOA.Add(new AccChartofAccountsRow() { FundControlId = Row.Id, ParentAccountId = parentId, IsControlhead = 1, Level = 1, AccountCode = "3", AccountName = "Income", AccountGroup = "Income", AccountCodeCount = 3 });
                    //listCOA.Add(new AccChartofAccountsRow() { FundControlId = Row.Id, ParentAccountId = parentId, IsControlhead = 1, Level = 1, AccountCode = "4", AccountName = "Expense", AccountGroup = "Expense", AccountCodeCount = 4 });

                    //foreach (var item in listCOA)
                    //{
                    //    new AccChartofAccountsRepository().Create(UnitOfWork, new SaveRequest<AccChartofAccountsRow> { Entity = item });

                    //}
                    //#endregion
                }
            }

            protected override void AfterSave()
            {
                base.AfterSave();

            }

        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow>
        {
            protected override void ExecuteDelete()
            {
                //int[] _level = { 0, 1 };
                //var _COAs =
                //    Connection
                //    .List<AccChartofAccountsRow>(AccChartofAccountsRow.Fields.FundControlId == Row.Id.Value
                //            && AccChartofAccountsRow.Fields.Level.In(_level))
                //    .OrderByDescending(p => p.Id);

                //foreach (var item in _COAs)
                //{
                //    new AccChartofAccountsRepository().Delete(UnitOfWork, new DeleteRequest { EntityId = item.Id });
                //}

                base.ExecuteDelete();




            }
        }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}


namespace VistaGL.Configurations.Repositories
{
    using Entities;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.AccChartofAccountsRow;

    public class AccChartofAccountsRepository
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

        public Endpoints.SaveCoAListResponse SaveCoAList(IDbConnection connection, Endpoints.SaveCoAListRequest request)
        {
            var user = (UserDefinition)Authorization.UserDefinition;

            var accOpeningBalance = new AccOpeningBalanceRow();
            accOpeningBalance.FundControlId = user.FundControlInformationId;
            accOpeningBalance.ZoneId = user.ZoneID;

            accOpeningBalance.OpeningBalance = 0;
            foreach (var Ob in request.List)
            {
                accOpeningBalance.CoAid = Ob.CoaId;

                var _COACode = connection.Count<AccOpeningBalanceRow>(AccOpeningBalanceRow.Fields.FundControlId == user.FundControlInformationId && AccOpeningBalanceRow.Fields.ZoneId == user.ZoneID && AccOpeningBalanceRow.Fields.CoAid == Ob.CoaId.Value);

                if (_COACode == 0)
                {
                    connection.Insert(accOpeningBalance);
                }
                //else
                //{
                //      accOpeningBalance.Id = user.ZoneID;
                //    connection.UpdateById(accOpeningBalance);
                //}
            }
            return new Endpoints.SaveCoAListResponse();
        }

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            protected override void BeforeSave()
            {
                base.BeforeSave();
                var user = (UserDefinition)Authorization.UserDefinition;

                if (Row.UserCode != "")
                {
                    int _DuplicateUserCodeCheck = 0;
                    if (IsCreate)
                        _DuplicateUserCodeCheck = Connection.Count<MyRow>(fld.UserCode == Row.UserCode && fld.FundControlId == Row.FundControlId.Value);
                    else
                        _DuplicateUserCodeCheck = Connection.Count<MyRow>(fld.UserCode == Row.UserCode && fld.FundControlId == Row.FundControlId.Value && fld.Id != Row.Id.Value);

                    if (_DuplicateUserCodeCheck != 0)
                    {
                        throw new ValidationError("Duplicate Account Code found!");
                    }
                }

                int _DuplicateAccountNameCheck = 0;
                if (IsCreate)
                    _DuplicateAccountNameCheck = Connection.Count<MyRow>(fld.AccountName == Row.AccountName && fld.FundControlId == Row.FundControlId.Value);
                else
                    _DuplicateAccountNameCheck = Connection.Count<MyRow>(fld.AccountName == Row.AccountName && fld.FundControlId == Row.FundControlId.Value && fld.Id != Row.Id.Value);

                if (_DuplicateAccountNameCheck != 0)
                {
                    throw new ValidationError("Duplicate Account name found!");
                }

            }

            protected override void ExecuteSave()
            {
                var user = (UserDefinition)Authorization.UserDefinition;
                int _coaid = 0;
                if (!IsCreate)
                {
                    base.ExecuteSave();
                    _coaid = Row.Id.Value;
                }
                else
                {
                    var _DuplicateCheck = new List<MyRow>();
                    if (Row.ParentAccountId.HasValue)
                    {
                        _DuplicateCheck = Connection.List<MyRow>(fld.AccountName == Row.AccountName && fld.FundControlId == Row.FundControlId.Value && fld.ParentAccountId == Row.ParentAccountId.Value);
                    }
                    else
                    {
                        _DuplicateCheck = Connection.List<MyRow>(fld.AccountName == Row.AccountName && fld.FundControlId == Row.FundControlId.Value);
                    }
                    if (_DuplicateCheck.Count == 0)
                    {
                        base.ExecuteSave();
                        _coaid = Row.Id.Value;
                    }
                    else
                    {
                        _coaid = _DuplicateCheck[0].Id.Value;
                        //  throw new Exception("duplicate found.");
                    }
                }

                if (Row.IsControlhead == 0)
                {
                    var accOpeningBalance = new AccOpeningBalanceRow();
                    accOpeningBalance.FundControlId = Row.FundControlId;

                    if (Row.AccOpeningBalance == null)
                        accOpeningBalance.OpeningBalance = 0;
                    else
                        accOpeningBalance.OpeningBalance = Row.AccOpeningBalance;

                    accOpeningBalance.CoAid = _coaid;

                    if (Row.AccOpeningBalanceId == null)
                    {
                        new AccOpeningBalanceRepository().Create(UnitOfWork, new SaveRequest<AccOpeningBalanceRow> { EntityId = Row.AccOpeningBalanceId, Entity = accOpeningBalance });
                    }
                    else
                    {
                        new AccOpeningBalanceRepository().Update(UnitOfWork, new SaveRequest<AccOpeningBalanceRow> { EntityId = Row.AccOpeningBalanceId, Entity = accOpeningBalance });
                    }
                }
            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow>
        {
            protected override void ExecuteDelete()
            {
                var o = AccOpeningBalanceRow.Fields.As("o");
                var oQuery = new SqlQuery()
                    .Select(o.Id)
                    .From(o)
                    .Where(o.CoAid == Row.Id.Value);

                var _COAs = Connection.Query<AccOpeningBalanceRow>(oQuery).ToList();

                //var _COAs = Connection.List<AccOpeningBalanceRow>(AccOpeningBalanceRow.Fields.CoAid == Row.Id.Value);

                foreach (var item in _COAs)
                {
                    new AccOpeningBalanceRepository().Delete(UnitOfWork, new DeleteRequest { EntityId = item.Id });
                }

                base.ExecuteDelete();
                // Connection.DeleteById<AccChartofAccountsRow>("");
            }
        }

        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow>
        {
            protected override void OnReturn()
            {
                base.OnReturn();

                var user = (UserDefinition)Authorization.UserDefinition;

                var o = AccOpeningBalanceRow.Fields.As("o");
                var oQuery = new SqlQuery()
                    .Select(o.Id)
                    .Select(o.CoAid)
                    .Select(o.OpeningBalance)
                    .From(o)
                    .Where(o.CoAid == Row.Id.Value & o.ZoneId == user.ZoneID & o.FundControlId == user.FundControlInformationId);

                var _AccOpeningBalance = Connection.Query<AccOpeningBalanceRow>(oQuery).ToList();

                //var _AccOpeningBalance = Connection.List<AccOpeningBalanceRow>(AccOpeningBalanceRow.Fields.CoAid == Row.Id.Value && AccOpeningBalanceRow.Fields.ZoneId == user.ZoneID && AccOpeningBalanceRow.Fields.FundControlId == Row.FundControlId.Value);
                if (_AccOpeningBalance.Count != 0)
                {
                    Row.AccOpeningBalanceId = _AccOpeningBalance[0].Id;
                    Row.AccOpeningBalance = _AccOpeningBalance[0].OpeningBalance;
                }

                int _usedCoA = 0;
                if (Row.IsControlhead == 1)
                {
                    _usedCoA = Connection.Count<MyRow>(fld.ParentAccountId == Row.Id.Value && fld.FundControlId == Row.FundControlId.Value);
                    if (_usedCoA == 0) { _usedCoA = 0; }
                    else
                    {
                        //    _usedCoA = Connection.Count<Transaction.Entities.AccVoucherDetailsRow>(Transaction.Entities.AccVoucherDetailsRow.Fields.ChartofAccountsId.In(_CoAList) && Transaction.Entities.AccVoucherDetailsRow.Fields.ChartofAccountsFundControlId == Row.FundControlId.Value);
                    }
                }
                else
                {
                    _usedCoA = Connection.Count<Transaction.Entities.AccVoucherDetailsRow>(Transaction.Entities.AccVoucherDetailsRow.Fields.ChartofAccountsId == Row.Id.Value && Transaction.Entities.AccVoucherDetailsRow.Fields.ChartofAccountsFundControlId == Row.FundControlId.Value);
                }
                Row.iSCoAUsed = _usedCoA;

                //foreach (var detail in Row.DetailList)
                //{
                //    //detail.ConListofAnswerList = FlatToHierarchy(detail.ConListofAnswerList);
                //}

            }
        }

        private class MyListHandler : ListRequestHandler<MyRow>
        {
            protected override void PrepareQuery(SqlQuery query)
            {
                base.PrepareQuery(query);
                //if (Authorization.Username != "admin")
                //{
                var user = (UserDefinition)Authorization.UserDefinition;

                if (user.FundControlInformationId != 0)
                {
                    query.Where(fld.FundControlId == user.FundControlInformationId);
                }
                else
                {
                    throw new Exception("Please select fund control!");
                }
                //}
            }

            protected override void OnReturn()
            {
                base.OnReturn();
                var user = (UserDefinition)Authorization.UserDefinition;
                if (user.ZoneID == 0)
                {
                    throw new Exception("select Zone Please!");
                }
                if (user.FundControlInformationId == 0)
                {
                    throw new Exception("select FundControl Information Please!");
                }

                var o = AccOpeningBalanceRow.Fields.As("o");
                var oQuery = new SqlQuery()
                    .Select(o.Id)
                    .Select(o.CoAid)
                    .Select(o.OpeningBalance)
                    .From(o)
                    .Where(o.ZoneId == user.ZoneID & o.FundControlId == user.FundControlInformationId);

                var _AccOpeningBalance = Connection.Query<AccOpeningBalanceRow>(oQuery).ToList();


                // var _AccOpeningBalance = Connection.List<AccOpeningBalanceRow>(AccOpeningBalanceRow.Fields.ZoneId == user.ZoneID && AccOpeningBalanceRow.Fields.FundControlId == user.FundControlInformationId);
                var items = Response.Entities.Where(p => p.IsControlhead == 0).ToList();
                foreach (var item in items)
                {
                    //if (_AccOpeningBalance.Count(o => o.CoAid == item.Id.Value) == 0)
                    //    Response.Entities.Remove(item);

                    //var spd = SubProjectDonorRow.Fields;
                    //var q = new SqlQuery().Dialect(Connection.GetDialect()).Select("DonorId")
                    //    .From(spd)
                    //    .Where(spd.SubProjectId == item.SubProjectId.Value);

                    //// List<int> d = Connection.Query<int>(q).ToList(); //q.List<SubProjectDonorRow>(Connection);

                    //var d = Connection.Query<Int64>(q).ToList();
                    //item.DonorId = d.Select(s => (int)s).ToList();

                }
            }

        }
    }


    [LookupScript("AccChartofAccountWithUserCode_Lookup", Expiration = -1, Permission = "?")]
    public class AccChartofAccountWithUserCodeLookup : Serenity.Web.LookupScript
    {
        public AccChartofAccountWithUserCodeLookup()
        {
            this.IdField = "Id";
            this.TextField = "accountName";
            this.getItems = this.GetItems;
        }

        protected virtual IEnumerable<dynamic> GetItems()
        {
            var items = new List<dynamic>();
            using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
            {
                items = connection.Query<dynamic>("SELECT Id, (UserCode + ' - ' + accountName) as accountName FROM acc_ChartofAccounts WHERE isControlhead = 0 ORDER BY accountName", commandTimeout: 0, commandType: CommandType.Text).ToList();
            }

            return items;
        }
    }

    [Serenity.ComponentModel.LookupScript("Configurations.AccCoABank_Lookup", Permission = "?", Expiration = -1)]
    public class AccChartofAccountsBankRowLookup : Serenity.Web.RowLookupScript<AccChartofAccountsRow>
    {
        protected override List<AccChartofAccountsRow> GetItems()
        {
            var _datas = base.GetItems();

            var binfofld = AccBankAccountInformationRow.Fields;

            var user = (UserDefinition)Authorization.UserDefinition;

            using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
            {
                var _zoneWiseBankAccInfoList = connection
                    .List<AccBankAccountInformationRow>(binfofld.EntityId == user.FundControlInformationId && binfofld.ZoneInfoId == user.ZoneID)
                    .Select(s => s.CoaId);

                _datas = _datas.Where(c => _zoneWiseBankAccInfoList.ToList().Contains(c.Id)).ToList();
            }

            return _datas;
        }
    }


    [Serenity.ComponentModel.LookupScript("Configurations.AccChartofAccountsForVoucher_Lookup", Permission = "?", Expiration = -1)]
    public class AccChartofAccountsForVoucherRowLookup : Serenity.Web.RowLookupScript<AccChartofAccountsRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            var user = (UserDefinition)Authorization.UserDefinition;

            var fld = AccChartofAccountsRow.Fields;

            if (user.FundControlInformationId != 0)
            {
                query.Where(fld.FundControlId == user.FundControlInformationId && fld.IsControlhead == 0);
            }
            else
            {
                throw new Exception("Please select fund control!");
            }
        }
    }


    [Serenity.ComponentModel.LookupScript("Configurations.AccChartofAccounts_Lookup", Permission = "?", Expiration = -1)]
    public class AccChartofAccountsRowLookup : Serenity.Web.RowLookupScript<AccChartofAccountsRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            //if (Authorization.Username != "admin")
            //{
            var user = (UserDefinition)Authorization.UserDefinition;

            var fld = AccChartofAccountsRow.Fields;

            if (user.FundControlInformationId != 0)
            {
                query.Where(fld.FundControlId == user.FundControlInformationId);
            }
            else
            {
                throw new Exception("Please select fund control!");
            }
            //}
        }

        protected override List<AccChartofAccountsRow> GetItems()
        {
            var _datas = base.GetItems();

            var user = (UserDefinition)Authorization.UserDefinition;

            if (user.ZoneID == 0)
            {
                throw new Exception("select Zone Please!");
            }
            if (user.FundControlInformationId == 0)
            {
                throw new Exception("select FundControl Information Please!");
            }

            var _AccOpeningBalance = new List<Entities.AccOpeningBalanceRow>();
            using (var connection = SqlConnections.NewFor<AccOpeningBalanceRow>())
            {
                var o = AccOpeningBalanceRow.Fields.As("o");
                var oQuery = new SqlQuery()
                    .Select(o.Id)
                    .Select(o.CoAid)
                    .Select(o.OpeningBalance)
                    .From(o)
                    .Where(o.ZoneId == user.ZoneID & o.FundControlId == user.FundControlInformationId);

                _AccOpeningBalance = connection.Query<AccOpeningBalanceRow>(oQuery).ToList();

                //_AccOpeningBalance = connection.List<AccOpeningBalanceRow>(AccOpeningBalanceRow.Fields.ZoneId == user.ZoneID && AccOpeningBalanceRow.Fields.FundControlId == user.FundControlInformationId);
            }

            var items = _datas.Where(p => p.IsControlhead == 0).ToList();
            foreach (var item in items)
            {
                if (_AccOpeningBalance.Count(o => o.CoAid == item.Id.Value) == 0)
                    item.OpeningBalance = 0;
                else
                    item.OpeningBalance = _AccOpeningBalance.FirstOrDefault(o => o.CoAid == item.Id.Value).OpeningBalance;
            }

            return _datas;
        }
    }

}
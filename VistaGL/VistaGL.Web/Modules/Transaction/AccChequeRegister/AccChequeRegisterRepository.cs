

namespace VistaGL.Transaction.Repositories
{
    using Entities;
    using Forms;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.AccChequeRegisterRow;

    public class AccChequeRegisterRepository
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

            protected override void ExecuteSave()
            {
                if (Convert.ToBoolean(Row.IsCancelled))
                {
                    Row.IsUsed = false;
                    Row.VoucherInformationId = null;
                }

                base.ExecuteSave();

                if (IsCreate)
                {
                    if (Convert.ToBoolean(Row.IsFinished))
                    {
                        var item = new AccChequeBookRow();
                        item.HasFinished = true;
                        item.Id = Row.ChequeBookId;
                        new AccChequeBookRepository().Update(UnitOfWork, new SaveRequest<AccChequeBookRow> { EntityId = item.Id, Entity = item });
                    }

                }


                if (IsUpdate)
                {
                    if (Convert.ToBoolean(Row.IsCancelled))
                    {
                        var v = AccVoucherInformationRow.Fields.As("v");
                        var vQuery = new SqlQuery()
                            .Select(v.Id)
                            .From(v)
                            .Where(v.ChequeRegisterId == Row.Id.Value);

                        var voucherList = Connection.Query<AccVoucherInformationRow>(vQuery).ToList();
                        //var voucherList = Connection
                        //    .List<AccVoucherInformationRow>()
                        //    .Where(v => v.ChequeRegisterId == Row.Id);
                        foreach (var item in voucherList)
                        {
                            Connection.Execute("UPDATE acc_voucher_information SET chequeRegisterId = NULL WHERE Id = " + item.Id + "");
                        }
                    }
                }

            }

            protected override void BeforeSave()
            {
                base.BeforeSave();

                var user = (UserDefinition)Authorization.UserDefinition;
                Row.ChequeNo = Row.ChequeNoTemp == null ? Row.ChequeNo : Row.ChequeNoTemp;
                Row.IsUsed = Row.IsUsed == null ? false : Row.IsUsed;
                Row.ZoneInfoId = user.ZoneID;
                Row.EntityId = user.FundControlInformationId;
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
                    throw new Exception("select fund control");
                }
            }
        }
    }

    [LookupScript("Transaction.AccChequeRegister_Lookup", Permission = "?", Expiration = -1)]
    public class AccChequeRegisterRowLookup : RowLookupScript<AccChequeRegisterRow>
    {
        protected override List<Entities.AccChequeRegisterRow> GetItems()
        {
            var _items = new List<AccChequeRegisterRow>();// base.GetItems();
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = AccChequeRegisterRow.Fields;

            using (var connection = SqlConnections.NewFor<AccChequeRegisterRow>())
            {
                var fldCheque = AccChequeRegisterRow.Fields.As("fldCheque");
                var queryCheque = new SqlQuery()
                    .Select(fldCheque.Id)
                    .Select(fldCheque.ChequeNo)
                    .From(fldCheque)
                    .Where(fldCheque.ZoneInfoId == user.ZoneID
                    && fldCheque.EntityId == user.FundControlInformationId
                    && fldCheque.IsUsed == 0
                    && fldCheque.IsCancelled == 0);
                _items = connection.Query<AccChequeRegisterRow>(queryCheque).ToList();
            }
            return _items;
        }
    }

    [Serenity.ComponentModel.LookupScript("Transaction.AccChequeRegisterForAdjust_Lookup", Permission = "?", Expiration = -1)]
    public class AccChequeRegisterForAdjustRowLookup : RowLookupScript<AccChequeRegisterRow>
    {
        protected override List<Entities.AccChequeRegisterRow> GetItems()
        {
            var _items = new List<AccChequeRegisterRow>();// base.GetItems();
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = MyRow.Fields;
            using (var connection = SqlConnections.NewFor<AccChequeRegisterRow>())
            {
                var fldCheque = AccChequeRegisterRow.Fields.As("fldCheque");
                var queryCheque = new SqlQuery()
                    .Select(fldCheque.Id)
                    .Select(fldCheque.ChequeNo)
                    .From(fldCheque)
                    .Where(fldCheque.ZoneInfoId == user.ZoneID 
                    && fldCheque.EntityId == user.FundControlInformationId
                    && fldCheque.IsUsed == 1
                    && fldCheque.IsCancelled == 0
                    && fldCheque.isAdjusted == 0);

                _items = connection.Query<AccChequeRegisterRow>(queryCheque).ToList();
            }
            return _items;
        }
    }


    [LookupScript("Transaction.AccChequeRegister_Lookup_ALL", Permission = "?", Expiration = -1)]
    public class AccChequeRegisterRowLookup_ALL : RowLookupScript<AccChequeRegisterRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = AccChequeRegisterRow.Fields;
            if (user.FundControlInformationId != 0)
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
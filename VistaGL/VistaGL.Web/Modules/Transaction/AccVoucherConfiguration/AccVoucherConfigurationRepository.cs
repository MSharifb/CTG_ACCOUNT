

namespace VistaGL.Transaction.Repositories
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using MyRow = Entities.AccVoucherConfigurationRow;

    public class AccVoucherConfigurationRepository
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
                base.ExecuteSave();
                if (IsCreate)
                {

                }
            }

            protected override void BeforeSave()
            {
                base.BeforeSave();
                var user = (UserDefinition)Authorization.UserDefinition;
                Row.ZoneInfoId = user.ZoneID;
                Row.FundControlInformationId = user.FundControlInformationId;

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
                    query.Where(fld.ZoneInfoId == user.ZoneID && fld.FundControlInformationId == user.FundControlInformationId);
                }
                else
                {
                    throw new Exception("select fund control");
                }
            }
        }
    }

    [Serenity.ComponentModel.LookupScript("Transaction.AccVoucherConfiguration_Lookup", Permission = "?", Expiration = -1)]
    public class AccVoucherConfigurationRowLookup : Serenity.Web.RowLookupScript<Entities.AccVoucherConfigurationRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = Entities.AccVoucherConfigurationRow.Fields;
            if (user.FundControlInformationId != 0)
            {
                query.Where(fld.ZoneInfoId == user.ZoneID && fld.FundControlInformationId == user.FundControlInformationId);
            }
            else
            {
                throw new Exception("select fund control");
            }
        }

    }
}
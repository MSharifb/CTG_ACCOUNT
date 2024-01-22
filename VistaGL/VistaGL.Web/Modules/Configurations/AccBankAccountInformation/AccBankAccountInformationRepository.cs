

namespace VistaGL.Configurations.Repositories
{
    using Entities;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Data;
    using MyRow = Entities.AccBankAccountInformationRow;

    public class AccBankAccountInformationRepository
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
                Row.EntityId = user.FundControlInformationId;
                Row.ZoneInfoId = user.ZoneID;
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
                    throw new Exception("Select entity please!");
                }
            }
        }
    }


    [LookupScript("Configurations.AccBankAccountInformation_Lookup", Permission = "?", Expiration = -1)]
    public class AccBankAccountInformationRowRowLookup : RowLookupScript<AccBankAccountInformationRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            //if (Authorization.Username != "admin")
            //{
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = AccBankAccountInformationRow.Fields;
            if (user.FundControlInformationId != 0 && user.ZoneID != 0)
            {
                query.Where(fld.EntityId == user.FundControlInformationId
                    && fld.ZoneInfoId == user.ZoneID);
            }
            else
            {
                throw new Exception("Select entity please!");
            }
            //}
        }

    }
}

namespace VistaGL.Transaction.Repositories
{
    using Endpoints;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using MyRow = Entities.AccMoneyReceiptRow;

    public class AccCreditVoucherFromMoneyReceiptRepository
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

        public StringMessageResponse CreateCreditVoucher(CreditVoucherParametersRequest request)
        {
            request.CheckNotNull();
            var error = false;
            if (error)
                throw new ValidationError("An error occured");

            var user = (UserDefinition)Authorization.UserDefinition;

            var ids = request.MoneyReceiptIds;

            var connection = SqlConnections.NewFor<MyRow>();

            DynamicParameters param = new DynamicParameters();
            param.Add("@voucherDate", Convert.ToDateTime(request.VoucherDate.ToString("dd-MMM-yyyy")));
            param.Add("@voucherNarration", request.Narration);
            param.Add("@voucherReceiveFrom", request.ReceiveFrom);
            param.Add("@moneyReceiptIds", String.Join(",", ids));
            param.Add("@zoneId", user.ZoneID);
            param.Add("@fundControlId", user.FundControlInformationId);
            param.Add("@createUserId", user.Id);
            param.Add("@message", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
            //ACC_AutoPVforVatTaxoucher
            var aList = connection.Query<string>("proc_acc_MoneyReceipt_to_CreditVoucher", param, commandType: CommandType.StoredProcedure);

            var newVoucherNo = param.Get<string>("@message");

            return new StringMessageResponse() { OutoutMessage = newVoucherNo };
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

        private class MySaveHandler : SaveRequestHandler<MyRow> { }
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
                    query.Where(fld.IsUsed == 0
                        && fld.IsCancelled == 0
                        && fld.IsConfirmed == 1
                        && fld.ZoneInfoId == user.ZoneID
                        && fld.EntityId == user.FundControlInformationId);
                }
                else
                {
                    throw new Exception("Select entity please!");
                }
            }
        }
    }
}
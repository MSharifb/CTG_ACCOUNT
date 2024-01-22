

namespace VistaGL.Transaction.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using Modules.Transaction.AccBankReconciliationDirect;
    using MyRow = Entities.AccVoucherDetailsRow;
    using Newtonsoft.Json;

    public class BankReconciliationVoucherRepository
    {

        static int first = 0;
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
        public string IsClearDate = "";
        public static IsClearModel IsclearData = new IsClearModel();
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            //IsClearDate = request.EqualityFilter.ToJson();
            //if (IsClearDate != "")
            //{
            //    IsclearData = JsonConvert.DeserializeObject<IsClearModel>(IsClearDate);
            //}
            return new MyListHandler().Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow> { }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow>
        {
            protected override void PrepareQuery(SqlQuery query)
            {



                try
                {

                    //if (first == 0)
                    //{
                    //    first++;


                    //}
                    //else

                    //{
                        base.PrepareQuery(query);
                        //if (Authorization.Username != "admin")
                        //{
                        var user = (UserDefinition)Authorization.UserDefinition;

                        if (user.FundControlInformationId != 0 && user.ZoneID != 0)
                        {
                            query.Where(
                                fld.VoucherInformationFundControlInformationId == user.FundControlInformationId
                                && fld.VoucherInformationZoneID == user.ZoneID
                                && fld.ChartofAccountsCoaMapping == "BANK"
                                && fld.VoucherInformationPostToLedger == 1
                              
                                //&& fld.IsClearDate == IsclearData.IsClearDate
                                );
                        }
                        else
                        {
                            throw new Exception("Select entity please!");
                        }
                        //}
                    }
             //   }

                catch (Exception ex)

                {

                }
            }
        }
    }
}
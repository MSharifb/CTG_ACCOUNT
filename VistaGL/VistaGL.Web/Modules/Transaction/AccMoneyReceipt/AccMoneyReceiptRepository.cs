

namespace VistaGL.Transaction.Repositories
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.AccMoneyReceiptRow;

    public class AccMoneyReceiptRepository
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

        public GetNewMoneyReceiptResponse GetNewMoneyReceiptNo(IDbConnection connection, GetNewMoneyReceiptNoRequest request)
        {
            var strSql = String.Format("SELECT * FROM [dbo].[fn_AMS_GetNextMoneyReceiptNumber] ({0}, '{1}')", request.ZoneId, request.FundControlId);
            var newMRNo = connection.Query<GetNewMoneyReceiptResponse>(strSql, commandType: CommandType.Text).FirstOrDefault();

            var response = new GetNewMoneyReceiptResponse();
            response.MoneyReceiptNo = newMRNo.MoneyReceiptNo;
            response.MoneyReceiptNumber = newMRNo.MoneyReceiptNumber;
            return response;
        }

        public class BankInfoForChequeReceiveRegister
        {
            public String accountName { get; set; }
            public String accountNumber { get; set; }
            public String bankName { get; set; }
            public String branchName { get; set; }
        }

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            protected override void BeforeSave()
            {
                base.BeforeSave();

                var user = (UserDefinition)Authorization.UserDefinition;
                Row.ZoneInfoId = user.ZoneID;
                Row.EntityId = user.FundControlInformationId;
            }

            protected override void ExecuteSave()
            {

                #region Cheque Receive Register

                String strSql = @"SELECT accountName, accountNumber, bi.bankName, bbi.branchName
                                    FROM acc_BankAccountInformation bai
                                    LEFT JOIN acc_BankInformation bi ON bai.bankId = bi.id
                                    LEFT JOIN acc_BankBranchInformation bbi ON bai.bankBranchId = bbi.id
                                    where bai.COAId = " + Row.AccHeadBankId;

                var baniInfo = Connection.Query<BankInfoForChequeReceiveRegister>(strSql).FirstOrDefault();

                var user = (UserDefinition)Authorization.UserDefinition;

                if (IsCreate)
                {
                    var newChequeReceiveRegister = new AccChequeReceiveRegisterRow()
                    {
                        AccountName = baniInfo?.accountName,
                        AccountNo = baniInfo?.accountNumber,
                        BankName = baniInfo?.bankName,
                        BranchName = baniInfo?.branchName,
                        Amount = Row.Amount,
                        AmountInWords = Row.AmountInWord,
                        ChequeDate = Row.ChequeDate,
                        ChequeNo = Row.ChequeNo,
                        ChequeReceiveDate = Row.ChequeDate,
                        ReceiveType = Row.ChequeType,
                        Remarks = Row.Narration,
                        RecieveFrom = Row.ReceiveFrom,

                        IsCancelled = false,
                        IsUsed = true,
                        ZoneInfoId = user.ZoneID,
                        EntityId = user.FundControlInformationId,
                        createdUserId = user.Id,
                        createdUserDate = DateTime.Now
                    };

                    var newChequeId = Connection.InsertAndGetID(newChequeReceiveRegister);

                    Row.ChequeReceiveRegisterId = newChequeId;
                }
                else
                {
                    var item = new AccChequeReceiveRegisterRow()
                    {
                        Id = Row.ChequeReceiveRegisterId,
                        AccountName = baniInfo?.accountName,
                        AccountNo = baniInfo?.accountNumber,
                        BankName = baniInfo?.bankName,
                        BranchName = baniInfo?.branchName,
                        Amount = Row.Amount,
                        AmountInWords = Row.AmountInWord,
                        ChequeDate = Row.ChequeDate,
                        ChequeNo = Row.ChequeNo,
                        ChequeReceiveDate = Row.ChequeDate,
                        ReceiveType = Row.ChequeType,
                        Remarks = Row.Narration,
                        RecieveFrom = Row.ReceiveFrom,

                        ZoneInfoId = user.ZoneID,
                        EntityId = user.FundControlInformationId,
                        updatedUserId = user.Id,
                        updatedUserDate = DateTime.Now
                    };

                    new AccChequeReceiveRegisterRepository().Update(UnitOfWork,
                        new SaveRequest<AccChequeReceiveRegisterRow> { EntityId = item.Id, Entity = item });
                }

                #endregion

                base.ExecuteSave();
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
                    query.Where(fld.ZoneInfoId == user.ZoneID && fld.EntityId == user.FundControlInformationId);
                }
                else
                {
                    throw new Exception("Select entity please!");
                }
            }
        }
    }
    public class GetNewMoneyReceiptNoRequest : ServiceRequest
    {
        public int FundControlId { get; set; }
        public int ZoneId { get; set; }
    }

    public class GetNewMoneyReceiptResponse : ServiceResponse
    {
        public String MoneyReceiptNo { get; set; }
        public String MoneyReceiptNumber { get; set; }
    }
}
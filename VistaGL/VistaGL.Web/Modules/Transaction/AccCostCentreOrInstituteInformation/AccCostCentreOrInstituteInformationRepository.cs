

namespace VistaGL.Transaction.Repositories
{
    using Configurations.Entities;
    using Entities;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.AccCostCentreOrInstituteInformationRow;

    public class AccCostCentreOrInstituteInformationRepository
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

                Row.IsFixedAssetDevWork = false;
                Row.IsFixedAssetNonDevWork = false;
                if (Row.FixedAssetDevWorkTypeSelector == Convert.ToInt32(FixedAssetDevWorkType.IsFixedAssetDevWork))
                    Row.IsFixedAssetDevWork = true;
                else
                    Row.IsFixedAssetNonDevWork = true;

                if (Row.BudgetGroupId != null && Row.BudgetGroupId > 0)
                {
                    var fld_b = AccBudgetGroupRow.Fields.As("fld_b");
                    var bQuery = new SqlQuery()
                        .Select(fld_b.GroupName)
                        .From(fld_b)
                        .Where(fld_b.Id == Convert.ToInt32(Row.BudgetGroupId));

                    var _budgetGroup = Connection.Query<AccBudgetGroupRow>(bQuery).FirstOrDefault();
                    if(_budgetGroup!=null)
                    {
                        if(_budgetGroup.GroupName.ToLower() == Row.Name.ToLower())
                        {
                            throw new ValidationError("Budget group name and sub-ledget name cannot be same! You can put a dash or dot or semicolon after any of name.");
                        }
                    }
                }

                if (IsCreate)
                {
                    if (Row.ParentId.HasValue)
                    {
                        var c = MyRow.Fields.As("c");

                        var cQuery = new SqlQuery()
                            .Select(c.CodeCount)
                            .From(c)
                            .Where(c.ParentId == Row.ParentId.Value)
                            .OrderBy(c.CodeCount, true);

                        var _Code = Connection.Query<MyRow>(cQuery).FirstOrDefault();
                        //var _Code = Connection.List<MyRow>(fld.ParentId == Row.ParentId.Value).OrderByDescending(p => p.CodeCount).FirstOrDefault();

                        int AccCount = 1;
                        if (_Code != null)
                        {
                            AccCount = _Code.CodeCount.Value + 1;
                        }

                        Row.CodeCount = AccCount;
                        Row.Code = Row.Code + "." + AccCount;
                    }
                    else
                    {
                        Row.CodeCount = 1;
                        Row.Code = "1";
                    }


                    Row.ZoneInfoId = user.ZoneID;
                    Row.EntityId = user.FundControlInformationId;
                }

                if (user.ZoneID != 1)
                {
                    if (user.ZoneID != Row.ZoneInfoId)
                    {
                        throw new ValidationError(String.Format("This subledger is created from {0}! Only {0} can modify this subledger.", Row.ZoneName));
                    }
                }
            }

            protected override void ExecuteSave()
            {
                base.ExecuteSave();

                var user = (UserDefinition)Authorization.UserDefinition;

                // Mergeing subledger
                if (Row.FromCostCenter != null && Row.ToCostCenter != null)
                {
                    if (Row.FromCostCenter > 0 && Row.ToCostCenter > 0)
                    {
                        if (Row.FromCostCenter != Row.ToCostCenter)
                        {
                            var updateCostQuery = "UPDATE acc_voucher_dtl_allocation SET cost_center_id = " + Row.ToCostCenter + " WHERE cost_center_id = " + Row.FromCostCenter;
                            this.UnitOfWork.Connection.Execute(updateCostQuery);

                            updateCostQuery = "UPDATE acc_voucher_information SET costCentreId = " + Row.ToCostCenter + " WHERE costCentreId = " + Row.FromCostCenter;
                            this.UnitOfWork.Connection.Execute(updateCostQuery);

                            updateCostQuery = "UPDATE acc_NOA SET CostCenterId = " + Row.ToCostCenter + " WHERE CostCenterId = " + Row.FromCostCenter;
                            this.UnitOfWork.Connection.Execute(updateCostQuery);
                        }
                    }
                }
                // --

            }
        }

        private class MyDeleteHandler : DeleteRequestHandler<MyRow>
        {
            protected override void OnBeforeDelete()
            {
                base.OnBeforeDelete();

                var user = (UserDefinition)Authorization.UserDefinition;
                if (user.ZoneID != 1)
                {
                    if (user.ZoneID != Row.ZoneInfoId)
                    {
                        throw new ValidationError(String.Format("This subledger is created from {0}! Only {0} can delete this subledger.", Row.ZoneName));
                    }
                }
            }
        }

        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }


    [LookupScript("Transaction.AccCostCentreOrInstituteInformation_Lookup", Permission = "?", Expiration = -1)]
    public class AccCostCentreOrInstituteInformationRowLookup : RowLookupScript<AccCostCentreOrInstituteInformationRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            //if (Authorization.Username != "admin")
            //{
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = MyRow.Fields;
            if (user.FundControlInformationId != 0)
            {
                query.Where(fld.IsActive > 0 && fld.IsInstitute == 0);
            }
            else
            {
                throw new Exception("Please select fund control!");
            }
            //}
        }
    }

    [LookupScript("Transaction.AccCostCentreOrInstituteInformation_LookupForAutoComplete", Permission = "?", Expiration = -1)]
    public class AccCostCentreOrInstituteInformationRowLookupForAutoComplete : RowLookupScript<AccCostCentreOrInstituteInformationRow>
    {
        public AccCostCentreOrInstituteInformationRowLookupForAutoComplete()
        {
            this.IdField = MyRow.Fields.Id.PropertyName;
            this.TextField = MyRow.Fields.Name.PropertyName;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            //if (Authorization.Username != "admin")
            //{
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = MyRow.Fields;
            if (user.FundControlInformationId != 0)
            {
                query.Where(fld.IsActive > 0 && fld.IsInstitute == 0);
            }
            else
            {
                throw new Exception("Please select fund control!");
            }
            //}
        }
    }

    //[LookupScript("Transaction.AccCostCenterWithoutUserCode_Lookup", Permission = "?")]
    //public class AccCostCenterWithoutUserCodeLookup : LookupScript
    //{
    //    public AccCostCenterWithoutUserCodeLookup()
    //    {
    //        this.IdField = "Id";
    //        this.TextField = "name";
    //        this.getItems = this.GetItems;
    //    }

    //    protected virtual IEnumerable<dynamic> GetItems()
    //    {
    //        var items = new List<dynamic>();
    //        using (var connection = SqlConnections.NewFor<MyRow>())
    //        {
    //            items = connection.Query<dynamic>("SELECT Id, name FROM acc_Cost_Centre_or_Institute_Information WHERE isInstitute = 0 ORDER BY name", commandTimeout: 0, commandType: CommandType.Text).ToList();
    //        }

    //        return items;
    //    }
    //}
}
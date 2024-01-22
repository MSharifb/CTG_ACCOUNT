

namespace VistaGL.Configurations.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Web;
    using System;
    using System.Data;
    using MyRow = Entities.PrmDepartmentRow;

    public class PrmDepartmentRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        //..
    }

    [Serenity.ComponentModel.LookupScript("Configurations.DepartmentForBudget_Lookup", Permission = "?", Expiration = -1)]
    public class PrmDepartmentRowLookup : RowLookupScript<Entities.PrmDepartmentRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = Entities.PrmDepartmentRow.Fields;

            if (user.ZoneID != 0)
            {
                query.Where(fld.ZoneInfoId == user.ZoneID);
            }
            else
            {
                throw new Exception("Please select Zone!");
            }
        }
    }
}
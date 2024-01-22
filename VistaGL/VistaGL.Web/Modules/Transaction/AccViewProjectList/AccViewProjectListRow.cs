using VistaGL.Modules.Common;

namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("acc_View_ProjectList"), InstanceName("acc_View_ProjectList"), TwoLevelCached]
    [ReadPermission("Transaction:acc_View_ProjectList:Read")]
    [InsertPermission("Transaction:acc_View_ProjectList:Insert")]
    [UpdatePermission("Transaction:acc_View_ProjectList:Update")]
    [DeletePermission("Transaction:acc_View_ProjectList:Delete")]
    [LookupScript("Transaction.AccViewProjectList", Permission = "?")]
    public sealed class AccViewProjectListRow : Row, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), NotNull]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Name Of Works
        [DisplayName("Name Of Works"), Size(1000), NotNull, QuickSearch]
        public String NameOfWorks { get { return Fields.NameOfWorks[this]; } set { Fields.NameOfWorks[this] = value; } }
        public partial class RowFields { public StringField NameOfWorks; }
        #endregion NameOfWorks

        #region Zone Or Project Id
        [DisplayName("Zone Or Project Id"), NotNull]
        public Int32? ZoneOrProjectId { get { return Fields.ZoneOrProjectId[this]; } set { Fields.ZoneOrProjectId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneOrProjectId; }
        #endregion ZoneOrProjectId


        #region Foreign Fields

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NameOfWorks; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccViewProjectListRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[acc_View_ProjectList]")
            {
                LocalTextPrefix = "Transaction.AccViewProjectList";
            }
        }
        #endregion RowFields
    }

    [Serenity.ComponentModel.LookupScript("Transaction.AccViewProjectList_Lookup", Permission = "?", Expiration = -1)]
    public class AccViewProjectListRowLookup : Serenity.Web.RowLookupScript<AccViewProjectListRow>
    {
        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);
            var user = (UserDefinition)Authorization.UserDefinition;
            var fld = AccViewProjectListRow.Fields;
            if (user.ZoneID != 0)
            {
                query.Where(fld.ZoneOrProjectId == user.ZoneID);
            }
            else
            {
                throw new Exception("select zone");
            }
        }

    }
}

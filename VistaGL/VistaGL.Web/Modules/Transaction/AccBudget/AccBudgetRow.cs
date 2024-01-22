
namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Transaction"), TableName("[dbo].[acc_Budget]")]
    [DisplayName("Budget"), InstanceName("Budget")]
    [ReadPermission("Transaction:AccBudget:Read")]
    [InsertPermission("Transaction:AccBudget:Insert")]
    [UpdatePermission("Transaction:AccBudget:Update")]
    [DeletePermission("Transaction:AccBudget:Delete")]
    [LookupScript("Transaction.AccBudget", Permission = "?")]
    [UniqueConstraint(new string[] { "FinancialYearId", "ZoneInfoId", "EntityId"}, CheckBeforeSave = true, ErrorMessage = "Duplicate Financial Year!")]
    public sealed class AccBudgetRow : NRow, IIdRow, INameRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Financial Year"), NotNull, ForeignKey("[dbo].[acc_Accounting_Period_Information]", "id"), LeftJoin("jFinancialYear"), TextualField("FinancialYearYearName")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow))]
        public Int32? FinancialYearId
        {
            get { return Fields.FinancialYearId[this]; }
            set { Fields.FinancialYearId[this] = value; }
        }

        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        public Int32? ZoneInfoId
        {
            get { return Fields.ZoneInfoId[this]; }
            set { Fields.ZoneInfoId[this] = value; }
        }

        [DisplayName("Entity Id"), NotNull]
        public Int32? EntityId
        {
            get { return Fields.EntityId[this]; }
            set { Fields.EntityId[this] = value; }
        }

        [DisplayName("Is Approved"), NotNull]
        public Boolean? IsApproved
        {
            get { return Fields.IsApproved[this]; }
            set { Fields.IsApproved[this] = value; }
        }

        [DisplayName("Attachment"), QuickSearch]
        public String Attachment
        {
            get { return Fields.Attachment[this]; }
            set { Fields.Attachment[this] = value; }
        }

        #region Budget Details
        [DisplayName("Budget Details"),MasterDetailRelation(foreignKey: "BudgetId", CheckChangesOnUpdate = true), MinSelectLevel(SelectLevel.Auto)]
        public List<AccBudgetDetailsRow> BudgetDetails
        {
            get { return Fields.BudgetDetails[this]; }
            set { Fields.BudgetDetails[this] = value; }
        }
        #endregion

        #region Foreign Key

        [DisplayName("Financial Year"), Expression("jFinancialYear.[yearName]")]
        public String FinancialYearYearName
        {
            get { return Fields.FinancialYearYearName[this]; }
            set { Fields.FinancialYearYearName[this] = value; }
        }

        [DisplayName("Zone Name"), Expression("jZoneInfo.[ZoneName]")]
        public String ZoneInfoZoneName
        {
            get { return Fields.ZoneInfoZoneName[this]; }
            set { Fields.ZoneInfoZoneName[this] = value; }
        }

        #endregion

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.FinancialYearYearName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccBudgetRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {

            public Int32Field Id;

            public Int32Field FinancialYearId;

            public Int32Field ZoneInfoId;

            public Int32Field EntityId;

            public BooleanField IsApproved;

            public StringField Attachment;


            public StringField FinancialYearYearName;

            public StringField ZoneInfoZoneName;

            public RowListField<AccBudgetDetailsRow> BudgetDetails;
        }
    }
}

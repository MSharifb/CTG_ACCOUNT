
namespace VistaGL.Transaction.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("ACCDB"), Module("Transaction"), TableName("[dbo].[acc_BudgetCircular]")]
    [DisplayName("Budget Circular"), InstanceName("Budget Circular")]
    [ReadPermission("Transaction:AccBudgetCircular:Read")]
    [InsertPermission("Transaction:AccBudgetCircular:Insert")]
    [UpdatePermission("Transaction:AccBudgetCircular:Update")]
    [DeletePermission("Transaction:AccBudgetCircular:Delete")]
    [LookupScript("Transaction.AccBudgetCircular", Permission = "?")]
    public sealed class AccBudgetCircularRow : NRow, IIdRow,INameRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Financial Year"), NotNull, ForeignKey("[dbo].[acc_Accounting_Period_Information]", "id"), LeftJoin("jFinancialYear"), TextualField("FinancialYearYearName")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow)),LookupInclude]
        public Int32? FinancialYearId
        {
            get { return Fields.FinancialYearId[this]; }
            set { Fields.FinancialYearId[this] = value; }
        }

        public Int32? FundControlId
        {
            get { return Fields.FundControlId[this]; }
            set { Fields.FundControlId[this] = value; }
        }

        [DisplayName("Is Active"), NotNull, LookupInclude]
        public Boolean? IsActive
        {
            get { return Fields.IsActive[this]; }
            set { Fields.IsActive[this] = value; }
        }



        [DisplayName("Financial Year Is Active"), Expression("jFinancialYear.[isActive]")]
        public Boolean? FinancialYearIsActive
        {
            get { return Fields.FinancialYearIsActive[this]; }
            set { Fields.FinancialYearIsActive[this] = value; }
        }

        [DisplayName("Financial Year Is Closed"), Expression("jFinancialYear.[isClosed]")]
        public Boolean? FinancialYearIsClosed
        {
            get { return Fields.FinancialYearIsClosed[this]; }
            set { Fields.FinancialYearIsClosed[this] = value; }
        }

        [DisplayName("Financial Year Period End Date"), Expression("jFinancialYear.[periodEndDate]")]
        public DateTime? FinancialYearPeriodEndDate
        {
            get { return Fields.FinancialYearPeriodEndDate[this]; }
            set { Fields.FinancialYearPeriodEndDate[this] = value; }
        }

        [DisplayName("Financial Year Period Start Date"), Expression("jFinancialYear.[periodStartDate]")]
        public DateTime? FinancialYearPeriodStartDate
        {
            get { return Fields.FinancialYearPeriodStartDate[this]; }
            set { Fields.FinancialYearPeriodStartDate[this] = value; }
        }

        [DisplayName("Financial Year Name"), Expression("jFinancialYear.[yearName]")]
        public String FinancialYearYearName
        {
            get { return Fields.FinancialYearYearName[this]; }
            set { Fields.FinancialYearYearName[this] = value; }
        }

        [DisplayName("Financial Year Fund Control Information Id"), Expression("jFinancialYear.[fundControlInformation_id]")]
        public Int32? FinancialYearFundControlInformationId
        {
            get { return Fields.FinancialYearFundControlInformationId[this]; }
            set { Fields.FinancialYearFundControlInformationId[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }
        StringField INameRow.NameField
        {
            get { return Fields.FinancialYearYearName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccBudgetCircularRow()
            : base(Fields)
        {
        }

        public class RowFields : NRowFields
        {

            public Int32Field Id;

            public Int32Field FinancialYearId;

            public Int32Field FundControlId;

            public BooleanField IsActive;



            public BooleanField FinancialYearIsActive;

            public BooleanField FinancialYearIsClosed;

            public DateTimeField FinancialYearPeriodEndDate;

            public DateTimeField FinancialYearPeriodStartDate;

            public StringField FinancialYearYearName;

            public Int32Field FinancialYearFundControlInformationId;


		}
    }
}

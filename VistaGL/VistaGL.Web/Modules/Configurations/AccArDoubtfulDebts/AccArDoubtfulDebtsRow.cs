
namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[acc_ARDoubtfulDebts]")]
    [DisplayName("AR Doubtful Debts"), InstanceName("AR Doubtful Debts")]
    [ReadPermission("Configurations:AccArDoubtfulDebts:Read")]
    [InsertPermission("Configurations:AccArDoubtfulDebts:Insert")]
    [UpdatePermission("Configurations:AccArDoubtfulDebts:Update")]
    [DeletePermission("Configurations:AccArDoubtfulDebts:Delete")]
    [LookupScript("Configurations.AccArDoubtfulDebts", Permission = "?", Expiration = -1)]
    public sealed class AccArDoubtfulDebtsRow : Row, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Financial Year"), ForeignKey("[dbo].[acc_Accounting_Period_Information]", "id"), LeftJoin("jFinancialYear"), TextualField("FinancialYearYearName")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow))]
        public Int32? FinancialYearId
        {
            get { return Fields.FinancialYearId[this]; }
            set { Fields.FinancialYearId[this] = value; }
        }

        [DisplayName("Doubtful Debts Amount"), Size(18), Scale(2), NotNull]
        public Decimal? DoubtfulDebtsAmount
        {
            get { return Fields.DoubtfulDebtsAmount[this]; }
            set { Fields.DoubtfulDebtsAmount[this] = value; }
        }
        
       [DisplayName("Receivable Amount"), Size(18), Scale(2)]
        public Decimal? Receivable
        {
            get { return Fields.Receivable[this]; }
            set { Fields.Receivable[this] = value; }
        }
        [DisplayName("Adjusted Amount"), Size(18), Scale(2)]
        public Decimal? Adjusted
        {
            get { return Fields.Adjusted[this]; }
            set { Fields.Adjusted[this] = value; }
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

        [DisplayName("Financial Year"), Expression("jFinancialYear.[yearName]")]
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

        public static readonly RowFields Fields = new RowFields().Init();

        public AccArDoubtfulDebtsRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field Id;

            public Int32Field FinancialYearId;

            public DecimalField DoubtfulDebtsAmount;

            public DecimalField Receivable;

            public DecimalField Adjusted;

            public BooleanField FinancialYearIsActive;

            public BooleanField FinancialYearIsClosed;

            public DateTimeField FinancialYearPeriodEndDate;

            public DateTimeField FinancialYearPeriodStartDate;

            public StringField FinancialYearYearName;

            public Int32Field FinancialYearFundControlInformationId;


		}
    }
}

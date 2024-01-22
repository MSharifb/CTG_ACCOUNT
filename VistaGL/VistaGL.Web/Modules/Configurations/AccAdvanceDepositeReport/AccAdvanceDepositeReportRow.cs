
namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[acc_AdvanceDepositeReport]")]
    [DisplayName("Advance Deposite Report"), InstanceName("Advance Deposite Report")]
    [ReadPermission("Configurations:AccAdvanceDepositeReport:Read")]
    [InsertPermission("Configurations:AccAdvanceDepositeReport:Insert")]
    [UpdatePermission("Configurations:AccAdvanceDepositeReport:Update")]
    [DeletePermission("Configurations:AccAdvanceDepositeReport:Delete")]
    [LookupScript("Configurations.AccAdvanceDepositeReport", Permission = "?", Expiration = -1)]
    public sealed class AccAdvanceDepositeReportRow : Row, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Financial Year"), NotNull, ForeignKey("[dbo].[acc_Accounting_Period_Information]", "id"), LeftJoin("jFinancial"), TextualField("FinancialYearName")]
        [LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow))]
        public Int32? FinancialId
        {
            get { return Fields.FinancialId[this]; }
            set { Fields.FinancialId[this] = value; }
        }

        [DisplayName("Sub-ledger"), NotNull, ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jSubledger"), TextualField("SubledgerCode")]
        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow), FilterField = nameof(Transaction.Entities.AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        public Int32? SubledgerId
        {
            get { return Fields.SubledgerId[this]; }
            set { Fields.SubledgerId[this] = value; }
        }

        [DisplayName("Opening Balance"), Size(18), Scale(2)]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public Decimal? OpeningBalance
        {
            get { return Fields.OpeningBalance[this]; }
            set { Fields.OpeningBalance[this] = value; }
        }

        [DisplayName("During"), Size(18), Scale(2)]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public Decimal? During
        {
            get { return Fields.During[this]; }
            set { Fields.During[this] = value; }
        }



        [DisplayName("Financial Is Active"), Expression("jFinancial.[isActive]")]
        public Boolean? FinancialIsActive
        {
            get { return Fields.FinancialIsActive[this]; }
            set { Fields.FinancialIsActive[this] = value; }
        }

        [DisplayName("Financial Is Closed"), Expression("jFinancial.[isClosed]")]
        public Boolean? FinancialIsClosed
        {
            get { return Fields.FinancialIsClosed[this]; }
            set { Fields.FinancialIsClosed[this] = value; }
        }

        [DisplayName("Financial Period End Date"), Expression("jFinancial.[periodEndDate]")]
        public DateTime? FinancialPeriodEndDate
        {
            get { return Fields.FinancialPeriodEndDate[this]; }
            set { Fields.FinancialPeriodEndDate[this] = value; }
        }

        [DisplayName("Financial Period Start Date"), Expression("jFinancial.[periodStartDate]")]
        public DateTime? FinancialPeriodStartDate
        {
            get { return Fields.FinancialPeriodStartDate[this]; }
            set { Fields.FinancialPeriodStartDate[this] = value; }
        }

        [DisplayName("Financial Year Name"), Expression("jFinancial.[yearName]")]
        public String FinancialYearName
        {
            get { return Fields.FinancialYearName[this]; }
            set { Fields.FinancialYearName[this] = value; }
        }

        [DisplayName("Financial Fund Control Information Id"), Expression("jFinancial.[fundControlInformation_id]")]
        public Int32? FinancialFundControlInformationId
        {
            get { return Fields.FinancialFundControlInformationId[this]; }
            set { Fields.FinancialFundControlInformationId[this] = value; }
        }



        [DisplayName("Subledger Code"), Expression("jSubledger.[code]")]
        public String SubledgerCode
        {
            get { return Fields.SubledgerCode[this]; }
            set { Fields.SubledgerCode[this] = value; }
        }

        [DisplayName("Subledger Code Count"), Expression("jSubledger.[codeCount]")]
        public Int32? SubledgerCodeCount
        {
            get { return Fields.SubledgerCodeCount[this]; }
            set { Fields.SubledgerCodeCount[this] = value; }
        }

        [DisplayName("Subledger User Code"), Expression("jSubledger.[userCode]")]
        public String SubledgerUserCode
        {
            get { return Fields.SubledgerUserCode[this]; }
            set { Fields.SubledgerUserCode[this] = value; }
        }

        [DisplayName("Subledger Is Institute"), Expression("jSubledger.[isInstitute]")]
        public Boolean? SubledgerIsInstitute
        {
            get { return Fields.SubledgerIsInstitute[this]; }
            set { Fields.SubledgerIsInstitute[this] = value; }
        }

        [DisplayName("Sub-ledger"), Expression("jSubledger.[name]")]
        public String SubledgerName
        {
            get { return Fields.SubledgerName[this]; }
            set { Fields.SubledgerName[this] = value; }
        }

        [DisplayName("Subledger Name For Bank Advice Letter"), Expression("jSubledger.[NameForBankAdviceLetter]")]
        public String SubledgerNameForBankAdviceLetter
        {
            get { return Fields.SubledgerNameForBankAdviceLetter[this]; }
            set { Fields.SubledgerNameForBankAdviceLetter[this] = value; }
        }

        [DisplayName("Subledger Pa Ammount"), Expression("jSubledger.[paAmmount]")]
        public Decimal? SubledgerPaAmmount
        {
            get { return Fields.SubledgerPaAmmount[this]; }
            set { Fields.SubledgerPaAmmount[this] = value; }
        }

        [DisplayName("Subledger Remarks"), Expression("jSubledger.[remarks]")]
        public String SubledgerRemarks
        {
            get { return Fields.SubledgerRemarks[this]; }
            set { Fields.SubledgerRemarks[this] = value; }
        }

        [DisplayName("Subledger Parent Id"), Expression("jSubledger.[parentId]")]
        public Int32? SubledgerParentId
        {
            get { return Fields.SubledgerParentId[this]; }
            set { Fields.SubledgerParentId[this] = value; }
        }

        [DisplayName("Subledger Cost Center Type Id"), Expression("jSubledger.[CostCenterTypeId]")]
        public Int32? SubledgerCostCenterTypeId
        {
            get { return Fields.SubledgerCostCenterTypeId[this]; }
            set { Fields.SubledgerCostCenterTypeId[this] = value; }
        }

        [DisplayName("Subledger Emp Id"), Expression("jSubledger.[empId]")]
        public Int32? SubledgerEmpId
        {
            get { return Fields.SubledgerEmpId[this]; }
            set { Fields.SubledgerEmpId[this] = value; }
        }

        [DisplayName("Subledger Is Active"), Expression("jSubledger.[IsActive]")]
        public Boolean? SubledgerIsActive
        {
            get { return Fields.SubledgerIsActive[this]; }
            set { Fields.SubledgerIsActive[this] = value; }
        }

        [DisplayName("Subledger Entity Id"), Expression("jSubledger.[entityId]")]
        public Int32? SubledgerEntityId
        {
            get { return Fields.SubledgerEntityId[this]; }
            set { Fields.SubledgerEntityId[this] = value; }
        }

        [DisplayName("Subledger Zone Info Id"), Expression("jSubledger.[ZoneInfoId]")]
        public Int32? SubledgerZoneInfoId
        {
            get { return Fields.SubledgerZoneInfoId[this]; }
            set { Fields.SubledgerZoneInfoId[this] = value; }
        }

        [DisplayName("Subledger Is Budget Head"), Expression("jSubledger.[isBudgetHead]")]
        public Boolean? SubledgerIsBudgetHead
        {
            get { return Fields.SubledgerIsBudgetHead[this]; }
            set { Fields.SubledgerIsBudgetHead[this] = value; }
        }

        [DisplayName("Subledger Budget Group Id"), Expression("jSubledger.[BudgetGroupId]")]
        public Int32? SubledgerBudgetGroupId
        {
            get { return Fields.SubledgerBudgetGroupId[this]; }
            set { Fields.SubledgerBudgetGroupId[this] = value; }
        }

        [DisplayName("Subledger Is Fixed Asset Head"), Expression("jSubledger.[IsFixedAssetHead]")]
        public Boolean? SubledgerIsFixedAssetHead
        {
            get { return Fields.SubledgerIsFixedAssetHead[this]; }
            set { Fields.SubledgerIsFixedAssetHead[this] = value; }
        }

        [DisplayName("Subledger Is Fixed Asset Dev Work"), Expression("jSubledger.[IsFixedAssetDevWork]")]
        public Boolean? SubledgerIsFixedAssetDevWork
        {
            get { return Fields.SubledgerIsFixedAssetDevWork[this]; }
            set { Fields.SubledgerIsFixedAssetDevWork[this] = value; }
        }

        [DisplayName("Subledger Is Fixed Asset Non Dev Work"), Expression("jSubledger.[IsFixedAssetNonDevWork]")]
        public Boolean? SubledgerIsFixedAssetNonDevWork
        {
            get { return Fields.SubledgerIsFixedAssetNonDevWork[this]; }
            set { Fields.SubledgerIsFixedAssetNonDevWork[this] = value; }
        }

        [DisplayName("Subledger Depreciation Rate"), Expression("jSubledger.[DepreciationRate]")]
        public Decimal? SubledgerDepreciationRate
        {
            get { return Fields.SubledgerDepreciationRate[this]; }
            set { Fields.SubledgerDepreciationRate[this] = value; }
        }

        [DisplayName("Subledger Budget Code"), Expression("jSubledger.[BudgetCode]")]
        public String SubledgerBudgetCode
        {
            get { return Fields.SubledgerBudgetCode[this]; }
            set { Fields.SubledgerBudgetCode[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccAdvanceDepositeReportRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field Id;

            public Int32Field FinancialId;

            public Int32Field SubledgerId;

            public DecimalField OpeningBalance;

            public DecimalField During;



            public BooleanField FinancialIsActive;

            public BooleanField FinancialIsClosed;

            public DateTimeField FinancialPeriodEndDate;

            public DateTimeField FinancialPeriodStartDate;

            public StringField FinancialYearName;

            public Int32Field FinancialFundControlInformationId;



            public StringField SubledgerCode;

            public Int32Field SubledgerCodeCount;

            public StringField SubledgerUserCode;

            public BooleanField SubledgerIsInstitute;

            public StringField SubledgerName;

            public StringField SubledgerNameForBankAdviceLetter;

            public DecimalField SubledgerPaAmmount;

            public StringField SubledgerRemarks;

            public Int32Field SubledgerParentId;

            public Int32Field SubledgerCostCenterTypeId;

            public Int32Field SubledgerEmpId;

            public BooleanField SubledgerIsActive;

            public Int32Field SubledgerEntityId;

            public Int32Field SubledgerZoneInfoId;

            public BooleanField SubledgerIsBudgetHead;

            public Int32Field SubledgerBudgetGroupId;

            public BooleanField SubledgerIsFixedAssetHead;

            public BooleanField SubledgerIsFixedAssetDevWork;

            public BooleanField SubledgerIsFixedAssetNonDevWork;

            public DecimalField SubledgerDepreciationRate;

            public StringField SubledgerBudgetCode;


		}
    }
}

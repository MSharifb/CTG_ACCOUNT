using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Sub-Ledger Opening Balance"), InstanceName("Sub-Ledger Opening Balance"), TwoLevelCached]
    [ReadPermission("Configurations:AccCoACostCenterOpeningBalance:Read")]
    [InsertPermission("Configurations:AccCoACostCenterOpeningBalance:Insert")]
    [UpdatePermission("Configurations:AccCoACostCenterOpeningBalance:Update")]
    [DeletePermission("Configurations:AccCoACostCenterOpeningBalance:Delete")]
    [LookupScript("Configurations.AccCoACostCenterOpeningBalance", Permission = "?")]
    public sealed class AccCoACostCenterOpeningBalanceRow : NRow, IIdRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Co Aid
        [DisplayName("Account Head"), Column("CoAID"), NotNull, ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoAid"), TextualField("CoAidAccountCode")]
        ////[LookupEditor(typeof(Configurations.Entities.AccChartofAccountsRow), InplaceAdd = false)]
        public Int32? CoAid { get { return Fields.CoAid[this]; } set { Fields.CoAid[this] = value; } }
        public partial class RowFields { public Int32Field CoAid; }
        #endregion CoAid

        #region Cost Center
        [DisplayName("Sub-Ledger"), NotNull, ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jCostCenter"), TextualField("CostCenterCode")]
        [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow), InplaceAdd = false)]
        public Int32? CostCenterId { get { return Fields.CostCenterId[this]; } set { Fields.CostCenterId[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterId; }
        #endregion CostCenterId

        #region Cost Center Opening Balance - DEBIT
        [DisplayName("Sub-Ledger Opening Balance(Debit)"), NotNull]
        public Decimal? OBDebit { get { return Fields.OBDebit[this]; } set { Fields.OBDebit[this] = value; } }
        public partial class RowFields { public DecimalField OBDebit; }
        #endregion OBDebit

        #region Cost Center Opening Balance - CREDIT
        [DisplayName("Sub-Ledger Opening Balance(Credit)"), NotNull]
        public Decimal? OBCredit { get { return Fields.OBCredit[this]; } set { Fields.OBCredit[this] = value; } }
        public partial class RowFields { public DecimalField OBCredit; }
        #endregion OBCredit

        #region Zone
        [DisplayName("Zone"), Column("ZoneID"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZone"), TextualField("ZoneZoneName")]
        [LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow), InplaceAdd = true)]
        public Int32? ZoneId { get { return Fields.ZoneId[this]; } set { Fields.ZoneId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneId; }
        #endregion ZoneId

        #region Fund Control
        [DisplayName("Fund Control"), Column("FundControlID"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControl"), TextualField("FundControlCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow), InplaceAdd = true)]
        public Int32? FundControlId { get { return Fields.FundControlId[this]; } set { Fields.FundControlId[this] = value; } }
        public partial class RowFields { public Int32Field FundControlId; }
        #endregion FundControlId


        #region Foreign Fields

        [DisplayName("Co Aid Account Code"), Expression("jCoAid.[accountCode]")]
        public String CoAidAccountCode { get { return Fields.CoAidAccountCode[this]; } set { Fields.CoAidAccountCode[this] = value; } }
        public partial class RowFields { public StringField CoAidAccountCode; }


        [DisplayName("Co Aid Account Code Count"), Expression("jCoAid.[accountCodeCount]")]
        public Int32? CoAidAccountCodeCount { get { return Fields.CoAidAccountCodeCount[this]; } set { Fields.CoAidAccountCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CoAidAccountCodeCount; }


        [DisplayName("Account Group"), Expression("jCoAid.[accountGroup]")]
        public String CoAidAccountGroup { get { return Fields.CoAidAccountGroup[this]; } set { Fields.CoAidAccountGroup[this] = value; } }
        public partial class RowFields { public StringField CoAidAccountGroup; }


        [DisplayName("Account Head"), Expression("jCoAid.[accountName]"), QuickSearch(SearchType.Contains)]
        public String CoAidAccountName { get { return Fields.CoAidAccountName[this]; } set { Fields.CoAidAccountName[this] = value; } }
        public partial class RowFields { public StringField CoAidAccountName; }


        [DisplayName("Co Aid Opening Balance"), Expression("jCoAid.[openingBalance]")]
        public Double? CoAidOpeningBalance { get { return Fields.CoAidOpeningBalance[this]; } set { Fields.CoAidOpeningBalance[this] = value; } }
        public partial class RowFields { public DoubleField CoAidOpeningBalance; }


        [DisplayName("Co Aid Remarks"), Expression("jCoAid.[remarks]")]
        public String CoAidRemarks { get { return Fields.CoAidRemarks[this]; } set { Fields.CoAidRemarks[this] = value; } }
        public partial class RowFields { public StringField CoAidRemarks; }


        [DisplayName("Co Aid Fund Control Id"), Expression("jCoAid.[fundControlId]")]
        public Int32? CoAidFundControlId { get { return Fields.CoAidFundControlId[this]; } set { Fields.CoAidFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoAidFundControlId; }


        [DisplayName("Co Aid Parent Account Id"), Expression("jCoAid.[parentAccountId]")]
        public Int32? CoAidParentAccountId { get { return Fields.CoAidParentAccountId[this]; } set { Fields.CoAidParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoAidParentAccountId; }



        [DisplayName("Co Aid User Code"), Expression("jCoAid.[UserCode]")]
        public String CoAidUserCode { get { return Fields.CoAidUserCode[this]; } set { Fields.CoAidUserCode[this] = value; } }
        public partial class RowFields { public StringField CoAidUserCode; }


        [DisplayName("Co Aid Noa Acc Type Id"), Expression("jCoAid.[NoaAccTypeId]")]
        public Int32? CoAidNoaAccTypeId { get { return Fields.CoAidNoaAccTypeId[this]; } set { Fields.CoAidNoaAccTypeId[this] = value; } }
        public partial class RowFields { public Int32Field CoAidNoaAccTypeId; }


        [DisplayName("Cost Center Code"), Expression("jCostCenter.[code]")]
        public String CostCenterCode { get { return Fields.CostCenterCode[this]; } set { Fields.CostCenterCode[this] = value; } }
        public partial class RowFields { public StringField CostCenterCode; }


        [DisplayName("Cost Center Code Count"), Expression("jCostCenter.[codeCount]")]
        public Int32? CostCenterCodeCount { get { return Fields.CostCenterCodeCount[this]; } set { Fields.CostCenterCodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterCodeCount; }


        [DisplayName("Cost Center User Code"), Expression("jCostCenter.[userCode]")]
        public String CostCenterUserCode { get { return Fields.CostCenterUserCode[this]; } set { Fields.CostCenterUserCode[this] = value; } }
        public partial class RowFields { public StringField CostCenterUserCode; }


        [DisplayName("Cost Center Is Institute"), Expression("jCostCenter.[isInstitute]")]
        public Boolean? CostCenterIsInstitute { get { return Fields.CostCenterIsInstitute[this]; } set { Fields.CostCenterIsInstitute[this] = value; } }
        public partial class RowFields { public BooleanField CostCenterIsInstitute; }


        [DisplayName("Sub-Ledger Name"), Expression("jCostCenter.[name]"), QuickSearch(SearchType.Contains)]
        public String CostCenterName { get { return Fields.CostCenterName[this]; } set { Fields.CostCenterName[this] = value; } }
        public partial class RowFields { public StringField CostCenterName; }


        [DisplayName("Cost Center Remarks"), Expression("jCostCenter.[remarks]")]
        public String CostCenterRemarks { get { return Fields.CostCenterRemarks[this]; } set { Fields.CostCenterRemarks[this] = value; } }
        public partial class RowFields { public StringField CostCenterRemarks; }


        [DisplayName("Cost Center Parent Id"), Expression("jCostCenter.[parentId]")]
        public Int32? CostCenterParentId { get { return Fields.CostCenterParentId[this]; } set { Fields.CostCenterParentId[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterParentId; }


        [DisplayName("Cost Center Entity Id"), Expression("jCostCenter.[entityId]")]
        public Int32? CostCenterEntityId { get { return Fields.CostCenterEntityId[this]; } set { Fields.CostCenterEntityId[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterEntityId; }


        [DisplayName("Cost Center Cost Center Type Id"), Expression("jCostCenter.[CostCenterTypeId]")]
        public Int32? CostCenterCostCenterTypeId { get { return Fields.CostCenterCostCenterTypeId[this]; } set { Fields.CostCenterCostCenterTypeId[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterCostCenterTypeId; }


        [DisplayName("Cost Center Is Active"), Expression("jCostCenter.[IsActive]")]
        public Boolean? CostCenterIsActive { get { return Fields.CostCenterIsActive[this]; } set { Fields.CostCenterIsActive[this] = value; } }
        public partial class RowFields { public BooleanField CostCenterIsActive; }


        [DisplayName("Zone Zone Name"), Expression("jZone.[ZoneName]")]
        public String ZoneZoneName { get { return Fields.ZoneZoneName[this]; } set { Fields.ZoneZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneZoneName; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccCoACostCenterOpeningBalanceRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public const string TableName = "[dbo].[acc_CoA_CostCenterOpeningBalance]";

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_CoA_CostCenterOpeningBalance]")
            {
                LocalTextPrefix = "Configurations.AccCoACostCenterOpeningBalance";
            }
        }
        #endregion RowFields
    }
}

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

    [ConnectionKey("ACCDB"), DisplayName("Sub Ledger"), InstanceName("Sub Ledger"), TwoLevelCached]
    [ReadPermission("Transaction:AccCostCentreOrInstituteInformation:Read")]
    [InsertPermission("Transaction:AccCostCentreOrInstituteInformation:Insert")]
    [UpdatePermission("Transaction:AccCostCentreOrInstituteInformation:Update")]
    [DeletePermission("Transaction:AccCostCentreOrInstituteInformation:Delete")]
    [LookupScript("Transaction.AccCostCentreOrInstituteInformation", Permission = "?", Expiration = -1)]
    public sealed class AccCostCentreOrInstituteInformationRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity, LookupInclude]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        [DisplayName("Account Code"), NotMapped]
        public String AccountCodeClient { get { return Fields.AccountCodeClient[this]; } set { Fields.AccountCodeClient[this] = value; } }
        public partial class RowFields { public StringField AccountCodeClient; }

        #region Code
        [DisplayName("System Code"), Column("code"), Size(150)]
        public String Code { get { return Fields.Code[this]; } set { Fields.Code[this] = value; } }
        public partial class RowFields { public StringField Code; }
        #endregion Code

        #region Code Count
        [DisplayName("Code Count"), Column("codeCount")]
        public Int32? CodeCount { get { return Fields.CodeCount[this]; } set { Fields.CodeCount[this] = value; } }
        public partial class RowFields { public Int32Field CodeCount; }
        #endregion Code

        #region User Code
        [DisplayName("Code"), Column("userCode"), Size(150), QuickSearch, NotNull, Unique]
        public String UserCode { get { return Fields.UserCode[this]; } set { Fields.UserCode[this] = value; } }
        public partial class RowFields { public StringField UserCode; }
        #endregion UserCode

        #region Is Group
        [DisplayName("Is Parent?"), Column("isInstitute"), NotNull, LookupInclude]
        public Boolean? IsInstitute { get { return Fields.IsInstitute[this]; } set { Fields.IsInstitute[this] = value; } }
        public partial class RowFields { public BooleanField IsInstitute; }
        #endregion IsInstitute


        #region Name for Bank Advice Letter
        [DisplayName("Name for Bank Advice"), Column("NameForBankAdviceLetter"), LookupInclude, MinSelectLevel(SelectLevel.List)]
        public String NameForBankAdviceLetter { get { return Fields.NameForBankAdviceLetter[this]; } set { Fields.NameForBankAdviceLetter[this] = value; } }
        public partial class RowFields { public StringField NameForBankAdviceLetter; }
        #endregion Name

        #region Sub Ledger
        [DisplayName("Sub Ledger"), Column("name"), NotNull, Unique, QuickSearch, LookupInclude, MinSelectLevel(SelectLevel.List)]
        public String Name { get { return Fields.Name[this]; } set { Fields.Name[this] = value; } }
        public partial class RowFields { public StringField Name; }
        #endregion Name

        #region Pa Ammount
        [DisplayName("Pa Ammount"), Column("paAmmount")]
        public Decimal? PaAmmount { get { return Fields.PaAmmount[this]; } set { Fields.PaAmmount[this] = value; } }
        public partial class RowFields { public DecimalField PaAmmount; }
        #endregion PaAmmount

        #region Remarks
        [DisplayName("Remarks"), Column("remarks"), Size(300)]
        public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
        public partial class RowFields { public StringField Remarks; }
        #endregion Remarks

        #region Sub Ledger Group
        [DisplayName("Parent Group"), Column("parentId"), ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jParent"), TextualField("ParentCode")]
        [LookupEditor(typeof(AccCostCentreOrInstituteInformationRow),
            FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = true), LookupInclude]
        //[LookupEditor("Transaction.AccCostCentreOrInstituteInformation_Lookup",
        //    FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = true, CascadeFrom = "CostCenterTypeId"), LookupInclude]
        public Int32? ParentId { get { return Fields.ParentId[this]; } set { Fields.ParentId[this] = value; } }
        public partial class RowFields { public Int32Field ParentId; }
        #endregion ParentId


        #region Sub Ledger Type
        [DisplayName("Sub Ledger Type"), NotNull, ForeignKey("[dbo].[acc_CostCenterType]", "id"), LeftJoin("jCostCenterType"), TextualField("CostCenterType")]
        [LookupEditor(typeof(Configurations.Entities.AccCostCenterTypeRow)), LookupInclude]
        public Int32? CostCenterTypeId { get { return Fields.CostCenterTypeId[this]; } set { Fields.CostCenterTypeId[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterTypeId; }
        #endregion CostCenterTypeId

        #region Emp
        //   [DisplayName("Employee"), Column("empId"), ForeignKey("[dbo].[PRM_EmploymentInfo]", "Id"), LeftJoin("jEmp"), TextualField("EmpEmpId")]
        [DisplayName("Employee"), Column("empId")]
        [LookupEditor(typeof(Configurations.Entities.PrmEmploymentInfoRow))]
        public Int32? EmpId { get { return Fields.EmpId[this]; } set { Fields.EmpId[this] = value; } }
        public partial class RowFields { public Int32Field EmpId; }
        #endregion EmpId

        #region Is Active
        [DisplayName("Is Active"), Column("IsActive"), LookupInclude, DefaultValue(1)]
        public Boolean? IsActive { get { return Fields.IsActive[this]; } set { Fields.IsActive[this] = value; } }
        public partial class RowFields { public BooleanField IsActive; }
        #endregion IsActive

        #region Total Voucher Detail Allocations
        [DisplayName("Total Voucher Allocation"), Expression("(SELECT COUNT(Id) AS TotalVoucherDtlAlo FROM acc_voucher_dtl_allocation WHERE cost_center_id=T0.Id)")]
        public Int64? TotalVoucherDtlAlo { get { return Fields.TotalVoucherDtlAlo[this]; } set { Fields.TotalVoucherDtlAlo[this] = value; } }
        public partial class RowFields { public Int64Field TotalVoucherDtlAlo; }
        #endregion TotalVDA


        #region Zone
        [DisplayName("Zone"), Column("ZoneInfoId"), NotNull, ForeignKey("[dbo].[prm_ZoneInfo]", "id"), LeftJoin("jZone"), TextualField("ZoneName")]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region Entity
        [DisplayName("Entity"), Column("entityId"), NotNull, ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jEntity"), TextualField("EntityCode")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow)), LookupInclude]
        public Int32? EntityId { get { return Fields.EntityId[this]; } set { Fields.EntityId[this] = value; } }
        public partial class RowFields { public Int32Field EntityId; }
        #endregion EntityId

        #region Is Budget Head
        [DisplayName("Is Budget Head?"), Column("isBudgetHead"), LookupInclude]
        public Int16? IsBudgetHead { get { return Fields.IsBudgetHead[this]; } set { Fields.IsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field IsBudgetHead; }
        #endregion IsBudgetHead

        #region BudgetGroupId
        [DisplayName("Budget Group")]
        [LookupEditor("Configurations.AccBudgetGroup"), LookupInclude]
        public Int32? BudgetGroupId { get { return Fields.BudgetGroupId[this]; } set { Fields.BudgetGroupId[this] = value; } }
        public partial class RowFields { public Int32Field BudgetGroupId; }
        #endregion BudgetGroupId

        #region Budget Code
        [DisplayName("Budget Code"), Column("BudgetCode"), Size(50)]
        public String BudgetCode { get { return Fields.BudgetCode[this]; } set { Fields.BudgetCode[this] = value; } }
        public partial class RowFields { public StringField BudgetCode; }
        #endregion BudgetCode

        [DisplayName("Title Name"), Expression("T0.userCode + ' - ' + T0.name")]
        public String LookupText { get { return Fields.LookupText[this]; } set { Fields.LookupText[this] = value; } }
        public partial class RowFields { public StringField LookupText; }


        #region From CostCenter
        [NotMapped]
        public Int32? FromCostCenter { get { return Fields.FromCostCenter[this]; } set { Fields.FromCostCenter[this] = value; } }
        public partial class RowFields { public Int32Field FromCostCenter; }
        #endregion FromCostCenter

        #region To CostCenter
        [NotMapped]
        public Int32? ToCostCenter { get { return Fields.ToCostCenter[this]; } set { Fields.ToCostCenter[this] = value; } }
        public partial class RowFields { public Int32Field ToCostCenter; }
        #endregion ToCostCenter


        #region Is Fixed Asset Head
        [DisplayName("Is Fixed Asset Head?"), Column("IsFixedAssetHead"), LookupInclude, DefaultValue(0)]
        public Boolean? IsFixedAssetHead { get { return Fields.IsFixedAssetHead[this]; } set { Fields.IsFixedAssetHead[this] = value; } }
        public partial class RowFields { public BooleanField IsFixedAssetHead; }
        #endregion IsFixedAssetHead

        #region Is Fixed Asset for Development Work
        [DisplayName("Is Fixed Asset for Development Work?"), Column("IsFixedAssetDevWork"), LookupInclude, DefaultValue(0)]
        public Boolean? IsFixedAssetDevWork { get { return Fields.IsFixedAssetDevWork[this]; } set { Fields.IsFixedAssetDevWork[this] = value; } }
        public partial class RowFields { public BooleanField IsFixedAssetDevWork; }
        #endregion IsFixedAssetDevWork

        #region Is Fixed Asset for Non-Development Work
        [DisplayName("Is Fixed Asset for Non-Development Work?"), Column("IsFixedAssetNonDevWork"), LookupInclude, DefaultValue(0)]
        public Boolean? IsFixedAssetNonDevWork { get { return Fields.IsFixedAssetNonDevWork[this]; } set { Fields.IsFixedAssetNonDevWork[this] = value; } }
        public partial class RowFields { public BooleanField IsFixedAssetNonDevWork; }
        #endregion IsFixedAssetHead

        #region Depreciation Rate
        [DisplayName("Depreciation Rate"), Column("DepreciationRate")]
        public Decimal? DepreciationRate { get { return Fields.DepreciationRate[this]; } set { Fields.DepreciationRate[this] = value; } }
        public partial class RowFields { public DecimalField DepreciationRate; }
        #endregion DepreciationRate

        #region Fixed Asset Dev Work Type Selector
        [NotMapped, DisplayName("Fixed Asset Dev. Work Type")]
        public Int16? FixedAssetDevWorkTypeSelector { get { return Fields.FixedAssetDevWorkTypeSelector[this]; } set { Fields.FixedAssetDevWorkTypeSelector[this] = value; } }
        public partial class RowFields { public Int16Field FixedAssetDevWorkTypeSelector; }
        #endregion FixedAssetDevWorkTypeSelector

        #region Foreign Fields

        [DisplayName("Parent Code"), Expression("jParent.[code]")]
        public String ParentCode { get { return Fields.ParentCode[this]; } set { Fields.ParentCode[this] = value; } }
        public partial class RowFields { public StringField ParentCode; }


        [DisplayName("Parent Is Institute"), Expression("jParent.[isInstitute]")]
        public Boolean? ParentIsInstitute { get { return Fields.ParentIsInstitute[this]; } set { Fields.ParentIsInstitute[this] = value; } }
        public partial class RowFields { public BooleanField ParentIsInstitute; }


        [DisplayName("Parent Group"), Expression("jParent.[name]"), QuickSearch]
        public String ParentName { get { return Fields.ParentName[this]; } set { Fields.ParentName[this] = value; } }
        public partial class RowFields { public StringField ParentName; }


        [DisplayName("Parent Pa Ammount"), Expression("jParent.[paAmmount]")]
        public Double? ParentPaAmmount { get { return Fields.ParentPaAmmount[this]; } set { Fields.ParentPaAmmount[this] = value; } }
        public partial class RowFields { public DoubleField ParentPaAmmount; }


        [DisplayName("Parent Remarks"), Expression("jParent.[remarks]")]
        public String ParentRemarks { get { return Fields.ParentRemarks[this]; } set { Fields.ParentRemarks[this] = value; } }
        public partial class RowFields { public StringField ParentRemarks; }


        [DisplayName("Parent Parent Id"), Expression("jParent.[parentId]")]
        public Int32? ParentParentId { get { return Fields.ParentParentId[this]; } set { Fields.ParentParentId[this] = value; } }
        public partial class RowFields { public Int32Field ParentParentId; }


        [DisplayName("Parent Entity Id"), Expression("jParent.[entityId]")]
        public Int32? ParentEntityId { get { return Fields.ParentEntityId[this]; } set { Fields.ParentEntityId[this] = value; } }
        public partial class RowFields { public Int32Field ParentEntityId; }


        [DisplayName("Parent Sub Ledger Type Id"), Expression("jParent.[CostCenterTypeId]")]
        public Int32? ParentCostCenterTypeId { get { return Fields.ParentCostCenterTypeId[this]; } set { Fields.ParentCostCenterTypeId[this] = value; } }
        public partial class RowFields { public Int32Field ParentCostCenterTypeId; }


        [DisplayName("Entity Code"), Expression("jEntity.[code]")]
        public String EntityCode { get { return Fields.EntityCode[this]; } set { Fields.EntityCode[this] = value; } }
        public partial class RowFields { public StringField EntityCode; }


        [DisplayName("Entity Fund Control Name"), Expression("jEntity.[fundControlName]")]
        public String EntityFundControlName { get { return Fields.EntityFundControlName[this]; } set { Fields.EntityFundControlName[this] = value; } }
        public partial class RowFields { public StringField EntityFundControlName; }


        [DisplayName("Entity Remarks"), Expression("jEntity.[remarks]")]
        public String EntityRemarks { get { return Fields.EntityRemarks[this]; } set { Fields.EntityRemarks[this] = value; } }
        public partial class RowFields { public StringField EntityRemarks; }


        [DisplayName("Sub Ledger Type"), Expression("jCostCenterType.[costCenterType]")]
        public String CostCenterType { get { return Fields.CostCenterType[this]; } set { Fields.CostCenterType[this] = value; } }
        public partial class RowFields { public StringField CostCenterType; }


        [DisplayName("Sub Ledger Type Sort Order"), Expression("jCostCenterType.[sortOrder]")]
        public Int32? CostCenterTypeSortOrder { get { return Fields.CostCenterTypeSortOrder[this]; } set { Fields.CostCenterTypeSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterTypeSortOrder; }


        [DisplayName("Created by Zone Name"), Expression("jZone.[ZoneName]")]
        public String ZoneName { get { return Fields.ZoneName[this]; } set { Fields.ZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneName; }

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.LookupText; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccCostCentreOrInstituteInformationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_Cost_Centre_or_Institute_Information]")
            {
                LocalTextPrefix = "Transaction.AccCostCentreOrInstituteInformation";
            }
        }
        #endregion RowFields
    }
}

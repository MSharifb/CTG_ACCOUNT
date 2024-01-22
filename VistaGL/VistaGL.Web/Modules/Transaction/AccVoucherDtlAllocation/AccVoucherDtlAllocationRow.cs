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

    [ConnectionKey("ACCDB"), DisplayName("Sub Ledger Allocation"), InstanceName("Sub Ledger Allocation"), TwoLevelCached]
    //[ReadPermission("Transaction:acc_voucher_dtl_allocation:Read")]
    //[InsertPermission("Transaction:acc_voucher_dtl_allocation:Insert")]
    //[UpdatePermission("Transaction:acc_voucher_dtl_allocation:Update")]
    //[DeletePermission("Transaction:acc_voucher_dtl_allocation:Delete")]
    [LookupScript("Transaction.AccVoucherDtlAllocationRow", Permission = "?")]
    public sealed class AccVoucherDtlAllocationRow : NRow, IIdRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int64? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int64Field Id; }
        #endregion Id

        #region Amount
        [DisplayName("Amount"), Column("amount")]
        public Decimal? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DecimalField Amount; }
        #endregion Amount

        #region Sub Ledger

        [DisplayName("Sub Ledger Type"), Expression("jCostCenter.[CostCenterTypeId]")]
        [LookupEditor(typeof(Configurations.Entities.AccCostCenterTypeRow))]
        [MinSelectLevel(SelectLevel.Always)]
        public Int32? CostCenterTypeId { get { return Fields.CostCenterTypeId[this]; } set { Fields.CostCenterTypeId[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterTypeId; }

        [DisplayName("Sub Ledger Group"), Expression("jCostCenter.[parentId]")]
        [LookupEditor("Transaction.AccCostCentreOrInstituteInformation_Lookup",
       FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = true, CascadeFrom = "CostCenterTypeId")]
        [MinSelectLevel(SelectLevel.Always)]
        public Int32? CostCenterParentId { get { return Fields.CostCenterParentId[this]; } set { Fields.CostCenterParentId[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterParentId; }


        [DisplayName("Sub Ledger"), Column("cost_center_id"), NotNull, ForeignKey("[dbo].[acc_Cost_Centre_or_Institute_Information]", "id"), LeftJoin("jCostCenter"), TextualField("CostCenterCode")]
        //  [LookupEditor(typeof(Transaction.Entities.AccCostCentreOrInstituteInformationRow))]
        [LookupEditor("Transaction.AccCostCentreOrInstituteInformation_Lookup",
            FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute),
            FilterValue = false)]//, CascadeFrom = "CostCenterParentId", CascadeField ="ParentId"

        public Int32? CostCenterId { get { return Fields.CostCenterId[this]; } set { Fields.CostCenterId[this] = value; } }
        public partial class RowFields { public Int32Field CostCenterId; }




        #endregion CostCenterId

        #region Voucher Detail
        [DisplayName("Voucher Detail"), Column("voucherDetailId"), NotNull, ForeignKey("[dbo].[acc_voucher_details]", "id"), LeftJoin("jVoucherDetail"), TextualField("VoucherDetailDescription")]
        //   [LookupEditor(typeof(Transaction.Entities.AccVoucherDetailsRow), InplaceAdd = true)]
        public Int64? VoucherDetailId { get { return Fields.VoucherDetailId[this]; } set { Fields.VoucherDetailId[this] = value; } }
        public partial class RowFields { public Int64Field VoucherDetailId; }
        #endregion VoucherDetailId

        #region DebitAmount
        [DisplayName("Debit Amount"), Column("debitAmount")]
        public Decimal? DebitAmount { get { return Fields.DebitAmount[this]; } set { Fields.DebitAmount[this] = value; } }
        public partial class RowFields { public DecimalField DebitAmount; }
        #endregion DebitAmount

        #region CreditAmount
        [DisplayName("Credit Amount"), Column("creditAmount")]
        public Decimal? CreditAmount { get { return Fields.CreditAmount[this]; } set { Fields.CreditAmount[this] = value; } }
        public partial class RowFields { public DecimalField CreditAmount; }
        #endregion CreditAmount

        #region Adjusted Voucher Id
        [Column("AdjustedChequeRegisterId"), ForeignKey("[dbo].[acc_ChequeRegister]", "id"), LeftJoin("jAdjustedVoucher"), TextualField("AdjustedVoucher"), LookupInclude]
        [DisplayName("Adjusted with"),NotMapped]
        public Int64? AdjustedChequeRegisterId { get { return Fields.AdjustedChequeRegisterId[this]; } set { Fields.AdjustedChequeRegisterId[this] = value; } }
        public partial class RowFields { public Int64Field AdjustedChequeRegisterId; }
        #endregion Adjusted Voucher Id

        #region Foreign Fields

        [DisplayName("Sub Ledger Code"), Expression("jCostCenter.[code]")]
        public String CostCenterCode { get { return Fields.CostCenterCode[this]; } set { Fields.CostCenterCode[this] = value; } }
        public partial class RowFields { public StringField CostCenterCode; }

        [DisplayName("User Code"), Expression("jCostCenter.[UserCode]")]
        [MinSelectLevel(SelectLevel.List)]
        public String CostCenterUserCode { get { return Fields.CostCenterUserCode[this]; } set { Fields.CostCenterUserCode[this] = value; } }
        public partial class RowFields { public StringField CostCenterUserCode; }


        //[DisplayName("Sub Ledger Is Institute"), Expression("jCostCenter.[isInstitute]")]
        //public Int16? CostCenterIsInstitute { get { return Fields.CostCenterIsInstitute[this]; } set { Fields.CostCenterIsInstitute[this] = value; } }
        //public partial class RowFields { public Int16Field CostCenterIsInstitute; }


        [DisplayName("Sub Ledger"), Expression("jCostCenter.[name]")]
        [MinSelectLevel(SelectLevel.List)]
        public String CostCenterName { get { return Fields.CostCenterName[this]; } set { Fields.CostCenterName[this] = value; } }
        public partial class RowFields { public StringField CostCenterName; }


        //[DisplayName("Sub Ledger Remarks"), Expression("jCostCenter.[remarks]")]
        //public String CostCenterRemarks { get { return Fields.CostCenterRemarks[this]; } set { Fields.CostCenterRemarks[this] = value; } }
        //public partial class RowFields { public StringField CostCenterRemarks; }


        //[DisplayName("Sub Ledger Entity Id"), Expression("jCostCenter.[entityId]")]
        //public Int32? CostCenterEntityId { get { return Fields.CostCenterEntityId[this]; } set { Fields.CostCenterEntityId[this] = value; } }
        //public partial class RowFields { public Int32Field CostCenterEntityId; }


        //[DisplayName("Voucher Detail Credit Amount"), Expression("jVoucherDetail.[creditAmount]")]
        //public Decimal? VoucherDetailCreditAmount { get { return Fields.VoucherDetailCreditAmount[this]; } set { Fields.VoucherDetailCreditAmount[this] = value; } }
        //public partial class RowFields { public DecimalField VoucherDetailCreditAmount; }


        //[DisplayName("Voucher Detail Debit Amount"), Expression("jVoucherDetail.[debitAmount]")]
        //public Decimal? VoucherDetailDebitAmount { get { return Fields.VoucherDetailDebitAmount[this]; } set { Fields.VoucherDetailDebitAmount[this] = value; } }
        //public partial class RowFields { public DecimalField VoucherDetailDebitAmount; }


        //[DisplayName("Voucher Detail Description"), Expression("jVoucherDetail.[description]")]
        //public String VoucherDetailDescription { get { return Fields.VoucherDetailDescription[this]; } set { Fields.VoucherDetailDescription[this] = value; } }
        //public partial class RowFields { public StringField VoucherDetailDescription; }


        //[DisplayName("Voucher Detail Is Payor Receive Head"), Expression("jVoucherDetail.[isPayorReceiveHead]")]
        //public Int16? VoucherDetailIsPayorReceiveHead { get { return Fields.VoucherDetailIsPayorReceiveHead[this]; } set { Fields.VoucherDetailIsPayorReceiveHead[this] = value; } }
        //public partial class RowFields { public Int16Field VoucherDetailIsPayorReceiveHead; }


        //[DisplayName("Voucher Detail Chartof Accounts Id"), Expression("jVoucherDetail.[chartofAccountsId]")]
        //public Int32? VoucherDetailChartofAccountsId { get { return Fields.VoucherDetailChartofAccountsId[this]; } set { Fields.VoucherDetailChartofAccountsId[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherDetailChartofAccountsId; }


        //[DisplayName("Voucher Detail Voucher Information Id"), Expression("jVoucherDetail.[voucherInformationId]")]
        //public Int32? VoucherDetailVoucherInformationId { get { return Fields.VoucherDetailVoucherInformationId[this]; } set { Fields.VoucherDetailVoucherInformationId[this] = value; } }
        //public partial class RowFields { public Int32Field VoucherDetailVoucherInformationId; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccVoucherDtlAllocationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_voucher_dtl_allocation]")
            {
                LocalTextPrefix = "Transaction.AccVoucherDtlAllocation";
            }
        }
        #endregion RowFields
    }
}

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

    [ConnectionKey("ACCDB"), DisplayName("Employee Advance"), InstanceName("Employee Advance"), TwoLevelCached]
    [ReadPermission("Transaction:AccEmpAdvance:Read")]
    [InsertPermission("Transaction:AccEmpAdvance:Insert")]
    [UpdatePermission("Transaction:AccEmpAdvance:Update")]
    [DeletePermission("Transaction:AccEmpAdvance:Delete")]
    [LookupScript("Transaction.AccEmpAdvanceRow")]
    public sealed class AccEmpAdvanceRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Emp
        [DisplayName("Employee"), Column("empId"), ForeignKey("[dbo].[PRM_EmploymentInfo]", "Id"), LeftJoin("jEmp"), TextualField("EmpEmpId")]
        [LookupEditor(typeof(Configurations.Entities.PrmEmploymentInfoRow))]
        public Int32? EmpId { get { return Fields.EmpId[this]; } set { Fields.EmpId[this] = value; } }
        public partial class RowFields { public Int32Field EmpId; }
        #endregion EmpId

        #region Transaction Mode
        [DisplayName("Transaction Mode"), Size(50), QuickSearch]
        public String TransactionMode { get { return Fields.TransactionMode[this]; } set { Fields.TransactionMode[this] = value; } }
        public partial class RowFields { public StringField TransactionMode; }
        #endregion TransactionMode

        #region Co A
        [DisplayName("Chart of Accounts"), ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoA"), TextualField("CoAAccountCode")]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup")]
        public Int32? CoAId { get { return Fields.CoAId[this]; } set { Fields.CoAId[this] = value; } }
        public partial class RowFields { public Int32Field CoAId; }
        #endregion CoAId

        #region Cheque Register
        [DisplayName("Cheque No."), ForeignKey("[dbo].[acc_ChequeRegister]", "id"), LeftJoin("jChequeRegister"), TextualField("ChequeRegisterAmountInWords")]
        [LookupEditor("Transaction.AccChequeRegister_Lookup")]
        public Int64? ChequeRegisterId { get { return Fields.ChequeRegisterId[this]; } set { Fields.ChequeRegisterId[this] = value; } }
        public partial class RowFields { public Int64Field ChequeRegisterId; }
        #endregion ChequeRegisterId

        #region Amount
        [DisplayName("Amount")]
        public Decimal? Amount { get { return Fields.Amount[this]; } set { Fields.Amount[this] = value; } }
        public partial class RowFields { public DecimalField Amount; }
        #endregion Amount

        #region RemainAmount
        [DisplayName("Remaining Amount")]
        public Decimal? RemainAmount { get { return Fields.RemainAmount[this]; } set { Fields.RemainAmount[this] = value; } }
        public partial class RowFields { public DecimalField RemainAmount; }
        #endregion RemainAmount

        #region Status
        [DisplayName("Status")]
        public Int32? Status { get { return Fields.Status[this]; } set { Fields.Status[this] = value; } }
        public partial class RowFields { public Int32Field Status; }
        #endregion Status

        #region Zone Id
        [DisplayName("Zone Id")]
        public Int32? ZoneId { get { return Fields.ZoneId[this]; } set { Fields.ZoneId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneId; }
        #endregion ZoneId

        #region Narration
        [DisplayName("Narration"), Column("Narration"), Size(500), NotNull]
        public String Narration { get { return Fields.Narration[this]; } set { Fields.Narration[this] = value; } }
        public partial class RowFields { public StringField Narration; }
        #endregion Narration
        #region Co A2
        [DisplayName("Chart of Accounts"), Column("CoAId2")]
            [ForeignKey("[dbo].[acc_ChartofAccounts]", "id"), LeftJoin("jCoA2"), TextualField("CoA2AccountCode")]

        [LookupEditor("Configurations.AccChartofAccounts_Lookup")]
        public Int32? CoAId2 { get { return Fields.CoAId2[this]; } set { Fields.CoAId2[this] = value; } }
        public partial class RowFields { public Int32Field CoAId2; }
        #endregion CoAId2
        #region Foreign Fields

        [DisplayName("Emp Id"), Expression("jEmp.[EmpID]")]
        public String EmpEmpId { get { return Fields.EmpEmpId[this]; } set { Fields.EmpEmpId[this] = value; } }
        public partial class RowFields { public StringField EmpEmpId; }


        [DisplayName("Emp Employee Initial"), Expression("jEmp.[EmployeeInitial]")]
        public String EmpEmployeeInitial { get { return Fields.EmpEmployeeInitial[this]; } set { Fields.EmpEmployeeInitial[this] = value; } }
        public partial class RowFields { public StringField EmpEmployeeInitial; }


        [DisplayName("Emp Title Id"), Expression("jEmp.[TitleId]")]
        public Int32? EmpTitleId { get { return Fields.EmpTitleId[this]; } set { Fields.EmpTitleId[this] = value; } }
        public partial class RowFields { public Int32Field EmpTitleId; }


        [DisplayName("Emp First Name"), Expression("jEmp.[FirstName]")]
        public String EmpFirstName { get { return Fields.EmpFirstName[this]; } set { Fields.EmpFirstName[this] = value; } }
        public partial class RowFields { public StringField EmpFirstName; }


        [DisplayName("Emp Middle Name"), Expression("jEmp.[MiddleName]")]
        public String EmpMiddleName { get { return Fields.EmpMiddleName[this]; } set { Fields.EmpMiddleName[this] = value; } }
        public partial class RowFields { public StringField EmpMiddleName; }


        [DisplayName("Emp Last Name"), Expression("jEmp.[LastName]")]
        public String EmpLastName { get { return Fields.EmpLastName[this]; } set { Fields.EmpLastName[this] = value; } }
        public partial class RowFields { public StringField EmpLastName; }


        [DisplayName("Emp Name"), Expression("jEmp.[FullName]")]
        public String EmpFullName { get { return Fields.EmpFullName[this]; } set { Fields.EmpFullName[this] = value; } }
        public partial class RowFields { public StringField EmpFullName; }


        [DisplayName("Emp Designation Id"), Expression("jEmp.[DesignationId]")]
        public Int32? EmpDesignationId { get { return Fields.EmpDesignationId[this]; } set { Fields.EmpDesignationId[this] = value; } }
        public partial class RowFields { public Int32Field EmpDesignationId; }


        [DisplayName("Emp Status Designation Id"), Expression("jEmp.[StatusDesignationId]")]
        public Int32? EmpStatusDesignationId { get { return Fields.EmpStatusDesignationId[this]; } set { Fields.EmpStatusDesignationId[this] = value; } }
        public partial class RowFields { public Int32Field EmpStatusDesignationId; }


        [DisplayName("Emp Discipline Id"), Expression("jEmp.[DisciplineId]")]
        public Int32? EmpDisciplineId { get { return Fields.EmpDisciplineId[this]; } set { Fields.EmpDisciplineId[this] = value; } }
        public partial class RowFields { public Int32Field EmpDisciplineId; }


        [DisplayName("Emp Division Id"), Expression("jEmp.[DivisionId]")]
        public Int32? EmpDivisionId { get { return Fields.EmpDivisionId[this]; } set { Fields.EmpDivisionId[this] = value; } }
        public partial class RowFields { public Int32Field EmpDivisionId; }


        [DisplayName("Emp Section Id"), Expression("jEmp.[SectionId]")]
        public Int32? EmpSectionId { get { return Fields.EmpSectionId[this]; } set { Fields.EmpSectionId[this] = value; } }
        public partial class RowFields { public Int32Field EmpSectionId; }


        [DisplayName("Emp Sub Section Id"), Expression("jEmp.[SubSectionId]")]
        public Int32? EmpSubSectionId { get { return Fields.EmpSubSectionId[this]; } set { Fields.EmpSubSectionId[this] = value; } }
        public partial class RowFields { public Int32Field EmpSubSectionId; }


        [DisplayName("Emp Job Location Id"), Expression("jEmp.[JobLocationId]")]
        public Int32? EmpJobLocationId { get { return Fields.EmpJobLocationId[this]; } set { Fields.EmpJobLocationId[this] = value; } }
        public partial class RowFields { public Int32Field EmpJobLocationId; }


        [DisplayName("Emp Resource Level Id"), Expression("jEmp.[ResourceLevelId]")]
        public Int32? EmpResourceLevelId { get { return Fields.EmpResourceLevelId[this]; } set { Fields.EmpResourceLevelId[this] = value; } }
        public partial class RowFields { public Int32Field EmpResourceLevelId; }


        [DisplayName("Emp Staff Category Id"), Expression("jEmp.[StaffCategoryId]")]
        public Int32? EmpStaffCategoryId { get { return Fields.EmpStaffCategoryId[this]; } set { Fields.EmpStaffCategoryId[this] = value; } }
        public partial class RowFields { public Int32Field EmpStaffCategoryId; }


        [DisplayName("Emp Employment Type Id"), Expression("jEmp.[EmploymentTypeId]")]
        public Int32? EmpEmploymentTypeId { get { return Fields.EmpEmploymentTypeId[this]; } set { Fields.EmpEmploymentTypeId[this] = value; } }
        public partial class RowFields { public Int32Field EmpEmploymentTypeId; }



        [DisplayName("Emp Bank Id"), Expression("jEmp.[BankId]")]
        public Int32? EmpBankId { get { return Fields.EmpBankId[this]; } set { Fields.EmpBankId[this] = value; } }
        public partial class RowFields { public Int32Field EmpBankId; }


        [DisplayName("Emp Bank Branch Id"), Expression("jEmp.[BankBranchId]")]
        public Int32? EmpBankBranchId { get { return Fields.EmpBankBranchId[this]; } set { Fields.EmpBankBranchId[this] = value; } }
        public partial class RowFields { public Int32Field EmpBankBranchId; }


        [DisplayName("Emp Bank Account No"), Expression("jEmp.[BankAccountNo]")]
        public String EmpBankAccountNo { get { return Fields.EmpBankAccountNo[this]; } set { Fields.EmpBankAccountNo[this] = value; } }
        public partial class RowFields { public StringField EmpBankAccountNo; }


        [DisplayName("Emp Employment Status Id"), Expression("jEmp.[EmploymentStatusId]")]
        public Int32? EmpEmploymentStatusId { get { return Fields.EmpEmploymentStatusId[this]; } set { Fields.EmpEmploymentStatusId[this] = value; } }
        public partial class RowFields { public Int32Field EmpEmploymentStatusId; }



        [DisplayName("Emp Zone Info Id"), Expression("jEmp.[ZoneInfoId]")]
        public Int32? EmpZoneInfoId { get { return Fields.EmpZoneInfoId[this]; } set { Fields.EmpZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field EmpZoneInfoId; }



        [DisplayName("Chart of Accounts"), Expression("jCoA.[accountName]")]
        public String CoAAccountName { get { return Fields.CoAAccountName[this]; } set { Fields.CoAAccountName[this] = value; } }
        public partial class RowFields { public StringField CoAAccountName; }



        [DisplayName("Co A Coa Mapping"), Expression("jCoA.[coaMapping]")]
        public String CoACoaMapping { get { return Fields.CoACoaMapping[this]; } set { Fields.CoACoaMapping[this] = value; } }
        public partial class RowFields { public StringField CoACoaMapping; }



        [DisplayName("Co A Is Budget Head"), Expression("jCoA.[isBudgetHead]")]
        public Int16? CoAIsBudgetHead { get { return Fields.CoAIsBudgetHead[this]; } set { Fields.CoAIsBudgetHead[this] = value; } }
        public partial class RowFields { public Int16Field CoAIsBudgetHead; }


        [DisplayName("Co A Is Controlhead"), Expression("jCoA.[isControlhead]")]
        public Int16? CoAIsControlhead { get { return Fields.CoAIsControlhead[this]; } set { Fields.CoAIsControlhead[this] = value; } }
        public partial class RowFields { public Int16Field CoAIsControlhead; }


        [DisplayName("Co A Is Sub Ledger Allocate"), Expression("jCoA.[isCostCenterAllocate]")]
        public Int16? CoAIsCostCenterAllocate { get { return Fields.CoAIsCostCenterAllocate[this]; } set { Fields.CoAIsCostCenterAllocate[this] = value; } }
        public partial class RowFields { public Int16Field CoAIsCostCenterAllocate; }


        [DisplayName("Co A Opening Balance"), Expression("jCoA.[openingBalance]")]
        public Decimal? CoAOpeningBalance { get { return Fields.CoAOpeningBalance[this]; } set { Fields.CoAOpeningBalance[this] = value; } }
        public partial class RowFields { public DecimalField CoAOpeningBalance; }



        [DisplayName("Co A Fund Control Id"), Expression("jCoA.[fundControlId]")]
        public Int32? CoAFundControlId { get { return Fields.CoAFundControlId[this]; } set { Fields.CoAFundControlId[this] = value; } }
        public partial class RowFields { public Int32Field CoAFundControlId; }


        [DisplayName("Co A Parent Account Id"), Expression("jCoA.[parentAccountId]")]
        public Int32? CoAParentAccountId { get { return Fields.CoAParentAccountId[this]; } set { Fields.CoAParentAccountId[this] = value; } }
        public partial class RowFields { public Int32Field CoAParentAccountId; }



        [DisplayName("Cheque Register Amount"), Expression("jChequeRegister.[amount]")]
        public Decimal? ChequeRegisterAmount { get { return Fields.ChequeRegisterAmount[this]; } set { Fields.ChequeRegisterAmount[this] = value; } }
        public partial class RowFields { public DecimalField ChequeRegisterAmount; }


        [DisplayName("Cheque Register Amount In Words"), Expression("jChequeRegister.[amountInWords]")]
        public String ChequeRegisterAmountInWords { get { return Fields.ChequeRegisterAmountInWords[this]; } set { Fields.ChequeRegisterAmountInWords[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterAmountInWords; }


        [DisplayName("Cheque Register Cheque Date"), Expression("jChequeRegister.[chequeDate]")]
        public DateTime? ChequeRegisterChequeDate { get { return Fields.ChequeRegisterChequeDate[this]; } set { Fields.ChequeRegisterChequeDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeRegisterChequeDate; }


        [DisplayName("Cheque Register Cheque Issue Date"), Expression("jChequeRegister.[chequeIssueDate]")]
        public DateTime? ChequeRegisterChequeIssueDate { get { return Fields.ChequeRegisterChequeIssueDate[this]; } set { Fields.ChequeRegisterChequeIssueDate[this] = value; } }
        public partial class RowFields { public DateTimeField ChequeRegisterChequeIssueDate; }


        [DisplayName("Cheque Register Cheque No"), Expression("jChequeRegister.[chequeNo]")]
        public String ChequeRegisterChequeNo { get { return Fields.ChequeRegisterChequeNo[this]; } set { Fields.ChequeRegisterChequeNo[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterChequeNo; }


        [DisplayName("Cheque Register Cheque Numhdn"), Expression("jChequeRegister.[chequeNumhdn]")]
        public Decimal? ChequeRegisterChequeNumhdn { get { return Fields.ChequeRegisterChequeNumhdn[this]; } set { Fields.ChequeRegisterChequeNumhdn[this] = value; } }
        public partial class RowFields { public DecimalField ChequeRegisterChequeNumhdn; }


        [DisplayName("Cheque Register Cheque Type"), Expression("jChequeRegister.[chequeType]")]
        public String ChequeRegisterChequeType { get { return Fields.ChequeRegisterChequeType[this]; } set { Fields.ChequeRegisterChequeType[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterChequeType; }


        [DisplayName("Cheque Register Is Cancelled"), Expression("jChequeRegister.[isCancelled]")]
        public Boolean? ChequeRegisterIsCancelled { get { return Fields.ChequeRegisterIsCancelled[this]; } set { Fields.ChequeRegisterIsCancelled[this] = value; } }
        public partial class RowFields { public BooleanField ChequeRegisterIsCancelled; }


        [DisplayName("Cheque Register Is Payment"), Expression("jChequeRegister.[isPayment]")]
        public Boolean? ChequeRegisterIsPayment { get { return Fields.ChequeRegisterIsPayment[this]; } set { Fields.ChequeRegisterIsPayment[this] = value; } }
        public partial class RowFields { public BooleanField ChequeRegisterIsPayment; }


        [DisplayName("Cheque Register Is Used"), Expression("jChequeRegister.[isUsed]")]
        public Boolean? ChequeRegisterIsUsed { get { return Fields.ChequeRegisterIsUsed[this]; } set { Fields.ChequeRegisterIsUsed[this] = value; } }
        public partial class RowFields { public BooleanField ChequeRegisterIsUsed; }


        [DisplayName("Cheque Register Pay To"), Expression("jChequeRegister.[payTo]")]
        public String ChequeRegisterPayTo { get { return Fields.ChequeRegisterPayTo[this]; } set { Fields.ChequeRegisterPayTo[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterPayTo; }


        [DisplayName("Cheque Register Payee Bank Name"), Expression("jChequeRegister.[payeeBankName]")]
        public String ChequeRegisterPayeeBankName { get { return Fields.ChequeRegisterPayeeBankName[this]; } set { Fields.ChequeRegisterPayeeBankName[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterPayeeBankName; }


        [DisplayName("Cheque Register Remarks"), Expression("jChequeRegister.[remarks]")]
        public String ChequeRegisterRemarks { get { return Fields.ChequeRegisterRemarks[this]; } set { Fields.ChequeRegisterRemarks[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterRemarks; }


        [DisplayName("Cheque Register Voucher No"), Expression("jChequeRegister.[voucherNo]")]
        public String ChequeRegisterVoucherNo { get { return Fields.ChequeRegisterVoucherNo[this]; } set { Fields.ChequeRegisterVoucherNo[this] = value; } }
        public partial class RowFields { public StringField ChequeRegisterVoucherNo; }


        [DisplayName("Cheque Register Bank Account Information Id"), Expression("jChequeRegister.[bankAccountInformation_id]")]
        public Int32? ChequeRegisterBankAccountInformationId { get { return Fields.ChequeRegisterBankAccountInformationId[this]; } set { Fields.ChequeRegisterBankAccountInformationId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeRegisterBankAccountInformationId; }


        [DisplayName("Cheque Register Voucher Information Id"), Expression("jChequeRegister.[voucherInformation_id]")]
        public Int32? ChequeRegisterVoucherInformationId { get { return Fields.ChequeRegisterVoucherInformationId[this]; } set { Fields.ChequeRegisterVoucherInformationId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeRegisterVoucherInformationId; }


        [DisplayName("Cheque Register Entity Id"), Expression("jChequeRegister.[entityId]")]
        public Int32? ChequeRegisterEntityId { get { return Fields.ChequeRegisterEntityId[this]; } set { Fields.ChequeRegisterEntityId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeRegisterEntityId; }


        [DisplayName("Cheque Register Cheque Book Id"), Expression("jChequeRegister.[chequeBook_id]")]
        public Int32? ChequeRegisterChequeBookId { get { return Fields.ChequeRegisterChequeBookId[this]; } set { Fields.ChequeRegisterChequeBookId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeRegisterChequeBookId; }


        [DisplayName("Cheque Register Is Bank Advice"), Expression("jChequeRegister.[isBankAdvice]")]
        public Boolean? ChequeRegisterIsBankAdvice { get { return Fields.ChequeRegisterIsBankAdvice[this]; } set { Fields.ChequeRegisterIsBankAdvice[this] = value; } }
        public partial class RowFields { public BooleanField ChequeRegisterIsBankAdvice; }


        [DisplayName("Cheque Register Zone Info Id"), Expression("jChequeRegister.[ZoneInfoId]")]
        public Int32? ChequeRegisterZoneInfoId { get { return Fields.ChequeRegisterZoneInfoId[this]; } set { Fields.ChequeRegisterZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ChequeRegisterZoneInfoId; }

          [DisplayName("Account Code"), Expression("jCoA2.[accountCode]")]
        public String CoA2AccountCode { get { return Fields.CoA2AccountCode[this]; } set { Fields.CoA2AccountCode[this] = value; } }
        public partial class RowFields { public StringField CoA2AccountCode; }


        [DisplayName("Chart of Accounts"), Expression("jCoA2.[accountName]")]
        public String CoA2AccountName { get { return Fields.CoA2AccountName[this]; } set { Fields.CoA2AccountName[this] = value; } }
        public partial class RowFields { public StringField CoA2AccountName; }

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TransactionMode; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccEmpAdvanceRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_EmpAdvance]")
            {
                LocalTextPrefix = "Transaction.AccEmpAdvance";
            }
        }
        #endregion RowFields
    }
}

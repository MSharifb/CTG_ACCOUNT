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

    [ConnectionKey("ACCDB"), DisplayName("acc_VoucherAPI"), InstanceName("acc_VoucherAPI"), TwoLevelCached]
    [ReadPermission("Configurations:acc_VoucherAPI:Read")]
    [InsertPermission("Configurations:acc_VoucherAPI:Insert")]
    [UpdatePermission("Configurations:acc_VoucherAPI:Update")]
    [DeletePermission("Configurations:acc_VoucherAPI:Delete")]
    [LookupScript("Configurations.AccVoucherApiRow")]
    public sealed class AccVoucherApiRow : Row, IIdRow, INameRow, IAuditLog
    {
            #region Id
            [DisplayName("Id"), Identity]
            public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
            public partial class RowFields { public Int32Field Id; }
            #endregion Id

            #region Config
            [DisplayName("Config"), ForeignKey("[dbo].[acc_VoucherAPIConfig]", "Id"), LeftJoin("jConfig"), TextualField("ConfigConfigName")]
            [LookupEditor(typeof(Configurations.Entities.AccVoucherApiConfigRow), InplaceAdd = true)]
            public Int32? ConfigId { get { return Fields.ConfigId[this]; } set { Fields.ConfigId[this] = value; } }
            public partial class RowFields { public Int32Field ConfigId; }
            #endregion ConfigId

            #region Vouchr Type Id
            [DisplayName("Vouchr Type Id")]
            public Int32? VouchrTypeId { get { return Fields.VouchrTypeId[this]; } set { Fields.VouchrTypeId[this] = value; } }
            public partial class RowFields { public Int32Field VouchrTypeId; }
            #endregion VouchrTypeId

            #region Transaction Id
            [DisplayName("Transaction Id")]
            public Int32? TransactionId { get { return Fields.TransactionId[this]; } set { Fields.TransactionId[this] = value; } }
            public partial class RowFields { public Int32Field TransactionId; }
            #endregion TransactionId

            #region Narration
            [DisplayName("Narration"), Size(500), QuickSearch]
            public String Narration { get { return Fields.Narration[this]; } set { Fields.Narration[this] = value; } }
            public partial class RowFields { public StringField Narration; }
            #endregion Narration

            #region Transaction Mode
            [DisplayName("Transaction Mode"), Size(50)]
            public String TransactionMode { get { return Fields.TransactionMode[this]; } set { Fields.TransactionMode[this] = value; } }
            public partial class RowFields { public StringField TransactionMode; }
            #endregion TransactionMode

            #region Emp
            [DisplayName("Emp"), ForeignKey("[dbo].[PRM_EmploymentInfo]", "Id"), LeftJoin("jEmp"), TextualField("EmpEmpId")]
            [LookupEditor(typeof(Configurations.Entities.PrmEmploymentInfoRow), InplaceAdd = true)]
            public Int32? EmpId { get { return Fields.EmpId[this]; } set { Fields.EmpId[this] = value; } }
            public partial class RowFields { public Int32Field EmpId; }
            #endregion EmpId


    #region Foreign Fields

                [DisplayName("Config Config Name"), Expression("jConfig.[ConfigName]")]
                public String ConfigConfigName { get { return Fields.ConfigConfigName[this]; } set { Fields.ConfigConfigName[this] = value; } }
                public partial class RowFields { public StringField ConfigConfigName; }


                [DisplayName("Config Module Id"), Expression("jConfig.[ModuleId]")]
                public String ConfigModuleId { get { return Fields.ConfigModuleId[this]; } set { Fields.ConfigModuleId[this] = value; } }
                public partial class RowFields { public StringField ConfigModuleId; }


                [DisplayName("Config Form Name"), Expression("jConfig.[FormName]")]
                public String ConfigFormName { get { return Fields.ConfigFormName[this]; } set { Fields.ConfigFormName[this] = value; } }
                public partial class RowFields { public StringField ConfigFormName; }


                [DisplayName("Config Vouchr Type Id"), Expression("jConfig.[VouchrTypeId]")]
                public Int32? ConfigVouchrTypeId { get { return Fields.ConfigVouchrTypeId[this]; } set { Fields.ConfigVouchrTypeId[this] = value; } }
                public partial class RowFields { public Int32Field ConfigVouchrTypeId; }


                [DisplayName("Config Transaction Id"), Expression("jConfig.[TransactionId]")]
                public Int32? ConfigTransactionId { get { return Fields.ConfigTransactionId[this]; } set { Fields.ConfigTransactionId[this] = value; } }
                public partial class RowFields { public Int32Field ConfigTransactionId; }


                [DisplayName("Config Transaction Mode"), Expression("jConfig.[TransactionMode]")]
                public String ConfigTransactionMode { get { return Fields.ConfigTransactionMode[this]; } set { Fields.ConfigTransactionMode[this] = value; } }
                public partial class RowFields { public StringField ConfigTransactionMode; }


                [DisplayName("Config Narration"), Expression("jConfig.[Narration]")]
                public String ConfigNarration { get { return Fields.ConfigNarration[this]; } set { Fields.ConfigNarration[this] = value; } }
                public partial class RowFields { public StringField ConfigNarration; }


                [DisplayName("Config Fund Control Id"), Expression("jConfig.[FundControlId]")]
                public Int32? ConfigFundControlId { get { return Fields.ConfigFundControlId[this]; } set { Fields.ConfigFundControlId[this] = value; } }
                public partial class RowFields { public Int32Field ConfigFundControlId; }


                [DisplayName("Emp Emp Id"), Expression("jEmp.[EmpID]")]
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


                [DisplayName("Emp Full Name"), Expression("jEmp.[FullName]")]
                public String EmpFullName { get { return Fields.EmpFullName[this]; } set { Fields.EmpFullName[this] = value; } }
                public partial class RowFields { public StringField EmpFullName; }


                [DisplayName("Emp Full Name Bangla"), Expression("jEmp.[FullNameBangla]")]
                public String EmpFullNameBangla { get { return Fields.EmpFullNameBangla[this]; } set { Fields.EmpFullNameBangla[this] = value; } }
                public partial class RowFields { public StringField EmpFullNameBangla; }


                [DisplayName("Emp Dateof Joining"), Expression("jEmp.[DateofJoining]")]
                public DateTime? EmpDateofJoining { get { return Fields.EmpDateofJoining[this]; } set { Fields.EmpDateofJoining[this] = value; } }
                public partial class RowFields { public DateTimeField EmpDateofJoining; }


                [DisplayName("Emp Provision Month"), Expression("jEmp.[ProvisionMonth]")]
                public Int32? EmpProvisionMonth { get { return Fields.EmpProvisionMonth[this]; } set { Fields.EmpProvisionMonth[this] = value; } }
                public partial class RowFields { public Int32Field EmpProvisionMonth; }


                [DisplayName("Emp Dateof Confirmation"), Expression("jEmp.[DateofConfirmation]")]
                public DateTime? EmpDateofConfirmation { get { return Fields.EmpDateofConfirmation[this]; } set { Fields.EmpDateofConfirmation[this] = value; } }
                public partial class RowFields { public DateTimeField EmpDateofConfirmation; }


                [DisplayName("Emp Dateof Position"), Expression("jEmp.[DateofPosition]")]
                public DateTime? EmpDateofPosition { get { return Fields.EmpDateofPosition[this]; } set { Fields.EmpDateofPosition[this] = value; } }
                public partial class RowFields { public DateTimeField EmpDateofPosition; }


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


                [DisplayName("Emp Religion Id"), Expression("jEmp.[ReligionId]")]
                public Int32? EmpReligionId { get { return Fields.EmpReligionId[this]; } set { Fields.EmpReligionId[this] = value; } }
                public partial class RowFields { public Int32Field EmpReligionId; }


                [DisplayName("Emp Is Contractual"), Expression("jEmp.[IsContractual]")]
                public Boolean? EmpIsContractual { get { return Fields.EmpIsContractual[this]; } set { Fields.EmpIsContractual[this] = value; } }
                public partial class RowFields { public BooleanField EmpIsContractual; }


                [DisplayName("Emp Is Consultant"), Expression("jEmp.[IsConsultant]")]
                public Boolean? EmpIsConsultant { get { return Fields.EmpIsConsultant[this]; } set { Fields.EmpIsConsultant[this] = value; } }
                public partial class RowFields { public BooleanField EmpIsConsultant; }


                [DisplayName("Emp Is Overtime Eligible"), Expression("jEmp.[IsOvertimeEligible]")]
                public Boolean? EmpIsOvertimeEligible { get { return Fields.EmpIsOvertimeEligible[this]; } set { Fields.EmpIsOvertimeEligible[this] = value; } }
                public partial class RowFields { public BooleanField EmpIsOvertimeEligible; }


                [DisplayName("Emp Overtime Rate"), Expression("jEmp.[OvertimeRate]")]
                public Decimal? EmpOvertimeRate { get { return Fields.EmpOvertimeRate[this]; } set { Fields.EmpOvertimeRate[this] = value; } }
                public partial class RowFields { public DecimalField EmpOvertimeRate; }


                [DisplayName("Emp Mobile No"), Expression("jEmp.[MobileNo]")]
                public String EmpMobileNo { get { return Fields.EmpMobileNo[this]; } set { Fields.EmpMobileNo[this] = value; } }
                public partial class RowFields { public StringField EmpMobileNo; }


                [DisplayName("Emp Emial Address"), Expression("jEmp.[EmialAddress]")]
                public String EmpEmialAddress { get { return Fields.EmpEmialAddress[this]; } set { Fields.EmpEmialAddress[this] = value; } }
                public partial class RowFields { public StringField EmpEmialAddress; }


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


                [DisplayName("Emp Dateof Inactive"), Expression("jEmp.[DateofInactive]")]
                public DateTime? EmpDateofInactive { get { return Fields.EmpDateofInactive[this]; } set { Fields.EmpDateofInactive[this] = value; } }
                public partial class RowFields { public DateTimeField EmpDateofInactive; }


                [DisplayName("Emp Is Bonus Eligible"), Expression("jEmp.[IsBonusEligible]")]
                public Boolean? EmpIsBonusEligible { get { return Fields.EmpIsBonusEligible[this]; } set { Fields.EmpIsBonusEligible[this] = value; } }
                public partial class RowFields { public BooleanField EmpIsBonusEligible; }


                [DisplayName("Emp Salary Scale Id"), Expression("jEmp.[SalaryScaleId]")]
                public Int32? EmpSalaryScaleId { get { return Fields.EmpSalaryScaleId[this]; } set { Fields.EmpSalaryScaleId[this] = value; } }
                public partial class RowFields { public Int32Field EmpSalaryScaleId; }


                [DisplayName("Emp Job Grade Id"), Expression("jEmp.[JobGradeId]")]
                public Int32? EmpJobGradeId { get { return Fields.EmpJobGradeId[this]; } set { Fields.EmpJobGradeId[this] = value; } }
                public partial class RowFields { public Int32Field EmpJobGradeId; }


                [DisplayName("Emp Gender"), Expression("jEmp.[Gender]")]
                public String EmpGender { get { return Fields.EmpGender[this]; } set { Fields.EmpGender[this] = value; } }
                public partial class RowFields { public StringField EmpGender; }


                [DisplayName("Emp Contract Expire Date"), Expression("jEmp.[ContractExpireDate]")]
                public DateTime? EmpContractExpireDate { get { return Fields.EmpContractExpireDate[this]; } set { Fields.EmpContractExpireDate[this] = value; } }
                public partial class RowFields { public DateTimeField EmpContractExpireDate; }


                [DisplayName("Emp Dateof Birth"), Expression("jEmp.[DateofBirth]")]
                public DateTime? EmpDateofBirth { get { return Fields.EmpDateofBirth[this]; } set { Fields.EmpDateofBirth[this] = value; } }
                public partial class RowFields { public DateTimeField EmpDateofBirth; }


                [DisplayName("Emp Contract Duration"), Expression("jEmp.[ContractDuration]")]
                public Decimal? EmpContractDuration { get { return Fields.EmpContractDuration[this]; } set { Fields.EmpContractDuration[this] = value; } }
                public partial class RowFields { public DecimalField EmpContractDuration; }


                [DisplayName("Emp Contract Type"), Expression("jEmp.[ContractType]")]
                public Int32? EmpContractType { get { return Fields.EmpContractType[this]; } set { Fields.EmpContractType[this] = value; } }
                public partial class RowFields { public Int32Field EmpContractType; }


                [DisplayName("Emp Organogram Level Id"), Expression("jEmp.[OrganogramLevelId]")]
                public Int32? EmpOrganogramLevelId { get { return Fields.EmpOrganogramLevelId[this]; } set { Fields.EmpOrganogramLevelId[this] = value; } }
                public partial class RowFields { public Int32Field EmpOrganogramLevelId; }


                [DisplayName("Emp Dateof Appointment"), Expression("jEmp.[DateofAppointment]")]
                public DateTime? EmpDateofAppointment { get { return Fields.EmpDateofAppointment[this]; } set { Fields.EmpDateofAppointment[this] = value; } }
                public partial class RowFields { public DateTimeField EmpDateofAppointment; }


                [DisplayName("Emp Order No"), Expression("jEmp.[OrderNo]")]
                public String EmpOrderNo { get { return Fields.EmpOrderNo[this]; } set { Fields.EmpOrderNo[this] = value; } }
                public partial class RowFields { public StringField EmpOrderNo; }


                [DisplayName("Emp Quota Id"), Expression("jEmp.[QuotaId]")]
                public Int32? EmpQuotaId { get { return Fields.EmpQuotaId[this]; } set { Fields.EmpQuotaId[this] = value; } }
                public partial class RowFields { public Int32Field EmpQuotaId; }


                [DisplayName("Emp Employee Class Id"), Expression("jEmp.[EmployeeClassId]")]
                public Int32? EmpEmployeeClassId { get { return Fields.EmpEmployeeClassId[this]; } set { Fields.EmpEmployeeClassId[this] = value; } }
                public partial class RowFields { public Int32Field EmpEmployeeClassId; }


                [DisplayName("Emp Employment Process Id"), Expression("jEmp.[EmploymentProcessId]")]
                public Int32? EmpEmploymentProcessId { get { return Fields.EmpEmploymentProcessId[this]; } set { Fields.EmpEmploymentProcessId[this] = value; } }
                public partial class RowFields { public Int32Field EmpEmploymentProcessId; }


                [DisplayName("Emp Seniority Position"), Expression("jEmp.[SeniorityPosition]")]
                public String EmpSeniorityPosition { get { return Fields.EmpSeniorityPosition[this]; } set { Fields.EmpSeniorityPosition[this] = value; } }
                public partial class RowFields { public StringField EmpSeniorityPosition; }


                [DisplayName("Emp Dateof Seniority"), Expression("jEmp.[DateofSeniority]")]
                public DateTime? EmpDateofSeniority { get { return Fields.EmpDateofSeniority[this]; } set { Fields.EmpDateofSeniority[this] = value; } }
                public partial class RowFields { public DateTimeField EmpDateofSeniority; }


                [DisplayName("Emp Prl Date"), Expression("jEmp.[PRLDate]")]
                public DateTime? EmpPrlDate { get { return Fields.EmpPrlDate[this]; } set { Fields.EmpPrlDate[this] = value; } }
                public partial class RowFields { public DateTimeField EmpPrlDate; }


                [DisplayName("Emp Is Pension Eligible"), Expression("jEmp.[IsPensionEligible]")]
                public Boolean? EmpIsPensionEligible { get { return Fields.EmpIsPensionEligible[this]; } set { Fields.EmpIsPensionEligible[this] = value; } }
                public partial class RowFields { public BooleanField EmpIsPensionEligible; }


                [DisplayName("Emp Is Leverage Eligible"), Expression("jEmp.[IsLeverageEligible]")]
                public Boolean? EmpIsLeverageEligible { get { return Fields.EmpIsLeverageEligible[this]; } set { Fields.EmpIsLeverageEligible[this] = value; } }
                public partial class RowFields { public BooleanField EmpIsLeverageEligible; }


                [DisplayName("Emp Card No"), Expression("jEmp.[CardNo]")]
                public String EmpCardNo { get { return Fields.EmpCardNo[this]; } set { Fields.EmpCardNo[this] = value; } }
                public partial class RowFields { public StringField EmpCardNo; }


                [DisplayName("Emp Finger Print Identiy No"), Expression("jEmp.[FingerPrintIdentiyNo]")]
                public String EmpFingerPrintIdentiyNo { get { return Fields.EmpFingerPrintIdentiyNo[this]; } set { Fields.EmpFingerPrintIdentiyNo[this] = value; } }
                public partial class RowFields { public StringField EmpFingerPrintIdentiyNo; }


                [DisplayName("Emp Attendance Effective Date"), Expression("jEmp.[AttendanceEffectiveDate]")]
                public DateTime? EmpAttendanceEffectiveDate { get { return Fields.EmpAttendanceEffectiveDate[this]; } set { Fields.EmpAttendanceEffectiveDate[this] = value; } }
                public partial class RowFields { public DateTimeField EmpAttendanceEffectiveDate; }


                [DisplayName("Emp Attendance Status"), Expression("jEmp.[AttendanceStatus]")]
                public Boolean? EmpAttendanceStatus { get { return Fields.EmpAttendanceStatus[this]; } set { Fields.EmpAttendanceStatus[this] = value; } }
                public partial class RowFields { public BooleanField EmpAttendanceStatus; }


                [DisplayName("Emp I User"), Expression("jEmp.[IUser]")]
                public String EmpIUser { get { return Fields.EmpIUser[this]; } set { Fields.EmpIUser[this] = value; } }
                public partial class RowFields { public StringField EmpIUser; }


                [DisplayName("Emp I Date"), Expression("jEmp.[IDate]")]
                public DateTime? EmpIDate { get { return Fields.EmpIDate[this]; } set { Fields.EmpIDate[this] = value; } }
                public partial class RowFields { public DateTimeField EmpIDate; }


                [DisplayName("Emp E User"), Expression("jEmp.[EUser]")]
                public String EmpEUser { get { return Fields.EmpEUser[this]; } set { Fields.EmpEUser[this] = value; } }
                public partial class RowFields { public StringField EmpEUser; }


                [DisplayName("Emp E Date"), Expression("jEmp.[EDate]")]
                public DateTime? EmpEDate { get { return Fields.EmpEDate[this]; } set { Fields.EmpEDate[this] = value; } }
                public partial class RowFields { public DateTimeField EmpEDate; }


                [DisplayName("Emp Is General Shifted"), Expression("jEmp.[IsGeneralShifted]")]
                public Boolean? EmpIsGeneralShifted { get { return Fields.EmpIsGeneralShifted[this]; } set { Fields.EmpIsGeneralShifted[this] = value; } }
                public partial class RowFields { public BooleanField EmpIsGeneralShifted; }


                [DisplayName("Emp Zone Info Id"), Expression("jEmp.[ZoneInfoId]")]
                public Int32? EmpZoneInfoId { get { return Fields.EmpZoneInfoId[this]; } set { Fields.EmpZoneInfoId[this] = value; } }
                public partial class RowFields { public Int32Field EmpZoneInfoId; }


                [DisplayName("Emp Telephone Office"), Expression("jEmp.[TelephoneOffice]")]
                public String EmpTelephoneOffice { get { return Fields.EmpTelephoneOffice[this]; } set { Fields.EmpTelephoneOffice[this] = value; } }
                public partial class RowFields { public StringField EmpTelephoneOffice; }


                [DisplayName("Emp Intercom"), Expression("jEmp.[Intercom]")]
                public String EmpIntercom { get { return Fields.EmpIntercom[this]; } set { Fields.EmpIntercom[this] = value; } }
                public partial class RowFields { public StringField EmpIntercom; }


                [DisplayName("Emp Honorary Degree"), Expression("jEmp.[HonoraryDegree]")]
                public String EmpHonoraryDegree { get { return Fields.EmpHonoraryDegree[this]; } set { Fields.EmpHonoraryDegree[this] = value; } }
                public partial class RowFields { public StringField EmpHonoraryDegree; }


                [DisplayName("Emp Is Eligible For Cpf"), Expression("jEmp.[IsEligibleForCpf]")]
                public Boolean? EmpIsEligibleForCpf { get { return Fields.EmpIsEligibleForCpf[this]; } set { Fields.EmpIsEligibleForCpf[this] = value; } }
                public partial class RowFields { public BooleanField EmpIsEligibleForCpf; }


                [DisplayName("Emp Tax Region Id"), Expression("jEmp.[TaxRegionId]")]
                public Int32? EmpTaxRegionId { get { return Fields.EmpTaxRegionId[this]; } set { Fields.EmpTaxRegionId[this] = value; } }
                public partial class RowFields { public Int32Field EmpTaxRegionId; }


                [DisplayName("Emp Tax Assessee Type"), Expression("jEmp.[TaxAssesseeType]")]
                public Int16? EmpTaxAssesseeType { get { return Fields.EmpTaxAssesseeType[this]; } set { Fields.EmpTaxAssesseeType[this] = value; } }
                public partial class RowFields { public Int16Field EmpTaxAssesseeType; }


                [DisplayName("Emp Having Child With Disability"), Expression("jEmp.[HavingChildWithDisability]")]
                public Boolean? EmpHavingChildWithDisability { get { return Fields.EmpHavingChildWithDisability[this]; } set { Fields.EmpHavingChildWithDisability[this] = value; } }
                public partial class RowFields { public BooleanField EmpHavingChildWithDisability; }


                [DisplayName("Emp Dateof Retirement"), Expression("jEmp.[DateofRetirement]")]
                public DateTime? EmpDateofRetirement { get { return Fields.EmpDateofRetirement[this]; } set { Fields.EmpDateofRetirement[this] = value; } }
                public partial class RowFields { public DateTimeField EmpDateofRetirement; }


                [DisplayName("Emp Salary Withdraw From Zone Id"), Expression("jEmp.[SalaryWithdrawFromZoneId]")]
                public Int32? EmpSalaryWithdrawFromZoneId { get { return Fields.EmpSalaryWithdrawFromZoneId[this]; } set { Fields.EmpSalaryWithdrawFromZoneId[this] = value; } }
                public partial class RowFields { public Int32Field EmpSalaryWithdrawFromZoneId; }


                [DisplayName("Emp Region Id"), Expression("jEmp.[RegionId]")]
                public Int32? EmpRegionId { get { return Fields.EmpRegionId[this]; } set { Fields.EmpRegionId[this] = value; } }
                public partial class RowFields { public Int32Field EmpRegionId; }


    #endregion Foreign Fields

    #region Id and Name fields
    IIdField IIdRow.IdField
    {
    get { return Fields.Id; }
    }

            StringField INameRow.NameField
            {
            get { return Fields.Narration; }
            }
            #endregion Id and Name fields

    #region Constructor
    public AccVoucherApiRow()
    : base(Fields)
    {
    }
    #endregion Constructor

    #region RowFields
    public static readonly RowFields Fields = new RowFields().Init();

    public partial class RowFields : RowFieldsBase
    {
    public RowFields()
    : base("[dbo].[acc_VoucherAPI]")
    {
    LocalTextPrefix = "Configurations.AccVoucherApi";
    }
    }
    #endregion RowFields
    }
    }

namespace VistaGL.Configurations {
    export interface AccVoucherApiRow {
        Id?: number;
        ConfigId?: number;
        VouchrTypeId?: number;
        TransactionId?: number;
        Narration?: string;
        TransactionMode?: string;
        EmpId?: number;
        ConfigConfigName?: string;
        ConfigModuleId?: string;
        ConfigFormName?: string;
        ConfigVouchrTypeId?: number;
        ConfigTransactionId?: number;
        ConfigTransactionMode?: string;
        ConfigNarration?: string;
        ConfigFundControlId?: number;
        EmpEmpId?: string;
        EmpEmployeeInitial?: string;
        EmpTitleId?: number;
        EmpFirstName?: string;
        EmpMiddleName?: string;
        EmpLastName?: string;
        EmpFullName?: string;
        EmpFullNameBangla?: string;
        EmpDateofJoining?: string;
        EmpProvisionMonth?: number;
        EmpDateofConfirmation?: string;
        EmpDateofPosition?: string;
        EmpDesignationId?: number;
        EmpStatusDesignationId?: number;
        EmpDisciplineId?: number;
        EmpDivisionId?: number;
        EmpSectionId?: number;
        EmpSubSectionId?: number;
        EmpJobLocationId?: number;
        EmpResourceLevelId?: number;
        EmpStaffCategoryId?: number;
        EmpEmploymentTypeId?: number;
        EmpReligionId?: number;
        EmpIsContractual?: boolean;
        EmpIsConsultant?: boolean;
        EmpIsOvertimeEligible?: boolean;
        EmpOvertimeRate?: number;
        EmpMobileNo?: string;
        EmpEmialAddress?: string;
        EmpBankId?: number;
        EmpBankBranchId?: number;
        EmpBankAccountNo?: string;
        EmpEmploymentStatusId?: number;
        EmpDateofInactive?: string;
        EmpIsBonusEligible?: boolean;
        EmpSalaryScaleId?: number;
        EmpJobGradeId?: number;
        EmpGender?: string;
        EmpContractExpireDate?: string;
        EmpDateofBirth?: string;
        EmpContractDuration?: number;
        EmpContractType?: number;
        EmpOrganogramLevelId?: number;
        EmpDateofAppointment?: string;
        EmpOrderNo?: string;
        EmpQuotaId?: number;
        EmpEmployeeClassId?: number;
        EmpEmploymentProcessId?: number;
        EmpSeniorityPosition?: string;
        EmpDateofSeniority?: string;
        EmpPrlDate?: string;
        EmpIsPensionEligible?: boolean;
        EmpIsLeverageEligible?: boolean;
        EmpCardNo?: string;
        EmpFingerPrintIdentiyNo?: string;
        EmpAttendanceEffectiveDate?: string;
        EmpAttendanceStatus?: boolean;
        EmpIUser?: string;
        EmpIDate?: string;
        EmpEUser?: string;
        EmpEDate?: string;
        EmpIsGeneralShifted?: boolean;
        EmpZoneInfoId?: number;
        EmpTelephoneOffice?: string;
        EmpIntercom?: string;
        EmpHonoraryDegree?: string;
        EmpIsEligibleForCpf?: boolean;
        EmpTaxRegionId?: number;
        EmpTaxAssesseeType?: number;
        EmpHavingChildWithDisability?: boolean;
        EmpDateofRetirement?: string;
        EmpSalaryWithdrawFromZoneId?: number;
        EmpRegionId?: number;
    }

    export namespace AccVoucherApiRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Narration';
        export const localTextPrefix = 'Configurations.AccVoucherApi';
        export const lookupKey = 'Configurations.AccVoucherApiRow';

        export function getLookup(): Q.Lookup<AccVoucherApiRow> {
            return Q.getLookup<AccVoucherApiRow>('Configurations.AccVoucherApiRow');
        }

        export declare const enum Fields {
            Id = "Id",
            ConfigId = "ConfigId",
            VouchrTypeId = "VouchrTypeId",
            TransactionId = "TransactionId",
            Narration = "Narration",
            TransactionMode = "TransactionMode",
            EmpId = "EmpId",
            ConfigConfigName = "ConfigConfigName",
            ConfigModuleId = "ConfigModuleId",
            ConfigFormName = "ConfigFormName",
            ConfigVouchrTypeId = "ConfigVouchrTypeId",
            ConfigTransactionId = "ConfigTransactionId",
            ConfigTransactionMode = "ConfigTransactionMode",
            ConfigNarration = "ConfigNarration",
            ConfigFundControlId = "ConfigFundControlId",
            EmpEmpId = "EmpEmpId",
            EmpEmployeeInitial = "EmpEmployeeInitial",
            EmpTitleId = "EmpTitleId",
            EmpFirstName = "EmpFirstName",
            EmpMiddleName = "EmpMiddleName",
            EmpLastName = "EmpLastName",
            EmpFullName = "EmpFullName",
            EmpFullNameBangla = "EmpFullNameBangla",
            EmpDateofJoining = "EmpDateofJoining",
            EmpProvisionMonth = "EmpProvisionMonth",
            EmpDateofConfirmation = "EmpDateofConfirmation",
            EmpDateofPosition = "EmpDateofPosition",
            EmpDesignationId = "EmpDesignationId",
            EmpStatusDesignationId = "EmpStatusDesignationId",
            EmpDisciplineId = "EmpDisciplineId",
            EmpDivisionId = "EmpDivisionId",
            EmpSectionId = "EmpSectionId",
            EmpSubSectionId = "EmpSubSectionId",
            EmpJobLocationId = "EmpJobLocationId",
            EmpResourceLevelId = "EmpResourceLevelId",
            EmpStaffCategoryId = "EmpStaffCategoryId",
            EmpEmploymentTypeId = "EmpEmploymentTypeId",
            EmpReligionId = "EmpReligionId",
            EmpIsContractual = "EmpIsContractual",
            EmpIsConsultant = "EmpIsConsultant",
            EmpIsOvertimeEligible = "EmpIsOvertimeEligible",
            EmpOvertimeRate = "EmpOvertimeRate",
            EmpMobileNo = "EmpMobileNo",
            EmpEmialAddress = "EmpEmialAddress",
            EmpBankId = "EmpBankId",
            EmpBankBranchId = "EmpBankBranchId",
            EmpBankAccountNo = "EmpBankAccountNo",
            EmpEmploymentStatusId = "EmpEmploymentStatusId",
            EmpDateofInactive = "EmpDateofInactive",
            EmpIsBonusEligible = "EmpIsBonusEligible",
            EmpSalaryScaleId = "EmpSalaryScaleId",
            EmpJobGradeId = "EmpJobGradeId",
            EmpGender = "EmpGender",
            EmpContractExpireDate = "EmpContractExpireDate",
            EmpDateofBirth = "EmpDateofBirth",
            EmpContractDuration = "EmpContractDuration",
            EmpContractType = "EmpContractType",
            EmpOrganogramLevelId = "EmpOrganogramLevelId",
            EmpDateofAppointment = "EmpDateofAppointment",
            EmpOrderNo = "EmpOrderNo",
            EmpQuotaId = "EmpQuotaId",
            EmpEmployeeClassId = "EmpEmployeeClassId",
            EmpEmploymentProcessId = "EmpEmploymentProcessId",
            EmpSeniorityPosition = "EmpSeniorityPosition",
            EmpDateofSeniority = "EmpDateofSeniority",
            EmpPrlDate = "EmpPrlDate",
            EmpIsPensionEligible = "EmpIsPensionEligible",
            EmpIsLeverageEligible = "EmpIsLeverageEligible",
            EmpCardNo = "EmpCardNo",
            EmpFingerPrintIdentiyNo = "EmpFingerPrintIdentiyNo",
            EmpAttendanceEffectiveDate = "EmpAttendanceEffectiveDate",
            EmpAttendanceStatus = "EmpAttendanceStatus",
            EmpIUser = "EmpIUser",
            EmpIDate = "EmpIDate",
            EmpEUser = "EmpEUser",
            EmpEDate = "EmpEDate",
            EmpIsGeneralShifted = "EmpIsGeneralShifted",
            EmpZoneInfoId = "EmpZoneInfoId",
            EmpTelephoneOffice = "EmpTelephoneOffice",
            EmpIntercom = "EmpIntercom",
            EmpHonoraryDegree = "EmpHonoraryDegree",
            EmpIsEligibleForCpf = "EmpIsEligibleForCpf",
            EmpTaxRegionId = "EmpTaxRegionId",
            EmpTaxAssesseeType = "EmpTaxAssesseeType",
            EmpHavingChildWithDisability = "EmpHavingChildWithDisability",
            EmpDateofRetirement = "EmpDateofRetirement",
            EmpSalaryWithdrawFromZoneId = "EmpSalaryWithdrawFromZoneId",
            EmpRegionId = "EmpRegionId"
        }
    }
}


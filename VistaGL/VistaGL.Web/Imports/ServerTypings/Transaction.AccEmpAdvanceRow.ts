namespace VistaGL.Transaction {
    export interface AccEmpAdvanceRow {
        Id?: number;
        EmpId?: number;
        TransactionMode?: string;
        CoAId?: number;
        ChequeRegisterId?: number;
        Amount?: number;
        RemainAmount?: number;
        Status?: number;
        ZoneId?: number;
        Narration?: string;
        CoAId2?: number;
        EmpEmpId?: string;
        EmpEmployeeInitial?: string;
        EmpTitleId?: number;
        EmpFirstName?: string;
        EmpMiddleName?: string;
        EmpLastName?: string;
        EmpFullName?: string;
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
        EmpBankId?: number;
        EmpBankBranchId?: number;
        EmpBankAccountNo?: string;
        EmpEmploymentStatusId?: number;
        EmpZoneInfoId?: number;
        CoAAccountName?: string;
        CoACoaMapping?: string;
        CoAIsBudgetHead?: number;
        CoAIsControlhead?: number;
        CoAIsCostCenterAllocate?: number;
        CoAOpeningBalance?: number;
        CoAFundControlId?: number;
        CoAParentAccountId?: number;
        ChequeRegisterAmount?: number;
        ChequeRegisterAmountInWords?: string;
        ChequeRegisterChequeDate?: string;
        ChequeRegisterChequeIssueDate?: string;
        ChequeRegisterChequeNo?: string;
        ChequeRegisterChequeNumhdn?: number;
        ChequeRegisterChequeType?: string;
        ChequeRegisterIsCancelled?: boolean;
        ChequeRegisterIsPayment?: boolean;
        ChequeRegisterIsUsed?: boolean;
        ChequeRegisterPayTo?: string;
        ChequeRegisterPayeeBankName?: string;
        ChequeRegisterRemarks?: string;
        ChequeRegisterVoucherNo?: string;
        ChequeRegisterBankAccountInformationId?: number;
        ChequeRegisterVoucherInformationId?: number;
        ChequeRegisterEntityId?: number;
        ChequeRegisterChequeBookId?: number;
        ChequeRegisterIsBankAdvice?: boolean;
        ChequeRegisterZoneInfoId?: number;
        CoA2AccountCode?: string;
        CoA2AccountName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccEmpAdvanceRow {
        export const idProperty = 'Id';
        export const nameProperty = 'TransactionMode';
        export const localTextPrefix = 'Transaction.AccEmpAdvance';
        export const lookupKey = 'Transaction.AccEmpAdvanceRow';

        export function getLookup(): Q.Lookup<AccEmpAdvanceRow> {
            return Q.getLookup<AccEmpAdvanceRow>('Transaction.AccEmpAdvanceRow');
        }

        export declare const enum Fields {
            Id = "Id",
            EmpId = "EmpId",
            TransactionMode = "TransactionMode",
            CoAId = "CoAId",
            ChequeRegisterId = "ChequeRegisterId",
            Amount = "Amount",
            RemainAmount = "RemainAmount",
            Status = "Status",
            ZoneId = "ZoneId",
            Narration = "Narration",
            CoAId2 = "CoAId2",
            EmpEmpId = "EmpEmpId",
            EmpEmployeeInitial = "EmpEmployeeInitial",
            EmpTitleId = "EmpTitleId",
            EmpFirstName = "EmpFirstName",
            EmpMiddleName = "EmpMiddleName",
            EmpLastName = "EmpLastName",
            EmpFullName = "EmpFullName",
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
            EmpBankId = "EmpBankId",
            EmpBankBranchId = "EmpBankBranchId",
            EmpBankAccountNo = "EmpBankAccountNo",
            EmpEmploymentStatusId = "EmpEmploymentStatusId",
            EmpZoneInfoId = "EmpZoneInfoId",
            CoAAccountName = "CoAAccountName",
            CoACoaMapping = "CoACoaMapping",
            CoAIsBudgetHead = "CoAIsBudgetHead",
            CoAIsControlhead = "CoAIsControlhead",
            CoAIsCostCenterAllocate = "CoAIsCostCenterAllocate",
            CoAOpeningBalance = "CoAOpeningBalance",
            CoAFundControlId = "CoAFundControlId",
            CoAParentAccountId = "CoAParentAccountId",
            ChequeRegisterAmount = "ChequeRegisterAmount",
            ChequeRegisterAmountInWords = "ChequeRegisterAmountInWords",
            ChequeRegisterChequeDate = "ChequeRegisterChequeDate",
            ChequeRegisterChequeIssueDate = "ChequeRegisterChequeIssueDate",
            ChequeRegisterChequeNo = "ChequeRegisterChequeNo",
            ChequeRegisterChequeNumhdn = "ChequeRegisterChequeNumhdn",
            ChequeRegisterChequeType = "ChequeRegisterChequeType",
            ChequeRegisterIsCancelled = "ChequeRegisterIsCancelled",
            ChequeRegisterIsPayment = "ChequeRegisterIsPayment",
            ChequeRegisterIsUsed = "ChequeRegisterIsUsed",
            ChequeRegisterPayTo = "ChequeRegisterPayTo",
            ChequeRegisterPayeeBankName = "ChequeRegisterPayeeBankName",
            ChequeRegisterRemarks = "ChequeRegisterRemarks",
            ChequeRegisterVoucherNo = "ChequeRegisterVoucherNo",
            ChequeRegisterBankAccountInformationId = "ChequeRegisterBankAccountInformationId",
            ChequeRegisterVoucherInformationId = "ChequeRegisterVoucherInformationId",
            ChequeRegisterEntityId = "ChequeRegisterEntityId",
            ChequeRegisterChequeBookId = "ChequeRegisterChequeBookId",
            ChequeRegisterIsBankAdvice = "ChequeRegisterIsBankAdvice",
            ChequeRegisterZoneInfoId = "ChequeRegisterZoneInfoId",
            CoA2AccountCode = "CoA2AccountCode",
            CoA2AccountName = "CoA2AccountName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}


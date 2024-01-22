namespace VistaGL.Transaction {
    export interface AccNoaRow {
        Id?: number;
        NoaNumber?: string;
        NoaDate?: string;
        CostCenterId?: number;
        ContactValue?: number;
        NameofContract?: string;
        ContractDate?: string;
        AdministrativeDate?: string;
        TechnicalDate?: string;
        FinancialDate?: string;
        BudgetProvision?: number;
        AdministrativeApproved?: string;
        TechnicalApproved?: string;
        FinancialApproved?: string;
        TenderNo?: string;
        NameofContractor?: string;
        ContractorAddress?: string;
        SecurityMoney?: number;
        WorkStartOn?: string;
        CompilationDate?: string;
        MBNo?: string;
        ZoneInfoId?: number;
        ZoneInfoZoneName?: string;
    }

    export namespace AccNoaRow {
        export const idProperty = 'Id';
        export const nameProperty = 'NoaNumber';
        export const localTextPrefix = 'Transaction.AccNoa';
        export const lookupKey = 'Transaction.AccNoa';

        export function getLookup(): Q.Lookup<AccNoaRow> {
            return Q.getLookup<AccNoaRow>('Transaction.AccNoa');
        }

        export declare const enum Fields {
            Id = "Id",
            NoaNumber = "NoaNumber",
            NoaDate = "NoaDate",
            CostCenterId = "CostCenterId",
            ContactValue = "ContactValue",
            NameofContract = "NameofContract",
            ContractDate = "ContractDate",
            AdministrativeDate = "AdministrativeDate",
            TechnicalDate = "TechnicalDate",
            FinancialDate = "FinancialDate",
            BudgetProvision = "BudgetProvision",
            AdministrativeApproved = "AdministrativeApproved",
            TechnicalApproved = "TechnicalApproved",
            FinancialApproved = "FinancialApproved",
            TenderNo = "TenderNo",
            NameofContractor = "NameofContractor",
            ContractorAddress = "ContractorAddress",
            SecurityMoney = "SecurityMoney",
            WorkStartOn = "WorkStartOn",
            CompilationDate = "CompilationDate",
            MBNo = "MBNo",
            ZoneInfoId = "ZoneInfoId",
            ZoneInfoZoneName = "ZoneInfoZoneName"
        }
    }
}


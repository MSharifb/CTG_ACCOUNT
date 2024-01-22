namespace VistaGL {
    export enum RTransferType {
        BanktoBank = 0,
        BanktoCash = 1,
        CashtoBank = 2
    }
    Serenity.Decorators.registerEnumType(RTransferType, 'VistaGL.RTransferType', 'RTransferType');
}


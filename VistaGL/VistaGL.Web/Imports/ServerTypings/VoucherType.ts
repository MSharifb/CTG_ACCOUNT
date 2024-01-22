namespace VistaGL {
    export enum VoucherType {
        Payment_Voucher = 1,
        Receipt_Voucher = 2,
        Journal_Voucher = 3,
        Transfer_Voucher = 4
    }
    Serenity.Decorators.registerEnumType(VoucherType, 'VistaGL.VoucherType', 'VoucherType');
}


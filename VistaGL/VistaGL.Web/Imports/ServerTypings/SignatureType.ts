namespace VistaGL {
    export enum SignatureType {
        PreparedBy = 1,
        CheckedBy = 2,
        ApprovedBy = 3,
        PostedBy = 4
    }
    Serenity.Decorators.registerEnumType(SignatureType, 'VistaGL.SignatureType', 'SignatureType');
}




class VoucherUtil {

    constructor() {
        //
    }


    public static currencyToWords(s) {
        var data = Q.parseDecimal(s.toString()) - Math.floor(s);

        var inWords = '';

        if (data > 0) {
            inWords = this.convertNumber(s) + " TAKA " + this.convertNumber(data * 100) + " POISA";
        }
        else {
            inWords = this.convertNumber(s) + " TAKA";
        }

        return inWords + ' ONLY';
    }


    public static newVoucherNumberFactory(voucherConfiguration, transactionTypeId, voucherDate, financialYearId, fundControlId, zoneId, bankAccId, _callback) {

        if (transactionTypeId === "") {
            Q.alert("Please select Transaction Type.");
            return;
        }

        let voucherNo: string = "";
        let voucherNumber: string = "";

        let vc = voucherConfiguration
            .filter(p => p.FundControlInformationId == fundControlId
                && p.TransactionTypeId == transactionTypeId
                && p.AccountingPeriodId == financialYearId
                && p.ZoneInfoId == zoneId);

        if (vc.length > 0) {
            // call our service, see AccVoucherInformationEndpoint.cs and AccVoucherInformationRepository.cs
            VistaGL.Transaction.AccVoucherInformationService.GetNewVoucherNo({
                TransactionTypeId: transactionTypeId,
                FundControlInformationId: fundControlId,
                ZoneId: zoneId,
                FinancialYearId: financialYearId,
                VoucherDate: voucherDate,
                BankAccId: bankAccId
            }, response => {

                voucherNo = response.VoucherNo;
                voucherNumber = response.VoucherNumber;

            }).done(() => {

                if (_callback && typeof (_callback) === "function") {
                    _callback(voucherNo, voucherNumber);
                }

            });
        }
        else {
            Q.alert("Voucher Configuration not found!");
        }

    }




    public static convertNumber(num) {
        if ((num < 0) || (num > 99999999999999)) {
            return "NUMBER OUT OF RANGE!";
        }
        var Gn = Math.floor(num / 10000000);  /* Crore */
        num -= Gn * 10000000;
        var kn = Math.floor(num / 100000);     /* lakhs */
        num -= kn * 100000;
        var Hn = Math.floor(num / 1000);      /* thousand */
        num -= Hn * 1000;
        var Dn = Math.floor(num / 100);       /* Tens (deca) */
        num = num % 100;               /* Ones */
        var tn = Math.floor(num / 10);
        var one = Math.floor(num % 10);
        var res = "";

        if (Gn > 0) {
            res += (this.convertNumber(Gn) + " CRORE");
        }
        if (kn > 0) {
            res += (((res == "") ? "" : " ") +
                this.convertNumber(kn) + " LAKH");
        }
        if (Hn > 0) {
            res += (((res == "") ? "" : " ") +
                this.convertNumber(Hn) + " THOUSAND");
        }

        if (Dn) {
            res += (((res == "") ? "" : " ") +
                this.convertNumber(Dn) + " HUNDRED");
        }


        var ones = Array("", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN");
        var tens = Array("", "", "TWENTY", "THIRTY", "FOURTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY");

        if (tn > 0 || one > 0) {
            if (!(res == "")) {
                res += " AND ";
            }
            if (tn < 2) {
                res += ones[tn * 10 + one];
            }
            else {

                res += tens[tn];
                if (one > 0) {
                    res += ("-" + ones[one]);
                }
            }
        }

        if (res == "") {
            res = "ZERO";
        }
        return res;
    }

}
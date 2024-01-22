using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.NOAInfoReport
{
    public class NOAInfoRptModel
    {


    public Int32 Id { get; set; }
    public String NOANumber { get; set; }
    public DateTime? NOADate { get; set; }
    public Int32 CostCenterId { get; set; }
    public Decimal ContactValue { get; set; }
    public String NameofContract { get; set; }
    public DateTime? ContractDate { get; set; }
    public Decimal BudgetProvision { get; set; }
    public String AdministrativeApproved { get; set; }
    public String TechnicalApproved { get; set; }
    public String FinancialApproved { get; set; }
    public DateTime? AdministrativeDate { get; set; }
    public DateTime? TechnicalDate { get; set; }

    public DateTime? FinancialDate { get; set; }
    public String TenderNo { get; set; }
    public String NameofContractor { get; set; }
    public String ContractorAddress { get; set; }
    public Decimal SecurityMoney { get; set; }
    public DateTime? WorkStartOn { get; set; }
    public DateTime? CompilationDate { get; set; }
    public String MBNo { get; set; }
    public DateTime? voucherDate { get; set; }
    public Decimal grossAmount { get; set; }
    public Int32 NOAId { get; set; }
    public String paytoOrReciveFrom { get; set; }
    public String description { get; set; }
    public Int32 fundControlInformationId { get; set; }
    public Int32 ZoneID { get; set; }
    public Decimal debitSD { get; set; }
    public Decimal creditSD { get; set; }
    public Decimal BalanceSD { get; set; }
    public Decimal debitIT { get; set; }
    public Decimal creditIT { get; set; }
    public Decimal BalanceIT { get; set; }
    public Decimal debitVat { get; set; }
    public Decimal creditVat { get; set; }
    public Decimal BalanceVat { get; set; }

    public Decimal debitAdvance { get; set; }
    public Decimal creditAdvance { get; set; }
    public Decimal BalanceAdvance { get; set; }
    public String accountName { get; set; }
    public String chequeNo { get; set; }
    public DateTime chequeDate { get; set; }

    public String ZoneCode { get; set; }
    public String ZoneName { get; set; }
    public String ZoneAddress { get; set; }

    public decimal creditOther { get; set; }
    public string OtherAccountName { get; set; }
    public string PowerofAttorney { get; set; }
}
}
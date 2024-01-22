using Serenity;
using Serenity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Configurations.Entities;
using VistaGL.Transaction.Entities;
using VistaGL.Transaction.Repositories;

namespace VistaGL.Modules.Reports
{
    public class ReportSearchViewModel
    {

        #region Ctor
        public ReportSearchViewModel()
        {

            this.BudgetType = Enum.GetValues(typeof(BudgetTypeenum)).Cast<BudgetTypeenum>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            this.AccHeadTypeMapping = Enum.GetValues(typeof(AccHeadTypeMappingEnum)).Cast<AccHeadTypeMappingEnum>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            ConsolidateReceiptPayment = new List<ReceiptPaymentDetailsRptModel>();
        }
        #endregion

        #region common serarch parameters

        [DisplayName("Zone")]
        public string ZoneInfoList { get; set; }

        public int COAId { get; set; }

        public int BankId { get; set; }

        public int BranchId { get; set; }

        public int FundcontrolId { get; set; }

        [DisplayName("NOA Number")]
        public int? NoaId { get; set; }

        //   [Serenity.ComponentModel.LookupEditor(typeof(Configurations.Entities.AccAccountingPeriodInformationRow))]
        public int financialPeriodId { get; set; }

        public int VoucherTypeId { get; set; }

        public string TransactionType { get; set; }

        public string AdjustmentReportType { get; set; }

        public string ReportType { get; set; }

        public int Level { get; set; }

        public Boolean IsAdjusted { get; set; }

        [DisplayName("Bank Account")]
        public int BankAccountId { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }

        [DisplayName("From Date")]
        public DateTime? FromDate2 { get; set; }

        [DisplayName("To Date")]
        public DateTime? ToDate2 { get; set; }

        public int CostCenterId { get; set; }

        #endregion

        public Boolean IsAddYear { get; set; }

        #region Other Parameters

        [DisplayName("With Details")]
        public Boolean WithDetails { get; set; }

        [DisplayName("With Sub Ledger")]
        public Boolean IsWithCostCenter { get; set; }

        [DisplayName("With Pay to/Receive from")]
        public Boolean IsWithPayto { get; set; }

        [DisplayName("With Bill Ref.")]
        public Boolean IsWithBillRef { get; set; }

        [DisplayName("With Cheque No.")]
        public Boolean IsWithChequeNo { get; set; }

        [DisplayName("With Narration")]
        public Boolean IsWithNarration { get; set; }

        [DisplayName("With Linked Journal")]
        public Boolean IsWithLinkedJournal { get; set; }

        [DisplayName("With Opening")]
        public Boolean IsWithOpening { get; set; }

        [DisplayName("Pay To")]
        public string strPayTo { get; set; }

        public string Operator { get; set; }
        public IList<SelectListItem> OperatorLIst { get; set; }
        public decimal? Amount { get; set; }
        public string MemorandumNo { get; set; }
        public string Duplication { get; set; }

        public int ZoneInfoId { get; set; }

        #endregion

        #region report Parameters
        public string pZoneName { get; set; }
        public string pDeptName { get; set; }
        public string pEntityName { get; set; }
        public string pFinancialYear { get; set; }
        public string pAccountHead { get; set; }
        public string pAccountCode { get; set; }
        public string pBankAccountNo { get; set; }
        public string pBankName { get; set; }
        public string pCostCenter { get; set; }
        #endregion

        public List<ReceiptPaymentDetailsRptModel> ConsolidateReceiptPayment { get; set; }
        public String Title { get; set; }

        private SelectList _financialPeriod;
        public SelectList financialPeriod
        {
            get
            {
                var items = new List<AccAccountingPeriodInformationRow>();
                using (var connection = SqlConnections.NewFor<AccAccountingPeriodInformationRow>())
                {
                    items = connection.List<AccAccountingPeriodInformationRow>()
                        .Where(p => p.IsActive == true && p.IsClosed == false)
                        .OrderBy(o => o.YearName)
                        .ToList();
                }

                this._financialPeriod = new SelectList(items, "id", "YearName");

                return _financialPeriod;
            }
            set { _financialPeriod = value; }
        }


        private SelectList _financialPeriodForBudget;
        public SelectList financialPeriodForBudget
        {
            get
            {
                var items = new List<AccAccountingPeriodInformationRow>();
                using (var connection = SqlConnections.NewFor<AccAccountingPeriodInformationRow>())
                {
                    items = connection.List<AccAccountingPeriodInformationRow>()
                        //.Where(p => p.IsActive == true && p.IsClosed == false)
                        .OrderBy(o => o.YearName)
                        .ToList();
                }

                this._financialPeriodForBudget = new SelectList(items, "id", "YearName");

                return _financialPeriodForBudget;
            }
            set { _financialPeriodForBudget = value; }
        }


        private SelectList _Fundcontrol;
        public SelectList Fundcontrol
        {
            get
            {
                var items = new List<AccFundControlInformationRow>();
                using (var connection = SqlConnections.NewFor<AccFundControlInformationRow>())
                {
                    items = connection.List<AccFundControlInformationRow>();

                }

                this._Fundcontrol = new SelectList(items, "id", "FundControlName");

                return _Fundcontrol;
            }
            set { _Fundcontrol = value; }
        }

        class clsZoneIds
        {
            public int? ZoneId { get; set; }
        }
        private IList<SelectListItem> _Zone;
        public IList<SelectListItem> Zone
        {
            get
            {
                var user = (UserDefinition)Authorization.UserDefinition;

                var sortZoneList = new List<PrmZoneInfoRow>();
                var userZoneList = new List<clsZoneIds>();
                using (var connection = SqlConnections.NewFor<PrmZoneInfoRow>())
                {
                    userZoneList = connection.Query<clsZoneIds>("SELECT ZoneId FROM TblUserZone WHERE EmpId = '" + user.Username + "'").ToList();
                    sortZoneList = connection.List<PrmZoneInfoRow>()
                        .Where(x => userZoneList.Select(s => s.ZoneId).Contains(x.Id))
                        .OrderBy(s => s.SortOrder)
                        .ToList();
                }

                var resultList = new List<SelectListItem>();
                foreach (var item in sortZoneList)
                {
                    if (sortZoneList.Count == 1)
                    {
                        resultList.Add(new SelectListItem()
                        {
                            Text = item.ZoneName,
                            Value = item.Id.ToString(),
                            Selected = true
                        });
                    }
                    else
                    {
                        resultList.Add(new SelectListItem()
                        {
                            Text = item.ZoneName,
                            Value = item.Id.ToString()
                        });
                    }

                }

                this._Zone = resultList;
                return _Zone;
            }
            set { _Zone = value; }
        }

        private SelectList _VoucherType;
        public SelectList VoucherType
        {
            get
            {
                var items = new List<AccVoucherTypeRow>();
                using (var connection = SqlConnections.NewFor<AccVoucherTypeRow>())
                {
                    items = connection.List<AccVoucherTypeRow>();
                }
                this._VoucherType = new SelectList(items, "id", "Name");

                return _VoucherType;
            }
            set { _VoucherType = value; }
        }

        private SelectList _BankAccount;
        public SelectList BankAccount
        {
            get
            {
                //var items = new List<AccBankAccountInformationRow>();
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                using (var connection = SqlConnections.NewFor<AccBankAccountInformationRow>())
                {

                    //var ba = connection.List<AccBankAccountInformationRow>();

                    var tblBaAlias = AccBankAccountInformationRow.Fields.As("tblBaAlias");
                    var query = new SqlQuery()
                        .Select(tblBaAlias.Id)
                        .Select(tblBaAlias.CoaId)
                        .Select(tblBaAlias.AccountNumber)
                        .From(tblBaAlias)
                        .Where(tblBaAlias.EntityId == user.FundControlInformationId
                               & tblBaAlias.ZoneInfoId == user.ZoneID)
                        .OrderBy(tblBaAlias.AccountName);
                    var ba = connection.Query<AccBankAccountInformationRow>(query).ToList();

                    //var ca = connection.List<AccChartofAccountsRow>();
                    var tblCoaAlias = AccChartofAccountsRow.Fields.As("tblCoaAlias");
                    var queryCOA = new SqlQuery()
                        .Select(tblCoaAlias.Id)
                        .Select(tblCoaAlias.AccountName)
                        .From(tblCoaAlias)
                        .Where(tblCoaAlias.FundControlId == user.FundControlInformationId)
                        .OrderBy(tblCoaAlias.AccountName);
                    var ca = connection.Query<AccChartofAccountsRow>(queryCOA).ToList();

                    var r = (from bas in ba
                             join cas in ca on bas.CoaId equals cas.Id
                             select new
                             {
                                 id = bas.Id,
                                 accountNumber = bas.AccountNumber + " - " + cas.AccountName
                             }).ToList();


                    //var query = connection.Query<CustomBankAccount>(
                    //    "SELECT ba.Id, ba.accountNumber + ' [' + ca.accountName + ']' as accountNumber " +
                    //    "FROM acc_BankAccountInformation ba " +
                    //    "INNER JOIN " +
                    //    "acc_ChartofAccounts ca ON ba.COAId = ca.id").ToList();

                    this._BankAccount = new SelectList(r, "id", "accountNumber");
                    //items = connection.List<AccBankAccountInformationRow>();
                }
                //this._BankAccount = new SelectList(items, "id", "accountNumber");

                return _BankAccount;
            }
            set { _BankAccount = value; }
        }

        private SelectList _COAAll;
        public SelectList COAAll
        {
            get
            {
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                var items = new List<AccChartofAccountsRow>();
                using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
                {
                    //var c = new Configurations.Repositories.AccChartofAccountsRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { })
                    //    .Entities
                    //    .Where(p => p.FundControlId == user.FundControlInformationId)
                    //    .OrderBy(o => o.AccountName)
                    //    .ToList();

                    var tblCoaAlias = AccChartofAccountsRow.Fields.As("tblCoaAlias");
                    var query = new SqlQuery()
                        .Select(tblCoaAlias.Id)
                        .Select(tblCoaAlias.AccountName)
                        .From(tblCoaAlias)
                        .Where(tblCoaAlias.FundControlId == user.FundControlInformationId)
                        .OrderBy(tblCoaAlias.AccountName);
                    items = connection.Query<AccChartofAccountsRow>(query).ToList();
                }

                this._COAAll = new SelectList(items, "id", "AccountName");

                return _COAAll;
            }
            set { _COAAll = value; }
        }


        private SelectList _COABank;
        public SelectList COABank
        {
            get
            {
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                var items = new List<AccChartofAccountsRow>();
                using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
                {
                    //var c = new Configurations.Repositories.AccChartofAccountsRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { })
                    //    .Entities
                    //    .Where(p => p.CoaMapping == "BANK" && p.FundControlId == user.FundControlInformationId)
                    //    .OrderBy(o => o.AccountName)
                    //    .ToList();

                    var tblCoaAlias = AccChartofAccountsRow.Fields.As("tblCoaAlias");
                    var query = new SqlQuery()
                        .Select(tblCoaAlias.Id)
                        .Select(tblCoaAlias.AccountName)
                        .From(tblCoaAlias)
                        .Where(tblCoaAlias.CoaMapping == "BANK"
                               & tblCoaAlias.FundControlId == user.FundControlInformationId)
                        .OrderBy(tblCoaAlias.AccountName);
                    items = connection.Query<AccChartofAccountsRow>(query).ToList();
                }

                this._COABank = new SelectList(items, "id", "AccountName");

                return _COABank;
            }
            set { _COABank = value; }
        }

        private SelectList _COACash;
        public SelectList COACash
        {
            get
            {
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                var items = new List<AccChartofAccountsRow>();
                using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
                {
                    //var c = new Configurations.Repositories.AccChartofAccountsRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { })
                    //    .Entities
                    //    .Where(p => p.CoaMapping == "CASH" && p.FundControlId == user.FundControlInformationId)
                    //    .OrderBy(o => o.AccountName)
                    //    .ToList();

                    var tblCoaAlias = AccChartofAccountsRow.Fields.As("tblCoaAlias");
                    var query = new SqlQuery()
                        .Select(tblCoaAlias.Id)
                        .Select(tblCoaAlias.AccountName)
                        .From(tblCoaAlias)
                        .Where(tblCoaAlias.CoaMapping == "CASH"
                               & tblCoaAlias.FundControlId == user.FundControlInformationId)
                        .OrderBy(tblCoaAlias.AccountName);
                    items = connection.Query<AccChartofAccountsRow>(query).ToList();
                }

                this._COACash = new SelectList(items, "id", "AccountName");

                return _COACash;
            }
            set { _COACash = value; }
        }

        [DisplayName("Department")]
        public string SelectedDeptList { get; set; }

        #region Zone wise Department List
        private SelectList _zoneWiseDepartments;
        public SelectList ZoneWiseDepartments
        {
            get
            {
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                var items = new List<PrmDepartmentRow>();
                using (var connection = SqlConnections.NewFor<PrmDepartmentRow>())
                {
                    var dep = PrmDepartmentRow.Fields.As("dep");
                    var query = new SqlQuery()
                        .Select(dep.Id)
                        .Select(dep.Name)
                        .From(dep)
                        .Where(dep.ZoneInfoId == user.ZoneID);

                    items = connection.Query<PrmDepartmentRow>(query).ToList();
                }

                this._zoneWiseDepartments = new SelectList(items, "Id", "Name");

                return _zoneWiseDepartments;
            }
            set { _zoneWiseDepartments = value; }
        }
        #endregion

        #region COA Parent HEAD
        private SelectList _COAParent;
        public SelectList COAParent
        {
            get
            {
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                var items = new List<AccChartofAccountsRow>();
                using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
                {
                    //var c = new Configurations.Repositories.AccChartofAccountsRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { })
                    //    .Entities
                    //    .Where(p => p.IsControlhead == 1)
                    //    .ToList();

                    var tblCoaAlias = AccChartofAccountsRow.Fields.As("tblCoaAlias");
                    var query = new SqlQuery()
                        .Select(tblCoaAlias.Id)
                        .Select(tblCoaAlias.AccountName)
                        .From(tblCoaAlias)
                        .Where(tblCoaAlias.IsControlhead == 1
                            & tblCoaAlias.FundControlId == user.FundControlInformationId)
                        .OrderBy(tblCoaAlias.AccountName);
                    items = connection.Query<AccChartofAccountsRow>(query).ToList();
                }

                this._COAParent = new SelectList(items, "id", "AccountName");

                return _COAParent;
            }
            set { _COAParent = value; }
        }
        #endregion

        #region COA CHILD HEAD
        private SelectList _COAChild;
        public SelectList COAChild
        {
            get
            {
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                var items = new List<AccChartofAccountsRow>();
                using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
                {
                    //Configurations.Repositories.AccChartofAccountsRepository c = new Configurations.Repositories.AccChartofAccountsRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { })
                    //    .Entities
                    //    .Where(p => p.IsControlhead == 0)
                    //    .ToList();

                    var tblCoaAlias = AccChartofAccountsRow.Fields.As("tblCoaAlias");
                    var query = new SqlQuery()
                        .Select(tblCoaAlias.Id)
                        .Select(tblCoaAlias.AccountName)
                        .From(tblCoaAlias)
                        .Where(tblCoaAlias.IsControlhead == 0
                               & tblCoaAlias.FundControlId == user.FundControlInformationId)
                        .OrderBy(tblCoaAlias.AccountName);
                    items = connection.Query<AccChartofAccountsRow>(query).ToList();
                }
                this._COAChild = new SelectList(items, "id", "AccountName");

                return _COAChild;
            }
            set { _COAChild = value; }
        }

        private SelectList _COAChildBank;
        public SelectList COAChildBank
        {
            get
            {
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                var items = new List<AccChartofAccountsRow>();
                using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
                {
                    //Configurations.Repositories.AccChartofAccountsRepository c = new Configurations.Repositories.AccChartofAccountsRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { })
                    //    .Entities
                    //    .Where(p => p.IsControlhead == 0 && p.CoaMapping == "BANK")
                    //    .ToList();

                    var tblCoaAlias = AccChartofAccountsRow.Fields.As("tblCoaAlias");
                    var query = new SqlQuery()
                        .Select(tblCoaAlias.Id)
                        .Select(tblCoaAlias.AccountName)
                        .From(tblCoaAlias)
                        .Where(tblCoaAlias.IsControlhead == 0
                                & tblCoaAlias.CoaMapping == "BANK"
                                & tblCoaAlias.FundControlId == user.FundControlInformationId)
                        .OrderBy(tblCoaAlias.AccountName);
                    items = connection.Query<AccChartofAccountsRow>(query).ToList();
                }

                this._COAChildBank = new SelectList(items, "id", "AccountName");

                return _COAChildBank;
            }
            set { _COAChildBank = value; }
        }

        private SelectList _NOANumberList;
        public SelectList NOANumberList
        {
            get
            {
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                var items = new List<AccNoaRow>();
                using (var connection = SqlConnections.NewFor<AccNoaRow>())
                {
                    //var c = new AccNoaRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { })
                    //    .Entities
                    //    .ToList();

                    var tblNoaAlias = AccNoaRow.Fields.As("tblNOAAlias");
                    var query = new SqlQuery()
                        .Select(tblNoaAlias.Id)
                        .Select(tblNoaAlias.NoaNumber)
                        .From(tblNoaAlias)
                        .Where(tblNoaAlias.ZoneInfoId == user.ZoneID)
                        .OrderBy(tblNoaAlias.NoaNumber);
                    items = connection.Query<AccNoaRow>(query).ToList();
                }

                this._NOANumberList = new SelectList(items, "Id", "NoaNumber");
                return _NOANumberList;
            }
            set { _NOANumberList = value; }
        }
        #endregion

        #region Budget Type

        public int BudgetTypeId { get; set; }
        public List<SelectListItem> BudgetType { get; set; }

        #endregion

        #region Sub Ledger

        private SelectList _CostCenter;
        public SelectList CostCenterList
        {
            get
            {
                var items = new List<AccCostCentreOrInstituteInformationRow>();
                using (var connection = SqlConnections.NewFor<AccCostCentreOrInstituteInformationRow>())
                {
                    //var c = new AccCostCentreOrInstituteInformationRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { })
                    //    .Entities
                    //    .Where(q => q.IsInstitute == false)
                    //    .ToList();

                    var costAlias = AccCostCentreOrInstituteInformationRow.Fields.As("costAlias");
                    var costQuery = new SqlQuery()
                        .Select(costAlias.Id)
                        .Select(costAlias.UserCode)
                        .Select(costAlias.Name)
                        .From(costAlias)
                        .Where(costAlias.IsInstitute == 0)
                        .OrderBy(costAlias.Name);
                    items = connection.Query<AccCostCentreOrInstituteInformationRow>(costQuery).ToList();
                }

                var r = (from cost in items
                         select new
                         {
                             id = cost.Id,
                             name = cost.UserCode + " - " + cost.Name
                         }).ToList();

                this._CostCenter = new SelectList(r, "id", "name");

                return _CostCenter;
            }
            set { _CostCenter = value; }
        }

        private SelectList _allCostCenters;
        public SelectList AllCostCenters
        {
            get
            {
                var items = new List<AccCostCentreOrInstituteInformationRow>();
                using (var connection = SqlConnections.NewFor<AccCostCentreOrInstituteInformationRow>())
                {
                    //var c = new AccCostCentreOrInstituteInformationRepository();
                    //items = c.List(connection, new Serenity.Services.ListRequest() { }).Entities.ToList();

                    var costAlias = AccCostCentreOrInstituteInformationRow.Fields.As("costAlias");
                    var costQuery = new SqlQuery()
                        .Select(costAlias.Id)
                        .Select(costAlias.UserCode)
                        .Select(costAlias.Name)
                        .From(costAlias)
                        .OrderBy(costAlias.Name);
                    items = connection.Query<AccCostCentreOrInstituteInformationRow>(costQuery).ToList();
                }

                var r = (from cost in items
                         select new
                         {
                             id = cost.Id,
                             name = cost.UserCode + " - " + cost.Name
                         }).ToList();

                this._allCostCenters = new SelectList(r, "id", "name");
                return _allCostCenters;
            }
            set { _allCostCenters = value; }
        }
        #endregion

        #region ReportTypes
        public int ReportTypeId { get; set; }

        private SelectList _reportType;
        public SelectList ReportTypeList
        {
            get
            {
                var items = new List<AccReportTypeRow>();
                using (var connection = SqlConnections.NewFor<AccReportTypeRow>())
                {

                    var rt = AccReportTypeRow.Fields.As("rt");
                    var rtQuery = new SqlQuery()
                        .Select(rt.Id)
                        .Select(rt.ReportType)
                        .From(rt)
                        .OrderBy(rt.ReportType);
                    items = connection.Query<AccReportTypeRow>(rtQuery).ToList();
                }

                var r = (from rt in items
                         select new
                         {
                             id = rt.Id,
                             name = rt.ReportType
                         }).ToList();

                this._reportType = new SelectList(r, "id", "name");

                return _reportType;
            }
            set { _reportType = value; }
        }

        #endregion


        #region Payto

        private List<SelectListItem> _paytoList;
        [DisplayName("Pay to/Receive From")]
        public List<SelectListItem> PaytoList
        {
            get
            {
                List<String> items = new List<String>();
                using (var connection = SqlConnections.NewFor<AccBankInformationRow>())
                {
                    string paytoQuery = @"SELECT DISTINCT paytoOrReciveFrom as 'Name'
                                            FROM acc_voucher_information
                                            ORDER BY paytoOrReciveFrom";
                    items = connection.Query<String>(paytoQuery).ToList();
                }

                this._paytoList = items.Select(a => new SelectListItem
                {
                    Text = a,
                    Value = a
                }).ToList();

                return _paytoList;
            }
            set { _paytoList = value; }
        }

        #endregion

        #region Bank
        private SelectList _Bank;
        public SelectList Bank
        {
            get
            {
                List<AccBankInformationRow> items = new List<AccBankInformationRow>();
                using (var connection = SqlConnections.NewFor<AccBankInformationRow>())
                {
                    //items = connection.List<AccBankInformationRow>();

                    var tblBankAlias = AccBankInformationRow.Fields.As("tblBankAlias");
                    var costQuery = new SqlQuery()
                        .Select(tblBankAlias.Id)
                        .Select(tblBankAlias.BankName)
                        .From(tblBankAlias)
                        .OrderBy(tblBankAlias.BankName);
                    items = connection.Query<AccBankInformationRow>(costQuery).ToList();
                }
                this._Bank = new SelectList(items, "id", "bankName");

                return _Bank;
            }
            set { _Bank = value; }
        }
        #endregion


        #region Acc Head Type Mapping

        [DisplayName("Account Head Type")]
        public string accHeadTypeMappingList { get; set; }
        public List<SelectListItem> AccHeadTypeMapping { get; set; }

        #endregion

        #region Bank Branch
        private SelectList _BankBranch;
        public SelectList BankBranch
        {
            get
            {
                List<AccBankBranchInformationRow> items = new List<AccBankBranchInformationRow>();
                using (var connection = SqlConnections.NewFor<AccBankBranchInformationRow>())
                {
                    //items = connection.List<AccBankBranchInformationRow>();

                    var tblBranchAlias = AccBankBranchInformationRow.Fields.As("tblBranchAlias");
                    var costQuery = new SqlQuery()
                        .Select(tblBranchAlias.Id)
                        .Select(tblBranchAlias.BranchName)
                        .From(tblBranchAlias)
                        .OrderBy(tblBranchAlias.BranchName);
                    items = connection.Query<AccBankBranchInformationRow>(costQuery).ToList();
                }
                this._BankBranch = new SelectList(items, "id", "branchName");

                return _BankBranch;
            }
            set { _BankBranch = value; }
        }
        #endregion

        #region Financial Report only
        public Int32 ParentCOAId { get; set; }
        private SelectList _ParentCOAList;
        public SelectList ParentCOAList
        {
            get
            {
                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                var items = new List<AccChartofAccountsRow>();
                using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
                {
                    var query = @"SELECT DISTINCT C1.* FROM acc_FinancialReportsDetails F
                                    INNER JOIN acc_ChartofAccounts C ON F.COAId = C.id
                                    INNER JOIN acc_ChartofAccounts C1 ON C.parentAccountId = C1.id
                                    WHERE F.ReportType = 'ADO' AND F.EntityId = " + user.FundControlInformationId;
                    items = connection.Query<AccChartofAccountsRow>(query).ToList();
                }

                this._ParentCOAList = new SelectList(items, "id", "AccountName");

                return _ParentCOAList;
            }
            set { _ParentCOAList = value; }
        }
        #endregion

        public bool ShowDashboardButton { get; set; }

        [DisplayName("Only Posted Voucher")]
        public bool IsOnlyPostedVoucher { get; set; }

        [DisplayName("Show with voucher no.")]
        public Boolean ShowWithVoucherNo { get; set; }

        [DisplayName("Show Sub-Ledger Wise Total")]
        public Boolean ShowSubledgerWiseTotal { get; set; }

        [DisplayName("Show subledgers without parent (Applicable for only Account Head selection.)")]
        public Boolean ShowSubledgersWithoutParent { get; set; }

        public String BankReconcileType { get; set; }
        public String ReceiptsPaymentsReportType { get; set; }

        [DisplayName("Show in Receipt-Payment Format (Applicable for only selected account head)")]
        public Boolean ShowInReceiptPaymentFormat { get; set; }

        [DisplayName("Tree View")]
        public Boolean IsTreeView { get; set; }

        [DisplayName("Report by Account Head")]
        public Boolean IsGroupbyCOA { get; set; }

        public String Message { get; set; }
        public Boolean IsError { get; set; }
        public String ErrMsgClass { get; set; }

        public Boolean HideChildren { get; set; }

        [DisplayName("Open Report in New Tab")]
        public Boolean IsOpenReportInNewTab { get; set; }
    }


    public class CustomBankAccount
    {
        public int id { get; set; }
        public String accountNumber { get; set; }
    }

}
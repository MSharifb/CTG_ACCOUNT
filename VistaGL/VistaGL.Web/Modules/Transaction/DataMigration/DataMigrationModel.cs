using Serenity;
using Serenity.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Transaction.Entities;
using VistaGL.Transaction.Repositories;

namespace VistaGL.Transaction
{

    public class ACINF
    {
        public String ACCODE { get; set; }
        public String ACDESC { get; set; }
    }

    public class STPINF
    {
        public String SPCODE { get; set; }
        public String SPDESC { get; set; }
    }

    public class DataMigrationModel
    {
        public DataMigrationModel()
        {

        }

        public int ZoneInfoId { get; set; }

        public int? demoCOA_ERPSystem { get; set; }
        public String demoCOA_OldSystem { get; set; }

        public String ErrMsg { get; set; }
        public string errClass { get; set; }

        public Boolean ShowMappdReport { get; set; }

        #region Sub Ledger - OLD System

        public String demoCostCenter_OldSystemId { get; set; }

        private SelectList _demoCostCenter_OldSystemList;
        public SelectList demoCostCenter_OldSystemList
        {
            get
            {
                //UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                //DynamicParameters param = new DynamicParameters();
                //param.Add("@ZoneId", user.ZoneID);
                //param.Add("@FundControlId", user.FundControlInformationId);
                //param.Add("@isFromOldDB", false);

                //var items = new List<ACINF>();
                //using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
                //{
                //    items = connection.Query<ACINF>("ACC_sp_GetACINFByZone", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
                //}

                UserDefinition user = (UserDefinition)Authorization.UserDefinition;
                DynamicParameters param = new DynamicParameters();
                param.Add("@ZoneId", user.ZoneID);
                param.Add("@FundControlId", user.FundControlInformationId);
                param.Add("@isFromOldDB", false);

                var items = new List<STPINF>();
                using (var connection = SqlConnections.NewFor<AccCostCentreOrInstituteInformationRow>())
                {
                    items = connection.Query<STPINF>("ACC_sp_GetSTPINFByZone", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
                }


                var r = (from cost in items
                         select new
                         {
                             id = cost.SPCODE,
                             name = cost.SPDESC
                         }).ToList();

                this._demoCostCenter_OldSystemList = new SelectList(r, "id", "name");

                return _demoCostCenter_OldSystemList;
            }
            set { _demoCostCenter_OldSystemList = value; }
        }
        #endregion

        #region Sub Ledger - ERP System

        public int? demoCostCenter_ERPSystemId { get; set; }

        private SelectList _demoCostCenter_ERPSystemList;
        public SelectList demoCostCenter_ERPSystemList
        {
            get
            {
                var items = new List<AccCostCentreOrInstituteInformationRow>();
                using (var connection = SqlConnections.NewFor<AccCostCentreOrInstituteInformationRow>())
                {
                    var c = new AccCostCentreOrInstituteInformationRepository();
                    items = c.List(connection, new Serenity.Services.ListRequest() { })
                        .Entities
                        .Where(q => q.IsInstitute == false)
                        .ToList();
                }

                var r = (from cost in items
                         select new
                         {
                             id = cost.Id,
                             name = cost.UserCode + " - " + cost.Name
                         }).ToList();

                this._demoCostCenter_ERPSystemList = new SelectList(r, "id", "name");

                return _demoCostCenter_ERPSystemList;
            }
            set { _demoCostCenter_ERPSystemList = value; }
        }
        #endregion




    }


    public class MappedReportModel
    {
        public MappedReportModel()
        {
            //
        }

        public String SPCODE { get; set; }
        public String SPDESC { get; set; }

        public String userCode { get; set; }
        public String Subledger { get; set; }

    }
}
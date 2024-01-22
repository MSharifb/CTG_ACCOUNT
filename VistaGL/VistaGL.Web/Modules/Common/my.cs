using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VistaGL.Transaction.Repositories;

namespace VistaGL.Modules.Common
{
    public static class my
    {
        public static List<AVP_InitialStep> GetApproverList(int zoneId, string processName= "AccVou", int exceptEmployeeId = 0, ApprovalStepType approvalStepType = ApprovalStepType.Both)
        {
            var param = new DynamicParameters();
            param.Add("@ZoneId", zoneId);
            param.Add("@ApprovalProcess", processName);
            param.Add("@EmployeeId", exceptEmployeeId);
            param.Add("@ApprovalStepTypeId", approvalStepType); // 2 - Approver

            List<AVP_InitialStep> result = new List<AVP_InitialStep>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ACCDB"].ToString()))
            {
                result = con.Query<AVP_InitialStep>("ACC_getApproverListByZoneId", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }
    }
}
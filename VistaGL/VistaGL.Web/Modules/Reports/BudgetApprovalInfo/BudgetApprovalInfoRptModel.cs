using System;

namespace VistaGL.Modules.Reports
{
    public class BudgetApprovalInfoRptModel
    {

        public int BudgetForDepartmentId { get; set; }
        public int DepartmentId { get; set; }
        public String DeptName { get; set; }
        public int FromAppoverId { get; set; }
        public String FromApprover { get; set; }
        public DateTime createdUserDate { get; set; }
        public int ApprovalStatusId { get; set; }
        public String ApprovalStatus
        {
            get
            {
                var approvalStatus = (ApprovalStatus)ApprovalStatusId;
                return approvalStatus.ToString();
            }
        }
        public int ToApproverId { get; set; }
        public String ToApprover { get; set; }

    }
}
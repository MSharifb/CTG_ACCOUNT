using System;

namespace VistaGL.Modules.Reports
{
    public class GratuityStatementRptModel
    {

        public String FullName { get; set; }
        public String EmpID { get; set; }
        public String Desig { get; set; }
        public Int32? DesigSortOrder { get; set; }
        public String StaffCategpry { get; set; }
        public DateTime? DateofJoining { get; set; }
        public Int32? Service_Length { get; set; }
        public Decimal BasicAmount { get; set; }
        public Decimal TotalGratuity { get; set; }
        public Decimal TotalGratuityPreviousYear { get; set; }
        public Decimal RequiredBalance { get; set; }
        public String WorkingZone { get; set; }
        public Int32? ZoneSortOrder { get; set; }
        public String EmployeeStatus { get; set; }

    }
}
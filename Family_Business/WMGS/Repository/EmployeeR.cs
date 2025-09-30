using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.Repository
{
    public class EmployeeR
    {
        public int Id { get; set; }
        public string EID { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string FullName { get; set; }
        public string EIDnFullName { get; set; }
        public string EmpPhone { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        public DateTime? DateofBirth { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public int Status { get; set; }
        public int EmpGender { get; set; }
        public string EMP_Status { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string EmpNominee { get; set; }
        public string EmpNomineePhone { get; set; }
        public string EmpShift { get; set; }
        public string Remarks { get; set; }
        public decimal? EmpPay { get; set; }
        public decimal? PayRate { get; set; }
        public decimal? Total_Payment { get; set; }
        public decimal? Incentive { get; set; }
        public decimal? Benefits { get; set; }
        public decimal? TotalWorkHour { get; set; }
        public bool? OffDayStatus { get; set; }
        public string OffDay { get; set; }
        public DateTime? JoiningDate { get; set; }
        public bool? ConfirmStatus { get; set; }

        public string WorkStatus { get; set; }
    }
}
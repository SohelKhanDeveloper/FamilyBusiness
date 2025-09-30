using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.Repository
{
    public class SalaryR
    {
        public int id { get; set; }
        public string EID { get; set; }
        public string FullName { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public decimal? TotalWorkingHour { get; set; }
        public decimal? EmpPay { get; set; }
        public decimal? totalPayAmt { get; set; }
        public string Status { get; set; }
        public decimal? Benefits { get; set; }
        public string Remarks { get; set; }
    }
}
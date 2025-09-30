using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.Repository
{
    public class AttendanceR
    {
        public int Id { get; set; }
        public string EID { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string FullName { get; set; }
        public string EIDnFullName { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public DateTime? ProcessDate { get; set; }
        public DateTime? AttendanceFromDate { get; set; }
        public DateTime? AttendanceToDate { get; set; }
        public decimal? Total_Hour { get; set; }
        public string Status { get; set; }
        public string Attendance_Day { get; set; }
        public bool? AttendanceProcessStatus { get; set; }
        public string Remarks { get; set; }

        public TimeSpan In_Time { get; set; }
        public TimeSpan Out_Time { get; set; }

    }
}
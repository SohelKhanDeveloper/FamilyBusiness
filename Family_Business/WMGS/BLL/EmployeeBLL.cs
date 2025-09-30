using Family_Business.WMGS.DAL;
using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.BLL
{
    
    public class EmployeeBLL
    {
        EmployeeDAL sEmployeeDAL = new EmployeeDAL();

        internal int SaveEmployee(tbl_EmpPersonalInfo stbl_Employee)
        {
            return sEmployeeDAL.SaveEmployee(stbl_Employee);
        }

        internal List<EmployeeR> GetAllEmployeeList()
        {
            return sEmployeeDAL.GetAllEmployeeList();
        }

        internal List<tbl_Genders> GetGender()
        {
            return sEmployeeDAL.GetGender();
        }
        internal List<tbl_EmpStatus> GetStatus()
        {
            return sEmployeeDAL.GetStatus();
        }

        internal int UpdateEmployee(tbl_EmpPersonalInfo stbl_Employee, int empId)
        {
            return sEmployeeDAL.UpdateEmployee(stbl_Employee,empId);
        }

        internal tbl_EmpPersonalInfo GetEmpById(string eId)
        {
            return sEmployeeDAL.GetEmpById(eId);
        }

        internal int DeleteShopById(string empId)
        {
            return sEmployeeDAL.DeleteShopById(empId);
        }

        internal int CreateUser(tbl_Users stblUser)
        {
            return sEmployeeDAL.CreateUser(stblUser);
        }



        internal int InsertAttendance(List<tbl_EmpAttendance> stbl_Attendance)
        {
            return sEmployeeDAL.InsertAttendance(stbl_Attendance);
        }

        internal List<AttendanceR> GetAllAttendance()
        {
            return sEmployeeDAL.GetAllAttendance();
        }      

        internal List<EmployeeR> GetOffDayList()
        {
            return sEmployeeDAL.GetOffDayList();
        }

        internal int SaveOffDay(tbl_EmpOffDay stbl_EmpOffDay)
        {
            return sEmployeeDAL.SaveOffDay(stbl_EmpOffDay);
        }

        internal List<tbl_DayName> GetAllDayList()
        {
            return sEmployeeDAL.GetAllDayList();
        }
        internal int UpdateOffDay(tbl_EmpOffDay stbl_EmpOffDay, int offDayId)
        {
            return sEmployeeDAL.UpdateOffDay(stbl_EmpOffDay, offDayId);
        }

        internal tbl_EmpOffDay GetOffDayById(string offId)
        {
            return sEmployeeDAL.GetOffDayById(offId);
        }

        internal int DeleteOffDayById(string offId)
        {
            return sEmployeeDAL.DeleteOffDayById(offId);
        }

        internal int InsertConfirmAttendance(List<tbl_AttendanceConfirm> attenCon)
        {
            return sEmployeeDAL.InsertConfirmAttendance(attenCon);
        }

        internal int UpdateAttenConfirmTableTotalHour(tbl_AttendanceConfirm _Confirm, string eid, DateTime attenDate, string attenDay)
        {
            return sEmployeeDAL.UpdateAttenConfirmTableTotalHour(_Confirm, eid, attenDate, attenDay);
        }

        
        internal List<SalaryR> GetDataListForSalary()
        {
            return sEmployeeDAL.GetDataListForSalary();
        }


        internal int InsertSalary(List<tbl_ProcesedSalary> lst_salary)
        {
            return sEmployeeDAL.InsertSalary(lst_salary);
        }

        internal List<EmployeeR> GetAllEmployeeReport()
        {
            return sEmployeeDAL.GetAllEmployeeReport();
        }

        internal List<EmployeeR> GetAllEmployeeSalaryReport()
        {
            return sEmployeeDAL.GetAllEmployeeSalaryReport();
        }

        internal List<AttendanceR> GetAllEmployeeAttendanceReport()
        {
            return sEmployeeDAL.GetAllEmployeeAttendanceReport();
        }

        internal List<AttendanceR> GetEmployeeJobCard(string eid, DateTime fromdate, DateTime todate)
        {
            return sEmployeeDAL.GetEmployeeJobCard(eid, fromdate, todate);
        }



        internal List<EmployeeR> GetEmployeePaySlip(string eid, DateTime fromdate, DateTime todate)
        {
            return sEmployeeDAL.GetEmployeePaySlip(eid, fromdate, todate);
        }

        internal List<ProductR> GetAllProduct()
        {
            return sEmployeeDAL.GetAllProduct();
        }
    }
}
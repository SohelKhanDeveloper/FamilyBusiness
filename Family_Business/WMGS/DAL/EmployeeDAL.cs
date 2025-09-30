using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.DAL
{
    public class EmployeeDAL
    {
        FamilyBusinessEntities sContext = new FamilyBusinessEntities();

        internal int SaveEmployee(tbl_EmpPersonalInfo stbl_Employee)
        {
            sContext.tbl_EmpPersonalInfo.Add(stbl_Employee);
            sContext.SaveChanges();
            return 1;
        }

        internal List<EmployeeR> GetAllEmployeeList()
        {
            try
            {


                return (from a in sContext.tbl_EmpPersonalInfo
                        join b in sContext.tbl_Genders on a.EmpGender equals b.Id
                        join c in sContext.tbl_EmpStatus on a.Status equals c.Id
                        orderby a.Id descending
                        select new EmployeeR
                        {
                            Id=a.Id,
                            EID = a.EID,
                            FullName = a.EmpFirstName ?? "" + " " + a.EmpLastName ?? "",//a.EmpFirstName +" " + a.EmpLastName,
                            EIDnFullName = a.EID + "-" + a.EmpFirstName ?? "" + " " + a.EmpLastName ?? "",
                            EmpPhone = a.EmpPhone,
                            EmpEmail = a.EmpEmail,
                            EmpAddress = a.EmpAddress,
                            DateofBirth = a.DateofBirth,
                            Gender = b.Gender,
                            EMP_Status=c.EMP_Status,
                            Education = a.Education,
                            EmpNominee=a.EmpNominee,
                            EmpNomineePhone=a.EmpNomineePhone,
                            EmpShift = a.EmpShift,
                            EmpPay=a.EmpPay,
                            JoiningDate=a.JoiningDate,
                            //ConfirmStatus = a.ConfirmStatus = false ? "Inactive" : "Active", //a.ConfirmStatus 
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<tbl_Genders> GetGender()
        {
            try
            {
                var query = (from itm in sContext.tbl_Genders
                             select itm).OrderBy(x => x.Id);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        internal List<tbl_EmpStatus> GetStatus()
        {
            try
            {
                var query = (from itm in sContext.tbl_EmpStatus
                             select itm).OrderBy(x => x.Id);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        internal int UpdateEmployee(tbl_EmpPersonalInfo stbl_Employee, int empId)
        {
            tbl_EmpPersonalInfo objproduct = sContext.tbl_EmpPersonalInfo.First(x => x.Id == empId);
            objproduct.EmpFirstName = stbl_Employee.EmpFirstName;
            objproduct.EmpLastName = stbl_Employee.EmpLastName;
            objproduct.EmpPhone = stbl_Employee.EmpPhone;
            objproduct.EmpEmail = stbl_Employee.EmpEmail;
            objproduct.EmpAddress = stbl_Employee.EmpAddress;
            objproduct.DateofBirth = stbl_Employee.DateofBirth;
            objproduct.EmpGender = stbl_Employee.EmpGender;
            objproduct.Status = stbl_Employee.Status;
            objproduct.Education = stbl_Employee.Education;
            objproduct.EmpNominee = stbl_Employee.EmpNominee;
            objproduct.EmpNomineePhone = stbl_Employee.EmpNomineePhone;
            objproduct.EmpShift = stbl_Employee.EmpShift;
            objproduct.EmpPay = stbl_Employee.EmpPay;
            objproduct.JoiningDate = stbl_Employee.JoiningDate;
            objproduct.ConfirmStatus = stbl_Employee.ConfirmStatus;
            sContext.SaveChanges();
            return 1;
        }

        internal tbl_EmpPersonalInfo GetEmpById(string eId)
        {
            try
            {
                int eid = Convert.ToInt16(eId);

                tbl_EmpPersonalInfo sale = sContext.tbl_EmpPersonalInfo.First(x => x.Id == eid);

                return sale;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int DeleteShopById(string empId)
        {
            try
            {
                int objID = Convert.ToInt32(empId);
                tbl_EmpPersonalInfo objId = sContext.tbl_EmpPersonalInfo.First(x => x.Id == objID);
                sContext.tbl_EmpPersonalInfo.Remove(objId);
                sContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int CreateUser(tbl_Users stblUser)
        {
            sContext.tbl_Users.Add(stblUser);
            sContext.SaveChanges();
            return 1;
        }

        internal int InsertAttendance(List<tbl_EmpAttendance> stbl_Attendance)
        {
            try
            {
                foreach (tbl_EmpAttendance aitm in stbl_Attendance)
                {
                    sContext.tbl_EmpAttendance.Add(aitm);
                }
                sContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<AttendanceR> GetAllAttendance()
        {
            try
            {


                return (from a in sContext.tbl_EmpAttendance
                        join b in sContext.tbl_EmpPersonalInfo on a.EID equals b.EID                        
                        orderby a.Id ascending
                        where(a.Status=="P" && a.AttendanceProcessStatus==false)
                        select new AttendanceR
                        {
                            Id = a.Id,
                            EID = a.EID,
                            FullName = b.EmpFirstName + " " + b.EmpLastName,
                            AttendanceDate = a.AttendanceDate,
                            Attendance_Day = a.Attendance_Day,
                            Total_Hour = a.Total_Hour,
                            Status = a.Status,
                            AttendanceProcessStatus = a.AttendanceProcessStatus,
                            Remarks = a.Remarks,
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        internal List<EmployeeR> GetOffDayList()
        {
            try
            {


                return (from a in sContext.tbl_EmpOffDay
                        join b in sContext.tbl_EmpPersonalInfo on a.EID equals b.EID
                        orderby a.Id descending
                        select new EmployeeR
                        {
                            Id = a.Id,
                            EID = a.EID,
                            EIDnFullName = b.EID + "-" + b.EmpFirstName + " " + b.EmpLastName,
                            OffDay=a.Off_Day,
                            OffDayStatus = a.Status,
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int SaveOffDay(tbl_EmpOffDay stbl_EmpOffDay)
        {
            sContext.tbl_EmpOffDay.Add(stbl_EmpOffDay);
            sContext.SaveChanges();
            return 1;
        }

      

        internal List<tbl_DayName> GetAllDayList()
        {
            try
            {
                var query = (from itm in sContext.tbl_DayName
                             select itm).OrderBy(x => x.Id);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateOffDay(tbl_EmpOffDay stbl_EmpOffDay, int offDayId)
        {
            tbl_EmpOffDay obj = sContext.tbl_EmpOffDay.First(x => x.Id == offDayId);
            obj.Off_Day = stbl_EmpOffDay.Off_Day;
            obj.Status = stbl_EmpOffDay.Status;
            sContext.SaveChanges();
            return 1;
        }


        internal tbl_EmpOffDay GetOffDayById(string offId)
        {
            try
            {
                int offid = Convert.ToInt16(offId);

                tbl_EmpOffDay sale = sContext.tbl_EmpOffDay.First(x => x.Id == offid);

                return sale;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int DeleteOffDayById(string offId)
        {
            try
            {
                int objID = Convert.ToInt32(offId);
                tbl_EmpOffDay objId = sContext.tbl_EmpOffDay.First(x => x.Id == objID);
                sContext.tbl_EmpOffDay.Remove(objId);
                sContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertConfirmAttendance(List<tbl_AttendanceConfirm> attenCon)
        {
            try
            {
                foreach (tbl_AttendanceConfirm aitm in attenCon)
                {
                    sContext.tbl_AttendanceConfirm.Add(aitm);
                }
                sContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateAttenConfirmTableTotalHour(tbl_AttendanceConfirm _Confirm, string eid, DateTime attenDate, string attenDay)
        {
            tbl_AttendanceConfirm obj = sContext.tbl_AttendanceConfirm.First(x => x.EID == eid && x.AttendanceDate==attenDate && x.Attendance_Day==attenDay);
            obj.Total_Hour = _Confirm.Total_Hour;
            obj.Remarks = _Confirm.Remarks;
            sContext.SaveChanges();
            return 1;
        }

        internal List<SalaryR> GetDataListForSalary()
        {
            try
            {
                using (var _context = new FamilyBusinessEntities())
                {
                    
                    string SP_SQL = "EmployeeSalaryProcess";
                    return (_context.Database.SqlQuery<SalaryR>(SP_SQL)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int InsertSalary(List<tbl_ProcesedSalary> lst_salary)
        {
            try
            {
                foreach (tbl_ProcesedSalary aitm in lst_salary)
                {
                    sContext.tbl_ProcesedSalary.Add(aitm);
                }
                sContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<EmployeeR> GetAllEmployeeReport()
        {
            try
            {
                using (var _context = new FamilyBusinessEntities())
                {

                    string SP_SQL = "rpt_Employee";
                    return (_context.Database.SqlQuery<EmployeeR>(SP_SQL)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<EmployeeR> GetAllEmployeeSalaryReport()
        {
            try
            {
                using (var _context = new FamilyBusinessEntities())
                {

                    string SP_SQL = "rpt_Salary";
                    return (_context.Database.SqlQuery<EmployeeR>(SP_SQL)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<AttendanceR> GetAllEmployeeAttendanceReport()
        {
            try
            {
                using (var _context = new FamilyBusinessEntities())
                {

                    string SP_SQL = "rpt_Attendance";
                    return (_context.Database.SqlQuery<AttendanceR>(SP_SQL)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        internal List<AttendanceR> GetEmployeeJobCard(string eid)
        {
            try
            {
                using (var _context = new FamilyBusinessEntities())
                {
                    var Eid = new SqlParameter("@Eid", eid);
                    string SP_SQL = "rpt_JobCard @Eid";
                    return (_context.Database.SqlQuery<AttendanceR>(SP_SQL, Eid)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<AttendanceR> GetEmployeeJobCard(string eid, DateTime fromdate, DateTime todate)
        {
            try
            {
                using (var _context = new FamilyBusinessEntities())
                {
                    var Eid = new SqlParameter("@Eid", eid);
                    var Fromdate = new SqlParameter("@FromDate", fromdate);
                    var Todate = new SqlParameter("@ToDate", todate);
                    string SP_SQL = "rpt_JobCard @Eid,@FromDate,@ToDate";
                    return (_context.Database.SqlQuery<AttendanceR>(SP_SQL, Eid, Fromdate, Todate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<EmployeeR> GetEmployeePaySlip(string eid, DateTime fromdate, DateTime todate)
        {
            try
            {
                using (var _context = new FamilyBusinessEntities())
                {
                    var Eid = new SqlParameter("@Eid", eid);
                    var Fromdate = new SqlParameter("@FromDate", fromdate);
                    var Todate = new SqlParameter("@ToDate", todate);
                    string SP_SQL = "rpt_PaySlip @Eid,@FromDate,@ToDate";
                    return (_context.Database.SqlQuery<EmployeeR>(SP_SQL, Eid, Fromdate, Todate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<ProductR> GetAllProduct()
        {
            try
            {
                using (var _context = new FamilyBusinessEntities())
                {

                    string SP_SQL = "rpt_Product";
                    return (_context.Database.SqlQuery<ProductR>(SP_SQL)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
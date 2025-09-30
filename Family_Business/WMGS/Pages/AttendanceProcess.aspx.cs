using Family_Business.WMGS.BLL;
using Family_Business.WMGS.DAL;
using Family_Business.WMGS.Repository;
using System;
using System.Data.OleDb;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Family_Business.WMGS.Pages
{
    public partial class AttendanceProcess : System.Web.UI.Page
    {
        SaleBLL sSaleBLL = new SaleBLL();
        EmployeeBLL sEmployee = new EmployeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
            if (!IsPostBack)
            {
              
               //GetAllShop();
               GetAllAttendanceList();
               GetEmployee();

            }
        }

        private void GetEmployee()
        {
            try
            {
                List<EmployeeR> sEmployeeR = new List<EmployeeR>();
                var row = sEmployee.GetAllEmployeeList().ToList();
                if (row.Count > 0)
                {
                    ddlEmployee.DataSource = row.ToList();
                    ddlEmployee.DataTextField = "EIDnFullName";
                    ddlEmployee.DataValueField = "EID";
                    ddlEmployee.DataBind();
                    ddlEmployee.Items.Insert(0, new ListItem("--Select Shop--", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }       

        private void GetAllAttendanceList()
        {
          
            try
            {
                List<AttendanceR> sAttendanceR = new List<AttendanceR>();
                sAttendanceR = sEmployee.GetAllAttendance().ToList();
                if (sAttendanceR.Count > 0)
                {
                    gridAttendance.DataSource = sAttendanceR;
                    gridAttendance.DataBind();
                    btnProcess.Visible = true;
                }
                else
                {
                    wrapperError.Visible = true;
                    lblMessageError.Text = "No Data Found";
                    btnProcess.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<tbl_EmpAttendance> stbl_EmpAttendance = new List<tbl_EmpAttendance>();

            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);


            //DateTime beginningOfMonth = new DateTime(fromDate.Year, fromDate.Month, 1);

            //while (fromDate.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
            //    fromDate = fromDate.AddDays(1);

            //int result1 = (int)Math.Truncate((double)fromDate.Subtract(beginningOfMonth).TotalDays / 7f) + 1;  

            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(fromDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int year = fromDate.Year;
            
            

            if (btnSave.Text == "Save")
            {
               
                for (int i = 0; i < Convert.ToInt16(txtTotalDay.Text); i++)
                {
                    tbl_EmpAttendance AttnObj = new tbl_EmpAttendance();
                   
                        
                        AttnObj.EID = ddlEmployee.SelectedValue;
                        AttnObj.ProcessDate = DateTime.Today;
                        AttnObj.AttendanceFromDate = Convert.ToDateTime(txtFromDate.Text);
                        AttnObj.AttendanceToDate = Convert.ToDateTime(txtToDate.Text);
                        AttnObj.WeekNumber = weekNum;
                        AttnObj.Year = year;
                        AttnObj.AttendanceDate = fromDate.AddDays(i);
                        AttnObj.Attendance_Day = Convert.ToString(fromDate.AddDays(i).DayOfWeek);
                        TimeSpan in_time = TimeSpan.Parse(string.Format("10:00:00"));
                        AttnObj.In_Time = in_time;
                        TimeSpan out_time = TimeSpan.Parse(string.Format("20:00:00"));
                        AttnObj.Out_Time = out_time;
                        AttnObj.Remarks = txtRemarks.Text == "" ? "N/A" : txtRemarks.Text;
                        AttnObj.Status = "P";
                        AttnObj.AttendanceProcessStatus = false;
                        AttnObj.Total_Hour = 10; //Convert.ToDecimal(TimeSpan.Parse(string.Format("20:00:00")) - TimeSpan.Parse(string.Format("10:00:00")));
                        if (IsExist(AttnObj.EID, AttnObj.WeekNumber,AttnObj.Year))
                        {
                            stbl_EmpAttendance.Add(AttnObj);
                        }                       
                                        

                }
                int result = sEmployee.InsertAttendance(stbl_EmpAttendance);

                using (var _context = new FamilyBusinessEntities())
                {
                    var ParamempID01 = new SqlParameter("@EID", ddlEmployee.SelectedValue);
                    string attprocess = "EmployeeOffDayUpdate @EID";
                    _context.Database.ExecuteSqlCommand(attprocess, ParamempID01);
                    _context.Database.CommandTimeout = 100000;
                }
                

                wrapperSuccess.Visible = true;
                lblMessageSuccess.Text = "Attendance Process successfully";
            }
            else
            {                
               
            }
            ClearUI();
            GetAllAttendanceList();
        }


        private bool IsExist(string EID, int? weekNo, int? year)
        {
            try
            {
                FamilyBusinessEntities _context = new FamilyBusinessEntities();
                tbl_EmpAttendance obj = new tbl_EmpAttendance();
                bool status = false;
                int count = (from itm in _context.tbl_EmpAttendance
                             where (itm.EID == EID && itm.WeekNumber == weekNo && itm.Year == year)
                             select itm.Id).Count();
                if (count == 0)
                {
                    status = true;
                }

                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }     
       

        private void ClearUI()
        {
           
            txtFromDate.Text = "";
            txtToDate.Text = "";
            txtRemarks.Text = "";
            txtTotalDay.Text = "";
            ddlEmployee.ClearSelection();
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            FamilyBusinessEntities _context = new FamilyBusinessEntities();
            List<tbl_AttendanceConfirm> attenCon = new List<tbl_AttendanceConfirm>();

            foreach (GridViewRow gvRow in gridAttendance.Rows)
            {

                Label lblEID = ((Label)gvRow.FindControl("lbEID"));
                Label AttendanceDate = ((Label)gvRow.FindControl("AttendanceDate"));
                Label AttendanceDay = ((Label)gvRow.FindControl("Attendance_Day"));


                string eid = lblEID.Text;
                DateTime attenDate = Convert.ToDateTime(AttendanceDate.Text);
                string attenDay = AttendanceDay.Text;

                tbl_AttendanceConfirm _Confirm = new tbl_AttendanceConfirm();


                //Check Attendance Confirm table 



                int count = (from obj in _context.tbl_AttendanceConfirm
                             where obj.EID == eid && obj.AttendanceDate == attenDate
                             select obj.EID).Count();
                if (count == 0)
                {
                    TextBox totalHour = ((TextBox)gvRow.FindControl("txtbx"));
                    TextBox txtbxRemarks = ((TextBox)gvRow.FindControl("txtbxRemarks"));
                    _Confirm.EID = lblEID.Text;
                    _Confirm.ConfirmDate = DateTime.Today;
                    _Confirm.AttendanceDate = Convert.ToDateTime(attenDate);
                    _Confirm.Attendance_Day = attenDay;
                    _Confirm.Total_Hour = Convert.ToDecimal(totalHour.Text);
                    _Confirm.Remarks = txtbxRemarks.Text;
                    _Confirm.Status = false;

                    attenCon.Add(_Confirm);
                }
                else
                {
                    TextBox totalHour = ((TextBox)gvRow.FindControl("txtbx"));
                    TextBox txtbxRemarks = ((TextBox)gvRow.FindControl("txtbxRemarks"));
                    decimal totalWorkingHr = Convert.ToDecimal(totalHour.Text);
                    _Confirm.Total_Hour = totalWorkingHr;
                    _Confirm.Remarks = txtbxRemarks.Text;
                    sEmployee.UpdateAttenConfirmTableTotalHour(_Confirm, eid, attenDate, attenDay);
                }

            }
            int result = sEmployee.InsertConfirmAttendance(attenCon);
            foreach (GridViewRow gvRow in gridAttendance.Rows)
            {
                Label lblEID = ((Label)gvRow.FindControl("lbEID"));
                Label AttendanceDate = ((Label)gvRow.FindControl("AttendanceDate"));
                Label AttendanceDay = ((Label)gvRow.FindControl("Attendance_Day"));
                TextBox totalHour = ((TextBox)gvRow.FindControl("txtbx"));

                string eid = lblEID.Text;
                DateTime attenDate = Convert.ToDateTime(AttendanceDate.Text);
                string attenDay = AttendanceDay.Text;
                decimal totalWorkingHr = Convert.ToDecimal(totalHour.Text);

                var ParamempID01 = new SqlParameter("@EID", eid);
                var ParamempID02 = new SqlParameter("@AttenDate", attenDate);
                var ParamempID03 = new SqlParameter("@AttenDay", attenDay);
                var ParamempID04 = new SqlParameter("@TotalHour", totalWorkingHr);
                string attprocess = "Update_AttendanceStatus @EID,@AttenDate,@AttenDay,@TotalHour";
                _context.Database.ExecuteSqlCommand(attprocess, ParamempID01, ParamempID02, ParamempID03, ParamempID04);
                _context.Database.CommandTimeout = 100000;
            }
            GetAllAttendanceList();
            wrapperSuccess.Visible = true;
            lblMessageSuccess.Text = "Attendance Process Confirm";
        }

        protected void ddlShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
        }
      


       
        protected void gridAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAttendance.PageIndex = e.NewPageIndex;
            GetAllAttendanceList();
        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            DateTime currentdate = Convert.ToDateTime(txtFromDate.Text);

            DateTime todate = currentdate.AddDays(6);

            txtToDate.Text = Convert.ToString(todate);

            txtTotalDay.Text = (1 + (todate - currentdate).TotalDays).ToString();
        }      

       


    }
}
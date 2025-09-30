using Family_Business.WMGS.BLL;
using Family_Business.WMGS.DAL;
using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Family_Business.WMGS.Pages
{
    public partial class SalaryProcess : System.Web.UI.Page
    {
        EmployeeBLL sEmployee = new EmployeeBLL();
        FamilyBusinessEntities _Context = new FamilyBusinessEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               GetDataListForSalary();             

            }
        }

        private void GetDataListForSalary()
        {          
            try
            {
                List<SalaryR> obj = new List<SalaryR>();
                obj = sEmployee.GetDataListForSalary().ToList();


                if (obj.Count > 0)
                {
                    grdSalary.DataSource = obj;
                    grdSalary.DataBind();
                    btnbtnConfirm.Visible = true;

                }
                else
                {
                    btnbtnConfirm.Visible = false;
                    wrapperSuccess.Visible = true;
                    lblMessageSuccess.Text = "No Data Found!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdSalary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnbtnConfirm_Click(object sender, EventArgs e)
        {
            List<tbl_ProcesedSalary> lst_salary = new List<tbl_ProcesedSalary>();
            foreach (GridViewRow gvRow in grdSalary.Rows)
            {
                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                Label lbEID = ((Label)gvRow.FindControl("lbEID"));
                string eid = lbEID.Text;

                //Convert.ToDateTime(txtDate.Text);
               
                

                if (rowChkBox.Checked == true)
                {

                    tbl_ProcesedSalary _salary = new tbl_ProcesedSalary();
                    //Check Leave table 

                    DateTime ProcessDate = DateTime.Today;

                    //Calendar Calendar = CultureInfo.InvariantCulture.Calendar;
                    //int weekNumber = Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    //Console.WriteLine(weekNumber);
                    CultureInfo ciCurr = CultureInfo.CurrentCulture;
                    int weekNum = ciCurr.Calendar.GetWeekOfYear(ProcessDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    //return weekNum;

                    //DateTime beginningOfMonth = new DateTime(ProcessDate.Year, ProcessDate.Month, 1);

                    //while (ProcessDate.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                    //    ProcessDate = ProcessDate.AddDays(1);

                    //int result1= (int)Math.Truncate((double)ProcessDate.Subtract(beginningOfMonth).TotalDays / 7f) + 1;  


                    int count = (from obj in _Context.tbl_ProcesedSalary
                                 where obj.EID == eid && obj.ConfirmDate == ProcessDate
                                 select obj.EID).Count();
                    if (count == 0)
                    {
                        Label lblTotalWorkingHour = ((Label)gvRow.FindControl("lblTotalWorkingHour"));
                        Label lbEmpPay = ((Label)gvRow.FindControl("lbEmpPay"));
                        Label lbtotalPayAmt = ((Label)gvRow.FindControl("lbtotalPayAmt"));
                        TextBox txtbx = ((TextBox)gvRow.FindControl("txtbx"));
                        TextBox txtbxRemarks = ((TextBox)gvRow.FindControl("txtbxRemarks"));

                        decimal totalWorkHr = Convert.ToDecimal(lblTotalWorkingHour.Text);
                        decimal EmpPay = Convert.ToDecimal(lbEmpPay.Text);
                        decimal totalPayAmt = Convert.ToDecimal(lbtotalPayAmt.Text);
                        decimal benefit = Convert.ToDecimal(txtbx.Text);
                        string remarks = txtbxRemarks.Text;


                        _salary.EID = lbEID.Text;
                        _salary.ConfirmDate = ProcessDate;
                        _salary.TotalWorkHour = totalWorkHr;
                        _salary.PayRate = EmpPay;
                        _salary.Total_Payment = totalPayAmt;
                        _salary.Benefits = benefit;
                        _salary.Remarks = remarks;


                        lst_salary.Add(_salary);
                    }
                    else
                    {

                       //int _SalryDelete_1 = _attendancebll.LeaveDelete(eid, _date_1, OCODE);

                        Label lblTotalWorkingHour = ((Label)gvRow.FindControl("lblTotalWorkingHour"));
                        Label lbEmpPay = ((Label)gvRow.FindControl("lbEmpPay"));
                        Label lbtotalPayAmt = ((Label)gvRow.FindControl("lbtotalPayAmt"));
                        TextBox txtbx = ((TextBox)gvRow.FindControl("txtbx"));
                        TextBox txtbxRemarks = ((TextBox)gvRow.FindControl("txtbxRemarks"));

                        decimal totalWorkHr = Convert.ToDecimal(lblTotalWorkingHour.Text);
                        decimal EmpPay = Convert.ToDecimal(lbEmpPay.Text);
                        decimal totalPayAmt = Convert.ToDecimal(lbtotalPayAmt.Text);
                        decimal benefite = Convert.ToDecimal(txtbx.Text);
                        string remarks = txtbxRemarks.Text;


                        _salary.EID = lbEID.Text;
                        _salary.ConfirmDate = ProcessDate;
                        _salary.TotalWorkHour = totalWorkHr;
                        _salary.PayRate = EmpPay;
                        _salary.Total_Payment = totalPayAmt;
                        _salary.Benefits = benefite;
                        _salary.Remarks = remarks;
                    }





                }
            }
            int result = sEmployee.InsertSalary(lst_salary);

            foreach (GridViewRow gvRow in grdSalary.Rows)
            {
                FamilyBusinessEntities _Context = new FamilyBusinessEntities();
                Label lblEID = ((Label)gvRow.FindControl("lbEID"));
               
                string eid = lblEID.Text;
               

                var ParamempID01 = new SqlParameter("@EID", eid);
               
                string attprocess = "Update_SalaryStatus @EID";
                _Context.Database.ExecuteSqlCommand(attprocess, ParamempID01);
                _Context.Database.CommandTimeout = 100000;
            }
            GetDataListForSalary();
            wrapperSuccess.Visible = true;
            lblMessageSuccess.Text = "Salary Process Successfully!";
            
        
        }
           

    }
}
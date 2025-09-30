using Family_Business.WMGS.BLL;
using Family_Business.WMGS.DAL;
using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Family_Business.WMGS.Pages
{
    public partial class Report : System.Web.UI.Page
    {
        EmployeeBLL sEmployeeBLL = new EmployeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
            if (!IsPostBack)
            {

                GetEmployee();

            }
        }
        private void GetEmployee()
        {
            try
            {
                List<EmployeeR> sEmployeeR = new List<EmployeeR>();
                var row = sEmployeeBLL.GetAllEmployeeList().ToList();
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
       
        protected void btnRpt_Click(object sender, EventArgs e)
        {
            if (ddlReport.SelectedItem.Text == "--Select Report--")
            {
                wrapperError.Visible = true;
                lblMessageError.Text = "Select Report First!";
            }
            else if (ddlReport.SelectedValue == "rptEmployee")
            {
                List<EmployeeR> obj = new List<EmployeeR>();
                DateTime fromDate = DateTime.Now;
                obj = sEmployeeBLL.GetAllEmployeeReport().ToList();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataset = new ReportDataSource("DataSet1", obj);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("/WMGS/Reports/Employee.rdlc");
                ReportViewer1.LocalReport.Refresh();
            }
            else if (ddlReport.SelectedValue == "rptAttendance")
            {
                List<AttendanceR> obj = new List<AttendanceR>();
                DateTime fromDate = DateTime.Now;
                obj = sEmployeeBLL.GetAllEmployeeAttendanceReport().ToList();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataset = new ReportDataSource("DataSet1", obj);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("/WMGS/Reports/Attendance.rdlc");
                ReportViewer1.LocalReport.Refresh();
            }
            else if (ddlReport.SelectedValue == "rptJobCard")
            {
                List<AttendanceR> obj = new List<AttendanceR>();                
                string eid = txteid.Text;
                DateTime fromdate = Convert.ToDateTime(txtFromDate.Text);
                DateTime todate = Convert.ToDateTime(txtToDate.Text);
                obj = sEmployeeBLL.GetEmployeeJobCard(eid, fromdate,todate).ToList();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataset = new ReportDataSource("JobCard", obj);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("/WMGS/Reports/JobCard.rdlc");
                ReportViewer1.LocalReport.Refresh();
            }
            else if (ddlReport.SelectedValue == "rptSalary")
            {
                List<EmployeeR> obj = new List<EmployeeR>();
                DateTime fromDate = DateTime.Now;
                obj = sEmployeeBLL.GetAllEmployeeSalaryReport().ToList();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataset = new ReportDataSource("Salary", obj);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("/WMGS/Reports/Salary.rdlc");
                ReportViewer1.LocalReport.Refresh();
            }
           
            else if (ddlReport.SelectedValue == "rptPaySlip")
            {
                List<EmployeeR> obj = new List<EmployeeR>();
                string eid = txteid.Text;
                DateTime fromdate = Convert.ToDateTime(txtFromDate.Text);
                DateTime todate = Convert.ToDateTime(txtToDate.Text);
                obj = sEmployeeBLL.GetEmployeePaySlip(eid, fromdate, todate).ToList();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataset = new ReportDataSource("Pay_Slip", obj);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("/WMGS/Reports/PaySlip.rdlc");
                ReportViewer1.LocalReport.Refresh();
            }
           
            else if (ddlReport.SelectedValue == "rptProduct")
            {
                List<ProductR> obj = new List<ProductR>();
                obj = sEmployeeBLL.GetAllProduct().ToList();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataset = new ReportDataSource("Products", obj);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("/WMGS/Reports/Product.rdlc");
                ReportViewer1.LocalReport.Refresh();
            }
           

           
        }

        protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReport.SelectedValue == "rptJobCard" || ddlReport.SelectedValue == "rptPaySlip")
            {
                employee.Visible = true;
                fromDate.Visible = true;
                toDate.Visible = true;
            }
            else
            {
                employee.Visible = false;
                fromDate.Visible = false;
                toDate.Visible = false;
            }
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            string eid = ddlEmployee.SelectedValue;
            txteid.Text = eid;
        }
    }
}
using Family_Business.WMGS.BLL;
using Family_Business.WMGS.DAL;
using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Family_Business.WMGS.Pages
{
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        EmployeeBLL sEmployeeBLL = new EmployeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
            //if ((Session["UserName"] != null))
            //{
                if (!IsPostBack)
                {
                    GetAllEmployeeList();
                    GetGender();
                    GetStatus();

                }
            //}
           
        }

        private void GetGender()
        {
            List<tbl_Genders> sGender = new List<tbl_Genders>();
            sGender = sEmployeeBLL.GetGender();
            if (sGender.Count > 0)
            {
                ddlGender.DataSource = sGender.ToList();
                ddlGender.DataTextField = "Gender";
                ddlGender.DataValueField = "Id";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("--Select Gender--", "0"));
            }
        }
        private void GetStatus()
        {
            List<tbl_EmpStatus> sStatus = new List<tbl_EmpStatus>();
            sStatus = sEmployeeBLL.GetStatus();
            if (sStatus.Count > 0)
            {
                ddlEmpStatus.DataSource = sStatus.ToList();
                ddlEmpStatus.DataTextField = "EMP_Status";
                ddlEmpStatus.DataValueField = "Id";
                ddlEmpStatus.DataBind();
                ddlEmpStatus.Items.Insert(0, new ListItem("--Select Status--", "0"));
            }
        }



        private void GetAllEmployeeList()
        {
          
            try
            {
                List<EmployeeR> sEmployee = new List<EmployeeR>();
                sEmployee = sEmployeeBLL.GetAllEmployeeList().ToList();
                if (sEmployee.Count > 0)
                {
                    gridEmployee.DataSource = sEmployee;
                    gridEmployee.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_EmpPersonalInfo stbl_Employee = new tbl_EmpPersonalInfo();
            stbl_Employee.EID = txtEmployeeID.Text;
            stbl_Employee.EmpFirstName = txtEmpFirstName.Text;
            stbl_Employee.EmpLastName = txtLastName.Text;
            stbl_Employee.EmpPhone = txtPhoneNo.Text;
            stbl_Employee.EmpEmail = txtEmpEmail.Text;
            stbl_Employee.EmpAddress = txtEmpAddress.Text;
            stbl_Employee.EmpGender = Convert.ToInt16(ddlGender.SelectedValue);
            stbl_Employee.Status = Convert.ToInt16(ddlEmpStatus.SelectedValue);
            stbl_Employee.Education = txtEducation.Text;
            stbl_Employee.EmpNominee = txtEmpNominee.Text;
            stbl_Employee.EmpNomineePhone = txtNomineePhone.Text;
            stbl_Employee.EmpShift = txtEmpShift.Text;
            stbl_Employee.DateofBirth = Convert.ToDateTime(txtDateOfDate.Text);
            stbl_Employee.EmpPay = Convert.ToDecimal(txtEmpPay.Text);
            stbl_Employee.JoiningDate = Convert.ToDateTime(txtJoingingDate.Text);
            if (chkEmployeeConfirmed.Checked)
            {
                stbl_Employee.ConfirmStatus = true;
            }
            else
            {
                stbl_Employee.ConfirmStatus = false;
            }
            
            
            if (btnSave.Text == "Save")
            {
                if (IsExist(stbl_Employee.EID))
                {
                    int save = sEmployeeBLL.SaveEmployee(stbl_Employee);
                    GetAllEmployeeList();

                    //Create User

                    tbl_Users stblUser = new tbl_Users();
                    Guid guid = Guid.NewGuid();
                    stblUser.UserID = guid;
                    stblUser.EmpID = txtEmployeeID.Text;
                    stblUser.UserName = txtEmpFirstName.Text;
                    stblUser.PhoneNo = txtPhoneNo.Text;
                    stblUser.Password = "123" + "" + txtEmployeeID.Text;
                    stblUser.Email = txtEmpEmail.Text;

                    int User = sEmployeeBLL.CreateUser(stblUser);

                    wrapperSuccess.Visible = true;
                    lblMessageSuccess.Text = "Data Save successfully";
                }

                else
                {
                    wrapperError.Visible = true;
                    lblMessageError.Text = "Emplyee ID Already Exist!";
                }
            }
            else
            {
                int empId = Convert.ToInt32(hidEMPID.Value);
                int result = sEmployeeBLL.UpdateEmployee(stbl_Employee, empId);
                btnSave.Text = "Save";
                wrapperSuccess.Visible = true;
                lblMessageSuccess.Text = "Data Update successfully";
            }
            ClearUI();
            GetAllEmployeeList();
        }

        private bool IsExist(string EID)
        {
            try
            {
                FamilyBusinessEntities _context = new FamilyBusinessEntities();
                tbl_EmpPersonalInfo obj = new tbl_EmpPersonalInfo();
                bool status = false;
                int count = (from itm in _context.tbl_EmpPersonalInfo
                             where (itm.EID == EID)
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
            txtEmployeeID.Text = "";
            txtEmpFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneNo.Text = "";
            txtEmpEmail.Text = "";
            txtEmpAddress.Text = "";
            ddlGender.ClearSelection() ;
            ddlEmpStatus.ClearSelection();
            txtEducation.Text = "";
            txtEmpNominee.Text = "";
            txtNomineePhone.Text = "";
            txtEmpShift.Text = "";
            txtDateOfDate.Text = "";
            txtEmpPay.Text = "";
            txtEmployeeID.Enabled = true;

            
        }


       

        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            tbl_EmpPersonalInfo objEMP= new tbl_EmpPersonalInfo();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string eId = "";
                Label lblId = (Label)gridEmployee.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {

                    eId = lblId.Text;
                    objEMP = sEmployeeBLL.GetEmpById(eId);

                    if (objEMP != null)
                    {
                        
                        hidEMPID.Value = objEMP.Id.ToString();
                        txtEmployeeID.Text = objEMP.EID;
                        txtEmpFirstName.Text=objEMP.EmpFirstName;
                        txtLastName.Text = objEMP.EmpLastName;
                        txtPhoneNo.Text = objEMP.EmpPhone;
                        txtEmpEmail.Text= objEMP.EmpEmail;
                        txtEmpAddress.Text = objEMP.EmpAddress;
                        ddlGender.SelectedValue = Convert.ToString(objEMP.EmpGender);
                        ddlEmpStatus.SelectedValue = Convert.ToString(objEMP.Status);
                        txtEducation.Text = objEMP.Education;
                        txtEmpNominee.Text= objEMP.EmpNominee;
                        txtNomineePhone.Text = objEMP.EmpNomineePhone;
                        txtEmpShift.Text = objEMP.EmpShift;
                        txtDateOfDate.Text = Convert.ToString(objEMP.DateofBirth);
                        txtEmpPay.Text = Convert.ToString(objEMP.EmpPay);
                        txtJoingingDate.Text = Convert.ToString(objEMP.JoiningDate);

                        if (objEMP.ConfirmStatus == true)
                        {
                            chkEmployeeConfirmed.Checked.ToString();
                        }
                        

                        if (btnSave.Text == "Save")
                        {
                            btnSave.Text = "Update";
                            txtEmployeeID.Enabled = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void imgbtnDelet_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string empId = "";
                Label lblempId = (Label)gridEmployee.Rows[row.RowIndex].FindControl("lblId");
                if (lblempId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    empId = lblempId.Text;
                    int result = sEmployeeBLL.DeleteShopById(empId);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Delete Successfully')", true);
                        GetAllEmployeeList();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        

        protected void gridEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEmployee.PageIndex = e.NewPageIndex;
            GetAllEmployeeList();
        }

       

      
    }
}
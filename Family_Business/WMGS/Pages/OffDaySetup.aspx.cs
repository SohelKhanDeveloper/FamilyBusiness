using Family_Business.WMGS.BLL;
using Family_Business.WMGS.DAL;
using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Family_Business.WMGS.Pages
{
    public partial class OffDaySetup : System.Web.UI.Page
    {
        EmployeeBLL sEmployee = new EmployeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
            if (!IsPostBack)
            {
               GetOffDayList();
               GetEmployee();
               GetDay();
              

            }
        }

        private void GetDay()
        {
            List<tbl_DayName> day = new List<tbl_DayName>();
            var row = sEmployee.GetAllDayList().ToList();
            if (row.Count > 0)
            {
                ddlDay.DataSource = row.ToList();
                ddlDay.DataTextField = "Day";
                ddlDay.DataValueField = "Id";
                ddlDay.DataBind();
                ddlDay.Items.Insert(0, new ListItem("--Select Day--", "0"));
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
                    ddlEmployee.Items.Insert(0, new ListItem("--Select Employee--", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }   

        private void GetOffDayList()
        {
          
            try
            {
                List<EmployeeR> employee = new List<EmployeeR>();
                employee = sEmployee.GetOffDayList().ToList();
                if (employee.Count > 0)
                {
                    gridOffDay.DataSource = employee;
                    gridOffDay.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_EmpOffDay stbl_EmpOffDay = new tbl_EmpOffDay();
            stbl_EmpOffDay.EID = ddlEmployee.SelectedValue;
            stbl_EmpOffDay.Off_Day = ddlDay.SelectedItem.Text;
            if (ddlStatus.SelectedItem.Text == "------- Select --------")
            {
                stbl_EmpOffDay.Status = false;
            }
            else if (ddlStatus.SelectedItem.Text == "Yes")
            {
                stbl_EmpOffDay.Status = true;
            }
            else
            {
                stbl_EmpOffDay.Status = false;
            }

            
            if (btnSave.Text == "Save")
            {
                if (IsExist(stbl_EmpOffDay.EID, stbl_EmpOffDay.Off_Day))
                {
                    int save = sEmployee.SaveOffDay(stbl_EmpOffDay);
                    GetOffDayList();
                    // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    wrapperSuccess.Visible = true;
                    lblMessageSuccess.Text = "Data Save successfully";
                }

                else
                {
                    wrapperError.Visible = true;
                    lblMessageError.Text = "Alreay axist!";
                }
            }
            else
            {
                int offDayId = Convert.ToInt32(hidOffDayID.Value);
                int result = sEmployee.UpdateOffDay(stbl_EmpOffDay, offDayId);
                btnSave.Text = "Save";
                wrapperSuccess.Visible = true;
                lblMessageSuccess.Text = "Data Update successfully";
            }
            ClearUI();
            GetOffDayList();
        }

        private bool IsExist(string eid, string offDay)
        {
            try
            {
                FamilyBusinessEntities _context = new FamilyBusinessEntities();
                tbl_EmpOffDay obj = new tbl_EmpOffDay();
                bool status = false;
                int count = (from itm in _context.tbl_EmpOffDay
                             where (itm.EID == eid && itm.Off_Day == offDay)
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
            ddlEmployee.ClearSelection();
            //ddlDay.SelectedItem.Text ="--Select Day--";
            //ddlStatus.SelectedItem.Text = "--Select--";

        }


      

        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            tbl_EmpOffDay objOffDay = new tbl_EmpOffDay();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string offId = "";
                Label lblId = (Label)gridOffDay.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {

                    offId = lblId.Text;
                    objOffDay = sEmployee.GetOffDayById(offId);

                    if (objOffDay != null)
                    {
                        hidOffDayID.Value = objOffDay.Id.ToString();

                        ddlEmployee.SelectedValue = objOffDay.EID;
                        ddlDay.SelectedItem.Text = objOffDay.Off_Day;
                        if (objOffDay.Status == true)
                        {
                            ddlStatus.SelectedItem.Text = "Yes";
                        }
                        else if (objOffDay.Status == false)
                        {
                            ddlStatus.SelectedItem.Text = "No";
                        }
                       // ddlStatus.SelectedItem.Text =Convert.ToString( objOffDay.Status);
                       

                        if (btnSave.Text == "Save")
                        {
                            btnSave.Text = "Update";
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
                string offId = "";
                Label lblOffdayId = (Label)gridOffDay.Rows[row.RowIndex].FindControl("lblId");
                if (lblOffdayId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    offId = lblOffdayId.Text;
                    int result = sEmployee.DeleteOffDayById(offId);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Delete Successfully')", true);
                        GetOffDayList();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
        }

        protected void gridOffDay_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridOffDay.PageIndex = e.NewPageIndex;
            GetOffDayList();
        }

       

      
    }
}
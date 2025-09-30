using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Family_Business.Models;
using System.Linq;
using Family_Business.WMGS.BLL;
using Family_Business.WMGS.DAL;
using System.Drawing;
using System.Collections.Generic;
using Family_Business.WMGS.Repository;

namespace Family_Business.Account
{
    public partial class Login : Page
    {
        ProductBll sProductBll = new ProductBll();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void LogIn(object sender, EventArgs e)
        {          


            try
            {
                if (IsValid())
                {
                    UserLogin();
                }
            }
            catch (Exception)
            {
                this.lblStatus.Text = "Login Error !!";
                this.lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void UserLogin()
        {
            List<UserR> userR = new List<UserR>();
            string UserName = txtLoginName.Text;
            string Password = txtLoginPassword.Text;
            userR = sProductBll.GetUser_Login(UserName,Password);
            Session["objResult"] = userR;

            var rowCount = userR.Count;          
           

            if (rowCount > 0)
            {
                 var obj = userR.SingleOrDefault();
                Session objSession = new Session();
                objSession.UserId = obj.UserID;
                objSession.UserName = obj.UserName;


                Session["UserID"] = objSession.UserId;
                Session["UserName"] = objSession.UserName;


                imgstatusloading.Visible = true;
                imgstatusloading.ImageUrl = "~/images/loading.gif";
                this.lblMesg.Text = "Please wait...";
                this.lblMesg.ForeColor = System.Drawing.Color.Orange;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "setInterval(function(){location.href='../Default.aspx';},3000);", true);
                lblMessage.Visible = false;
                lblStatus.Visible = false;
            }
            else
            {
                lblMessage.Text = "Input Correct User Name and Password";
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Focus();
                //this.lblMessage.BackColor = Color.Green;
                lblPassword.Visible = false;
                
            }

        }

        private bool IsValid()
        {
            if (txtLoginName.Text == string.Empty)
            {
                this.lblStatus.Text = "Enter User name!";
                this.lblStatus.ForeColor = Color.Maroon;
                this.txtLoginName.Focus();
                this.txtLoginName.BackColor = Color.Khaki;
                lblMessage.Visible = false;
                return false;
            }

            if (txtLoginPassword.Text == string.Empty)
            {
                lblStatus.Visible=false;
                this.lblPassword.Text = "Enter User Password!";
                this.lblPassword.ForeColor = Color.Maroon;
                this.txtLoginPassword.Focus();
                this.txtLoginPassword.BackColor = Color.Khaki;
                lblMessage.Visible = false;
                return false;
            }

            return true;
        }
    }
}
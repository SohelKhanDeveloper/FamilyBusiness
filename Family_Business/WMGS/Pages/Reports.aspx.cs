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
    public partial class Reports : System.Web.UI.Page
    {
        SaleBLL sSaleBLL = new SaleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
            if (!IsPostBack)
            {
              
               GetAllShop();
               GetAllSaleList();

            }
        }

        private void GetAllShop()
        {
            try
            {
                List<SalesR> sSaleR = new List<SalesR>();
                var row = sSaleBLL.GetAllShop().ToList();
                if (row.Count > 0)
                {
                    ddlShop.DataSource = row.ToList();
                    ddlShop.DataTextField = "ShopName";
                    ddlShop.DataValueField = "id";
                    ddlShop.DataBind();
                    ddlShop.Items.Insert(0, new ListItem("--Select Shop--", "0"));
                }
            }
            catch (Exception)            {
                throw;
            }

           
        }

        private void GetAllSaleList()
        {
          
            try
            {
                List<SalesR> sSalesR = new List<SalesR>();
                sSalesR = sSaleBLL.GetAllSales().ToList();
                if (sSalesR.Count > 0)
                {
                    gridSales.DataSource = sSalesR;
                    gridSales.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_Sale stblSale = new tbl_Sale();

            stblSale.SaleDate = Convert.ToDateTime(txtSaleDate.Text);
            stblSale.ShopID = Convert.ToInt16(ddlShop.SelectedValue);
            stblSale.Cash = Convert.ToDecimal(txtCash.Text);
            stblSale.Cash_Tax = Convert.ToDecimal(Convert.ToDecimal(txtCash.Text) *6)/100;
            stblSale.Cash_Total = Convert.ToDecimal(txtCash.Text) + Convert.ToDecimal(Convert.ToDecimal(txtCash.Text) * 6) / 100;
            stblSale.Card = Convert.ToDecimal(txtCard.Text);
            stblSale.Card_Tax = Convert.ToDecimal(Convert.ToDecimal(txtCard.Text) * 6) / 100;
            stblSale.Card_Total = Convert.ToDecimal(txtCard.Text) + Convert.ToDecimal(Convert.ToDecimal(txtCard.Text) * 6) / 100;
           
            if (btnSave.Text == "Save")
            {
                if (IsExist(stblSale.ShopID, stblSale.SaleDate))
                {
                    //stblSale.Create_User = ((Session)Session["UserID"]).UserId;
                    //stblSale.Create_Date = DateTime.Now;

                    int save = sSaleBLL.SaveSale(stblSale);
                    GetAllSaleList();
                    // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    wrapperSuccess.Visible = true;
                    lblMessageSuccess.Text = "Data Save successfully";
                }

                else
                {
                    wrapperError.Visible = true;
                    lblMessageError.Text = "Oil Name Already exist!";
                }
            }
            else
            {
                //stblSale.Edit_User = ((Session)Session["SessionUser"]).UserId;
                //stblSale.Edit_Date = DateTime.Now;

                int SaleId = Convert.ToInt32(hidSaleID.Value);
                int result = sSaleBLL.UpdateSale(stblSale, SaleId);
                btnSave.Text = "Save";
                wrapperSuccess.Visible = true;
                lblMessageSuccess.Text = "Data Update successfully";
            }
            ClearUI();
            GetAllSaleList();
        }

        private bool IsExist(int? shopid, DateTime? date)
        {
            try
            {
                FamilyBusinessEntities _context = new FamilyBusinessEntities();
                tbl_Sale obj = new tbl_Sale();
                bool status = false;
                int count = (from itm in _context.tbl_Sale
                             where (itm.ShopID == shopid && itm.SaleDate == date)
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
            txtCard.Text = "";
            txtCash.Text = "";
            txtSaleDate.Text = "";
            ddlShop.ClearSelection();
        }


        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            tbl_Sale objSale = new tbl_Sale();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string saleId = "";
                Label lblId = (Label)gridSales.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {

                    saleId = lblId.Text;
                    objSale = sSaleBLL.GetSaleById(saleId);

                    if (objSale != null)
                    {
                        hidSaleID.Value = objSale.Id.ToString();
                        ddlShop.SelectedValue = Convert.ToString(objSale.ShopID);

                        txtSaleDate.Text = Convert.ToString(objSale.SaleDate);
                        txtCash.Text = Convert.ToString(objSale.Cash);
                        txtCard.Text = Convert.ToString(objSale.Card);
                       

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
                string saleId = "";
                Label lblsaleId = (Label)gridSales.Rows[row.RowIndex].FindControl("lblId");
                if (lblsaleId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    saleId = lblsaleId.Text;
                    int result = sSaleBLL.DeleteSaleById(saleId);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Delete Successfully')", true);
                        GetAllSaleList();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        //protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    wrapperSuccess.Visible = false;
        //    wrapperError.Visible = false;
        //}

        protected void gridSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSales.PageIndex = e.NewPageIndex;
            GetAllSaleList();
        }

        protected void ddlShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
        }
        protected void btnRpt_Click(object sender, EventArgs e)
        {
            List<SalesR> objBill = new List<SalesR>();
            DateTime fromDate = DateTime.Now;
            objBill = sSaleBLL.GetSalesReport(fromDate).ToList();
            //printWrapper.Visible = true;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource reportDataset = new ReportDataSource("DataSet1", objBill);
            ReportViewer1.LocalReport.DataSources.Add(reportDataset);
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath(ddlPrintPageType.SelectedValue == "1" ? "/Billing/Reports/Billing_Half.rdlc" : "/Billing/Reports/Billing_Full.rdlc");
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("/WMGS/Reports/DailySale.rdlc");
            ReportViewer1.LocalReport.Refresh();
            //PrintReport.Export(ReportViewer1.LocalReport);
            //PrintReport.DisposePrint();
        }
    }
}
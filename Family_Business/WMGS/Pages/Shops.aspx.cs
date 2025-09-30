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
    public partial class Shops : System.Web.UI.Page
    {
        ProductBll sProductBll = new ProductBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
            if (!IsPostBack)
            {
               GetAllShopList();
              

            }
        }



        private void GetAllShopList()
        {
          
            try
            {
                List<tbl_ShopName> sShop = new List<tbl_ShopName>();
                sShop = sProductBll.GetAllShop().ToList();
                if (sShop.Count > 0)
                {
                    gridShop.DataSource = sShop;
                    gridShop.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_ShopName stbl_ShopName = new tbl_ShopName();
            stbl_ShopName.ShopName = txtShopName.Text;
            stbl_ShopName.ShopLocation = txtShopLocation.Text;
            
            if (btnSave.Text == "Save")
            {
                if (IsExist(stbl_ShopName.ShopName, stbl_ShopName.ShopLocation))
                {
                    int save = sProductBll.SaveShop(stbl_ShopName);
                    GetAllShopList();
                    // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    wrapperSuccess.Visible = true;
                    lblMessageSuccess.Text = "Data Save successfully";
                }

                else
                {
                    wrapperError.Visible = true;
                    lblMessageError.Text = "Oil Name Alreay axist!";
                }
            }
            else
            {
                int shopId = Convert.ToInt32(hidShopID.Value);
                int result = sProductBll.UpdateShop(stbl_ShopName, shopId);
                btnSave.Text = "Save";
                wrapperSuccess.Visible = true;
                lblMessageSuccess.Text = "Data Update successfully";
            }
            ClearUI();
            GetAllShopList();
        }

        private bool IsExist(string shopName, string shopLoction)
        {
            try
            {
                FamilyBusinessEntities _context = new FamilyBusinessEntities();
                tbl_ShopName obj = new tbl_ShopName();
                bool status = false;
                int count = (from itm in _context.tbl_ShopName
                             where (itm.ShopName == shopName && itm.ShopLocation == shopLoction)
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
            txtShopName.Text = "";
            txtShopLocation.Text = "";
            
        }


        protected void gridProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridShop.PageIndex = e.NewPageIndex;
            GetAllShopList();
        }

        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            tbl_ShopName objShop = new tbl_ShopName();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string shopId = "";
                Label lblId = (Label)gridShop.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {

                    shopId = lblId.Text;
                    objShop = sProductBll.GetShopById(shopId);

                    if (objShop != null)
                    {
                        hidShopID.Value = objShop.Id.ToString();

                        txtShopName.Text = objShop.ShopName;
                        txtShopLocation.Text = objShop.ShopLocation;
                       

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
                string shopId = "";
                Label lblshopId = (Label)gridShop.Rows[row.RowIndex].FindControl("lblId");
                if (lblshopId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    shopId = lblshopId.Text;
                    int result = sProductBll.DeleteShopById(shopId);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Delete Successfully')", true);
                        GetAllShopList();
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

       

      
    }
}
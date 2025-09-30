using Family_Business.WMGS.BLL;
using Family_Business.WMGS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Family_Business.WMGS.Pages
{
    public partial class Products : System.Web.UI.Page
    {
        ProductBll sProductBll = new ProductBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            wrapperSuccess.Visible = false;
            wrapperError.Visible = false;
            if (!IsPostBack)
            {
               GetAllProductList();
               GetOilLocation();

            }
        }

        private void GetOilLocation()
        {
            try
            {

                var row = sProductBll.GetOilLocation().ToList();
                if (row.Count > 0)
                {
                    ddlLocation.DataSource = row.ToList();
                    ddlLocation.DataTextField = "Oil_AllocationBox";
                    ddlLocation.DataValueField = "id";
                    ddlLocation.DataBind();
                    ddlLocation.Items.Insert(0, new ListItem("--Oil Location--", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }

           
        }

        private void GetAllProductList()
        {
          
            try
            {
                List<ProductR> sProductR = new List<ProductR>();
                sProductR = sProductBll.GetAllProduct().ToList();
                if (sProductR.Count > 0)
                {
                    gridProduct.DataSource = sProductR;
                    gridProduct.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_AllProduct stblProduct = new tbl_AllProduct();
            stblProduct.ProductType_Id = Convert.ToInt16(ddlProductType.SelectedValue);
            stblProduct.OilType_Id = Convert.ToInt16(ddlOilType.SelectedValue);
            stblProduct.FragranceType = Convert.ToInt16(ddlFragranceType.SelectedValue);
            stblProduct.Product_Name = txtProductName.Text;
            stblProduct.Product_Code = txtProductCode.Text;
            stblProduct.Product_Index = "N/A";
            stblProduct.Product_Index = txtIndex.Text == "" ? "N/A" : txtIndex.Text;
            stblProduct.Product_Location_Id = Convert.ToInt16(ddlLocation.SelectedValue);

            if (btnSave.Text == "Save")
            {
                if (IsExist(stblProduct.OilType_Id, stblProduct.Product_Name))
                {
                    int save = sProductBll.SaveProduct(stblProduct);
                    GetAllProductList();
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
                int productId = Convert.ToInt32(hidProductID.Value);
                int result = sProductBll.UpdateProduct(stblProduct, productId);
                btnSave.Text = "Save";
                wrapperSuccess.Visible = true;
                lblMessageSuccess.Text = "Data Update successfully";
            }
            ClearUI();
            GetAllProductList();
        }

        private bool IsExist(int oilType, string productname)
        {
            try
            {
                FamilyBusinessEntities _context = new FamilyBusinessEntities();
                tbl_AllProduct obj = new tbl_AllProduct();
                bool status = false;
                int count = (from itm in _context.tbl_AllProduct
                             where (itm.OilType_Id == oilType && itm.Product_Name == productname)
                             select itm.id).Count();
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
            txtProductName.Text = "";
            txtProductCode.Text = "";
            txtIndex.Text = "";
            ddlLocation.ClearSelection();
            ddlProductType.ClearSelection();
            ddlOilType.ClearSelection();
            ddlFragranceType.ClearSelection();
        }


        protected void gridProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProduct.PageIndex = e.NewPageIndex;
            GetAllProductList();
        }

        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            tbl_AllProduct objproduct = new tbl_AllProduct();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string productId = "";
                Label lblId = (Label)gridProduct.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {

                    productId = lblId.Text;
                    objproduct = sProductBll.GetProductById(productId);

                    if (objproduct != null)
                    {
                        hidProductID.Value = objproduct.id.ToString();
                        ddlProductType.SelectedValue = Convert.ToString(objproduct.ProductType_Id);
                        ddlOilType.SelectedValue = Convert.ToString(objproduct.OilType_Id);
                        txtProductName.Text = objproduct.Product_Name;
                        txtProductCode.Text = objproduct.Product_Code;
                        ddlLocation.Text = Convert.ToString(objproduct.Product_Location_Id);
                        ddlFragranceType.Text = Convert.ToString(objproduct.FragranceType);
                        txtIndex.Text = objproduct.Product_Index;
                       

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
                string productId = "";
                Label lblproductId = (Label)gridProduct.Rows[row.RowIndex].FindControl("lblId");
                if (lblproductId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    productId = lblproductId.Text;
                    int result = sProductBll.DeleteProductById(productId);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Delete Successfully')", true);
                        GetAllProductList();
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
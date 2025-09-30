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
    public partial class ProductList : System.Web.UI.Page
    {
        ProductBll sProductBll = new ProductBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               GetAllProductList();
               GetOilType();
               GetProducts();

            }
        }

        private void GetOilType()
        {
            
            List<tbl_OilType> sProductR = new List<tbl_OilType>();
            sProductR = sProductBll.GetAllOilType().ToList();

            if (sProductR.Count > 0)
            {
                ddlOilType.DataSource = sProductR.ToList();
                ddlOilType.DataTextField = "OilType";
                ddlOilType.DataValueField = "Id";
                ddlOilType.DataBind();
                ddlOilType.Items.Insert(0, new ListItem("--select Oil Type--", "0"));
            }
        }

        private void GetProducts()
        {
            List<ProductR> sProductR = new List<ProductR>();
            sProductR = sProductBll.GetAllProduct().ToList();
            if (sProductR.Count > 0)
            {
                ddlProductName.DataSource = sProductR.ToList();
                ddlProductName.DataTextField = "ProductName";
                ddlProductName.DataValueField = "id";
                ddlProductName.DataBind();
                ddlProductName.Items.Insert(0, new ListItem("--select Oil Name--", "0"));
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
        //[System.Web.Script.Services.ScriptMethod()]
        //[System.Web.Services.WebMethod]
        //public static List<string> SearchOil(string prefixText, int count)
        //{
        //    using (var _context = new FamilyBusinessEntities())
        //    {
               

        //        var allitms = from itm in _context.tbl_AllProduct
        //                        where (
        //                        (itm.Product_Name.StartsWith(prefixText)
        //                        || itm.Product_Code.StartsWith(prefixText)
        //                        ))
        //                        select itm;

        //        List<String> productList = new List<String>();

        //        foreach (var itms in allitms)
        //        {
        //            productList.Add(itms.Product_Name + "-" + itms.Product_Code);
        //        }

        //        //System.Threading.Thread.Sleep(500);
        //        return productList;
        //    }
        //}

        

        private void ClearUI()
        {
           
        }


        protected void gridProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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
                       
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //protected void txtProductName_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string itemName = txtProductName.Text;


               
        //            List<ProductR> sProductR = new List<ProductR>();
        //            sProductR = sProductBll.GetProductName(itemName).ToList();
        //            if (sProductR.Count > 0)
        //            {
        //                gridProduct.DataSource = sProductR;
        //                gridProduct.DataBind();
        //            }
               

        //    }
        //    catch (Exception ex)
        //    {

                
        //    }
        //}

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
             try
             {
                 string itemName = ddlProductName.SelectedItem.Text;
                 List<ProductR> sProductR = new List<ProductR>();
                 sProductR = sProductBll.GetProductName(itemName).ToList();
                 if (sProductR.Count > 0)
                 {
                     gridProduct.DataSource = sProductR;
                     gridProduct.DataBind();
                 }


             }
             catch (Exception ex)
             {


             }

        }

        protected void ddlOilType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string oiltype = ddlOilType.SelectedItem.Text;
                List<ProductR> sProductR = new List<ProductR>();
                sProductR = sProductBll.GetProductByOilType(oiltype).ToList();
                if (sProductR.Count > 0)
                {
                    gridProduct.DataSource = sProductR;
                    gridProduct.DataBind();
                }


            }
            catch (Exception ex)
            {


            }
        }
    }
}
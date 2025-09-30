using Family_Business.WMGS.DAL;
using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.BLL
{
     
    public class ProductBll
    {
        ProductDal sProductDal = new ProductDal();

        internal int SaveProduct(tbl_AllProduct stblProduct)
        {
            return sProductDal.SaveProduct(stblProduct);
        }

        internal List<ProductR> GetAllProduct()
        {
            return sProductDal.GetAllProduct();
        }

        internal tbl_AllProduct GetProductById(string productId)
        {
            return sProductDal.GetProductById(productId);
        }

        internal int UpdateProduct(tbl_AllProduct stblProduct, int productId)
        {
            return sProductDal.UpdateProduct(stblProduct, productId);
        }

        internal List<tbl_AllocationBox> GetOilLocation()
        {
            return sProductDal.GetOilLocation();
        }

        internal List<UserR> GetUser_Login(string UserName, string Password)
        {
            return sProductDal.GetUser_Login(UserName, Password);
        }


        internal List<ProductR> GetProductName(string itemName)
        {
            return sProductDal.GetProductName(itemName);
        }

        internal int DeleteProductById(string productId)
        {
            return sProductDal.DeleteProductById(productId);
        }

        internal List<ProductR> GetProductByOilType(string oiltype)
        {
            return sProductDal.GetProductByOilType(oiltype);
        }


        internal List<tbl_OilType> GetAllOilType()
        {
            return sProductDal.GetAllOilType();

        }

        internal int SaveShop(tbl_ShopName stbl_ShopName)
        {
            return sProductDal.SaveShop(stbl_ShopName);
        }

        internal List<tbl_ShopName> GetAllShop()
        {
            return sProductDal.GetAllShop();
        }

        internal int UpdateShop(tbl_ShopName stbl_ShopName, int shopId)
        {
            return sProductDal.UpdateShop(stbl_ShopName, shopId);
        }

        internal tbl_ShopName GetShopById(string shopId)
        {
            return sProductDal.GetShopById(shopId);
        }

        internal int DeleteShopById(string shopId)
        {
            return sProductDal.DeleteShopById(shopId);
        }

       
    }
}
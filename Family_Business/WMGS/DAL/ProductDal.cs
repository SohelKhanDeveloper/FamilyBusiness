using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.DAL
{
    public class ProductDal
    {
        FamilyBusinessEntities sFamilyBusinessEntities = new FamilyBusinessEntities();

        internal int SaveProduct(tbl_AllProduct stblProduct)
        {
            sFamilyBusinessEntities.tbl_AllProduct.Add(stblProduct);
            sFamilyBusinessEntities.SaveChanges();
            return 1;
        }

        internal List<ProductR> GetAllProduct()
        {
          
            try
            {


                return (from b in sFamilyBusinessEntities.tbl_AllProduct
                        join c in sFamilyBusinessEntities.tbl_OilType on b.OilType_Id equals c.Id
                        join p in sFamilyBusinessEntities.tbl_AllocationBox on b.Product_Location_Id equals p.id
                        orderby b.id descending
                        select new ProductR
                        {
                            id = b.id,
                            oilTypeid=c.Id,
                            oilType = c.OilType,
                            ProductCode = b.Product_Code,
                            ProductIndex = b.Product_Index,
                            ProductLocation = p.Oil_AllocationBox,   
                            ProductName=b.Product_Name,
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal tbl_AllProduct GetProductById(string productId)
        {
            int cId = Convert.ToInt32(productId);
            tbl_AllProduct product = sFamilyBusinessEntities.tbl_AllProduct.First(x => x.id == cId);

            return product;
        }

        internal int UpdateProduct(tbl_AllProduct stblProduct, int productId)
        {

            tbl_AllProduct objproduct = sFamilyBusinessEntities.tbl_AllProduct.First(x => x.id == productId);
            objproduct.ProductType_Id = stblProduct.ProductType_Id;
            objproduct.OilType_Id = stblProduct.OilType_Id;
            objproduct.Product_Name = stblProduct.Product_Name;
            objproduct.Product_Code = stblProduct.Product_Code;
            objproduct.Product_Location_Id = stblProduct.Product_Location_Id;
            objproduct.FragranceType = stblProduct.FragranceType;


            sFamilyBusinessEntities.SaveChanges();
            return 1;
        }

        internal List<tbl_AllocationBox> GetOilLocation()
        {
            try
            {
                var query = (from itm in sFamilyBusinessEntities.tbl_AllocationBox
                             select itm).OrderBy(x => x.id);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<UserR> GetUser_Login(string UserName, string Password)
        {
            try
            {
                using (var _context_db = new FamilyBusinessEntities())
                {

                    var Name = new SqlParameter("@Name", UserName);
                    var Pass = new SqlParameter("@Pass", Password);
                    string SP_SQL = "exec UserLogIn @Name,@Pass";

                    return (_context_db.Database.SqlQuery<UserR>(SP_SQL, Name,Pass)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<ProductR> GetProductName(string itemName)
        {
            try
            {

                return (from b in sFamilyBusinessEntities.tbl_AllProduct
                        join c in sFamilyBusinessEntities.tbl_OilType on b.OilType_Id equals c.Id
                        join p in sFamilyBusinessEntities.tbl_AllocationBox on b.Product_Location_Id equals p.id
                        orderby b.id descending
                        where b.Product_Name == itemName 
                        select new ProductR
                        {
                            id = b.id,
                            oilType = c.OilType,
                            ProductCode = b.Product_Code,
                            ProductIndex = b.Product_Index,
                            ProductLocation = p.Oil_AllocationBox,
                            ProductName = b.Product_Name,
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int DeleteProductById(string productId)
        {
            try
            {
                int objID = Convert.ToInt32(productId);
                tbl_AllProduct objProductId = sFamilyBusinessEntities.tbl_AllProduct.First(x => x.id == objID);
                sFamilyBusinessEntities.tbl_AllProduct.Remove(objProductId);
                sFamilyBusinessEntities.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ProductR> GetProductByOilType(string oiltype)
        {
            try
            {

                return (from b in sFamilyBusinessEntities.tbl_AllProduct
                        join c in sFamilyBusinessEntities.tbl_OilType on b.OilType_Id equals c.Id
                        join p in sFamilyBusinessEntities.tbl_AllocationBox on b.Product_Location_Id equals p.id
                        orderby b.id descending
                        where c.OilType == oiltype
                        select new ProductR
                        {
                            id = b.id,
                            oilType = c.OilType,
                            ProductCode = b.Product_Code,
                            ProductIndex = b.Product_Index,
                            ProductLocation = p.Oil_AllocationBox,
                            ProductName = b.Product_Name,
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<tbl_OilType> GetAllOilType()
        {
            try
            {
                var query = (from itm in sFamilyBusinessEntities.tbl_OilType
                             select itm).OrderBy(x => x.Id);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal int SaveShop(tbl_ShopName stbl_ShopName)
        {
            sFamilyBusinessEntities.tbl_ShopName.Add(stbl_ShopName);
            sFamilyBusinessEntities.SaveChanges();
            return 1;
        }

        internal List<tbl_ShopName> GetAllShop()
        {
            try
            {
                var query = (from shop in sFamilyBusinessEntities.tbl_ShopName
                             select shop).OrderBy(x => x.Id);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateShop(tbl_ShopName stbl_ShopName, int shopId)
        {
            tbl_ShopName objshop = sFamilyBusinessEntities.tbl_ShopName.First(x => x.Id == shopId);

            objshop.ShopName = stbl_ShopName.ShopName;
            objshop.ShopLocation = stbl_ShopName.ShopLocation;


            sFamilyBusinessEntities.SaveChanges();
            return 1;
        }

        internal tbl_ShopName GetShopById(string shopId)
        {
            int cId = Convert.ToInt32(shopId);
            tbl_ShopName product = sFamilyBusinessEntities.tbl_ShopName.First(x => x.Id == cId);

            return product;
        }

        internal int DeleteShopById(string shopId)
        {
            try
            {
                int objID = Convert.ToInt32(shopId);
                tbl_ShopName objId = sFamilyBusinessEntities.tbl_ShopName.First(x => x.Id == objID);
                sFamilyBusinessEntities.tbl_ShopName.Remove(objId);
                sFamilyBusinessEntities.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
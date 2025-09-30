using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.DAL
{
    public class SaleDAL
    {
        FamilyBusinessEntities context = new FamilyBusinessEntities();

        internal List<SalesR> GetAllShop()
        {
            try
            {

                return (from s in context.tbl_ShopName
                       
                        orderby s.Id descending
                        select new SalesR
                        {
                            id = s.Id,
                            ShopName = s.ShopName + " "+ s.ShopLocation,
                           
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int SaveSale(tbl_Sale stblSale)
        {
            context.tbl_Sale.Add(stblSale);
            context.SaveChanges();
            return 1;
        }

        internal List<SalesR> GetAllSales()
        {
            try
            {

                return (from a in context.tbl_Sale
                        join b in context.tbl_ShopName on a.ShopID equals b.Id
                        orderby a.Id descending
                        select new SalesR
                        {
                            id = a.Id,
                            ShopName = b.ShopName,
                            SaleDate =a.SaleDate,
                            ShopLocation = b.ShopLocation,
                            CashAmt = a.Cash,
                            CashAmtTax = a.Cash_Tax,
                            TotalCashAmt=a.Cash_Total,
                            CardAmt = a.Card,
                            CardAmtTax = a.Card_Tax,
                            TotalCardAmt=a.Card_Total,
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateSale(tbl_Sale stblSale, int SaleId)
        {
            tbl_Sale objSale = context.tbl_Sale.First(x => x.Id == SaleId);
            objSale.ShopID = stblSale.ShopID;
            objSale.SaleDate = stblSale.SaleDate;
            objSale.ShopID = stblSale.ShopID;
            objSale.Cash = stblSale.Cash;
            objSale.Cash_Tax = stblSale.Cash_Tax;
            objSale.Card = stblSale.Card;
            objSale.Card_Tax = stblSale.Card_Tax;

            //objSale.Edit_User = stblSale.Edit_User;
            //objSale.Edit_Date = stblSale.Edit_Date;


            context.SaveChanges();
            return 1;

        }

        internal tbl_Sale GetSaleById(string saleId)
        {
            int cId = Convert.ToInt32(saleId);
            tbl_Sale sale = context.tbl_Sale.First(x => x.Id == cId);

            return sale;
        }

        internal int DeleteSaleById(string saleId)
        {
            try
            {
                int objID = Convert.ToInt32(saleId);
                tbl_Sale objId = context.tbl_Sale.First(x => x.Id == objID);
                context.tbl_Sale.Remove(objId);
                context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        internal List<SalesR> GetSalesReport(DateTime fromDate)
        {
            try
            {
                using (var _context = new FamilyBusinessEntities())
                {
                    var FromDate = new SqlParameter("@fromDate", fromDate);
                    string SP_SQL = "rpt_Sale @fromDate";
                    return (_context.Database.SqlQuery<SalesR>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
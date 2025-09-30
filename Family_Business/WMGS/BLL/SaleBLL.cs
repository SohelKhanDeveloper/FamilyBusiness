using Family_Business.WMGS.DAL;
using Family_Business.WMGS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.BLL
{
    public class SaleBLL
    {
        SaleDAL sSaleDAL = new SaleDAL();

        internal List<SalesR> GetAllShop()
        {
            return sSaleDAL.GetAllShop();
        }

        internal int SaveSale(tbl_Sale stblSale)
        {
            return sSaleDAL.SaveSale(stblSale);
        }

        internal List<SalesR> GetAllSales()
        {
            return sSaleDAL.GetAllSales();
        }

        internal int UpdateSale(tbl_Sale stblSale, int SaleId)
        {
            return sSaleDAL.UpdateSale(stblSale, SaleId);
        }

        internal tbl_Sale GetSaleById(string saleId)
        {
            return sSaleDAL.GetSaleById(saleId);
        }

        internal int DeleteSaleById(string saleId)
        {
            return sSaleDAL.DeleteSaleById(saleId);
        }

        internal List<SalesR> GetSalesReport(DateTime fromDate)
        {
            return sSaleDAL.GetSalesReport(fromDate);
        }
    }
}
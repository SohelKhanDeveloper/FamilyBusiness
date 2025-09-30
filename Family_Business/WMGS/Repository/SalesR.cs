using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.Repository
{
    public class SalesR
    {
        public int id { get; set; }
        public string ShopName { get; set; }
        public string ShopLocation { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? CashAmt { get; set; }
        public decimal? CashAmtTax { get; set; }
        public decimal? TotalCashAmt { get; set; }
        public decimal? CardAmt { get; set; }
        public decimal? CardAmtTax { get; set; }
        public decimal? TotalCardAmt { get; set; }


        public string FullName { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? TotalAdvance { get; set; }
        


    }
}
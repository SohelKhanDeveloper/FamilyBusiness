using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS
{
    public class ProductR
    {
        public int id { get; set; }        
        public int oilTypeid { get; set; }
        public string ProdactTypeName { get; set; }       
        public string oilType { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductLocation { get; set; }
        public string ProductIndex { get; set; }
        public int FragranceType { get; set; }
        public int ProductType_Id { get; set; }
        public string ProductType { get; set; }
        public string Product_Code { get; set; }
        public string Product_Name { get; set; }
        public int Product_Location_Id { get; set; }
        public string Oil_AllocationBox { get; set; }
        public string Fragrance_Type { get; set; }
        public string Product_Index { get; set; }
        public string Oil_Type { get; set; }

    }
}
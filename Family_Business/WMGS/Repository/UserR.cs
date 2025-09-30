using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.Repository
{
    public class UserR
    {
            
        public System.Guid UserID { get; set; }
        public string UserName { get; set; }
        public string EmpID { set; get; }
        public string Password { get; set; }
    }
}
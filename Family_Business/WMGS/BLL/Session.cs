using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family_Business.WMGS.BLL
{
    public class Session
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string EID { set; get; }
        public string OCode { get; set; }
        public string RoleId { set; get; }
        //public string PCode { get; set; }
        public string User_Level { get; set; }
        public string UserFullName { set; get; }
        public string BranchID { get; set; }
        public string Company_Code { get; set; }
        public string Nature { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.DBIslemleri
{
    public class UyeDetay
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int statusId { get; set; }
        public int timestampId { get; set; }
        public int statusID { get; set; }
        public string statusName { get; set; }
        public int timestampID { get; set; }
        public System.DateTime create_time { get; set; }
        public System.DateTime update_time { get; set; }
    }
}
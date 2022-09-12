using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace WebApplication5.Models
{
    public class Prop
    {
        public int Id { get; set; }
        public string sno { get; set; }
        public int Action { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Pic { get; set; }
        public string Contact { get; set; }
        public string gender { get; set; }
        public string Msg { get; set; }
        public HttpPostedFileBase Picf { get; set; }
        public string Dob { get; set; }
        public string Stutas { get; set; }
        public DataTable dt { get; set; }
    }
}
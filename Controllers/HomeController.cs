using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using System.Data;
namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataLayer dl = new DataLayer();
        Prop p1 = new Prop();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            p1.Action = 2;
           p1.dt= dl.getallrecord(p1);

            return View(p1);
        }
        public JsonResult Insertstudent(Prop p)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                //string imgname = DateTime.UtcNow + file.FileName;
                file.SaveAs(Server.MapPath("/Content/pic/" + file.FileName));
                p.Pic = file.FileName;
            }
            p.dt= dl.getallrecord(p);
            if(p.dt!=null && p.dt.Rows.Count > 0)
            {
                p.sno = p.dt.Rows[0]["sc"].ToString();
            }

            return Json(p.sno, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getupdate(Prop p)
        {
            DataTable dt = dl.getallrecord(p);
            if(dt.Rows.Count>0 && dt != null)
            {
                p.Name = dt.Rows[0]["name"].ToString();
                p.Id = Convert.ToInt32( dt.Rows[0]["id"]);
                p.Email = dt.Rows[0]["email"].ToString();
                p.Pass = dt.Rows[0]["pass"].ToString();
                p.Contact = dt.Rows[0]["contact"].ToString();
                p.Dob = dt.Rows[0]["dob"].ToString();
                p.gender = dt.Rows[0]["gender"].ToString();
                p.Pic = ("../content/pic/"+dt.Rows[0]["pic"].ToString());
            }

            return Json(p,JsonRequestBehavior.AllowGet);
        }
    }
}
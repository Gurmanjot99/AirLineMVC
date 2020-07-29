using AirLineMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirLineMVC.Controllers
{
    public class HomeController : Controller
    {
        AirlineEntityEntities obj = new AirlineEntityEntities();

        public ActionResult QueryList()
        {
            return View(obj.Contacts.ToList());
        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(Contact IdtoDel)
        {
            var d = obj.Contacts.Where(x => x.id == IdtoDel.id).FirstOrDefault();
            obj.Contacts.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("QueryList");
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MainLogin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult LoginQuery(AdminLogin data)
        {


            
            String query = "select * from Login where Name='" + data.txtName + "' And Password='" + data.txtPassword + "'";
            DataTable tbl = new DataTable();
            tbl = data.SearchRecord(query);

            if (tbl.Rows.Count > 0)
            {
                return View("Dashboard");
            }
            else
            {
                return View("InvalidDetails");
            }

        }
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InvalidDetails()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FeedBack()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult postQuery(Query info)
        {

            //get the value from the user to pass in the database 

           

            String query = "insert into Contact(Name,Email,Msg) values('" + info.txtName + "','" + info.txtEmail + "','" + info.txtMsg + "')";

            info.AddDelUpdate(query);

            return View("FeedBack");


        }



    }
}
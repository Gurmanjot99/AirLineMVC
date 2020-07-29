using AirLineMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirLineMVC.Controllers
{
    public class EmployeeController : Controller
    {
        AirlineEntityEntities obj = new AirlineEntityEntities();

        // GET: Flight
        public ActionResult AllEmployees()
        {
            return View(obj.Employees.ToList());
        }

        // GET: Flight/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flight/Create
        [HttpPost]
        public ActionResult Create(Employee data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Employees.Add(data);
            obj.SaveChanges();
            
            return RedirectToAction("AllEmployees");

        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.Employees where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Flight/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee ID)
        {
            var orignalRecord = (from m in obj.Employees where m.id == ID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(ID);

            obj.SaveChanges();
            return RedirectToAction("AllEmployees");
        }

        // GET: Flight/Delete/5
        public ActionResult Delete(Employee IDtoDel)
        {
            var d = obj.Employees.Where(x => x.id == IDtoDel.id).FirstOrDefault();
            obj.Employees.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("AllEmployees");
        }

        // POST: Flight/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using AirLineMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirLineMVC.Controllers
{
    public class FlightController : Controller
    {
        AirlineEntityEntities obj = new AirlineEntityEntities();

        // GET: Flight
        public ActionResult AllFlights()
        {
            return View(obj.Flights.ToList());
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
        public ActionResult Create(Flight data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Flights.Add(data);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("AllFlights");

        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.Flights where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Flight/Edit/5
        [HttpPost]
        public ActionResult Edit(Flight ID)
        {
            var orignalRecord = (from m in obj.Flights where m.id ==ID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(ID);

            obj.SaveChanges();
            return RedirectToAction("AllFlights");
        }

        // GET: Flight/Delete/5
        public ActionResult Delete(Flight IDtoDel)
        {
            var d = obj.Flights.Where(x => x.id == IDtoDel.id).FirstOrDefault();
            obj.Flights.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("AllFlights");
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

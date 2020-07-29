using AirLineMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirLineMVC.Controllers
{
    public class BookingController : Controller
    {
        AirlineEntityEntities obj = new AirlineEntityEntities();

        // GET: Flight
        public ActionResult AllBookings()
        {
            return View(obj.Bookings.ToList());
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
        public ActionResult Create(Booking data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Bookings.Add(data);
            obj.SaveChanges();

            return RedirectToAction("AllBookings");

        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.Bookings where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Flight/Edit/5
        [HttpPost]
        public ActionResult Edit(Booking ID)
        {
            var orignalRecord = (from m in obj.Bookings where m.id == ID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(ID);

            obj.SaveChanges();
            return RedirectToAction("AllBookings");
        }

        // GET: Flight/Delete/5
        public ActionResult Delete(Booking IDtoDel)
        {
            var d = obj.Bookings.Where(x => x.id == IDtoDel.id).FirstOrDefault();
            obj.Bookings.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("AllBookings");
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

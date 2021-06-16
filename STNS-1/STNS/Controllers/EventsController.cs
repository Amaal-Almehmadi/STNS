using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using STNS.Models;

namespace STNS.Controllers
{
    public class EventsController : Controller
    {
       STNSEntities db = new STNSEntities();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }


        // Events / details 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {              // when receive many requests on the unsupported URL that  return 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Event_Number, Event_Title, Event_Description, DOE")]Event events)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);

        }


        public ActionResult Edit(int? id)
        {

            if (id == null)
            {              // when receive many requests on the unsupported URL that  return 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Event_Number, Event_Title, Event_Description, DOE")]Event events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(events);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {              // when receive many requests on the unsupported URL that  return 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event events = db.Events.Find(id);
            db.Events.Remove(events);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }






    }
}
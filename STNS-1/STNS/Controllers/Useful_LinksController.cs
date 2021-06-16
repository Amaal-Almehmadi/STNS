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
    public class Useful_LinksController : Controller
    {
        private STNSEntities db = new STNSEntities();

        // GET: Useful_Links
        public ActionResult Index()
        {
           return View(db.Useful_Links.ToList());
        }

        // GET: Useful_Links
        public ActionResult Show()
        {
            return View(db.Useful_Links.ToList());
        }


        // GET: Useful_Links/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Link_Number,Link_Title,Link_href")] Useful_Links useful_Links)
        {
            if (ModelState.IsValid)
            {
                db.Useful_Links.Add(useful_Links);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(useful_Links);
        }

        // GET: Useful_Links/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Useful_Links useful_Links = db.Useful_Links.Find(id);
            if (useful_Links == null)
            {
                return HttpNotFound();
            }
            return View(useful_Links);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Link_Number,Link_Title,Link_href")] Useful_Links useful_Links)
        {
            if (ModelState.IsValid)
            {
                db.Entry(useful_Links).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(useful_Links);
        }

        // GET: Useful_Links/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Useful_Links useful_Links = db.Useful_Links.Find(id);
            if (useful_Links == null)
            {
                return HttpNotFound();
            }
            return View(useful_Links);
        }

        // POST: Useful_Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Useful_Links useful_Links = db.Useful_Links.Find(id);
            db.Useful_Links.Remove(useful_Links);
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
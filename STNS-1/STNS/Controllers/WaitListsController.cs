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
    public class WaitListsController : Controller
    {
        private STNSEntities db = new STNSEntities();

        // GET: WaitLists
        public ActionResult Index()
        {
            return View(db.WaitList.ToList());
        }

        

        // GET: WaitLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaitList waitList = db.WaitList.Find(id);
            if (waitList == null)
            {
                return HttpNotFound();
            }
            return View(waitList);
        }

        // POST: WaitLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WaitList waitList = db.WaitList.Find(id);
            db.WaitList.Remove(waitList);
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

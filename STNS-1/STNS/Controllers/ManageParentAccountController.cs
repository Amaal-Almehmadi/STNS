using STNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace STNS.Controllers
{
    public class ManageParentAccountController : Controller
    {
        // GET: ManageParentAcount
        private STNSEntities account = new STNSEntities();
        // GET: ManageParentAcount
        public ActionResult Index()
        {
            var model = account.Parents.ToList();
            return View(model);
        }
      
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent manage2 = account.Parents.Find(id);
            if (manage2 == null)
            {
                return HttpNotFound();

            }
            return View(manage2);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = " Parent_Name,Parent_Nationality,Parent_password,Parent_Email,Parent_Phone")]Parent manage2)
        {
            if (ModelState.IsValid)
            {

                account.Entry(manage2).State = System.Data.Entity.EntityState.Modified;
                account.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(manage2);

        }
    }
}
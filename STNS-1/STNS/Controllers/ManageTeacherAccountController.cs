using STNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace STNS.Controllers
{
    public class ManageTeacherAccountController : Controller
    {
        // GET: ManageTeacherAccount
        private STNSEntities account = new STNSEntities();
        // GET: ManageTeacherAccount
        public ActionResult Index()
        {
            //
            var model = account.Teachers.ToList();
            return View(model);
        }

     
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher manage1 = account.Teachers.Find(id);
            if (manage1 == null)
            {
                return HttpNotFound();

            }
            return View(manage1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Teacher_National_Id,Teacher_Name,Teacher_Nationality,Teacher_password,Teacher_Username")]Teacher manage1)
        {
            if (ModelState.IsValid)
            {

                account.Entry(manage1).State = System.Data.Entity.EntityState.Modified;
                account.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(manage1);

        }
    }
}
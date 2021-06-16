using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using STNS.Models;

namespace STNS.Controllers
{
    public class ManageAdminAccountController : Controller
    {
        // GET: ManageAdminAccount
        private STNSEntities account = new STNSEntities();
        // GET: ManageAdminAccount
        public ActionResult Index()
        {

            var model = account.Adminstrators.ToList();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Adminstrator admin)
        {
            try
            { //  add new account for admin
                using (STNSEntities DbModel = new STNSEntities())
                {
                    DbModel.Adminstrators.Add(admin);
                    DbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception c)
            {
                throw c;
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminstrator admin = account.Adminstrators.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = " Admin_Name,Admin_Nationality,Admin_password,Admin_Email,Admin_Phone")] Adminstrator admin)
        {
            if (ModelState.IsValid)
            {
                account.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                account.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STNS.Models;
using System.Data.Entity;

namespace STNS.Controllers
{
    public class programController : Controller
    {
        // GET: program/index
        public ActionResult Index()
        {
            using (STNSEntities DbModel = new STNSEntities())
            {
                return View(DbModel.Programs.ToList());
            }
        }

        // GET: program/Details/5
        public ActionResult Details(int? id)
        {
            using (STNSEntities DbModel = new STNSEntities())
            {
                return View(DbModel.Programs.Where(x => x.Program_Id == id).FirstOrDefault());
            }
        }

        // GET: program/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: program/Create
        [HttpPost]
        public ActionResult Create(Program program)
        {
            try
            {  // add insert logic
                using (STNSEntities DbModel = new STNSEntities())
                {
                    DbModel.Programs.Add(program);
                    DbModel.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: program/Edit/5
        public ActionResult Edit(int id = 0)
        {
            using (STNSEntities DbModel = new STNSEntities())
            {
                return View(DbModel.Programs.Where(x => x.Program_Id == id).FirstOrDefault());
            }
        }

        // POST: program/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Program program)
        {
            try
            { //   update logic 
                STNSEntities DbModel = new STNSEntities();
                DbModel.Entry(program).State = EntityState.Modified;
                DbModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: program/Delete/5
        public ActionResult Delete(int id = 0)
        {
            using (STNSEntities DbModel = new STNSEntities())
            {
                return View(DbModel.Programs.Where(x => x.Program_Id == id).FirstOrDefault());

            }
        }

        // POST: program/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //  delete logic 
                using (STNSEntities DbModel = new STNSEntities())
                {
                   Program program = DbModel.Programs.Where(x => x.Program_Id == id).FirstOrDefault();
                    DbModel.Programs.Remove(program);
                    DbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
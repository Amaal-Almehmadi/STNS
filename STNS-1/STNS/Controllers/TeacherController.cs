using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STNS.Models;

namespace STNS.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/index
        public ActionResult Index()
        {
            using (STNSEntities DbModel = new STNSEntities())
            {
                return View(DbModel.Teachers.ToList());
            }
        }

        // GET: Teacher/Details/
        public ActionResult Details(int id)
        {
            using (STNSEntities DbModel = new STNSEntities())
            {
                return View(DbModel.Teachers.Where(x => x.Teacher_National_Id == id).FirstOrDefault());
            }
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher Teacher)
        {
            try
            { //  Add insert logic 
                using (STNSEntities DbModel = new STNSEntities())
                {
                    DbModel.Teachers.Add(Teacher);
                    DbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch( Exception c)
            {
                throw c;
                return View();
            }
        }

        // GET: Teacher/Edit/
        public ActionResult Edit(int? id)
        {
            using (STNSEntities DbModel = new STNSEntities())
            {
                return View(DbModel.Teachers.Where(x => x.Teacher_National_Id == id).FirstOrDefault());
            }
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Teacher Teacher)
        {
            try
            { //   update logic 
                STNSEntities DbModel = new STNSEntities();
                DbModel.Entry(Teacher).State = EntityState.Modified;
                DbModel.SaveChanges();
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/
        public ActionResult Delete(int id)
        {
            using (STNSEntities DbModel = new STNSEntities())
            {
                return View(DbModel.Teachers.Where(x => x.Teacher_National_Id == id).FirstOrDefault());

            }
        }

        // POST: Teacher/Delete/
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //  delete logic 
                using (STNSEntities DbModel = new STNSEntities())
                {
                    Teacher Teacher = DbModel.Teachers.Where(x => x.Teacher_National_Id == id).FirstOrDefault();
                    DbModel.Teachers.Remove(Teacher);
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
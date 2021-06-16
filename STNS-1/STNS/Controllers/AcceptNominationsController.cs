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
    public class AcceptNominationsController : Controller
    {
        STNSEntities db = new STNSEntities();

        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomination nomination = db.Nominations.Find(id);
            if (nomination == null)
            {
                return HttpNotFound();
            }
            return View(nomination);
        }

        // POST: Nominations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public ActionResult Accept(Nomination model)
        {

            var parent = new Parent
            {
                Parent_Name = model.Mother_Name,
                Parent_Nationality = model.Mother_Nationality,
                Parent_National_Id = model.Mother_Nationad_ID.Value,
                Parent_Email = model.Mother_Email,
                Parent_password = Convert.ToString(model.Mother_Nationad_ID),
                Parent_Phone = model.Mother_Phone,
                Parent_Username = model.Mother_Name,
                Parent_state = model.Mother_state,
                Parent_College = model.College,
                Parent_role = model.role

            };
            db.Parents.Add(parent);
            var child_class = new Child();
            if (model.Monthly_Age == 1) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 2) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 3) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 4) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 5) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 6) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 7) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 8) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 9) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 10) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 11) { child_class.Program_Id = 1; }
            if (model.Monthly_Age == 12) { child_class.Program_Id = 1; }
            if (model.Years_Age == 1) { child_class.Program_Id = 2; }
            if (model.Years_Age == 2) { child_class.Program_Id = 3; }
            if (model.Years_Age == 3) { child_class.Program_Id = 4; }
            if (model.Years_Age == 4) { child_class.Program_Id = 5; }
            if (model.Years_Age == 5) { child_class.Program_Id = 6; }

            var child = new Child
            {
                Child_Munth_Age = model.Monthly_Age,
                Child_year_Age = model.Years_Age,
                Child_National_Id = model.Child_Id,
                Child_Name = model.Child_Fullname,
                Child_BirthDate = model.Child_BirthDate,
                Child_Nationality = model.Child_Nationality,
                Child_Gender = model.Child_Gender,
                Mother = model.Mother_Nationad_ID

            };

            db.Children.Add(child);
            db.SaveChanges();

            return RedirectToAction("index");
        }
        public ActionResult AddToWaitList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomination nomination = db.Nominations.Find(id);
            if (nomination == null)
            {
                return HttpNotFound();
            }
            return View(nomination);
        }
        [HttpPost]
        public ActionResult AddToWaitList(Nomination model)
        {
           
            var waitlist = new WaitList
            {
                Monthly_Age = model.Monthly_Age,
                Years_Age = model.Years_Age,
                Child_Id = model.Child_Id,
                Child_Fullname = model.Child_Fullname,
                Child_BirthDate = model.Child_BirthDate,
                Child_Nationality = model.Child_Nationality,
                Child_Gender = model.Child_Gender,
                Mother_Name = model.Mother_Name,
                Mother_Nationality = model.Mother_Nationality,
                Mother_Nationad_ID = model.Mother_Nationad_ID.Value,
               Mother_Email = model.Mother_Email,
                Mother_Phone = model.Mother_Phone,
                Mother_state=model.Mother_state,
                College=model.College,
                role=model.role
            };
            db.WaitList.Add(waitlist);
            db.SaveChanges();

            return RedirectToAction("index");
        }
        public string ActionMethordNam(string id)
        {

            int count = db.Children.Where(x => x.branch == id).ToList().Count;


            //foreach (var item in db.Children.ToList())
            //{
            //    int id = item.Child_National_Id;

            //    //SystemsCount 
            //    int count = db.Children.Where(x => x.branch == "").Count();
            string s = "the number of child in this branch" + id + "العدد" + count;
            // }
            return (s);
        }

        public ActionResult Index()
        {
            return View(db.Nominations.ToList());
        }

    }
}
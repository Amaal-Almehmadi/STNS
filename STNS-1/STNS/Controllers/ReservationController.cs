using STNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STNS.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            var model = new Reservations();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Reservations model)
        {
            var db = new  STNSEntities();
            //Check If Reservation Allowed
            var SameDayTotalReservations = db.Reservations.ToList().Count(x => x.ReservationDate.Date == model.ReservationDate.Date);
            if (SameDayTotalReservations < 15)
            {
                db.Reservations.Add(model);
                db.SaveChanges();
                ViewBag.Message = "تم حجز الموعد بنجاح";
                ViewBag.IsSaved = true;
            }
            else
            {
                ViewBag.Message = "من فضلك قم باختيار موعد اخر";
            }
            ModelState.Clear();
            return View();
        }
        public ActionResult GetOldReservations()
        {
            var db = new STNSEntities();
            var data = db.Reservations.ToList().Select(x => new
            {
                start = x.ReservationDate.ToString("yyyy-MM-dd"),
                title = "\n"
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Admin()
        {
            var db = new STNSEntities();
            var data = db.Reservations.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Admin(int? Accept, int? Reject)
        {
            var db = new STNSEntities();
            var id = Accept.HasValue ? Accept.Value : Reject.Value;
            var reservation = db.Reservations.FirstOrDefault(x => x.Id == id);
            if (reservation != null)
            {
                if (Accept.HasValue)
                    reservation.Accepted = true;
                else
                    reservation.Accepted = false;
                db.SaveChanges();
            }
            return View(db.Reservations.ToList());
        }

    }
}
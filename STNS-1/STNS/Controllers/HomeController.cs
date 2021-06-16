using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using STNS.Models;

namespace STNS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (STNSEntities db = new STNSEntities())
            {
                return View(db.Rotator.ToList());
            }
            //return View();
        }

        //Add Images in slider

        public ActionResult AddImage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null)
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(ImagePath.InputStream);
                // Upload your pic
                string pic = System.IO.Path.GetFileName(ImagePath.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/Rotator"), pic);
                ImagePath.SaveAs(path);
                using (STNSEntities db = new STNSEntities())
                {
                    Rotator rr = new Rotator();
                    rr.ImagePath = "~/Content/Rotator/" + pic;
                    rr.Href = Request.Form["Href"];
                    rr.Title = Request.Form["Title"];
                    rr.HrefTitle = Request.Form["HrefTitle"];
                    db.Rotator.Add(rr);
                    db.SaveChanges();

                }
            }
            return RedirectToAction("Index");
        }

        // Delete Multiple Images
        public ActionResult DeleteImages()
        {
            using (STNSEntities db = new STNSEntities())
            { //list the images that we want to delete it
                return View(db.Rotator.ToList());
            }
        }

        [HttpPost]
        // delete images by thier id
        public ActionResult DeleteImages(IEnumerable<int> ImagesIDs)
        {
            using (STNSEntities db = new STNSEntities())
            {// get all the images in database
                foreach (var id in ImagesIDs)
                {
                    var image = db.Rotator.Single(s => s.ID == id);
                    // get image's path
                    string imgPath = Server.MapPath(image.ImagePath);
                    db.Rotator.Remove(image);
                    if (System.IO.File.Exists(imgPath))
                        System.IO.File.Delete(imgPath);

                }
                db.SaveChanges();
            }
            return RedirectToAction("DeleteImages");
        }
        public ActionResult location()
        {

            return View();
        }
        public ActionResult ourPrograms()
        {
            return View();
        }
    }
}
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
    public class PhotosController : Controller
    {

        STNSEntities db = new STNSEntities();

        // GET: Photos
        public ActionResult Index()
        {
            return View(db.Photos.ToList());
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            ViewBag.Albums = db.Albums.ToList();

            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,PhotoId,PhotoTitle,photoDate,UserPhoto")] Photo photo, HttpPostedFileBase upload)
        {


                if (upload != null && upload.ContentLength > 0) /* means uploaded somthing */
                {
                    var aphoto = new UserPhotoFile /* AlbumImageFile is a sub from File class */
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),/* complete file name */
                        contentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream)) /* To upload the image file in the Db*/
                    {
                        aphoto.content = reader.ReadBytes(upload.ContentLength); /* the reader wich i initialis with the binary reader takes the input stream of the uploaded file and read it in bytes*/
                    }
                    photo.UserPhoto = aphoto;
                }



                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
          

            return View(photo);
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            ViewBag.Albums = db.Albums.ToList();

            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoId,PhotoTitle,photoDate,UserPhoto,AlbumId,UserPhoto.FileId")] Photo photo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {


                db.Entry(photo).State = EntityState.Modified;
                try
                {



                    db.SaveChanges();
                    if (upload != null && upload.ContentLength > 0) /* means uploaded somthing */
                    {
                        Models.File f = db.Files.Where(x => x.FileId == photo.UserPhoto.FileId).First();
                        f.FileName = System.IO.Path.GetFileName(upload.FileName);
                        f.contentType = upload.ContentType;
                        using (var reader = new System.IO.BinaryReader(upload.InputStream)) /* To upload the image file in the Db*/
                        {
                            f.content = reader.ReadBytes(upload.ContentLength); /* the reader wich i initialis with the binary reader takes the input stream of the uploaded file and read it in bytes*/
                        }
                        db.Entry(f).State = EntityState.Modified;
                        db.SaveChanges();
                    }



                }
                catch (Exception x)
                {

                    throw x;
                }

                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
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
using STNS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace STNS.Controllers
{
    public class AlbumsController : Controller
    {
        STNSEntities db = new STNSEntities();
        // GET: Albums
        public ActionResult Index()
        {
            return View(db.Albums.ToList());
        }

        public ActionResult ShowGallery(int? id)
        {

            return View(db.Albums.ToList());
        }
        public ActionResult ShowAlbumPhotos(int id)
        {


            return View(db.Photos.Where(x => x.AlbumId == id));
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,AlbumTitle")] Album album, HttpPostedFileBase upload) /*HttpPostedFileBase upload contain all information about file aploaded*/
        {
            if (ModelState.IsValid)
            { /* add code for apload file */
                if (upload != null && upload.ContentLength > 0) /* means uploaded somthing */
                {
                    var photo = new AlbumImageFile /* AlbumImageFile is a sub from File class */
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),/* complete file name */
                        contentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream)) /* To upload the image file in the Db*/
                    {
                        photo.content = reader.ReadBytes(upload.ContentLength); /* the reader wich i initialis with the binary reader takes the input stream of the uploaded file and read it in bytes*/
                    }
                    album.Photo = photo;
                }

                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,AlbumTitle")] Album album, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                if (upload != null && upload.ContentLength > 0) /* means will change the exixt img only if theres an uploaded */
                {/* when retreive the model should retrive the relative model and the img is part original*/
                    album.Photo = db.Albums.Include(i => i.Photo).SingleOrDefault(c => c.AlbumId == album.AlbumId).Photo;
                    album.Photo.FileName = System.IO.Path.GetFileName(upload.FileName);
                    album.Photo.contentType = upload.ContentType; /* to edit the exsits img*/
                    using (var reader = new System.IO.BinaryReader(upload.InputStream)) /* To upload the image file in the Db*/
                    {
                        album.Photo.content = reader.ReadBytes(upload.ContentLength); /* the reader wich i initialis with the binary reader takes the input stream of the uploaded file and read it in bytes*/
                    }

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
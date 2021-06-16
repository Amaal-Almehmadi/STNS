
using STNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STNS.Controllers
{
    public class FilesController : Controller
    {
        private STNSEntities db = new STNSEntities();


        // GET: Files
        public ActionResult Index(int id)
        { /* retrive approprate file*/
            /*first reteive from Db*/
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.content, fileToRetrieve.contentType);

        }
    }
}
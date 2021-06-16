using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STNS.Models;
using System.IO;

namespace STNS.Controllers
{
    public class DoNominationController : Controller
    {
        STNSEntities db = new STNSEntities();
        // GET: Nomination
        public ActionResult Nomination()
		{

			return View();
		}
		[HttpPost]
		public ActionResult Nomination(Nomination model)
		{

			
			db.Nominations.Add(model);
			db.SaveChanges();
			int id = model.Child_Id;
            //return View(model);
            return RedirectToAction("Downloads", "DoNomination");
		}
		public ActionResult print()
		{
			var print_from = new ActionAsPdf("Nomination");
			return print_from;
		}
        public ActionResult stepForRegesterion()
        {
           
            return View("stepForRegesterion");
        }
        public ActionResult Downloads()
		{
			var dir = new DirectoryInfo(Server.MapPath("~/App_Data/regestre_file/"));
			FileInfo[] fileNames = dir.GetFiles("*.*");
			List<string> items = new List<string>();
			foreach (var file in fileNames)
			{
				items.Add(file.Name);
			}
			return View(items);
		}
		public FileResult Download(string ImageName)
		{
			var FileVirtualPath = "~/App_Data/regestre_file/" + ImageName;
			return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
		}
	}
}
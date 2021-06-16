using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STNS.Models;

namespace STNS.Controllers
{
    public class DoDelegationController : Controller
    {
		STNSEntities db = new STNSEntities();
		// GET: DoDelegation
		public ActionResult delegation()
		{

			return View();


		}
		[HttpPost]
		public ActionResult delegation(Delegation model)
		{

			db.Delegations.Add(model);
			db.SaveChanges();
			int id = model.id;
			return View(model);



		}
		public ActionResult print()
		{
			var print_from = new ActionAsPdf("delegation");
			return print_from;
		}

	}
}
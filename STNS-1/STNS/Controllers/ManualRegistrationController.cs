using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STNS.Models;
using Rotativa;

namespace STNS.Controllers
{
    public class ManualRegistrationController : Controller
    {
		STNSEntities db = new STNSEntities();
		// GET: ManualRegistration
		public ActionResult ManualRegistration()
		{


			return View();
		}

		[HttpPost]
		public ActionResult ManualRegistration(AcceptanceInfoModel model)
        {
			var parent = new Parent
			{

				Parent_Name = model.ParentName,
				Parent_Nationality = model.ParentNationality,
				Parent_National_Id = model.ParentNational_Id,
				Parent_password = model.Parentpassword,
				Parent_Username = model.ParentUsername

			};
			db.Parents.Add(parent);
			db.SaveChanges();
			
			var child = new Child
			{
                Child_Munth_Age = model.Monthl_Age,
				Child_year_Age=model.Year_Age,
				Child_National_Id = model.ChildNational_Id,
				Child_Name = model.ChildName,
				Child_BirthDate = model.ChildBirthDate,
				Child_Nationality = model.ChildNationality,
				Child_Gender = model.ChildGender,
				Mother = model.ParentNational_Id

			};
			
			db.Children.Add(child);
			db.SaveChanges();

			return View(model);
		}
        public ActionResult print()
        {
            var print_from = new ActionAsPdf("ManualRegistration");
            return print_from;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using STNS.Models;

namespace STNS.Controllers
{
    public class ComunicationController : Controller
    {
        STNSEntities db = new STNSEntities();
        // GET: Comunication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmails()
        {
            
            var model = new SendEmailModel(); // the list fills parents from db
            model.parents = db.Parents.ToList();
            return View(model);
        }

        // this action when user click on send button
        [HttpPost]
        public ActionResult SendEmails(SendEmailModel model)
        {
            var db = new STNSEntities();
            model.parents = db.Parents.ToList();
            if (model.SelectedParents.Any()) // to be sure that user choose one of emails
            {
                //WebConfigurationManager.AppSettings[""]
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(WebConfigurationManager.AppSettings["Email_User"]);

                SmtpClient client = new SmtpClient();
                client.Port = int.Parse(WebConfigurationManager.AppSettings["Email_Port"]);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                client.Credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["Email_User"],
                WebConfigurationManager.AppSettings["Email_password"]);
                client.EnableSsl = true;
                client.Host = WebConfigurationManager.AppSettings["Email_Host"];
                mail.Subject = model.Subject;
                mail.Body = model.EmailBody;

                // loop for all parents selected from user 
                foreach (var id in model.SelectedParents)
                {
                    var parent = db.Parents.FirstOrDefault(x => x.Parent_National_Id == id);
                    if (parent != null)
                        // after getting the parents by his ID, take his email to add to send list 
                        mail.To.Add(parent.Parent_Email);
                }
                client.Send(mail);
            }
            else
            { ModelState.AddModelError("", "لم يتم اختيار ولي أمر"); }
            return View(model);
        }




        public ActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBlog(Blog model)
        {
            if (ModelState.IsValid)
            {
                var db = new STNSEntities();
                model.Blog_CreatedAt = DateTime.Now;
                db.Blogs.Add(model);
                db.SaveChanges();
                ViewBag.Message = "تم اضافة التدوينة بنجاح";
            }
            return View(model);
        }

        public ActionResult Blogs()
        {
            var db = new STNSEntities();
            var blogs = db.Blogs.ToList();
            return View(blogs);
        }
    }
}
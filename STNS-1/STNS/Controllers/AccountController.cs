using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STNS.Models;
using System.Net.Mail;
using System.Net;

namespace STNS.Controllers
{
    public class AccountController : Controller
    {
        STNSEntities db = new STNSEntities();

        public ActionResult Index()
        {
            return View();
        }
        // GET: Account
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {     //check for Admin login
                var admin = db.Adminstrators.FirstOrDefault(x => x.Admin_Username == model.UserName
                && x.Admin_password == model.Password);
                if (admin != null)
                {
                    Session["Admin"] = admin.Admin_National_Id;
                    return RedirectToAction("Index");
                }
                else
                {
                    //check for parent login
                    var parent = db.Parents.FirstOrDefault(x => x.Parent_Username == model.UserName
                    && x.Parent_password == model.Password);
                    if (parent != null)
                    {
                        Session["parent"] = parent.Parent_National_Id;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //check for teacher login
                        var teacher = db.Teachers.FirstOrDefault(x => x.Teacher_Username == model.UserName
                        && x.Teacher_password == model.Password);
                        if (teacher != null)
                        {
                            Session["teacher"] = teacher.Teacher_National_Id;
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "المستخدم غير موجود او البينات المدخلة غير صحيحة");
                        }

                    }
                }
            }
            return View(model);
        }
        public ActionResult logout()
        {
            Session["Admin"] = Session["parent"] = Session["teacher"] = null;
            return Redirect("/");
        }

        public void SendEmail(string emailID, string activationCode)
        {// create Url of reset password page
            var verifyUrl = "/Account/ResetPassword/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            // create message that will sent from STNS email
            var fromEmail = new MailAddress("Snabel.Taibah1@gmail.com", "Sanabel Taibah Nursery System");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "Snabel123456";
            string subject = " ";
            string body = " ";
            // message body
            subject = "إعادة تعيين كلمة المرور";
            body = "<br/><br/>انقر فوق الرابط الموجود في الاسفل لإعادة تعيين كلمة المرور الخاصة بك" +
  " <br/><br/><a href=" + link + ">إعادة تعيين كلمة المرور</a> ";
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (MailMessage message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {
            string message = " ";
            bool status = false;
            // check if email is for admin 
            var admin = db.Adminstrators.Where(a => a.Admin_Email == EmailID).FirstOrDefault();
            if (admin != null)
            {
                string resetCode = Guid.NewGuid().ToString();
                SendEmail(admin.Admin_Email, resetCode);
                admin.ResetPasswordCode = resetCode;
                db.Configuration.ValidateOnSaveEnabled = false;

                db.SaveChanges();
                message = " تم ارسال رابط اعادة تعيين كلمة المرور الى ايميلك";
            }
            else // check if email is for parent
            {
                var parent = db.Parents.Where(a => a.Parent_Email == EmailID).FirstOrDefault();
                if (parent != null)
                {
                    string resetCode = Guid.NewGuid().ToString();
                    SendEmail(parent.Parent_Email, resetCode);
                    parent.ResetPasswordCode = resetCode;
                    db.Configuration.ValidateOnSaveEnabled = false;

                    db.SaveChanges();
                    message = " تم ارسال رابط اعادة تعيين كلمة المرور الى ايميلك";
                }
                else  // check if email is for teacher
                {
                    var teacher = db.Teachers.Where(a => a.Teacher_Email == EmailID).FirstOrDefault();
                    if (teacher != null)
                    {
                        string resetCode = Guid.NewGuid().ToString();
                        SendEmail(teacher.Teacher_Email, resetCode);
                        teacher.ResetPasswordCode = resetCode;
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = " تم ارسال رابط اعادة تعيين كلمة المرور الى ايميلك";
                    }
                    else
                    {// message appears if email does not in database
                        message = "عنوان البريد الالكتروني المدخل غير مسجل في الموقع , اعد ادخال عنوان بريد الكتروني اخر او تاكد من كتابتة بشكل صحيح   ";

                    }
                }
            }
            ViewBag.Message = message;
            return View();
        }
        public ActionResult ResetPassword(string id)
        {
            var admin = db.Adminstrators.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
            if (admin != null)
            {
                ResetPasswordModel model = new ResetPasswordModel();
                model.ResetCode = id;
                return View(model);
            }
            else
            {
                var teacher = db.Teachers.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (teacher != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    var parent = db.Parents.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                    if (parent != null)
                    {
                        ResetPasswordModel model = new ResetPasswordModel();
                        model.ResetCode = id;
                        return View(model);
                    }
                }

            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = " ";
            if (ModelState.IsValid)
            {// save new password for admin
                var admin = db.Adminstrators.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                if (admin.Admin_password != null)
                {
                    admin.Admin_password = model.NewPassword;
                    admin.ResetPasswordCode = " ";
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    message = " تم تحديث كلمة المرور بنجاح ";
                }
                else
                {  // save new password for teacher
                    var Teacher = db.Teachers.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (Teacher.Teacher_password != null)
                    {
                        Teacher.Teacher_password = model.NewPassword;
                        Teacher.ResetPasswordCode = " ";
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = " تم تحديث كلمة المرور بنجاح ";
                    }
                    else
                    {   // save new password for parent                  
                        var parent = db.Parents.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                        if (parent.Parent_password != null)
                        {
                            parent.Parent_password = model.NewPassword;
                            parent.ResetPasswordCode = " ";
                            db.Configuration.ValidateOnSaveEnabled = false;
                            db.SaveChanges();
                            message = " تم تحديث كلمة المرور بنجاح ";
                        }
                    }
                }
            }
            else
            {
                message = " لم يتم تحديث كلمة المرور ! اعد المحاولة";
            }
            ViewBag.Message = message;
            return View(model);
        }
    }
}
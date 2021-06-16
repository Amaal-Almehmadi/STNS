using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STNS.Models
{
    public class LoginModel
    {
        [DisplayName("اسم المستخدم")]
        [Required(ErrorMessage = "من فضلك ادخل اسم المستخدم")]
        public string UserName { get; set; }
        [DisplayName("كلمة المرور")]
        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور")]
        public string Password { get; set; }
    }
}
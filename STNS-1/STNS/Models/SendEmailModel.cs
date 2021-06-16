using STNS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STNS.Models
{
    public class SendEmailModel
    {
        [Required(ErrorMessage = "من فضلك ادخل عنوان الرسالة")]
        [DisplayName("عنوان الرسالة")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل نص الرسالة")]

        [DisplayName("نص الرسالة")]
        public string EmailBody { get; set; }

        // to make list of parents name to be displayed in website 
        public List<Parent> parents { get; set; }

        // to receive the IDs of parents that you already were selected 
        public List<int> SelectedParents { get; set; }

        public SendEmailModel()
        {    // to make new list when the object created 
            parents = new List<Parent>();
            SelectedParents = new List<int>();
        }
    }
}
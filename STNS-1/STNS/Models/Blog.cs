﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STNS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Blog
    {
        [Key]
        public int Blog_Number { get; set; }
        [DisplayName("محتوى التدوينة")]
        [Required(ErrorMessage = "من فضلك ادخل محتوى التدوينة")]
        public string Blog_Content { get; set; }
        public Nullable<System.DateTime> Blog_CreatedAt { get; set; }
    }
}

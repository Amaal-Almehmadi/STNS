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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Teacher
    {
    
        public string Teacher_Name { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Teacher_National_Id { get; set; }
        public string Teacher_Nationality { get; set; }
        public string Teacher_password { get; set; }
        public string Teacher_Username { get; set; }
        public String Teacher_Email { get; set; }
        public string Teacher_Phone { get; set; }
        public string ResetPasswordCode { get; set; }
    }
}

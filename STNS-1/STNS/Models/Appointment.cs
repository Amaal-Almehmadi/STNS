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

    public partial class Appointment
    {
        [Key]
        public int Appointment_Number { get; set; }
        public Nullable<int> Prnt_id { get; set; }
        public Nullable<int> Chld_id { get; set; }
        public string Prnt_Name { get; set; }
        public string Chld_Name { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
    
        public virtual Child Child { get; set; }
        public virtual Parent Parent { get; set; }
    }
}

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
    
  
    public partial class Reservations
    {
        public int Id { get; set; }
        public System.DateTime ReservationDate { get; set; }
        public string UserName { get; set; }
        public Nullable<bool> Accepted { get; set; }
    }
}

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
    
    public partial class Album
    {
        public virtual int AlbumId { get; set; }
        public virtual string AlbumTitle { get; set; }
        public virtual AlbumImageFile Photo { get; set; }
        public List<Photo> Photos { get; set; }
    }
}

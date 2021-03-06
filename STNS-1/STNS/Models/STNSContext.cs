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
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class STNSEntities : DbContext
    {


        public STNSEntities()
            : base("name=STNSEntities")
        {

        }


        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Adminstrator> Adminstrators { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Class_Activity> Class_Activity { get; set; }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Useful_Links> Useful_Links { get; set; }
        public DbSet<Weekly_Task> weekly_Task { get; set; }
        public DbSet<Rotator> Rotator { get; set; }
      public DbSet<WaitList> WaitList { get; set; }

    }
}

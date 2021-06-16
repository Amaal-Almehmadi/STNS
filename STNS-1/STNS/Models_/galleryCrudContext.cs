using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace STNS.Models
{
    public class galleryCrudContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<galleryCrudContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
        public galleryCrudContext() : base("name=galleryCrudContext")
        {
        }

        public System.Data.Entity.DbSet<STNS.Models.Album> Albums { get; set; }
        public System.Data.Entity.DbSet<STNS.Models.Photo> Photos { get; set; }
        public System.Data.Entity.DbSet<STNS.Models.File> Files { get; set; }

    }
}

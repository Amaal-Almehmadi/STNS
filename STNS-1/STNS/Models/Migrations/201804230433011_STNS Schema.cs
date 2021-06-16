namespace STNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class STNSSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adminstrators",
                c => new
                    {
                        Admin_National_Id = c.Int(nullable: false),
                        Admin_Name = c.String(),
                        Admin_Nationality = c.String(),
                        Admin_password = c.String(),
                        Admin_Username = c.String(),
                        Admin_Email = c.String(),
                        Admin_Phone = c.String(),
                        ResetPasswordCode = c.String(),
                    })
                .PrimaryKey(t => t.Admin_National_Id);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumTitle = c.String(),
                        Photo_FileId = c.Int(),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Files", t => t.Photo_FileId)
                .Index(t => t.Photo_FileId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        contentType = c.String(maxLength: 150),
                        content = c.Binary(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        PhotoTitle = c.String(),
                        photoDate = c.DateTime(),
                        AlbumId = c.Int(),
                        UserPhoto_FileId = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Albums", t => t.AlbumId)
                .ForeignKey("dbo.Files", t => t.UserPhoto_FileId)
                .Index(t => t.AlbumId)
                .Index(t => t.UserPhoto_FileId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Appointment_Number = c.Int(nullable: false, identity: true),
                        Prnt_id = c.Int(),
                        Chld_id = c.Int(),
                        Prnt_Name = c.String(),
                        Chld_Name = c.String(),
                        Time = c.DateTime(),
                        Child_Child_National_Id = c.Int(),
                        Parent_Parent_National_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Appointment_Number)
                .ForeignKey("dbo.Children", t => t.Child_Child_National_Id)
                .ForeignKey("dbo.Parents", t => t.Parent_Parent_National_Id)
                .Index(t => t.Child_Child_National_Id)
                .Index(t => t.Parent_Parent_National_Id);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        Child_National_Id = c.Int(nullable: false),
                        Child_Name = c.String(),
                        Child_Munth_Age = c.Int(),
                        Child_year_Age = c.Int(),
                        Child_Nationality = c.String(),
                        Child_Gender = c.String(),
                        branch = c.String(),
                        Child_BirthDate = c.DateTime(),
                        Program_Id = c.Int(nullable: false),
                        Mother = c.Int(),
                        Parent_Parent_National_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Child_National_Id)
                .ForeignKey("dbo.Parents", t => t.Parent_Parent_National_Id)
                .ForeignKey("dbo.Programs", t => t.Program_Id, cascadeDelete: true)
                .Index(t => t.Program_Id)
                .Index(t => t.Parent_Parent_National_Id);
            
            CreateTable(
                "dbo.Delegations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        child_Id = c.Int(),
                        Parent_id = c.Int(),
                        Delegated_person_Name = c.String(),
                        Reason = c.String(),
                        Date = c.DateTime(),
                        Delegated_person_id = c.Int(),
                        Child_Child_National_Id = c.Int(),
                        Parent_Parent_National_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Children", t => t.Child_Child_National_Id)
                .ForeignKey("dbo.Parents", t => t.Parent_Parent_National_Id)
                .Index(t => t.Child_Child_National_Id)
                .Index(t => t.Parent_Parent_National_Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Parent_National_Id = c.Int(nullable: false),
                        Parent_Name = c.String(),
                        Parent_Nationality = c.String(),
                        Parent_Email = c.String(),
                        Parent_Phone = c.Int(),
                        Parent_password = c.String(),
                        Parent_Username = c.String(),
                        ResetPasswordCode = c.String(),
                        Parent_state = c.String(),
                        Parent_role = c.String(),
                        Parent_College = c.String(),
                    })
                .PrimaryKey(t => t.Parent_National_Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Program_Id = c.Int(nullable: false, identity: true),
                        Program_Name = c.String(),
                        Program_Age_ByMonth = c.Int(),
                        Program_Age_ByYear = c.Int(),
                    })
                .PrimaryKey(t => t.Program_Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Blog_Number = c.Int(nullable: false, identity: true),
                        Blog_Content = c.String(nullable: false),
                        Blog_CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Blog_Number);
            
            CreateTable(
                "dbo.Class_Activity",
                c => new
                    {
                        Activity_number = c.Int(nullable: false, identity: true),
                        Activity_date = c.DateTime(),
                        Activity_Description = c.String(),
                    })
                .PrimaryKey(t => t.Activity_number);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Event_Number = c.Int(nullable: false, identity: true),
                        Event_Title = c.String(),
                        Event_Description = c.String(),
                        Start_date = c.DateTime(),
                        End_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Event_Number);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FAQ_Number = c.Int(nullable: false, identity: true),
                        FAQ_Question = c.String(nullable: false),
                        FAQ_Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FAQ_Number);
            
            CreateTable(
                "dbo.Nominations",
                c => new
                    {
                        Request_num = c.Int(nullable: false, identity: true),
                        Child_Id = c.Int(nullable: false),
                        Child_Fullname = c.String(),
                        Child_Gender = c.String(),
                        Child_BirthDate = c.DateTime(),
                        Monthly_Age = c.Int(),
                        Years_Age = c.Int(),
                        Child_Nationality = c.String(),
                        Mother_Name = c.String(),
                        Mother_Nationality = c.String(),
                        Mother_Nationad_ID = c.Int(),
                        Mother_Phone = c.Int(),
                        Mother_Email = c.String(),
                        branch = c.String(),
                        age_type = c.Boolean(nullable: false),
                        Start_date = c.DateTime(),
                        Other = c.String(),
                        Mother_state = c.String(),
                        role = c.String(),
                        College = c.String(),
                    })
                .PrimaryKey(t => t.Request_num);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationDate = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Accepted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rotators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Href = c.String(),
                        Title = c.String(),
                        HrefTitle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Teacher_National_Id = c.Int(nullable: false),
                        Teacher_Name = c.String(),
                        Teacher_Nationality = c.String(),
                        Teacher_password = c.String(),
                        Teacher_Username = c.String(),
                        Teacher_Email = c.String(),
                        Teacher_Phone = c.String(),
                        ResetPasswordCode = c.String(),
                    })
                .PrimaryKey(t => t.Teacher_National_Id);
            
            CreateTable(
                "dbo.Useful_Links",
                c => new
                    {
                        Link_Number = c.Int(nullable: false, identity: true),
                        Link_Title = c.String(nullable: false),
                        Link_href = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Link_Number);
            
            CreateTable(
                "dbo.WaitLists",
                c => new
                    {
                        Request_num = c.Int(nullable: false, identity: true),
                        Child_Id = c.Int(nullable: false),
                        Child_Fullname = c.String(),
                        Child_Gender = c.String(),
                        Child_BirthDate = c.DateTime(),
                        Monthly_Age = c.Int(),
                        Years_Age = c.Int(),
                        Child_Nationality = c.String(),
                        Mother_Name = c.String(),
                        Mother_Nationality = c.String(),
                        Mother_Nationad_ID = c.Int(),
                        Mother_Phone = c.Int(),
                        Mother_Email = c.String(),
                        branch = c.String(),
                        age_type = c.Boolean(nullable: false),
                        Start_date = c.DateTime(),
                        Other = c.String(),
                        Mother_state = c.String(),
                        role = c.String(),
                        College = c.String(),
                    })
                .PrimaryKey(t => t.Request_num);
            
            CreateTable(
                "dbo.Weekly_Task",
                c => new
                    {
                        Weely_Number = c.Int(nullable: false, identity: true),
                        Sun = c.String(),
                        Mon = c.String(),
                        Tue = c.String(),
                        Wed = c.String(),
                        Thu = c.String(),
                    })
                .PrimaryKey(t => t.Weely_Number);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Parent_Parent_National_Id", "dbo.Parents");
            DropForeignKey("dbo.Appointments", "Child_Child_National_Id", "dbo.Children");
            DropForeignKey("dbo.Children", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Delegations", "Parent_Parent_National_Id", "dbo.Parents");
            DropForeignKey("dbo.Children", "Parent_Parent_National_Id", "dbo.Parents");
            DropForeignKey("dbo.Delegations", "Child_Child_National_Id", "dbo.Children");
            DropForeignKey("dbo.Photos", "UserPhoto_FileId", "dbo.Files");
            DropForeignKey("dbo.Photos", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Photo_FileId", "dbo.Files");
            DropIndex("dbo.Delegations", new[] { "Parent_Parent_National_Id" });
            DropIndex("dbo.Delegations", new[] { "Child_Child_National_Id" });
            DropIndex("dbo.Children", new[] { "Parent_Parent_National_Id" });
            DropIndex("dbo.Children", new[] { "Program_Id" });
            DropIndex("dbo.Appointments", new[] { "Parent_Parent_National_Id" });
            DropIndex("dbo.Appointments", new[] { "Child_Child_National_Id" });
            DropIndex("dbo.Photos", new[] { "UserPhoto_FileId" });
            DropIndex("dbo.Photos", new[] { "AlbumId" });
            DropIndex("dbo.Albums", new[] { "Photo_FileId" });
            DropTable("dbo.Weekly_Task");
            DropTable("dbo.WaitLists");
            DropTable("dbo.Useful_Links");
            DropTable("dbo.Teachers");
            DropTable("dbo.Rotators");
            DropTable("dbo.Reservations");
            DropTable("dbo.Nominations");
            DropTable("dbo.FAQs");
            DropTable("dbo.Events");
            DropTable("dbo.Class_Activity");
            DropTable("dbo.Blogs");
            DropTable("dbo.Programs");
            DropTable("dbo.Parents");
            DropTable("dbo.Delegations");
            DropTable("dbo.Children");
            DropTable("dbo.Appointments");
            DropTable("dbo.Photos");
            DropTable("dbo.Files");
            DropTable("dbo.Albums");
            DropTable("dbo.Adminstrators");
        }
    }
}

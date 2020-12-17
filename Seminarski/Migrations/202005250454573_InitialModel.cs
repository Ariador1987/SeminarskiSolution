namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Predbiljezbe",
                c => new
                    {
                        PredbiljezbaID = c.Int(nullable: false, identity: true),
                        Mobitel = c.String(maxLength: 30),
                        Email = c.String(nullable: false),
                        Adresa = c.String(),
                        Prezime = c.String(nullable: false),
                        Ime = c.String(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        SeminarID = c.Int(nullable: false),
                        Predbiljezba_PredbiljezbaID = c.Int(),
                    })
                .PrimaryKey(t => t.PredbiljezbaID)
                .ForeignKey("dbo.Predbiljezbe", t => t.Predbiljezba_PredbiljezbaID)
                .ForeignKey("dbo.Seminari", t => t.SeminarID, cascadeDelete: true)
                .Index(t => t.SeminarID)
                .Index(t => t.Predbiljezba_PredbiljezbaID);
            
            CreateTable(
                "dbo.Seminari",
                c => new
                    {
                        SeminarID = c.Int(nullable: false, identity: true),
                        JePopunjen = c.Boolean(nullable: false),
                        JeObjavljen = c.Boolean(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        Opis = c.String(),
                        Naziv = c.String(nullable: false, maxLength: 100),
                        BrojPolaznika = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeminarID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Predbiljezbe", "SeminarID", "dbo.Seminari");
            DropForeignKey("dbo.Predbiljezbe", "Predbiljezba_PredbiljezbaID", "dbo.Predbiljezbe");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Predbiljezbe", new[] { "Predbiljezba_PredbiljezbaID" });
            DropIndex("dbo.Predbiljezbe", new[] { "SeminarID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Seminari");
            DropTable("dbo.Predbiljezbe");
        }
    }
}

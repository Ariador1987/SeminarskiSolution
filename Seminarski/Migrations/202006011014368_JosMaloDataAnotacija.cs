namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JosMaloDataAnotacija : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezbe", "Mobitel", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Predbiljezbe", "Email", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Predbiljezbe", "Adresa", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Predbiljezbe", "Prezime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Predbiljezbe", "Ime", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Predbiljezbe", "Ime", c => c.String(nullable: false));
            AlterColumn("dbo.Predbiljezbe", "Prezime", c => c.String(nullable: false));
            AlterColumn("dbo.Predbiljezbe", "Adresa", c => c.String());
            AlterColumn("dbo.Predbiljezbe", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Predbiljezbe", "Mobitel", c => c.String(maxLength: 30));
        }
    }
}

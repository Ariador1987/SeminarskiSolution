namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajemAnotacijePosljednjiTestovi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezbe", "Prezime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Predbiljezbe", "Ime", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Predbiljezbe", "Ime", c => c.String(nullable: false));
            AlterColumn("dbo.Predbiljezbe", "Prezime", c => c.String(nullable: false));
        }
    }
}

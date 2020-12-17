namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JosAnotacija : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezbe", "Mobitel", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Predbiljezbe", "Adresa", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Predbiljezbe", "Adresa", c => c.String());
            AlterColumn("dbo.Predbiljezbe", "Mobitel", c => c.String(maxLength: 30));
        }
    }
}

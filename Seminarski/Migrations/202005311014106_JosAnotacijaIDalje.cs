namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JosAnotacijaIDalje : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezbe", "Email", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Predbiljezbe", "Email", c => c.String(nullable: false));
        }
    }
}

namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingDateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezbe", "Datum", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Predbiljezbe", "Datum", c => c.DateTime(nullable: false));
        }
    }
}

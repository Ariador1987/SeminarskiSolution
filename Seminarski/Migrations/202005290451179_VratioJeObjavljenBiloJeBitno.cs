namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VratioJeObjavljenBiloJeBitno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seminari", "JeObjavljen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seminari", "JeObjavljen");
        }
    }
}

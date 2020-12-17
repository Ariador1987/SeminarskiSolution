namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IpakJeBiloNebitnoSvojstvo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Seminari", "JeObjavljen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seminari", "JeObjavljen", c => c.Boolean(nullable: false));
        }
    }
}

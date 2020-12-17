namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTecajObjavljenCSharpOsnove : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Seminari SET JeObjavljen = 1 WHERE SeminarID = 1");
        }
        
        public override void Down()
        {
        }
    }
}

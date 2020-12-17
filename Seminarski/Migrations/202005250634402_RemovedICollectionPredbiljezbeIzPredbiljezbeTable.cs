namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedICollectionPredbiljezbeIzPredbiljezbeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Predbiljezbe", "Predbiljezba_PredbiljezbaID", "dbo.Predbiljezbe");
            DropIndex("dbo.Predbiljezbe", new[] { "Predbiljezba_PredbiljezbaID" });
            DropColumn("dbo.Predbiljezbe", "Predbiljezba_PredbiljezbaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Predbiljezbe", "Predbiljezba_PredbiljezbaID", c => c.Int());
            CreateIndex("dbo.Predbiljezbe", "Predbiljezba_PredbiljezbaID");
            AddForeignKey("dbo.Predbiljezbe", "Predbiljezba_PredbiljezbaID", "dbo.Predbiljezbe", "PredbiljezbaID");
        }
    }
}

namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajemPopunjenTecajTestiranjeLINQaZaTrazilicu : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Seminari (JePopunjen, JeObjavljen, Datum, Opis, Naziv, BrojPolaznika) VALUES (1, 0, CAST('2020-06-15' AS DATETIME), 'Javascript osnove', 'Popunjen Tecaj', 11)");
        }
        
        public override void Down()
        {
        }
    }
}

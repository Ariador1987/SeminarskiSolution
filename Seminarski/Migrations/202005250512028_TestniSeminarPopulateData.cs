namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestniSeminarPopulateData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Seminari (JePopunjen, JeObjavljen, Datum, Opis, Naziv, BrojPolaznika) VALUES (0, 0, CAST('2020-06-15' AS DATETIME), 'C# Osnove', 'Uvod u C# programski jezik', 11)");
        }
        
        public override void Down()
        {
        }
    }
}

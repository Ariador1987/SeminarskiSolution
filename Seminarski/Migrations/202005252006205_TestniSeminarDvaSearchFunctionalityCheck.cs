namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestniSeminarDvaSearchFunctionalityCheck : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Seminari (JePopunjen, JeObjavljen, Datum, Opis, Naziv, BrojPolaznika) VALUES (0, 0, CAST('2021-01-04' AS DATETIME), 'Napredni C# Programski jezik', 'Napredni C#', 11)");
        }
        
        public override void Down()
        {
        }
    }
}

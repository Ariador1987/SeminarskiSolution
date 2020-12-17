namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestnaPredbiljezbaPopulate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Predbiljezbe (Mobitel, Email, Adresa, Prezime, Ime, Datum, Status, SeminarID) VALUES ('+38599099099', 'nekias@as.com', '21217, As', 'PrezimeAsa', 'ImeAsa', CAST('2015-05-22' AS DATETIME), 1, 1)");
        }
        
        public override void Down()
        {
        }
    }
}

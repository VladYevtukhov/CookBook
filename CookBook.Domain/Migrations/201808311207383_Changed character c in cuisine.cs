namespace CookBook.Domain.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedcharactercincuisine : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.СuisineСountry", newName: "CuisineСountry");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CuisineСountry", newName: "СuisineСountry");
        }
    }
}

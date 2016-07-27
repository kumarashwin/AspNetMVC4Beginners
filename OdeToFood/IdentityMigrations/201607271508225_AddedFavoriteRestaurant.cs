namespace OdeToFood.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFavoriteRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FavoriteRestaurant", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FavoriteRestaurant");
        }
    }
}

namespace MVVM_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipeingredient_unitnotrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("MyWeight.RecipeIngredient", "Unit", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("MyWeight.RecipeIngredient", "Unit", c => c.String(nullable: false, maxLength: 20));
        }
    }
}

namespace MVVM_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalrecipeingredientamount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("MyWeight.RecipeIngredient", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("MyWeight.RecipeIngredient", "Amount", c => c.Int(nullable: false));
        }
    }
}

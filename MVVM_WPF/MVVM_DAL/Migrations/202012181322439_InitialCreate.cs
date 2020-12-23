namespace MVVM_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "MyWeight.Diary",
                c => new
                    {
                        DiaryID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DiaryID)
                .ForeignKey("MyWeight.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "MyWeight.DiaryTimeStamp",
                c => new
                    {
                        DiaryTimeStampID = c.Int(nullable: false, identity: true),
                        DiaryID = c.Int(nullable: false),
                        TimeStampID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiaryTimeStampID)
                .ForeignKey("MyWeight.Diary", t => t.DiaryID, cascadeDelete: true)
                .ForeignKey("MyWeight.Timestamp", t => t.TimeStampID, cascadeDelete: true)
                .Index(t => t.DiaryID)
                .Index(t => t.TimeStampID);
            
            CreateTable(
                "MyWeight.DiaryTimeStampMeal",
                c => new
                    {
                        DiaryTimeStampMealID = c.Int(nullable: false, identity: true),
                        DiaryTimeStampID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiaryTimeStampMealID)
                .ForeignKey("MyWeight.DiaryTimeStamp", t => t.DiaryTimeStampID, cascadeDelete: true)
                .ForeignKey("MyWeight.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.DiaryTimeStampID)
                .Index(t => t.MealID);
            
            CreateTable(
                "MyWeight.Meal",
                c => new
                    {
                        MealID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.MealID);
            
            CreateTable(
                "MyWeight.MealIngredient",
                c => new
                    {
                        MealIngredientID = c.Int(nullable: false, identity: true),
                        MealID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealIngredientID)
                .ForeignKey("MyWeight.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("MyWeight.Meal", t => t.MealID, cascadeDelete: true)
                .Index(t => t.MealID)
                .Index(t => t.IngredientID);
            
            CreateTable(
                "MyWeight.Ingredient",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        NutritionFactID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Brand = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.IngredientID)
                .ForeignKey("MyWeight.NutritionFact", t => t.NutritionFactID, cascadeDelete: true)
                .Index(t => t.NutritionFactID);
            
            CreateTable(
                "MyWeight.NutritionFact",
                c => new
                    {
                        NutritionFactID = c.Int(nullable: false, identity: true),
                        Unit = c.String(nullable: false, maxLength: 20),
                        Calories = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Carbohydrates = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Protein = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.NutritionFactID);
            
            CreateTable(
                "MyWeight.RecipeIngredient",
                c => new
                    {
                        RecipeIngredientID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Unit = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.RecipeIngredientID)
                .ForeignKey("MyWeight.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("MyWeight.Recipe", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.IngredientID);
            
            CreateTable(
                "MyWeight.Recipe",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        RecipeCategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        Servings = c.Int(nullable: false),
                        PrepTime = c.DateTime(nullable: false),
                        CookTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeID)
                .ForeignKey("MyWeight.RecipeCategory", t => t.RecipeCategoryID, cascadeDelete: true)
                .Index(t => t.RecipeCategoryID);
            
            CreateTable(
                "MyWeight.MealRecipe",
                c => new
                    {
                        MealRecipeID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealRecipeID)
                .ForeignKey("MyWeight.Meal", t => t.MealID, cascadeDelete: true)
                .ForeignKey("MyWeight.Recipe", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.MealID);
            
            CreateTable(
                "MyWeight.RecipeCategory",
                c => new
                    {
                        RecipeCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.RecipeCategoryID);
            
            CreateTable(
                "MyWeight.RecipeDirections",
                c => new
                    {
                        RecipeDirectionsID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.RecipeDirectionsID)
                .ForeignKey("MyWeight.Recipe", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "MyWeight.Timestamp",
                c => new
                    {
                        TimeStampID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.TimeStampID);
            
            CreateTable(
                "MyWeight.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 255),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WantedWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CaloriesDayGoal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("MyWeight.Diary", "UserID", "MyWeight.User");
            DropForeignKey("MyWeight.DiaryTimeStamp", "TimeStampID", "MyWeight.Timestamp");
            DropForeignKey("MyWeight.MealIngredient", "MealID", "MyWeight.Meal");
            DropForeignKey("MyWeight.RecipeIngredient", "RecipeID", "MyWeight.Recipe");
            DropForeignKey("MyWeight.RecipeDirections", "RecipeID", "MyWeight.Recipe");
            DropForeignKey("MyWeight.Recipe", "RecipeCategoryID", "MyWeight.RecipeCategory");
            DropForeignKey("MyWeight.MealRecipe", "RecipeID", "MyWeight.Recipe");
            DropForeignKey("MyWeight.MealRecipe", "MealID", "MyWeight.Meal");
            DropForeignKey("MyWeight.RecipeIngredient", "IngredientID", "MyWeight.Ingredient");
            DropForeignKey("MyWeight.Ingredient", "NutritionFactID", "MyWeight.NutritionFact");
            DropForeignKey("MyWeight.MealIngredient", "IngredientID", "MyWeight.Ingredient");
            DropForeignKey("MyWeight.DiaryTimeStampMeal", "MealID", "MyWeight.Meal");
            DropForeignKey("MyWeight.DiaryTimeStampMeal", "DiaryTimeStampID", "MyWeight.DiaryTimeStamp");
            DropForeignKey("MyWeight.DiaryTimeStamp", "DiaryID", "MyWeight.Diary");
            DropIndex("MyWeight.RecipeDirections", new[] { "RecipeID" });
            DropIndex("MyWeight.MealRecipe", new[] { "MealID" });
            DropIndex("MyWeight.MealRecipe", new[] { "RecipeID" });
            DropIndex("MyWeight.Recipe", new[] { "RecipeCategoryID" });
            DropIndex("MyWeight.RecipeIngredient", new[] { "IngredientID" });
            DropIndex("MyWeight.RecipeIngredient", new[] { "RecipeID" });
            DropIndex("MyWeight.Ingredient", new[] { "NutritionFactID" });
            DropIndex("MyWeight.MealIngredient", new[] { "IngredientID" });
            DropIndex("MyWeight.MealIngredient", new[] { "MealID" });
            DropIndex("MyWeight.DiaryTimeStampMeal", new[] { "MealID" });
            DropIndex("MyWeight.DiaryTimeStampMeal", new[] { "DiaryTimeStampID" });
            DropIndex("MyWeight.DiaryTimeStamp", new[] { "TimeStampID" });
            DropIndex("MyWeight.DiaryTimeStamp", new[] { "DiaryID" });
            DropIndex("MyWeight.Diary", new[] { "UserID" });
            DropTable("MyWeight.User");
            DropTable("MyWeight.Timestamp");
            DropTable("MyWeight.RecipeDirections");
            DropTable("MyWeight.RecipeCategory");
            DropTable("MyWeight.MealRecipe");
            DropTable("MyWeight.Recipe");
            DropTable("MyWeight.RecipeIngredient");
            DropTable("MyWeight.NutritionFact");
            DropTable("MyWeight.Ingredient");
            DropTable("MyWeight.MealIngredient");
            DropTable("MyWeight.Meal");
            DropTable("MyWeight.DiaryTimeStampMeal");
            DropTable("MyWeight.DiaryTimeStamp");
            DropTable("MyWeight.Diary");
        }
    }
}

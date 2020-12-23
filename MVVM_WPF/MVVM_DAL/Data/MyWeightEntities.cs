using MVVM_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_DAL.Data
{
    public class MyWeightEntities : DbContext
    {
        public  MyWeightEntities(): base("name=MyWeightDB")
        {

        }

        public DbSet<Diary> Diarys { get; set; }
        public DbSet<DiaryTimeStamp> DiaryTimeStamps { get; set; }
        public DbSet<DiaryTimeStampMeal> DiaryTimeStampMeals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealIngredient> MealIngredients { get; set; }
        public DbSet<MealRecipe> MealRecipes { get; set; }
        public DbSet<NutritionFact> NutritionFacts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeDirections> RecipeDirections { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Timestamp> Timestamps { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

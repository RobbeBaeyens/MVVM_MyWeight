using MVVM_DAL.Data.Repositories;
using MVVM_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_DAL.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Diary> DiaryRepo { get; }
        IRepository<DiaryTimeStamp> DiaryTimeStampRepo { get; }
        IRepository<DiaryTimeStampMeal> DiaryTimeStampMealRepo { get; }
        IRepository<Ingredient> IngredientRepo { get; }
        IRepository<Meal> MealRepo { get; }
        IRepository<MealIngredient> MealIngredientRepo { get; }
        IRepository<MealRecipe> MealRecipeRepo { get; }
        IRepository<NutritionFact> NutritionFactRepo { get; }
        IRepository<Recipe> RecipeRepo { get; }
        IRepository<RecipeCategory> RecipeCategoryRepo { get; }
        IRepository<RecipeDirections> RecipeDirectionsRepo { get; }
        IRepository<RecipeIngredient> RecipeIngredientRepo { get; }
        IRepository<Timestamp> TimestampRepo { get; }
        IRepository<User> UserRepo { get; }

        int Save();
    }
}

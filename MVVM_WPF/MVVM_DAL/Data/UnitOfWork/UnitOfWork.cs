using MVVM_DAL.Data.Repositories;
using MVVM_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Diary> _diaryRepo;
        private IRepository<DiaryTimeStamp> _diaryTimeStampRepo;
        private IRepository<DiaryTimeStampMeal> _diaryTimeStampMealRepo;
        private IRepository<Ingredient> _ingredientRepo;
        private IRepository<Meal> _mealRepo;
        private IRepository<MealIngredient> _mealIngredientRepo;
        private IRepository<MealRecipe> _mealRecipeRepo;
        private IRepository<NutritionFact> _nutritionFactRepo;
        private IRepository<Recipe> _recipeRepo;
        private IRepository<RecipeCategory> _recipeCategoryRepo;
        private IRepository<RecipeDirections> _recipeDirectionsRepo;
        private IRepository<RecipeIngredient> _recipeIngredientRepo;
        private IRepository<Timestamp> _timestampRepo;
        private IRepository<User> _userRepo; 
        
        
        public UnitOfWork(MyWeightEntities myWeightEntities)
        {
            this.MyWeightEntities = myWeightEntities;

        }
        private MyWeightEntities MyWeightEntities { get; }

        public IRepository<Diary> DiaryRepo
        {
            get
            {
                if (_diaryRepo == null)
                {
                    _diaryRepo = new Repository<Diary>(this.MyWeightEntities);
                }
                return _diaryRepo;
            }
        }

        public IRepository<DiaryTimeStamp> DiaryTimeStampRepo
        {
            get
            {
                if (_diaryTimeStampRepo == null)
                {
                    _diaryTimeStampRepo = new Repository<DiaryTimeStamp>(this.MyWeightEntities);
                }
                return _diaryTimeStampRepo;
            }
        }

        public IRepository<DiaryTimeStampMeal> DiaryTimeStampMealRepo
        {
            get
            {
                if (_diaryTimeStampMealRepo == null)
                {
                    _diaryTimeStampMealRepo = new Repository<DiaryTimeStampMeal>(this.MyWeightEntities);
                }
                return _diaryTimeStampMealRepo;
            }
        }

        public IRepository<Ingredient> IngredientRepo
        {
            get
            {
                if (_ingredientRepo == null)
                {
                    _ingredientRepo = new Repository<Ingredient>(this.MyWeightEntities);
                }
                return _ingredientRepo;
            }
        }

        public IRepository<Meal> MealRepo
        {
            get
            {
                if (_mealRepo == null)
                {
                    _mealRepo = new Repository<Meal>(this.MyWeightEntities);
                }
                return _mealRepo;
            }
        }

        public IRepository<MealIngredient> MealIngredientRepo
        {
            get
            {
                if (_mealIngredientRepo == null)
                {
                    _mealIngredientRepo = new Repository<MealIngredient>(this.MyWeightEntities);
                }
                return _mealIngredientRepo;
            }
        }

        public IRepository<MealRecipe> MealRecipeRepo
        {
            get
            {
                if (_mealRecipeRepo == null)
                {
                    _mealRecipeRepo = new Repository<MealRecipe>(this.MyWeightEntities);
                }
                return _mealRecipeRepo;
            }
        }

        public IRepository<NutritionFact> NutritionFactRepo
        {
            get
            {
                if (_nutritionFactRepo == null)
                {
                    _nutritionFactRepo = new Repository<NutritionFact>(this.MyWeightEntities);
                }
                return _nutritionFactRepo;
            }
        }

        public IRepository<Recipe> RecipeRepo
        {
            get
            {
                if (_recipeRepo == null)
                {
                    _recipeRepo = new Repository<Recipe>(this.MyWeightEntities);
                }
                return _recipeRepo;
            }
        }

        public IRepository<RecipeCategory> RecipeCategoryRepo
        {
            get
            {
                if (_recipeCategoryRepo == null)
                {
                    _recipeCategoryRepo = new Repository<RecipeCategory>(this.MyWeightEntities);
                }
                return _recipeCategoryRepo;
            }
        }

        public IRepository<RecipeDirections> RecipeDirectionsRepo
        {
            get
            {
                if (_recipeDirectionsRepo == null)
                {
                    _recipeDirectionsRepo = new Repository<RecipeDirections>(this.MyWeightEntities);
                }
                return _recipeDirectionsRepo;
            }
        }

        public IRepository<RecipeIngredient> RecipeIngredientRepo
        {
            get
            {
                if (_recipeIngredientRepo == null)
                {
                    _recipeIngredientRepo = new Repository<RecipeIngredient>(this.MyWeightEntities);
                }
                return _recipeIngredientRepo;
            }
        }

        public IRepository<Timestamp> TimestampRepo
        {
            get
            {
                if (_timestampRepo == null)
                {
                    _timestampRepo = new Repository<Timestamp>(this.MyWeightEntities);
                }
                return _timestampRepo;
            }
        }

        public IRepository<User> UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new Repository<User>(this.MyWeightEntities);
                }
                return _userRepo;
            }
        }

        public void Dispose()
        {
            MyWeightEntities.Dispose();
        }

        public int Save()
        {
            return MyWeightEntities.SaveChanges();
        }
    }    
}

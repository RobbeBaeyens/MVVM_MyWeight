using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Data;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
using MVVM_WPF.Views.DiaryAdd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MVVM_WPF.Views.Error;

namespace MVVM_WPF.ViewModels
{
    public class MealViewModel : BasisViewModel
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());
        WindowCollection windows;

        private string _addedMealName;
        public string AddedMealName
        {
            get
            {
                return _addedMealName;
            }
            set
            {
                _addedMealName = value;
                NotifyPropertyChanged(_addedMealName);
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged(_name);
            }
        }

        private string _buttonText;
        public string ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                _buttonText = value;
                NotifyPropertyChanged(_buttonText);
            }
        }

        public int mealType = 0;
        public Ingredient ingredient;
        public Recipe recipe;
        public DiaryTimeStamp diaryTimeStamp;

        public MealViewModel(Ingredient ingredient, DiaryTimeStamp diaryTimeStamp)
        {
            InitializeMealViewModel();
            this.ingredient = ingredient;
            this.diaryTimeStamp = diaryTimeStamp;
            ButtonText = "Add Meal to " + unitOfWork.TimestampRepo.ZoekOpPK(diaryTimeStamp.TimeStampID).Name;
            AddedMealName = "Food: " + ingredient.Name;
            mealType = 1;
            Name = ingredient.Name;
        }
        public MealViewModel(Recipe recipe, DiaryTimeStamp diaryTimeStamp)
        {
            InitializeMealViewModel();
            this.recipe = recipe;
            this.diaryTimeStamp = diaryTimeStamp;
            ButtonText = "Add Meal to " + unitOfWork.TimestampRepo.ZoekOpPK(diaryTimeStamp.TimeStampID).Name;
            AddedMealName = "Recipe: " + recipe.Name;
            mealType = 2;
            Name = ingredient.Name;
        }

        public void InitializeMealViewModel()
        {
            windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window.Title != "Meal")
                {
                    window.IsEnabled = false;
                }
            }
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Exit":
                    foreach (Window window in windows)
                    {
                        window.IsEnabled = true;
                        if (window.Title == "Meal")
                        {
                            window.Close();
                        }
                    }
                    break;
                case "AddMeal":
                    AddMeal();
                    break;
            }
        }

        private void AddMeal()
        {
            try
            {
                Meal meal = new Meal()
                {
                    Name = Name
                };
                unitOfWork.MealRepo.Toevoegen(meal);
                unitOfWork.Save();

                switch (mealType)
                {
                    case 1:
                        MealIngredient mealIngredient = new MealIngredient()
                        {
                            IngredientID = this.ingredient.IngredientID,
                            MealID = meal.MealID
                        };
                        unitOfWork.MealIngredientRepo.Toevoegen(mealIngredient);
                        unitOfWork.Save();
                        break;

                    case 2:
                        MealRecipe mealRecipe = new MealRecipe()
                        {
                            RecipeID = this.recipe.RecipeID,
                            MealID = meal.MealID
                        };
                        unitOfWork.MealRecipeRepo.Toevoegen(mealRecipe);
                        unitOfWork.Save();
                        break;
                }
                DiaryTimeStampMeal diaryTimeStampMeal = new DiaryTimeStampMeal()
                {
                    MealID = meal.MealID,
                    DiaryTimeStampID = this.diaryTimeStamp.DiaryTimeStampID
                };
                unitOfWork.DiaryTimeStampMealRepo.Toevoegen(diaryTimeStampMeal);
                unitOfWork.Save();

                CustomSuccesDialogue succesDialogue = new CustomSuccesDialogue("Succes", "New Meal {" + Name + "} added to " + unitOfWork.TimestampRepo.ZoekOpPK(this.diaryTimeStamp.TimeStampID).Name);
                succesDialogue.ShowDialog();

                Execute("Exit");
            }
            catch(Exception ex)
            {
                CustomErrorDialogue customErrorDialogue = new CustomErrorDialogue("Database error", ex, new int[] { 500, 600 });
                customErrorDialogue.ShowDialog();
            }
        }
    }
}

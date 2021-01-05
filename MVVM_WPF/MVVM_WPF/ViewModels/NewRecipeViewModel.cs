using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_DAL.Data;
using MVVM_WPF.Commands;
using MVVM_WPF.Views.DiaryAdd;
using MVVM_WPF.Views.Error;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace MVVM_WPF.ViewModels
{
    public class NewRecipeViewModel : BasisViewModel
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());

        private string _name = "";
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

        private string _description = "";
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                NotifyPropertyChanged(_description);
            }
        }

        private string _servingsNr = "";
        public string ServingsNr
        {
            get
            {
                return _servingsNr;
            }

            set
            {
                _servingsNr = value;
                NotifyPropertyChanged(_servingsNr);
            }
        }
        public int IntServingsNr = 0;

        private string _prepTime = "";
        public string PrepTime
        {
            get
            {
                return _prepTime;
            }

            set
            {
                _prepTime = value;
                NotifyPropertyChanged(_prepTime);
            }
        }
        public int IntPrepTime = 0;

        private string _cookTime = "";
        public string CookTime
        {
            get
            {
                return _cookTime;
            }

            set
            {
                _cookTime = value;
                NotifyPropertyChanged(_cookTime);
            }
        }
        public int IntCookTime = 0;

        private List<RecipeCategory> _recipeCategories;
        public List<RecipeCategory> RecipeCategories
        {
            get
            {
                return _recipeCategories;
            }

            set
            {
                _recipeCategories = value;
                NotifyPropertyChanged(nameof(_recipeCategories));
            }
        }

        private int _selectedRecipeCategory = -1;
        public int SelectedRecipeCategory
        {
            get
            {
                return _selectedRecipeCategory;
            }

            set
            {
                _selectedRecipeCategory = value;
                NotifyPropertyChanged(nameof(_selectedRecipeCategory));
            }
        }

        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }

            set
            {
                _ingredients = value;
                NotifyPropertyChanged(nameof(_ingredients));
            }
        }

        private int _selectedIngredient = -1;
        public int SelectedIngredient
        {
            get
            {
                return _selectedIngredient;
            }

            set
            {
                _selectedIngredient = value;
                NotifyPropertyChanged(nameof(_selectedIngredient));
            }
        }

        public int CustomDirectionID = 0;
        public List<CustomIngredient> IngredientsListList = new List<CustomIngredient>();
        public List<RecipeIngredient> RealRecipeIngredients = new List<RecipeIngredient>();
        public List<Ingredient> RealIngredients = new List<Ingredient>();
        private ObservableCollection<CustomIngredient> _ingredientsList;
        public ObservableCollection<CustomIngredient> IngredientsList
        {
            get
            {
                return _ingredientsList;
            }

            set
            {
                _ingredientsList = value;
                NotifyPropertyChanged(nameof(_ingredientsList));
            }
        }

        private int _selectedIngredientListItem = -1;
        public int SelectedIngredientListItem
        {
            get
            {
                return _selectedIngredientListItem;
            }

            set
            {
                _selectedIngredientListItem = value;
                NotifyPropertyChanged(nameof(_selectedIngredientListItem));
            }
        }

        private string _direction = "";
        public string Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
                NotifyPropertyChanged(nameof(_direction));
            }
        }

        public List<CustomDirection> DirectionsListList = new List<CustomDirection>();
        public List<RecipeDirections> RealRecipeDirections = new List<RecipeDirections>();
        private ObservableCollection<CustomDirection> _directionsList;
        public ObservableCollection<CustomDirection> DirectionsList
        {
            get
            {
                return _directionsList;
            }

            set
            {
                _directionsList = value;
                NotifyPropertyChanged(nameof(_directionsList));
            }
        }

        private int _selectedDirectionsListItem = -1;
        public int SelectedDirectionsListItem
        {
            get
            {
                return _selectedDirectionsListItem;
            }

            set
            {
                _selectedDirectionsListItem = value;
                NotifyPropertyChanged(nameof(_selectedDirectionsListItem));
            }
        }

        private string _ingredientAmount = "";
        public string IngredientAmount
        {
            get
            {
                return _ingredientAmount;
            }

            set
            {
                _ingredientAmount = value;
                NotifyPropertyChanged(nameof(_ingredientAmount));
            }
        }

        private string _ingredientUnit = "";
        public string IngredientUnit
        {
            get
            {
                return _ingredientUnit;
            }

            set
            {
                _ingredientUnit = value;
                NotifyPropertyChanged(nameof(_ingredientUnit));
            }
        }



        public NewRecipeViewModel()
        {
            try
            {
                RecipeCategories = unitOfWork.RecipeCategoryRepo.Ophalen().ToList();
                Ingredients = new ObservableCollection<Ingredient>(unitOfWork.IngredientRepo.Ophalen().ToList());
            }
            catch(Exception e)
            {

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
            WindowCollection windows = Application.Current.Windows;
            switch (parameter.ToString())
            {
                case "Exit":
                    foreach(Window window in windows)
                    {
                        if(window.Title == "NewRecipe")
                        {
                            window.Close();
                        }
                    }
                    break;
                case "Foods":
                    List<string> windowTitles = new List<string>();
                    foreach (Window window in windows)
                    {
                        windowTitles.Add(window.Title);
                    }
                    if (!windowTitles.Contains("NewFood"))
                    {
                        NewFood newFood = new NewFood();
                        newFood.ShowDialog();
                        Ingredients = new ObservableCollection<Ingredient>(unitOfWork.IngredientRepo.Ophalen().ToList());
                    }
                    break;
                case "AddRecipe":
                    AddRecipe();
                    break;
                case "AddIngredient":
                    AddIngredient();
                    break;
                case "RemoveIngredient":
                    RemoveIngredient();
                    break;
                case "AddDirections":
                    AddDirections();
                    break;
                case "RemoveDirections":
                    RemoveDirections();
                    break;
            }
        }
        private void AddIngredient()
        {
            if(SelectedIngredient != -1)
            {
                decimal DecAmount = 0;
                if(IngredientAmount != "" && decimal.TryParse(IngredientAmount, out DecAmount))
                {
                        Ingredient ingredient = unitOfWork.IngredientRepo.ZoekOpPK(SelectedIngredient);
                        RecipeIngredient recipeIngredient = new RecipeIngredient()
                        {
                            IngredientID = ingredient.IngredientID,
                            Amount = DecAmount,
                            Unit = IngredientUnit
                        };
                        CustomIngredient customIngredient = new CustomIngredient()
                        {
                            Id = ingredient.IngredientID,
                            Name = ingredient.Name,
                            Brand = "(" + ingredient.Brand + ")",
                            Amount = DecAmount + " " + recipeIngredient.Unit + " :",
                            ActualAmount = DecAmount,
                            ActualUnit = IngredientUnit
                        };
                    IngredientsListList.Add(customIngredient);
                    IngredientsList = new ObservableCollection<CustomIngredient>(IngredientsListList);
                }
            }
        }
        private void RemoveIngredient()
        {
            if (SelectedIngredientListItem != -1)
            {
                int index1 = 0;
                foreach (CustomIngredient customIngredient in IngredientsListList)
                {
                    if (customIngredient.Id == SelectedIngredientListItem)
                    {
                        index1 = IngredientsListList.IndexOf(customIngredient);
                    }
                }
                IngredientsListList.RemoveAt(index1);
                IngredientsList = new ObservableCollection<CustomIngredient>(IngredientsListList);
            }
        }

        private void AddDirections()
        {
            if(Direction != "")
            {
                CustomDirection customDirection = new CustomDirection()
                {
                    Id = CustomDirectionID,
                    Description = Direction
                };
                CustomDirectionID++;
                DirectionsListList.Add(customDirection);
                DirectionsList = new ObservableCollection<CustomDirection>(DirectionsListList);
            }
        }

        private void RemoveDirections()
        {
            if (SelectedDirectionsListItem != -1)
            {
                int index = 0;
                foreach (CustomDirection customDirection in DirectionsListList)
                {
                    if (customDirection.Id == SelectedDirectionsListItem)
                    {
                        index = DirectionsListList.IndexOf(customDirection);
                    }
                }
                DirectionsListList.RemoveAt(index);
                DirectionsList = new ObservableCollection<CustomDirection>(DirectionsListList);
            }
        }

        private void AddRecipe()
        {
            if (CheckForm())
            {
                SaveNewRecipe();
            }
        }

        private bool CheckForm()
        {
            List<string> emptyTextboxes = new List<string>();
            List<string> nonNumericTextboxes = new List<string>();
            List<string> Minimum3Lists = new List<string>();
            if (Name.Length == 0)
            {
                emptyTextboxes.Add("Name");
            }
            if (Description.Length == 0)
            {
                emptyTextboxes.Add("Description");
            }
            if (ServingsNr.Length == 0)
            {
                emptyTextboxes.Add("Number of servings");
            }
            if (!int.TryParse(ServingsNr, out IntServingsNr))
            {
                nonNumericTextboxes.Add("Number of servings");
            }
            if (PrepTime.Length == 0)
            {
                emptyTextboxes.Add("Prep Time");
            }
            if (!int.TryParse(PrepTime, out IntPrepTime))
            {
                nonNumericTextboxes.Add("Prep Time");
            }
            if (CookTime.Length == 0)
            {
                emptyTextboxes.Add("Cook Time");
            }
            if (!int.TryParse(CookTime, out IntCookTime))
            {
                nonNumericTextboxes.Add("Cook Time");
            }
            if (SelectedRecipeCategory == -1)
            {
                emptyTextboxes.Add("Recipe Category");
            }
            if (IngredientsListList.Count < 3)
            {
                Minimum3Lists.Add("Ingredients");
            }
            if (DirectionsListList.Count < 3)
            {
                Minimum3Lists.Add("Directions");
            }

            if (emptyTextboxes.Count == 0 && nonNumericTextboxes.Count == 0 && Minimum3Lists.Count == 0)
            {
                return true;
            }
            else
            {
                CustomErrorDialogue errorDialogue;
                if (emptyTextboxes.Count != 0)
                {
                    string errorText = "Fill in all the required values! (*):";
                    foreach (string textboxName in emptyTextboxes)
                    {
                        errorText += "\n- " + textboxName;
                    }
                    errorDialogue = new CustomErrorDialogue("Error", errorText, new int[] { 360, 500 });
                    errorDialogue.ShowDialog();
                }
                if (nonNumericTextboxes.Count != 0)
                {
                    string errorText = "These inputs must be decimal values:";
                    foreach (string textboxName in nonNumericTextboxes)
                    {
                        errorText += "\n- " + textboxName;
                    }
                    errorDialogue = new CustomErrorDialogue("Error", errorText, new int[] { 360, 500 });
                    errorDialogue.ShowDialog();
                }
                if (Minimum3Lists.Count != 0)
                {
                    string errorText = "These lists must have minimum 3 items:";
                    foreach (string textboxName in Minimum3Lists)
                    {
                        errorText += "\n- " + textboxName;
                    }
                    errorDialogue = new CustomErrorDialogue("Error", errorText, new int[] { 360, 500 });
                    errorDialogue.ShowDialog();
                }
                return false;
            }
        }

        private void SaveNewRecipe()
        {
            try
            {

                Recipe recipe = new Recipe()
                {
                    Name = Name,
                    Description = Description,
                    Servings = IntServingsNr,
                    PrepTime = IntPrepTime,
                    CookTime = IntCookTime,
                    RecipeCategoryID = SelectedRecipeCategory
                };

                unitOfWork.RecipeRepo.Toevoegen(recipe);
                unitOfWork.Save();

                Console.WriteLine("The ID is: " + recipe.RecipeID);

                foreach (CustomIngredient customIngredient in IngredientsList)
                {
                    RecipeIngredient recipeIngredient = new RecipeIngredient()
                    {
                        RecipeID = recipe.RecipeID,
                        IngredientID = customIngredient.Id,
                        Amount = customIngredient.ActualAmount,
                        Unit = customIngredient.ActualUnit
                    };
                    unitOfWork.RecipeIngredientRepo.Toevoegen(recipeIngredient);
                    unitOfWork.Save();
                    Console.WriteLine("The ID is: " + recipeIngredient.RecipeIngredientID);
                }
                foreach (CustomDirection customDirection in DirectionsList)
                {
                    RecipeDirections recipeDirections = new RecipeDirections()
                    {
                        RecipeID = recipe.RecipeID,
                        Description = customDirection.Description
                    };
                    unitOfWork.RecipeDirectionsRepo.Toevoegen(recipeDirections);
                    unitOfWork.Save();
                    Console.WriteLine("The ID is: " + recipeDirections.RecipeDirectionsID);
                }


                CustomSuccesDialogue succesDialogue = new CustomSuccesDialogue("Succes", "New recipe {" + Name + "} added");
                succesDialogue.ShowDialog();
                Execute("Exit");
            }
            catch (Exception ex)
            {
                CustomErrorDialogue customErrorDialogue = new CustomErrorDialogue("Database error", ex, new int[] { 500, 600 });
                customErrorDialogue.ShowDialog();
            }
        }
    }

    public class CustomIngredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Amount { get; set; }
        public decimal ActualAmount { get; set; }
        public string ActualUnit { get; set; }
    }

    public class CustomDirection
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}

using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
using MVVM_WPF.Views.DiaryAdd;
using MVVM_WPF.Views.Error;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_WPF.ViewModels
{
    public class DiaryRecipesViewModel : BasisViewModel
    {
        public List<User> users;

        private List<Recipe> _recipes;
        public List<Recipe> Recipes
        {
            get
            {
                return _recipes;
            }
            set
            {
                _recipes = value;
                NotifyPropertyChanged(nameof(_recipes));
            }
        }
        private List<RecipeIngredient> _recipeIngredients;
        public List<RecipeIngredient> RecipeIngredients
        {
            get
            {
                return _recipeIngredients;
            }
            set
            {
                _recipeIngredients = value;
                NotifyPropertyChanged(nameof(_recipeIngredients));
            }
        }
        private List<RecipeDirections> _recipeDirections;
        public List<RecipeDirections> RecipeDirections
        {
            get
            {
                return _recipeDirections;
            }
            set
            {
                _recipeDirections = value;
                NotifyPropertyChanged(nameof(_recipeDirections));
            }
        }
        private RecipeCategory _recipeCategory;
        public RecipeCategory RecipeCategory
        {
            get
            {
                return _recipeCategory;
            }
            set
            {
                _recipeCategory = value;
                NotifyPropertyChanged(nameof(_recipeCategory));
            }
        }

        private List<Ingredient> _ingredients;
        public List<Ingredient> Ingredients
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

        private List<NutritionFact> _nutritionFacts;
        public List<NutritionFact> NutritionFacts
        {
            get
            {
                return _nutritionFacts;
            }
            set
            {
                _nutritionFacts = value;
                NotifyPropertyChanged(nameof(_nutritionFacts));
            }
        }

        private ObservableCollection<CustomRecipe> _customRecipes;
        public ObservableCollection<CustomRecipe> CustomRecipes
        {
            get
            {
                return _customRecipes;
            }
            set
            {
                _customRecipes = value;
                NotifyPropertyChanged(nameof(_customRecipes));
            }
        }

        private CustomRecipe _selectedRecipe = null;
        public CustomRecipe SelectedRecipe
        {
            get
            {
                return _selectedRecipe;
            }
            set
            {
                _selectedRecipe = value;
                NotifyPropertyChanged(nameof(_selectedRecipe));
            }
        }

        private string _searchText = "";
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                NotifyPropertyChanged(_searchText);
            }
        }

        private int userID;
        private DateTime diaryDate;
        public List<Timestamp> Timestamps { get; set; }

        public string Date { get; set; }

        private Timestamp _selectedTimeStamp;
        public Timestamp SelectedTimeStamp
        {
            get { return _selectedTimeStamp; }
            set { 
                _selectedTimeStamp = value;
                ChangeTimeStamp(_selectedTimeStamp.TimeStampID);
                NotifyPropertyChanged(nameof(_selectedTimeStamp));
            }
        }

        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());

        private DiaryTimeStamp _selectedDiaryTimeStamp;
        public DiaryTimeStamp SelectedDiaryTimeStamp
        {
            get { 
                return _selectedDiaryTimeStamp;
            }
            set { 
                _selectedDiaryTimeStamp = value;
                NotifyPropertyChanged(nameof(_selectedDiaryTimeStamp));
            }
        }

        public Diary diary;
        public int diaryID;

        public DiaryRecipesViewModel(MainViewModel viewModel, int userID, int selectedTimestampID, int diaryID)
        {
            this.diaryID = diaryID;
            try
            {
                users = unitOfWork.UserRepo.Ophalen(u => u.UserID == userID).ToList();
                diary = unitOfWork.DiaryRepo.ZoekOpPK(diaryID);
                Search();
                Timestamps = unitOfWork.TimestampRepo.Ophalen().ToList();
                foreach(Timestamp timestamp in Timestamps)
                {
                    if(timestamp.TimeStampID == selectedTimestampID)
                    {
                        SelectedTimeStamp = timestamp;
                    }
                }
                ChangeTimeStamp(selectedTimestampID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            diaryDate = diary.Date;
            Date = diaryDate.ToString("dd/MM/yyyy");
            this.userID = userID;

            App.Current.Properties["GlobalUserID"] = userID;
            App.Current.Properties["GlobalSelectedTimestamp"] = selectedTimestampID;
            UpdateViewCommand = new UpdateViewCommand(viewModel);
        }

        private void ChangeTimeStamp(int selectedTimestampID)
        {
            SelectedDiaryTimeStamp = unitOfWork.DiaryTimeStampRepo.Ophalen(t => t.DiaryID == diaryID && t.TimeStampID == selectedTimestampID).ToList()[0];
            Console.WriteLine(SelectedTimeStamp.Name);
            Console.WriteLine(SelectedDiaryTimeStamp.DiaryTimeStampID);
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
                case "NewRecipe":
                    WindowCollection windows = Application.Current.Windows;
                    List<string> windowTitles = new List<string>();
                    foreach (Window window in windows)
                    {
                        windowTitles.Add(window.Title);
                    }
                    if (!windowTitles.Contains("NewRecipe"))
                    {
                        NewRecipe newRecipe = new NewRecipe();
                        newRecipe.ShowDialog();
                    }
                    break;
                case "Foods":
                    App.Current.Properties["GlobalSelectedTimestamp"] = SelectedTimeStamp.TimeStampID;
                    App.Current.Properties["GlobalDiaryDate"] = Date;
                    UpdateViewCommand.Execute("DiaryAddFoods");
                    break;
                case "Search":
                    Search();
                    break;
                case "Back":
                    App.Current.Properties["GlobalSelectedTimestamp"] = SelectedTimeStamp.TimeStampID;
                    App.Current.Properties["GlobalDiaryDate"] = Date;
                    UpdateViewCommand.Execute("Diary");
                    break;
                case "Add":
                    Add();
                    break;
            }
        }

        private void Add()
        {
            if(SelectedRecipe != null)
            {
                Recipe recipe = unitOfWork.RecipeRepo.ZoekOpPK(SelectedRecipe.Id);
                MealDialogue mealDialogue = new MealDialogue(recipe, SelectedDiaryTimeStamp);
                mealDialogue.ShowDialog();
            }
        }

        private void Search()
        {
            if (SearchText == "")
            {
                Recipes = unitOfWork.RecipeRepo.Ophalen().ToList();
            }
            else
            {
                Recipes = unitOfWork.RecipeRepo.Ophalen(i => i.Name.ToLower().Contains(SearchText.ToLower())).ToList();
            }

            NutritionFacts = unitOfWork.NutritionFactRepo.Ophalen().ToList();
            Ingredients = unitOfWork.IngredientRepo.Ophalen().ToList();
            RecipeIngredients = unitOfWork.RecipeIngredientRepo.Ophalen().ToList();
            List<CustomRecipe> customRecipes = new List<CustomRecipe>();
            foreach (Recipe recipe in Recipes)
            {
                decimal decCalories = 0;
                RecipeCategory = unitOfWork.RecipeCategoryRepo.ZoekOpPK(recipe.RecipeCategoryID);
                foreach (RecipeIngredient recipeIngredient in RecipeIngredients)
                {
                    if (recipeIngredient.RecipeID == recipe.RecipeID)
                    {
                        foreach (Ingredient ingredient in Ingredients)
                        {
                            foreach (NutritionFact nutritionFact in NutritionFacts)
                            {
                                if(recipeIngredient.IngredientID == ingredient.IngredientID)
                                {
                                    if(nutritionFact.NutritionFactID == ingredient.NutritionFactID)
                                    {
                                        decCalories += nutritionFact.Calories;
                                    }
                                }
                            }
                        }
                    }
                }

                string calories = ((decCalories > 1000) ? (decCalories / 1000).ToString() + " kcal" : (decCalories).ToString() + " cal");
                List<RecipeIngredient> recipeIngredientList = unitOfWork.RecipeIngredientRepo.Ophalen(i => i.RecipeID == recipe.RecipeID).ToList();
                string ingredients = "\n";
                foreach (RecipeIngredient recipeIngredient in recipeIngredientList)
                {
                    Ingredient ingredient = unitOfWork.IngredientRepo.ZoekOpPK(recipeIngredient.IngredientID);
                    ingredients += $"\n{recipeIngredient.Amount} {recipeIngredient.Unit} : {ingredient.Name} ({ingredient.Brand})";
                }

                List<RecipeDirections> recipeDirectionsList = unitOfWork.RecipeDirectionsRepo.Ophalen(d => d.RecipeID == recipe.RecipeID).ToList();
                string directions = "\n";
                int step = 1;
                foreach (RecipeDirections recipeDirections in recipeDirectionsList)
                {
                    directions += $"\n{step}) {recipeDirections.Description}";
                    step++;
                }
                CustomRecipe customRecipe = new CustomRecipe()
                {
                    Id = recipe.RecipeID,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Servings = recipe.Servings + " Serving(s)",
                    Calories = calories,
                    RDI = "RDI " + Math.Round(decCalories / 1000 / users[0].CaloriesDayGoal * 100, 2).ToString() + "%",
                    ToolTip = "Prep time: " + recipe.PrepTime + "\nCook time: " + recipe.CookTime + "\nCategory: " + RecipeCategory.Name + ingredients + directions
                };
                customRecipes.Add(customRecipe);
            }
            CustomRecipes = new ObservableCollection<CustomRecipe>(customRecipes);
        }
    }

    public class CustomRecipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Servings { get; set; }
        public string RDI { get; set; }
        public string Calories { get; set; }
        public string ToolTip { get; set; }
    }
}

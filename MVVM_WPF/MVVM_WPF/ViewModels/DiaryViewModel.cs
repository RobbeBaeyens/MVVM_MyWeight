using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MVVM_WPF.ViewModels
{
    public class DiaryViewModel : BasisViewModel
    {
        #region PROPERTIES
        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());

        private DateTime _date = DateTime.Today;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                App.Current.Properties["GlobalDiaryDate"] = _date;
                ChangedDate();
            }
        }

        private int _summaryPercent;
        public int SummaryPercent
        {
            get
            {
                return _summaryPercent;
            }
            set
            {
                _summaryPercent = value;
            }
        }

        private string _rdi;
        public string RDI
        {
            get
            {
                return _rdi;
            }
            set
            {
                _rdi = value;
            }
        }

        private string _calloriesRemaining;
        public string CalloriesRemaining
        {
            get
            {
                return _calloriesRemaining;
            }
            set
            {
                _calloriesRemaining = value;
            }
        }

        private string _calloriesConsumed;
        public string CalloriesConsumed
        {
            get
            {
                return _calloriesConsumed;
            }
            set
            {
                _calloriesConsumed = value;
            }
        }

        public Grid control;
        public Grid SummaryGridControl
        {
            get { return control; }
            set { control = value; }
        }
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public User user;
        public MainViewModel viewModel;
        public DateTime diaryDate;
        List<DiaryTimeStamp> diaryTimeStamps;
        #endregion

        #region MORE PROPERTIES

        private ObservableCollection<CustomMeal> _breakfastFoods;
        public ObservableCollection<CustomMeal> BreakfastFoods
        {
            get
            {
                return _breakfastFoods;
            }
            set
            {
                _breakfastFoods = value;
                NotifyPropertyChanged(nameof(_breakfastFoods));
            }
        }

        private CustomMeal _selectedBreakfastFood;
        public CustomMeal SelectedBreakfastFood
        {
            get
            {
                return _selectedBreakfastFood;
            }
            set
            {
                _selectedBreakfastFood = value;
                NotifyPropertyChanged(nameof(_selectedBreakfastFood));
            }
        }

        private ObservableCollection<CustomMeal> _lunchFoods;
        public ObservableCollection<CustomMeal> LunchFoods
        {
            get
            {
                return _lunchFoods;
            }
            set
            {
                _lunchFoods = value;
                NotifyPropertyChanged(nameof(_lunchFoods));
            }
        }

        private CustomMeal _selectedLunchFood;
        public CustomMeal SelectedLunchFood
        {
            get
            {
                return _selectedLunchFood;
            }
            set
            {
                _selectedLunchFood = value;
                NotifyPropertyChanged(nameof(_selectedLunchFood));
            }
        }

        private ObservableCollection<CustomMeal> _dinnerFoods;
        public ObservableCollection<CustomMeal> DinnerFoods
        {
            get
            {
                return _dinnerFoods;
            }
            set
            {
                _dinnerFoods = value;
                NotifyPropertyChanged(nameof(_dinnerFoods));
            }
        }

        private CustomMeal _selectedDinnerFood;
        public CustomMeal SelectedDinnerFood
        {
            get
            {
                return _selectedDinnerFood;
            }
            set
            {
                _selectedDinnerFood = value;
                NotifyPropertyChanged(nameof(_selectedDinnerFood));
            }
        }

        private ObservableCollection<CustomMeal> _snackFoods;
        public ObservableCollection<CustomMeal> SnackFoods
        {
            get
            {
                return _snackFoods;
            }
            set
            {
                _snackFoods = value;
                NotifyPropertyChanged(nameof(_snackFoods));
            }
        }

        private CustomMeal _selectedSnackFood;
        public CustomMeal SelectedSnackFood
        {
            get
            {
                return _selectedSnackFood;
            }
            set
            {
                _selectedSnackFood = value;
                NotifyPropertyChanged(nameof(_selectedSnackFood));
            }
        }

        decimal calloriesConsumed = 0;
        decimal calloriesRemaining = 0;
        #endregion

        public DiaryViewModel(MainViewModel viewModel, int userID, DateTime diaryDate)
        {
            this.viewModel = viewModel;
            this.diaryDate = diaryDate;

            user = unitOfWork.UserRepo.ZoekOpPK(userID);
            List<Diary> diariesOfToday = unitOfWork.DiaryRepo.Ophalen(d => d.UserID == user.UserID && d.Date == DateTime.Today).ToList();
            Console.WriteLine(diariesOfToday.Count);
            if(diariesOfToday.Count == 0)
            {
                Diary diary = new Diary() { Date = DateTime.Today, UserID = user.UserID };
                unitOfWork.DiaryRepo.Toevoegen(diary);
                unitOfWork.Save();
                CreateDiaryTimeStamps(diary);
            }

            Date = diaryDate;
            LoadPage();
            App.Current.Properties["GlobalUserID"] = userID;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Breakfast":
                    App.Current.Properties["GlobalSelectedTimestamp"] = 1;
                    App.Current.Properties["GlobalDiaryDate"] = Date;
                    UpdateViewCommand.Execute("DiaryAddRecipes");
                    break;
                case "Lunch":
                    App.Current.Properties["GlobalSelectedTimestamp"] = 2;
                    App.Current.Properties["GlobalDiaryDate"] = Date;
                    UpdateViewCommand.Execute("DiaryAddRecipes");
                    break;
                case "Dinner":
                    App.Current.Properties["GlobalSelectedTimestamp"] = 3;
                    App.Current.Properties["GlobalDiaryDate"] = Date;
                    UpdateViewCommand.Execute("DiaryAddRecipes");
                    break;
                case "Snacks/Other":
                    App.Current.Properties["GlobalSelectedTimestamp"] = 4;
                    App.Current.Properties["GlobalDiaryDate"] = Date;
                    UpdateViewCommand.Execute("DiaryAddRecipes");
                    break;

                case "RemoveBreakfast":
                    if(SelectedBreakfastFood != null)
                    {
                        unitOfWork.MealRepo.Verwijderen(SelectedBreakfastFood.Id);
                        unitOfWork.Save();
                        LoadPage();
                    }
                    break;
                case "RemoveLunch":
                    if (SelectedLunchFood != null)
                    {
                        unitOfWork.MealRepo.Verwijderen(SelectedLunchFood.Id);
                        unitOfWork.Save();
                        LoadPage();
                    }
                    break;
                case "RemoveDinner":
                    if (SelectedDinnerFood != null)
                    {
                        unitOfWork.MealRepo.Verwijderen(SelectedDinnerFood.Id);
                        unitOfWork.Save();
                        LoadPage();
                    }
                    break;
                case "RemoveSnack":
                    if (SelectedSnackFood != null)
                    {
                        unitOfWork.MealRepo.Verwijderen(SelectedSnackFood.Id);
                        unitOfWork.Save();
                        LoadPage();
                    }
                    break;
            }
        }

        public void LoadPage()
        {
            UpdateViewCommand = new UpdateViewCommand(viewModel);

            calloriesConsumed = 0;
            calloriesRemaining = 0;
            SummaryPercent = 0;


            int diaryID = 0;
            List<Diary> diaries = unitOfWork.DiaryRepo.Ophalen(d => d.UserID == user.UserID && d.Date == Date).ToList();
            if (diaries.Count == 0)
            {
                Diary diary = new Diary() { Date = Date, UserID = user.UserID };
                unitOfWork.DiaryRepo.Toevoegen(diary);
                unitOfWork.Save();
                CreateDiaryTimeStamps(diary);
            }
            diaries = unitOfWork.DiaryRepo.Ophalen(d => d.UserID == user.UserID && d.Date == Date).ToList();
            if (diaries.Count != 0)
            {
                diaryID = diaries[0].DiaryID;
                Console.WriteLine("DiaryID: " + diaryID);
                App.Current.Properties["GlobalDiaryID"] = diaryID;

                LoadMealLists(diaryID);
            }

            calloriesConsumed = Math.Round(calloriesConsumed / 1000 ,2);
            calloriesRemaining = Math.Round((user.CaloriesDayGoal - calloriesConsumed), 2);
            CalloriesRemaining = calloriesRemaining + " kcal";
            CalloriesConsumed = calloriesConsumed + " kcal";
            SummaryPercent = int.Parse(Math.Floor((calloriesConsumed / user.CaloriesDayGoal) * 100).ToString());
            RDI = $"{SummaryPercent}% of RDI";

            control = CreateSummaryGrid();
        }

        public void LoadMealLists(int diaryID)
        {
            try
            {
                diaryTimeStamps = unitOfWork.DiaryTimeStampRepo.Ophalen(t => t.DiaryID == diaryID).ToList();
                foreach(DiaryTimeStamp diaryTimeStamp in diaryTimeStamps)
                {
                    List<DiaryTimeStampMeal> diaryTimeStampMeals = unitOfWork.DiaryTimeStampMealRepo.Ophalen(t => t.DiaryTimeStampID == diaryTimeStamp.DiaryTimeStampID).ToList();
                    switch (diaryTimeStamp.TimeStampID)
                    {
                        case 1:
                            BreakfastFoods = new ObservableCollection<CustomMeal>(GetCustomMeals(diaryTimeStampMeals));
                            break;
                        case 2:
                            LunchFoods = new ObservableCollection<CustomMeal>(GetCustomMeals(diaryTimeStampMeals));
                            break;
                        case 3:
                            DinnerFoods = new ObservableCollection<CustomMeal>(GetCustomMeals(diaryTimeStampMeals));
                            break;
                        case 4:
                            SnackFoods = new ObservableCollection<CustomMeal>(GetCustomMeals(diaryTimeStampMeals));
                            break;
                    }
                }
            }
            catch(Exception ex)
            {

            }

        }

        public List<CustomMeal> GetCustomMeals(List<DiaryTimeStampMeal> diaryTimeStampMeals)
        {

            List<CustomMeal> customMeals = new List<CustomMeal>();
            foreach (DiaryTimeStampMeal diaryTimeStampMeal in diaryTimeStampMeals)
            {
                int mealID = diaryTimeStampMeal.MealID;

                List<MealRecipe> mealRecipes = unitOfWork.MealRecipeRepo.Ophalen(m => m.MealID == mealID).ToList();
                List<MealIngredient> mealIngredients = unitOfWork.MealIngredientRepo.Ophalen(m => m.MealID == mealID).ToList();

                string description = "";
                string unitOrServings = "";
                string calories = "";
                string rdi = "";
                string tooltip = "";

                if (mealRecipes.Count != 0)
                {
                    MealRecipe mealRecipe = mealRecipes[0];
                    Recipe recipe = unitOfWork.RecipeRepo.ZoekOpPK(mealRecipe.RecipeID);
                    RecipeCategory recipeCategory = unitOfWork.RecipeCategoryRepo.ZoekOpPK(recipe.RecipeCategoryID);

                    decimal decCalories = 0;
                    foreach (RecipeIngredient recipeIngredient in unitOfWork.RecipeIngredientRepo.Ophalen(r => r.RecipeID == recipe.RecipeID).ToList())
                    {
                        foreach (Ingredient ingredient in unitOfWork.IngredientRepo.Ophalen(i => i.IngredientID == recipeIngredient.IngredientID).ToList())
                        {
                            foreach (NutritionFact nutritionFact in unitOfWork.NutritionFactRepo.Ophalen(n => n.NutritionFactID == ingredient.NutritionFactID).ToList())
                            {
                                decCalories += nutritionFact.Calories;
                            }
                        }
                    }

                    description = "Recipe: " + recipe.Name;
                    unitOrServings = 1 + " Serving";
                    calories = ((decCalories > 1000) ? (Math.Round(decCalories / 1000 / recipe.Servings, 2)).ToString() + " kcal" : (Math.Round(decCalories / recipe.Servings, 2)).ToString() + " cal");
                    rdi = "RDI " + Math.Round(decCalories / 1000 / user.CaloriesDayGoal * 100, 2).ToString() + "%";
                    tooltip = "Prep time: " + recipe.PrepTime + "\nCook time: " + recipe.CookTime + "\nCategory: " + recipeCategory.Name;


                    calloriesConsumed += decCalories/ recipe.Servings;
                }
                if (mealIngredients.Count != 0)
                {
                    MealIngredient mealIngredient = mealIngredients[0];
                    Ingredient ingredient = unitOfWork.IngredientRepo.ZoekOpPK(mealIngredient.IngredientID);
                    NutritionFact nutritionFact = unitOfWork.NutritionFactRepo.ZoekOpPK(ingredient.NutritionFactID);

                    description += "Food: " + ingredient.Name;
                    unitOrServings = nutritionFact.Unit;
                    calories = ((nutritionFact.Calories > 1000) ? (nutritionFact.Calories / 1000).ToString() + " kcal" : (nutritionFact.Calories).ToString() + " cal");
                    rdi = "RDI " + Math.Round(nutritionFact.Calories / 1000 / user.CaloriesDayGoal * 100, 2).ToString() + "%";
                    tooltip = "Energy: " + calories + "\nFat: " + nutritionFact.Fat + " g\nCarbohydrates: " + nutritionFact.Carbohydrates + " g\nProtein: " + nutritionFact.Protein + " g";

                    calloriesConsumed += nutritionFact.Calories;
                }

                CustomMeal customMeal = new CustomMeal()
                {
                    Id = mealID,
                    Name = unitOfWork.MealRepo.ZoekOpPK(mealID).Name,
                    Description = description,
                    UnitOrServings = unitOrServings,
                    Calories = calories,
                    RDI = rdi,
                    ToolTip = tooltip
                };
                customMeals.Add(customMeal);
            }
            return customMeals;
        }

        public void CreateDiaryTimeStamps(Diary diary)
        {
            List<Timestamp> timestamps = unitOfWork.TimestampRepo.Ophalen().ToList();
            foreach(Timestamp timestamp in timestamps)
            {
                DiaryTimeStamp diaryTimeStamp = new DiaryTimeStamp()
                {
                    DiaryID = diary.DiaryID,
                    TimeStampID = timestamp.TimeStampID
                };
                unitOfWork.DiaryTimeStampRepo.Toevoegen(diaryTimeStamp);
                unitOfWork.Save();
            }
        }

        public Grid CreateSummaryGrid()
        {
            Grid summaryGrid = new Grid();
            GridLength gridLength = new GridLength(10);
            for (int i = 0; i < 10; i++)
            {
                summaryGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = gridLength });
            }
            for (int i = 0; i < 10; i++)
            {
                summaryGrid.RowDefinitions.Add(new RowDefinition() { Height = gridLength });
            }

            Thickness cellmargin = new Thickness() { Bottom = 1, Left = 1, Right = 1, Top = 1 };
            int cell = 100;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Rectangle rectangle = new Rectangle() { Width = 10, Height = 10, Margin = cellmargin };
                    if( SummaryPercent > 100)
                    {
                        rectangle.Fill = Brushes.DarkRed;
                    }
                    else
                    {
                        if (cell > SummaryPercent)
                        {
                            rectangle.Fill = Brushes.Gray;
                        }
                        else
                        {
                            rectangle.Fill = Brushes.CadetBlue;
                        }
                    }
                    summaryGrid.Children.Add(rectangle);
                    Grid.SetRow(rectangle, x);
                    Grid.SetColumn(rectangle, y);
                    cell--;
                }
            }

            return summaryGrid;
        }

        private void ChangedDate()
        {
            Console.WriteLine("Date set: " + Date.ToString("dd/MM/yyyy"));
            LoadPage();
        }

    }

    public class CustomMeal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UnitOrServings { get; set; }
        public string RDI { get; set; }
        public string Calories { get; set; }
        public string ToolTip { get; set; }
    }
}

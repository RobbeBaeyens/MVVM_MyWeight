using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
using MVVM_WPF.Views.DiaryAdd;
using MVVM_WPF.Views.Error;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_WPF.ViewModels
{
    public class DiaryFoodsViewModel : BasisViewModel
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());

        public List<User> users;

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

        private ObservableCollection<Food> _foods;
        public ObservableCollection<Food> Foods
        {
            get
            {
                return _foods;
            }
            set
            {
                _foods = value;
                NotifyPropertyChanged(nameof(_foods));
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
            set
            {
                _selectedTimeStamp = value;
                ChangeTimeStamp(_selectedTimeStamp.TimeStampID);
                NotifyPropertyChanged(nameof(_selectedTimeStamp));
            }
        }

        private Food _selectedFood = null;
        public Food SelectedFood
        {
            get
            {
                return _selectedFood;
            }
            set
            {
                _selectedFood = value;
                NotifyPropertyChanged(nameof(_selectedFood));
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

        public DiaryFoodsViewModel(MainViewModel viewModel, int userID, int selectedTimestampID, int diaryID)
        {
            this.diaryID = diaryID;
            try
            {
                users = unitOfWork.UserRepo.Ophalen(u => u.UserID == userID).ToList();
                diary = unitOfWork.DiaryRepo.ZoekOpPK(diaryID);
                Search();
                Timestamps = unitOfWork.TimestampRepo.Ophalen().ToList();
                foreach (Timestamp timestamp in Timestamps)
                {
                    if (timestamp.TimeStampID == selectedTimestampID)
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
                case "NewFood":
                    WindowCollection windows = Application.Current.Windows;
                    List<string> windowTitles = new List<string>();
                    foreach (Window window in windows)
                    {
                        windowTitles.Add(window.Title);
                    }
                    if (!windowTitles.Contains("NewFood"))
                    {
                        NewFood newFood = new NewFood();
                        newFood.ShowDialog();
                        Search();
                    }
                    break;
                case "Recipes":
                    App.Current.Properties["GlobalSelectedTimestamp"] = SelectedTimeStamp.TimeStampID;
                    App.Current.Properties["GlobalDiaryDate"] = Date;
                    UpdateViewCommand.Execute("DiaryAddRecipes");
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
                case "Edit":
                    Edit();
                    break;
            }
        }

        private void Add()
        {
            if (SelectedFood != null)
            {
                Ingredient ingredient = unitOfWork.IngredientRepo.ZoekOpPK(SelectedFood.Id);
                MealDialogue mealDialogue = new MealDialogue(ingredient, SelectedDiaryTimeStamp);
                mealDialogue.ShowDialog();
            }
        }

        private void Edit()
        {
            if (SelectedFood != null)
            {
                Ingredient ingredient = unitOfWork.IngredientRepo.ZoekOpPK(SelectedFood.Id);

                NewFood newFood = new NewFood(ingredient);
                newFood.ShowDialog();
                Search();
            }
        }

        private void Search()
        {
            if (SearchText == "")
            {
                Ingredients = unitOfWork.IngredientRepo.Ophalen().ToList();
            }
            else
            {
                Ingredients = unitOfWork.IngredientRepo.Ophalen(i => i.Name.ToLower().Contains(SearchText.ToLower())).ToList();
            }

            NutritionFacts = unitOfWork.NutritionFactRepo.Ophalen().ToList();
            List<Food> foods = new List<Food>();
            foreach(Ingredient ingredient in Ingredients)
            {
                foreach(NutritionFact nutritionFact in NutritionFacts)
                {
                    if(nutritionFact.NutritionFactID == ingredient.NutritionFactID)
                    {
                        string calories = ((nutritionFact.Calories > 1000) ? (nutritionFact.Calories / 1000).ToString() + " kcal" : (nutritionFact.Calories).ToString() + " cal");
                        Food food = new Food()
                        {
                            Id = ingredient.IngredientID,
                            Name = ingredient.Name,
                            Brand = ingredient.Brand,
                            Unit = nutritionFact.Unit,
                            Calories = calories,
                            RDI = "RDI " + Math.Round(nutritionFact.Calories / 1000 / users[0].CaloriesDayGoal * 100,2).ToString() + "%",
                            ToolTip = "Energy: " + calories + "\nFat: " + nutritionFact.Fat + " g\nCarbohydrates: " + nutritionFact.Carbohydrates + " g\nProtein: " + nutritionFact.Protein + " g"
                        };
                        foods.Add(food);
                    }
                }
            }
            Foods = new ObservableCollection<Food>(foods);
        }
    }

    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public string RDI { get; set; }
        public string Calories { get; set; }
        public string ToolTip { get; set; }


        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
            }
        }
    }
}

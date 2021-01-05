using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
using MVVM_WPF.Views.Error;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_WPF.ViewModels
{
    public class NewFoodViewModel : BasisViewModel
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());

        private string _brand = "";
        public string Brand
        {
            get
            {
                return _brand;
            }

            set
            {
                _brand = value;
                NotifyPropertyChanged(_brand);
            }
        }

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

        private string _energy = "";
        public string Energy
        {
            get
            {
                return _energy;
            }

            set
            {
                _energy = value;
                NotifyPropertyChanged(_energy);
            }
        }
        public decimal DecEnergy = 0;

        private string _fat = "";
        public string Fat
        {
            get
            {
                return _fat;
            }

            set
            {
                _fat = value;
                NotifyPropertyChanged(_fat);
            }
        }
        public decimal DecFat = 0;

        private string _carbohydrates = "";
        public string Carbohydrates
        {
            get
            {
                return _carbohydrates;
            }

            set
            {
                _carbohydrates = value;
                NotifyPropertyChanged(_carbohydrates);
            }
        }
        public decimal DecCarbohydrates = 0;

        private string _protein = "";
        public string Protein
        {
            get
            {
                return _protein;
            }

            set
            {
                _protein = value;
                NotifyPropertyChanged(_protein);
            }
        }
        public decimal DecProtein = 0;

        private List<ServingSize> _servingSizes = new List<ServingSize>();
        public List<ServingSize> ServingSizes
        {
            get
            {
                return _servingSizes;
            }

            set
            {
                _servingSizes = value;
            }
        }

        private ServingSize _selectedServingSize;
        public ServingSize SelectedServingSize
        {
            get
            {
                return _selectedServingSize;
            }

            set
            {
                _selectedServingSize = value;
                SelectedServingSizeChanged(_selectedServingSize);
            }
        }

        private Visibility _servingSizeVisibility;
        public Visibility ServingSizeVisibility
        {
            get
            {
                return _servingSizeVisibility;
            }
            set
            {
                _servingSizeVisibility = value;
            }
        }

        private Visibility _servingSizeVisibility1;
        public Visibility ServingSizeVisibility1
        {
            get
            {
                return _servingSizeVisibility1;
            }
            set
            {
                _servingSizeVisibility1 = value;
            }
        }

        private Visibility _servingSizeVisibility2;
        public Visibility ServingSizeVisibility2
        {
            get
            {
                return _servingSizeVisibility2;
            }
            set
            {
                _servingSizeVisibility2 = value;
            }
        }

        private string _servingSizeDescription = "";
        public string ServingSizeDescription { 
            get 
            {
                return _servingSizeDescription;
            } 
            set
            {
                _servingSizeDescription = value;
                NotifyPropertyChanged(_servingSizeDescription);
            }
        }

        private List<ServingSize> _servingSizes1 = new List<ServingSize>();
        public List<ServingSize> ServingSizes1
        {
            get
            {
                return _servingSizes1;
            }

            set
            {
                _servingSizes1 = value;
                NotifyPropertyChanged(nameof(_servingSizes1));
            }
        }

        private ServingSize _selectedServingSize1;
        public ServingSize SelectedServingSize1
        {
            get
            {
                return _selectedServingSize1;
            }

            set
            {
                _selectedServingSize1 = value;
                NotifyPropertyChanged(nameof(_selectedServingSize1));
            }
        }

        private string _confirmButtonText;
        public string ConfirmButtonText
        {
            get
            {
                return _confirmButtonText;
            }
            set
            {
                _confirmButtonText = value;
                NotifyPropertyChanged(_confirmButtonText);
            }
        }



        private bool _editModeVisibility;
        public bool EditModeVisibility
        {
            get
            {
                return _editModeVisibility;
            }
            set
            {
                _editModeVisibility = value;
                NotifyPropertyChanged(nameof(_editModeVisibility));
            }
        }

        public bool EditMode = false;
        public Ingredient EditIngredient;

        public NewFoodViewModel()
        {
            ServingSizeVisibility = Visibility.Collapsed;
            _servingSizes.Add(new ServingSize() { Value = "-1", Name = "Select serving type" });
            _servingSizes.Add(new ServingSize() { Value = "1", Name = "100g / 100ml" });
            _servingSizes.Add(new ServingSize() { Value = "2", Name = "1 serving (e.g. 1 glass, 75g, 2 pieces)" });

            _servingSizes1.Add(new ServingSize() { Value = "-1", Name = "Select serving unit" });
            _servingSizes1.Add(new ServingSize() { Value = "1", Name = "grams(g)" });
            _servingSizes1.Add(new ServingSize() { Value = "2", Name = "mililiter(ml)" });

            SelectedServingSize = ServingSizes[0];
            SelectedServingSize1 = ServingSizes1[0];

            EditMode = false;
            EditModeVisibility = true;
            ConfirmButtonText = "Add new Food";
        }

        public NewFoodViewModel(Ingredient ingredient)
        {
            ServingSizeVisibility = Visibility.Collapsed;
            _servingSizes.Add(new ServingSize() { Value = "-1", Name = "Select serving type" });
            _servingSizes.Add(new ServingSize() { Value = "1", Name = "100g / 100ml" });
            _servingSizes.Add(new ServingSize() { Value = "2", Name = "1 serving (e.g. 1 glass, 75g, 2 pieces)" });

            _servingSizes1.Add(new ServingSize() { Value = "-1", Name = "Select serving unit" });
            _servingSizes1.Add(new ServingSize() { Value = "1", Name = "grams(g)" });
            _servingSizes1.Add(new ServingSize() { Value = "2", Name = "mililiter(ml)" });

            SelectedServingSize = ServingSizes[0];
            SelectedServingSize1 = ServingSizes1[0];

            Name = ingredient.Name;
            Brand = ingredient.Brand;
            NutritionFact nutritionFact = unitOfWork.NutritionFactRepo.ZoekOpPK(ingredient.NutritionFactID);
            Energy = Math.Round(nutritionFact.Calories, 0).ToString();
            Fat = nutritionFact.Fat.ToString();
            Carbohydrates = nutritionFact.Carbohydrates.ToString();
            Protein = nutritionFact.Protein.ToString();
            switch (nutritionFact.Unit)
            {
                case "100 grams(g)":
                    SelectedServingSize = ServingSizes[1];
                    SelectedServingSize1 = ServingSizes1[1];
                    break;

                case "100 mililiter(ml)":
                    SelectedServingSize = ServingSizes[1];
                    SelectedServingSize1 = ServingSizes1[2];
                    break;

                default:
                    SelectedServingSize = ServingSizes[2];
                    ServingSizeDescription = nutritionFact.Unit;
                    break;
            }


            EditMode = true;
            EditIngredient = ingredient;
            EditModeVisibility = false;
            ConfirmButtonText = "Edit Food";
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
                    WindowCollection windows = Application.Current.Windows;
                    foreach (Window window in windows)
                    {
                        if (window.Title == "NewFood")
                        {
                            window.Close();
                        }
                    }
                    break;
                case "AddFood":
                    AddFood();
                    break;
            }
        }

        private void AddFood()
        {
            if (CheckForm())
            {
                if (!EditMode)
                {
                    SaveNewFood();
                }
                else
                {
                    EditFood();
                }
            }
        }

        private void SelectedServingSizeChanged(ServingSize selected)
        {
            ServingSizeVisibility = Visibility.Visible;
            ServingSizeVisibility1 = Visibility.Visible;
            ServingSizeVisibility2 = Visibility.Collapsed;
            switch (selected.Value)
            {
                case "1":
                    ServingSizeVisibility = Visibility.Visible;
                    ServingSizeVisibility1 = Visibility.Visible;
                    ServingSizeVisibility2 = Visibility.Collapsed;
                    break;
                case "2":
                    ServingSizeVisibility = Visibility.Visible;
                    ServingSizeVisibility1 = Visibility.Collapsed;
                    ServingSizeVisibility2 = Visibility.Visible;
                    SelectedServingSize1 = ServingSizes1[0];
                    break;
                default:
                    ServingSizeVisibility = Visibility.Collapsed;
                    break;
            }
        }

        private bool CheckForm()
        {
            List<string> emptyTextboxes = new List<string>();
            List<string> nonNumericTextboxes = new List<string>();
            if (Brand.Length == 0)
            {
                emptyTextboxes.Add("Brand");
            }
            if (Name.Length == 0)
            {
                emptyTextboxes.Add("Name");
            }
            if (Energy.Length == 0)
            {
                emptyTextboxes.Add("Energy");
            }
            if (!decimal.TryParse(Energy, out DecEnergy))
            {
                nonNumericTextboxes.Add("Energy");
            }
            if (Fat.Length == 0)
            {
                emptyTextboxes.Add("Fat");
            }
            if (!decimal.TryParse(Fat, out DecFat))
            {
                nonNumericTextboxes.Add("Fat");
            }
            if (Carbohydrates.Length == 0)
            {
                emptyTextboxes.Add("Carbohydrates");
            }
            if (!decimal.TryParse(Carbohydrates, out DecCarbohydrates))
            {
                nonNumericTextboxes.Add("Carbohydrates");
            }
            if (Protein.Length == 0)
            {
                emptyTextboxes.Add("Protein");
            }
            if (!decimal.TryParse(Protein, out DecProtein))
            {
                nonNumericTextboxes.Add("Protein");
            }
            if (SelectedServingSize.Value != "1" && SelectedServingSize.Value != "2")
            {
                emptyTextboxes.Add("Serving Size");
            }
            else if (SelectedServingSize.Value == "1")
            {
                if (SelectedServingSize1.Value != "1" && SelectedServingSize1.Value != "2")
                {
                    emptyTextboxes.Add("Serving Size");
                }
            }
            else if (SelectedServingSize.Value == "2")
            {
                if (ServingSizeDescription.Length == 0)
                {
                    emptyTextboxes.Add("Serving Size Description");
                }
            }

            if (emptyTextboxes.Count == 0 && nonNumericTextboxes.Count == 0)
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
                if(nonNumericTextboxes.Count != 0)
                {
                    string errorText = "These inputs must be decimal values:";
                    foreach (string textboxName in nonNumericTextboxes)
                    {
                        errorText += "\n- " + textboxName;
                    }
                    errorDialogue = new CustomErrorDialogue("Error", errorText, new int[] { 360, 500 });
                    errorDialogue.ShowDialog();
                }
                return false;
            }
        }

        private void SaveNewFood()
        {
            try
            {
                string unit = "1 serving";
                if (SelectedServingSize.Value == "1")
                {
                    unit = "100 " + SelectedServingSize1.Name;
                }
                else if (SelectedServingSize.Value == "2")
                {
                    unit = ServingSizeDescription;
                }

                NutritionFact nutritionFact = new NutritionFact()
                {
                    Unit = unit,
                    Calories = DecEnergy,
                    Fat = DecFat,
                    Carbohydrates = DecCarbohydrates,
                    Protein = DecProtein
                };

                unitOfWork.NutritionFactRepo.Toevoegen(nutritionFact);
                unitOfWork.Save();

                Console.WriteLine("The ID is: " + nutritionFact.NutritionFactID);

                Ingredient ingredient = new Ingredient()
                {
                    Name = Name,
                    Brand = Brand,
                    NutritionFactID = nutritionFact.NutritionFactID
                };

                unitOfWork.IngredientRepo.Toevoegen(ingredient);
                unitOfWork.Save();

                CustomSuccesDialogue succesDialogue = new CustomSuccesDialogue("Succes", "New food {" + Name + "} added");
                succesDialogue.ShowDialog();
                Execute("Exit");
            }
            catch(Exception ex)
            {
                CustomErrorDialogue customErrorDialogue = new CustomErrorDialogue("Database error", "Couldn't store {" + Name + "} to the database!\n\n" + ex, new int[] { 500, 600 });
                customErrorDialogue.ShowDialog();
            }
        }

        private void EditFood()
        {
            try
            {
                NutritionFact nutritionFact = unitOfWork.NutritionFactRepo.ZoekOpPK(EditIngredient.NutritionFactID);
                nutritionFact.Calories = DecEnergy;
                nutritionFact.Fat = DecFat;
                nutritionFact.Carbohydrates = DecCarbohydrates;
                nutritionFact.Protein = DecProtein;

                unitOfWork.NutritionFactRepo.Aanpassen(nutritionFact);
                unitOfWork.Save();

                CustomSuccesDialogue succesDialogue = new CustomSuccesDialogue("Succes", "Food {" + Name + "} edited");
                succesDialogue.ShowDialog();
                Execute("Exit");
            }
            catch (Exception ex)
            {
                CustomErrorDialogue customErrorDialogue = new CustomErrorDialogue("Database error", "Couldn't edit {" + Name + "} to the database!\n\n" + ex, new int[] { 500, 600 });
                customErrorDialogue.ShowDialog();
            }
        }
    }

    public class ServingSize
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }
}

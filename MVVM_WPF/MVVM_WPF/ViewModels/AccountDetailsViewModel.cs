using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
using MVVM_WPF.Views.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_WPF.ViewModels
{
    public class AccountDetailsViewModel : BasisViewModel
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        private decimal _weight1;
        public decimal Weight1
        {
            get
            {
                return _weight1;
            }
            set
            {
                _weight1 = value;
            }
        }

        private decimal _weight2;
        public decimal Weight2
        {
            get
            {
                return _weight2;
            }
            set
            {
                _weight2 = value;
            }
        }

        private decimal _currentWeight;
        public decimal CurrentWeight
        {
            get
            {
                return _currentWeight;
            }
            set
            {
                _currentWeight = value;
            }
        }

        private string _weight1Kg;
        public string Weight1Kg
        {
            get
            {
                return _weight1Kg;
            }
            set
            {
                _weight1Kg = value;
            }
        }

        private string _weight2Kg;
        public string Weight2Kg
        {
            get
            {
                return _weight2Kg;
            }
            set
            {
                _weight2Kg = value;
            }
        }

        private string _currentWeightKg;
        public string CurrentWeightKg
        {
            get
            {
                return _currentWeightKg;
            }
            set
            {
                _currentWeightKg = value;
            }
        }

        private string _lostWeightKg;
        public string LostWeightKg
        {
            get
            {
                return _lostWeightKg;
            }
            set
            {
                _lostWeightKg = value;
            }
        }

        private string _performance;
        public string Performance
        {
            get
            {
                return _performance;
            }
            set
            {
                _performance = value;
            }
        }

        private string _weightToGoKg;
        public string WeightToGoKg
        {
            get
            {
                return _weightToGoKg;
            }
            set
            {
                _weightToGoKg = value;
            }
        }

        private string _weight;
        public string Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        private string _wantedWeight;
        public string WantedWeight
        {
            get
            {
                return _wantedWeight;
            }
            set
            {
                _wantedWeight = value;
            }
        }

        private string _dayGoal;
        public string DayGoal
        {
            get
            {
                return _dayGoal;
            }
            set
            {
                _dayGoal = value;
            }
        }

        private string _setGoal;
        public string SetGoal
        {
            get
            {
                return _setGoal;
            }
            set
            {
                _setGoal = value;
            }
        }

        User user;

        public AccountDetailsViewModel(MainViewModel viewModel, int userID)
        {
            App.Current.Properties["GlobalUserID"] = userID;
            user = unitOfWork.UserRepo.ZoekOpPK(userID);
            Username = user.Username;

            LoadPage();

            UpdateViewCommand = new UpdateViewCommand(viewModel);
        }

        public void LoadPage()
        {
            CurrentWeight = user.CurrentWeight;
            if (user.WantedWeight > user.Weight)
            {
                Weight1 = user.Weight;
                Weight2 = user.WantedWeight;
                Performance = "Weight Gain";
            }
            else if (user.WantedWeight == user.Weight)
            {
                Performance = "Weight Hold";
            }
            else
            {
                Weight2 = user.Weight;
                Weight1 = user.WantedWeight;
                Performance = "Weight Loss";
            }

            Weight1Kg = Weight1.ToString() + " Kg";
            Weight2Kg = Weight2.ToString() + " Kg";
            CurrentWeightKg = CurrentWeight.ToString() + " Kg";

            WeightToGoKg = (user.WantedWeight - user.CurrentWeight).ToString() + " Kg";

            SetGoal = $"Set Goal: {user.CaloriesDayGoal} Kcal";
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
            decimal currentWeight = 0;
            decimal wantedWeight = 0;
            switch (parameter.ToString())
            {
                case "Logout":
                    App.Current.Properties["GlobalUserID"] = -1;
                    UpdateViewCommand.Execute("Logout");
                    break;
                case "SetCurrentWeight":
                    if (decimal.TryParse(Weight, out currentWeight))
                    {
                        user.CurrentWeight = currentWeight;
                        unitOfWork.UserRepo.Aanpassen(user);
                        unitOfWork.Save();
                        LoadPage();
                    }
                    else
                    {
                        CustomErrorDialogue errorDialogue = new CustomErrorDialogue("Error", "Current Weight must be a decimal value");
                        errorDialogue.ShowDialog();
                    }
                    break;
                case "SetWantedWeight":
                    if (decimal.TryParse(WantedWeight, out wantedWeight))
                    {
                        user.WantedWeight = wantedWeight;
                        unitOfWork.UserRepo.Aanpassen(user);
                        unitOfWork.Save();
                        LoadPage();
                    }
                    else
                    {
                        CustomErrorDialogue errorDialogue = new CustomErrorDialogue("Error", "Wanted Weight must be a decimal value");
                        errorDialogue.ShowDialog();
                    }
                    break;
                case "SetDayGoal":
                    int dayGoal = 0;
                    if (int.TryParse(DayGoal, out dayGoal))
                    {
                        user.CaloriesDayGoal = dayGoal;
                        unitOfWork.UserRepo.Aanpassen(user);
                        unitOfWork.Save();
                        LoadPage();
                    }
                    else
                    {
                        CustomErrorDialogue errorDialogue = new CustomErrorDialogue("Error", "Calories Goal must be an integer");
                        errorDialogue.ShowDialog();
                    }
                    break;
                case "ResetWeightProgress":
                    user.Weight = user.CurrentWeight;
                    unitOfWork.UserRepo.Aanpassen(user);
                    unitOfWork.Save();
                    LoadPage();
                    break;
            }
        }
    }
}

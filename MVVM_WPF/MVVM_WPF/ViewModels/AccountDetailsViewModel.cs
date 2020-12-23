using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
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

        public AccountDetailsViewModel(MainViewModel viewModel, int userID)
        {
            App.Current.Properties["GlobalUserID"] = userID;
            User user = unitOfWork.UserRepo.ZoekOpPK(userID);
            CurrentWeight = user.CurrentWeight;
            if(user.WantedWeight > user.Weight)
            {
                Weight1 = user.Weight;
                Weight2 = user.WantedWeight;
            }
            else
            {
                Weight2 = user.Weight;
                Weight1 = user.WantedWeight;
            }
            Console.WriteLine(Weight1);
            Console.WriteLine(Weight2);

            Weight1Kg = Weight1.ToString() + " Kg";
            Weight2Kg = Weight2.ToString() + " Kg";
            CurrentWeightKg = CurrentWeight.ToString() + " Kg";

            UpdateViewCommand = new UpdateViewCommand(viewModel);
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
                case "Logout":
                    App.Current.Properties["GlobalUserID"] = -1;
                    UpdateViewCommand.Execute("Logout");
                    break;
            }
        }
    }
}

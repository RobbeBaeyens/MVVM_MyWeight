using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
using MVVM_WPF.Views.DiaryAdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_WPF.ViewModels
{
    public class DiaryRecipesViewModel : BasisViewModel
    {
        public List<Timestamp> Timestamps { get; set; }

        public string Date { get; set; }

        private Timestamp _selectedTimeStamp;
        public Timestamp SelectedTimeStamp
        {
            get { return _selectedTimeStamp; }
            set { 
                _selectedTimeStamp = value;
                Console.WriteLine(_selectedTimeStamp.Name);
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
                SelectedDiaryTimeStampChanged();
            }
        }

        private void SelectedDiaryTimeStampChanged()
        {

        }

        public DiaryRecipesViewModel(MainViewModel viewModel, int userID, int selectedTimestamp, DateTime diaryDate)
        {
            try
            {
                Timestamps = unitOfWork.TimestampRepo.Ophalen().ToList();
                foreach(Timestamp timestamp in Timestamps)
                {
                    if(timestamp.TimeStampID == selectedTimestamp)
                    {
                        _selectedTimeStamp = timestamp;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Date = diaryDate.ToString("dd/MM/yyyy");

            App.Current.Properties["GlobalUserID"] = userID;
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
                case "NewRecipe":
                    NewRecipe newRecipe = new NewRecipe();
                    newRecipe.Show();
                    break;
            }
        }
    }
}

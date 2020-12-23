using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private int _calloriesRemaining;
        public int CalloriesRemaining
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

        private int _calloriesConsumed;
        public int CalloriesConsumed
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

        public DiaryViewModel(MainViewModel viewModel, int userID)
        {
            User user = unitOfWork.UserRepo.ZoekOpPK(userID);
            List<Diary> diariesOfToday = unitOfWork.DiaryRepo.Ophalen(d => d.UserID == user.UserID && d.Date == DateTime.Today).ToList();
            Console.WriteLine(diariesOfToday.Count);
            if(diariesOfToday.Count == 0)
            {
                Diary diary = new Diary() { Date = DateTime.Today, UserID = user.UserID };
                unitOfWork.DiaryRepo.Toevoegen(diary);
            }

            App.Current.Properties["GlobalUserID"] = userID;
            UpdateViewCommand = new UpdateViewCommand(viewModel);

            CalloriesConsumed = 999;
            CalloriesRemaining = user.CaloriesDayGoal - CalloriesConsumed;
            double cC = CalloriesRemaining;
            double cR = _calloriesConsumed;
            SummaryPercent = int.Parse(Math.Floor((cR/user.CaloriesDayGoal)*100).ToString());
            RDI = $"{SummaryPercent}% of RDI";

            control = CreateSummaryGrid();
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
                    if(cell > SummaryPercent)
                    {
                        rectangle.Fill = Brushes.Gray;
                    }
                    else
                    {
                        rectangle.Fill = Brushes.CadetBlue;
                    }
                    summaryGrid.Children.Add(rectangle);
                    Grid.SetRow(rectangle, x);
                    Grid.SetColumn(rectangle, y);
                    cell--;
                }
            }

            return summaryGrid;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {

        }
    }
}

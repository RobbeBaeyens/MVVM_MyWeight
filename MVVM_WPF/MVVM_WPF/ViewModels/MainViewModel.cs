using MVVM_WPF.Commands;
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
    public class MainViewModel : BasisViewModel
    {
        private BasisViewModel _selectedViewModel;
        public BasisViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                NotifyPropertyChanged(nameof(SelectedViewModel));
            }
        }
        private BasisViewModel _selectedNavViewModel;
        public BasisViewModel SelectedNavViewModel
        {
            get { return _selectedNavViewModel; }
            set
            {
                _selectedNavViewModel = value;
                NotifyPropertyChanged(nameof(SelectedNavViewModel));
            }
        }


        public MainViewModel()
        {
            SelectedViewModel = new AccountViewModel(this);
            SelectedNavViewModel = new NavNotLoggedInViewModel(this);
            UpdateViewCommand = new UpdateViewCommand(this);
            App.Current.Properties["GlobalUserID"] = -1;
            App.Current.Properties["GlobalDiaryID"] = -1;
            App.Current.Properties["GlobalSelectedTimestamp"] = -1;
            App.Current.Properties["GlobalDiaryDate"] = DateTime.Today;
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
            Window thisWindow = new Window();
            WindowCollection windows = Application.Current.Windows;
            foreach(Window window in windows)
            {
                if(window.Title == "MyWeight")
                {
                    thisWindow = window;
                }
            }

            switch (parameter.ToString())
            {
                case "Exit":
                    Environment.Exit(0);
                    break;
                case "Maximize":
                    if(GetWindowState(thisWindow) == WindowState.Maximized)
                    {
                        ChangeWindowState(WindowState.Normal, thisWindow);
                    } else
                    {
                        ChangeWindowState(WindowState.Maximized, thisWindow);
                    }
                    break;
                case "Minimize":
                    ChangeWindowState(WindowState.Minimized, thisWindow);
                    break;
            }
        }

        private void ChangeWindowState(WindowState state, Window window)
        {
            window.WindowState = state;
        }

        private WindowState GetWindowState(Window window)
        {
            return window.WindowState;
        }
    }
}

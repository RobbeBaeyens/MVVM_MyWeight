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
                    Environment.Exit(0);
                    break;
                case "Maximize":
                    if(GetWindowState() == WindowState.Maximized)
                    {
                        ChangeWindowState(WindowState.Normal);
                    } else
                    {
                        ChangeWindowState(WindowState.Maximized);
                    }
                    break;
                case "Minimize":
                    ChangeWindowState(WindowState.Minimized);
                    break;
            }
        }

        private void ChangeWindowState(WindowState state)
        {
            Window window = (Window)Application.Current.Windows.OfType
            <System.Windows.Window>().SingleOrDefault(x => x.IsActive);

            window.WindowState = state;
        }

        private WindowState GetWindowState()
        {
            Window window = (Window)Application.Current.Windows.OfType
            <System.Windows.Window>().SingleOrDefault(x => x.IsActive);

            return window.WindowState;
        }
    }
}

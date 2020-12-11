using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_WPF.ViewModels
{
    public class RegisterViewModel : BasisViewModel, INotifyPropertyChanged
    {
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

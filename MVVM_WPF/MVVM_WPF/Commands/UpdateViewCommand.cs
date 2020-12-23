using MVVM_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace MVVM_WPF.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int globalUserID = int.Parse(App.Current.Properties["GlobalUserID"].ToString());
            Console.WriteLine(App.Current.Properties["GlobalUserID"]);
            switch (parameter.ToString())
            {
                case "AccountDetails":
                    if (globalUserID != -1)
                    {
                        Console.WriteLine("AccountDetails");
                        viewModel.SelectedViewModel = new AccountDetailsViewModel(viewModel, globalUserID);
                        viewModel.SelectedNavViewModel = new NavLoggedInViewModel(viewModel, 0);
                    }
                    else
                    {
                        Console.WriteLine("Account");
                        viewModel.SelectedViewModel = new AccountViewModel(viewModel);
                        viewModel.SelectedNavViewModel = new NavNotLoggedInViewModel(viewModel);
                    }
                    break;
                case "Login":
                    Console.WriteLine("Login");
                    viewModel.SelectedViewModel = new LoginViewModel(viewModel);
                    viewModel.SelectedNavViewModel = new NavNotLoggedInViewModel(viewModel);
                    break;
                case "Register":
                    Console.WriteLine("Register");
                    viewModel.SelectedViewModel = new RegisterViewModel(viewModel);
                    viewModel.SelectedNavViewModel = new NavNotLoggedInViewModel(viewModel);
                    break;
                case "Diary":
                    Console.WriteLine("Diary");
                    viewModel.SelectedViewModel = new DiaryViewModel(viewModel, globalUserID);
                    viewModel.SelectedNavViewModel = new NavLoggedInViewModel(viewModel, 1);
                    break;
                case "Logout":
                    Console.WriteLine("Logout");
                    viewModel.SelectedViewModel = new AccountViewModel(viewModel);
                    viewModel.SelectedNavViewModel = new NavNotLoggedInViewModel(viewModel);
                    break;
            }
        }
    }
}

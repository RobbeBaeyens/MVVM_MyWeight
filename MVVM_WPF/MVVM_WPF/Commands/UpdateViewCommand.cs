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
            int globalDiaryID = int.Parse(App.Current.Properties["GlobalDiaryID"].ToString());
            int globalSelectedTimestamp = int.Parse(App.Current.Properties["GlobalSelectedTimestamp"].ToString());
            DateTime globalDiaryDate = DateTime.Parse(App.Current.Properties["GlobalDiaryDate"].ToString());
            Console.WriteLine("UserID: " + App.Current.Properties["GlobalUserID"]);
            switch (parameter.ToString())
            {
                case "AccountDetails":
                    if (globalUserID != -1)
                    {
                        viewModel.SelectedViewModel = new AccountDetailsViewModel(viewModel, globalUserID);
                        viewModel.SelectedNavViewModel = new NavLoggedInViewModel(viewModel, 0);
                    }
                    else
                    {
                        viewModel.SelectedViewModel = new AccountViewModel(viewModel);
                        viewModel.SelectedNavViewModel = new NavNotLoggedInViewModel(viewModel);
                    }
                    break;
                case "Login":
                    viewModel.SelectedViewModel = new LoginViewModel(viewModel);
                    viewModel.SelectedNavViewModel = new NavNotLoggedInViewModel(viewModel);
                    break;
                case "Register":
                    viewModel.SelectedViewModel = new RegisterViewModel(viewModel);
                    viewModel.SelectedNavViewModel = new NavNotLoggedInViewModel(viewModel);
                    break;
                case "Diary":
                    viewModel.SelectedViewModel = new DiaryViewModel(viewModel, globalUserID, globalDiaryDate);
                    viewModel.SelectedNavViewModel = new NavLoggedInViewModel(viewModel, 1);
                    break;

                case "DiaryAddRecipes":
                    viewModel.SelectedViewModel = new DiaryRecipesViewModel(viewModel, globalUserID, globalSelectedTimestamp, globalDiaryID);
                    viewModel.SelectedNavViewModel = new NavLoggedInViewModel(viewModel);
                    break;
                case "DiaryAddFoods":
                    viewModel.SelectedViewModel = new DiaryFoodsViewModel(viewModel, globalUserID, globalSelectedTimestamp, globalDiaryID);
                    viewModel.SelectedNavViewModel = new NavLoggedInViewModel(viewModel);
                    break;


                case "Logout":
                    viewModel.SelectedViewModel = new AccountViewModel(viewModel);
                    viewModel.SelectedNavViewModel = new NavNotLoggedInViewModel(viewModel);
                    break;
            }
        }
    }
}

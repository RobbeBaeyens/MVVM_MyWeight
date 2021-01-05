using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_DAL.Security;
using MVVM_WPF.Commands;
using MVVM_WPF.Views.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using static MVVM_DAL.Security.PasswordHasher;

namespace MVVM_WPF.ViewModels
{
    public class LoginViewModel : BasisViewModel
    {
        #region Properties
        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());

        PasswordHasher hash = new PasswordHasher();
        public User user { get; set; }
        public List<User> users { get; set; }

        private string userName = "";
        public string UserName
        {
            get { return this.userName; }
            set
            {
                if (!string.Equals(this.userName, value))
                {
                    this.userName = value;
                    this.NotifyPropertyChanged(this.userName);
                }
            }
        }
        private string password = "";
        public string Password
        {
            get { return this.password; }
            set
            {
                if (!string.Equals(this.password, value))
                {
                    this.password = value;
                    this.NotifyPropertyChanged(this.password);
                }
            }
        }
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }
        #endregion

        public LoginViewModel(MainViewModel viewModel)
        {
            UpdateViewCommand = new UpdateViewCommand(viewModel);
            users = unitOfWork.UserRepo.Ophalen().ToList();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            CustomErrorDialogue errorDialogue;
            switch (parameter.ToString())
            {
                case "Login":
                    Console.WriteLine("Clicked login!");
                    if (!String.IsNullOrWhiteSpace(this.UserName) && !String.IsNullOrWhiteSpace(this.Password))
                    {
                        bool userExists = false;
                        foreach(User user in users)
                        {
                            if(this.UserName == user.Username)
                            {
                                if(hash.VerifyHashedPassword(user.Password, this.Password) == PasswordVerificationResult.Success)
                                {
                                    App.Current.Properties["GlobalUserID"] = user.UserID;

                                    CustomSuccesDialogue succesDialogue = new CustomSuccesDialogue("Error", "Login succesvol!", new int[] { 360, 500 });
                                    succesDialogue.ShowDialog();

                                    UpdateViewCommand.Execute("AccountDetails");
                                }
                                else
                                {
                                    errorDialogue = new CustomErrorDialogue("Error", "Incorrect wachtwoord!", new int[] { 360, 500 });
                                    errorDialogue.ShowDialog();
                                }
                                userExists = true;
                            }
                        }
                        if (userExists == false)
                        {
                            errorDialogue = new CustomErrorDialogue("Error", "Gebruiker bestaat niet!", new int[] { 360, 500 });
                            errorDialogue.ShowDialog();
                        }
                    }
                    else
                    {
                        errorDialogue = new CustomErrorDialogue("Error", "alle velden invullen!", new int[] { 360, 500 });
                        errorDialogue.ShowDialog();
                    }
                    break;
            }
        }
    }
}

using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVM_WPF.ViewModels
{
    public class LoginViewModel : BasisViewModel
    {
        #region Properties
        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());
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
            switch (parameter.ToString())
            {
                case "Login":
                    Console.WriteLine("Clicked login!");
                    if (!String.IsNullOrWhiteSpace(this.UserName) && !String.IsNullOrWhiteSpace(this.Password))
                    {
                        foreach(User user in users)
                        {
                            if(this.UserName == user.Username)
                            {
                                if(this.Password == user.Password)
                                {
                                    App.Current.Properties["GlobalUserID"] = user.UserID;
                                    UpdateViewCommand.Execute("AccountDetails");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Incorrect wachtwoord!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Gebruiker bestaat niet!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Alle velden invullen!");
                        Console.WriteLine($"{this.UserName}, {this.Password.Length > 0}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
            }
        }
    }
}

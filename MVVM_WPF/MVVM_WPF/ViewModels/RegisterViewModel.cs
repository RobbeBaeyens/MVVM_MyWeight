﻿using MVVM_DAL.Data;
using MVVM_DAL.Data.UnitOfWork;
using MVVM_DAL.Models;
using MVVM_DAL.Security;
using MVVM_WPF.Commands;
using MVVM_WPF.Views.Error;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_WPF.ViewModels
{
    public class RegisterViewModel : BasisViewModel
    {
        #region Properties
        IUnitOfWork unitOfWork = new UnitOfWork(new MyWeightEntities());

        PasswordHasher hash = new PasswordHasher();
        public User user { get; set; }
        public List<User> users { get; set; }

        private string userName;
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
        private string password;
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
        private string weight;
        public string Weight
        {
            get { return this.weight; }
            set
            {
                if (!string.Equals(this.weight, value))
                {
                    this.weight = value;
                    this.NotifyPropertyChanged(this.weight);
                }
            }
        }
        private string wantedWeight;
        public string WantedWeight
        {
            get { return this.wantedWeight; }
            set
            {
                if (!string.Equals(this.wantedWeight, value))
                {
                    this.wantedWeight = value;
                    this.NotifyPropertyChanged(this.wantedWeight);
                }
            }
        }
        private string caloriesDayGoal = "2700";
        public string CaloriesDayGoal
        {
            get { return this.caloriesDayGoal; }
            set
            {
                if (!string.Equals(this.caloriesDayGoal, value))
                {
                    this.caloriesDayGoal = value;
                    this.NotifyPropertyChanged(this.caloriesDayGoal);
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

        public RegisterViewModel(MainViewModel viewModel)
        {
            UpdateViewCommand = new UpdateViewCommand(viewModel);
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Register":
                    CustomErrorDialogue errorDialogue;
                    if (!String.IsNullOrWhiteSpace(this.UserName) && !String.IsNullOrWhiteSpace(this.Password) && !String.IsNullOrWhiteSpace(this.Weight) && !String.IsNullOrWhiteSpace(this.wantedWeight))
                    {
                        int caloriesDayGoalInt;
                        decimal weightDecimal;
                        decimal wantedWeightDecimal;
                        int ok = 0;
                        if (int.TryParse(this.CaloriesDayGoal, out caloriesDayGoalInt) && decimal.TryParse(this.Weight, out weightDecimal) && decimal.TryParse(this.WantedWeight, out wantedWeightDecimal))
                        {
                            users = unitOfWork.UserRepo.Ophalen(u => u.Username == this.UserName).ToList();
                            if(users.Count == 0)
                            {
                                user = new User() { Username = this.UserName, Password = hash.HashPassword(this.Password), Weight = decimal.Parse(this.Weight), CurrentWeight = decimal.Parse(this.Weight), WantedWeight = decimal.Parse(this.WantedWeight), CaloriesDayGoal = caloriesDayGoalInt };
                                unitOfWork.UserRepo.Toevoegen(user);
                                ok = unitOfWork.Save();
                                if (ok == 1)
                                {
                                    CustomSuccesDialogue succesDialogue = new CustomSuccesDialogue("Succes", $"{user.Username} Succesvol geregistreerd", new int[] { 360, 500 });
                                    succesDialogue.ShowDialog();
                                    UpdateViewCommand.Execute("Login");
                                }
                                else
                                {
                                    errorDialogue = new CustomErrorDialogue("Error", "Register foutje..??", new int[] { 360, 500 });
                                    errorDialogue.ShowDialog();
                                }
                            }
                            else
                            {
                                errorDialogue = new CustomErrorDialogue("Error", $"{this.UserName} bestaat al!", new int[] { 360, 500 });
                                errorDialogue.ShowDialog();
                            }
                        }
                        else
                        {
                            errorDialogue = new CustomErrorDialogue("Error",  "Weight, WantedWeight & Calories Goal moeten deimale getallen zijn of integers!", new int[] { 360, 500 });
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

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}

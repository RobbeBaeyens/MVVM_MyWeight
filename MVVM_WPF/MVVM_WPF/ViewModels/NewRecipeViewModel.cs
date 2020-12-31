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
    public class NewRecipeViewModel : BasisViewModel
    {
        public NewRecipeViewModel()
        {

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
                    WindowCollection windows = Application.Current.Windows;
                    foreach(Window window in windows)
                    {
                        if(window.Title == "NewRecipe")
                        {
                            window.Close();
                        }
                    }
                    break;
            }
        }
    }
}

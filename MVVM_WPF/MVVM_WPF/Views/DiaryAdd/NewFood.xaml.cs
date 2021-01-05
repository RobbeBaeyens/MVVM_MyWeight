using MVVM_DAL.Models;
using MVVM_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_WPF.Views.DiaryAdd
{
    /// <summary>
    /// Interaction logic for NewRecipe.xaml
    /// </summary>
    public partial class NewFood : Window
    {
        public NewFood()
        {
            InitializeComponent();
            DataContext = new NewFoodViewModel();
        }
        public NewFood(Ingredient ingredient)
        {
            InitializeComponent();
            DataContext = new NewFoodViewModel(ingredient);
        }
    }
}

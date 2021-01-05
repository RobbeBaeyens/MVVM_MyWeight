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

namespace MVVM_WPF.Views.Error
{
    /// <summary>
    /// Interaction logic for NewRecipe.xaml
    /// </summary>
    public partial class MealDialogue : Window
    {
        public MealDialogue(Ingredient ingredient, DiaryTimeStamp diaryTimeStamp)
        {
            InitializeComponent();
            DataContext = new MealViewModel(ingredient, diaryTimeStamp);
        }
        public MealDialogue(Recipe recipe, DiaryTimeStamp diaryTimeStamp)
        {
            InitializeComponent();
            DataContext = new MealViewModel(recipe, diaryTimeStamp);
        }
    }
}

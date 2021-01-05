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
    public partial class CustomSuccesDialogue : Window
    {
        public CustomSuccesDialogue(string title, string text)
        {
            InitializeComponent();
            DataContext = new SuccesViewModel(title, text);
        }
        public CustomSuccesDialogue(string title, string text, int[] dimensions)
        {
            InitializeComponent();
            DataContext = new SuccesViewModel(title, text, dimensions);
        }
    }
}

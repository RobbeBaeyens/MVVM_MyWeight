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
    public partial class CustomErrorDialogue : Window
    {
        public CustomErrorDialogue(string title, string text)
        {
            InitializeComponent();
            DataContext = new ErrorViewModel(title, text);
        }
        public CustomErrorDialogue(string title, string text, int[] dimensions)
        {
            InitializeComponent();
            DataContext = new ErrorViewModel(title, text, dimensions);
        }
        public CustomErrorDialogue(string title, Exception ex)
        {
            InitializeComponent();
            DataContext = new ErrorViewModel(title, ex);
        }
        public CustomErrorDialogue(string title, Exception ex, int[] dimensions)
        {
            InitializeComponent();
            DataContext = new ErrorViewModel(title, ex, dimensions);
        }
    }
}

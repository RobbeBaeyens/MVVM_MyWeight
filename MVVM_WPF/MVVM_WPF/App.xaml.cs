using MVVM_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DiaryViewModel viewModel = new DiaryViewModel();
            Views.Diary view = new Views.Diary();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}

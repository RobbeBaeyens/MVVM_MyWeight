using MVVM_WPF.Commands;
using MVVM_WPF.Views.DiaryAdd;
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
    public class ErrorViewModel : BasisViewModel
    {
        WindowCollection windows;

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        private string _errortext;
        public string ErrorText
        {
            get
            {
                return _errortext;
            }
            set
            {
                _errortext = value;
            }
        }

        private int _height;
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }


        public ErrorViewModel(string title, string text, int[] dimensions)
        {
            InitializeErrorViewModel(title, text, dimensions);
        }
        public ErrorViewModel(string title, string text)
        {
            int[] dimensions = new int[] { 300, 500 };
            InitializeErrorViewModel(title, text, dimensions);
        }
        public ErrorViewModel(string title, Exception ex, int[] dimensions)
        {
            string text = ex.ToString();
            InitializeErrorViewModel(title, text, dimensions);
        }
        public ErrorViewModel(string title, Exception ex)
        {
            int[] dimensions = new int[] { 300, 500 };
            string text = ex.ToString();
            InitializeErrorViewModel(title, text, dimensions);
        }

        public void InitializeErrorViewModel(string title, string text, int[] dimensions)
        {
            Title = title;
            Height = dimensions[0] - 100;
            ErrorText = text;

            windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window.Title != "Error")
                {
                    window.IsEnabled = false;
                }
                else
                {
                    window.Height = dimensions[0];
                    window.MinHeight = dimensions[0];
                    window.MaxHeight = dimensions[0];
                    window.Width = dimensions[1];
                    window.MinWidth = dimensions[1];
                    window.MaxWidth = dimensions[1];
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

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Exit":
                    foreach (Window window in windows)
                    {
                        window.IsEnabled = true;
                        if (window.Title == "Error")
                        {
                            window.Close();
                        }
                    }
                    break;
            }
        }
    }
}

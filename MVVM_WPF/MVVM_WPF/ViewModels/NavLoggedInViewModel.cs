using MVVM_WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MVVM_WPF.ViewModels
{
    public class NavLoggedInViewModel : BasisViewModel
    {
        private SolidColorBrush _userColor;
        public SolidColorBrush UserColor
        {
            get
            {
                return _userColor;
            }
            set
            {
                _userColor = value;
            }
        }
        private SolidColorBrush _diaryColor;
        public SolidColorBrush DiaryColor
        {
            get
            {
                return _diaryColor;
            }
            set
            {
                _diaryColor = value;
            }
        }

        private Color Primary = Color.FromRgb(0, 148, 255);
        private Color DarkPrimary = Color.FromRgb(0, 100, 175);

        public NavLoggedInViewModel(MainViewModel viewModel, int page = 1)
        {
            UpdateViewCommand = new UpdateViewCommand(viewModel);
            switch (page)
            {
                case 0:
                    UserColor = new SolidColorBrush(DarkPrimary);
                    DiaryColor = new SolidColorBrush(Primary);
                    break;
                case 1:
                    UserColor = new SolidColorBrush(Primary);
                    DiaryColor = new SolidColorBrush(DarkPrimary);
                    break;
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

        }
    }
}

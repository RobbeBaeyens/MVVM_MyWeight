using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PasswordBoxMVVM.Components
{
    public partial class BindablePasswordBox : UserControl
    {
        //Deze DependencyProperty bind niet default TwoWay, hier FrameworkPropertyMetadataOptions.BindsTwoWayByDefault definieren
        //Je kan ook TwoWay binding definieren in [NAAM VAN LOGIN VIEW].xaml 
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox), 
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = passwordBox.Password;
        }
    }
}

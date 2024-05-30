using MVPTema3.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MVPTema3.Views
{
    public partial class UtilizatorView : Window
    {

        public UtilizatorView()
        {
            InitializeComponent();
            var viewModel = new UtilizatorViewModel();
            DataContext = viewModel;
            viewModel.RequestClose += UtilizatorViewModel_RequestClose;
        }
        private void UtilizatorViewModel_RequestClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is UtilizatorViewModel viewModel)
            {
                viewModel.NewPassword = ((PasswordBox)sender).Password;
            }
        }



        private void LoginPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is UtilizatorViewModel viewModel)
            {
                viewModel.LoginPassword = ((PasswordBox)sender).Password;
            }
        }

    }
}
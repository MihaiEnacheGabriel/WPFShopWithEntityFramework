using MVPTema3.ViewModels;
using System.Windows;

namespace MVPTema3.Views
{
    public partial class CategorieView : Window
    {
        public CategorieView()
        {
            InitializeComponent();
            Left = 100; // X coordinate
            Top = 100; // Y coordinate
            DataContext = new CategoryViewModel();
        }
        private void StartPage_Click(object sender, RoutedEventArgs e)
        {
            var startPage = new StartPage();
            startPage.Show();
            Close();
        }

        private void ProducerManagement_Click(object sender, RoutedEventArgs e)
        {
            var producerView = new ProducatorView();
            producerView.Show();
            Close();
        }

    }
}

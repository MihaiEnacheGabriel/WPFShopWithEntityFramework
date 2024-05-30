using MVPTema3.ViewModels;
using System.Windows;

namespace MVPTema3.Views
{
    public partial class ProducatorView : Window
    {
        public ProducatorView()
        {
            InitializeComponent();
            Left = 100; // X coordinate
            Top = 100; // Y coordinate
            DataContext = new ProducatorViewModel();
        }

        private void StartPage_Click(object sender, RoutedEventArgs e)
        {
            var startPage = new StartPage();
            startPage.Show();
            Close();
        }

        private void CategoryManagement_Click(object sender, RoutedEventArgs e)
        {
            var categoryView = new CategorieView();
            categoryView.Show();
            Close();
        }
    }
}

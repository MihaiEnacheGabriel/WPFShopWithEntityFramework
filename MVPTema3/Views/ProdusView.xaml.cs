using System.Windows;

namespace MVPTema3.Views
{
    public partial class ProdusView : Window
    {
        public ProdusView()
        {
            InitializeComponent();
        }

        private void CategoryManagement_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Category Management View
            var categoryView = new CategorieView();
            categoryView.Show();
            Close();
        }

        private void ProducerManagement_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Producer Management View
            var producerView = new ProducatorView();
            producerView.Show();
            Close();
        }
    }
}

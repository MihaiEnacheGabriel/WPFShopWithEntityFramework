using System.Windows;
using System.Windows.Controls;

namespace MVPTema3.Views
{
    public partial class StartPage : Window
    {
        public StartPage()
        {
            InitializeComponent();
            Left = 100; // X coordinate
            Top = 100; // Y coordinate
            AddNavigationBar();
        }

        private void AddNavigationBar()
        {
            StackPanel navigationBar = new StackPanel();
            navigationBar.Orientation = Orientation.Horizontal;
            navigationBar.HorizontalAlignment = HorizontalAlignment.Center;
            navigationBar.VerticalAlignment = VerticalAlignment.Top;

            Button categoryButton = new Button();
            categoryButton.Content = "Category Management";
            categoryButton.Click += CategoryButton_Click;
            navigationBar.Children.Add(categoryButton);

            Button producerButton = new Button();
            producerButton.Content = "Producer Management";
            producerButton.Click += ProducerButton_Click;
            navigationBar.Children.Add(producerButton);

            Button productButton = new Button();
            productButton.Content = "Product Management";
            productButton.Click += ProductButton_Click;
            navigationBar.Children.Add(productButton);

            Button stockButton = new Button(); // Add Stock Management button
            stockButton.Content = "Stock Management";
            stockButton.Click += StockButton_Click; // Attach event handler
            navigationBar.Children.Add(stockButton); // Add button to navigation bar

            MainGrid.Children.Add(navigationBar);
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var categoryView = new CategorieView();
            categoryView.Show();
            Close();
        }

        private void ProducerButton_Click(object sender, RoutedEventArgs e)
        {
            var producerView = new ProducatorView();
            producerView.Show();
            Close();
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            var produsView = new ProdusView();
            produsView.Show();
            Close();
        }

        private void StockButton_Click(object sender, RoutedEventArgs e)
        {
            var stocView = new StockView();
            stocView.Show();
            Close();
        }
    }
}

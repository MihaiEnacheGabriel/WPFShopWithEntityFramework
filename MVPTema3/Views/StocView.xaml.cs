using System;
using System.Windows;
using MVPTema3.ViewModels;

namespace MVPTema3.Views
{
    public partial class StockView : Window
    {
        public StockView()
        {
            InitializeComponent();
            DataContext = new StockViewModel(); // Initialize ViewModel
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MVPTema3.Models;
using MVPTema3.ViewModels;
using MVPTema3Magazin.Models;
using System.Linq;
using System.Windows;

namespace MVPTema3.Views
{
    public partial class BonView : Window
    {
        private readonly MyDbContext _context;
        private readonly BonViewModel _viewModel;

        public BonView()
        {
            InitializeComponent();
            _context = new MyDbContext();
            _viewModel = new BonViewModel();
            DataContext = _viewModel;
            LoadInitialProduct();
        }

        private void LoadInitialProduct()
        {
            // Retrieve the first stock entry (e.g., based on ID)
            Stoc firstStock = _context.Stoc.OrderBy(s => s.ID_stoc).FirstOrDefault();

            if (firstStock != null)
            {
                // Retrieve the product associated with the first stock entry
                Produs initialProduct = firstStock.Produs;

                if (initialProduct != null)
                {
                    // Set the ComboBox's SelectedItem to the initial product
                    productComboBox.SelectedItem = initialProduct;
                }
            }
        }
    }
}

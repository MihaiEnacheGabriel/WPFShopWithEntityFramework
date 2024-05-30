using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MVPTema3.Models;
using MVPTema3.Services;
using MVPTema3Magazin.Models;

namespace MVPTema3.Views
{
    public partial class CashierView : Window
    {
        private readonly ProdusService _produsService;
        private List<Categorie> _categories;
        private List<Producator> _producers;

        public CashierView()
        {
            InitializeComponent();
            _produsService = new ProdusService(new MyDbContext());
            LoadData();
            LoadCategories();
            LoadProducers();
            Left = 100; // X coordinate
            Top = 100; // Y coordinate
        }

        private void LoadData()
        {
            // Load all products into the datagrid
            dataGrid.ItemsSource = _produsService.GetAllProducts().ToList();
        }

        private void LoadCategories()
        {
            _categories = _produsService.GetAllCategories().ToList();
            foreach (var category in _categories)
            {
                cmbCategory.Items.Add(category.Nume_categorie);
            }
        }

        private void LoadProducers()
        {
            _producers = _produsService.GetAllProducers().ToList();
            foreach (var producer in _producers)
            {
                cmbProducer.Items.Add(producer.Nume_producator);
            }
        }

        private void Search()
        {
            string name = txtName.Text.Trim();
            string barcode = txtBarcode.Text.Trim();
            string category = cmbCategory.SelectedItem?.ToString(); // Retrieve selected category
            string producer = cmbProducer.SelectedItem?.ToString(); // Retrieve selected producer
            DateTime? expirationDate = dpExpirationDate.SelectedDate;

            // Query products based on search criteria
            IEnumerable<Produs> filteredProducts = _produsService.GetAllProducts();

            if (!string.IsNullOrWhiteSpace(name))
            {
                filteredProducts = filteredProducts.Where(p => p.Nume_produs.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(barcode))
            {
                filteredProducts = filteredProducts.Where(p => p.Cod_bare.Contains(barcode));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                filteredProducts = filteredProducts.Where(p => p.Categorie.Nume_categorie.Equals(category));
            }

            if (!string.IsNullOrWhiteSpace(producer))
            {
                filteredProducts = filteredProducts.Where(p => p.Producator.Nume_producator.Equals(producer));
            }

            if (expirationDate.HasValue)
            {
                // Filter products based on expiration date
                filteredProducts = filteredProducts.Where(p => p.Stoc.Any(s => s.Data_expirare.Date <= expirationDate.Value.Date));
            }

            // Update the datagrid with filtered products
            dataGrid.ItemsSource = filteredProducts.ToList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtBarcode.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbProducer.SelectedIndex = -1;
            dpExpirationDate.SelectedDate = null;

            LoadData();
        }
        private void btnCreateBon_Click(object sender, RoutedEventArgs e)
        {
            BonView bonView = new BonView();
            bonView.Show();
            this.Close();
        }

    }
}

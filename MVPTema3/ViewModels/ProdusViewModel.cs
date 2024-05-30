using Microsoft.EntityFrameworkCore;
using MVPTema3.Commands;
using MVPTema3.Models;
using MVPTema3.Services;
using MVPTema3Magazin.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MVPTema3.ViewModels
{
    public class ProdusViewModel : INotifyPropertyChanged
    {
        private readonly ProdusService _produsService;
        private string _newProductName;
        private string _newProductBarcode;
        private bool _newProductInStock;
        private Produs _selectedProduct;
        private Categorie _selectedCategory;
        private Producator _selectedProducer;

        public ProdusViewModel()
        {
            _produsService = new ProdusService(new MyDbContext());

            AddProductCommand = new RelayCommand(obj => AddProduct());
            EditProductCommand = new RelayCommand(obj => EditProduct());
            SoftDeleteProductCommand = new RelayCommand(obj => SoftDeleteProduct());

            Products = new ObservableCollection<Produs>(_produsService.GetAllProducts());
            Producers = new ObservableCollection<Producator>(_produsService.GetProducers());
            Categories = new ObservableCollection<Categorie>(_produsService.GetCategories());
        }

        public string NewProductName
        {
            get => _newProductName;
            set
            {
                _newProductName = value;
                OnPropertyChanged();
            }
        }

        public string NewProductBarcode
        {
            get => _newProductBarcode;
            set
            {
                _newProductBarcode = value;
                OnPropertyChanged();
            }
        }

        public Categorie SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public Producator SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                OnPropertyChanged();
            }
        }

        public bool NewProductInStock
        {
            get => _newProductInStock;
            set
            {
                _newProductInStock = value;
                OnPropertyChanged();
            }
        }

        public Produs SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Produs> Products { get; set; }
        public ObservableCollection<Producator> Producers { get; set; }
        public ObservableCollection<Categorie> Categories { get; set; }

        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand SoftDeleteProductCommand { get; }

        private void AddProduct()
        {
            if (string.IsNullOrWhiteSpace(NewProductName) || string.IsNullOrWhiteSpace(NewProductBarcode) || SelectedCategory == null || SelectedProducer == null)
            {
                MessageBox.Show("All fields must be filled in.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_produsService.IsBarcodeDuplicate(NewProductBarcode))
            {
                MessageBox.Show("A product with this barcode already exists.", "Duplicate Barcode", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_produsService.IsProductNameDuplicate(NewProductName, SelectedCategory.ID_categorie, SelectedProducer.ID_producator))
            {
                MessageBox.Show("A product with this name already exists in the selected category and producer.", "Duplicate Product Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var product = new Produs
            {
                Nume_produs = NewProductName,
                Cod_bare = NewProductBarcode,
                Categorie = SelectedCategory,
                Producator = SelectedProducer,
                In_stock = NewProductInStock,
                Is_Active = true
            };
            _produsService.AddProduct(product);
            Products.Add(product);
        }

        private void EditProduct()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Please select a product to edit.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(NewProductName) || string.IsNullOrWhiteSpace(NewProductBarcode) || SelectedCategory == null || SelectedProducer == null)
            {
                MessageBox.Show("All fields must be filled in.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_produsService.IsBarcodeDuplicate(NewProductBarcode) && SelectedProduct.Cod_bare != NewProductBarcode)
            {
                MessageBox.Show("A product with this barcode already exists.", "Duplicate Barcode", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_produsService.IsProductNameDuplicate(NewProductName, SelectedCategory.ID_categorie, SelectedProducer.ID_producator) && SelectedProduct.Nume_produs != NewProductName)
            {
                MessageBox.Show("A product with this name already exists in the selected category and producer.", "Duplicate Product Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SelectedProduct.Nume_produs = NewProductName;
            SelectedProduct.Cod_bare = NewProductBarcode;
            SelectedProduct.Categorie = SelectedCategory;
            SelectedProduct.Producator = SelectedProducer;
            SelectedProduct.In_stock = NewProductInStock;
            RefreshProducts();
        }



        private void SoftDeleteProduct()
        {
            if (SelectedProduct != null)
            {
                _produsService.SoftDeleteProduct(SelectedProduct);
                Products.Remove(SelectedProduct);
                RefreshProducts();
            }
        }
        private void RefreshProducts()
        {
            Products.Clear();
            foreach (var product in _produsService.GetAllProducts())
            {
                Products.Add(product);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

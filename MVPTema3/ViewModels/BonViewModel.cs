using MVPTema3.Commands;
using MVPTema3.Models;
using MVPTema3.Services;
using MVPTema3Magazin.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MVPTema3.ViewModels
{
    public class BonViewModel : INotifyPropertyChanged
    {
        private readonly BonService _bonService;
        private ObservableCollection<ProdusVandut> _produseVandute;
        private decimal _subtotal;
        private Produs _selectedProduct;
        private ObservableCollection<Produs> _availableProducts;
        private int _quantity;

        public BonViewModel()
        {
            _bonService = new BonService(new MyDbContext());
            ProduseVandute = new ObservableCollection<ProdusVandut>();
            LoadAvailableProducts();
            AddProductCommand = new RelayCommand(AddProduct);
            ConfirmBonCommand = new RelayCommand(ConfirmBon);
        }

        public ObservableCollection<ProdusVandut> ProduseVandute
        {
            get => _produseVandute;
            set
            {
                _produseVandute = value;
                OnPropertyChanged(nameof(ProduseVandute));
            }
        }

        public decimal Subtotal
        {
            get => _subtotal;
            set
            {
                _subtotal = value;
                OnPropertyChanged(nameof(Subtotal));
            }
        }

        public Produs SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public ObservableCollection<Produs> AvailableProducts
        {
            get => _availableProducts;
            set
            {
                _availableProducts = value;
                OnPropertyChanged(nameof(AvailableProducts));
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public ICommand AddProductCommand { get; }
        public ICommand ConfirmBonCommand { get; }

        private void AddProduct(object parameter)
        {
            if (SelectedProduct != null && Quantity > 0)
            {
                ProduseVandute.Add(new ProdusVandut { Produs = SelectedProduct, Cantitate = Quantity });

                Subtotal = _bonService.CalculateSubtotal(this);

                Quantity = 0;
            }
        }

        private void ConfirmBon(object parameter)
        {
            Bon bon = new Bon
            {
                ProduseVandute = new List<ProdusVandut>(ProduseVandute)
            };

            // Confirm
            _bonService.ConfirmBon(bon);

            ProduseVandute.Clear();
            Subtotal = 0;
        }

        private void LoadAvailableProducts()
        {
            AvailableProducts = new ObservableCollection<Produs>(_bonService.GetAllProducts());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

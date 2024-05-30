using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MVPTema3.Commands;
using MVPTema3.Models;
using MVPTema3.Services;
using MVPTema3Magazin.Models;

namespace MVPTema3.ViewModels
{
    public class StockViewModel : INotifyPropertyChanged
    {
        private readonly StockService _stockService;
        private Produs _selectedProduct;
        private Stoc _selectedStock;
        private int _newStockQuantity;
        private string _newStockUnitOfMeasure;
        private DateTime _newStockSupplyDate;
        private DateTime _newStockExpiryDate;
        private decimal _newStockPurchasePrice;
        private decimal _newStockMarkup;
        private ObservableCollection<Produs> _products;
        private ObservableCollection<Stoc> _stocks;

        public StockViewModel()
        {
            _stockService = new StockService(new MyDbContext());

            AddStockCommand = new RelayCommand(obj => AddStock());
            UpdateStockCommand = new RelayCommand(obj => UpdateStock());
            EditStockCommand = new RelayCommand(obj => EditStock());

            Products = new ObservableCollection<Produs>(_stockService.GetAllActiveProducts());
            Stocks = new ObservableCollection<Stoc>(_stockService.GetAllStocks());

            // Initialize default date values
            NewStockSupplyDate = DateTime.Today;
            NewStockExpiryDate = DateTime.Today;
        }

        private decimal _sellPrice;
        private bool _isActive;

        public decimal SellPrice
        {
            get => _sellPrice;
            set
            {
                _sellPrice = value;
                OnPropertyChanged();
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnPropertyChanged();
            }
        }

        private int _quantity;

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                IsActive = _quantity > 0;
                OnPropertyChanged();
            }
        }


        private void CalculateSellPrice()
        {
            SellPrice = NewStockPurchasePrice * (1 + (NewStockMarkup / 100));
        }

        private void DetermineIsActive()
        {
            IsActive = NewStockQuantity > 0;
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

        public Stoc SelectedStock
        {
            get => _selectedStock;
            set
            {
                _selectedStock = value;
                OnPropertyChanged();
            }
        }

        public int NewStockQuantity
        {
            get => _newStockQuantity;
            set
            {
                _newStockQuantity = value;
                OnPropertyChanged();
            }
        }

        public string NewStockUnitOfMeasure
        {
            get => _newStockUnitOfMeasure;
            set
            {
                _newStockUnitOfMeasure = value;
                OnPropertyChanged();
            }
        }

        public DateTime NewStockSupplyDate
        {
            get => _newStockSupplyDate;
            set
            {
                _newStockSupplyDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime NewStockExpiryDate
        {
            get => _newStockExpiryDate;
            set
            {
                _newStockExpiryDate = value;
                OnPropertyChanged();
            }
        }

        public decimal NewStockPurchasePrice
        {
            get => _newStockPurchasePrice;
            set
            {
                _newStockPurchasePrice = value;
                OnPropertyChanged();
            }
        }

        public decimal NewStockMarkup
        {
            get => _newStockMarkup;
            set
            {
                _newStockMarkup = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Produs> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Stoc> Stocks
        {
            get => _stocks;
            set
            {
                _stocks = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddStockCommand { get; }
        public ICommand UpdateStockCommand { get; }
        public ICommand EditStockCommand { get; }

        private void AddStock()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            // Calculate the sell price
            decimal sellPrice = NewStockPurchasePrice * (1 + (NewStockMarkup / 100));

            // Determine is_active
            bool isActive = NewStockQuantity > 0;

            // Add the stock
            _stockService.AddStock(SelectedProduct, NewStockQuantity, NewStockUnitOfMeasure,
                                   NewStockSupplyDate, NewStockExpiryDate, NewStockPurchasePrice,
                                   NewStockMarkup, sellPrice, isActive);

            // Refresh the Stocks collection after adding a new stock
            Stocks = new ObservableCollection<Stoc>(_stockService.GetAllStocks());

            SellPrice = sellPrice;
        }

        private void UpdateStock()
        {
            if (SelectedStock == null)
            {
                MessageBox.Show("Please select a stock to update.");
                return;
            }

            SelectedStock.Cantitate = NewStockQuantity;
            SelectedStock.Unitate_masura = NewStockUnitOfMeasure;
            SelectedStock.Data_aprovizionare = NewStockSupplyDate;
            SelectedStock.Data_expirare = NewStockExpiryDate;
            //SelectedStock.Pret_achizitie = Math.Round(NewStockPurchasePrice, 2);\
            SelectedStock.AdaosComercial = NewStockMarkup;
            SelectedStock.Pret_vanzare = Math.Round(SelectedStock.Pret_achizitie * (1 + (NewStockMarkup / 100)), 2);
            SelectedStock.Is_Active = NewStockQuantity > 0;

            _stockService.UpdateStock(SelectedStock);
            Stocks = new ObservableCollection<Stoc>(_stockService.GetAllStocks());
        }

        private void EditStock()
        {
            if (SelectedStock != null)
            {
                NewStockQuantity = SelectedStock.Cantitate;
                NewStockUnitOfMeasure = SelectedStock.Unitate_masura;
                NewStockSupplyDate = SelectedStock.Data_aprovizionare;
                NewStockExpiryDate = SelectedStock.Data_expirare;
                //NewStockPurchasePrice = SelectedStock.Pret_achizitie;
                NewStockMarkup = SelectedStock.AdaosComercial;
                OnPropertyChanged(nameof(NewStockQuantity));
                OnPropertyChanged(nameof(NewStockUnitOfMeasure));
                OnPropertyChanged(nameof(NewStockSupplyDate));
                OnPropertyChanged(nameof(NewStockExpiryDate));
                OnPropertyChanged(nameof(NewStockPurchasePrice));
                OnPropertyChanged(nameof(NewStockMarkup));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

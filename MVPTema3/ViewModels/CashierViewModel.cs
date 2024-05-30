using MVPTema3.Commands;
using MVPTema3.Models;
using MVPTema3.Services;
using MVPTema3Magazin.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MVPTema3.ViewModels
{
    public class CashierViewModel : INotifyPropertyChanged
    {
        private readonly ProdusService _productService;
        private ObservableCollection<Produs> _searchResults;
        private string _searchName;
        private string _searchCodBare;
        private string _searchCategory;
        private string _searchProducer;
        private string _searchStock;

        public CashierViewModel(MyDbContext context)
        {
            _productService = new ProdusService(context);
            SearchCommand = new RelayCommand(Search);
        }

        public ObservableCollection<Produs> SearchResults
        {
            get => _searchResults;
            set
            {
                _searchResults = value;
                OnPropertyChanged(nameof(SearchResults));
            }
        }

        public string SearchName
        {
            get => _searchName;
            set
            {
                _searchName = value;
                OnPropertyChanged(nameof(SearchName));
            }
        }

        public string SearchCodBare
        {
            get => _searchCodBare;
            set
            {
                _searchCodBare = value;
                OnPropertyChanged(nameof(SearchCodBare));
            }
        }

        public string SearchCategory
        {
            get => _searchCategory;
            set
            {
                _searchCategory = value;
                OnPropertyChanged(nameof(SearchCategory));
            }
        }

        public string SearchProducer
        {
            get => _searchProducer;
            set
            {
                _searchProducer = value;
                OnPropertyChanged(nameof(SearchProducer));
            }
        }

        public string SearchStock
        {
            get => _searchStock;
            set
            {
                _searchStock = value;
                OnPropertyChanged(nameof(SearchStock));
            }
        }

        public ICommand SearchCommand { get; }

        private void Search(object parameter)
        {
            // Perform search based on the entered criteria
            SearchResults = new ObservableCollection<Produs>(_productService.SearchProducts(SearchName, SearchCodBare, SearchCategory, SearchProducer, SearchStock));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using MVPTema3.Commands;
using MVPTema3.Models;
using MVPTema3.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MVPTema3.ViewModels
{
    public class ProducatorViewModel : BaseViewModel
    {
        private readonly ProducatorService _producerService;

        public ProducatorViewModel()
        {
            _producerService = new ProducatorService();
            Producers = new ObservableCollection<Producator>(_producerService.GetAllProducers());

            AddProducerCommand = new RelayCommand(o => AddProducer(), o => CanAddProducer());
            EditProducerCommand = new RelayCommand(o => EditProducer(), o => CanEditProducer());
            SoftDeleteProducerCommand = new RelayCommand(o => SoftDeleteProducer(), o => CanSoftDeleteProducer());
        }

        public ObservableCollection<Producator> Producers { get; }

        private string _newProducerName;
        public string NewProducerName
        {
            get => _newProducerName;
            set
            {
                _newProducerName = value;
                OnPropertyChanged();
                ((RelayCommand)AddProducerCommand).RaiseCanExecuteChanged();
                ((RelayCommand)EditProducerCommand).RaiseCanExecuteChanged();
            }
        }

        private string _newProducerCountry;
        public string NewProducerCountry
        {
            get => _newProducerCountry;
            set
            {
                _newProducerCountry = value;
                OnPropertyChanged();
                ((RelayCommand)AddProducerCommand).RaiseCanExecuteChanged();
                ((RelayCommand)EditProducerCommand).RaiseCanExecuteChanged();
            }
        }

        private Producator _selectedProducer;
        public Producator SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                OnPropertyChanged();
                ((RelayCommand)EditProducerCommand).RaiseCanExecuteChanged();
                ((RelayCommand)SoftDeleteProducerCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AddProducerCommand { get; }
        public ICommand EditProducerCommand { get; }
        public ICommand SoftDeleteProducerCommand { get; }

        private void AddProducer()
        {
            try
            {
                _producerService.AddProducer(NewProducerName, NewProducerCountry);
                UpdateProducers();
                NewProducerName = string.Empty;
                NewProducerCountry = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanAddProducer() => !string.IsNullOrEmpty(NewProducerName) && !string.IsNullOrEmpty(NewProducerCountry);

        private void EditProducer()
        {
            if (SelectedProducer == null || !SelectedProducer.Is_Active)
            {
                MessageBox.Show("Cannot edit an inactive or non-selected producer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _producerService.EditProducer(SelectedProducer.ID_producator, NewProducerName, NewProducerCountry);
                UpdateProducers();
                NewProducerName = string.Empty;
                NewProducerCountry = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanEditProducer() => SelectedProducer != null && !string.IsNullOrEmpty(NewProducerName) && !string.IsNullOrEmpty(NewProducerCountry);

        private void SoftDeleteProducer()
        {
            if (SelectedProducer == null)
            {
                MessageBox.Show("No producer selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _producerService.SoftDeleteProducer(SelectedProducer.ID_producator);
                UpdateProducers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanSoftDeleteProducer() => SelectedProducer != null;

        private void UpdateProducers()
        {
            Producers.Clear();
            foreach (var producer in _producerService.GetAllProducers())
            {
                Producers.Add(producer);
            }
        }
    }
}

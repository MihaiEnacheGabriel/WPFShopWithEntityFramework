
using Microsoft.VisualBasic.Logging;
using MVPTema3.Commands;
using MVPTema3.Models;
using MVPTema3.Services;
using MVPTema3.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MVPTema3.ViewModels
{
    public class UtilizatorViewModel : INotifyPropertyChanged
    {
        private readonly UtilizatorService _utilizatorService;
        private Utilizator _selectedUtilizator;
        private string _newUserName;
        private string _loginUsername;
        private string _loginPassword;
        private bool _isAdmin;

        public UtilizatorViewModel()
        {
            _utilizatorService = new UtilizatorService();
            Utilizatori = new ObservableCollection<Utilizator>(_utilizatorService.GetAllUtilizatori());
            AddUtilizatorCommand = new RelayCommand(AddUtilizator, CanAddUtilizator);
            EditUtilizatorCommand = new RelayCommand(EditUtilizator, CanEditUtilizator);
            SoftDeleteUtilizatorCommand = new RelayCommand(SoftDeleteUtilizator, CanSoftDeleteUtilizator);
            LoginCommand = new RelayCommand(Login);
        }

        public ObservableCollection<Utilizator> Utilizatori { get; }

        public Utilizator SelectedUtilizator
        {
            get => _selectedUtilizator;
            set
            {
                _selectedUtilizator = value;
                OnPropertyChanged(nameof(SelectedUtilizator));
            }
        }

        public string NewUserName
        {
            get => _newUserName;
            set
            {
                _newUserName = value;
                OnPropertyChanged(nameof(NewUserName));
                ((RelayCommand)AddUtilizatorCommand).RaiseCanExecuteChanged();
            }
        }

        public string LoginUsername
        {
            get => _loginUsername;
            set
            {
                _loginUsername = value;
                OnPropertyChanged(nameof(LoginUsername));
            }
        }

        public string LoginPassword
        {
            get => _loginPassword;
            set
            {
                _loginPassword = value;
                OnPropertyChanged(nameof(LoginPassword));
            }
        }
        private string _newPassword;

        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public ICommand AddUtilizatorCommand { get; }
        public ICommand EditUtilizatorCommand { get; }
        public ICommand SoftDeleteUtilizatorCommand { get; }
        public ICommand LoginCommand { get; }

        private const string MasterPassword = "master";

        private bool PromptMasterPassword()
        {
            // Prompt the user for the master password using a dialog box
            string enteredPassword = Microsoft.VisualBasic.Interaction.InputBox("Enter Master Password:", "Master Password Required", "");

            // Check if the entered password matches the hardcoded master password
            return enteredPassword == MasterPassword;
        }

        private void AddUtilizator(object parameter)
        {
            try
            {
                if (!PromptMasterPassword())
                {
                    MessageBox.Show("Incorrect master password. Action aborted.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _utilizatorService.AddUtilizator(NewUserName, NewPassword, IsAdmin);
                UpdateUtilizatori();
                NewUserName = string.Empty;
                NewPassword = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanAddUtilizator(object parameter) => !string.IsNullOrEmpty(NewUserName);

        private void EditUtilizator(object parameter)
        {
            if (SelectedUtilizator == null || !SelectedUtilizator.Is_Active)
            {
                MessageBox.Show("Cannot edit an inactive or non-selected user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (!PromptMasterPassword())
                {
                    MessageBox.Show("Incorrect master password. Action aborted.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _utilizatorService.EditUtilizator(SelectedUtilizator.ID_utilizator, NewUserName, NewPassword, IsAdmin);
                UpdateUtilizatori();
                NewUserName = string.Empty;
                NewPassword = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private bool CanEditUtilizator(object parameter) => SelectedUtilizator != null && !string.IsNullOrEmpty(NewUserName);

        private void SoftDeleteUtilizator(object parameter)
        {
            if (SelectedUtilizator == null)
            {
                MessageBox.Show("No user selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (!PromptMasterPassword())
                {
                    MessageBox.Show("Incorrect master password. Action aborted.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _utilizatorService.SoftDeleteUtilizator(SelectedUtilizator.ID_utilizator);
                UpdateUtilizatori();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanSoftDeleteUtilizator(object parameter) => SelectedUtilizator != null;

        private void UpdateUtilizatori()
        {
            Utilizatori.Clear();
            foreach (var utilizator in _utilizatorService.GetAllUtilizatori())
            {
                Utilizatori.Add(utilizator);
            }
        }

        public event EventHandler RequestClose;

        private void Login(object parameter)
        {
            try
            {
                var user = _utilizatorService.Authenticate(LoginUsername, LoginPassword);
                if (user != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (user.Is_admin)
                    {
                        var startPage = new StartPage();
                        startPage.Show();
                        RequestClose?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        var cashierView = new CashierView();
                        cashierView.Show();
                        RequestClose?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
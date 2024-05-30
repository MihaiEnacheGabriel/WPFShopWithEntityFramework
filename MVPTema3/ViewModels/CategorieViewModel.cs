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
    public class CategoryViewModel : BaseViewModel
    {
        private readonly CategoryService categoryService;

        public CategoryViewModel()
        {
            categoryService = new CategoryService();
            Categories = new ObservableCollection<Categorie>(categoryService.GetAllCategories());

            AddCategoryCommand = new RelayCommand(o => AddCategory(), o => CanAddCategory());
            EditCategoryCommand = new RelayCommand(o => EditCategory(), o => CanEditCategory());
            SoftDeleteCategoryCommand = new RelayCommand(o => SoftDeleteCategory(), o => CanSoftDeleteCategory());
        }

        public ObservableCollection<Categorie> Categories { get; }

        private string _newCategoryName;
        public string NewCategoryName
        {
            get => _newCategoryName;
            set
            {
                _newCategoryName = value;
                OnPropertyChanged();
                ((RelayCommand)AddCategoryCommand).RaiseCanExecuteChanged();
                ((RelayCommand)EditCategoryCommand).RaiseCanExecuteChanged();
            }
        }

        private Categorie _selectedCategory;
        public Categorie SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                ((RelayCommand)EditCategoryCommand).RaiseCanExecuteChanged();
                ((RelayCommand)SoftDeleteCategoryCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AddCategoryCommand { get; }
        public ICommand EditCategoryCommand { get; }
        public ICommand SoftDeleteCategoryCommand { get; }

        private void AddCategory()
        {
            try
            {
                categoryService.AddCategory(NewCategoryName);
                UpdateCategories();
                NewCategoryName = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanAddCategory() => !string.IsNullOrEmpty(NewCategoryName);

        private void EditCategory()
        {
            if (SelectedCategory == null || !SelectedCategory.Is_Active)
            {
                MessageBox.Show("Cannot edit an inactive or non-selected category.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                categoryService.EditCategory(SelectedCategory.ID_categorie, NewCategoryName);
                UpdateCategories();
                NewCategoryName = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanEditCategory() => SelectedCategory != null && !string.IsNullOrEmpty(NewCategoryName);

        private void SoftDeleteCategory()
        {
            if (SelectedCategory == null)
            {
                MessageBox.Show("No category selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                categoryService.SoftDeleteCategory(SelectedCategory.ID_categorie);
                UpdateCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanSoftDeleteCategory() => SelectedCategory != null;

        private void UpdateCategories()
        {
            Categories.Clear();
            foreach (var category in categoryService.GetAllCategories())
            {
                Categories.Add(category);
            }
        }
    }
}

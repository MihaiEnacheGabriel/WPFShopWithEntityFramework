using MVPTema3.Models;
using MVPTema3Magazin.Models;
using System;
using System.Linq;

namespace MVPTema3.Services
{
    public class CategoryService
    {
        private readonly MyDbContext _context;

        public CategoryService()
        {
            _context = new MyDbContext();
        }

        public IQueryable<Categorie> GetAllCategories()
        {
            return _context.Categorie;
        }

        public void AddCategory(string categoryName)
        {
            if (_context.Categorie.Any(c => c.Nume_categorie == categoryName))
            {
                throw new InvalidOperationException("Category already exists.");
            }

            var newCategory = new Categorie
            {
                Nume_categorie = categoryName,
                Is_Active = true
            };

            _context.Categorie.Add(newCategory);
            _context.SaveChanges(); // Save changes to the database
        }

        public void EditCategory(int categoryId, string newCategoryName)
        {
            var category = _context.Categorie.Find(categoryId);
            if (category == null || !category.Is_Active)
            {
                throw new InvalidOperationException("Category not found or inactive.");
            }

            if (_context.Categorie.Any(c => c.Nume_categorie == newCategoryName && c.ID_categorie != categoryId))
            {
                throw new InvalidOperationException("Another category with the same name already exists.");
            }

            category.Nume_categorie = newCategoryName;
            _context.SaveChanges(); // Save changes to the database
        }

        public void SoftDeleteCategory(int categoryId)
        {
            var category = _context.Categorie.Find(categoryId);
            if (category == null)
            {
                throw new InvalidOperationException("Category not found.");
            }

            category.Is_Active = false;
            _context.SaveChanges(); // Save changes to the database
        }
    }
}

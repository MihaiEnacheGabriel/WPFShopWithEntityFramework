using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MVPTema3.Models;
using MVPTema3Magazin.Models;

namespace MVPTema3.Services
{
    public class ProdusService
    {
        private readonly MyDbContext _context;

        public ProdusService(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produs> GetAllProducts()
        {
            return _context.Produs.ToList();
        }

        public void AddProduct(Produs product)
        {
            _context.Produs.Add(product);
            _context.SaveChanges();
        }

        public void EditProduct(Produs product)
        {
            _context.Produs.Update(product);
            _context.SaveChanges();
        }

        public void SoftDeleteProduct(Produs product)
        {
            product.Is_Active = false;
            _context.Produs.Update(product);
            _context.SaveChanges();
        }

        public IEnumerable<Producator> GetProducers()
        {
            return _context.Producator.ToList();
        }

        public IEnumerable<Categorie> GetCategories()
        {
            return _context.Categorie.ToList();
        }

        public bool IsBarcodeDuplicate(string barcode)
        {
            return _context.Produs.Any(p => p.Cod_bare == barcode && p.Is_Active);
        }

        public bool IsProductNameDuplicate(string name, int categoryId, int producerId)
        {
            return _context.Produs.Any(p => p.Nume_produs == name && p.Categorie.ID_categorie == categoryId && p.Producator.ID_producator == producerId && p.Is_Active);
        }

        public IEnumerable<Produs> SearchProducts(string name, string codBare, string category, string producer, string stock)
        {
            IQueryable<Produs> query = _context.Produs.Include(p => p.Categorie).Include(p => p.Producator).Include(p => p.Stoc);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Nume_produs.Contains(name));
            }

            if (!string.IsNullOrEmpty(codBare))
            {
                query = query.Where(p => p.Cod_bare == codBare);
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Categorie.Nume_categorie.Contains(category));
            }

            if (!string.IsNullOrEmpty(producer))
            {
                query = query.Where(p => p.Producator.Nume_producator.Contains(producer));
            }

            if (!string.IsNullOrEmpty(stock))
            {
                query = query.Where(p => p.Stoc.Any(s => s.Cantitate.ToString() == stock));
            }

            return query.ToList();
        }
        public IEnumerable<Categorie> GetAllCategories()
        {
            return _context.Categorie.ToList();
        }

        public IEnumerable<Producator> GetAllProducers()
        {
            return _context.Producator.ToList();
        }
    }

}

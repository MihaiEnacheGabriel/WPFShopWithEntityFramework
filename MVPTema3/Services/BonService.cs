using MVPTema3.Models;
using MVPTema3.ViewModels;
using MVPTema3Magazin.Models;
using System;
using System.Linq;

namespace MVPTema3.Services
{
    public class BonService
    {
        private readonly MyDbContext _context;

        public BonService(MyDbContext context)
        {
            _context = context;
        }

        public decimal CalculateSubtotal(BonViewModel viewModel)
        {
            decimal subtotal = 0;
            foreach (var produsVandut in viewModel.ProduseVandute)
            {
                var stock = _context.Stoc.FirstOrDefault(s => s.Produs.ID_produs == produsVandut.Produs.ID_produs);
                if (stock != null)
                {
                    decimal productPrice = stock.Pret_vanzare;
                    subtotal += productPrice * produsVandut.Cantitate;
                }
            }
            return subtotal;
        }

        public void UpdateStockQuantity(Produs produs, int quantity)
        {
            if (produs == null)
            {
                throw new ArgumentNullException(nameof(produs));
            }

            var stock = _context.Stoc.FirstOrDefault(s => s.Produs.ID_produs == produs.ID_produs);
            if (stock != null)
            {
                stock.Cantitate -= quantity;
                _context.SaveChanges();
            }
        }
        public IEnumerable<Produs> GetAllProducts()
        {

            return _context.Produs.ToList();
        }
        public void ConfirmBon(Bon bon)
        {
            if (bon == null)
            {
                throw new ArgumentNullException(nameof(bon));
            }

            // Update the database with sold products and quantities
            foreach (var produsVandut in bon.ProduseVandute)
            {
                UpdateStockQuantity(produsVandut.Produs, produsVandut.Cantitate);
            }
            //bon.IsConfirmed = true;
            _context.SaveChanges();
        }

    }
}

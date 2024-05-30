using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using MVPTema3.Models;
using MVPTema3Magazin.Models;

namespace MVPTema3.Services
{
    public class StockService
    {
        private readonly MyDbContext _context;

        public StockService(MyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Produs> GetAllActiveProducts()
        {
            return _context.Produs.Where(p => p.Is_Active).ToList();
        }


        public IEnumerable<Stoc> GetAllStocks()
        {
            return _context.Stoc.ToList();
        }

        public void AddStock(Produs product, int quantity, string unitOfMeasure,
                     DateTime supplyDate, DateTime expiryDate, decimal purchasePrice,
                     decimal markup, decimal sellPrice, bool isActive)
        {
            var stock = new Stoc
            {
                Cantitate = quantity,
                Unitate_masura = unitOfMeasure,
                Data_aprovizionare = supplyDate,
                Data_expirare = expiryDate,
                Pret_achizitie = purchasePrice,
                Pret_vanzare = sellPrice,
                Produs = product,
                Is_Active = isActive,
                AdaosComercial = markup
            };
            if (expiryDate < supplyDate)
            {
                MessageBox.Show("Expiry date cannot be before the supply date.");
                return;
            }
            if (quantity > 0 && DateTime.Now >= supplyDate && DateTime.Now <= expiryDate)
            {
                isActive = true;
            }
            _context.Stoc.Add(stock);
            _context.SaveChanges();
        }

        public Stoc GetStockById(int id)
        {
            return _context.Stoc.FirstOrDefault(s => s.ID_stoc == id);
        }
        public void UpdateStock(Stoc stock)
        {
            if (stock.Cantitate == 0)
            {
                stock.Is_Active = false;
            }

            _context.Entry(stock).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Stoc> GetAllActiveStocks()
        {
            return _context.Stoc.Where(s => s.Is_Active).ToList();
        }


    }
}

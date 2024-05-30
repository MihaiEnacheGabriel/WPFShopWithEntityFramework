using Microsoft.EntityFrameworkCore;
using MVPTema3.Models;

namespace MVPTema3Magazin.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Bon> Bon { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Producator> Producator { get; set; }
        public DbSet<Produs> Produs { get; set; }
        public DbSet<ProdusVandut> ProdusVandut { get; set; }
        public DbSet<Stoc> Stoc { get; set; }
        public DbSet<Utilizator> Utilizator { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=magazin;Integrated Security = SSPI;TrustServerCertificate=True");
        }
        public void TestConnection()
        {
            try
            {
                this.Database.OpenConnection();
                this.Database.CloseConnection();
                Console.WriteLine("Connection successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
            }
        }

    }
}

using System.ComponentModel.DataAnnotations;

namespace MVPTema3.Models
{
    public class ProdusVandut
    {
        [Key]
        public int ID_produsvandut{ get; set; }
        public int Cantitate { get; set; }
        public decimal Subtotal { get; set; }

        // Navigation properties
        public virtual Bon Bon { get; set; }
        public virtual Produs Produs { get; set; }
    }
}

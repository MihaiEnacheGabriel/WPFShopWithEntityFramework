using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVPTema3.Models
{
    public class Bon
    {
        [Key]
        public int ID_bon { get; set; }
        public DateTime Data_eliberare { get; set; }
        public decimal Suma_incasata { get; set; }
        public int TotalQuantity { get; set; }
        public decimal Subtotal { get; set; }
        public bool Is_Active { get; set; } = true;
        // Navigation properties
        public virtual Utilizator Casier { get; set; }
        public virtual ICollection<ProdusVandut> ProduseVandute { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace MVPTema3.Models
{
    public class Stoc
    {
        [Key]
        public int ID_stoc { get; set; }
        public int Cantitate { get; set; }
        public string Unitate_masura { get; set; }
        public DateTime Data_aprovizionare { get; set; }
        public DateTime Data_expirare { get; set; }
        public decimal Pret_achizitie { get; set; }
        public decimal Pret_vanzare { get; set; }
        public bool Is_Active { get; set; } = true;
        public decimal AdaosComercial { get; set; }

        // Navigation properties
        public virtual Produs Produs { get; set; }
    }

}

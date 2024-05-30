using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVPTema3.Models
{
    public class Produs
    {
        [Key]
        public int ID_produs { get; set; }
        public string Nume_produs { get; set; }
        public string Cod_bare { get; set; }
        public bool In_stock { get; set; }
        public bool Is_Active { get; set; } = true;

        // Navigation properties
        public virtual Categorie Categorie { get; set; }
        public virtual Producator Producator { get; set; }
        public virtual ICollection<Stoc> Stoc { get; set; }

    }
}

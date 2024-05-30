using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MVPTema3.Models
{
    public class Categorie
    {
        [Key]
        public int ID_categorie { get; set; }
        public string Nume_categorie { get; set; }
        public bool Is_Active { get; set; } = true;
    }
}

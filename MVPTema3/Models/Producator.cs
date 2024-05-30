using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models
{
    public class Producator
    {
        [Key]
        public int ID_producator { get; set; }
        public string Nume_producator { get; set; }
        public string Tara_origine { get; set; }
        public bool Is_Active { get; set; } = true;
    }

}

using System.ComponentModel.DataAnnotations;

namespace MVPTema3.Models
{
    public class Utilizator
    {
        [Key]
        public int ID_utilizator { get; set; }
        public string Nume_utilizator { get; set; }
        public string Parola { get; set; }
        public bool Is_admin { get; set; }
        public bool Is_Active { get; set; }
        // Navigation property
        public virtual ICollection<Bon> Bonuri { get; set; }
    }
}
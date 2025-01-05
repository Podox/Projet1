using System.ComponentModel.DataAnnotations.Schema;

namespace Projet1.Models
{
    public class Entreprise
    {
        public int Id { get; set; }
        public string? Nom { get; set; }

        // Navigation property
        public Adresse Adresse { get; set; }

        // Foreign key property
        [ForeignKey("Adresse")]
        public int AdresseEId { get; set; }

        public string? Telephone { get; set; }

        public Entreprise()
        {
            Adresse = new Adresse();
        }
    }
}

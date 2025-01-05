using System.ComponentModel.DataAnnotations.Schema;

namespace Projet1.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }

        // Navigation property for Entreprise
        public Entreprise Entreprise { get; set; }

        [ForeignKey("Entreprise")]
        public int EntrepriseUId { get; set; }
        public string Telephone { get; set; }

        // Constructor to initialize the navigation property
        public Utilisateur()
        {
            Entreprise = new Entreprise();
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet1.Models
{
    public class Facture
    {
        public int Id { get; set; }
        public string NumeroFacture { get; set; } // Numéro unique de la facture
        public DateTime DateEmission { get; set; }
        public DateTime? DateEcheance { get; set; } // Optionnel pour les paiements à terme
        public decimal MontantTotal { get; set; }
        public bool EstPayee { get; set; } // Pour indiquer si la facture est réglée
        
        public Entreprise EntrepriseAssociee { get; set; } // Référence à l'entreprise facturée

        [ForeignKey("Entreprise")]
        public int EntrepriseAssocieeId { get; set; }

        public Facture()
        {
            EntrepriseAssociee = new Entreprise();
        }

    }
}

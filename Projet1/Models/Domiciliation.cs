using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet1.Models
{
    public class Domiciliation
    {
        public int Id { get; set; }

        // Navigation properties
        public Utilisateur Utilisateur { get; set; }
        public Document Document { get; set; }
        public Adresse AdresseDomiciliation { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        // Foreign keys

        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        [ForeignKey("Utilisateur")]
        public int UtilisateurId { get; set; }

        [ForeignKey("Adresse")]
        public int AdresseDomiciliationId { get; set; }

        // Consolidated constructor
        public Domiciliation()
        {
           
            Document = new Document();
            AdresseDomiciliation = new Adresse();
          
        }
    }

}

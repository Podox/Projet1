namespace Projet1.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public byte[] Contenu { get; set; } // Pour stocker le contenu du document sous forme de binaire
        public DateTime DateDeCreation { get; set; }
       

    }
}

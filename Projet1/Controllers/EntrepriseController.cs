using Microsoft.AspNetCore.Mvc;
using Projet1.Data;
using Projet1.Models;
using System.Linq;

namespace YourNamespace.Controllers
{
    public class EntrepriseController : Controller
    {
        private readonly Projet1Context _context;

        public EntrepriseController(Projet1Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DemandeDomiciliation()
        {
            var addresses = _context.Adresse.Where(a => a.etat == 1).ToList();
            ViewBag.Addresses = addresses;
            return View();
        }

        [HttpPost]
        public IActionResult CreateEntreprise(Entreprise entreprise)
        {
            // Get the UserId from the session
            var userIdString = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdString))
            {
                // Handle missing session value (e.g., redirect to login)
                return RedirectToAction("Login", "Account");
            }

            // Safely parse the UserId
            int userId;
            if (!int.TryParse(userIdString, out userId))
            {
                // Handle invalid UserId format
                return RedirectToAction("Error", "Home"); // Or another suitable action
            }

            // Retrieve the user
            var user = _context.Utilisateur.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Save the new entreprise
            _context.Entreprise.Add(entreprise);
            _context.SaveChanges();

            // Update the user's EntrepriseUId
            user.EntrepriseUId = entreprise.Id;
            _context.Utilisateur.Update(user);
            _context.SaveChanges();

            return RedirectToAction("ViewEntreprise");
        }


        [HttpGet]
        public IActionResult ViewEntreprise()
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var user = _context.Utilisateur
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    Entreprise = u.Entreprise,
                    Domiciliations = _context.Domiciliation
                        .Where(d => d.idUtilisateur == u.Id).ToList()
                })
                .FirstOrDefault();

            if (user == null || user.Entreprise == null)
            {
                return RedirectToAction("DemandeDomiciliation");
            }

            ViewBag.Entreprise = user.Entreprise;
            ViewBag.Domiciliations = user.Domiciliations;

            return View();
        }
    }
}

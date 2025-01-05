using Microsoft.AspNetCore.Mvc;
using Projet1.Data;
using Projet1.Models;

public class AccountController : Controller
{
    private readonly Projet1Context _context;

    public AccountController(Projet1Context context)
    {
        _context = context;
    }

    // GET: CreateAccount
    public IActionResult CreateAccount()
    {
        return View("~/Views/Account/CreateAccount.cshtml");  // Specify the full path
    }

    // POST: CreateAccount
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateAccount(Utilisateur utilisateur)
    {
        if (ModelState.IsValid)
        {
            utilisateur.EntrepriseUId = 0;
            _context.Utilisateur.Add(utilisateur);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        return View("~/Views/Account/CreateAccount.cshtml", utilisateur);  // Specify the full path
    }

    // GET: Login
    public IActionResult Login()
    {
        return View("~/Views/Account/Login.cshtml");  // Specify the full path
    }

    // POST: Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string email, string motDePasse)
    {
        var utilisateur = _context.Utilisateur
            .FirstOrDefault(u => u.Email == email && u.MotDePasse == motDePasse);

        if (utilisateur != null)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("", "Invalid email or password.");
            return View("~/Views/Account/Login.cshtml");  // Specify the full path
        }
    }
}

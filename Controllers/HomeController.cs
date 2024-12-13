
using System.Diagnostics;
using exercice_ado.Context;
using exercice_ado.DisplayModel;
using Microsoft.AspNetCore.Mvc;
using exercice_ado.Models;
using Guid = System.Guid;

namespace exercice_ado.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyDbContext _context;

    public HomeController(ILogger<HomeController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var model = new EtudiantDisplayModel()
        {
            Etudiants = _context.Etudiants.ToList(),  
        };

        return View(model); 
    }

    public IActionResult FilterByClass(int numberClass)
    {
        var model = new EtudiantDisplayModel()
        {
            Etudiants = _context.Etudiants.Where(e => e.NumberClass == numberClass).ToList()
        };

        return View("Index", model);
    }

    [HttpPost]
    public IActionResult Create(EtudiantDisplayModel model)
    {
        if (ModelState.IsValid)
        {
            var newEtudiant = new Etudiant()
            {
                Primarikey = Guid.NewGuid(),
                Name = model.Name,
                Firstname = model.Firstname,
                NumberClass = model.NumberClass,
                DateDiplome = model.DateDiplome
            };

            _context.Etudiants.Add(newEtudiant);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View("Index");
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        var etudiant = _context.Etudiants.FirstOrDefault(e => e.Primarikey == id);
        if (etudiant != null)
        {
            _context.Etudiants.Remove(etudiant);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
    
}

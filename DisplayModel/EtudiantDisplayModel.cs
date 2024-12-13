using System.ComponentModel.DataAnnotations;
using exercice_ado.Models;
using Microsoft.EntityFrameworkCore;

namespace exercice_ado.DisplayModel;
[Keyless]
public class EtudiantDisplayModel
{
    public List<Etudiant> Etudiants { get; set; }  
    public string? Name { get; set; }
    public string? Firstname { get; set; }
    public int? NumberClass { get; set; }
    public DateOnly? DateDiplome { get; set; }

    public EtudiantDisplayModel()
    {
        Etudiants = new List<Etudiant>();
    }
    
    
}
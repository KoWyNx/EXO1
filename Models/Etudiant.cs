using System;
using System.Collections.Generic;

namespace exercice_ado.Models;

public partial class Etudiant
{
    public Guid Primarikey { get; set; }

    public string? Name { get; set; }

    public string? Firstname { get; set; }

    public int? NumberClass { get; set; }

    public DateOnly? DateDiplome { get; set; }
}

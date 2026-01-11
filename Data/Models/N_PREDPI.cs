using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_PREDPI
{
    public decimal ID_PREDPISU { get; set; }

    public decimal ID_VYSETRENIA { get; set; }

    public string SUKL_KOD { get; set; } = null!;

    public DateTime DATUM_PREDPISU { get; set; }

    public string? DAVKOVANIE { get; set; }

    public string? MNOZSTVO { get; set; }

    public string? POZNAMKA { get; set; }

    public virtual N_VYSETRENIE ID_VYSETRENIANavigation { get; set; } = null!;

    public virtual N_LIEK SUKL_KODNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_DIAGNOZA
{
    public decimal ID_DIAGNOZY { get; set; }

    public string? KOD { get; set; }

    public string NAZOV { get; set; } = null!;

    public string? POPIS { get; set; }

    public virtual ICollection<N_PACIENTOVE_DIAGNOZY> N_PACIENTOVE_DIAGNOZies { get; set; } = new List<N_PACIENTOVE_DIAGNOZY>();
}

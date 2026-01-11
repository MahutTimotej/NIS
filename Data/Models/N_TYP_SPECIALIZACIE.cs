using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_TYP_SPECIALIZACIE
{
    public decimal ID_SPECIALIZACIE { get; set; }

    public string NAZOV { get; set; } = null!;

    public string? POPIS { get; set; }

    public virtual ICollection<N_LEKAR> N_LEKARs { get; set; } = new List<N_LEKAR>();
}

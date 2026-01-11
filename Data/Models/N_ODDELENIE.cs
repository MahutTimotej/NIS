using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_ODDELENIE
{
    public decimal ID_ODDELENIA { get; set; }

    public string NAZOV { get; set; } = null!;

    public decimal? POSCHODIE { get; set; }

    public decimal? KAPACITA { get; set; }

    public virtual ICollection<N_IZBA> N_IZBAs { get; set; } = new List<N_IZBA>();

    public virtual ICollection<N_LEKAR> N_LEKARs { get; set; } = new List<N_LEKAR>();

    public virtual ICollection<N_SESTRA> N_SESTRAs { get; set; } = new List<N_SESTRA>();
}

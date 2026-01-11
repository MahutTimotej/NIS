using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_VYSETRENIE
{
    public decimal ID_VYSETRENIA { get; set; }

    public decimal ID_PACIENTA { get; set; }

    public decimal ID_LEKARA { get; set; }

    public DateTime DATUM { get; set; }

    public string? TYP_VYSETRENIA { get; set; }

    public string? VYSLEDOK { get; set; }

    public byte[]? SNIMOK { get; set; }

    public virtual N_LEKAR ID_LEKARANavigation { get; set; } = null!;

    public virtual N_PACIENT ID_PACIENTANavigation { get; set; } = null!;

    public virtual ICollection<N_PREDPI> N_PREDPIs { get; set; } = new List<N_PREDPI>();
}

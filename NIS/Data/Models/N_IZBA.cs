using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_IZBA
{
    public decimal ID_IZBY { get; set; }

    public string CISLO_IZBY { get; set; } = null!;

    public decimal? KAPACITA { get; set; }

    public decimal ID_ODDELENIA { get; set; }

    public virtual N_ODDELENIE ID_ODDELENIANavigation { get; set; } = null!;

    public virtual ICollection<N_PRIJEM> N_PRIJEMs { get; set; } = new List<N_PRIJEM>();
}

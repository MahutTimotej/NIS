using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_PRIJEM
{
    public decimal ID_PRIJMU { get; set; }

    public decimal ID_PACIENTA { get; set; }

    public decimal ID_IZBY { get; set; }

    public DateTime DATUM_PRIJMU { get; set; }

    public DateTime? DATUM_PREPUSTENIA { get; set; }

    public string? STAV_PACIENTA { get; set; }

    public string? POZNAMKA { get; set; }

    public virtual N_IZBA ID_IZBYNavigation { get; set; } = null!;

    public virtual N_PACIENT ID_PACIENTANavigation { get; set; } = null!;
}

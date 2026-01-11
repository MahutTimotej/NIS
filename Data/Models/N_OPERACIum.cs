using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_OPERACIum
{
    public decimal ID_OPERACIE { get; set; }

    public decimal ID_PACIENTA { get; set; }

    public decimal ID_LEKARA { get; set; }

    public DateTime DATUM_OPERACIE { get; set; }

    public string? TYP_OPERACIE { get; set; }

    public string? POPIS { get; set; }

    public virtual N_LEKAR ID_LEKARANavigation { get; set; } = null!;

    public virtual N_PACIENT ID_PACIENTANavigation { get; set; } = null!;
}

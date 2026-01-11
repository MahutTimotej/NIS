using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_PACIENTOVE_DIAGNOZY
{
    public decimal ID_PACIENTA { get; set; }

    public decimal ID_DIAGNOZY { get; set; }

    public DateTime? DATUM_DIAGNOSTIKY { get; set; }

    public virtual N_DIAGNOZA ID_DIAGNOZYNavigation { get; set; } = null!;

    public virtual N_PACIENT ID_PACIENTANavigation { get; set; } = null!;
}

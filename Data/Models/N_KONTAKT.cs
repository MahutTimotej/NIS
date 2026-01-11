using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_KONTAKT
{
    public decimal ID_KONTAKTU { get; set; }

    public string RODNE_CISLO { get; set; } = null!;

    public string? EMAIL { get; set; }

    public string? TELEFON { get; set; }

    public string? TELEFON_PRACA { get; set; }

    public virtual N_OSOBNE_UDAJE RODNE_CISLONavigation { get; set; } = null!;
}

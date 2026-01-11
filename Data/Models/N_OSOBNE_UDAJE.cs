using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_OSOBNE_UDAJE
{
    public string RODNE_CISLO { get; set; } = null!;

    public string MENO { get; set; } = null!;

    public string PRIEZVISKO { get; set; } = null!;

    public string PSC { get; set; } = null!;

    public string? ULICA { get; set; }

    public virtual ICollection<N_KONTAKT> N_KONTAKTs { get; set; } = new List<N_KONTAKT>();

    public virtual ICollection<N_LEKAR> N_LEKARs { get; set; } = new List<N_LEKAR>();

    public virtual ICollection<N_PACIENT> N_PACIENTs { get; set; } = new List<N_PACIENT>();

    public virtual ICollection<N_SESTRA> N_SESTRAs { get; set; } = new List<N_SESTRA>();

    public virtual N_OBEC PSCNavigation { get; set; } = null!;
}

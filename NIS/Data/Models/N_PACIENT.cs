using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_PACIENT
{
    public decimal ID_PACIENTA { get; set; }

    public string RODNE_CISLO { get; set; } = null!;

    public string? POISTOVNA { get; set; }

    public virtual ICollection<N_OPERACIum> N_OPERACIa { get; set; } = new List<N_OPERACIum>();

    public virtual ICollection<N_PACIENTOVE_DIAGNOZY> N_PACIENTOVE_DIAGNOZies { get; set; } = new List<N_PACIENTOVE_DIAGNOZY>();

    public virtual ICollection<N_PRIJEM> N_PRIJEMs { get; set; } = new List<N_PRIJEM>();

    public virtual ICollection<N_VYSETRENIE> N_VYSETRENIEs { get; set; } = new List<N_VYSETRENIE>();

    public virtual N_OSOBNE_UDAJE RODNE_CISLONavigation { get; set; } = null!;
}

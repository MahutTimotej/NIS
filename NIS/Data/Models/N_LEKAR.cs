using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_LEKAR
{
    public decimal ID_LEKARA { get; set; }

    public string RODNE_CISLO { get; set; } = null!;

    public decimal? ID_SPECIALIZACIE { get; set; }

    public decimal ID_ODDELENIA { get; set; }

    public virtual N_ODDELENIE ID_ODDELENIANavigation { get; set; } = null!;

    public virtual N_TYP_SPECIALIZACIE? ID_SPECIALIZACIENavigation { get; set; }

    public virtual ICollection<N_OPERACIum> N_OPERACIa { get; set; } = new List<N_OPERACIum>();

    public virtual ICollection<N_VYSETRENIE> N_VYSETRENIEs { get; set; } = new List<N_VYSETRENIE>();

    public virtual N_OSOBNE_UDAJE RODNE_CISLONavigation { get; set; } = null!;
}

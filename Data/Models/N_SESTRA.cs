using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_SESTRA
{
    public decimal ID_SESTRY { get; set; }

    public string RODNE_CISLO { get; set; } = null!;

    public decimal ID_ODDELENIA { get; set; }

    public virtual N_ODDELENIE ID_ODDELENIANavigation { get; set; } = null!;

    public virtual N_OSOBNE_UDAJE RODNE_CISLONavigation { get; set; } = null!;
}

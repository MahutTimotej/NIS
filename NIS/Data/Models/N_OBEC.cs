using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_OBEC
{
    public string PSC { get; set; } = null!;

    public string NAZOV { get; set; } = null!;

    public decimal ID_OKRESU { get; set; }

    public virtual N_OKRE ID_OKRESUNavigation { get; set; } = null!;

    public virtual ICollection<N_OSOBNE_UDAJE> N_OSOBNE_UDAJEs { get; set; } = new List<N_OSOBNE_UDAJE>();
}

using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_OKRE
{
    public decimal ID_OKRESU { get; set; }

    public string NAZOV { get; set; } = null!;

    public decimal ID_KRAJA { get; set; }

    public virtual N_KRAJ ID_KRAJANavigation { get; set; } = null!;

    public virtual ICollection<N_OBEC> N_OBECs { get; set; } = new List<N_OBEC>();
}

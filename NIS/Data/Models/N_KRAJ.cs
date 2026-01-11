using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_KRAJ
{
    public decimal ID_KRAJA { get; set; }

    public string NAZOV { get; set; } = null!;

    public virtual ICollection<N_OKRE> N_OKREs { get; set; } = new List<N_OKRE>();
}

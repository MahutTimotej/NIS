using System;
using System.Collections.Generic;

namespace NIS.Data.Models;

public partial class N_LIEK
{
    public string SUKL_KOD { get; set; } = null!;

    public string NAZOV { get; set; } = null!;

    public string? DOPLNOK { get; set; }

    public string? KOD_DRZ { get; set; }

    public string? KOD_STATU { get; set; }

    public string? ATC_KOD { get; set; }

    public string? ATC_NAZOV_SK { get; set; }

    public decimal? IDENTIFIKATOR { get; set; }

    public string? REG_CISLO { get; set; }

    public decimal? EXPIRACIA { get; set; }

    public string? VYDAJ { get; set; }

    public string? TYP_REG { get; set; }

    public DateTime? DATUM_REG { get; set; }

    public string? PLATNOST { get; set; }

    public string? BP { get; set; }

    public virtual ICollection<N_PREDPI> N_PREDPIs { get; set; } = new List<N_PREDPI>();
}

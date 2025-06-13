using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoDydaktyk
{
    public int DydaktykId { get; set; }

    public DateOnly DataRozpoczecia { get; set; }

    public DateOnly? DataZakonczenia { get; set; }

    public decimal Wyplata { get; set; }

    public virtual TpoOsoba Dydaktyk { get; set; }

    public virtual ICollection<TpoDydaktykPrzedmiot> TpoDydaktykPrzedmiots { get; set; } = new List<TpoDydaktykPrzedmiot>();

    public virtual ICollection<TpoOcena> TpoOcenas { get; set; } = new List<TpoOcena>();
}

using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoOcena
{
    public int StudentId { get; set; }

    public int PrzedmiotId { get; set; }

    public int SemestrId { get; set; }

    public int DydaktykId { get; set; }

    public decimal Ocena { get; set; }

    public virtual TpoDydaktyk Dydaktyk { get; set; }

    public virtual TpoPrzedmiot Przedmiot { get; set; }

    public virtual TpoSemestr Semestr { get; set; }

    public virtual TpoStudent Student { get; set; }
}

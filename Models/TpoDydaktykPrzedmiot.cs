using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoDydaktykPrzedmiot
{
    public int PrzedmiotId { get; set; }

    public int DydaktykId { get; set; }

    public int SemestrSemestrId { get; set; }

    public virtual TpoDydaktyk Dydaktyk { get; set; }

    public virtual TpoPrzedmiot Przedmiot { get; set; }

    public virtual TpoSemestr SemestrSemestr { get; set; }
}

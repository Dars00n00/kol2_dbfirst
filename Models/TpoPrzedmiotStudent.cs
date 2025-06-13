using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoPrzedmiotStudent
{
    public int StudentId { get; set; }

    public int PrzedmiotId { get; set; }

    public int SemestrSemestrId { get; set; }

    public virtual TpoPrzedmiot Przedmiot { get; set; }

    public virtual TpoSemestr SemestrSemestr { get; set; }

    public virtual TpoStudent Student { get; set; }
}

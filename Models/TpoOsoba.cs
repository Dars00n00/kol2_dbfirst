using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoOsoba
{
    public int OsobaId { get; set; }

    public string Imie { get; set; }

    public string Nazwisko { get; set; }

    public DateOnly DataUrodzenia { get; set; }

    public virtual TpoDydaktyk TpoDydaktyk { get; set; }

    public virtual TpoStudent TpoStudent { get; set; }
}

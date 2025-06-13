using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoForma
{
    public int FormaId { get; set; }

    public string Nazwa { get; set; }

    public virtual ICollection<TpoPrzedmiot> TpoPrzedmiots { get; set; } = new List<TpoPrzedmiot>();
}

using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoPrzedmiot
{
    public int PrzedmiotId { get; set; }

    public int FormaId { get; set; }

    public string CzyObowiazkowy { get; set; }

    public string Nazwa { get; set; }

    public int PunktyEtcs { get; set; }

    public virtual TpoForma Forma { get; set; }

    public virtual ICollection<TpoDydaktykPrzedmiot> TpoDydaktykPrzedmiots { get; set; } = new List<TpoDydaktykPrzedmiot>();

    public virtual ICollection<TpoOcena> TpoOcenas { get; set; } = new List<TpoOcena>();

    public virtual ICollection<TpoPrzedmiotStudent> TpoPrzedmiotStudents { get; set; } = new List<TpoPrzedmiotStudent>();
}

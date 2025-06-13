using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoSemestr
{
    public int SemestrId { get; set; }

    public string RokAkademicki { get; set; }

    public int NumerSemestru { get; set; }

    public virtual ICollection<TpoDydaktykPrzedmiot> TpoDydaktykPrzedmiots { get; set; } = new List<TpoDydaktykPrzedmiot>();

    public virtual ICollection<TpoOcena> TpoOcenas { get; set; } = new List<TpoOcena>();

    public virtual ICollection<TpoPrzedmiotStudent> TpoPrzedmiotStudents { get; set; } = new List<TpoPrzedmiotStudent>();
}

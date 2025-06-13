using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoStudent
{
    public int StudentId { get; set; }

    public DateOnly DataRozpoczecia { get; set; }

    public DateOnly? DataZakonczenia { get; set; }

    public int StatusId { get; set; }

    public virtual TpoStatus Status { get; set; }

    public virtual TpoOsoba Student { get; set; }

    public virtual ICollection<TpoOcena> TpoOcenas { get; set; } = new List<TpoOcena>();

    public virtual ICollection<TpoPrzedmiotStudent> TpoPrzedmiotStudents { get; set; } = new List<TpoPrzedmiotStudent>();
}

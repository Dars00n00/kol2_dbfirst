using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TpoStatus
{
    public int StatusId { get; set; }

    public string Nazwa { get; set; }

    public virtual ICollection<TpoStudent> TpoStudents { get; set; } = new List<TpoStudent>();
}

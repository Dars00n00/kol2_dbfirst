using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class ZadaniaPerson
{
    public int PersonId { get; set; }

    public string Fname { get; set; }

    public string Lname { get; set; }

    public string Email { get; set; }

    public virtual ICollection<ZadaniaTask> ZadaniaTasks { get; set; } = new List<ZadaniaTask>();
}

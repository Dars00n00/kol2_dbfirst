using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class ZadaniaUrgency
{
    public int UrgencyId { get; set; }

    public string Type { get; set; }

    public virtual ICollection<ZadaniaTask> ZadaniaTasks { get; set; } = new List<ZadaniaTask>();
}

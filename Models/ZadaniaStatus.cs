using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class ZadaniaStatus
{
    public int StatusId { get; set; }

    public string Type { get; set; }

    public virtual ICollection<ZadaniaTask> ZadaniaTasks { get; set; } = new List<ZadaniaTask>();
}

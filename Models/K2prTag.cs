using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K2prTag
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<K2prEvent> Events { get; set; } = new List<K2prEvent>();
}

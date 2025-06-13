using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K2prUser
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public virtual ICollection<K2prEvent> K2prEvents { get; set; } = new List<K2prEvent>();

    public virtual ICollection<K2prEvent> Events { get; set; } = new List<K2prEvent>();
}

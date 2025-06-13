using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K2prEvent
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }

    public int OrganizerId { get; set; }

    public virtual K2prUser Organizer { get; set; }

    public virtual ICollection<K2prTag> Tags { get; set; } = new List<K2prTag>();

    public virtual ICollection<K2prUser> Users { get; set; } = new List<K2prUser>();
}

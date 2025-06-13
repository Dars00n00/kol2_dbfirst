using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class ZadaniaTask
{
    public int TaskId { get; set; }

    public string Description { get; set; }

    public int StatusId { get; set; }

    public int UrgencyId { get; set; }

    public int PersonId { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfCompletion { get; set; }

    public virtual ZadaniaPerson Person { get; set; }

    public virtual ZadaniaStatus Status { get; set; }

    public virtual ZadaniaUrgency Urgency { get; set; }
}

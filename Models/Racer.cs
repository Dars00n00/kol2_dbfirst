using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class Racer
{
    public int RacerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public virtual ICollection<RaceParticipation> RaceParticipations { get; set; } = new List<RaceParticipation>();
}

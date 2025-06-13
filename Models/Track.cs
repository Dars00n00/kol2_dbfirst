using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class Track
{
    public int TrackId { get; set; }

    public string Name { get; set; }

    public decimal LengthInKm { get; set; }

    public virtual ICollection<TrackRace> TrackRaces { get; set; } = new List<TrackRace>();
}

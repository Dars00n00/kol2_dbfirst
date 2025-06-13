using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class Race
{
    public int RaceId { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<TrackRace> TrackRaces { get; set; } = new List<TrackRace>();
}

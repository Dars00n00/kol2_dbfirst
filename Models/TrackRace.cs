using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class TrackRace
{
    public int TrackRaceId { get; set; }

    public int TrackId { get; set; }

    public int RaceId { get; set; }

    public int Laps { get; set; }

    public int? BestTimeInSeconds { get; set; }

    public virtual Race Race { get; set; }

    public virtual ICollection<RaceParticipation> RaceParticipations { get; set; } = new List<RaceParticipation>();

    public virtual Track Track { get; set; }
}

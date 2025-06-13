using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class Cwiczenia12Trip
{
    public int IdTrip { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }

    public virtual ICollection<Cwiczenia12ClientTrip> Cwiczenia12ClientTrips { get; set; } = new List<Cwiczenia12ClientTrip>();

    public virtual ICollection<Cwiczenia12Country> IdCountries { get; set; } = new List<Cwiczenia12Country>();
}

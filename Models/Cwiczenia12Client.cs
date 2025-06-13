using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class Cwiczenia12Client
{
    public int IdClient { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Telephone { get; set; }

    public string Pesel { get; set; }

    public virtual ICollection<Cwiczenia12ClientTrip> Cwiczenia12ClientTrips { get; set; } = new List<Cwiczenia12ClientTrip>();
}

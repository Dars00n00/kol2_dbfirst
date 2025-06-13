using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class Cwiczenia12ClientTrip
{
    public int IdClient { get; set; }

    public int IdTrip { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Cwiczenia12Client IdClientNavigation { get; set; }

    public virtual Cwiczenia12Trip IdTripNavigation { get; set; }
}

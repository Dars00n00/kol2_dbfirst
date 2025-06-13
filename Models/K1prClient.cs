using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K1prClient
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public virtual ICollection<K1prCarRental> K1prCarRentals { get; set; } = new List<K1prCarRental>();
}

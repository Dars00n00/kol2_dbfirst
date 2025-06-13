using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K1rCustomer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<K1rDelivery> K1rDeliveries { get; set; } = new List<K1rDelivery>();
}

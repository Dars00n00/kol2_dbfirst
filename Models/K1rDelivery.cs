using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K1rDelivery
{
    public int DeliveryId { get; set; }

    public int CustomerId { get; set; }

    public int DriverId { get; set; }

    public DateTime Date { get; set; }

    public virtual K1rCustomer Customer { get; set; }

    public virtual K1rDriver Driver { get; set; }

    public virtual ICollection<K1rProductDelivery> K1rProductDeliveries { get; set; } = new List<K1rProductDelivery>();
}

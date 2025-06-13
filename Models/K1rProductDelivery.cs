using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K1rProductDelivery
{
    public int ProductId { get; set; }

    public int DeliveryId { get; set; }

    public int Amount { get; set; }

    public virtual K1rDelivery Delivery { get; set; }

    public virtual K1rProduct Product { get; set; }
}

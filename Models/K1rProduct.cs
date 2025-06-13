using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K1rProduct
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<K1rProductDelivery> K1rProductDeliveries { get; set; } = new List<K1rProductDelivery>();
}

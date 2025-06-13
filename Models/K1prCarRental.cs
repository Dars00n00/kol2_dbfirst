using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K1prCarRental
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int CarId { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int TotalPrice { get; set; }

    public int? Discount { get; set; }

    public virtual K1prCar Car { get; set; }

    public virtual K1prClient Client { get; set; }
}

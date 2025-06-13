using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K1prCar
{
    public int Id { get; set; }

    public string Vin { get; set; }

    public string Name { get; set; }

    public int Seats { get; set; }

    public int PricePerDay { get; set; }

    public int ModelId { get; set; }

    public int ColorId { get; set; }

    public virtual K1prColor Color { get; set; }

    public virtual ICollection<K1prCarRental> K1prCarRentals { get; set; } = new List<K1prCarRental>();

    public virtual K1prModel Model { get; set; }
}

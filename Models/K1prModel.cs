using System;
using System.Collections.Generic;

namespace kol2.Models;

public partial class K1prModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<K1prCar> K1prCars { get; set; } = new List<K1prCar>();
}

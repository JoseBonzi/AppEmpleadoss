using System;
using System.Collections.Generic;

namespace Empleados.Models;

public partial class Ciudade
{
    public Guid IdCiudad { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Sucursale> Sucursales { get; set; } = new List<Sucursale>();
}

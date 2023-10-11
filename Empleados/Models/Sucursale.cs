using System;
using System.Collections.Generic;

namespace Empleados.Models;

public partial class Sucursale
{
    public Guid IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public Guid IdCiudad { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Ciudade IdCiudadNavigation { get; set; } = null!;
}

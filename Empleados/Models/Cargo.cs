using System;
using System.Collections.Generic;

namespace Empleados.Models;

public partial class Cargo
{
    public Guid IdCargo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}

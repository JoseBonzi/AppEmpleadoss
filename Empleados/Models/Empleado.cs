using System;
using System.Collections.Generic;

namespace Empleados.Models;

public partial class Empleado
{
    public Guid IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public DateTime FechaAlta { get; set; }

    public Guid IdSucursal { get; set; }

    public Guid IdCargo { get; set; }

    public Guid IdJefe { get; set; }

    public int Activo { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
}

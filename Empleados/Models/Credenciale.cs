using System;
using System.Collections.Generic;

namespace Empleados.Models;

public partial class Credenciale
{
    public Guid IdCredencial { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public DateTime CreadoEn { get; set; }

    public DateTime ActualizadoEn { get; set; }

    public int Activo { get; set; }
}

using System;
using System.Collections.Generic;

namespace ProtoApp.Models;

public partial class Titulo
{
    public int IdTitulo { get; set; }

    public int Registro { get; set; }

    public string TituloLicenciatura { get; set; } = null!;

    public string NumeroControl { get; set; } = null!;

    public string ClavePlanEstudios { get; set; } = null!;

    public DateTime FechaActo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public long? Cedula { get; set; }

    public string? Observaciones { get; set; }
}

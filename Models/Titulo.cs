using System;
using System.Collections.Generic;

namespace ProtoApp.Models;

public partial class Titulo
{
    public int NoRegistro { get; set; }

    public int NoTitulo { get; set; }

    public string NoControl { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string? ApPaterno { get; set; }

    public string? ApMaterno { get; set; }

    public string ClavePlanDeEstudios { get; set; } = null!;

    public DateTime FechaActo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int? NoCedula { get; set; }

    public string? Observaciones { get; set; }
}

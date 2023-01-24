using System;
using System.Collections.Generic;

namespace ProtoApp.Models;

public partial class Titulo
{
    public int IdTitulo { get; set; }

    public int Registro { get; set; }

    public int TituloLicenciatura { get; set; }

    public string? NumeroControl { get; set; }

    public int? ClavePlanEstudios { get; set; }

    public DateTime? FechaActo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? Cedula { get; set; }

    public string? Observaciones { get; set; }
}

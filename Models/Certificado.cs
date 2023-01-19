using System;
using System.Collections.Generic;

namespace ProtoApp.Models;

public partial class Certificado
{
    public int NoReg { get; set; }

    public int NoFolio { get; set; }

    public string NoControl { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string? ApPaterno { get; set; }

    public string? ApMaterno { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? Observaciones { get; set; }
}

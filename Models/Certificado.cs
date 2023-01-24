using System;
using System.Collections.Generic;

namespace ProtoApp.Models;

public partial class Certificado
{
    public int IdCertificado { get; set; }

    public int RegistroCertificado { get; set; }

    public int Folio { get; set; }

    public string? NumeroControl { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Carrera { get; set; }

    public DateTime? FechaRegCert { get; set; }

    public string? Observaciones { get; set; }
}

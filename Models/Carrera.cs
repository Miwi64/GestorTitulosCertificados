using System;
using System.Collections.Generic;

namespace ProtoApp.Models;

public partial class Carrera
{
    public int CarreraId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;
}

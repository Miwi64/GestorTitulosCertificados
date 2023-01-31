using System;
using System.Collections.Generic;

namespace ProtoApp.Models;

public partial class Usuario
{
    public int UserId { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Contra { get; set; } = null!;

    public int Privilegios { get; set; }
}

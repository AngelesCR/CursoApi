using System;
using System.Collections.Generic;

namespace Curso.ApiPrueba.Model;

public partial class Role
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

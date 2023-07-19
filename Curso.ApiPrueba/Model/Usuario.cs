using System;
using System.Collections.Generic;

namespace Curso.ApiPrueba.Model;

public partial class Usuario
{
    public int Id { get; set; }

    public byte IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual Role IdRolNavigation { get; set; } = null!;
}

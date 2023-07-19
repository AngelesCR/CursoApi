using System;
using System.Collections.Generic;

namespace Curso.ApiPrueba.Model;

public partial class Curso
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public byte Estatus { get; set; }

    public decimal Porcentaje { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

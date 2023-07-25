namespace Curso.ApiPrueba.DTOs
{
    public class CursoDTO
    {
        public CursoDTO() { }
        #region "Constructor"
        public CursoDTO(
            byte Id,
            byte IdUsuario,
            string Nombre,
            DateTime Fecha,
            byte Estatus,
            decimal Porcentaje)
        {
            Id = Id;
            IdUsuario = IdUsuario;
            Nombre = Nombre;
            Fecha = Fecha;
            Estatus = Estatus;
            Porcentaje = Porcentaje;

        }
        #endregion
        #region "Propiedades"
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public byte Estatus { get; set; }

        public decimal Porcentaje { get; set; }
        #endregion
    }
}

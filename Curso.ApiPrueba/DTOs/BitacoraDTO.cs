namespace Curso.ApiPrueba.DTOs
{
    public class BitacoraDTO
    {
        public BitacoraDTO() { }
        #region "Constructor"
        public BitacoraDTO(
            int Id,
            byte IdUsuario,
            DateTime Fecha,
            byte Accion,
            byte Modulo,
            string Descripcion)
        {
            Id = Id;
            IdUsuario = IdUsuario;
            Fecha = Fecha;
            Accion = Accion;
            Modulo = Modulo;
            Descripcion = Descripcion;
        }
        #endregion
        #region "Propiedades"
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public byte Accion { get; set; }

        public byte Modulo { get; set; }

        public string Descripcion { get; set; } = null!;
        #endregion
    }
}

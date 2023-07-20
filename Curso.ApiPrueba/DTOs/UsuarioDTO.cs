namespace Curso.ApiPrueba.DTOs
{
    public class UsuarioDTO
    {
        public UsuarioDTO() { }
        #region "Constructor"
        public UsuarioDTO(
            int id,
            byte idRol,
            string nombre,
            string apellidos,
            DateTime fechaNacimiento,
            string correo,
            string contraseña)
        {
            Id = id;
            IdRol = idRol;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Correo = correo;
            Contraseña = contraseña;
        }
        #endregion

        #region "Propiedades"
        public int Id { get; set; }

        public byte IdRol { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;
        #endregion
    }

}

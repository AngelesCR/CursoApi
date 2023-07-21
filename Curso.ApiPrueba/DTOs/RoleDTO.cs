namespace Curso.ApiPrueba.DTOs
{
    public class RoleDTO
    {
        public RoleDTO() { }
        #region "Constructor"
        public RoleDTO(
            byte Id,
            string Nombre)
        {
            Id = Id;
            Nombre = Nombre;
        }
        #endregion
        #region "Propiedades"
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;
        #endregion
    }
}

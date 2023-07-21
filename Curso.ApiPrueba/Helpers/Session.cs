using Microsoft.AspNetCore.Identity;

namespace Curso.ApiPrueba.Helpers
{
    public class Session : IdentityUser
    {
        #region Propiedades
        public string Nombre { get; set; }
        public string Apellidos { get; set; } = null!;
        #endregion
    }
}

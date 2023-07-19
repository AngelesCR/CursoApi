using Curso.ApiPrueba.DTOs;
using Curso.ApiPrueba.Model;

namespace Curso.ApiPrueba.Services.Interfaces
{
    public interface IUsuariosServices
    {
        #region Implementacion
        Task<List<Usuario>> Obtener();
        Task<bool> Agregar(UsuarioDTO agregarUsuario);
        Task<bool> Eliminar(UsuarioDTO eliminarUsuario);
        Task<bool> Actualizar(UsuarioDTO actualizarUsuario);
        #endregion
    }
}

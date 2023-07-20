using Curso.ApiPrueba.DTOs;
using Curso.ApiPrueba.Model;

namespace Curso.ApiPrueba.Services.Interfaces
{
    public interface IUsuariosServices
    {
        #region "Implementaciones"
        Task<RespuestaGenerica<object>> Actualizar(UsuarioDTO modelo);
        Task<RespuestaGenerica<UsuarioDTO>> Eliminar(int id);
        Task<RespuestaGenerica<object>> Insertar(UsuarioDTO modelo);
        Task<RespuestaGenerica<List<UsuarioDTO>>> Obtener();
        #endregion

    }
}

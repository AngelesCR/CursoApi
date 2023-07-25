using Curso.ApiPrueba.DTOs;

namespace Curso.ApiPrueba.Services.Interfaces
{
    public interface ICurso
    {
        #region "Implementaciones"
        Task<RespuestaGenerica<object>> Actualizar(CursoDTO modelo);
        Task<RespuestaGenerica<CursoDTO>> Eliminar(int id);
        Task<RespuestaGenerica<object>> Insertar(CursoDTO modelo);
        Task<RespuestaGenerica<List<CursoDTO>>> Obtener();
        #endregion
    }
}

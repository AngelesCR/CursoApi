using Curso.ApiPrueba.DTOs;

namespace Curso.ApiPrueba.Services.Interfaces
{
    public interface IBitacoraServices
    {
        Task<RespuestaGenerica<object>> Insertar(BitacoraDTO modelo);
        Task<RespuestaGenerica<List<BitacoraDTO>>> Obtener();
    }
}

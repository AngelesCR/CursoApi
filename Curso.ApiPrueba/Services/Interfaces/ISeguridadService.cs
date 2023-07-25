using Curso.ApiPrueba.DTOs;

namespace Curso.ApiPrueba.Services.Interfaces
{
    public interface ISeguridadService
    {
        Task<RespuestaGenerica<UsuarioDTO>> Autenticar(string correo, string contraseña);

    }
}

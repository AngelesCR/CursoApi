using Curso.ApiPrueba.Model;

namespace Curso.ApiPrueba.Services.Interfaces
{
    public interface IRolesServices
    {
        Task<List<Role>> Obtener();
    }
}

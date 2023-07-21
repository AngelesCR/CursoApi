using Curso.ApiPrueba.Model;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Curso.ApiPrueba.Services
{
    public class RolesServices : IRolesServices

    {
        #region "Atributos"
        private readonly CursoDbContext dtx;
        #endregion

        #region "Constructor"
        public RolesServices(CursoDbContext dtx)
        {
            this.dtx = dtx;
        }
        #endregion
        public async Task<List<Role>> Obtener() => await dtx.Roles.ToListAsync();
    }
}

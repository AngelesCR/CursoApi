using Curso.ApiPrueba.Services;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ApiPrueba.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class RoleController : Controller
    {
        private readonly IRolesServices rolesServices; //inyeccion de interfas

        public RoleController(IRolesServices rolesServices)
        {
            this.rolesServices = rolesServices;
        }
        [HttpGet("ObtenerListaRoles")]
        public async Task<IActionResult> GetRole()
        {
            var roles = await rolesServices.Obtener();
            return Ok(roles);
        }
    }
}

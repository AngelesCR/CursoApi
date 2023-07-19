using Curso.ApiPrueba.DTOs;
using Curso.ApiPrueba.Model;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Curso.ApiPrueba.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : Controller
    {

        private readonly IUsuariosServices usuariosServices; //inyeccion de interfas

        public UsuariosController(IUsuariosServices usuariosServices)
        {
            this.usuariosServices = usuariosServices;
        }
        [HttpGet("ObtenerUsuario")]
        public async Task<IActionResult> Get()
        {
            var usuarios = await usuariosServices.Obtener();
            return Ok(usuarios);
        }

        [HttpPost("CrearUsuario")] 
        public async Task<IActionResult> Post(UsuarioDTO crearUser)
        {
            var usuarios = await usuariosServices.Agregar(crearUser);
            return Ok(usuarios);
        }

        [HttpDelete("EliminarUsuario")]
        public async Task<IActionResult> Delete(UsuarioDTO eliminarUser)
        {
            var usuarios = await usuariosServices.Eliminar(eliminarUser);
            return Ok(usuarios);
        }


        [HttpPut("ActualizarUsuario")]
        public async Task<IActionResult>Updated(UsuarioDTO actUser)
        {
            var usuarios = await usuariosServices.Actualizar(actUser);
            return Ok(usuarios);
        }

    }
}

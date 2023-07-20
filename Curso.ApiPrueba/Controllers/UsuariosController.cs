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

        [HttpPost] 
        public async Task<IActionResult> Post(UsuarioDTO crearUser)
        {
            var respuesta = await usuariosServices.Insertar(crearUser);

            if (respuesta.Valido)
            {
                return Ok(respuesta);
            }
            return BadRequest(respuesta.Mensaje);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var respuesta = await usuariosServices.Eliminar(id);
            
            if(respuesta.Valido)
            {
                return Ok(respuesta);
            }
            return BadRequest(respuesta.Mensaje);
        }


        [HttpPut]
        public async Task<IActionResult>Updated(UsuarioDTO actUser)
        {
            var respuesta = await usuariosServices.Actualizar(actUser);
            if (respuesta.Valido)
            {
                return Ok(respuesta);
            }
            return BadRequest(respuesta.Mensaje);
        }

    }
}

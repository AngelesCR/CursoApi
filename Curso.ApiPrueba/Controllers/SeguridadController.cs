using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ApiPrueba.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SeguridadController : Controller
    {
        private readonly ISeguridadService seguridadService;
        public SeguridadController(ISeguridadService seguridadService)

        {
            this.seguridadService = seguridadService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(string correo, string contraseña)
        {
            var respuesta = await seguridadService.Autenticar(correo,contraseña);
            if(respuesta.Valido)
            {
                return Ok(respuesta);
            }
            return BadRequest(respuesta.Mensaje);
        
        }

    }

}

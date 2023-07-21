using Curso.ApiPrueba.DTOs;
using Curso.ApiPrueba.Services;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ApiPrueba.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BitacoraController : Controller
    {

        private readonly IBitacoraServices bitacoraServices; //inyeccion de interfas

        public BitacoraController(IBitacoraServices bitacoraServices)
        {
            this.bitacoraServices = bitacoraServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await bitacoraServices.Obtener();
           if(usuarios.Valido)
            {
                return Ok(usuarios);

            }
            return BadRequest(usuarios.Mensaje);
        }
        
    }
}

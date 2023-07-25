using Curso.ApiPrueba.DTOs;
using Curso.ApiPrueba.Services;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ApiPrueba.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class CursoController : Controller
    {
        private readonly ICurso cursoServices; //inyeccion de interfas

        public CursoController(ICurso cursoServices)
        {
            this.cursoServices = cursoServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cursos = await cursoServices.Obtener();
            if (cursos.Valido)
            {
                return Ok(cursos);

            }
            return BadRequest(cursos.Mensaje);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CursoDTO crearCurso)
        {
            var respuesta = await cursoServices.Insertar(crearCurso);

            if (respuesta.Valido)
            {
                return Ok(respuesta);
            }
            return BadRequest(respuesta.Mensaje);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var respuesta = await cursoServices.Eliminar(id);

            if (respuesta.Valido)
            {
                return Ok(respuesta);
            }
            return BadRequest(respuesta.Mensaje);
        }
        [HttpPut]
        public async Task<IActionResult> Updated(CursoDTO actUser)
        {
            var respuesta = await cursoServices.Actualizar(actUser);
            if (respuesta.Valido)
            {
                return Ok(respuesta);
            }
            return BadRequest(respuesta.Mensaje);
        }
    }
}

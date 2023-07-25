using Curso.ApiPrueba.DTOs;
using CursoModel = Curso.ApiPrueba.Model;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Curso.ApiPrueba.Model;

namespace Curso.ApiPrueba.Services
{
    public class CursoServices : ICurso
    {
        #region "Atributos"
        private readonly CursoModel.CursoDbContext dtx;
        #endregion

        #region "Constructor"
        public CursoServices(CursoModel.CursoDbContext dtx)
        {
            this.dtx = dtx;
        }
        #endregion

        public async Task<RespuestaGenerica<object>> Actualizar(CursoDTO modelo)
        {
            RespuestaGenerica<object> respuesta = new()
            {
                Mensaje = "El curso no existe"
            };
            try
            {
                CursoModel.Curso?  existe = await dtx.Cursos.Where
                    (x => x.Id == modelo.Id).FirstOrDefaultAsync();
                if (existe == null)
                {
                    return respuesta;
                }

                existe.Nombre = modelo.Nombre;
                existe.Id = modelo.Id;
                existe.Fecha = modelo.Fecha;
                existe.Estatus = modelo.Estatus;
                existe.Porcentaje = modelo.Porcentaje;
                dtx.Cursos.Update(existe);
                await dtx.SaveChangesAsync();
                respuesta.Mensaje = "Se actualizo el usuario correctamente";
                respuesta.Objecto = modelo;
                respuesta.Valido = true;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }
            return respuesta;
        }

        public async Task<RespuestaGenerica<CursoDTO>> Eliminar(int id)
        {

            RespuestaGenerica<CursoDTO> respuesta = new()
            {
                Mensaje = "El curso no existe"
            };
            try
            {
                CursoModel.Curso? existe = await dtx.Cursos.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existe == null)
                {
                    return respuesta;
                }

                dtx.Cursos.Remove(existe);
                await dtx.SaveChangesAsync();
                respuesta.Mensaje = "Se elimino el curso correctamente";
                respuesta.Valido = true;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }
            return respuesta;
        }

        public async Task<RespuestaGenerica<object>> Insertar(CursoDTO modelo)
        {
            RespuestaGenerica<object> respuesta = new()
            {
                Mensaje = "Existe un curso con la misma informacion"
            };
            try
            {

                CursoModel.Curso? existe = await dtx.Cursos.Where
                    (x => x.Nombre.ToLower() == modelo.Nombre.ToLower())
                    .FirstOrDefaultAsync();

                if (existe != null)
                {
                    return respuesta;
                }

                existe = new CursoModel.Curso
                {
                    IdUsuario = modelo.IdUsuario,
                    Nombre = modelo.Nombre,
                    Fecha = modelo.Fecha,
                    Estatus = modelo.Estatus,
                    Porcentaje = modelo.Porcentaje
                };
                await dtx.Cursos.AddAsync(existe);
                await dtx.SaveChangesAsync();
                modelo.Id = existe.Id;
                respuesta.Mensaje = "Se creo el curso correctamente";
                respuesta.Valido = true;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.InnerException.Message;
            }
            return respuesta;
        }

        public async Task<RespuestaGenerica<List<CursoDTO>>> Obtener()
        {
            RespuestaGenerica<List<CursoDTO>> respuesta = new();
            try
            {
                respuesta.Objecto = await dtx.Cursos
                    .Select(x => new CursoDTO
                    {
                        Id = x.Id,
                        IdUsuario = x.IdUsuario,
                        Nombre = x.Nombre,
                        Fecha = x.Fecha,
                        Estatus = x.Estatus,
                        Porcentaje = x.Porcentaje

                    }).ToListAsync();

                respuesta.Valido = true;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }
            return respuesta;
        }

    }
}

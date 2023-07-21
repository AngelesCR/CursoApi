using Curso.ApiPrueba.DTOs;
using Curso.ApiPrueba.Model;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.ApiPrueba.Services
{
    public class BitacoraServices : IBitacoraServices
    {
        #region "Atributos"
        private readonly CursoDbContext dtx;
        #endregion

        #region "Constructor"
        public BitacoraServices(CursoDbContext dtx)
        {
            this.dtx = dtx;
        }
        #endregion

        public async Task<RespuestaGenerica<object>> Insertar(BitacoraDTO modelo)
        {
            RespuestaGenerica<object> respuesta = new();

            try
            {
                Bitacora bitacora = new()
                {
                Accion= modelo.Accion,
                Descripcion= modelo.Descripcion,
                Fecha=modelo.Fecha,
                IdUsuario= modelo.IdUsuario,
                Modulo= modelo.Modulo
                };
                await dtx.Bitacoras.AddAsync(bitacora);
                await dtx.SaveChangesAsync();
                respuesta.Mensaje = "Se registro correctamete";
                respuesta.Valido = true;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }
            return respuesta;
        }

        public async Task<RespuestaGenerica<List<BitacoraDTO>>> Obtener()
        {
            RespuestaGenerica<List<BitacoraDTO>> respuesta = new();
            try
            {
                respuesta.Objecto = await dtx.Bitacoras
                    .Select(x => new BitacoraDTO
                    {
                        Accion= x.Accion,
                        Descripcion=x.Descripcion,
                        Fecha=x.Fecha,
                        IdUsuario=x.IdUsuario,
                        Modulo=x.Modulo

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

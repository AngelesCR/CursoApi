using Curso.ApiPrueba.DTOs;
using Curso.ApiPrueba.Model;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.ApiPrueba.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        #region "Atributos"
        private readonly CursoDbContext dtx;
        #endregion

        #region "Constructor"
        public UsuariosServices(CursoDbContext dtx)
        {
            this.dtx = dtx;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Comprueba que el usuario exista.
        /// No se actualiza el correo.
        /// </summary>
        public async Task<RespuestaGenerica<object>> Actualizar(UsuarioDTO modelo)
        {
            RespuestaGenerica<object> respuesta = new()
            {
                Mensaje = "El usuario no existe"
            };
            try
            {
                Usuario? existe = await dtx.Usuarios.Where(x => x.Id == modelo.Id).FirstOrDefaultAsync();
                if (existe == null)
                {
                    return respuesta;
                }

                existe.Nombre = modelo.Nombre;
                existe.IdRol = modelo.IdRol;
                existe.Apellidos = modelo.Apellidos;
                existe.Contraseña = modelo.Contraseña;
                existe.FechaNacimiento = modelo.FechaNacimiento;
                dtx.Usuarios.Update(existe);
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

        public async Task<RespuestaGenerica<UsuarioDTO>>Eliminar(int id)
        {
            RespuestaGenerica<UsuarioDTO> respuesta = new()
            {
                Mensaje = "El usuario no existe"
            };
            try
            {
                Usuario? existe = await dtx.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existe == null)
                {
                    return respuesta;
                }

                dtx.Usuarios.Remove(existe);
                await dtx.SaveChangesAsync();
                respuesta.Mensaje = "Se elimino el usuario correctamente";
                respuesta.Objecto = new UsuarioDTO(existe.Id, existe.IdRol, existe.Nombre, existe.Apellidos, existe.FechaNacimiento, existe.Contraseña, existe.Contraseña);
                respuesta.Valido = true;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }
            return respuesta;
        }

        public async Task<RespuestaGenerica<object>> Insertar(UsuarioDTO modelo)
        {
            RespuestaGenerica<object> respuesta = new()
            {
                Mensaje = "Existe un usuario con la misma información"
            };
            try
            {
                Usuario? existe = await dtx.Usuarios
                    .Where(x => x.Correo.ToLower() == modelo.Correo.ToLower()).FirstOrDefaultAsync();
                if (existe != null)
                {
                    return respuesta;
                }

                existe = new Usuario
                {
                    Id = modelo.Id,
                    Apellidos = modelo.Apellidos,
                    Contraseña = modelo.Contraseña,
                    Correo = modelo.Correo,
                    FechaNacimiento = modelo.FechaNacimiento,
                    IdRol = modelo.IdRol,
                    Nombre = modelo.Nombre
                };
                await dtx.Usuarios.AddAsync(existe);
                await dtx.SaveChangesAsync();
                modelo.Id = existe.Id;
                respuesta.Mensaje = "Se creo el usuario correctamente";
                respuesta.Valido = true;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.InnerException.Message;
            }
            return respuesta;
        }

        public async Task<RespuestaGenerica<List<UsuarioDTO>>> Obtener()
        {
            RespuestaGenerica<List<UsuarioDTO>> respuesta = new();
            try
            {
                respuesta.Objecto = await dtx.Usuarios
                    .Select(x => new UsuarioDTO(x.Id, x.IdRol, x.Nombre, x.Apellidos, x.FechaNacimiento, x.Correo, x.Contraseña))
                    .ToListAsync();
                respuesta.Valido = true;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }
            return respuesta;
        }
        #endregion

    }
}

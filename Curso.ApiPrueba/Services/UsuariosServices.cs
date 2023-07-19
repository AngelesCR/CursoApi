using Curso.ApiPrueba.DTOs;
using Curso.ApiPrueba.Model;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.ApiPrueba.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly CursoDbContext dtx; //crea un atributo de la clase
        public UsuariosServices(CursoDbContext dtx)
        {
            this.dtx = dtx;
        }
        public async Task<List<Usuario>> Obtener()
        {
            var usuarios = await dtx.Usuarios.ToListAsync();
            return usuarios;
        }


        public async Task<bool> Agregar(UsuarioDTO crearUser)
        {
            Usuario usregistro = new Usuario
            {
                Nombre = crearUser.Nombre,
                Apellidos = crearUser.Apellidos,
                FechaNacimiento = crearUser.FechaNacimiento,
                Correo = crearUser.Correo,
                Contraseña = crearUser.Contraseña,
                IdRol = crearUser.IdRol
            };
            var registro = dtx.Usuarios.Add(usregistro);
            await dtx.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Actualizar(UsuarioDTO actualizarUsuario)
        {
            Usuario usactualizar = new Usuario
            {
                Id= actualizarUsuario.Id,
                Nombre = actualizarUsuario.Nombre,
                Apellidos = actualizarUsuario.Apellidos,
                FechaNacimiento = actualizarUsuario.FechaNacimiento,
                Correo = actualizarUsuario.Correo,
                Contraseña = actualizarUsuario.Contraseña,
                IdRol = actualizarUsuario.IdRol
            };
            var act = dtx.Usuarios.Update(usactualizar);
            await dtx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(UsuarioDTO eliminarUsuario)
        {
            Usuario useliminar = new Usuario
            {
                Id = eliminarUsuario.Id
            };
            var eliminar = dtx.Usuarios.Remove(useliminar);
            await dtx.SaveChangesAsync();
            return true;
        }
    }
}

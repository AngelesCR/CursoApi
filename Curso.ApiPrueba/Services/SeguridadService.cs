using Curso.ApiPrueba.DTOs;
using Curso.ApiPrueba.Model;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Curso.ApiPrueba.Services
{
    public class SeguridadService : ISeguridadService
    {
        #region "Atributos"
        private readonly IConfiguration configuration;
        private readonly CursoDbContext dtx;
        #endregion

        #region "Constructor"
        public SeguridadService(CursoDbContext dtx, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.dtx = dtx;
        }
        #endregion
        public async Task<RespuestaGenerica<UsuarioDTO>> Autenticar(string correo, string contraseña)
        {
            RespuestaGenerica<UsuarioDTO> respuesta = new();
            try
            {
                Usuario? usuario = await dtx.Usuarios
                    .Where(x => x.Correo.ToLower() == correo.ToLower() && x.Contraseña == contraseña)
                    .FirstOrDefaultAsync();
                if (usuario != null)
                {
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                    var credenciales = new SigningCredentials
                        (new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature);
                    var subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                     new Claim(ClaimTypes.Role, usuario.IdRol.ToString()),
                      new Claim(ClaimTypes.Email, usuario.Correo),
                    });

                    var expires = DateTime.UtcNow.AddMinutes(10);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        SigningCredentials = credenciales
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    string jwtToken = tokenHandler.WriteToken(token);
                    respuesta.Objecto = new()
                    {
                        Nombre = usuario.Nombre,
                        Apellidos = usuario.Apellidos,
                        FechaNacimiento = usuario.FechaNacimiento,
                        IdRol = usuario.IdRol,
                        Token = jwtToken

                    };
                    respuesta.Valido = true;
                }
                else
                {
                    respuesta.Mensaje = "Usuario o contraseña incorrectos";
                }

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.InnerException.Message;

            }
            return respuesta;
        }
    }
}

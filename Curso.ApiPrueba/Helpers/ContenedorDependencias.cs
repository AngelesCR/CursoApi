using Curso.ApiPrueba.Model;
using Curso.ApiPrueba.Services;
using Curso.ApiPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Curso.ApiPrueba.Helpers
{
    public static class ContenedorDependencias
    {
        #region "Métodos"
        public static IServiceCollection AgregarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CursoDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("Database"), op =>
                { //linea que espera la conexion...tarea investigar para que funciona cada metodo
                    op.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(60), null);
                });
            });
            services.AddScoped<IUsuariosServices, UsuariosServices>();
            services.AddScoped<IBitacoraServices, BitacoraServices>();
            services.AddScoped<IRolesServices, RolesServices>();
            services.AddScoped<ISeguridadService, SeguridadService>();
            services.AddScoped<ICurso, CursoServices>();
            return services;
        }
        #endregion   
    }
}

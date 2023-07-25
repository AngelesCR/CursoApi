using Curso.ApiPrueba.Controllers;
using Curso.ApiPrueba.Helpers;
using Curso.ApiPrueba.Model;
using Curso.ApiPrueba.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.IdentityModel.Tokens;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Collections.Specialized.BitVector32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//controla la sesion de un usuario
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();
//CONTROLA LOS ROLES DE LA SESSION DE UN USUARIO
builder.Services.AgregarDependencias(builder.Configuration);

//builder.Services.AddIdentityCore<Session>().AddRoles<IdentityRole>();
//controla las solicitudes
builder.Services.AddHttpContextAccessor();
//controla la autorizacion en los controladores
builder.Services.AddAuthorization();
//controla el esquema de auntetificacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //configura la estructura y validacion de un token de un token 
    .AddJwtBearer(o => {
        o.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero
        };
        o.Events= new JwtBearerEvents
        {
            OnTokenValidated = ctx =>
            {
                if (ctx.SecurityToken is JwtSecurityToken accessToken)
                {
                    if (ctx.Principal.Identities is ClaimsIdentity identity)

                    {
                        identity.AddClaim(new Claim("access_token", accessToken.RawData));

                    }
                }
                return Task.CompletedTask;
            },
           OnAuthenticationFailed = ctx =>
            {
                if (ctx.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    ctx.Response.Headers.Add("Token-Expired", "true");
                }
                return Task.CompletedTask;
            }
            };
    });
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


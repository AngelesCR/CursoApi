using Curso.ApiPrueba.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;
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
builder.Services.AddIdentityCore<Session>().AddRoles<IdentityRole>();
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
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
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();


﻿namespace Curso.ApiPrueba.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public byte IdRol { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;
    }
}

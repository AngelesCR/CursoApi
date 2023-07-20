namespace Curso.ApiPrueba.DTOs
{
    public class RespuestaGenerica<T> where T : new()
    {
        #region "Propiedades"
        public T? Objecto { get; set; }
        public string Mensaje { get; set; } = null!;
        public bool Valido { get; set; }
        #endregion
    }
}

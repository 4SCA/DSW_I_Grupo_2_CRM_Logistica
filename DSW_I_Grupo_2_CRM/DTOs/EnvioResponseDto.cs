namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class EnvioResponseDto
    {
        public int IdEnvio {  get; set; }
        public int IdCotizacion { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaEntrega { get; set; }
    }
}

namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class EnvioDTO
    {
        public int IdEnvio { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int CotizacionId { get; set; }
    }
}

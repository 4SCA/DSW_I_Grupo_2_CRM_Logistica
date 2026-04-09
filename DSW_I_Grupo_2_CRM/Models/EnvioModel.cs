namespace DSW_I_Grupo_2_CRM.Models
{
    public class EnvioModel
    {
        public int IdEnvio { get; set; }
        public int IdCotizacion { get; set; }
        public CotizacionModel Cotizacion { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public List<SeguimientoModel> Seguimientos { get; set; } = new();
    }
}

namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class CotizacionDTO
    {
        public int IdCotizacion { get; set; }
        public string NumeroCorrelativo { get; set; }
        public string ClienteRazonSocial { get; set; }
        public string UsuarioNombre { get; set; }
        public string Estado { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

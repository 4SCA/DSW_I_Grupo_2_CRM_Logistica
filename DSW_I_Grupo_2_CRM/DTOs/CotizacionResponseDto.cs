namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class CotizacionResponseDto
    {
        public int IdCotizacion { get; set; }
        public string NumeroCorrelativo { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }

        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

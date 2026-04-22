namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class HistorialCotizacionResponseDto
    {
        public int IdHist { get; set; }
        public int IdCotizacion { get; set; }
        public string EstadoAnterior { get; set; }
        public string EstadoNuevo { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
    }
}
